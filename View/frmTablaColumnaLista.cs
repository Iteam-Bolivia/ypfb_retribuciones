using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaColumnaLista : Form
    {
        public static long tac_id1 = 0;
        public frmTablaColumnaLista()
        {
            InitializeComponent();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmTablaColumna frmTablaColumnaNew = new frmTablaColumna();
                    frmTablaColumnaNew.FormClosed += new FormClosedEventHandler(frmTablaColumnaLista_FormClosed);
                    frmTablaColumnaNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmTablaColumna frmTablaColumnaEdit = new frmTablaColumna();
                    frmTablaColumnaEdit.Buscar();
                    frmTablaColumnaEdit.FormClosed += new FormClosedEventHandler(frmTablaColumnaLista_FormClosed);
                    frmTablaColumnaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + tac_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Tabla_Columna> lstTablaColumna = new List<Tabla_Columna>();
                            List<Tabla_Columna> lstTablaColumna2 = new List<Tabla_Columna>();
                            TablaColumnaObject objTablaColumna = new TablaColumnaObject();
                            Tabla_Columna objTablaColumna2 = new Tabla_Columna();
                            lstTablaColumna = objTablaColumna.listTablaColumna(tac_id1);
                            if (lstTablaColumna.Count != 0)
                            {
                                foreach (Tabla_Columna item in lstTablaColumna)
                                {
                                    Tabla_Columna tablaValores = new Tabla_Columna();
                                    tablaValores.Tac_id = item.Tac_id;
                                    tablaValores.Taf_id = item.Taf_id;
                                    tablaValores.Tac_valcolumna = item.Tac_valcolumna;
                                    tablaValores.Tac_valor = item.Tac_valor;
                                    tablaValores.Tac_estado = 0;
                                    lstTablaColumna2.Add(tablaValores);
                                }
                                if (objTablaColumna2.update(lstTablaColumna2) != 0)
                                {
                                    MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.Cargar();
                                }
                                else
                                    MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case DialogResult.No:
                            // "No" processing
                            break;
                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                    break;
                case "cmdRefresh":
                    Cargar();
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
        private void frmTablaColumnaLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmTablaColumnaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of Tabla Valores
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    tac_id1 = Convert.ToInt64(dataGridView1.Rows[row].Cells[0].Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
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
        }
        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Tabla_Columna> listaTablaColumnaTabla = TablaColumnaController.GetListaTablaColumnaPorTablaFila(frmTablaFilaLista.taf_id1);
            DataTable table = null;
            if (listaTablaColumnaTabla.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTablaColumnaTabla);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}