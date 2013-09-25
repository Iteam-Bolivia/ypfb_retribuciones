using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampoProductoMercadoLista : Form
    {
        public static long cpm_id1 = 0;
        
        public frmCampoProductoMercadoLista()
        {
            InitializeComponent();
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmCampoProductoMercado frmCampoProductoMercadoNew = new frmCampoProductoMercado();
                    frmCampoProductoMercadoNew.FormClosed += new FormClosedEventHandler(frmCampoProductoMercadoLista_FormClosed);
                    frmCampoProductoMercadoNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmCampoProductoMercado frmCampoProductoMercadoEdit = new frmCampoProductoMercado();
                    frmCampoProductoMercadoEdit.FormClosed += new FormClosedEventHandler(frmCampoProductoMercadoLista_FormClosed);
                    frmCampoProductoMercadoEdit.Buscar();
                    frmCampoProductoMercadoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + cpm_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Campo_Producto_Mercado> lstCPM = new List<Campo_Producto_Mercado>();
                            List<Campo_Producto_Mercado> lstCPM2 = new List<Campo_Producto_Mercado>();
                            CampoProductoMercadoObject objCPMObject = new CampoProductoMercadoObject();
                            Campo_Producto_Mercado datoscpm = new Campo_Producto_Mercado();
                            lstCPM = objCPMObject.listCampoProductoMercado(cpm_id1);
                            if (lstCPM.Count != 0)
                            {
                                lstCPM.ForEach(delegate(Campo_Producto_Mercado cpm)
                                {
                                    lstCPM2.Add(new Campo_Producto_Mercado(cpm.Cpm_id, cpm.Cam_id, cpm.Pro_id, cpm.Mer_id, cpm.Cpm_preciocom.Replace(",", "."), 0));
                                });
                                if (datoscpm.update(lstCPM2) != 0)
                                    MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Cargar();
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

        private void frmProductoLista_Load(object sender, System.EventArgs e)
        {
            Cargar();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];            
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    cpm_id1 = Convert.ToInt64(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    cpm_id1 = 0;
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                }
            }
            catch
            { }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1_Click(sender, e);
            //Llamada a accion editar

            frmCampoProductoMercado frmCampoProductoMercadoEdit = new frmCampoProductoMercado();
            frmCampoProductoMercadoEdit.FormClosed += new FormClosedEventHandler(frmCampoProductoMercadoLista_FormClosed);
            frmCampoProductoMercadoEdit.Buscar();
            frmCampoProductoMercadoEdit.ShowDialog();
        }

        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<Campo_Producto_Mercado> list = CampoProductoMercadoController.GetListCampoProductoMercadoPorCampo(frmCampoLista.cam_id1);

            DataTable table = null;

            if (list.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(list);
            }
            //Adicionar
            toolBar1.Buttons[0].Enabled = true;
            //Eliminar
            toolBar1.Buttons[1].Enabled = false;
            //Editar
            toolBar1.Buttons[2].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion

        private void frmCampoProductoMercadoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar();
        }
    }
}