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
    public partial class frmBloque : Form
    {
        bool flagValidacion;
        long blo_id = 0;
        public frmBloque()
        {
            InitializeComponent();
            Cargar();
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

        #region Metodos Controller()
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Bloque");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Bloque");
        }

        public void Buscar()
        {
            blo_id = frmBloqueLista.blo_id1;

            List<Bloque> lstBloque = new List<Bloque>();
            lstBloque = BloqueController.GetListBloques(blo_id);
            if (lstBloque.Count != 0)
            {
                lstBloque.ForEach(delegate(Bloque b)
                {
                    txtfields1.Text = b.Blo_codigo;
                    txtfields2.Text = b.Blo_nombre;
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
                MessageBox.Show(this, "Registre el Código del Bloque", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre del Bloque", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
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
                        List<Bloque> lstBloque = new List<Bloque>();
                        lstBloque.Add(new Bloque(blo_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        Bloque bloque = new Bloque();
                        accion = bloque.update(lstBloque);
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
                        List<Bloque> lstBloque = new List<Bloque>();
                        lstBloque.Add(new Bloque(0, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        Bloque bloque = new Bloque();
                        accion = bloque.insert(lstBloque);
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
        }
    }
}