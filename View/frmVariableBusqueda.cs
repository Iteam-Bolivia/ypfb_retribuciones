using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;
using ypfbApplication.Controller;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmVariableBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Variable> listaVariables;

        public frmVariableBusqueda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            else
                Buscar(out listaVariables);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaVariables = null;
            flagBusqueda = 0;
            this.Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.KeyChar = Char.ToUpper(e.KeyChar);
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

        #region Metodos Controller
        public bool Buscar(out List<Variable> listaVariables)
        {
            VariableController objVariableController = new VariableController();
            listaVariables = objVariableController.GetListVariablesSegunCriterio(txtCodigo.Text, txtNombre.Text);
            if (listaVariables.Count == 0)
            {
                flagBusqueda = 0;
                MessageBox.Show(this, "No se encontraron Variables según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void frmVariableBusqueda_Load(object sender, EventArgs e)
        {

        }


    }
}