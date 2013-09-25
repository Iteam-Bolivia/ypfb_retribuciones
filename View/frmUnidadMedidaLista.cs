using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmUnidadMedidaLista : Form
    {
        public static long umd_id1 = 0;
        
        public frmUnidadMedidaLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmUnidadMedidaLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void frmUnidadMedidaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
            umd_id1 = 0;
        }        
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmUnidadMedida frmUnidadMedidaNew = new frmUnidadMedida();
                    frmUnidadMedidaNew.FormClosed += new FormClosedEventHandler(frmUnidadMedidaLista_FormClosed);
                    frmUnidadMedidaNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmUnidadMedida frmUnidadMedidaEdit = new frmUnidadMedida();
                    frmUnidadMedidaEdit.Buscar();
                    frmUnidadMedidaEdit.FormClosed += new FormClosedEventHandler(frmUnidadMedidaLista_FormClosed);
                    frmUnidadMedidaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show(this, "Eliminar registro " + umd_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
                            List<Unidad_Medida> lstUnidadMedida2 = new List<Unidad_Medida>();
                            Unidad_Medida objUnidadMedida = new Unidad_Medida();
                            lstUnidadMedida = UnidadMedidaController.GetListaUnidadMedida(umd_id1);
                            if (lstUnidadMedida.Count != 0)
                            {
                                lstUnidadMedida.ForEach(delegate(Unidad_Medida um)
                                {
                                    lstUnidadMedida2.Add(new Unidad_Medida(um.Umd_id, um.Umd_codigo, um.Umd_nombre, 0));
                                });
                            }
                            if (objUnidadMedida.update(lstUnidadMedida2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar();
                            }
                            else
                            {
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar();
                            }
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmUnidadMedidaLista_Load(sender, e);
                    break;
                case "cmdFind":
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    umd_id1 = 0;
                    this.Close();
                    break;
                case "cmdConversiones":
                    frmConversionesLista frmConversionLista = new frmConversionesLista();
                    frmConversionLista.FormClosed += new FormClosedEventHandler(frmUnidadMedidaLista_FormClosed);
                    frmConversionLista.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of Unidad Medida
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    umd_id1 = Convert.ToInt64(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                    //Unidad Medida
                    toolBar1.Buttons[7].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Unidad Medida
                    toolBar1.Buttons[7].Enabled = false;
                    umd_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmUnidadMedida frmUnidadMedidaEdit = new frmUnidadMedida();
            frmUnidadMedidaEdit.Buscar();
            frmUnidadMedidaEdit.FormClosed += new FormClosedEventHandler(frmUnidadMedidaLista_FormClosed);
            frmUnidadMedidaEdit.ShowDialog();
        }
        #endregion
        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Unidad_Medida> listaUnidadMedidas = UnidadMedidaController.GetListaUnidadMedida(0);
            DataTable table = null;

            if (listaUnidadMedidas.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaUnidadMedidas);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[7].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}