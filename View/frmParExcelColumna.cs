using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmParExcelColumna : Form
    {
        bool flag = false;
        public long pec_id = 0;
        public long pex_id = 0;
        List<Variable> lstVariable = new List<Variable>();
        List<Variable> lstVariableAux = new List<Variable>();
        public frmParExcelColumna()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        

        private void frmParExcelColumna_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }








        private void guardar()
        {
            int convercion = 0;
          long updated = 0;
          long inserted = 0;
            bool aux = false;
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

                            if (rbtnTrue.Checked == true)
                            {
                                aux = true;
                            }
                            else
                            {
                                aux = false;
                            }

                            

                            //actualizacion del parexcel_columna
                            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();

                            ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();

                            ParExcel_Columna parExcelColumna = new ParExcel_Columna();
                            parExcelColumna.Pec_id = pec_id;
                            parExcelColumna.Pex_id = pex_id;
                            parExcelColumna.Pec_Columna = txtNombreColumna.Text;
                            parExcelColumna.Pec_fila = Convert.ToInt64(txtPec_Fila.Text);
                            parExcelColumna.Tco_id = Convert.ToInt64(0);
                            parExcelColumna.Mer_id = Convert.ToInt64(cbxMercado.SelectedValue);
                            parExcelColumna.Umd_id = Convert.ToInt64(0);
                            parExcelColumna.Pec_iva = aux;
                            parExcelColumna.Pec_Estado = 1;
                            parExcelColumna.Var_id = var_id;
                            
                            parExcelColumna.Pec_Convercion = Convert.ToInt64(cbxConvercion.SelectedIndex);

                            lstParExcelColumna.Add(parExcelColumna);

                            updated = objParExcelColumnaController.update(lstParExcelColumna);
                            if (updated == 0)
                            {
                                MessageBox.Show("Hubo error en la actualizacion", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("Se actualizó con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
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
                            ParExcel_Columna parExceColumna = new ParExcel_Columna();
                            parExceColumna.Pec_id = 1;
                            parExceColumna.Pex_id = 0;
                            parExceColumna.Pec_Columna = "";
                            parExceColumna.Tco_id = 0;
                            parExceColumna.Pec_Estado = 1;
                            if (rbtnTrue.Checked == true)
                            {
                                aux = true;
                            }
                            else
                            {
                                aux = false;
                            }
                            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
                            ParExcel_Columna parExcelColumna = new ParExcel_Columna();
                            parExcelColumna.Pec_id = pec_id;
                            parExcelColumna.Pex_id = pex_id;
                            parExcelColumna.Pec_Columna = txtNombreColumna.Text;
                            parExcelColumna.Pec_fila = Convert.ToInt64(txtPec_Fila.Text);
                            parExcelColumna.Tco_id = Convert.ToInt64(0);
                            parExcelColumna.Mer_id = Convert.ToInt64(cbxMercado.SelectedValue);
                            parExcelColumna.Umd_id = Convert.ToInt64(0);
                            parExcelColumna.Pec_iva = aux;
                            parExcelColumna.Pec_Estado = 1;
                            parExcelColumna.Var_id = var_id;
                            
                            parExcelColumna.Pec_Convercion = Convert.ToInt64(cbxConvercion.SelectedIndex);

                            lstParExcelColumna.Add(parExcelColumna);

                            ParExcel_ColumnaController parExcelColumnaAuxController = new ParExcel_ColumnaController();

                            inserted = parExcelColumnaAuxController.save(lstParExcelColumna);
                            if (inserted == 0)
                            {
                              MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                              MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                              this.Close();
                            }
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






        private void cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblColumna, "Indicar Columna de la hoja de excel");
            toolTip1.SetToolTip(this.txtNombreColumna, "Indicar Columna de la hoja de excel");

            toolTip1.SetToolTip(this.lblCodigoPagina, "Indica el nombre de la hoja de excel");
            toolTip1.SetToolTip(this.txtCodigoHoja, "Indica el nombre de la hoja de excel");

            toolTip1.SetToolTip(this.lblTipoCosto, "Seleccione el tipo de costo");
            toolTip1.SetToolTip(this.cbxTipoCosto, "Seleccione el tipo de costo");

            toolTip1.SetToolTip(this.lblMercado, "Seleccione el mercado");
            toolTip1.SetToolTip(this.cbxConvercion, "Seleccione el mercado");

            toolTip1.SetToolTip(this.lblUnidadMedida, "Seleccione la unidad medida");
            toolTip1.SetToolTip(this.cbxUnidadMedida, "Seleccione la unidad medida");


            toolTip1.SetToolTip(this.rbtnTrue, "Seleccione true si se toma en cuenta el via");
            toolTip1.SetToolTip(this.rbtnFalse, "Seleccione false si no se toma en cuenta el via");


            if (!flag)
            {
                Session objSession = new Session();
                pex_id = objSession.ID;
                long tcl_id = 0;

                List<ParExcel> lstParExcel = new List<ParExcel>();
                ParExcelObject objParExcelObject = new ParExcelObject();
                lstParExcel = objParExcelObject.listParExcel(pex_id);
                if (lstParExcel.Count != 0)
                {
                    lstParExcel.ForEach(delegate(ParExcel u)
                    {
                        txtCodigoHoja.Text = u.Pex_codigo;
                        pex_id = u.Pex_id;
                        tcl_id = u.Tcl_id;
                    });
                }
                //cargado de tipo costo
                List<TipoColumna> lstTipoCosto = new List<TipoColumna>();
                Tipo_ColumnaObject objTipoCostoObject = new Tipo_ColumnaObject();

                lstTipoCosto = objTipoCostoObject.listTipoCosto(0);

                cbxTipoCosto.DataSource = lstTipoCosto;
                cbxTipoCosto.DisplayMember = "Tco_nombre";
                cbxTipoCosto.ValueMember = "Tco_id";


                //cargado mercado

                List<Mercado> lstMercado = new List<Mercado>();
                MercadoObject objMercadoObject = new MercadoObject();

                lstMercado = objMercadoObject.listMercado(0);

                Mercado merAux = new Mercado();
                merAux.Mer_id = 0;
                merAux.Mer_nombre = "";
                merAux.Mer_estado = 1;
                merAux.Mer_codigo = "";

                lstMercado.Insert(0, merAux);

                cbxMercado.DataSource = lstMercado;
                cbxMercado.DisplayMember = "Mer_nombre";
                cbxMercado.ValueMember = "Mer_id";

                //cargado unidad medida
                List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
                UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
                lstUnidadMedida = objUnidadMedida.listUnidadMedida(0);

                Unidad_Medida unidadMedidaBlanco = new Unidad_Medida();
                unidadMedidaBlanco.Umd_id = 0;
                unidadMedidaBlanco.Umd_nombre = "";
                unidadMedidaBlanco.Umd_estado = 0;
                unidadMedidaBlanco.Umd_codigo = "";

                lstUnidadMedida.Insert(0, unidadMedidaBlanco);
                cbxUnidadMedida.DataSource = lstUnidadMedida;
                cbxUnidadMedida.DisplayMember = "Umd_Nombre";
                cbxUnidadMedida.ValueMember = "Umd_Id";

                VariableController objVariableController = new VariableController();

                Variable objVariableBlanco = new Variable();
                objVariableBlanco.Var_id = 0;
                objVariableBlanco.Var_nombre = "";
                objVariableBlanco.Var_estado = 0;
                objVariableBlanco.Var_tipo = "";
                objVariableBlanco.Var_valini = 0;
                objVariableBlanco.Var_codigo = "";
                if (tcl_id >= 0)
                    lstVariable = objVariableController.findByTcl_id(tcl_id);
                else
                    lstVariable = objVariableController.findByTcl_id(0);
                lstVariable.Insert(0, objVariableBlanco);

                cbxVariable.DataSource = lstVariable;
                cbxVariable.DisplayMember = "Var_codigo";
                cbxVariable.ValueMember = "Var_id";
                cbxVariable.SelectedIndex = 0;


                cbxConvercion.Items.Add("Ninguno");
                cbxConvercion.Items.Add("68º F base saturada");
                cbxConvercion.Items.Add("60º F base seca");

                cbxConvercion.SelectedIndex = 0;
            }


        }



        public void buscar()
        {
            Session objSession = new Session();
            pec_id = objSession.ID;
            long var_id=0;

            long tcl_id = 0;

            List<ParExcel> lstParExcel = new List<ParExcel>();
            ParExcelObject objParExcelObject = new ParExcelObject();
            lstParExcel = objParExcelObject.listParExcel(pex_id);
            if (lstParExcel.Count != 0)
            {
                lstParExcel.ForEach(delegate(ParExcel u)
                {
                    txtCodigoHoja.Text = u.Pex_codigo;
                    pex_id = u.Pex_id;
                    tcl_id = u.Tcl_id;
                });
            }


            //cargado mercado
            List<Mercado> lstMercado = new List<Mercado>();
            //MercadoController objMercadoObject = new MercadoController();
            lstMercado  = MercadoController.GetListMercados(0);
            Mercado merAux = new Mercado();
            merAux.Mer_id = 0;
            merAux.Mer_nombre = "";
            merAux.Mer_estado = 1;
            merAux.Mer_codigo = "";
            lstMercado.Insert(0, merAux);
            cbxMercado.DataSource = lstMercado;
            cbxMercado.DisplayMember = "Mer_nombre";
            cbxMercado.ValueMember = "Mer_id";


            cbxConvercion.Items.Add("Ninguno");
            cbxConvercion.Items.Add("68º F base saturada");
            cbxConvercion.Items.Add("60º F base seca");


            VariableController objVariableController = new VariableController();


            Variable objVariableBlanco = new Variable();
            objVariableBlanco.Var_id = 0;
            objVariableBlanco.Var_nombre = "";
            objVariableBlanco.Var_estado = 0;
            objVariableBlanco.Var_tipo = "";
            objVariableBlanco.Var_valini = 0;
            objVariableBlanco.Var_codigo = "";
            if (tcl_id > 0)
                lstVariable = objVariableController.findByTcl_id(tcl_id);
            else
                lstVariable = objVariableController.findByTcl_id(0);
            lstVariable.Insert(0, objVariableBlanco);


            cbxVariable.DataSource = lstVariable;
            cbxVariable.DisplayMember = "Var_codigo";
            cbxVariable.ValueMember = "Var_id";
            //cbxVariable.SelectedIndex = 0;

            Session session = new Session();
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();
            session.ID = pec_id;
            lstParExcelColumna = objParExcelColumnaController.find();
            if (lstParExcelColumna.Count != 0)
            {
                lstParExcelColumna.ForEach(delegate(ParExcel_Columna u)
                {
                    txtNombreColumna.Text = u.Pec_Columna;
                    txtCodigoHoja.Text = u.Pex_codigo;
                    pex_id = u.Pex_id;
                    var_id = u.Var_id;
                    cbxMercado.SelectedValue = u.Mer_id;
                    cbxUnidadMedida.SelectedValue = u.Umd_id;
                    cbxTipoCosto.SelectedValue = u.Tco_id;
                    txtPec_Fila.Text = u.Pec_fila.ToString();
                    //var_id = u.Var_id;
                    if(u.Var_nombre != null)
                        cbxVariable.SelectedValue = Convert.ToInt64(u.Var_id);
                    if (u.Pec_iva)
                    {
                        rbtnTrue.Checked = true;
                        rbtnFalse.Checked = false;
                    }
                    else
                    {
                        rbtnTrue.Checked = false;
                        rbtnFalse.Checked = true;
                    }

                    cbxConvercion.SelectedIndex = Convert.ToInt32(u.Pec_Convercion);
                });

                //List<ParExcel> lstParExcel = new List<ParExcel>();
                //ParExcelObject objParExcelObject = new ParExcelObject();
                lstParExcel = objParExcelObject.listParExcel(pex_id);

                //VariableController objVariableController = new VariableController();

                objVariableBlanco = new Variable();
                objVariableBlanco.Var_id = 0;
                objVariableBlanco.Var_nombre = "";
                objVariableBlanco.Var_estado = 0;
                objVariableBlanco.Var_tipo = "";
                objVariableBlanco.Var_valini = 0;
                objVariableBlanco.Var_codigo = "";
                if (lstParExcel[0].Tcl_id >= 0)
                    lstVariable = objVariableController.findByTcl_id(lstParExcel[0].Tcl_id);
                else
                    lstVariable = objVariableController.findByTcl_id(0);
                lstVariable.Insert(0, objVariableBlanco);
                cbxVariable.DataSource = lstVariable;
                cbxVariable.DisplayMember = "Var_codigo";
                cbxVariable.ValueMember = "Var_id";



                if (var_id == 0)
                {
                    cbxVariable.SelectedIndex = 0;
                    lblNombreColumna.Text = "";
                }
                else
                {
                    lstVariableAux = objVariableController.list(var_id);
                    lblNombreColumna.Text = lstVariableAux[0].Var_descripcion;
                    cbxVariable.SelectedValue = Convert.ToInt64(var_id);
                }


                flag = true;
            }
            
            
        }

        private bool validarCampos()
        {
            bool flag2 = false;
            if (txtNombreColumna.Text == "")
            {
                MessageBox.Show("Registre el nombre de la columna del excel", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreColumna.Focus();
                return flag2;
            }
            if (txtCodigoHoja.Text == "")
            {
                //MessageBox.Show("Registre la hoja de la Parametrica del excel", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoHoja.Focus();
                return flag2;
            }
            


            if (flag != true)
            {
                EmpresaObject objEmpresaObject = new EmpresaObject();
                pec_id = objEmpresaObject.generateIdEmpresa();
            }

            flag2 = true;
            return flag2;
        }

        private void txtNombreHoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNombreColumna_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxTipoCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxTipoCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        long var_id;
        private void cbxVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            long Var_id1 = 0;
            if (cbxVariable.SelectedIndex != 0)
            {
                Var_id1 = Convert.ToInt64(cbxVariable.SelectedValue);
                VariableController objVariableController = new VariableController();
                lstVariableAux = objVariableController.list(Var_id1);
            }
            int index = cbxVariable.SelectedIndex;
            
            if (this.lstVariableAux.Count != 0)
                this.lblNombreColumna.Text = lstVariableAux[0].Var_descripcion;
            else
                this.lblNombreColumna.Text = "";
            if (index >= 0)
            {
                if (lstVariable.Count >= 0)
                {
                    var_id = lstVariable[index].Var_id;
                }
            }
        }

        private void cbxMerecado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxMerecado.Text == "MERCADO INTERNO")
            //{
            //    rbtnTrue.Visible = true;
            //    rbtnFalse.Visible = true;
            //}
            //else
            //{
            //    rbtnFalse.Visible = false;
            //    rbtnTrue.Visible = false;
            //}
        }

        private void cbxMerecado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPec_Fila_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbxVariable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
