using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmProductoBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Producto> listaProductos;

        public frmProductoBusqueda()
        {
            InitializeComponent();
            Cargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Buscar(out listaProductos);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaProductos = null;
            flagBusqueda = 0;
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
            //else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
            //    e.Handled = false;
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //    e.Handled = true;
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
        #region Metodos Controller
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblCodigo, "Indicar el Código del Producto");
            toolTip1.SetToolTip(this.lblNombre, "Indicar el Nombre del Producto");

        }

        public bool Buscar(out List<Producto> listaProductos)
        {
            listaProductos = ProductoController.GetListProductosSegunCriterio(txtCodigo.Text.ToUpper(), txtNombre.Text.ToUpper());
            if (listaProductos.Count == 0)
            {
                flagBusqueda = 0;
                MessageBox.Show(this, "No se encontraron Bloques según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                flagBusqueda = 1;
                this.Close();
                return true;
            }
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) && string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(this, "Introdusca valores para realizar la búsqueda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion
    }
}