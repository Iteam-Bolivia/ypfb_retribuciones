using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitularContratoLista : Form
    {
        public static long ttc_id1 = 0;
        private long ctt_id = 0;
        bool estadoDataGridView = true;
        private long titd_id = 0;

        public frmTitularContratoLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmTitularLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmTitularLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
                    TitularContratoObject objTitularContratoObject = new TitularContratoObject();
                    frmTitularContrato frmTitularContratoNew = new frmTitularContrato();
                    lstTitularContrato = objTitularContratoObject.listaTitularesContratoPorContrato(ctt_id);
                    if (lstTitularContrato.Count != 0)
                    {
                        foreach (Titular_Contrato item in lstTitularContrato)
                        {
                            Titular_Contrato ttc = new Titular_Contrato();
                            ttc.Ttc_id = item.Ttc_id;
                            ttc.Ctt_id = item.Ctt_id;
                            ttc.Tit_id = item.Tit_id;
                            ttc.Ttc_tipo = (item.Ttc_tipo == "TITULAR" ? "T" : "O");
                            if (ttc.Ttc_tipo == "O")
                                titd_id = ttc.Tit_id;
                            ttc.Ttc_porcentaje = item.Ttc_porcentaje.Replace(",", ".");
                            ttc.Ttc_estado = 0;
                        }
                    }
                    frmTitularContratoNew.titd_id = titd_id;
                    frmTitularContratoNew.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    frmTitularContratoNew.ShowDialog();
                    break;
                case "cmdEdit":
                    lstTitularContrato = new List<Titular_Contrato>();
                    objTitularContratoObject = new TitularContratoObject();
                    frmTitularContrato frmTitularContratoEdit = new frmTitularContrato();
                    frmTitularContratoEdit.Buscar();
                    lstTitularContrato = objTitularContratoObject.listaTitularesContratoPorContrato(ctt_id);
                    if (lstTitularContrato.Count != 0)
                    {
                        foreach (Titular_Contrato item in lstTitularContrato)
                        {
                            Titular_Contrato ttc = new Titular_Contrato();
                            ttc.Ttc_id = item.Ttc_id;
                            ttc.Ctt_id = item.Ctt_id;
                            ttc.Tit_id = item.Tit_id;
                            ttc.Ttc_tipo = (item.Ttc_tipo == "TITULAR" ? "T" : "O");
                            if (ttc.Ttc_tipo == "O")
                                titd_id = ttc.Tit_id;
                            ttc.Ttc_porcentaje = item.Ttc_porcentaje.Replace(",", ".");
                            ttc.Ttc_estado = 0;
                        }
                    }
                    frmTitularContratoEdit.titd_id = titd_id;
                    frmTitularContratoEdit.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    frmTitularContratoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + ttc_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            lstTitularContrato = new List<Titular_Contrato>();
                            List<Titular_Contrato> lstTitularContrato2 = new List<Titular_Contrato>();
                            objTitularContratoObject = new TitularContratoObject();
                            Titular_Contrato obj = new Titular_Contrato();
                            lstTitularContrato = objTitularContratoObject.listTitularContrato(ttc_id1);
                            if (lstTitularContrato.Count != 0)
                            {
                                foreach (Titular_Contrato item in lstTitularContrato)
                                {
                                    Titular_Contrato ttc = new Titular_Contrato();
                                    ttc.Ttc_id = item.Ttc_id;
                                    ttc.Ctt_id = item.Ctt_id;
                                    ttc.Tit_id = item.Tit_id;
                                    ttc.Ttc_tipo = (item.Ttc_tipo == "TITULAR" ? "T" : "O");
                                    if (ttc.Ttc_tipo == "O")
                                        titd_id = ttc.Tit_id;
                                    ttc.Ttc_porcentaje = item.Ttc_porcentaje.Replace(",", ".");
                                    ttc.Ttc_estado = 0;
                                    lstTitularContrato2.Add(ttc);
                                }
                                if (obj.update(lstTitularContrato2) != 0)
                                {
                                    MessageBox.Show("Se elimino registro", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.Cargar();
                                }
                                else
                                    MessageBox.Show(this, "Hubo error en la eliminación", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    //frmUsuarioBusqueda childForm = new frmUsuarioBusqueda();
                    //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    //childForm.Show();
                    //buscar();
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
            // Find Name of Titulares
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];

            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    ttc_id1 = (long)celda.Value;
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
                    ttc_id1 = 0;
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
            frmTitularContrato frmTitularContratoEdit = new frmTitularContrato();
            frmTitularContratoEdit.Buscar();
            frmTitularContratoEdit.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
            frmTitularContratoEdit.ShowDialog();
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
        #endregion
        #region Metodos Controller
        private void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            ctt_id = frmContratoLista.ctt_id1;
            List<Titular_Contrato> listaTitularesPorContrato = TitularContratoController.GetListTitularesContratoPorContrato(ctt_id);

            DataTable table = null;

            if (listaTitularesPorContrato.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTitularesPorContrato);
            }
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            dataGridView1.ClearSelection();
            //Adicionar
            toolBar1.Buttons[0].Enabled = true;
            //Eliminar
            toolBar1.Buttons[1].Enabled = false;
            //Editar
            toolBar1.Buttons[2].Enabled = false;

            //Verficar porcentaje
            decimal porcentaje = 0;
            int accion = 0;
            porcentaje = TitularContratoController.GetVerificaTitularContratoPorcentaje(frmContratoLista.ctt_id1);
            accion = TitularContratoController.GetVerificaTitularContratoOperador(frmContratoLista.ctt_id1, "");
            if (porcentaje < 100)
            {
                MessageBox.Show(this, "Las Empresas asociadas al contrato deben sumar 100", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ControlBox = false;
                toolBar1.Buttons[6].Enabled = false;
                toolBar1.Buttons[0].Enabled = true;
            }
            else if (accion == 0)
            {
                MessageBox.Show(this, "Debe existir un Operador asociado al Contrato", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ControlBox = false;
                toolBar1.Buttons[6].Enabled = false;
                toolBar1.Buttons[0].Enabled = true;
            }
            else
            {
                this.ControlBox = true;
                toolBar1.Buttons[6].Enabled = true;
                toolBar1.Buttons[0].Enabled = false;
            }
        }
        #endregion
    }
}