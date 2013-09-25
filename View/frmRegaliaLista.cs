using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmRegaliaLista : Form
    {
        public static long reg_id1;
        bool estadoDataGridView = true;
        public frmRegaliaLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }
        private void frmRegaliaLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmRegaliaLista_FormClosed(object sender, FormClosedEventArgs e)
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
            // Find Name of Regalia
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    reg_id1 = Convert.ToInt64(celda.Value);
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
                    reg_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmRegalia frmRegaliaEdit = new frmRegalia();
            frmRegaliaEdit.Buscar();
            frmRegaliaEdit.FormClosed += new FormClosedEventHandler(frmRegaliaLista_FormClosed);
            frmRegaliaEdit.ShowDialog();
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
                    frmRegalia frmRegaliaNew = new frmRegalia();
                    frmRegaliaNew.FormClosed += new FormClosedEventHandler(frmRegaliaLista_FormClosed);
                    frmRegaliaNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmRegalia frmRegaliaEdit = new frmRegalia();
                    frmRegaliaEdit.Buscar();
                    frmRegaliaEdit.FormClosed += new FormClosedEventHandler(frmRegaliaLista_FormClosed);
                    frmRegaliaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + reg_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Regalia> lstRegalia = new List<Regalia>();
                            List<Regalia> lstRegalia2 = new List<Regalia>();
                            RegaliaObject objRegaliaObject = new RegaliaObject();
                            lstRegalia = objRegaliaObject.listRegalia(reg_id1);
                            if (lstRegalia.Count != 0)
                            {
                                lstRegalia.ForEach(delegate(Regalia r)
                                {
                                    lstRegalia2.Add(new Regalia(r.Reg_id, r.Ctt_id, r.Ani_id, r.Mes_id, r.Mon_id, r.Reg_tipo, r.Reg_gasmi, r.Reg_gasme, r.Reg_crudomi, r.Reg_crudome, r.Reg_glp, r.Reg_total, 0));
                                });
                            }
                            if (objRegaliaObject.update(lstRegalia2) != 0)
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
                    frmRegaliaLista_Load(sender, e);
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
            List<Regalia> listaRegalias = RegaliaController.GetListaRegaliaPorContrato(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaRegalias.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaRegalias);
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