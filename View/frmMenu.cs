using System;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;
using ypfbApplication.View;
using System.Collections.Generic;

namespace View
{
    public partial class frmMenu : Form
    {
        bool flagValidacion;
        int men_id = 0;
        public frmMenu()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMenu_Load(object sender, EventArgs e)
        {
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
        #endregion
        #region Metodos Controller
        public void Buscar()
        {
            men_id = frmMenuLista.men_id1;
            List<Menus> lstMenu = new List<Menus>();
            lstMenu = MenuController.GetListaMenu(men_id);
            if (lstMenu.Count != 0)
            {
                foreach (Menus item in lstMenu)
                {
                    txtfields1.Text = item.Men_titulo;
                }
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
            }
        }
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Título del Menú");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Título del Menú");

        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Menus> lstMenus = new List<Menus>();
                        lstMenus = MenuController.GetListaMenu(frmMenuLista.men_id1);
                        lstMenus[0].Men_titulo = txtfields1.Text.Trim();
                        //lstBloque.Add
                        MenuObject menu = new MenuObject();
                        accion = menu.update(lstMenus);
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
            }
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text.Trim()))
            {
                MessageBox.Show(this, "Registre el Título del Menú", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            return true;
        }
        #endregion
    }
}