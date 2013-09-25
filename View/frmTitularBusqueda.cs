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
    public partial class frmTitularBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Titular> listaTitulares;

        public frmTitularBusqueda()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Buscar(out listaTitulares);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaTitulares = null;
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
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
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
        }
        #region Metodos Controller
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
        public bool Buscar(out List<Titular> listaTitulares)
        {
            listaTitulares = TitularController.GetListTitularesSegunCriterio(txtfields1.Text.ToUpper(), txtfields2.Text.ToUpper());
            if (listaTitulares.Count == 0)
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
            if (string.IsNullOrWhiteSpace(txtfields1.Text) && string.IsNullOrWhiteSpace(txtfields2.Text))
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