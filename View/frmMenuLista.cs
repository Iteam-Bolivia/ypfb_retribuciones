using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;
using View;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmMenuLista : Form
    {
        public static int men_id1;
        public frmMenuLista()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMenuLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
        private void frmMenuLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    break;
                case "cmdEdit":
                    frmMenu frmMenuEdit = new frmMenu();
                    frmMenuEdit.FormClosed += new FormClosedEventHandler(frmMenuLista_FormClosed);
                    frmMenuEdit.Buscar();
                    frmMenuEdit.ShowDialog();
                    break;
                case "cmdRefresh":
                    frmMenuLista_Load(sender, e);
                    break;
                case "cmdFind":
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
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    men_id1 = Convert.ToInt32(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    men_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMenu frmMenuEdit = new frmMenu();
            frmMenuEdit.FormClosed += new FormClosedEventHandler(frmMenuLista_FormClosed);
            frmMenuEdit.Buscar();
            frmMenuEdit.ShowDialog();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                if (fila.Cells[7].Value.ToString() == "0")
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(235, 234, 219);
                    fila.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    fila.ReadOnly = true;
                    fila.Cells[0].ToolTipText = "Menú Principal o Padre (Solo de Lectura)";
                    fila.Cells[1].ToolTipText = "Menú Principal o Padre (Solo de Lectura)";
                }
                fila.Cells[0].Style.BackColor = Color.Gray;
            }
            catch { }
        }
        #endregion
        #region Metodos Controller
        private void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Menus> lstMenu = new List<Menus>();
            lstMenu = MenuController.GetListaMenus(0);
            DataTable table = null;
            if (lstMenu.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(lstMenu);
            }
            //Adicionar
            toolBar1.Buttons[0].Enabled = false;
            //Eliminar
            toolBar1.Buttons[1].Enabled = false;
            //Actualizar
            toolBar1.Buttons[2].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}