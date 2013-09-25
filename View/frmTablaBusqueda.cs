using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Tabla> listaTablas;
        public frmTablaBusqueda()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            else
                Buscar(out listaTablas);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaTablas = null;
            flagBusqueda = 0;
            this.Close();
        }
        private void txtfields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsNumber(e.KeyChar) || char.IsLetter(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)// || Convert.ToInt32(e.KeyChar) == 45)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtfields2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsNumber(e.KeyChar) || char.IsLetter(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)// || Convert.ToInt32(e.KeyChar) == 45)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        #region Metodos Controller
        public bool Buscar(out List<Tabla> listaTablas)
        {
            listaTablas = TablaController.GetListaTablaSegunCriterio(txtfields1.Text, txtfields2.Text);
            if (listaTablas.Count == 0)
            {
                flagBusqueda = 0;
                MessageBox.Show(this, "No se encontraron Tablas según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (string.IsNullOrWhiteSpace(txtfields1.Text.Trim()) && string.IsNullOrWhiteSpace(txtfields2.Text.Trim()))
            {
                MessageBox.Show(this, "Introdusca valores para realizar la búsqueda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion
    }
}