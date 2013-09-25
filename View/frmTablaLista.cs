using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaLista : Form
    {
        public static long tab_id1 = 0;
        List<Tabla> listaTabla;
        
        public frmTablaLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmTablaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar(listaTabla);
        }
        private void frmTablaLista_Load(object sender, EventArgs e)
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
                    
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                    //Ver Filas
                    toolBar1.Buttons[7].Enabled = true;
                    //Ver Filas
                    toolBar1.Buttons[8].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Ver Filas
                    toolBar1.Buttons[7].Enabled = false;
                    //Ver Filas
                    toolBar1.Buttons[8].Enabled = false;
                    tab_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTabla frmTablaEdit = new frmTabla();
            frmTablaEdit.Buscar();
            listaTabla = null;
            frmTablaBusqueda.flagBusqueda = 0;
            frmTablaEdit.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
            frmTablaEdit.ShowDialog();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmTabla frmTablaNew = new frmTabla();
                    frmTablaNew.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
                    listaTabla = null;
                    frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmTabla frmTablaEdit = new frmTabla();
                    frmTablaEdit.Buscar();
                    listaTabla = null;
                    frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaEdit.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
                    frmTablaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaTabla = null;
                    frmTablaBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + tab_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Tabla> lstTabla = new List<Tabla>();
                            List<Tabla> lstTabla2 = new List<Tabla>();
                            TablaObject objTablaObject = new TablaObject();
                            lstTabla = objTablaObject.listTabla(tab_id1);
                            if (lstTabla.Count != 0)
                            {
                                lstTabla.ForEach(delegate(Tabla t)
                                {
                                    lstTabla2.Add(new Tabla(t.Tab_id, t.Tab_codigo, t.Tab_nombre, 0));
                                });
                            }
                            if (objTablaObject.update(lstTabla2) != 0)
                            {
                                MessageBox.Show("Se eliminó el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(this.listaTabla);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmTablaLista_Load(sender, e);
                    break;

                case "cmdFind":
                    frmTablaBusqueda frmTablaBusquedaFind = new frmTablaBusqueda();
                    frmTablaBusquedaFind.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
                    frmTablaBusqueda.listaTablas = null;
                    frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdFilas":
                    frmTablaFilaLista frmTablaFilasListaLista = new frmTablaFilaLista();
                    frmTablaFilasListaLista.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
                    frmTablaFilasListaLista.ShowDialog();
                    break;

                case "cmdValores":
                    frmTablaFilaColumna frmTablaFilaColumnaLista = new frmTablaFilaColumna();
                    frmTablaFilaColumnaLista.FormClosed += new FormClosedEventHandler(frmTablaLista_FormClosed);
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
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[7].Enabled = false;
            toolBar1.Buttons[8].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}