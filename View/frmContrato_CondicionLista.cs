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
    public partial class frmContrato_CondicionLista : Form
    {

        public static long ccn_id1;
        bool estadoDataGridView = true;
        public frmContrato_CondicionLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void frmContrato_CondicionLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }

        private void frmContrato_CondicionLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmContrato_Condicion frmContrato_CondicionEdit = new frmContrato_Condicion();
            frmContrato_CondicionEdit.Buscar();
            frmContrato_CondicionEdit.FormClosed += new FormClosedEventHandler(frmContrato_CondicionLista_FormClosed);
            frmContrato_CondicionEdit.ShowDialog();
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

                    ccn_id1 = Convert.ToInt64(celda.Value);
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
                    ccn_id1 = 0;
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
                    frmContrato_Condicion frmContrato_CondicionNew = new frmContrato_Condicion();
                    frmContrato_CondicionNew.FormClosed += new FormClosedEventHandler(frmContrato_CondicionLista_FormClosed);
                    frmContrato_CondicionNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmContrato_Condicion frmContrato_CondicionEdit = new frmContrato_Condicion();
                    frmContrato_CondicionEdit.Buscar();
                    frmContrato_CondicionEdit.FormClosed += new FormClosedEventHandler(frmContrato_CondicionLista_FormClosed);
                    frmContrato_CondicionEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + ccn_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<ContratoCondicion> lstContrato_Condicion = new List<ContratoCondicion>();
                            List<ContratoCondicion> lstContrato_Condicion2 = new List<ContratoCondicion>();
                            ContratoCondicionObject objContrato_CondicionObject = new ContratoCondicionObject();
                            lstContrato_Condicion = objContrato_CondicionObject.listContratoCondicionById(ccn_id1);
                            if (lstContrato_Condicion.Count != 0)
                            {
                                lstContrato_Condicion.ForEach(delegate(ContratoCondicion r)
                                {
                                    lstContrato_Condicion2.Add(new ContratoCondicion(r.Ccn_id, r.Ctt_id, r.Con_id, r.Sim_id, r.Ccn_mesiniexp, r.Ccn_anioiniexp, r.Ccn_mesfin, r.Ccn_aniofin, r.Ccn_diasdifer, r.Ccn_valorb, 0));
                                });
                            }
                            if (objContrato_CondicionObject.update(lstContrato_Condicion2) != 0)
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
                    frmContrato_CondicionLista_Load(sender, e);
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
            ContratoCondicionObject ContratoCondi = new ContratoCondicionObject();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<ContratoCondicion> listaContratoCondiciones = ContratoCondi.listContratoCondicion(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaContratoCondiciones.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaContratoCondiciones);
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
