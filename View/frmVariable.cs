using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmVariable : Form
    {
        bool flag = false;
        long var_id = 0;
        long umd_id = 0;
        long tcl_id = 0;
        long var_imprime = 0;
        long var_calvalmer = 0;

        Session objSession = new Session();
        string var_tipo;
        string var_total;

        public frmVariable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmVariable_Load
        /// </summary>
        private void frmVariable_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /* View */
        /// <summary>
        /// Method txtfields1_KeyPress
        /// </summary>   
        private void txtfields1_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method txtfields2_KeyPress
        /// </summary>
        private void txtfields2_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method txtfields3_KeyPress
        /// </summary>
        private void txtfields3_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46)
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;


        }




        /// <summary>
        /// Method txtfields4_KeyPress
        /// </summary>
        private void txtfields4_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }


        /// <summary>
        /// Method txtfields5_KeyPress
        /// </summary>
        private void txtfields5_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }


        /// <summary>
        /// Method txtfields6_KeyPress
        /// </summary>   
        private void txtfields6_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method txtfields7_KeyPress
        /// </summary>   
        private void txtfields7_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method cbofields1_KeyPress
        /// </summary>
        private void cbofields1_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method cbofields2_KeyPress
        /// </summary>
        private void cbofields2_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method cbofields3_KeyPress
        /// </summary>
        private void cbofields3_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbofields4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbofields5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbofields6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        private void cbofields7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbofields8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        private void cbofields9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbofields10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method btnGuardar_Click
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();

        }


        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Method childForm4_FormClosed
        /// </summary>
        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        /// Controller
        /// <summary>
        /// Method cargar
        /// </summary>
        private void cargar()
        {

            Session objSession = new Session();
            this.Text = this.Text + " - " + objSession.SISTEMA;  

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(this.cbofields1, "Indicar el Tipo de Variable: Con Fórmula/Sin Fórmula");
            toolTip1.SetToolTip(this.cbofields2, "Indicar la Unidad de Medida de la Variable");
            toolTip1.SetToolTip(this.cbofields3, "Indicar el Tipo de Cálculo");

            toolTip1.SetToolTip(this.txtfields1, "Indicar la variable");
            toolTip1.SetToolTip(this.txtfields2, "Describir la Variable");
            toolTip1.SetToolTip(this.txtfields3, "Indicar el valor inicial de la Variable");
            toolTip1.SetToolTip(this.txtfields4, "Indicar el Orden de procesamiento de la Variable");
            toolTip1.SetToolTip(this.txtfields5, "Indicar el Orden de Impresión de la Variable");

            txtfields1.Text = "";
            txtfields2.Text = "";
            txtfields3.Text = "0.00";

            cbofields1.Items.Clear();
            cbofields1.Items.Add("Sin formula");
            cbofields1.Items.Add("Con Formula");
            cbofields1.SelectedIndex = 0;

            cbofields4.Items.Clear();
            cbofields4.Items.Add("No");
            cbofields4.Items.Add("Si");
            cbofields4.SelectedIndex = 0;

            //label17.Visible = true;
            //cboCampo.Visible = true;
            //cbCampo.Visible = false;

            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            UnidadMedidaObject objUnidadMedidaObject = new UnidadMedidaObject();
            lstUnidadMedida = objUnidadMedidaObject.listUnidadMedida(0);
            if (lstUnidadMedida.Count == 0)
            {
                cbofields2.Items.Clear();
            }
            else
            {
                cbofields2.Items.Clear();
                cbofields2.DataSource = lstUnidadMedida;
                cbofields2.DisplayMember = "umd_codigo";
                cbofields2.ValueMember = "umd_id";
                cbofields2.SelectedIndex = 0;
            }


            List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
            Tipo_CalculoObject objTipoCalculoObject = new Tipo_CalculoObject();

            lstTipoCalculo = objTipoCalculoObject.listTipoCalculo(0);
            if (lstTipoCalculo.Count == 0)
            {
                cbofields3.Items.Clear();
            }
            else
            {
                cbofields3.Items.Clear();
                cbofields3.DataSource = lstTipoCalculo;
                cbofields3.DisplayMember = "tcl_codigo";
                cbofields3.ValueMember = "tcl_id";
                cbofields3.SelectedIndex = 0;
            }



            // Producto
            List<Producto> lstProducto = new List<Producto>();
            ProductoObject objProductoObject = new ProductoObject();
            lstProducto = objProductoObject.listProducto(0);
            if (lstProducto.Count == 0)
            {
                cbofields5.Items.Clear();
            }
            else
            {
                cbofields5.Items.Clear();
                cbofields5.DataSource = lstProducto;
                cbofields5.DisplayMember = "pro_codigo";
                cbofields5.ValueMember = "pro_id";
                cbofields5.SelectedIndex = 2;
            }


            // Mercado
            List<Mercado> lstMercado = new List<Mercado>();
            MercadoObject objMercadoObject = new MercadoObject();
            lstMercado = objMercadoObject.listMercado(0);
            if (lstMercado.Count == 0)
            {
                cbofields3.Items.Clear();
            }
            else
            {
                cbofields6.Items.Clear();
                cbofields6.DataSource = lstMercado;
                cbofields6.DisplayMember = "mer_codigo";
                cbofields6.ValueMember = "mer_id";
                cbofields6.SelectedIndex = 13;
            }


            // Variables
            List<Variable> lstVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariable(0);
            if (lstVariable.Count == 0)
            {
                cbofields7.Items.Clear();
            }
            else
            {
                cbofields7.Items.Clear();
                cbofields7.DataSource = lstVariable;
                cbofields7.DisplayMember = "var_codigo";
                cbofields7.ValueMember = "var_id";
                cbofields7.SelectedIndex = 0;
            }


            // Variables
            List<Variable> lstVariable2 = new List<Variable>();
            VariableObject objVariableObject2 = new VariableObject();
            lstVariable2 = objVariableObject2.listVariable(0);
            if (lstVariable2.Count == 0)
            {
                cbofields10.Items.Clear();
            }
            else
            {
                cbofields10.Items.Clear();
                cbofields10.DataSource = lstVariable2;
                cbofields10.DisplayMember = "var_codigo";
                cbofields10.ValueMember = "var_id";
                cbofields10.SelectedIndex = 0;
            }


            cbofields8.Items.Clear();
            cbofields8.Items.Add("Ninguno");
            cbofields8.Items.Add("SubTotal");
            cbofields8.Items.Add("Total");
            cbofields8.SelectedIndex = 0;


            // Producto
            List<Tipo_Proyeccion> lstTipoProyeccion = new List<Tipo_Proyeccion>();
            Tipo_ProyeccionObject objTipoProyeccionObject = new Tipo_ProyeccionObject();
            lstTipoProyeccion = objTipoProyeccionObject.listTipo_Proyeccion(0);
            if (lstTipoProyeccion.Count == 0)
            {
                cbofields9.Items.Clear();
            }
            else
            {
                cbofields9.Items.Clear();
                cbofields9.DataSource = lstTipoProyeccion;
                cbofields9.DisplayMember = "tpy_nombre";
                cbofields9.ValueMember = "tpy_id";
                cbofields9.SelectedIndex = 0;
            }




            // campo
            List<Campo> lstCampo = new List<Campo>();
            CampoObject objCamopoObject = new CampoObject();
            lstCampo = objCamopoObject.listCampo(0);
            if (lstCampo.Count == 0)
            {
                cboCampo.Items.Clear();
            }
            else
            {
                cboCampo.Items.Clear();
                cboCampo.DataSource = lstCampo;
                cboCampo.DisplayMember = "cam_nombre";
                cboCampo.ValueMember = "cam_id";
                cboCampo.SelectedIndex = 0;
            }

            var_id = objSession.ID;
            if (var_id != 0)
            {
                this.buscar(var_id);
            }

        }


        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscar(long var_id)
        {
            List<Variable> lstVariable = new List<Variable>();
            VariableController objVariableController = new VariableController();
            lstVariable = objVariableController.list(var_id);
            if (lstVariable.Count == 0)
            {
                //MessageBox.Show("¡NO EXISTEN VariableS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lstVariable.ForEach(delegate(Variable v)
                {

                    txtfields1.Text = v.Var_codigo;
                    txtfields2.Text = v.Var_nombre;
                    txtfields3.Text = System.Convert.ToString(v.Var_valini);
                    txtfields4.Text = System.Convert.ToString(v.Var_orden);
                    if (v.Tcl_id != 2)
                    {
                        txtfields5.Text = System.Convert.ToString(v.Var_impresion);
                    }
                    else
                    {
                        txtfields5.Text = System.Convert.ToString(v.Var_impresion_a);
                    }
                    txtfields6.Text = System.Convert.ToString(v.Var_descripcion);
                    cbofields1.Items.Clear();
                    cbofields1.Items.Add("Sin formula");
                    cbofields1.Items.Add("Con Formula");
                    if (v.Var_tipo.Equals("N"))
                    {
                        cbofields1.SelectedIndex = 0;
                    }
                    else
                    {
                        cbofields1.SelectedIndex = 1;
                    }
                    cbofields2.Text = v.Umd_codigo;
                    cbofields3.Text = v.Tcl_codigo;
                    cbofields4.Items.Clear();
                    cbofields4.Items.Add("No");
                    cbofields4.Items.Add("Si");
                    if (v.Var_imprime == 0)
                    {
                        cbofields4.SelectedIndex = 0;
                    }
                    else
                    {
                        cbofields4.SelectedIndex = 1;
                    }

                    tcl_id = v.Tcl_id;
                    // Variables
                    List<Variable> lstVariable1 = new List<Variable>();
                    VariableObject objVariableObject = new VariableObject();
                    lstVariable1 = objVariableObject.findByTcl_id(tcl_id);
                    if (lstVariable1.Count == 0)
                    {
                        cbofields7.Items.Clear();
                    }
                    else
                    {
                        cbofields7.DataSource = lstVariable1;
                        cbofields7.DisplayMember = "var_codigo";
                        cbofields7.ValueMember = "var_id";
                        cbofields7.SelectedIndex = 0;
                    }


                    // Variables
                    List<Variable> lstVariable2 = new List<Variable>();
                    VariableObject objVariableObject2 = new VariableObject();
                    lstVariable2 = objVariableObject2.findByTcl_id(tcl_id);
                    if (lstVariable2.Count == 0)
                    {
                        cbofields10.Items.Clear();
                    }
                    else
                    {
                        cbofields10.DataSource = lstVariable2;
                        cbofields10.DisplayMember = "var_codigo";
                        cbofields10.ValueMember = "var_id";
                        cbofields10.SelectedIndex = 0;
                    }


                    cbofields5.Text = v.Producto;
                    cbofields6.Text = v.Mercado;
                    cbofields7.Text = v.Var_codigod;
                    cbofields10.SelectedValue = v.Vard_id;
                    //          
                    cbofields8.Text = v.Tpy_nombre;

                    cbofields8.Items.Clear();
                    cbofields8.Items.Add("Ninguno");
                    cbofields8.Items.Add("SubTotal");
                    cbofields8.Items.Add("Total");

                    // campo
                    List<Campo> lstCampo = new List<Campo>();
                    CampoObject objCamopoObject = new CampoObject();
                    lstCampo = objCamopoObject.listCampo(0);
                    if (lstCampo.Count == 0)
                    {
                        cboCampo.Items.Clear();
                    }
                    else
                    {
                        //cboCampo.Items.Clear();
                        cboCampo.DataSource = lstCampo;
                        cboCampo.DisplayMember = "cam_nombre";
                        cboCampo.ValueMember = "cam_id";
                    }

                    cboCampo.SelectedValue = v.Cam_id;

                    switch (v.Var_total)
                    {
                        case "N":
                            cbofields8.SelectedIndex = 0;
                            break;
                        case "S":
                            cbofields8.SelectedIndex = 1;
                            break;
                        case "T":
                            cbofields8.SelectedIndex = 2;
                            break;
                    }
                    cbxCuadro.Text = v.Var_posicion.ToString();
                    cbxTipoCalculo.SelectedIndex = Convert.ToInt32(v.Var_tipo_cal - 1);
                    ////aumentado diego 10-10-2012
                    txtVar_m.Text = Convert.ToString(v.Var_m);
                    txtVar_cam.Text = Convert.ToString(v.Var_cam);
                    txtFor_m.Text = Convert.ToString(v.For_m);
                    ////////////////
                });
            }
            flag = true;
        }

        /// <summary>
        /// Method validarCampos
        /// </summary>
        private bool validarCampos()
        {
            bool flag2 = false;

            VariableObject objVariableObject = new VariableObject();
            if (objVariableObject.existVariableNombre(txtfields1.Text, System.Convert.ToInt64(cbofields3.SelectedValue)))
            {
                MessageBox.Show("La variable ya existe", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                flag = true;
            }

            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre la variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag2;
            }

            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre el valor inicial de la variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag2;
            }

            if (txtfields5.Text == "")
            {
                MessageBox.Show("Registre el orden de las variables", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields5.Focus();
                return flag2;
            }


            if (cbofields1.Text == "Sin formula")
            {
                var_tipo = "N";
                var_calvalmer = 0;
            }
            else
            {
                var_tipo = "S";
                var_calvalmer = 1;
                txtfields6.Text = txtfields6.Text.ToUpper();
            }


            var v_umd_id = cbofields2.SelectedValue;
            umd_id = System.Convert.ToInt64(v_umd_id);

            var v_tcl_id = cbofields3.SelectedValue;
            tcl_id = System.Convert.ToInt64(v_tcl_id);

            var v_var_imprime = cbofields4.SelectedValue;
            var_imprime = System.Convert.ToInt64(v_var_imprime);


            switch (cbofields8.Text)
            {
                case "Ninguno":
                    var_total = "N";
                    break;
                case "SubTotal":
                    var_total = "S";
                    break;
                case "Total":
                    var_total = "T";
                    break;
            }

            flag2 = true;
            return flag2;
        }


        /// <summary>
        /// Method guardar
        /// </summary>
        private void guardar()
        {
            long inserted = 0;


            if (validarCampos())
            {
                if (flag == true)
                {
                    switch (MessageBox.Show("Actualizar registro?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            // Fill data      
                            VariableObject objVariableObject = new VariableObject();
                            List<Variable> lstVariable = new List<Variable>();
                            lstVariable = objVariableObject.listVariable(var_id);
                            lstVariable.ForEach(delegate(Variable v)
                            {
                                var_calvalmer = v.Tpy_id;
                            });
                            // Fill data      
                            List<Variable> lstVariable2 = new List<Variable>();
                            Variable variable = new Variable();
                            if (tcl_id != 2)
                            {
                                variable.Var_id = System.Convert.ToInt64(var_id);
                                variable.Var_codigo = System.Convert.ToString(txtfields1.Text.Trim());
                                variable.Var_nombre = System.Convert.ToString(txtfields2.Text.Trim());
                                variable.Var_tipo = System.Convert.ToString(var_tipo);
                                variable.Var_valini = System.Convert.ToDecimal(txtfields3.Text.Trim());
                                variable.Var_estado = System.Convert.ToInt64(1);
                                variable.Var_orden = System.Convert.ToInt64(txtfields4.Text.Trim());
                                variable.Umd_id = System.Convert.ToInt64(umd_id);
                                variable.Tcl_id = System.Convert.ToInt64(tcl_id);
                                variable.Var_impresion = System.Convert.ToInt64(txtfields5.Text.Trim());
                                variable.Var_imprime = System.Convert.ToInt64(cbofields4.SelectedIndex);
                                variable.Var_descripcion = System.Convert.ToString(txtfields6.Text.Trim());
                                variable.Tpy_id = System.Convert.ToInt64(cbofields9.SelectedValue);
                                variable.Mer_id = System.Convert.ToInt64(cbofields6.SelectedValue);
                                variable.Pro_id = System.Convert.ToInt64(cbofields5.SelectedValue);
                                variable.Var_codigod = System.Convert.ToString(cbofields7.Text);
                                variable.Var_total = System.Convert.ToString(var_total);
                                variable.Vard_id = System.Convert.ToInt64(cbofields10.SelectedValue);
                                variable.Var_posicion = Convert.ToInt64(cbxCuadro.Text);
                                variable.Var_impresion_a = 0;
                                if (cbxTipoCalculo.Text == "Lista la variable")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(1);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la formula y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(2);
                                }
                                else if (cbxTipoCalculo.Text == "Guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(3);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la variabler y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(4);
                                }
                                variable.Cam_id = Convert.ToInt64(cboCampo.SelectedValue);
                                ////aumentado diego 10-10-2012
                                variable.Var_m = Convert.ToInt32(txtVar_m.Text);
                                variable.Var_cam = Convert.ToInt32(txtVar_cam.Text);
                                variable.For_m = Convert.ToInt32(txtFor_m.Text);
                                //////////////////
                                lstVariable2.Add(variable);
                            }
                            else
                            {
                                variable.Var_id = System.Convert.ToInt64(var_id);
                                variable.Var_codigo = System.Convert.ToString(txtfields1.Text.Trim());
                                variable.Var_nombre = System.Convert.ToString(txtfields2.Text.Trim());
                                variable.Var_tipo = System.Convert.ToString(var_tipo);
                                variable.Var_valini = System.Convert.ToDecimal(txtfields3.Text.Trim());
                                variable.Var_estado = System.Convert.ToInt64(1);
                                variable.Var_orden = System.Convert.ToInt64(txtfields4.Text.Trim());
                                variable.Umd_id = System.Convert.ToInt64(umd_id);
                                variable.Tcl_id = System.Convert.ToInt64(tcl_id);
                                variable.Var_impresion_a = System.Convert.ToInt64(txtfields5.Text.Trim());
                                variable.Var_imprime = System.Convert.ToInt64(cbofields4.SelectedIndex);
                                variable.Var_descripcion = System.Convert.ToString(txtfields6.Text.Trim());
                                variable.Tpy_id = System.Convert.ToInt64(cbofields9.SelectedValue);
                                variable.Mer_id = System.Convert.ToInt64(cbofields6.SelectedValue);
                                variable.Pro_id = System.Convert.ToInt64(cbofields5.SelectedValue);
                                variable.Var_codigod = System.Convert.ToString(cbofields7.Text);
                                variable.Var_total = System.Convert.ToString(var_total);
                                variable.Vard_id = System.Convert.ToInt64(cbofields10.SelectedValue);
                                variable.Var_posicion = Convert.ToInt64(cbxCuadro.Text);
                                variable.Var_impresion = 0;
                                if (cbxTipoCalculo.Text == "Lista la variable")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(1);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la formula y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(2);
                                }
                                else if (cbxTipoCalculo.Text == "Guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(3);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la variabler y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(4);
                                }
                                variable.Cam_id = Convert.ToInt64(cboCampo.SelectedValue);
                                ////aumentado diego 10-10-2012
                                variable.Var_m = Convert.ToInt32(txtVar_m.Text);
                                variable.Var_cam = Convert.ToInt32(txtVar_cam.Text);
                                variable.For_m = Convert.ToInt32(txtFor_m.Text);
                                //////////////////
                                lstVariable2.Add(variable);
                            }
                            // Save data from Variable
                            VariableController objVariableController = new VariableController();
                            inserted = objVariableController.edit(lstVariable2);
                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            flag = false;
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
                else
                {
                    switch (MessageBox.Show("Grabar registro?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            // Fill data      
                            List<Variable> lstVariable = new List<Variable>();
                            Variable variable = new Variable();
                            if (tcl_id != 2)
                            {
                                variable.Var_id = System.Convert.ToInt64(0);
                                variable.Var_codigo = System.Convert.ToString(txtfields1.Text.Trim());
                                variable.Var_nombre = System.Convert.ToString(txtfields2.Text.Trim());
                                variable.Var_tipo = System.Convert.ToString(var_tipo);
                                variable.Var_valini = System.Convert.ToDecimal(txtfields3.Text.Trim());
                                variable.Var_estado = System.Convert.ToInt64(1);
                                variable.Var_orden = System.Convert.ToInt64(txtfields4.Text.Trim());
                                variable.Umd_id = System.Convert.ToInt64(umd_id);
                                variable.Tcl_id = System.Convert.ToInt64(tcl_id);
                                variable.Var_impresion = System.Convert.ToInt64(txtfields5.Text.Trim());
                                variable.Var_imprime = System.Convert.ToInt64(cbofields4.SelectedIndex);
                                variable.Var_descripcion = System.Convert.ToString(txtfields6.Text.Trim());
                                variable.Tpy_id = System.Convert.ToInt64(cbofields9.SelectedValue);
                                variable.Mer_id = System.Convert.ToInt64(cbofields6.SelectedValue);
                                variable.Pro_id = System.Convert.ToInt64(cbofields5.SelectedValue);
                                variable.Var_codigod = System.Convert.ToString(cbofields7.Text);
                                variable.Var_total = System.Convert.ToString(var_total);
                                variable.Vard_id = System.Convert.ToInt64(cbofields7.SelectedValue);
                                variable.Var_posicion = Convert.ToInt64(cbxCuadro.Text);
                                variable.Var_impresion_a = 0;
                                if (cbxTipoCalculo.Text == "Lista la variable")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(1);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la formula y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(2);
                                }
                                else if (cbxTipoCalculo.Text == "Guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(3);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la variabler y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(4);
                                }
                                variable.Cam_id = Convert.ToInt64(cboCampo.SelectedValue);

                                ////aumentado diego 10-10-2012
                                variable.Var_m = Convert.ToInt32(txtVar_m.Text);
                                variable.Var_cam = Convert.ToInt32(txtVar_cam.Text);
                                variable.For_m = Convert.ToInt32(txtFor_m.Text);
                                //////////////////
                                lstVariable.Add(variable);
                            }
                            else
                            {
                                variable.Var_id = System.Convert.ToInt64(0);
                                variable.Var_codigo = System.Convert.ToString(txtfields1.Text.Trim());
                                variable.Var_nombre = System.Convert.ToString(txtfields2.Text.Trim());
                                variable.Var_tipo = System.Convert.ToString(var_tipo);
                                variable.Var_valini = System.Convert.ToDecimal(txtfields3.Text.Trim());
                                variable.Var_estado = System.Convert.ToInt64(1);
                                variable.Var_orden = System.Convert.ToInt64(txtfields4.Text.Trim());
                                variable.Umd_id = System.Convert.ToInt64(umd_id);
                                variable.Tcl_id = System.Convert.ToInt64(tcl_id);
                                variable.Var_impresion_a = System.Convert.ToInt64(txtfields5.Text.Trim());
                                variable.Var_imprime = System.Convert.ToInt64(cbofields4.SelectedIndex);
                                variable.Var_descripcion = System.Convert.ToString(txtfields6.Text.Trim());
                                variable.Tpy_id = System.Convert.ToInt64(cbofields9.SelectedValue);
                                variable.Mer_id = System.Convert.ToInt64(cbofields6.SelectedValue);
                                variable.Pro_id = System.Convert.ToInt64(cbofields5.SelectedValue);
                                variable.Var_codigod = System.Convert.ToString(cbofields7.Text);
                                variable.Var_total = System.Convert.ToString(var_total);
                                variable.Vard_id = System.Convert.ToInt64(cbofields7.SelectedValue);
                                variable.Var_posicion = Convert.ToInt64(cbxCuadro.Text);
                                variable.Var_impresion = 0;
                                if (cbxTipoCalculo.Text == "Lista la variable")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(1);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la formula y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(2);
                                }
                                else if (cbxTipoCalculo.Text == "Guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(3);
                                }
                                else if (cbxTipoCalculo.Text == "Lista la variabler y guarda 1 vez")
                                {
                                    variable.Var_tipo_cal = Convert.ToInt64(4);
                                }
                                variable.Cam_id = Convert.ToInt64(cboCampo.SelectedValue);
                                ////aumentado diego 10-10-2012
                                variable.Var_m = Convert.ToInt32(txtVar_m.Text);
                                variable.Var_cam = Convert.ToInt32(txtVar_cam.Text);
                                variable.For_m = Convert.ToInt32(txtFor_m.Text);
                                //////////////////
                                lstVariable.Add(variable);
                            }
                            // Save data from Variable
                            VariableController objVariableController = new VariableController();
                            inserted = objVariableController.save(lstVariable);
                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();

                            }

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

        private void cbCampo_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbCampo.Checked == true)
            //{
            //    label17.Visible = true;
            //    cboCampo.Visible = true;
            //}
            //else
            //{
            //    label17.Visible = false;
            //    cboCampo.Visible = false;
            //}
        }

        private void cbofields3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}