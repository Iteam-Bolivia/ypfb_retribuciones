using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;
using System.Data;
using System.Drawing;

namespace ypfbApplication.View
{
    public partial class frmRol : Form
    {
        static int contador = 0;

        bool flagValidacion;
        int rol_id = 0;

        public frmRol()
        {
            InitializeComponent();
        }
        private void frmRol_Load(object sender, EventArgs e)
        {
            Cargar();
            if (!flagValidacion)
                CargarGrid();
        }

        private void txtfields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtfields2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtfields3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            contador = 0;
            int res = 0;           
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                res = Convert.ToInt32(item.Cells[2].Value);
                //Verificar si se ha seleccionado alguna fila padre
                if (res != 0 && item.Cells[3].Value.ToString() != "0")
                    contador++;
            }
            if (contador == 0)
            {
                MessageBox.Show("Marque un valor de la lista", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!ValidarCampos())
                return;
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar Código");
            toolTip1.SetToolTip(this.txtfields1, "Indicar Código");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar Título");
            toolTip1.SetToolTip(this.txtfields2, "Indicar Título");
            toolTip1.SetToolTip(this.lbltxtfields3, "Indicar Descripción");
            toolTip1.SetToolTip(this.txtfields3, "Indicar Descripción");
        }

        private void CargarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Width = this.Width - 20;
            //dataGridView1.Height = this.Height - 50;
            List<Menus> listaMenus = new List<Menus>();
            DataTable table = null;

            listaMenus = MenuController.GetListaMenus(0);
            if (listaMenus.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaMenus);
            }
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        protected Menus CreateMenu(int men_id, string men_titulo)
        {

            Menus objMenus = new Menus();
            objMenus.Men_id = men_id;
            objMenus.Men_titulo = men_titulo;
            return objMenus;
        }
        private void CargarGridBusqueda()
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Width = this.Width - 20;
            //dataGridView1.Height = this.Height - 50;
            List<Menus> listaMenus = new List<Menus>();
            DataTable table = null;

            listaMenus = MenuController.GetListaMenus(0, frmRolLista.rol_id1);
            if (listaMenus.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaMenus);
            }
            dataGridView1.DataSource = table;          
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        public void Buscar()
        {
            rol_id = frmRolLista.rol_id1;
            List<Rol> lstRol = new List<Rol>();
            lstRol = RolController.GetListRoles(rol_id);
            if (lstRol.Count != 0)
            {
                lstRol.ForEach(delegate(Rol u)
                {
                    txtfields1.Text = u.Rol_cod;
                    txtfields2.Text = u.Rol_titulo;
                    txtfields3.Text = u.Rol_descripcion;

                    CargarGridBusqueda();

                });
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
            }
        }
        private bool ValidarCampos()
        {
            bool flag = false;
            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre el Codigo del Rol", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (txtfields2.Text == "")
            {
                MessageBox.Show("Registre el Titulo del Rol", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre la Descripción", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag;
            }
            flag = true;
            return flag;
        }
        private void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Rol> lstRol = new List<Rol>();
                        lstRol.Add(new Rol(rol_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), txtfields3.Text.Trim().ToUpper(), 1));
                        Rol rol = new Rol();
                        accion = rol.update(lstRol);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            //Realizar llamada asociacion de roles menu
                            if (GuardarUsuarioRolMenu(1))
                                MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "Hubo error en  la actualzación", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        List<Rol> lstRol = new List<Rol>();
                        lstRol.Add(new Rol(rol_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), txtfields3.Text.Trim().ToUpper(), 1));
                        Rol rol = new Rol();
                        accion = rol.insert(lstRol);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            frmRolLista.rol_id1 = Convert.ToInt32(accion);
                            //Realizar llamada asociacion de roles menu
                            if (GuardarUsuarioRolMenu(0))
                            {
                                MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en  la actualzación", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        protected bool GuardarUsuarioRolMenu(int accion)
        {
            int cantidadSeleccionada = 0;
            int cantidadAlmacenada = 0;

            List<Usurolmenu> lista = new List<Usurolmenu>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[2].Value == true)
                {
                    Usurolmenu usuarioRolMenu = new Usurolmenu();
                    usuarioRolMenu.Urm_id = 0;
                    usuarioRolMenu.Rol_id = frmRolLista.rol_id1;
                    usuarioRolMenu.Men_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    usuarioRolMenu.Urm_privilegios = "1111";
                    usuarioRolMenu.Urm_estado = 1;
                    lista.Add(usuarioRolMenu);
                }
            }
            cantidadSeleccionada = lista.Count;

            UsurolMenuObject objUsuarioRolMenu = new UsurolMenuObject();
            long res = 0;
            MenuObject objMenu = new MenuObject();
            if (accion == 0)//Guardar
                res = 1;
            else//Actualizar
                //Realizar el Borrado de los menu asociados al rol
                res = objUsuarioRolMenu.delete("rol_id = " + frmRolLista.rol_id1);
            if (res != 0)
            {
                List<Usurolmenu> listaGeneral = new List<Usurolmenu>();
                foreach (Usurolmenu item in lista)
                {
                    Menus menuPadre = new Menus();
                    Menus dataMenu = objMenu.DatosMenu(item.Men_id);
                    if (dataMenu != null)
                    {
                        if (dataMenu.Men_par != 0)//es submenu
                            menuPadre = objMenu.DatosMenu(dataMenu.Men_par);
                        Usurolmenu urm = new Usurolmenu();
                        urm.Men_id = menuPadre.Men_id;
                        urm.Rol_id = frmRolLista.rol_id1;
                        urm.Urm_id = 0;
                        urm.Urm_privilegios = "1111";
                        urm.Urm_estado = 1;
                        bool existePadre = listaGeneral.Exists(delegate(Usurolmenu u) { return u.Men_id == urm.Men_id; });
                        if (!existePadre)
                            listaGeneral.Add(urm);
                        listaGeneral.Add(item);
                    }
                }
                cantidadSeleccionada = listaGeneral.Count;
                foreach (Usurolmenu item in listaGeneral)
                {
                    List<Usurolmenu> listaUsuariosInsert = new List<Usurolmenu>();
                    Usurolmenu urm = new Usurolmenu();
                    listaUsuariosInsert.Add(item);
                    res = urm.insert(listaUsuariosInsert);
                    if (res != 1)
                        cantidadAlmacenada++;
                }
                if (cantidadAlmacenada == cantidadSeleccionada)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                if (fila.Cells[3].Value.ToString() == "0")
                {
                    //fila.DefaultCellStyle.BackColor = Color.Blue;
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(235, 234, 219); //ColorTranslator.FromHtml("#DBEAEB");
                    //fila.DefaultCellStyle.ForeColor = Color.White;
                    fila.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    fila.ReadOnly = true;
                    fila.Cells[0].ToolTipText = "Menú Principal o Padre (Solo de Lectura)";
                    fila.Cells[1].ToolTipText = "Menú Principal o Padre (Solo de Lectura)";
                }
                //else
                //    fila.ReadOnly = false;
            }
            catch { }
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}