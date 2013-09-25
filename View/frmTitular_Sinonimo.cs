using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using System.Data;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitular_Sinonimo : Form
    {
        bool flagValidacion;
        long tis_id = 0;
        long tit_id;
        
        
        public frmTitular_Sinonimo()
        {
            InitializeComponent();
        }
        private void frmTitular_Sinonimo_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
            {
                Cargar();
                CargarTitular();
            }
            if (frmTitularLista.tit_id1 == 0)//Si es igual a 0 significa que se inserta desde el Menu regalias
            {
                lblTitular.Visible = false;
                //lblTitular.Text = (frmTitularLista.tit_nombre1!= "" ? "Titular: " + frmTitularLista.tit_nombre1 : "");
                cbofields1.Visible = true;
                lblcbofields1.Visible = true;
            }
            else
            {
                lblTitular.Visible = true;
                //lblTitular.Text = (frmTitularLista.tit_nombre1 != "" ? "Titular: " + frmTitularLista.tit_nombre1 : "");
                cbofields1.Visible = false;
                lblcbofields1.Visible = false;
            }
        }
        private void CargarTitular()
        {
            List<Titular> listaTitulars = new List<Titular>();
            listaTitulars = TitularController.GetListTitular(0);
            cbofields1.DataSource = listaTitulars;
            cbofields1.DisplayMember = "tit_nombre";
            cbofields1.ValueMember = "tit_id";
        }
        private void cbofields1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        
        private void txtfields1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarTitulars())
                return;

            if (frmTitularLista.tit_id1 == 0)
                tit_id = Convert.ToInt64(cbofields1.SelectedValue);
            else
                tit_id = Convert.ToInt64(frmTitularLista.tit_id1);
            Guardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Cargar()
        {

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;            
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar el titular");
            toolTip1.SetToolTip(this.cbofields1, "Indicar el titular");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Sinonimo");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Sinonimo");

            
        }
        public void Buscar()
        {
            Cargar();
            CargarTitular();
            tis_id = frmTitular_SinonimoLista.tis_id1;
            List<Titular_Sinonimo> lstTitular_Sinonimo = new List<Titular_Sinonimo>();
            Titular_SinonimoObject objTitular_SinonimoObject = new Titular_SinonimoObject();
            lstTitular_Sinonimo = objTitular_SinonimoObject.listTitular_Sinonimo(tis_id);
            if (lstTitular_Sinonimo.Count != 0)
            {
                lstTitular_Sinonimo.ForEach(delegate(Titular_Sinonimo r)
                {
                    txtfields1.Text = System.Convert.ToString(r.Tis_nombre);
                    cbofields1.Text = r.Tit_nombre;
                    
                    
                });
                flagValidacion = true;
            }
            else
                flagValidacion = false;
        }

        private bool validarTitulars()
        {
            bool flag = false;
            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre el Sinonimo", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            
            flag = true;
            return flag;
        }
        private void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)
            {
                switch (MessageBox.Show("Actualizar registro?",
                              "Validación GEdS Desktop",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Titular_Sinonimo> lstproyecto = new List<Titular_Sinonimo>();
                        Titular_Sinonimo contrato_sinonimo = new Titular_Sinonimo();
                        contrato_sinonimo.Tis_id = Convert.ToInt64(tis_id);
                        contrato_sinonimo.Tit_id = Convert.ToInt64(tit_id);
                        contrato_sinonimo.Tis_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Tis_estado = 1;

                        lstproyecto.Add(contrato_sinonimo);
                        Titular_Sinonimo objTitular_Sinonimo = new Titular_Sinonimo();
                        accion = objTitular_Sinonimo.update(lstproyecto);

                    if (accion == 0)
                        {
                            MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                switch (MessageBox.Show("Grabar registro?",
                              "Validación GEdS Desktop",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Titular_Sinonimo> lstproyecto = new List<Titular_Sinonimo>();
                        Titular_Sinonimo contrato_sinonimo = new Titular_Sinonimo();
                        contrato_sinonimo.Tis_id = 0;
                        contrato_sinonimo.Tit_id = Convert.ToInt64(tit_id);
                        contrato_sinonimo.Tis_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Tis_estado = 1;
                        lstproyecto.Add(contrato_sinonimo);
                        Titular_Sinonimo objTitular_Sinonimo = new Titular_Sinonimo();
                        accion = objTitular_Sinonimo.insert(lstproyecto);
                        if (accion == 0)
                        {
                            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }                    
        }
    }
}