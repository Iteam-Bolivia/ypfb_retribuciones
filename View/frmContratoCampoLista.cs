using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmContratoCampoLista : Form
    {
        /// <summary>
        /// Variable utilizada para pasar el valor a traves de las listas
        /// </summary>
        public static long ctc_id1 = 0;
        
        public frmContratoCampoLista()
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }
        #region Eventos Pagina
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmContratoCampo frmContratoCampoNew = new frmContratoCampo();
                    frmContratoCampoNew.FormClosed += new FormClosedEventHandler(frmContratoCampoLista_FormClosed);
                    frmContratoCampoNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmContratoCampo frmContratoCampoEdit = new frmContratoCampo();
                    frmContratoCampoEdit.Buscar();
                    frmContratoCampoEdit.FormClosed += new FormClosedEventHandler(frmContratoCampoLista_FormClosed);
                    frmContratoCampoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + ctc_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                            List<Contrato_Campo> lstContratoCampo2 = new List<Contrato_Campo>();
                            ContratoCampoObject objContratoCampo = new ContratoCampoObject();
                            Contrato_Campo objContratoCampo2 = new Contrato_Campo();
                            lstContratoCampo = objContratoCampo.listContratoCampo(ctc_id1);
                            if (lstContratoCampo.Count != 0)
                            {
                                foreach (Contrato_Campo item in lstContratoCampo)
                                {
                                    Contrato_Campo contrato_Campo = new Contrato_Campo();
                                    contrato_Campo.Ctc_id = item.Ctc_id;
                                    contrato_Campo.Ctt_id = item.Ctt_id;
                                    contrato_Campo.Cam_id = item.Cam_id;
                                    contrato_Campo.Ctc_estado = 0;;
                                    lstContratoCampo2.Add(contrato_Campo);
                                }
                                if (objContratoCampo2.update(lstContratoCampo2) != 0)
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
        private void frmContratoCampoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmContratoCampoLista_FormClosed(object sender, FormClosedEventArgs e)
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
            // Find Name of Contrato Campo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    ctc_id1 = Convert.ToInt64(dataGridView1.Rows[row].Cells[0].Value);
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
            List<Contrato_Campo> listaContratoCampoPorContrato = ContratoCampoController.GetListContratoCamposPorContrato(frmContratoLista.ctt_id1);
            DataTable table = null;
            if (listaContratoCampoPorContrato.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaContratoCampoPorContrato);
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