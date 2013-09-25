using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmContrato_SinonimoLista : Form
    {
        public static long cts_id1;
        bool estadoDataGridView = true;
        public frmContrato_SinonimoLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

       
        private void frmContrato_SinonimoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmContrato_SinonimoLista_FormClosed(object sender, FormClosedEventArgs e)
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
            // Find Name of Contrato_Sinonimo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    cts_id1 = Convert.ToInt64(celda.Value);
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
                    cts_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmContrato_Sinonimo frmContrato_SinonimoEdit = new frmContrato_Sinonimo();
            frmContrato_SinonimoEdit.Buscar();
            frmContrato_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmContrato_SinonimoLista_FormClosed);
            frmContrato_SinonimoEdit.ShowDialog();
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (estadoDataGridView)
            {
                estadoDataGridView = false;
                this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            }
        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmContrato_Sinonimo frmContrato_SinonimoNew = new frmContrato_Sinonimo();
                    frmContrato_SinonimoNew.FormClosed += new FormClosedEventHandler(frmContrato_SinonimoLista_FormClosed);
                    frmContrato_SinonimoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmContrato_Sinonimo frmContrato_SinonimoEdit = new frmContrato_Sinonimo();
                    frmContrato_SinonimoEdit.Buscar();
                    frmContrato_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmContrato_SinonimoLista_FormClosed);
                    frmContrato_SinonimoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + cts_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
                            List<Contrato_Sinonimo> lstContrato_Sinonimo2 = new List<Contrato_Sinonimo>();
                            Contrato_SinonimoObject objContrato_SinonimoObject = new Contrato_SinonimoObject();
                            lstContrato_Sinonimo = objContrato_SinonimoObject.listContrato_Sinonimo(cts_id1);
                            if (lstContrato_Sinonimo.Count != 0)
                            {
                                lstContrato_Sinonimo.ForEach(delegate(Contrato_Sinonimo r)
                                {
                                    lstContrato_Sinonimo2.Add(new Contrato_Sinonimo(r.Cts_id, r.Ctt_id, r.Cts_nombre, 0));
                                });
                            }
                            if (objContrato_SinonimoObject.update(lstContrato_Sinonimo2) != 0)
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
                    frmContrato_SinonimoLista_Load(sender, e);
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
        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Contrato_Sinonimo> listaContrato_Sinonimos = Contrato_SinonimoController.GetListaContrato_SinonimoPorContrato(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaContrato_Sinonimos.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaContrato_Sinonimos);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            dataGridView1.DataSource = table;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}