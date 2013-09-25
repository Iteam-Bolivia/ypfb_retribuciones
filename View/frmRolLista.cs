using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmRolLista : Form
    {
        public static int rol_id1;
                
        public frmRolLista()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmRolLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmRolLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmRol frmRolNew = new frmRol();
                    frmRolNew.FormClosed += new FormClosedEventHandler(frmRolLista_FormClosed);
                    frmRolNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmRol frmRolEdit = new frmRol();
                    frmRolEdit.FormClosed += new FormClosedEventHandler(frmRolLista_FormClosed);
                    frmRolEdit.Buscar();
                    frmRolEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + rol_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Rol> lstRol = new List<Rol>();
                            List<Rol> lstRol2 = new List<Rol>();
                            RolObject objRolObject = new RolObject();
                            lstRol = objRolObject.listRol(rol_id1);
                            if (lstRol.Count != 0)
                            {
                                lstRol.ForEach(delegate(Rol r)
                                {
                                    lstRol2.Add(new Rol(r.Rol_id, r.Rol_cod, r.Rol_titulo, r.Rol_descripcion, 0));
                                });
                            }
                            if (objRolObject.update(lstRol2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar();
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmRolLista_Load(sender, e);
                    break;
                case "cmdFind":
                    //frmRolBusqueda childForm = new frmRolBusqueda();
                    //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    //childForm.Show();
                    //buscar();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrWhiteSpace(celda.Value.ToString()))
                {
                    rol_id1 = Convert.ToInt32(celda.Value);
                    //Validar si el usuario pretende eliminar los siguientes roles
                    if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "1")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    else if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "2")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    else if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "3")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    else if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "4")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    else if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "5")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    else if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "6")
                    {
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        return;
                    }
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    rol_id1 = 0;
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmRol frmRolEdit = new frmRol();
            frmRolEdit.FormClosed += new FormClosedEventHandler(frmRolLista_FormClosed);
            frmRolEdit.Buscar();
            frmRolEdit.ShowDialog();
        }
        #endregion
        #region Metodos Controller
        private void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Rol> lstRol = new List<Rol>();
            lstRol = RolController.GetListRoles(0);
            DataTable table = null;
            if (lstRol.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(lstRol);
            }
            dataGridView1.DataSource = table;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            //Adicionar
            toolBar1.Buttons[0].Enabled = true;
            //Eliminar
            toolBar1.Buttons[1].Enabled = false;
            //Editar
            toolBar1.Buttons[2].Enabled = false;
        }
        #endregion
        
    }
}