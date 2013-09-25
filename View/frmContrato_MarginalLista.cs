using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ypfbApplication.View
{
    public partial class frmContrato_MarginalLista : Form
    {
        public static long cma_id1;
        bool estadoDataGridView = true;
        public frmContrato_MarginalLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void frmContrato_MarginalLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }

        private void frmContrato_MarginalLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmContrato_Marginal frmContrato_MarginalEdit = new frmContrato_Marginal();
            frmContrato_MarginalEdit.Buscar();
            frmContrato_MarginalEdit.FormClosed += new FormClosedEventHandler(frmContrato_MarginalLista_FormClosed);
            frmContrato_MarginalEdit.ShowDialog();
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (estadoDataGridView)
            {
                estadoDataGridView = false;
                this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            }
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

                    cma_id1 = Convert.ToInt64(celda.Value);
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
                    cma_id1 = 0;
                }
            }
            catch { }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmContrato_Marginal frmContrato_MarginalNew = new frmContrato_Marginal();
                    frmContrato_MarginalNew.FormClosed += new FormClosedEventHandler(frmContrato_MarginalLista_FormClosed);
                    frmContrato_MarginalNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmContrato_Marginal frmContrato_MarginalEdit = new frmContrato_Marginal();
                    frmContrato_MarginalEdit.Buscar();
                    frmContrato_MarginalEdit.FormClosed += new FormClosedEventHandler(frmContrato_MarginalLista_FormClosed);
                    frmContrato_MarginalEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + cma_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<ContratoMarginal> lstContrato_Marginal = new List<ContratoMarginal>();
                            List<ContratoMarginal> lstContrato_Marginal2 = new List<ContratoMarginal>();
                            ContratoMarginalObject objContrato_MarginalObject = new ContratoMarginalObject();
                            lstContrato_Marginal = objContrato_MarginalObject.listContratoMarginalById(cma_id1);
                            if (lstContrato_Marginal.Count != 0)
                            {
                                lstContrato_Marginal.ForEach(delegate(ContratoMarginal r)
                                {
                                    lstContrato_Marginal2.Add(new ContratoMarginal(r.Cma_id, r.Ctt_id, r.Cma_mes, r.Cma_anio, 0,r.Cma_mes_ini,r.Cma_anio_ini));
                                });
                            }
                            if (objContrato_MarginalObject.update(lstContrato_Marginal2) != 0)
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
                    frmContrato_MarginalLista_Load(sender, e);
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
            ContratoMarginalObject ContratoMargi = new ContratoMarginalObject();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<ContratoMarginal> listaContratoMarginales = ContratoMargi.listContratoMarginal(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaContratoMarginales.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaContratoMarginales);
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
