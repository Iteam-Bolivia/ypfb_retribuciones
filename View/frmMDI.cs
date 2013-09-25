using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Model;
using View;
//using ypfbApplication.ReportForms;
namespace ypfbApplication.View
{
    public partial class frmMDI : Form
    {
        private Assembly ensambladoActual;
        public static Bd BaseDatos;

        public frmMDI()
        {
            InitializeComponent();
        }
        private void frmMDI_Load(object sender, EventArgs e)
        {
            ensambladoActual = Assembly.GetExecutingAssembly();
            CreateMenu();
            doLoad();
        }


        private void frmMDI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closeSystem();
        }


        DataSet dsMenu = new DataSet();
        private void CreateMenu()
        {
            MenuObject objMenu = new MenuObject();
            List<Menus> lstMenu = new List<Menus>();
            Session objSession = new Session();
            lstMenu = objMenu.listParentMenu(0, objSession.ROL_ID);
            if (lstMenu.Count != 0)
            {
                lstMenu.ForEach(delegate(Menus m)
                {
                    CreateMenuItem(m.Men_titulo, m.Men_id);
                });
            }
        }
        private void CreateMenuItem(string strMenu, long men_id)
        {
            MenuItem mmru = new MenuItem(strMenu);
            mnuMainMenu.MenuItems.Add(mmru);
            Session objSession = new Session();
            MenuObject objMenu = new MenuObject();
            List<Menus> lstMenu = new List<Menus>();
            lstMenu = objMenu.listParentMenu(men_id, objSession.ROL_ID);
            if (lstMenu.Count != 0)
            {
                lstMenu.ForEach(delegate(Menus m)
                {
                    CreateMenuItems(mmru, m.Men_enlace, m.Men_titulo);
                });
            }
        }
        private string CreateMenuItems(MenuItem mnuItem, string strTag, string strMenu)
        {
            MenuItem mmru = new MenuItem(strMenu, new EventHandler(Menu_Click));
            mmru.Tag = strTag;
            mnuItem.MenuItems.Add(mmru);
            return strMenu;
        }
        private bool GetMenuEnable(string strMenuID)
        {
            if (dsMenu.Tables[0].Select("MenuID='" + strMenuID + "'")[0][3].ToString() == "Y")
                return true;
            else
                return false;
        }
        private void Menu_Click(object sender, System.EventArgs e)
        {
            pictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            if (sender.GetType() == typeof(MenuItem))
            {
                string nombreFormulario = ((MenuItem)sender).Tag.ToString();
                Object form;
                string nombreEnsamblado = nombreFormulario;
                if (nombreEnsamblado == "salir")
                    closeSystem();
                else if (nombreEnsamblado == "creditos")
                {
                    frmCredits objFrmCredits = new frmCredits();
                    objFrmCredits.ShowDialog();
                }
                else
                {
                    Type tipo = ensambladoActual.GetType(nombreEnsamblado);
                    if (tipo != null)
                    {
                        if (!FormularioIsOpen(nombreFormulario))
                        {
                            form = ensambladoActual.CreateInstance(tipo.FullName); //Activator.CreateInstance(tipo);
                            object from1 = ensambladoActual.CreateInstance(tipo.FullName);
                            Form formulario = (Form)form;
                            
                            formulario.WindowState = FormWindowState.Maximized;
                            formulario.MdiParent = this;
                            try
                            {
                                formulario.Show();
                            }
                            catch (Exception ex)
                            {
                                formulario.Close();
                                MessageBox.Show("Error: " + ex.Message, "Error en la apertura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
        public void doLoad()
        {
            string login = "";
            MenuStrip menuStrip2 = new System.Windows.Forms.MenuStrip();
            ToolStripMenuItem materialesEInsumosToolStripMenuItem2_2 = new ToolStripMenuItem();
            ToolStripSeparator toolStripSeparator5_2 = new ToolStripSeparator();
            Session objSession = new Session();
            login = objSession.USU_LOGIN;
            this.Text = this.Text + " - " + objSession.SISTEMA;
            label1.Text = label1.Text + " - " + objSession.SISTEMA;
            toolStripStatusLabel4.Text = "Oficina: " + objSession.SUC_NOMBRE;
            toolStripStatusLabel2.Text = "Rol: " + objSession.ROL_TITULO;
            toolStripStatusLabel5.Text = "Usuario: " + objSession.USU_LOGIN;
            toolStripStatusLabel6.Text = "ID: " + objSession.IP;
            toolStripStatusLabel3.Text = "Estado: " + objSession.USU_ESTADO;
        }

        private void closeSystem()
        {
            switch (MessageBox.Show("Cerrar Sistema de Procesos de Cálculo?",
                    "Validación del Sistema",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }


        private bool FormularioIsOpen(string nombreForm)
        {
            if (this.MdiChildren.Length > 0)
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (nombreForm == (MdiChildren[i].Name))
                    {
                        MdiChildren[i].Activate();
                        MdiChildren[i].WindowState = FormWindowState.Maximized;
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
    }
}