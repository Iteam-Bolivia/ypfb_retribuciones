using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaCalculoLista : Form
    {
        public static long tca_id1 = 0;
        public frmTablaCalculoLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmTablaCalculoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmTablaCalculoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmTablaCalculo frmTablaCalculoNew = new frmTablaCalculo();
                    frmTablaCalculoNew.FormClosed += new FormClosedEventHandler(frmTablaCalculoLista_FormClosed);
                    frmTablaCalculoNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmTablaCalculo frmTablaCalculoEdit = new frmTablaCalculo();
                    frmTablaCalculoEdit.Buscar();
                    frmTablaCalculoEdit.FormClosed += new FormClosedEventHandler(frmTablaCalculoLista_FormClosed);
                    frmTablaCalculoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + tca_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                            List<Tabla_Calculo> lstTablaCalculo2 = new List<Tabla_Calculo>();
                            TablaCalculoObject objTablaCalculo = new TablaCalculoObject();
                            Tabla_Calculo objTablaCalculo2 = new Tabla_Calculo();
                            lstTablaCalculo = objTablaCalculo.listTablaCalculo(tca_id1);
                            if (lstTablaCalculo.Count != 0)
                            {
                                foreach (Tabla_Calculo item in lstTablaCalculo)
                                {
                                    Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                                    tablaCalculo.Tca_id = item.Tca_id;
                                    tablaCalculo.Ctt_id = item.Ctt_id;
                                    tablaCalculo.Tab_id = item.Tab_id;
                                    tablaCalculo.Tca_estado = 0;
                                    lstTablaCalculo2.Add(tablaCalculo);
                                }
                                if (objTablaCalculo2.update(lstTablaCalculo2) != 0)
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of Tabla Calculo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    tca_id1 = Convert.ToInt64(dataGridView1.Rows[row].Cells[0].Value);
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
        #endregion
        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Tabla_Calculo> listaTablaCalculoTabla = TablaCalculoController.GetListaTablaCalculoPorContrato(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaTablaCalculoTabla.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTablaCalculoTabla);
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