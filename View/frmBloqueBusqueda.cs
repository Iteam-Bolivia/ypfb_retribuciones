using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmBloqueBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Bloque> listaBloques;

        public frmBloqueBusqueda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            else
                Buscar(out listaBloques);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaBloques = null;
            flagBusqueda = 0;
            this.Close();
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
            //else if (Convert.ToInt32(e.KeyChar) == 32 || Convert.ToInt32(e.KeyChar) == 45)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }

        #region Metodos Controller
        public bool Buscar(out List<Bloque> listaBloques)
        {
            listaBloques = BloqueController.GetListBloquesSegunCriterio(txtCodigo.Text.ToUpper(), txtNombre.Text.ToUpper());
            if (listaBloques.Count == 0)
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