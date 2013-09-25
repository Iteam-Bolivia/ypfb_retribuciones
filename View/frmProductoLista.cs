using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmProductoLista : Form
    {
        public static long pro_id1 = 0;
        public static string pro_nombre1;
        List<Producto> listaProducto;

        public frmProductoLista()
        {
            InitializeComponent();
        }
        private void frmProductoLista_Load(object sender, EventArgs e)
        {
            Cargar(listaProducto);
        }
        private void frmProductoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmProductoBusqueda.flagBusqueda == 0)
            {
                Cargar(listaProducto);
                frmProductoBusqueda.flagBusqueda = 0;
                frmProductoBusqueda.listaProductos = null;
            }
            else
            {
                Cargar(frmProductoBusqueda.listaProductos);
                frmProductoBusqueda.flagBusqueda = 0;
                frmProductoBusqueda.listaProductos = null;
            }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (ProductoController.GetDatosProducto(pro_id1) != null)
                pro_nombre1 = ProductoController.GetDatosProducto(pro_id1).Pro_nombre;
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmProducto frmProductoNew = new frmProducto();
                    frmProductoNew.FormClosed += new FormClosedEventHandler(frmProductoLista_FormClosed);
                    listaProducto = null;
                    frmProductoBusqueda.flagBusqueda = 0;
                    frmProductoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmProducto frmProductoEdit = new frmProducto();
                    frmProductoEdit.Buscar();
                    listaProducto = null;
                    frmProductoBusqueda.flagBusqueda = 0;
                    frmProductoEdit.FormClosed += new FormClosedEventHandler(frmProductoLista_FormClosed);
                    frmProductoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaProducto = null;
                    frmProductoBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + pro_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Producto> lstProducto = new List<Producto>();
                            List<Producto> lstProducto2 = new List<Producto>();
                            ProductoObject objProductoObject = new ProductoObject();
                            lstProducto = objProductoObject.listProducto(pro_id1);
                            if (lstProducto.Count != 0)
                            {
                                lstProducto.ForEach(delegate(Producto p)
                                {
                                    lstProducto2.Add(new Producto(p.Pro_id, p.Pro_codigo, p.Pro_nombre, 0, p.Umd_id,p.Pro_var,p.Pro_mer));
                                });
                            }
                            if (objProductoObject.update(lstProducto2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(listaProducto);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }

                    break;
                case "cmdRefresh":
                    frmProductoLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmProductoBusqueda frmProductoBusquedaFind = new frmProductoBusqueda();
                    frmProductoBusquedaFind.FormClosed += new FormClosedEventHandler(frmProductoLista_FormClosed);
                    frmProductoBusqueda.listaProductos = null;
                    frmProductoBusqueda.flagBusqueda = 0;
                    frmProductoBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdUnidadMedida":
                    frmUnidadMedidaLista frmUnidadMedidaView = new frmUnidadMedidaLista();
                    frmUnidadMedidaView.FormClosed += new FormClosedEventHandler(frmProductoLista_FormClosed);
                    frmUnidadMedidaView.Text = (pro_nombre1 != "" ? "Unidades de Medida asociados al Producto: " + pro_nombre1 : "Unidad Medida");
                    frmUnidadMedidaView.ShowDialog();
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
            // Find Name of Producto
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    pro_id1 = Convert.ToInt64(celda.Value);
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
                    pro_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProducto frmProductoEdit = new frmProducto();
            frmProductoEdit.Buscar();
            listaProducto = null;
            frmProductoBusqueda.flagBusqueda = 0;
            frmProductoEdit.FormClosed += new FormClosedEventHandler(frmProductoLista_FormClosed);
            frmProductoEdit.ShowDialog();
        }
        #region Metodos Controller
        protected void Cargar(List<Producto> listaProductos)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaProductos == null)
            {
                listaProductos = new List<Producto>();
                listaProductos = ProductoController.GetListProducto(0);
            }
            DataTable table = null;

            if (listaProductos.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaProductos);
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