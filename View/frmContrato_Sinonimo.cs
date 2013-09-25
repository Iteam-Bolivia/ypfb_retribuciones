using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using System.Data;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmContrato_Sinonimo : Form
    {
        bool flagValidacion;
        long cts_id = 0;
        long ctt_id;

        
        public frmContrato_Sinonimo()
        {
            InitializeComponent();
        }
        private void frmContrato_Sinonimo_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
            {
                Cargar();
                CargarContratos();
            }
            if (frmContratoLista.ctt_id1 == 0)//Si es igual a 0 significa que se inserta desde el Menu regalias
            {
                lblContrato.Visible = false;
                lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
                cbofields1.Visible = true;
                lblcbofields1.Visible = true;
            }
            else
            {
                lblContrato.Visible = true;
                lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
                cbofields1.Visible = false;
                lblcbofields1.Visible = false;
            }
        }
        private void CargarContratos()
        {
            List<Contrato> listaContratos = new List<Contrato>();
            listaContratos = ContratoController.GetListContrato(0);
            cbofields1.DataSource = listaContratos;
            cbofields1.DisplayMember = "ctt_nombre";
            cbofields1.ValueMember = "ctt_id";
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
            if (!validarCampos())
                return;

            if (frmContratoLista.ctt_id1 == 0)
                ctt_id = Convert.ToInt64(cbofields1.SelectedValue);
            else
                ctt_id = Convert.ToInt64(frmContratoLista.ctt_id1);
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
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar el contrato");
            toolTip1.SetToolTip(this.cbofields1, "Indicar el contrato");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Sinonimo");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Sinonimo");

            
        }
        public void Buscar()
        {
            Cargar();
            CargarContratos();
            cts_id = frmContrato_SinonimoLista.cts_id1;
            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
            Contrato_SinonimoObject objContrato_SinonimoObject = new Contrato_SinonimoObject();
            lstContrato_Sinonimo = objContrato_SinonimoObject.listContrato_Sinonimo(cts_id);
            if (lstContrato_Sinonimo.Count != 0)
            {
                lstContrato_Sinonimo.ForEach(delegate(Contrato_Sinonimo r)
                {
                    cbofields1.Text = r.Ctt_nombre;
                    txtfields1.Text = System.Convert.ToString(r.Cts_nombre);
                    
                });
                flagValidacion = true;
            }
            else
                flagValidacion = false;
        }

        private bool validarCampos()
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
                              "Validación del Sistema",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Contrato_Sinonimo> lstproyecto = new List<Contrato_Sinonimo>();
                        Contrato_Sinonimo contrato_sinonimo = new Contrato_Sinonimo();
                        contrato_sinonimo.Cts_id = Convert.ToInt64(cts_id);
                        contrato_sinonimo.Ctt_id = Convert.ToInt64(ctt_id);
                        contrato_sinonimo.Cts_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Cts_estado = 1;

                        lstproyecto.Add(contrato_sinonimo);
                        Contrato_Sinonimo objContrato_Sinonimo = new Contrato_Sinonimo();
                        accion = objContrato_Sinonimo.update(lstproyecto);

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
                              "Validación del Sistema",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Contrato_Sinonimo> lstproyecto = new List<Contrato_Sinonimo>();
                        Contrato_Sinonimo contrato_sinonimo = new Contrato_Sinonimo();
                        contrato_sinonimo.Cts_id = 0;
                        contrato_sinonimo.Ctt_id = Convert.ToInt64(ctt_id);
                        contrato_sinonimo.Cts_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Cts_estado = 1;
                        lstproyecto.Add(contrato_sinonimo);
                        Contrato_Sinonimo objContrato_Sinonimo = new Contrato_Sinonimo();
                        accion = objContrato_Sinonimo.insert(lstproyecto);
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