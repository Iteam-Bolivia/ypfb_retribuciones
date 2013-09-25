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
    public partial class frmTablaVisualLista : Form
    {
        public frmTablaVisualLista()
        {
            InitializeComponent();
        }
        public static long tab_id1 = 0;
        List<Tabla> listaTabla;
        #region Eventos Pagina
        private void frmTablaVisualLista_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void frmTablaVisualLista_Load(object sender, EventArgs e)
        {
            Cargar(listaTabla);
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of Tabla
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];

            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    tab_id1 = Convert.ToInt64(celda.Value);
                    Session objSession = new Session();
                    objSession.ID = tab_id1;
                    //Ver Valores
                    toolBar1.Buttons[3].Enabled = true;
                }
                else
                {
                    //Ver Valores
                    toolBar1.Buttons[3].Enabled = false;
                    tab_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdRefresh":
                    frmTablaVisualLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmTablaBusqueda frmTablaBusquedaFind = new frmTablaBusqueda();
                    frmTablaBusquedaFind.FormClosed += new FormClosedEventHandler(frmTablaVisualLista_FormClosed);
                    listaTabla = null;
                    frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaBusquedaFind.ShowDialog();
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdValores":
                    frmTablaFilaColumna frmTablaFilaColumnaLista = new frmTablaFilaColumna();
                    frmTablaFilaColumnaLista.FormClosed += new FormClosedEventHandler(frmTablaVisualLista_FormClosed);
                    frmTablaFilaColumnaLista.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Metodos Controller
        protected void Cargar(List<Tabla> listaTablas)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaTablas == null)
            {
                listaTablas = new List<Tabla>();
                listaTablas = TablaController.GetListaTabla(0);
            }
            DataTable table = null;

            if (listaTablas.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTablas);
            }
            toolBar1.Buttons[3].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}