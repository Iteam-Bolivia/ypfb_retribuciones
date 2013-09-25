using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampo_SinonimoLista : Form
    {
        public static long cas_id1;
        bool estadoDataGridView = true;
        public frmCampo_SinonimoLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

       
        private void frmCampo_SinonimoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmCampo_SinonimoLista_FormClosed(object sender, FormClosedEventArgs e)
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
            // Find Name of Campo_Sinonimo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    cas_id1 = Convert.ToInt64(celda.Value);
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
                    cas_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmCampo_Sinonimo frmCampo_SinonimoEdit = new frmCampo_Sinonimo();
            frmCampo_SinonimoEdit.Buscar();
            frmCampo_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmCampo_SinonimoLista_FormClosed);
            frmCampo_SinonimoEdit.ShowDialog();
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
                    frmCampo_Sinonimo frmCampo_SinonimoNew = new frmCampo_Sinonimo();
                    frmCampo_SinonimoNew.FormClosed += new FormClosedEventHandler(frmCampo_SinonimoLista_FormClosed);
                    frmCampo_SinonimoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmCampo_Sinonimo frmCampo_SinonimoEdit = new frmCampo_Sinonimo();
                    frmCampo_SinonimoEdit.Buscar();
                    frmCampo_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmCampo_SinonimoLista_FormClosed);
                    frmCampo_SinonimoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + cas_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Campo_Sinonimo> lstCampo_Sinonimo = new List<Campo_Sinonimo>();
                            List<Campo_Sinonimo> lstCampo_Sinonimo2 = new List<Campo_Sinonimo>();
                            Campo_SinonimoObject objCampo_SinonimoObject = new Campo_SinonimoObject();
                            lstCampo_Sinonimo = objCampo_SinonimoObject.listCampo_Sinonimo(cas_id1);
                            if (lstCampo_Sinonimo.Count != 0)
                            {
                                lstCampo_Sinonimo.ForEach(delegate(Campo_Sinonimo r)
                                {
                                    lstCampo_Sinonimo2.Add(new Campo_Sinonimo(r.Cas_id, r.Cam_id, r.Cas_nombre, 0));
                                });
                            }
                            if (objCampo_SinonimoObject.update(lstCampo_Sinonimo2) != 0)
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
                    frmCampo_SinonimoLista_Load(sender, e);
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
            List<Campo_Sinonimo> listaCampo_Sinonimos = Campo_SinonimoController.GetListCampo_SinonimoPorCampo(frmCampoLista.cam_id1);
            DataTable table = null;
            if (listaCampo_Sinonimos.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaCampo_Sinonimos);
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