using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmProducto : Form
    {
        bool flagValidacion;
        long pro_id = 0;
        public frmProducto()
        {
            InitializeComponent();
            Cargar();
        }
        #region Eventos Pagina
        private void frmProducto_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
                CargarCombo();
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Guardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Metodos Controller()
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Producto");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Producto");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Código del Producto");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre del Producto");
            toolTip1.SetToolTip(this.lblcbofields1, "Seleccionar la Unidad de Medida");
            toolTip1.SetToolTip(this.cbofields1, "Seleccionar la Unidad de Medida");
        }
        protected void CargarCombo()
        {
            List<Unidad_Medida> listaUnidadMedida = UnidadMedidaController.GetListaUnidadMedida(0);
            cbofields1.DataSource = listaUnidadMedida;
            cbofields1.DisplayMember = "umd_nombre";
            cbofields1.ValueMember = "umd_id";
        }
        public void Buscar()
        {
            CargarCombo();
            pro_id = frmProductoLista.pro_id1;

            List<Producto> lstProducto = new List<Producto>();
            lstProducto = ProductoController.GetListProducto(pro_id);
            if (lstProducto.Count != 0)
            {
                lstProducto.ForEach(delegate(Producto p)
                {
                    txtfields1.Text = p.Pro_codigo;
                    txtfields2.Text = p.Pro_nombre;
                    cbofields1.Text = p.Umd_nombre;
                    txtPro_var.Text = Convert.ToString(p.Pro_var);
                    txtPro_mer.Text = Convert.ToString(p.Pro_mer);

                });
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
            }
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
                MessageBox.Show(this, "Registre el Código del Producto", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre del Producto", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            return flag = true;
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Producto> lstProducto = new List<Producto>();
                        lstProducto.Add(new Producto(pro_id, txtfields1.Text.Trim(), txtfields2.Text.Trim().ToUpper(), 1, Convert.ToInt64(cbofields1.SelectedValue), Convert.ToInt32(txtPro_var.Text), Convert.ToInt32(txtPro_mer.Text)));
                        Producto producto = new Producto();
                        accion = producto.update(lstProducto);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
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
                        List<Producto> lstProducto = new List<Producto>();
                        lstProducto.Add(new Producto(0, txtfields1.Text.Trim(), txtfields2.Text.Trim().ToUpper(), 1, Convert.ToInt64(cbofields1.SelectedValue), Convert.ToInt32(txtPro_var.Text), Convert.ToInt32(txtPro_mer.Text)));
                        Producto producto = new Producto();
                        accion = producto.insert(lstProducto);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        #endregion

        private void cbofields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}