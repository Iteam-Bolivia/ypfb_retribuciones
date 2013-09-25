using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampo : Form
    {
        bool flagValidacion;
        long cam_id = 0;
        public frmCampo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboBloques_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32 || Convert.ToInt32(e.KeyChar) == 45)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            //else if (Convert.ToInt32(e.KeyChar) == 32)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }


        #region Metodos Controller()
        protected void Cargar()
        {
            
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Campo");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Campo");
        }

        public void Buscar()
        {
            cam_id = frmCampoLista.cam_id1;

            
            List<Campo> lstCampo = new List<Campo>();
            lstCampo = CampoController.GetListCampos(cam_id);
            if (lstCampo.Count != 0)
            {
                lstCampo.ForEach(delegate(Campo  c)
                {
                    txtCodigo.Text = c.Cam_codigo;
                    txtNombre.Text = c.Cam_nombre;
                });
                flagValidacion = true;
                //gbCabecera.Text = "Actualizacíón de Contratos";
            }
            else
            {
                flagValidacion = false;
            }
        }

        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(this, "Registre el Código del Campo", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(this, "Registre el Nombre del Campo", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return flag;
            }
            return flag = true;
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Campo> lstCampo = new List<Campo>();
                        Campo campoObjet = new Campo();
                        campoObjet.Cam_id = cam_id;
                        campoObjet.Cam_codigo = txtCodigo.Text.Trim().ToUpper();
                        campoObjet.Cam_nombre = txtNombre.Text.Trim().ToUpper();
                        campoObjet.Cam_estado = 1;
                        campoObjet.Blo_id = 1;
                        
                        //lstCampo.Add(new Campo(cam_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        lstCampo.Add(campoObjet);
                        Campo campo = new Campo();
                        accion = campo.update(lstCampo);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else//Registrar
            {
                switch (MessageBox.Show("Grabar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Campo> lstCampo = new List<Campo>();
                        Campo campoObjet = new Campo();
                        campoObjet.Cam_id = 0;
                        campoObjet.Cam_codigo = txtCodigo.Text.Trim().ToUpper();
                        campoObjet.Cam_nombre = txtNombre.Text.Trim().ToUpper();
                        campoObjet.Cam_estado = 1;
                        campoObjet.Blo_id = 1;
                        //lstCampo.Add(new Campo(0,  txtCodigo.Text.Trim().ToUpper(), txtNombre.Text.Trim().ToUpper(), 1));
                        lstCampo.Add(campoObjet);
                        Campo campo = new Campo();
                        accion = campo.insert(lstCampo);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        #endregion

        private void frmCampo_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtfields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtfields2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}