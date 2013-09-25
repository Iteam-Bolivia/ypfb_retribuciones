using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmMercadoLista : Form
    {
        public static long mer_id1 = 0;
        List<Mercado> listaMercado;
        public frmMercadoLista()
        {
            InitializeComponent();
        }
        private void frmMercadoLista_Load(object sender, EventArgs e)
        {
            Cargar(listaMercado);
        }
        private void frmMercadoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar(listaMercado);
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmMercado frmMercadoNew = new frmMercado();
                    frmMercadoNew.FormClosed += new FormClosedEventHandler(frmMercadoLista_FormClosed);
                    listaMercado = null;
                    frmMercadoBusqueda.flagBusqueda = 0;
                    frmMercadoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmMercado frmMercadoEdit = new frmMercado();
                    frmMercadoEdit.Buscar();
                    listaMercado = null;
                    frmMercadoBusqueda.flagBusqueda = 0;
                    frmMercadoEdit.FormClosed += new FormClosedEventHandler(frmMercadoLista_FormClosed);
                    frmMercadoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaMercado = null;
                    frmMercadoBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + mer_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Mercado> lstMercado = new List<Mercado>();
                            List<Mercado> lstMercado2 = new List<Mercado>();
                            MercadoObject objMercadoObject = new MercadoObject();
                            lstMercado = objMercadoObject.listMercado(mer_id1);
                            if (lstMercado.Count != 0)
                            {
                                lstMercado.ForEach(delegate(Mercado m)
                                {
                                    lstMercado2.Add(new Mercado(m.Mer_id, m.Mer_codigo, m.Mer_nombre, 0, m.Mer_tipo,m.Mer_orden,m.Mer_ordenletra,m.Mer_var,m.Pro_mer));
                                });
                            }
                            if (objMercadoObject.update(lstMercado2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(listaMercado);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }

                    break;
                case "cmdRefresh":
                    frmMercadoLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmMercadoBusqueda frmMercadoBusquedaFind = new frmMercadoBusqueda();
                    frmMercadoBusquedaFind.FormClosed += new FormClosedEventHandler(frmMercadoLista_FormClosed);
                    frmMercadoBusqueda.listaMercados = null;
                    frmMercadoBusqueda.flagBusqueda = 0;
                    frmMercadoBusquedaFind.ShowDialog();
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
            // Find Name of Mercado
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    mer_id1 = Convert.ToInt64(celda.Value);
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
                    mer_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMercado frmMercadoEdit = new frmMercado();
            frmMercadoEdit.Buscar();
            listaMercado = null;
            frmMercadoBusqueda.flagBusqueda = 0;
            frmMercadoEdit.FormClosed += new FormClosedEventHandler(frmMercadoLista_FormClosed);
            frmMercadoEdit.ShowDialog();
        }
        #region Metodos Controller
        protected void Cargar(List<Mercado> listaMercados)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaMercados == null)
            {
                listaMercados = new List<Mercado>();
                listaMercados = MercadoController.GetListMercados(0);
            }
            DataTable table = null;

            if (listaMercados.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaMercados);
                toolBar1.Buttons[1].Enabled = false;
                toolBar1.Buttons[2].Enabled = false;
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