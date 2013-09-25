using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmMonedaLista : Form
    {
        public static long mon_id1 = 0;
        List<Moneda> listaMoneda;
        
        public frmMonedaLista()
        {
            InitializeComponent();
        }


        #region Eventos Pagina
        private void frmMonedaLista_Load(object sender, EventArgs e)
        {
            Cargar(listaMoneda);
        }
        private void frmMonedaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar(listaMoneda);
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmMoneda frmMonedaNew = new frmMoneda();
                    frmMonedaNew.FormClosed += new FormClosedEventHandler(frmMonedaLista_FormClosed);
                    listaMoneda = null;
                    //frmMercadoBusqueda.flagBusqueda = 0;
                    frmMonedaNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmMoneda frmMonedaEdit = new frmMoneda();
                    frmMonedaEdit.Buscar();
                    listaMoneda = null;
                    //frmMercadoBusqueda.flagBusqueda = 0;
                    frmMonedaEdit.FormClosed += new FormClosedEventHandler(frmMonedaLista_FormClosed);
                    frmMonedaEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaMoneda = null;
                    //frmMercadoBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + mon_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Moneda> lstMoneda = new List<Moneda>();
                            List<Moneda> lstMoneda2 = new List<Moneda>();
                            MonedaObject objMonedaObject = new MonedaObject();
                            lstMoneda = objMonedaObject.listMoneda(mon_id1);
                            if (lstMoneda.Count != 0)
                            {
                                lstMoneda.ForEach(delegate(Moneda m)
                                {
                                    lstMoneda2.Add(new Moneda(m.Mon_id, m.Mon_codigo, m.Mon_nombre, 0));
                                });
                            }
                            if (objMonedaObject.update(lstMoneda2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(listaMoneda);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmMonedaLista_Load(sender, e);
                    break;
                case "cmdFind":
                    //frmMercadoBusqueda frmMercadoBusquedaFind = new frmMercadoBusqueda();
                    //frmMercadoBusquedaFind.FormClosed += new FormClosedEventHandler(frmMercadoLista_FormClosed);
                    //frmMercadoBusqueda.listaMercados = null;
                    //frmMercadoBusqueda.flagBusqueda = 0;
                    //frmMercadoBusquedaFind.ShowDialog();
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
            // Find Name of Moneda
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    mon_id1 = Convert.ToInt64(celda.Value);
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
                    mon_id1 = 0;
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
        protected void Cargar(List<Moneda> listaMonedas)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaMonedas == null)
            {
                listaMonedas = new List<Moneda>();
                listaMonedas = MonedaController.GetListMonedas(0);
            }
            DataTable table = null;

            if (listaMonedas.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaMonedas);
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