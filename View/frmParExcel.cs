using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Controller;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmParExcel : Form
    {
        bool flag = false;
        long pex_id = 0;
        List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
        List<ParExcel_Tipo> lstParExcelTipo = new List<ParExcel_Tipo>();

        public frmParExcel()
        {
            InitializeComponent();
        }

        private void frmParExcel_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }







        private void cargar()
        {

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblCodigo, "Indicar Codigo de la Parametricas");
            toolTip1.SetToolTip(this.txtPex_Codigo, "Indicar Codigo de la Parametricas");

            toolTip1.SetToolTip(this.lblNombre, "Indicar nombre de la página de la Parametricas");
            toolTip1.SetToolTip(this.txtPex_Nombre, "Indicar nombre de la página de la Parametricas");

            toolTip1.SetToolTip(this.lblHoja, "Indicar nombre de la  hoja a Parametricas");
            toolTip1.SetToolTip(this.txtPex_Hoja, "Indicar nombre de la  hoja a Parametricas");

            toolTip1.SetToolTip(this.cbxTipoCalculo, "Indicar el tipo de hoja");
            toolTip1.SetToolTip(this.lblTca_nombre, "Indicar el tipo de hoja");

            toolTip1.SetToolTip(this.cbxPex_Tipo, "Indicar tipo de hoja");
            toolTip1.SetToolTip(this.lblPex_Tipo, "Indicar tipo de hoja");

            toolTip1.SetToolTip(this.cbxProducto, "Indicar tipo de hoja");
            toolTip1.SetToolTip(this.lblProducto, "Indicar tipo de hoja");

            if (pex_id == 0)
            {
                lstTipoCalculo = Tipo_CalculoController.GetListTipoCalculo(0);
                cbxTipoCalculo.DataSource = lstTipoCalculo;
                cbxTipoCalculo.DisplayMember = "tcl_nombre";
                cbxTipoCalculo.ValueMember = "tcl_id";

                lstParExcelTipo = ParExcel_TipoController.load();
                cbxPex_Tipo.DataSource = lstParExcelTipo;
                cbxPex_Tipo.DisplayMember = "pxt_codigo";
                cbxPex_Tipo.ValueMember = "pxt_id";

                List<Producto> lstProducto = new List<Producto>();
                Producto producto = new Producto();
                producto.Pro_id = 0;
                producto.Pro_nombre = "";
                lstProducto = ProductoController.GetListProducto(0);
                lstProducto.Insert(0, producto);
                cbxProducto.DataSource = lstProducto;
                cbxProducto.DisplayMember = "Pro_nombre";
                cbxProducto.ValueMember = "Pro_id";
            }
        }




        /// <summary>
        /// Method buscar
        /// </summary>
        public void buscar()
        {
            Session objSession = new Session();
            pex_id = objSession.ID;

            lstTipoCalculo = Tipo_CalculoController.GetListTipoCalculo(0);

            cbxTipoCalculo.DataSource = lstTipoCalculo;
            cbxTipoCalculo.DisplayMember = "tcl_nombre";
            cbxTipoCalculo.ValueMember = "tcl_id";

            lstParExcelTipo = ParExcel_TipoController.load();
            cbxPex_Tipo.DataSource = lstParExcelTipo;
            cbxPex_Tipo.DisplayMember = "pxt_codigo";
            cbxPex_Tipo.ValueMember = "pxt_id";
            
            Producto productoBlanco = new Producto();
            productoBlanco.Pro_id = 0;
            productoBlanco.Pro_nombre = "";
            
            
            List<Producto> lstProducto = new List<Producto>();
            lstProducto = ProductoController.GetListProducto(0);
            lstProducto.Insert(0, productoBlanco);
            cbxProducto.DataSource = lstProducto;
            cbxProducto.DisplayMember = "Pro_nombre";
            cbxProducto.ValueMember = "Pro_id";

            List<ParExcel> lstParExcel = new List<ParExcel>();
            ParExcelController objParExcelController = new ParExcelController();
            lstParExcel = objParExcelController.find();

            if (lstParExcel.Count != 0)
            {
                lstParExcel.ForEach(delegate(ParExcel u)
                {
                    txtPex_Nombre.Text = u.Pex_nombre;
                    txtPex_Codigo.Text = u.Pex_codigo;
                    txtPex_Hoja.Text = u.Pex_hoja;
                    cbxTipoCalculo.SelectedValue = u.Tcl_id;
                    cbxProducto.SelectedValue = u.Pro_id;
                });
                flag = true;
            }
            txtPex_Codigo.Enabled = false;
           
        }

        private void guardar()
        {
            if (validarCampos())
            {
                if (flag == true)
                {
                    switch (MessageBox.Show("Actualizar registro?",
                                  "Validación GEdS Desktop",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:

                            // actualizacion del Parexcel
                            List<ParExcel> lstParExcel = new List<ParExcel>();
                            ParExcelController objparExceController = new ParExcelController();
                            if (cbxProducto.SelectedValue == null)
                              lstParExcel.Add(new ParExcel(pex_id, txtPex_Codigo.Text, txtPex_Nombre.Text, txtPex_Hoja.Text, 1, Convert.ToInt64(cbxTipoCalculo.SelectedValue), 0, Convert.ToInt64(cbxPex_Tipo.SelectedValue)));
                            else
                              lstParExcel.Add(new ParExcel(pex_id, txtPex_Codigo.Text, txtPex_Nombre.Text, txtPex_Hoja.Text, 1, Convert.ToInt64(cbxTipoCalculo.SelectedValue), Convert.ToInt64(cbxProducto.SelectedValue), Convert.ToInt64(cbxPex_Tipo.SelectedValue)));
                            objparExceController.update(lstParExcel);


                            MessageBox.Show("Se actualizó el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            flag = false;
                            this.Close();
                            //doNew();

                            break;
                        case DialogResult.No:
                            // "No" processing
                            break;
                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                }
                else
                {
                    switch (MessageBox.Show("Grabar registro?",
                                  "Validación GEdS Desktop",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            // Save Empresa
                            ParExcel parExce = new ParExcel();
                            parExce.Pex_id = 1;
                            parExce.Pex_nombre = "";
                            parExce.Pex_codigo = "";
                            parExce.Pex_estado = 1;

                            List<ParExcel> lstParExcel = new List<ParExcel>();
                            if (Convert.ToInt64(cbxProducto.SelectedValue) > 0)
                              lstParExcel.Add(new ParExcel(0, txtPex_Codigo.Text, txtPex_Nombre.Text, txtPex_Hoja.Text, 1, Convert.ToInt64(cbxTipoCalculo.SelectedValue), 0, Convert.ToInt64(cbxPex_Tipo.SelectedValue)));
                            else
                              lstParExcel.Add(new ParExcel(0, txtPex_Codigo.Text, txtPex_Nombre.Text, txtPex_Hoja.Text, 1, Convert.ToInt64(cbxTipoCalculo.SelectedValue), Convert.ToInt64(cbxProducto.SelectedValue), Convert.ToInt64(cbxPex_Tipo.SelectedValue)));

                            ParExcelController parExcelController = new ParExcelController();

                            parExcelController.save(lstParExcel);


                            MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                            break;

                        case DialogResult.No:
                            // "No" processing
                            break;

                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                }
            }
            else
            {
            }
        }


        private bool validarCampos()
        {
            bool flag2 = false;
            if (txtPex_Codigo.Text == "")
            {
                MessageBox.Show("Registre el código de la Parametrica del excel", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPex_Codigo.Focus();
                return flag2;
            }
            if (txtPex_Hoja.Text == "")
            {
                MessageBox.Show("Registre la hoja de la Parametrica del excel", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPex_Hoja.Focus();
                return flag2;
            }
            if (txtPex_Nombre.Text == "")
            {
                MessageBox.Show("Registre el nombre de la Parametrica del excel", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPex_Nombre.Focus();
                return flag2;
            }
            
            
            if (flag != true)
            {
                EmpresaObject objEmpresaObject = new EmpresaObject();
                pex_id = objEmpresaObject.generateIdEmpresa();
            }

            flag2 = true;
            return flag2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPex_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPex_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPex_Hoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPec_Columna_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxCampo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxTipoCalculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxPex_Tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
