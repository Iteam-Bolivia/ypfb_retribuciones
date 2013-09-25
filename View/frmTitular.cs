using System;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitular : Form
    {
        bool flagValidacion;
        long tit_id = 0;
        public frmTitular()
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
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
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #region Metodos Controller()
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Titular");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Titular");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Código del Titular");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre del Titular");
        }

        public void Buscar()
        {
            tit_id = frmTitularLista.tit_id1;

            List<Titular> lstTitular = new List<Titular>();
            lstTitular = TitularController.GetListTitulares(tit_id);
            if (lstTitular.Count != 0)
            {
                lstTitular.ForEach(delegate(Titular t)
                {
                    txtfields1.Text = t.Tit_codigo;
                    txtfields2.Text = t.Tit_nombre;
                    txtfields3.Text = System.Convert.ToString(t.Tit_orden);
                });
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
            }
        }

        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
                MessageBox.Show(this, "Registre el Código del Titular", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre del Titular", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields3.Text))
            {
              MessageBox.Show(this, "Registre el Orden del Titular", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              txtfields3.Focus();
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
                        List<Titular> lstTitular = new List<Titular>();
                        lstTitular.Add(new Titular(tit_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1, System.Convert.ToInt32(txtfields3.Text.Trim())));
                        Titular titular = new Titular();
                        accion = titular.update(lstTitular);
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
                        List<Titular> lstTitular = new List<Titular>();
                        lstTitular.Add(new Titular(0, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1, System.Convert.ToInt32(txtfields3.Text.Trim())));
                        Titular titular = new Titular();
                        accion = titular.insert(lstTitular);
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
    }
}