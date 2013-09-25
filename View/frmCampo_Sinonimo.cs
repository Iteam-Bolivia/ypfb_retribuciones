using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using System.Data;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampo_Sinonimo : Form
    {
        bool flagValidacion;
        long cas_id = 0;
        long cam_id;

        
        public frmCampo_Sinonimo()
        {
            InitializeComponent();
        }
        private void frmCampo_Sinonimo_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
            {
                Cargar();
                CargarCampos();
            }
            if (frmCampoLista.cam_id1 == 0)//Si es igual a 0 significa que se inserta desde el Menu regalias
            {
                lblCampo.Visible = false;
                lblCampo.Text = (frmCampoLista.cam_nombre1 != "" ? "Campo: " + frmCampoLista.cam_nombre1 : "");
                cbofields1.Visible = true;
                lblcbofields1.Visible = true;
            }
            else
            {
                lblCampo.Visible = true;
                lblCampo.Text = (frmCampoLista.cam_nombre1 != "" ? "Campo: " + frmCampoLista.cam_nombre1 : "");
                cbofields1.Visible = false;
                lblcbofields1.Visible = false;
            }
        }
        private void CargarCampos()
        {
            List<Campo> listaCampos = new List<Campo>();
            listaCampos = CampoController.GetListCampos(0);
            cbofields1.DataSource = listaCampos;
            cbofields1.DisplayMember = "ctt_nombre";
            cbofields1.ValueMember = "cam_id";
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

            if (frmCampoLista.cam_id1 == 0)
                cam_id = Convert.ToInt64(cbofields1.SelectedValue);
            else
                cam_id = Convert.ToInt64(frmCampoLista.cam_id1);
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
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar el campo");
            toolTip1.SetToolTip(this.cbofields1, "Indicar el campo");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Sinonimo");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Sinonimo");

            
        }
        public void Buscar()
        {
            Cargar();
            CargarCampos();
            cas_id = frmCampo_SinonimoLista.cas_id1;
            List<Campo_Sinonimo> lstCampo_Sinonimo = new List<Campo_Sinonimo>();
            Campo_SinonimoObject objCampo_SinonimoObject = new Campo_SinonimoObject();
            lstCampo_Sinonimo = objCampo_SinonimoObject.listCampo_Sinonimo(cas_id);
            if (lstCampo_Sinonimo.Count != 0)
            {
                lstCampo_Sinonimo.ForEach(delegate(Campo_Sinonimo r)
                {
                    cbofields1.Text = r.Cam_nombre;
                    txtfields1.Text = System.Convert.ToString(r.Cas_nombre);
                    
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
                        List<Campo_Sinonimo> lstproyecto = new List<Campo_Sinonimo>();
                        Campo_Sinonimo contrato_sinonimo = new Campo_Sinonimo();
                        contrato_sinonimo.Cas_id = Convert.ToInt64(cas_id);
                        contrato_sinonimo.Cam_id = Convert.ToInt64(cam_id);
                        contrato_sinonimo.Cas_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Cas_estado = 1;

                        lstproyecto.Add(contrato_sinonimo);
                        Campo_Sinonimo objCampo_Sinonimo = new Campo_Sinonimo();
                        accion = objCampo_Sinonimo.update(lstproyecto);

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
                        List<Campo_Sinonimo> lstproyecto = new List<Campo_Sinonimo>();
                        Campo_Sinonimo contrato_sinonimo = new Campo_Sinonimo();
                        contrato_sinonimo.Cas_id = 0;
                        contrato_sinonimo.Cam_id = Convert.ToInt64(cam_id);
                        contrato_sinonimo.Cas_nombre = Convert.ToString(txtfields1.Text).Trim();
                        contrato_sinonimo.Cas_estado = 1;
                        lstproyecto.Add(contrato_sinonimo);
                        Campo_Sinonimo objCampo_Sinonimo = new Campo_Sinonimo();
                        accion = objCampo_Sinonimo.insert(lstproyecto);
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