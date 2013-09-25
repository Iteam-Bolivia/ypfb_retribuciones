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
    public partial class frmUnidadMedida : Form
    {
        bool flagValidacion;
        long umd_id = 0;
        public frmUnidadMedida()
        {
            InitializeComponent();
            Cargar();
            lblProducto.Text = (frmProductoLista.pro_nombre1 != "" ? "Producto: " + frmProductoLista.pro_nombre1 : "");
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

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código de la Unidad de Medida");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre de la Unidad de Medida");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Código de la Unidad de Medida");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre de la Unidad de Medida");
        }

        public void Buscar()
        {
            umd_id = frmUnidadMedidaLista.umd_id1;

            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            lstUnidadMedida = UnidadMedidaController.GetListaUnidadMedida(umd_id);
            if (lstUnidadMedida.Count != 0)
            {
                lstUnidadMedida.ForEach(delegate(Unidad_Medida b)
                {
                    txtfields1.Text = b.Umd_codigo;
                    txtfields2.Text = b.Umd_nombre;
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
                MessageBox.Show(this, "Registre el Código de la Unidad de Medida", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre de la Unidad de Medida", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
                        //lstUnidadMedida.Add(new Unidad_Medida(umd_id, frmProductoLista.pro_id1, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        lstUnidadMedida.Add(new Unidad_Medida(umd_id, txtfields1.Text.Trim(), txtfields2.Text.Trim(), 1));
                        Unidad_Medida unidadMedida = new Unidad_Medida();
                        accion = unidadMedida.update(lstUnidadMedida);
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
                        List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
                        //lstUnidadMedida.Add(new Unidad_Medida(0, frmProductoLista.pro_id1, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        lstUnidadMedida.Add(new Unidad_Medida(0, txtfields1.Text.Trim(), txtfields2.Text.Trim(), 1));
                        Unidad_Medida unidadMedida = new Unidad_Medida();
                        accion = unidadMedida.insert(lstUnidadMedida);
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
            e.KeyChar = char.ToUpper(e.KeyChar);
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
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
