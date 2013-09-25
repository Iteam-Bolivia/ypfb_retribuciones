using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmCampoProductoMercado : Form
    {
        bool flagValidacion;
        //long cpm_id = 0;
        static int contador = 0;
        public frmCampoProductoMercado()
        {
            InitializeComponent();
            lblCampo.Text = (frmCampoLista.cam_nombre1 != "" ? "Campo: " + frmCampoLista.cam_nombre1 : "");
        }
        #region Eventos Pagina
        private void frmCampoProductoMercado_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void cbofields1_SelectedIndexChanged(object sender, EventArgs e)
        {
            contador = 0;
            int contadorPrecio = 0;

            validarGrilla(out contadorPrecio, out contador);

            if (contador == 0 && contadorPrecio == 0 || contadorPrecio == contador) //if (contador == 0 && contadorPrecio != contador)
            {
                Buscar();
            }
            else if(contadorPrecio != contador)
            {

                if (contador > contadorPrecio)
                {
                    MessageBox.Show("Registre el precio de comercialización del Mercado", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    MessageBox.Show("Seleccione el Mercado que tiene precio", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Realizo modificaciones desea guardarlas.", "Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Guardar();
                }
            }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    break;
                case "cmdEdit":
                    break;
                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar Mercados asociados al Campo " + frmCampoLista.cam_nombre1 + " y al Producto "+ cbofields1.Text + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Campo_Producto_Mercado> lstCPM = new List<Campo_Producto_Mercado>();
                            CampoProductoMercadoObject objCPMObject = new CampoProductoMercadoObject();
                            //lstCPM = objCPMObject.listCampoProductoMercado(cpm_id1);
                            lstCPM = objCPMObject.listCampoProductoMercadoPorCampoProducto(frmCampoLista.cam_id1, Convert.ToInt64(cbofields1.SelectedValue));
                            long deleteMercado = 0;
                            if (lstCPM.Count != 0)
                            {
                                lstCPM.ForEach(delegate(Campo_Producto_Mercado cpm)
                                {
                                    Campo_Producto_Mercado datoscpm = new Campo_Producto_Mercado();
                                    List<Campo_Producto_Mercado> lstCPM2 = new List<Campo_Producto_Mercado>();
                                    lstCPM2.Add(new Campo_Producto_Mercado(cpm.Cpm_id, cpm.Cam_id, cpm.Pro_id, cpm.Mer_id, cpm.Cpm_preciocom.Replace(",", "."), 0));
                                    deleteMercado = datoscpm.update(lstCPM2);
                                });
                                if (deleteMercado != 0)
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
                    frmCampoProductoMercado_Load(sender, e);
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtPrecio_Com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46)
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
                e.Control.KeyPress += new KeyPressEventHandler(this.txtPrecio_Com_KeyPress);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            contador = 0;
            int contadorPrecio = 0;
            validarGrilla(out contadorPrecio,out contador);

            if (contadorPrecio != contador || contador == 0 || contadorPrecio == 0) //if (contador == 0 && contadorPrecio != contador)
            {
                if (contador > contadorPrecio)
                {
                    MessageBox.Show("Registre el precio de comercialización del Mercado", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    MessageBox.Show("Seleccione el Mercado que tiene precio", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
                Guardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion


        #region Metodos


        protected void Cargar()
        {
            if (ProductoController.GetListProducto(0).Count > 0)
            {
                cbofields1.DataSource = ProductoController.GetListProducto(0);
                cbofields1.DisplayMember = "pro_nombre";
                cbofields1.ValueMember = "pro_id";
                cbofields1.SelectedIndexChanged += new EventHandler(cbofields1_SelectedIndexChanged);
            }

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblcbofields1, "Seleccionar el Producto");
            toolTip1.SetToolTip(this.cbofields1, "Seleccionar el Producto");
        }


        public void Buscar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 30;
            DataTable table = null;

            if (cbofields1.SelectedIndex == -1)
            {
                List<Mercado> listaMercados = new List<Mercado>();
                listaMercados = MercadoController.GetListMercados(0);
                if (listaMercados.Count != 0)
                {
                    table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(listaMercados);
                }
                dataGridView1.DataSource = table;
                return;
            }

            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            if (cbofields1.SelectedIndex != 0)
            {
                lstCampoProductoMercado = CampoProductoMercadoController.GetListCampoProductoMercadoPorCampoProducto(frmCampoLista.cam_id1, Convert.ToInt32(cbofields1.SelectedValue));//GetListCampoProductoMercadoPorCampo(frmCampoLista.cam_id1);
            }

            if (lstCampoProductoMercado.Count != 0)
            {
                foreach (Campo_Producto_Mercado cpm in lstCampoProductoMercado)
                {
                    cbofields1.Text = cpm.Pro_nombre;
                }
                lstCampoProductoMercado = CampoProductoMercadoController.GetListMercadosPorCampoProducto(frmCampoLista.cam_id1, Convert.ToInt64(cbofields1.SelectedValue));
                if (lstCampoProductoMercado.Count != 0)
                {
                    table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(lstCampoProductoMercado);
                    toolBar1.Buttons[1].Enabled = true;
                }
                dataGridView1.DataSource = table;
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
                List<Mercado> listaMercados = new List<Mercado>();
                if (cbofields1.SelectedIndex != 0)
                {
                    listaMercados = MercadoController.GetListMercados(0);
                    if (listaMercados.Count != 0)
                    {
                        table = new DataTable();
                        Misc objMisc = new Misc();
                        table = objMisc.GenericListToDataTable(listaMercados);
                        toolBar1.Buttons[1].Enabled = false;
                    }
                }
                dataGridView1.DataSource = table;
            }
        }
        protected void Guardar()
        {
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (GuardarProductoMercado(1))
                            MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, "Hubo error en  la actualzación", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else//Registrar
            {
                switch (MessageBox.Show("Grabar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (GuardarProductoMercado(0))
                            MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, "Hubo error en  la actualzación", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        protected bool GuardarProductoMercado(int accion)
        {
            int cantidadSeleccionada = 0;
            int cantidadAlmacenada = 0;
            List<Campo_Producto_Mercado> lista = new List<Campo_Producto_Mercado>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        Campo_Producto_Mercado campoProductoMercado = new Campo_Producto_Mercado();
                        campoProductoMercado.Cpm_id = 0;
                        campoProductoMercado.Cam_id = frmCampoLista.cam_id1;
                        campoProductoMercado.Pro_id = Convert.ToInt64(cbofields1.SelectedValue);
                        campoProductoMercado.Mer_id = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        campoProductoMercado.Cpm_preciocom = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        campoProductoMercado.Cpm_estado = 1;
                        lista.Add(campoProductoMercado);
                    }
                }
            }
            cantidadSeleccionada = lista.Count;
            Campo_Producto_Mercado cpm = new Campo_Producto_Mercado();
            long res = 0;
            //return false;
            if (accion == 0)//Guardar
                res = 1;
            else//Actualizar
            {
                res = cpm.delete("cam_id = " + frmCampoLista.cam_id1 + " AND pro_id = " + Convert.ToInt64(cbofields1.SelectedValue) + " AND cpm_estado = 1");
            }
            if (res != 0)
            {
                foreach (Campo_Producto_Mercado item in lista)
                {
                    cpm = new Campo_Producto_Mercado();
                    List<Campo_Producto_Mercado> listaGeneral = new List<Campo_Producto_Mercado>();
                    listaGeneral.Add(item);
                    res = cpm.insert(listaGeneral);
                    if (res != 1)
                        cantidadAlmacenada++;
                }
                if (cantidadAlmacenada == cantidadSeleccionada)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }


        public void validarGrilla(out int contadorPrecio, out int contador)
        {
            int resAsociacion = 0;
            decimal resPrecio = 0;
            contador = 0;
            contadorPrecio = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                resAsociacion = (Convert.IsDBNull(item.Cells[2].Value) ? 0 : Convert.ToInt32(item.Cells[2].Value));
                resPrecio = (Convert.IsDBNull(item.Cells[3].Value) ? 0 : Convert.ToDecimal(item.Cells[3].Value));
                if (resAsociacion > 0)//Verificar si se ha seleccionado alguna fila
                    contador++;
                if (resPrecio > 0)
                    contadorPrecio++;
            }
        }
        #endregion
    }
} 