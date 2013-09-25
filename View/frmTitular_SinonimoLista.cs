using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitular_SinonimoLista : Form
    {
        public static long tis_id1;
        bool estadoDataGridView = true;
        public frmTitular_SinonimoLista()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

       
        private void frmTitular_SinonimoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmTitular_SinonimoLista_FormClosed(object sender, FormClosedEventArgs e)
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
            // Find Name of Titular_Sinonimo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    tis_id1 = Convert.ToInt64(celda.Value);
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
                    tis_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmTitular_Sinonimo frmTitular_SinonimoEdit = new frmTitular_Sinonimo();
            frmTitular_SinonimoEdit.Buscar();
            frmTitular_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmTitular_SinonimoLista_FormClosed);
            frmTitular_SinonimoEdit.ShowDialog();
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
                    frmTitular_Sinonimo frmTitular_SinonimoNew = new frmTitular_Sinonimo();
                    frmTitular_SinonimoNew.FormClosed += new FormClosedEventHandler(frmTitular_SinonimoLista_FormClosed);
                    frmTitular_SinonimoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmTitular_Sinonimo frmTitular_SinonimoEdit = new frmTitular_Sinonimo();
                    frmTitular_SinonimoEdit.Buscar();
                    frmTitular_SinonimoEdit.FormClosed += new FormClosedEventHandler(frmTitular_SinonimoLista_FormClosed);
                    frmTitular_SinonimoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + tis_id1 + "?", "Validación GEdS Desktop", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Titular_Sinonimo> lstTitular_Sinonimo = new List<Titular_Sinonimo>();
                            List<Titular_Sinonimo> lstTitular_Sinonimo2 = new List<Titular_Sinonimo>();
                            Titular_SinonimoObject objTitular_SinonimoObject = new Titular_SinonimoObject();
                            lstTitular_Sinonimo = objTitular_SinonimoObject.listTitular_Sinonimo(tis_id1);
                            if (lstTitular_Sinonimo.Count != 0)
                            {
                                lstTitular_Sinonimo.ForEach(delegate(Titular_Sinonimo r)
                                {
                                    lstTitular_Sinonimo2.Add(new Titular_Sinonimo(r.Tis_id, r.Tit_id, r.Tis_nombre, 0));
                                });
                            }
                            if (objTitular_SinonimoObject.update(lstTitular_Sinonimo2) != 0)
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
                    frmTitular_SinonimoLista_Load(sender, e);
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
            List<Titular_Sinonimo> listaTitular_Sinonimos = Titular_SinonimoController.GetListTitular_SinonimoPorTitular(frmTitularLista.tit_id1);
            DataTable table = null;
            if (listaTitular_Sinonimos.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTitular_Sinonimos);
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