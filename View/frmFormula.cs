using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using LibFormula;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmFormula : Form
    {
        bool flag = false;
        long for_id = 0;
        long var_id = 0;
        long tcl_id = 0;

        public frmFormula()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmFormula_Load
        /// </summary>
        private void frmFormula_Load(object sender, EventArgs e)
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
            e.KeyChar = Char.ToUpper(e.KeyChar);
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
        /// Method txtfields2_KeyPress
        /// </summary>
        private void txtfields3_KeyPress(object sender,
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
        /// Method txtfields3_KeyPress
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

        private void lstCalculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sw = 0;
            string var_codigo = lstCalculos.Text;
            List<Variable> lstVariable = new List<Variable>();
            if (var_codigo.Length > 0)
            {
                VariableObject objVariableObject = new VariableObject();
                lstVariable = objVariableObject.listVariablePorCodigo(var_codigo);
                lstVariable.ForEach(delegate(Variable v)
                {
                    if (sw == 0)
                    {
                        txtDescripcionVariable.Text = v.Var_nombre;
                        txtfields2.Text = txtfields2.Text + " " + var_codigo;
                        sw = 1;
                    }
                });
            }
        }


        private void lstFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string var_codigo = lstFunciones.Text;
            if (var_codigo.Length > 0)
            {
                txtfields2.Text = txtfields2.Text + " " + var_codigo;
            }
        }

        /// <summary>
        /// Method btnGuardar_Click
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        /// <summary>
        /// Method btnCancelar_Click
        /// </summary>
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            long deleted = 0;
            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {

                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + for_id + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            FormulaController objFormulaController2 = new FormulaController();
                            deleted = objFormulaController2.delete(for_id);
                            if (deleted == 0)
                            {
                                MessageBox.Show("Hubo error en la eliminación del registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("Se eliminó con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            break;
                    }
                    break;

                case "cmdClose":
                    this.Close();
                    break;

                default:
                    break;
            }
        }












        /// Controller
        /// <summary>
        /// Method cargar
        /// </summary>
        private void cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(this.lstCalculos, "Indicar el Tipo de Variable: Con Fórmula/Sin Fórmula");
            toolTip1.SetToolTip(this.txtDescripcionVariable, "Indicar la Unidad de Medida de la Variable");

            toolTip1.SetToolTip(this.txtfields1, "Nombre de la Variable");
            toolTip1.SetToolTip(this.txtfields2, "Fórmula");
            toolTip1.SetToolTip(this.txtfields4, "Valor Inicial de la Variable");

            Session objSession = new Session();
            var_id = objSession.ID;


            List<Variable> lstVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariable(var_id);
            if (lstVariable.Count != 0)
            {
                lstVariable.ForEach(delegate(Variable v)
                {
                    txtfields1.Text = v.Var_codigo;
                    txtfields3.Text = System.Convert.ToString(v.Var_nombre).ToUpper();
                    tcl_id = v.Tcl_id;
                    if (v.Tpy_id == 1)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                });
            }

            // Funciones
            lstFunciones.Items.Clear();
            lstFunciones.Items.Add("+");
            lstFunciones.Items.Add("-");
            lstFunciones.Items.Add("*");
            lstFunciones.Items.Add("/");

            lstFunciones.Items.Add("Max");
            lstFunciones.Items.Add("Min");
            lstFunciones.Items.Add("Rnd");
            lstFunciones.Items.Add("INt");
            lstFunciones.Items.Add("Fix");
            lstFunciones.Items.Add("Abs");
            lstFunciones.Items.Add("Sgn");
            lstFunciones.Items.Add("Cos");
            lstFunciones.Items.Add("Sin");
            lstFunciones.Items.Add("Tan");
            lstFunciones.Items.Add("Atn");
            lstFunciones.Items.Add("Exp");
            lstFunciones.Items.Add("Log");
            lstFunciones.Items.Add("Sec");
            lstFunciones.Items.Add("CoSec");
            lstFunciones.Items.Add("CoTan");
            lstFunciones.Items.Add("EQ");
            lstFunciones.Items.Add("NEQ");
            lstFunciones.Items.Add("LT");
            lstFunciones.Items.Add("LET");
            lstFunciones.Items.Add("GT");
            lstFunciones.Items.Add("GET");

            List<Formula> lstFormula = new List<Formula>();
            FormulaObject objFormulaObject = new FormulaObject();
            lstFormula = objFormulaObject.listFormulaPorVariableId(var_id);
            if (lstFormula.Count != 0)
            {
                lstFormula.ForEach(delegate(Formula u)
                {
                    for_id = u.For_id;
                    txtfields2.Text = u.For_codigo;
                    txtfields4.Text = System.Convert.ToString(u.For_valini);
                    //Aumentado Diego 10-10-2012
                    txtForTipo.Text = Convert.ToString(u.For_tipo);
                    ////////////
                    flag = true;
                });
            }



            // Variable
            List<Variable> lstVariable2 = new List<Variable>();
            VariableObject objVariableObject2 = new VariableObject();
            lstVariable2 = objVariableObject.listVariable(0);
            if (lstVariable2.Count == 0)
            {
                lstCalculos.Items.Clear();
            }
            else
            {

                if (lstVariable2.Count == 0)
                {
                    // Cargar Variables
                    lstCalculos.Items.Clear();
                }
                else
                {
                    lstCalculos.Items.Clear();
                    lstVariable2.ForEach(delegate(Variable v)
                    {
                        if (v.Tcl_id == tcl_id)
                        {
                            lstCalculos.Items.Add(v.Var_codigo);
                        }
                    });
                }
            }

        }


        /// <summary>
        /// Method nuevo
        /// </summary>
        public void nuevo()
        {
        }


        /// <summary>
        /// Method buscar
        /// </summary>
        public void buscar()
        {
        }




        /// <summary>
        /// Method validarCampos
        /// </summary>
        private bool validarCampos()
        {
            bool flag2 = false;
            String txt_formula = txtfields2.Text;



            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre los Nombres del Formula", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag2;
            }
            if (txtfields2.Text == "")
            {
                MessageBox.Show("Registre \nla formula", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag2;
            }
            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre el Teléfono del Formula", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag2;
            }

            string resp = "";
            MathProcessor process = new MathProcessor();
            String aux_formula = "";
            aux_formula = txtfields2.Text.Trim();
            aux_formula = aux_formula.Replace("(", "+");
            aux_formula = aux_formula.Replace(")", "+");
            aux_formula = aux_formula.Replace(",", "+");
            resp = process.ProcessConditionValidarFormula(aux_formula);
            if (resp.Length > 0)
            {
                MessageBox.Show(resp, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag2;
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
                            List<Formula> lstFormula = new List<Formula>();
                            Formula Formula = new Formula();
                            Formula.For_id = System.Convert.ToInt64(for_id);
                            Formula.Var_id = System.Convert.ToInt64(var_id);
                            Formula.For_codigo = System.Convert.ToString(txtfields2.Text);
                            Formula.For_nombre = System.Convert.ToString(txtfields3.Text);
                            Formula.For_valini = System.Convert.ToDecimal(txtfields4.Text);
                            Formula.For_estado = System.Convert.ToInt64(1);
                            //Aumentado Diego 10-10-2012
                            Formula.For_tipo = System.Convert.ToInt32(txtForTipo.Text);
                            //////////////////
                            lstFormula.Add(Formula);

                            // Save data from Formula
                            FormulaController objFormulaController = new FormulaController();
                            inserted = objFormulaController.edit(lstFormula);
                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            // Actualizar Variable
                            // Fill data      
                            VariableObject objVariableObject = new VariableObject();
                            List<Variable> lstVariable = new List<Variable>();
                            List<Variable> lstVariable2 = new List<Variable>();
                            lstVariable = objVariableObject.listVariable(var_id);
                            lstVariable.ForEach(delegate(Variable v)
                            {
                                Variable variable = new Variable();
                                variable.Var_id = System.Convert.ToInt64(v.Var_id);
                                variable.Var_codigo = System.Convert.ToString(v.Var_codigo);
                                variable.Var_nombre = System.Convert.ToString(v.Var_nombre);
                                variable.Var_tipo = System.Convert.ToString(v.Var_tipo);
                                variable.Var_valini = System.Convert.ToDecimal(v.Var_valini);
                                variable.Var_estado = System.Convert.ToInt64(v.Var_estado);
                                variable.Var_orden = System.Convert.ToInt64(v.Var_orden);
                                variable.Umd_id = System.Convert.ToInt64(v.Umd_id);
                                variable.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                                variable.Var_impresion = System.Convert.ToInt64(v.Var_impresion);
                                variable.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                                variable.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                                if (checkBox1.Checked == true)
                                {
                                    variable.Tpy_id = System.Convert.ToInt64(1);
                                }
                                else
                                {
                                    variable.Tpy_id = System.Convert.ToInt64(0);
                                }
                                variable.Mer_id = System.Convert.ToInt64(v.Mer_id);
                                variable.Pro_id = System.Convert.ToInt64(v.Pro_id);
                                variable.Var_codigod = System.Convert.ToString(v.Var_codigod);
                                variable.Var_total = System.Convert.ToString(v.Var_total);
                                variable.Var_impresion_a = Convert.ToInt64(v.Var_impresion_a);
                                variable.Vard_id = v.Vard_id;
                                variable.Var_tipo_cal = v.Var_tipo_cal;
                                variable.Var_posicion = v.Var_posicion;
                                //Aumentado Diego 10-10-2012
                                variable.Cam_id = v.Cam_id;
                                variable.Var_m = v.Var_m;
                                variable.Var_cam = v.Var_cam;
                                variable.For_m = v.For_m;
                                ////////////////

                                lstVariable2.Add(variable);
                            });

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
                                this.Close();
                            }
                            flag = false;

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
                            List<Formula> lstFormula = new List<Formula>();
                            Formula Formula = new Formula();
                            Formula.For_id = System.Convert.ToInt64(0);
                            Formula.Var_id = System.Convert.ToInt64(var_id);
                            Formula.For_codigo = System.Convert.ToString(txtfields2.Text);
                            Formula.For_nombre = System.Convert.ToString(txtfields3.Text);
                            Formula.For_valini = System.Convert.ToDecimal(txtfields4.Text);
                            Formula.For_estado = System.Convert.ToInt64(1);
                            lstFormula.Add(Formula);

                            // Save data from Formula
                            FormulaController objFormulaController = new FormulaController();
                            inserted = objFormulaController.save(lstFormula);

                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Se registro con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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





    }
}