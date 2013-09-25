using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmConversionesLista : Form
    {
        public static long con_id1 = 0;
        public frmConversionesLista()
        {
            InitializeComponent();
        }
        private void frmConversionesLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmConversionesLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
            
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmConversiones frmConversionesNew = new frmConversiones();
                    frmConversionesNew.FormClosed += new FormClosedEventHandler(frmConversionesLista_FormClosed);
                    frmConversionesNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmConversiones frmConversionesEdit = new frmConversiones();
                    frmConversionesEdit.Buscar();
                    frmConversionesEdit.FormClosed += new FormClosedEventHandler(frmConversionesLista_FormClosed);
                    frmConversionesEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + con_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Conversiones> lstConversiones = new List<Conversiones>();
                            List<Conversiones> lstConversiones2 = new List<Conversiones>();
                            Conversiones objConversiones = new Conversiones();
                            lstConversiones = ConversionesController.GetListaConversiones(con_id1);
                            if (lstConversiones.Count != 0)
                            {
                                lstConversiones.ForEach(delegate(Conversiones c)
                                {
                                    lstConversiones2.Add(new Conversiones(c.Con_id, c.Umd_id, c.Umdc_id, c.Con_valor, 0, c.Var_id));
                                });
                            }
                            if (objConversiones.update(lstConversiones2) != 0)
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Cargar();
                            break;
                        case DialogResult.No:
                            break;
                    }

                    break;
                case "cmdRefresh":
                    frmConversionesLista_Load(sender, e);
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
            // Find Name of Conversiones
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];

            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    con_id1 = Convert.ToInt64(celda.Value);
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
                    con_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmConversiones frmConversionesEdit = new frmConversiones();
            frmConversionesEdit.Buscar();
            frmConversionesEdit.FormClosed += new FormClosedEventHandler(frmConversionesLista_FormClosed);
            frmConversionesEdit.ShowDialog();
        }
        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Conversiones> listaConversiones = ConversionesController.GetListaConversionesPorUnidadMedida(frmUnidadMedidaLista.umd_id1);
            DataTable table = null;
            if (listaConversiones.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaConversiones);
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