using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaFilaLista : Form
    {        
        public static long taf_id1 = 0;
        public long tab_id = 0;
        List<Tabla_Fila> listaTablaFila;
        public frmTablaFilaLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmTablaFilaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar(listaTablaFila);
            //if (frmTablaBusqueda.flagBusqueda == 0)
            //{
            //    Cargar(listaTabla);
            //    frmTablaBusqueda.flagBusqueda = 0;
            //    frmTablaBusqueda.listaTablas = null;
            //}
            //else
            //{
            //    Cargar(frmTablaBusqueda.listaTablas);
            //    frmTablaBusqueda.flagBusqueda = 0;
            //    frmTablaBusqueda.listaTablas = null;
            //}
        }
        private void frmTablaFilaLista_Load(object sender, EventArgs e)
        {
            Cargar(listaTablaFila);
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
                    taf_id1 = Convert.ToInt64(celda.Value);

                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                    //Ver Columnas
                    toolBar1.Buttons[7].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Ver Columnas
                    toolBar1.Buttons[7].Enabled = false;
                    taf_id1 = 0;
                }
            }
            catch { }


            celda = dataGridView1.Rows[row].Cells[1];
            try
            {
              if (!string.IsNullOrEmpty(celda.Value.ToString()))
              {
                tab_id = Convert.ToInt64(celda.Value);
                Session objSession = new Session();
                objSession.ID = tab_id;
              }
              else
              {
                taf_id1 = 0;
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
                case "cmdNew":
                    frmTablaFila frmTablaNew = new frmTablaFila();
                    frmTablaNew.FormClosed += new FormClosedEventHandler(frmTablaFilaLista_FormClosed);
                    listaTablaFila = null;
                    //frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmTablaFila frmTablaEdit = new frmTablaFila();
                    frmTablaEdit.Buscar();
                    listaTablaFila = null;
                    //frmTablaBusqueda.flagBusqueda = 0;
                    frmTablaEdit.FormClosed += new FormClosedEventHandler(frmTablaFilaLista_FormClosed);
                    frmTablaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaTablaFila = null;
                    //frmTablaBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + taf_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();
                            List<Tabla_Fila> lstTabla2 = new List<Tabla_Fila>();
                            TablaFilaObject objTablaObject = new TablaFilaObject();
                            Tabla_Fila objTablaObject2 = new Tabla_Fila(); 
                            lstTabla = objTablaObject.listTablaFila(taf_id1);
                            if (lstTabla.Count != 0)
                            {
                                lstTabla.ForEach(delegate(Tabla_Fila t)
                                {
                                    lstTabla2.Add(new Tabla_Fila(t.Taf_id, frmTablaLista.tab_id1, t.Taf_valfila, t.Taf_valor, 0));
                                });
                            }
                            if (objTablaObject2.update(lstTabla2) != 0)
                            {
                                MessageBox.Show("Se eliminó el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(this.listaTablaFila);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmTablaFilaLista_Load(sender, e);
                    break;

                case "cmdFind":
                    //frmTablaBusqueda frmTablaBusquedaFind = new frmTablaBusqueda();
                    //frmTablaBusquedaFind.FormClosed += new FormClosedEventHandler(frmTablaFilaLista_FormClosed);
                    //frmTablaBusqueda.listaTablas = null;
                    //frmTablaBusqueda.flagBusqueda = 0;
                    //frmTablaBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdColumnas":
                    frmTablaColumnaLista frmTablaColumnaListaLista = new frmTablaColumnaLista();
                    frmTablaColumnaListaLista.FormClosed += new FormClosedEventHandler(frmTablaFilaLista_FormClosed);
                    frmTablaColumnaListaLista.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Metodos Controller
        protected void Cargar(List<Tabla_Fila> listaTablaFilas)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaTablaFilas == null)
            {
                listaTablaFilas = new List<Tabla_Fila>();
                listaTablaFilas = TablaFilaController.GetListaTablaFilaPorTabla(frmTablaLista.tab_id1);
            }
            DataTable table = null;

            if (listaTablaFilas.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTablaFilas);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[7].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}