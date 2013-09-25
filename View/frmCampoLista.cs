using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampoLista : Form
    {
        public static long cam_id1 = 0;
        public static string cam_nombre1;
        List<Campo> listaCampo;
        bool estadoDataGridView = true;
        public frmCampoLista()
        {
            InitializeComponent();
        }
        private void frmCampoLista_Load(object sender, EventArgs e)
        {
            Cargar(listaCampo);
        }
        private void frmCampoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmCampoBusqueda.flagBusqueda == 0)
            {
                Cargar(listaCampo);
                frmCampoBusqueda.flagBusqueda = 0;
                frmCampoBusqueda.listaCampos = null;
            }
            else
            {
                Cargar(frmCampoBusqueda.listaCampos);
                frmCampoBusqueda.flagBusqueda = 0;
                frmCampoBusqueda.listaCampos = null;
            }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (CampoController.GetDatosCampo(cam_id1) != null)
                cam_nombre1 = CampoController.GetDatosCampo(cam_id1).Cam_nombre;
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmCampo frmCampoNew = new frmCampo();
                    frmCampoNew.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
                    listaCampo = null;
                    frmCampoBusqueda.flagBusqueda = 0;
                    frmCampoNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmCampo frmCampoEdit = new frmCampo();
                    frmCampoEdit.Buscar();
                    listaCampo = null;
                    frmCampoBusqueda.flagBusqueda = 0;
                    frmCampoEdit.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
                    frmCampoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaCampo = null;
                    frmCampoBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + cam_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Campo> lstCampo = new List<Campo>();
                            List<Campo> lstCampo2 = new List<Campo>();
                            CampoObject objCampoObject = new CampoObject();
                            lstCampo = objCampoObject.listCampo(cam_id1);
                            if (lstCampo.Count != 0)
                            {
                                lstCampo.ForEach(delegate(Campo c)
                                {
                                    lstCampo2.Add(new Campo(c.Cam_id,  c.Cam_codigo, c.Cam_nombre, 0,1));
                                });
                            }
                            if (objCampoObject.update(lstCampo2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(listaCampo);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }

                    break;
                case "cmdRefresh":
                    frmCampoLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmCampoBusqueda frmBloqueBusquedaFind = new frmCampoBusqueda();
                    frmBloqueBusquedaFind.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
                    frmCampoBusqueda.listaCampos = null;
                    frmCampoBusqueda.flagBusqueda = 0;
                    frmBloqueBusquedaFind.ShowDialog();
                    break;
                case "cmdCampoProductoMercado":
                    //frmCampoProductoMercadoLista objProductoLista = new frmCampoProductoMercadoLista();
                    frmCampoProductoMercado objCampoProductoMercadoLista = new frmCampoProductoMercado();
                    objCampoProductoMercadoLista.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
                    objCampoProductoMercadoLista.Text = (cam_nombre1 != "" ? "Productos y Mercados asociados al Campo: " + cam_nombre1 : "Campo Producto Mercado");
                    //objCampoProductoMercadoLista.Buscar();
                    objCampoProductoMercadoLista.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdCampoSinonimo":
                    frmCampo_SinonimoLista objCampo_SinonimoLista = new frmCampo_SinonimoLista();
                    objCampo_SinonimoLista.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
                    objCampo_SinonimoLista.Text = (cam_nombre1 != "" ? "Sinonimos asociados al Campo: " + cam_nombre1 : "Campo sinonimo");
                    objCampo_SinonimoLista.ShowDialog();

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
            // Find Name of Campo
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    cam_id1 = Convert.ToInt64(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                    //Campo Producto Mercado
                    toolBar1.Buttons[7].Enabled = true;
                    //Campo sinonimo
                    toolBar1.Buttons[8].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Campo Producto Mercado
                    toolBar1.Buttons[7].Enabled = false;
                    //Campo sinonimo
                    toolBar1.Buttons[8].Enabled = false;
                    cam_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Llamada por defecto a form editar
            frmCampo frmCampoEdit = new frmCampo();
            frmCampoEdit.Buscar();
            listaCampo = null;
            frmCampoBusqueda.flagBusqueda = 0;
            frmCampoEdit.FormClosed += new FormClosedEventHandler(frmCampoLista_FormClosed);
            frmCampoEdit.ShowDialog();
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
        #region Metodos Controller
        protected void Cargar(List<Campo> listaCampos)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaCampos == null)
            {
                listaCampos = new List<Campo>();
                listaCampos = CampoController.GetListCampos(0);
            }
            DataTable table = null;

            if (listaCampos.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaCampos);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[7].Enabled = false;
            toolBar1.Buttons[8].Enabled = false;

            dataGridView1.DataSource = table;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}