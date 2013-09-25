// Formato de números
// String.Format("{0:0,0.0000}", System.Convert.ToDouble(process.ProcessCondition(sFormula)));

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibFormula;
using Model;
using ypfbApplication.Controller;
using Controller;

namespace View
{
    public partial class frmCalculoManual : Form
    {

        Session objSession = new Session();
        long cal_id;
        long ctt_id;
        long tcl_id;
        long ani_id;
        long mes_id;
        long var_id;
        long cam_id;
        long ctt_produccion;

        int count = 0;
        bool flag;
        bool flagajustado = false;
        bool flasACuenta = false;

        // qbt
        decimal mpcdia = 0;
        decimal bbldia = 0;
        decimal simpta = 0;
        decimal simpt = 0;
        decimal indiceb = 0;
        decimal preT = 0;
        long tabla = 0;
        decimal qbt = 0;
        //
        decimal vrprpi = 0;
        decimal ibtvalue = 0;
        string ibt = "";
        // Result
        decimal result = 0;

        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };

        List<Contrato> lstContrato = new List<Contrato>();
        private MathProcessor process = new MathProcessor();

        /// <summary>
        /// Method frmCalculoManual
        /// </summary>
        public frmCalculoManual()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmCalculoManual_Load
        /// </summary>
        private void frmCalculoManual_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /// <summary>
        /// Method lstCalculos_SelectedIndexChanged
        /// </summary>
        private void lstCalculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sTmp = lstCalculos.Text;
            List<Variable> lstVariable = new List<Variable>();
            if (sTmp.Length > 0)
            {
                int i = sTmp.IndexOf("=");
                if (i <= -1)
                {
                }
                else
                {
                    txtName.Text = sTmp.Substring(0, i - 1).Trim();
                    txtValue.Text = sTmp.Substring(i + 1).Trim();
                    VariableObject objVariableObject = new VariableObject();
                    lstVariable = objVariableObject.listVariablePorCodigo(txtName.Text);
                    lstVariable.ForEach(delegate(Variable v)
                    {
                        txtDescripcionVariable.Text = v.Var_descripcion;
                    });

                }
            }
        }

        /// <summary>
        /// Method lstFormulas_SelectedIndexChanged
        /// </summary>
        private void lstFormulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sFormula = lstFormulas.Text;
            cbTest.Text = lstFormulas.Text;
            if (sFormula.Length > 0)
            {
                int k = sFormula.IndexOf("=");
                if (k <= -1)
                {
                }
                else
                {
                    sFormula = sFormula.Substring(k + 1).Trim();
                }
            }

            if (sFormula.Length > 0)
            {
                List<Formula> lstFormula = new List<Formula>();
                FormulaObject objFormulaObject = new FormulaObject();
                lstFormula = objFormulaObject.listFormulaPorCodigoAndCam_id(sFormula, cam_id);
                lstFormula.ForEach(delegate(Formula f)
                {
                    txtFormulaDescripcion.Text = f.For_nombre;

                    //
                    // Aumentado solo para pruebas
                    //
                    calcular();

                });
            }
        }


        /// <summary>
        /// Method lstCampos_SelectedIndexChanged
        /// </summary>
        private void lstCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sCampo = lstCampos.Text;
            cam_id = CampoController.SerchCampoByName(sCampo).Cam_id;
            if (sCampo.Length > 0)
            {

                if (flag == true)
                {

                    switch (System.Convert.ToInt64(cbofields1.SelectedValue))
                    {
                        // Recálculo
                        case 1:
                            if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                            {
                                // Procesar por Campo
                                BuscarDatosTotales();
                            }
                            break;

                        // A cuenta
                        case 2:
                            if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                            {
                                buscar();
                            }
                            break;

                    }

                }
            }
        }







        /// <summary>
        /// Method cbofields2_SelectedIndexChanged
        /// </summary>
        private void cbofields2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbofields2.SelectedIndex;
            lblCtt_nombre.Text = lstContrato[index].Ctt_codigo;
            var var_ctt_id = cbofields2.SelectedValue;
            //ctt_id = (long)var_ctt_id;
            //ctt_id = ContratoController.FindContratoByCtt_Name(lstContrato[index].Ctt_nombre)[0].Ctt_id;
            // Cargar Campos
            List<Campo> lstCampo = new List<Campo>();
            lstCampo = CampoController.GetListCamposContrato(lstContrato[index].Ctt_id);

            if (lstCampo.Count == 0)
            {
                lstCampos.Items.Clear();
            }
            else
            {
                lstCampos.Items.Clear();
                lstCampo.ForEach(delegate(Campo c)
                {
                    lstCampos.Items.Add(c.Cam_nombre);
                });
                flag = true;
            }
            if (lstCampos.Items.Count > 0)
            {
                lstCampos.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Method ChangeOnList
        /// </summary>
        private void ChangeOnList(string sName, string sValue)
        {
            int i, j;
            string sVariable;

            for (i = 0; i <= lstCalculos.Items.Count - 1; i++)
            {
                sVariable = lstCalculos.Items[i].ToString();
                j = sVariable.IndexOf("=");
                if (j <= 1)
                {
                }
                else
                {
                    if (sName.Trim() == sVariable.Substring(0, j - 1))
                    {
                        lstCalculos.Items[i] = sName + " = " + sValue;
                        break;
                    }
                }
            }

            if (i == lstCalculos.Items.Count)
                lstCalculos.Items.Add(sName + " = " + sValue);

            lstCalculos.Refresh();
        }

        /// <summary>
        /// Method cmdCalcular_Click
        /// </summary>
        private void cmdCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }

        /// <summary>
        /// Method cmdAddVar_Click
        /// </summary>
        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            //if (Opciones1.Checked == true)
            ChangeOnList(txtName.Text, txtValue.Text);
        }

        /// <summary>
        /// Method cmdEscoger_Click
        /// </summary>
        private void cmdEscoger_Click(object sender, EventArgs e)
        {
            switch (System.Convert.ToInt64(cbofields1.SelectedValue))
            {
                // Recálculo
                case 1:
                    // Procesar por Campo
                    buscarDatos();
                    break;

                // A cuenta
                case 2:
                    buscar();
                    break;

            }
        }

        /// <summary>
        /// Method cmdGuardar_Click
        /// </summary>
        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        /// <summary>
        /// Method cmdProcesar_Click
        /// </summary>
        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            switch (System.Convert.ToInt64(cbofields1.SelectedValue))
            {
                // Recálculo
                case 1:
                    // Procesar por Campo              
                    procesar();
                    break;

                // A cuenta
                case 2:
                    procesarACuentaUltimo();
                    break;
            }

        }

        /// <summary>
        /// Method cmdImprimir_Click
        /// </summary>
        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.Print();
            }
            catch { }
        }

        /// <summary>
        /// Method cmdCancelar_Click_1
        /// </summary>
        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method printDocument1_PrintPage
        /// </summary>
        private void printDocument1_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
            string sVariable = "";
            string sValor = "";
            string sDescripcion = "";

            // Procesar Lista
            for (int i = 0; i <= lstCalculos.Items.Count - 1; i++)
            {
                sVariable = lstCalculos.Items[i].ToString();
                if (sVariable.Length > 0)
                {
                    int j = sVariable.IndexOf("=");
                    if (j <= -1)
                    {
                    }
                    else
                    {
                        sValor = sVariable.Substring(j + 1).Trim();
                        sVariable = sVariable.Substring(0, j - 1).Trim();
                        List<Variable> lstVariable = new List<Variable>();
                        VariableObject objVariableObject = new VariableObject();
                        lstVariable = objVariableObject.listVariablePorCodigo(sVariable);
                        lstVariable.ForEach(delegate(Variable v)
                        {
                            sDescripcion = System.Convert.ToString(v.Var_codigo);
                            //e.Graphics.DrawString(sVariable + ";" + sDescripcion + " = " + sValor + "\n", new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
                            e.Graphics.DrawString(sDescripcion + "= " + sValor, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
                        });
                    }
                }
            }
        }














        /// Controller
        /// <summary>
        /// Method cargar
        /// </summary>
        private void cargar()
        {
            try
            {
                Session objSession = new Session();
                this.Text = this.Text + " - " + objSession.SISTEMA;  
                ToolTip toolTip1 = new ToolTip();
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipTitle = "Ayuda";
                toolTip1.UseFading = true;
                toolTip1.UseAnimation = true;

                toolTip1.SetToolTip(this.cbofields1, "Escoger el contrato");
                toolTip1.SetToolTip(this.cbofields2, "Escoger el tipo de proceso cálculo");
                toolTip1.SetToolTip(this.cbxAnio, "Escoger el año");
                toolTip1.SetToolTip(this.cbxMes, "Escoger el mes");
                toolTip1.SetToolTip(this.lstCalculos, "Variables del proceso de cálculo escogido");
                toolTip1.SetToolTip(this.lstFormulas, "Fórmulas de proceso del cálculo escogido");
                toolTip1.SetToolTip(this.txtDescripcionVariable, "Descripción de la Variable");
                toolTip1.SetToolTip(this.txtFormulaDescripcion, "Descripción de la Fórmula");
                toolTip1.SetToolTip(this.cbTest, "Procesar la fórmula");

                toolTip1.SetToolTip(this.txtName, "Nombre de la Variable");
                toolTip1.SetToolTip(this.txtValue, "Nombre de la Fórmula");
                toolTip1.SetToolTip(this.lblResultado, "Resultado del proceso de cálculo de las variables");


                // Vars of Session
                ctt_id = objSession.CTT_ID;
                cal_id = objSession.CAL_ID;
                ani_id = objSession.ANI_ID;
                mes_id = objSession.MES_ID;
                tcl_id = objSession.TCL_ID;
                // Cerear variables
                objSession.CTT_ID = 0;
                objSession.ANI_ID = 0;
                objSession.MES_ID = 0;
                objSession.TCL_ID = 0;


                // Load
                lstContrato = ContratoController.GetListContratoAndUsu(0);
                cbofields2.DataSource = lstContrato;
                cbofields2.DisplayMember = "Ctt_nombre";
                cbofields2.ValueMember = "Ctt_id";
                cbofields2.Refresh();

                cbofields2.SelectedValue = ctt_id;

                List<ParExcel> lstParExcel = new List<ParExcel>();
                ParExcelController objParExcelController = new ParExcelController();
                lstParExcel = objParExcelController.load();


                // Tipo de Cálculo
                List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
                Tipo_CalculoController objTipoCalculoController = new Tipo_CalculoController();
                lstTipoCalculo = Tipo_CalculoController.GetListTipoCalculo(0);
                if (lstTipoCalculo.Count == 0)
                {
                    cbofields1.Items.Clear();
                }
                else
                {
                    cbofields1.Items.Clear();
                    cbofields1.DataSource = lstTipoCalculo;
                    cbofields1.DisplayMember = "tcl_codigo";
                    cbofields1.ValueMember = "tcl_id";
                    cbofields1.SelectedIndex = 0;
                }
                cbofields1.SelectedValue = tcl_id;
                // Meses
                foreach (string mes in MESES)
                {
                    cbxMes.Items.Add(mes);
                }
                int a = cbxMes.Items.Count;
                cbxMes.SelectedIndex = Convert.ToInt32(mes_id - 1);

                foreach (int anio in ANIOS)
                {
                    cbxAnio.Items.Add(anio);
                }
                int index = cbxAnio.FindStringExact(ani_id.ToString());
                cbxAnio.SelectedText = ani_id.ToString();
                cbxAnio.SelectedIndex = index;

                if (tcl_id == 1)
                {
                    lstCampos.Visible = true;
                    label8.Visible = true;
                    // Cargar Campos
                    List<Campo> lstCampo = new List<Campo>();
                    lstCampo = CampoController.GetListCamposContrato(ctt_id);
                    if (lstCampo.Count == 0)
                    {
                        lstCampos.Items.Clear();
                    }
                    else
                    {
                        lstCampos.Items.Clear();
                        lstCampo.ForEach(delegate(Campo c)
                        {
                            lstCampos.Items.Add(c.Cam_nombre);
                        });
                        flag = true;
                    }

                    lstCampos.SelectedIndex = 0;

                }
                else
                {
                    lstCampos.Visible = false;
                    label8.Visible = false;
                }
                buscarContrato();
                flag = true;

                //buscarDatos();
                BuscarDatosTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        /// <summary>
        /// Method buscarContrato
        /// </summary>
        public void buscarContrato()
        {
            Calculo_VariableObject objCalculo_VariableObject = new Calculo_VariableObject();

            string ctt_nombre = "";
            ContratoObject objContratoObjecto = new ContratoObject();
            List<Contrato> lstContrato = new List<Contrato>();
            lstContrato = objContratoObjecto.listContrato(ctt_id);
            lstContrato.ForEach(delegate(Contrato c)
            {
                ctt_nombre = c.Ctt_nombre;
                ctt_produccion = c.Ctt_produccion;
            });
            cbofields2.SelectedIndex = cbofields2.FindString(ctt_nombre, -1);

            cbxMes.Text = MESES[mes_id - 1];
            int index = cbxAnio.FindStringExact(ani_id.ToString());
            cbxAnio.SelectedIndex = index;

            string tcl_codigo = "";
            Tipo_CalculoObject objTipoCalculoObjecto = new Tipo_CalculoObject();
            List<Tipo_Calculo> lstTipo_Calculo = new List<Tipo_Calculo>();
            lstTipo_Calculo = objTipoCalculoObjecto.listTipoCalculo(tcl_id);
            lstTipo_Calculo.ForEach(delegate(Tipo_Calculo tc)
            {
                tcl_codigo = tc.Tcl_codigo;
            });
            cbofields1.SelectedIndex = cbofields1.FindString(tcl_codigo, -1);
            //decimal suma = 0;
            //Habilitación del boton de procesar datos.
            CalculoObject objCalcuoObject = new CalculoObject();
            bool calculo = false;
            calculo = objCalcuoObject.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            //suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id-1, ani_id);
            //if (calculo.Cal_valor != -1)
            //{
            //    cmdProcesar.Enabled = false;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}
            //else
            //{
            //    cmdProcesar.Enabled = true;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}

        }











        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscarDatos()
        {
            int aux = 0;
            //var v_ctt_id = cbofields2.SelectedValue;
            ctt_id = System.Convert.ToInt64(ctt_id);
            var v_tcl_id = cbofields1.SelectedValue;
            tcl_id = System.Convert.ToInt64(v_tcl_id);
            mes_id = cbxMes.FindString(cbxMes.Text, -1) + 1;
            ani_id = System.Convert.ToInt64(cbxAnio.Text);
            CalculoObject objCalculoObject = new CalculoObject();
            cal_id = objCalculoObject.findCalculo(ctt_id, tcl_id, ani_id, mes_id);

            lstCalculos.Refresh();

            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
            if (tcl_id != 1)
            {
                lstCalculoVariable = objCalculoVariableObject.listCalculoVariableDetalle(ctt_id, tcl_id, ani_id, mes_id, cam_id);
                aux = lstCalculoVariable.Count;
                if (lstCalculoVariable.Count == 0)
                {
                    lstCalculos.Items.Clear();
                }
                else
                {
                    if (lstCalculoVariable.Count == 0)
                    {
                        lstCalculos.Items.Clear();
                    }
                    else
                    {
                        lstCalculos.Items.Clear();
                        lstCalculos.Refresh();
                        decimal suma = objCalculoVariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                        if (suma != 0)
                        {

                            lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                            {
                                //recuperar la sumartoria de las variables glabales para preceder con el calculo.
                                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                            });
                        }
                        else
                        {
                            lstCalculoVariable.Clear();
                        }
                        flag = true;
                    }
                }

            }
            else
            {
                lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotalProcesado(ctt_id, tcl_id, ani_id, mes_id);
                aux = lstCalculoVariable.Count;
                if (lstCalculoVariable.Count == 0)
                {
                    lstCalculos.Items.Clear();
                }
                else
                {
                    if (lstCalculoVariable.Count == 0)
                    {
                        lstCalculos.Items.Clear();
                    }
                    else
                    {
                        lstCalculos.Items.Clear();
                        lstCalculos.Refresh();
                        decimal suma = objCalculoVariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                        if (suma != 0)
                        {

                            lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                            {
                                //recuperar la sumartoria de las variables glabales para preceder con el calculo.
                                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                            });
                        }
                        else
                        {
                            lstCalculoVariable.Clear();
                        }

                    }
                }
                lstCalculoVariable = objCalculoVariableObject.listCalculoVariableDetalle(ctt_id, tcl_id, ani_id, mes_id, cam_id);
                aux = lstCalculoVariable.Count;
                if (lstCalculoVariable.Count == 0)
                {
                    lstCalculos.Items.Clear();
                }
                else
                {
                    if (lstCalculoVariable.Count == 0)
                    {
                        lstCalculos.Items.Clear();
                    }
                    else
                    {
                        //lstCalculos.Items.Clear();

                        decimal suma = objCalculoVariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                        if (suma != 0)
                        {

                            lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                            {
                                //recuperar la sumartoria de las variables glabales para preceder con el calculo.
                                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                            });
                        }
                        else
                        {
                            lstCalculoVariable.Clear();
                        }
                        flag = true;
                        lstCalculos.Refresh();
                    }
                }
            }

            //List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
            //Calculo_VariableObject objCalculoVariableObject2 = new Calculo_VariableObject();
            //lstCalculoVariable2 = objCalculoVariableObject2.listCalculoVariable(ctt_id, tcl_id, ani_id, mes_id);
            //if (lstCalculoVariable.Count == 0)
            //{
            //}
            //else
            //{
            //    if (lstCalculoVariable.Count == 0)
            //    {
            //    }
            //    else
            //    {
            //        lstCalculoVariable2.ForEach(delegate(Calculo_Variable u)
            //        {
            //            if (u.Var_codigo == "Dt")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
            //            else if (u.Var_codigo == "Ot")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
            //            else if (u.Var_codigo == "At")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
            //            else if (u.Var_codigo == "ITFt")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
            //            else if (u.Var_codigo == "It")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
            //            else if (u.Var_codigo == "ITt")
            //                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);

            //        });
            //        flag = true;
            //    }
            //}


            //// Leer contrato
            //// Depreciaciones
            //// Inversiones
            //ContratoObject objContratoObject = new ContratoObject();
            //List<Contrato> lstContrato = new List<Contrato>();
            //lstContrato = objContratoObject.listContrato(ctt_id);
            //if (lstContrato.Count == 0)
            //{
            //}
            //else
            //{
            //    lstContrato.ForEach(delegate(Contrato c)
            //    {
            //        lstCalculos.Items.Add("DAo" + " = " + c.Ctt_depacu);
            //        lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
            //        lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
            //        lstCalculos.Items.Add("IAo" + " = " + c.Ctt_invacu);
            //        lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
            //        lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
            //        lstCalculos.Items.Add("LRC" + " = " + c.Ctt_lrc);
            //        //lstCalculos.Items.Add("GRt_1" + " = " + c.Ctt_depacuma);
            //    });
            //}


            //CalculoObject objCalculo = new CalculoObject();
            //Calculo calculo = new Calculo();
            //calculo = objCalculoObject.listCalculoGDT_1ByMesAndAnio(ctt_id, ani_id, mes_id - 1, tcl_id);
            //if (calculo.Cal_costrecuacu == 0)
            //{
            //    lstCalculos.Items.Add("GRt_1" + " = " + "0.00000000");
            //}
            //else
            //{
            //    lstCalculos.Items.Add("GRt_1" + " = " + calculo.Cal_costrecuacu);
            //}

            ////Habilitación del boton de procesar datos.
            //calculo = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            //if (calculo.Cal_valor != -1)
            //{
            //    cmdProcesar.Enabled = false;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}
            //else
            //{
            //    cmdProcesar.Enabled = true;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}


            // Leer regalias
            //RegaliaObject objRegaliaObject = new RegaliaObject();
            //List<Regalia> lstRegalia = new List<Regalia>();
            //lstRegalia = objRegaliaObject.listRegaliaPorContratoCampo(ctt_id, ani_id, mes_id, cam_id);
            //if (lstRegalia.Count == 0)
            //{
            //}
            //else
            //{
            //    // Sumar todas la regalías
            //    decimal crudor = 0;
            //    decimal gnr = 0;
            //    decimal glpr = 0;
            //    decimal crudoi = 0;
            //    decimal gni = 0;
            //    decimal glpi = 0;

            //    decimal crudop = 0;
            //    decimal gnp = 0;
            //    decimal glpp = 0;

            //    lstRegalia.ForEach(delegate(Regalia r)
            //    {
            //        if (r.Reg_tipo == "R")
            //        {
            //            // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
            //            crudor += r.Reg_crudome + r.Reg_crudomi;
            //            gnr += r.Reg_gasme + r.Reg_gasmi;
            //            glpr += r.Reg_glp;
            //        }

            //        // Código adicional
            //        if (r.Reg_tipo == "I")
            //        {
            //            // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
            //            crudoi += r.Reg_crudome + r.Reg_crudomi;
            //            gni += r.Reg_gasme + r.Reg_gasmi;
            //            glpi += r.Reg_glp;
            //        }

            //        if (r.Reg_tipo == "P")
            //        {
            //            // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
            //            crudop += r.Reg_crudome + r.Reg_crudomi;
            //            gnp += r.Reg_gasme + r.Reg_gasmi;
            //            glpp += r.Reg_glp;
            //        }
            //        // Código adicional

            //    });


            //    lstCalculos.Items.Add("Rtgn" + " = " + gnr);
            //    lstCalculos.Items.Add("Rtpcg" + " = " + crudor);
            //    lstCalculos.Items.Add("Rtglp" + " = " + glpr);

            //    // Código adicional
            //    lstCalculos.Items.Add("Ptgn" + " = " + gnp);
            //    lstCalculos.Items.Add("Ptpcg" + " = " + crudop);
            //    lstCalculos.Items.Add("Ptglp" + " = " + glpp);

            //    lstCalculos.Items.Add("IDHtgn" + " = " + gni);
            //    lstCalculos.Items.Add("IDHtpcg" + " = " + crudoi);
            //    lstCalculos.Items.Add("IDHtglp" + " = " + glpi);
            //}

            // Formula
            lstFormulas.Items.Clear();
            List<Formula> lstFormula = new List<Formula>();
            FormulaObject objFormulaObject = new FormulaObject();
            if (tcl_id != 1)
                lstFormula = objFormulaObject.listFormula(tcl_id);
            else
                lstFormula = objFormulaObject.listFormulaPorCodigoAndCam_idyTotales(tcl_id, cam_id);
            if (lstFormula.Count == 0)
            {
                lstFormulas.Items.Clear();
            }
            else
            {
                if (lstFormula.Count == 0)
                {
                    cbTest.Items.Clear();
                }
                else
                {
                    lstFormulas.Items.Clear();
                    lstFormula.ForEach(delegate(Formula f)
                    {
                        cbTest.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                        lstFormulas.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                    });
                    flag = true;
                }
            }


            //switch (tcl_id)
            //{
            //    case 1:
            //        // Recálculo
            //        // Leer contrato
            //        // Leer VALORES P0R DEFECTO
            //        // CONVERSIONES
            //        Conversiones objConversiones = new Conversiones();
            //        List<Conversiones> lstConversiones = new List<Conversiones>();
            //        lstConversiones = ConversionesController.GetListaConversiones(0);
            //        if (lstConversiones.Count == 0)
            //        {
            //        }
            //        else
            //        {
            //            lstConversiones.ForEach(delegate(Conversiones c)
            //            {
            //                //lstCalculos.Items.Add(c.Var_codigo + " = " + String.Format("{0:0,0.000000}", System.Convert.ToDouble(c.Con_valor)));
            //                lstCalculos.Items.Add(c.Var_codigo + " = " + c.Con_valor);
            //            });
            //        }
            //        // Porcentajes Comunes
            //        lstCalculos.Items.Add("PVPF" + " = " + "1");
            //        lstCalculos.Items.Add("PPijk" + " = " + "1");
            //        //lstCalculos.Items.Add("GRt_1" + " = " + "0");
            //        lstConversiones.Clear();
            //        break;


            //    case 2:
            //        // A cuenta
            //        // Porcentajes Comunes
            //        lstCalculos.Items.Add("PVPF" + " = " + "1");
            //        break;

            //    default:
            //        break;

            //}
            //lstCalculoVariable.Clear();
            //lstCalculoVariable2.Clear();
            //lstContrato.Clear();
            //lstFormula.Clear();
            //lstRegalia.Clear();

        }



        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscarVariablesFormulasCampo()
        {
            string sCampo;
            var v_ctt_id = cbofields2.SelectedValue;
            ctt_id = System.Convert.ToInt64(v_ctt_id);
            var v_tcl_id = cbofields1.SelectedValue;
            tcl_id = System.Convert.ToInt64(v_tcl_id);
            mes_id = cbxMes.FindString(cbxMes.Text, -1) + 1;
            ani_id = System.Convert.ToInt64(cbxAnio.Text);
            CalculoObject objCalculoObject = new CalculoObject();
            //cal_id = objCalculoObject.findCalculo(ctt_id, tcl_id, ani_id, mes_id);

            cal_id = objSession.CAL_ID;
            // Recuperar Campo Id
            sCampo = System.Convert.ToString(lstCampos.SelectedItem);
            Campo campo = new Campo();
            campo = CampoController.SerchCampoByName(sCampo);
            cam_id = campo.Cam_id;



            lstCalculos.Items.Clear();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
            lstCalculoVariable = objCalculoVariableObject.listCalculoVariableDetalle(ctt_id, tcl_id, ani_id, mes_id, cam_id);
            if (lstCalculoVariable.Count == 0)
            {
                lstCalculos.Items.Clear();
            }
            else
            {
                if (lstCalculoVariable.Count == 0)
                {
                    lstCalculos.Items.Clear();
                }
                else
                {
                    lstCalculos.Items.Clear();
                    lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                    {
                        lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                    });
                    flag = true;
                }
            }


            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject2 = new Calculo_VariableObject();
            lstCalculoVariable2 = objCalculoVariableObject2.listCalculoVariable(ctt_id, tcl_id, ani_id, mes_id);
            if (lstCalculoVariable.Count == 0)
            {
            }
            else
            {
                if (lstCalculoVariable.Count == 0)
                {
                }
                else
                {
                    lstCalculoVariable2.ForEach(delegate(Calculo_Variable u)
                    {
                        if (u.Var_codigo.Equals("Dt") ||
                            u.Var_codigo.Equals("Ot") ||
                            u.Var_codigo.Equals("At") ||
                            u.Var_codigo.Equals("ITFt") ||
                            u.Var_codigo.Equals("It"))
                        {
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        }
                    });
                    flag = true;
                }
            }


            // Leer contrato
            // Depreciaciones
            // Inversiones
            ContratoObject objContratoObject = new ContratoObject();
            List<Contrato> lstContrato = new List<Contrato>();
            lstContrato = objContratoObject.listContrato(ctt_id);
            if (lstContrato.Count == 0)
            {
            }
            else
            {
                lstContrato.ForEach(delegate(Contrato c)
                {
                    lstCalculos.Items.Add("DAo" + " = " + c.Ctt_depacu);
                    lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
                    lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
                    lstCalculos.Items.Add("IAo" + " = " + c.Ctt_invacu);
                    lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
                    //lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
                    lstCalculos.Items.Add("LRC" + " = " + c.Ctt_lrc);
                    //lstCalculos.Items.Add("GRt_1" + " = " + c.Ctt_depacuma);
                });
            }



            CalculoObject objCalculo = new CalculoObject();
            Calculo calculo = new Calculo();
            calculo = objCalculoObject.listCalculoGDT_1ByMesAndAnio(ctt_id, ani_id, mes_id - 1, tcl_id);
            if (calculo.Cal_costrecuacu == 0)
            {
                lstCalculos.Items.Add("GRt_1" + " = " + "0.00000000");
            }
            else
            {
                lstCalculos.Items.Add("GRt_1" + " = " + calculo.Cal_costrecuacu);
            }


            ////Habilitación del boton de procesar datos.
            //calculo = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            //if (calculo.Cal_valor != -1)
            //{
            //    cmdProcesar.Enabled = false;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}
            //else
            //{
            //    cmdProcesar.Enabled = true;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}


            // Leer regalias
            RegaliaObject objRegaliaObject = new RegaliaObject();
            List<Regalia> lstRegalia = new List<Regalia>();
            lstRegalia = objRegaliaObject.listRegaliaPorContratoCampo(ctt_id, ani_id, mes_id, cam_id);
            if (lstRegalia.Count == 0)
            {
            }
            else
            {
                // Sumar todas la regalías
                decimal crudor = 0;
                decimal gnr = 0;
                decimal glpr = 0;
                decimal crudoi = 0;
                decimal gni = 0;
                decimal glpi = 0;

                decimal crudop = 0;
                decimal gnp = 0;
                decimal glpp = 0;

                lstRegalia.ForEach(delegate(Regalia r)
                {
                    if (r.Reg_tipo == "R")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudor += r.Reg_crudome + r.Reg_crudomi;
                        gnr += r.Reg_gasme + r.Reg_gasmi;
                        glpr += r.Reg_glp;
                    }

                    // Código adicional
                    if (r.Reg_tipo == "I")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudoi += r.Reg_crudome + r.Reg_crudomi;
                        gni += r.Reg_gasme + r.Reg_gasmi;
                        glpi += r.Reg_glp;
                    }

                    if (r.Reg_tipo == "P")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudop += r.Reg_crudome + r.Reg_crudomi;
                        gnp += r.Reg_gasme + r.Reg_gasmi;
                        glpp += r.Reg_glp;
                    }
                    // Código adicional

                });


                lstCalculos.Items.Add("Rtgn" + " = " + gnr);
                lstCalculos.Items.Add("Rtpcg" + " = " + crudor);
                lstCalculos.Items.Add("Rtglp" + " = " + glpr);

                // Código adicional
                lstCalculos.Items.Add("Ptgn" + " = " + gnp);
                lstCalculos.Items.Add("Ptpcg" + " = " + crudop);
                lstCalculos.Items.Add("Ptglp" + " = " + glpp);

                lstCalculos.Items.Add("IDHtgn" + " = " + gni);
                lstCalculos.Items.Add("IDHtpcg" + " = " + crudoi);
                lstCalculos.Items.Add("IDHtglp" + " = " + glpi);
            }

            // Formula
            lstFormulas.Items.Clear();
            List<Formula> lstFormula = new List<Formula>();
            FormulaObject objFormulaObject = new FormulaObject();
            lstFormula = objFormulaObject.listFormula(tcl_id);
            if (lstFormula.Count == 0)
            {
                lstFormulas.Items.Clear();
            }
            else
            {
                if (lstFormula.Count == 0)
                {
                    cbTest.Items.Clear();
                }
                else
                {
                    lstFormulas.Items.Clear();
                    lstFormula.ForEach(delegate(Formula f)
                    {
                        cbTest.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                        lstFormulas.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                    });
                    flag = true;
                }
            }



            switch (tcl_id)
            {
                case 1:
                    // Recálculo
                    // Leer contrato
                    // Leer VALORES P0R DEFECTO
                    // CONVERSIONES
                    Conversiones objConversiones = new Conversiones();
                    List<Conversiones> lstConversiones = new List<Conversiones>();
                    lstConversiones = ConversionesController.GetListaConversiones(0);
                    if (lstConversiones.Count == 0)
                    {
                    }
                    else
                    {
                        lstConversiones.ForEach(delegate(Conversiones c)
                        {
                            //lstCalculos.Items.Add(c.Var_codigo + " = " + String.Format("{0:0,0.000000}", System.Convert.ToDouble(c.Con_valor)));
                            lstCalculos.Items.Add(c.Var_codigo + " = " + c.Con_valor);
                        });
                    }
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    lstCalculos.Items.Add("PPijk" + " = " + "1");
                    //lstCalculos.Items.Add("GRt_1" + " = " + "0");
                    break;


                case 2:
                    // A cuenta
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    break;

                default:
                    break;

            }
        }




        /// <summary>
        /// Method calcular
        /// </summary>
        private void calcular()
        {
            string sVariable = "";
            string sFormula = "";
            decimal result = 0;

            // Procesar Lista
            for (int i = 0; i <= lstCalculos.Items.Count - 1; i++)
            {
                sVariable = lstCalculos.Items[i].ToString();
                int j = sVariable.IndexOf("=");
                if (j <= -1)
                {
                }
                else
                {
                    process.NewVariable(sVariable.Substring(0, j - 1), sVariable.Substring(j + 1));
                }
            }

            // Calcular formula
            sFormula = cbTest.Text;
            if (sFormula.Length > 0)
            {
                int k = sFormula.IndexOf("=");
                if (k <= -1)
                {
                }
                else
                {
                    sVariable = sFormula.Substring(0, k).Trim();
                    sFormula = sFormula.Substring(k + 1).Trim();
                }
            }



            //
            // PROCESOS QUE NO SE CALCULAN CON FÓRMULAS
            //
            switch (sVariable)
            {
                case "D":
                    if (ani_id == 2007 && mes_id == 5)
                    {
                        decimal resultAux = Util.diasMes(ani_id, mes_id);
                        result = resultAux - 1;
                    }
                    else
                    {
                        result = Util.diasMes(ani_id, mes_id);
                    }
                    break;
                case "Bt":
                    // Almacenar Valor
                    indiceb = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    break;

                case "PFGNdia":
                    // Almacenar Valor
                    mpcdia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    break;


                case "PFHLdia":
                    // Almacenar Valor
                    bbldia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    break;

                case "qbt":
                    ContratoObject objContratoObject = new ContratoObject();
                    // Dea acuerdo al tipo de producción del hidrocarburo del Operador se debe escoger
                    // mpcdia ó bbldia
                    // Al momento solo mpcdia
                    if (ctt_produccion == 1)
                    {
                        qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, preT), 28);
                        result = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, preT), 28);
                    }
                    else if (ctt_produccion == 2)
                    {
                        qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, bbldia, indiceb, preT), 28);
                        result = decimal.Round(objContratoObject.buscarIndice(ctt_id, bbldia, indiceb, preT), 28);
                    }
                    //qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla),8);
                    //result = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla), 8);
                    sVariable = "qbt";
                    lstCalculos.Items.Add(sVariable + " = " + qbt);
                    lstCalculos.Refresh();

                    //Cálculo modificado de acuerdo a consulta de Isabel respecto a valores cero de las Tablas de Cálculo
                    if (ani_id == 2007 && mes_id <= 7)
                    {
                        sVariable = "qbt";
                        result = 0;
                    }

                    // Respecto a valores al periodo de gracia del contrato 83 contrato chaco
                    if (ani_id <= 2011 && ctt_id == 83)
                    {
                        if (ani_id == 2011 && mes_id <= 5)
                        {
                            sVariable = "qbt";
                            result = 0;
                        }
                        else
                        {
                            sVariable = "qbt";
                            result = 0;
                        }

                    }


                    if (ani_id <= 2007 && ctt_id == 75)
                    {
                        if (ani_id == 2007 && mes_id < 12)
                        {
                            sVariable = "qbt";
                            result = 0;
                        }
                        else if (ani_id == 2007 && mes_id == 12)
                        {
                            sVariable = "qbt";
                            decimal resultAux = qbt / 31;
                            resultAux = resultAux * 9;
                            result = resultAux;
                        }

                    }

                    //calculo para los demas contratos
                    if (ani_id == 2007 && mes_id == 8 && ctt_id != 83 && ctt_id != 75)
                    {
                        sVariable = "qbt";
                        result = qbt / 31;
                    }
                    break;

                default:
                    // PROCESAR CÁLCULO CON FÓRMULAS
                    //result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                    break;
            }
            if (sVariable == "PREt")
            {
                List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                lstTablaCalculo = TablaCalculoController.GetListaTablaCalculoPorContrato(ctt_id);
                if (lstTablaCalculo.Count > 1)
                {
                    preT = result;
                }
                else
                {
                    preT = 0;
                    result = 0;
                }
            }
            lblResultado.Text = Util.formatNumber(process.ProcessCondition(System.Convert.ToString(result)));
            lstCalculos.Items.Add(sVariable + " = " + result);
            lstCalculos.Refresh();
        }





        /// <summary>
        /// Method validarVariables
        /// </summary>
        private string validarVariables()
        {
            bool flagVariable = false;
            string sVariable = "";
            string sVariableAux = "";
            string sVariablesNoEncontradas = "";

            List<Variable> lstVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.findByTcl_idNoFormula(tcl_id);
            if (lstVariable.Count == 0)
            {
            }
            else
            {
                if (lstVariable.Count == 0)
                {
                }
                else
                {
                    // Validar
                    lstVariable.ForEach(delegate(Variable v)
                    {
                        for (int i = 0; i < lstCalculos.Items.Count; i++)
                        {
                            // Escoger Variable
                            sVariable = lstCalculos.Items[i].ToString();
                            if (sVariable.Length > 0)
                            {
                                int k = sVariable.IndexOf("=");
                                if (k <= -1)
                                {
                                }
                                else
                                {
                                    sVariable = sVariable.Substring(0, k).Trim();
                                    if (v.Var_codigo.Equals(sVariable))
                                    {
                                        flagVariable = true;
                                        break;
                                    }
                                    else
                                    {
                                        flagVariable = false;
                                        sVariableAux = sVariable;
                                    }
                                }
                            }
                        }

                        if (flagVariable == false)
                        {
                            sVariablesNoEncontradas += "$" + v.Var_codigo + ":" + v.Var_descripcion;
                        }
                    });
                }
            }
            return sVariablesNoEncontradas;
        }
        bool flagCalculo = false;






        /// <summary>
        /// Method procesar
        /// </summary>
        private void procesar()
        {
            Calculo_VariableObject objCalculo_VariableObject = new Calculo_VariableObject();
            string sCampo = "";
            //Habilitación del boton de procesar datos.
            CalculoObject objCalculo = new CalculoObject();
            bool flag2 = false;
            flag2 = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id - 1, tcl_id);
            decimal suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id - 1, ani_id);

            //if (flag2 = true && suma > 0)
            //{
            // Inicio
            if (validarVariables().Equals(""))
            {
            }
            else
            {
                // hourglass cursor
                Cursor.Current = Cursors.WaitCursor;
                lblProcesando.Visible = false;
                progressBar1.Visible = false;
                timer1.Enabled = true;

                int z = 0;
                try
                {
                    CalculoObject calculoObject = new CalculoObject();

                    //Calculo primero los totales para sacar el IBt total para el PPijk
                    lstCalculos.Dispose();

                    #region Asiganción de la lista lstcalculos

                    lstCalculos = new ListBox();
                    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                    this.lstCalculos.Name = "lstCalculos";
                    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                    this.lstCalculos.TabIndex = 6;
                    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                    lstCalculos.Visible = true;
                    lstCalculos.Show();
                    lstCalculos.Refresh();
                    this._Frame1_0.Controls.Add(this.lstCalculos);
                    #endregion

                    #region asignacion de la lista de formulas

                    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                    this.lstFormulas.Name = "lstFormulas";
                    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                    this.lstFormulas.TabIndex = 10;
                    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                    this._Frame1_1.Controls.Add(this.lstFormulas);


                    #endregion

                    #region limpieza del proceso por completo

                    process = new MathProcessor();

                    #endregion

                    suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id, ani_id);
                    if (suma > 0)
                    {
                        BuscarDatosTotales();
                        procesarDetalle();
                        guardarTotales();
                    }
                    suma = 0;

                    //empiezo con el proceso de los datos

                    for (z = 0; z <= lstCampos.Items.Count - 1; z++)
                    //for (z = 0; z <= 1; z++)
                    {
                        try
                        {
                            lstCalculos.Dispose();

                            #region Asiganción de la lista lstcalculos

                            lstCalculos = new ListBox();
                            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                            this.lstCalculos.Name = "lstCalculos";
                            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                            this.lstCalculos.TabIndex = 6;
                            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                            lstCalculos.Visible = true;
                            lstCalculos.Show();
                            lstCalculos.Refresh();
                            this._Frame1_0.Controls.Add(this.lstCalculos);
                            #endregion

                            #region Asignacion de la lista de formulas

                            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                            this.lstFormulas.Name = "lstFormulas";
                            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                            this.lstFormulas.TabIndex = 10;
                            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                            this._Frame1_1.Controls.Add(this.lstFormulas);


                            #endregion

                            #region limpieza del proceso por completo

                            process = new MathProcessor();

                            #endregion

                            //posicion del campo
                            lstCampos.SelectedIndex = z;
                            lstCampos.SelectionMode = SelectionMode.One;
                            lstCampos.Refresh();

                            // Recuperar Campo Id
                            sCampo = lstCampos.Items[z].ToString();
                            Campo campo = new Campo();
                            campo = CampoController.SerchCampoByName(sCampo);
                            cam_id = campo.Cam_id;

                            flagCalculo = true;

                            suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                            if (suma > 0)
                            {
                                buscarDatos();
                                procesarDetalle();
                                guardar();
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Hubo error en el procesamiento del campo: " + sCampo + ".\n" + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    #region Operacion que no sirve
                    //if (lstCampos.Items.Count > 1)
                    //{
                    //    flagCalculo = true;
                    //    // Procesar Lista
                    //    for (z = 0; z <= lstCampos.Items.Count - 1; z++)
                    //    {
                    //        lstCalculos.Dispose();

                    //        #region Asiganción de la lista lstcalculos

                    //        lstCalculos = new ListBox();
                    //        this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                    //        this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                    //        this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                    //        this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                    //        this.lstCalculos.Name = "lstCalculos";
                    //        this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //        this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //        this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                    //        this.lstCalculos.TabIndex = 6;
                    //        this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                    //        lstCalculos.Visible = true;
                    //        lstCalculos.Show();
                    //        lstCalculos.Refresh();

                    //        this._Frame1_0.Controls.Add(this.lstCalculos);


                    //        #endregion

                    //        #region asignacion de la lista de formulas

                    //        this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                    //        this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                    //        this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                    //        this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                    //        this.lstFormulas.Name = "lstFormulas";
                    //        this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //        this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //        this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                    //        this.lstFormulas.TabIndex = 10;
                    //        this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                    //        this._Frame1_1.Controls.Add(this.lstFormulas);


                    //        #endregion

                    //        #region limpieza del proceso por completo

                    //        process = new MathProcessor();

                    //        #endregion

                    //        //posicion del campo
                    //        lstCampos.SelectedIndex = z;
                    //        lstCampos.SelectionMode = SelectionMode.One;
                    //        lstCampos.Refresh();
                    //        // Recuperar Campo Id
                    //        sCampo = lstCampos.Items[z].ToString();
                    //        Campo campo = new Campo();
                    //        campo = CampoController.SerchCampoByName(sCampo);
                    //        cam_id = campo.Cam_id;

                    //        suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                    //        if (suma > 0)
                    //        {
                    //            // Procesar por campo
                    //            buscarDatos();
                    //            procesarDetalle();
                    //            guardar();
                    //        }
                    //        suma = 0;
                    //    }
                    //    #region Operacion que no sirve
                    //    //if (lstCampos.Items.Count == z)
                    //    //{
                    //    //    lstCalculos.Dispose();
                    //    //    #region Asiganción de la lista lstcalculos

                    //    //    lstCalculos = new ListBox();
                    //    //    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                    //    //    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                    //    //    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                    //    //    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                    //    //    this.lstCalculos.Name = "lstCalculos";
                    //    //    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //    //    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //    //    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                    //    //    this.lstCalculos.TabIndex = 6;
                    //    //    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                    //    //    lstCalculos.Visible = true;
                    //    //    lstCalculos.Show();
                    //    //    lstCalculos.Refresh();
                    //    //    this._Frame1_0.Controls.Add(this.lstCalculos);
                    //    //    #endregion

                    //    //    #region asignacion de la lista de formulas

                    //    //    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                    //    //    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                    //    //    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                    //    //    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                    //    //    this.lstFormulas.Name = "lstFormulas";
                    //    //    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //    //    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //    //    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                    //    //    this.lstFormulas.TabIndex = 10;
                    //    //    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                    //    //    this._Frame1_1.Controls.Add(this.lstFormulas);


                    //    //    #endregion

                    //    //    #region limpieza del proceso por completo

                    //    //    process = new MathProcessor();

                    //    //    #endregion

                    //    //    suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id, ani_id);
                    //    //    if (suma > 0)
                    //    //    {
                    //    //        BuscarDatosTotales();
                    //    //        procesarDetalle();
                    //    //        guardarTotales();
                    //    //    }
                    //    //    suma = 0;
                    //    //}

                    //    //lstCampos.SelectedIndex = 0;

                    //    #endregion
                    //}

                    //else
                    //{
                    //    lstCalculos.Dispose();
                    //    #region Asiganción de la lista lstcalculos

                    //    lstCalculos = new ListBox();
                    //    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                    //    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                    //    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                    //    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                    //    this.lstCalculos.Name = "lstCalculos";
                    //    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                    //    this.lstCalculos.TabIndex = 6;
                    //    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                    //    lstCalculos.Visible = true;
                    //    lstCalculos.Show();
                    //    lstCalculos.Refresh();
                    //    this._Frame1_0.Controls.Add(this.lstCalculos);
                    //    #endregion

                    //    #region asignacion de la lista de formulas

                    //    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                    //    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                    //    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                    //    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                    //    this.lstFormulas.Name = "lstFormulas";
                    //    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    //    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    //    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                    //    this.lstFormulas.TabIndex = 10;
                    //    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                    //    this._Frame1_1.Controls.Add(this.lstFormulas);


                    //    #endregion

                    //    #region limpieza del proceso por completo

                    //    process = new MathProcessor();

                    //    #endregion

                    //    flagCalculo = false;
                    //    suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                    //    if (suma > 0)
                    //    {
                    //        buscarDatos();
                    //        procesarDetalle();
                    //        guardar();
                    //    }
                    //}
                    #endregion
                    MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Hubo error en el procesamiento del contrato: " + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                progressBar1.Visible = false;
                lblProcesando.Visible = false;
            }
            //}
            //else if (flag2 = false && suma == 0)
            //{
            //    // Inicio
            //    if (validarVariables().Equals(""))
            //    {
            //    }
            //    else
            //    {
            //        // hourglass cursor
            //        Cursor.Current = Cursors.WaitCursor;
            //        lblProcesando.Visible = false;
            //        progressBar1.Visible = false;
            //        timer1.Enabled = true;

            //        int z = 0;
            //        try
            //        {
            //            CalculoObject calculoObject = new CalculoObject();

            //            //Calculo primero los totales para sacar el IBt total para el PPijk
            //            lstCalculos.Dispose();

            //            #region Asiganción de la lista lstcalculos

            //            lstCalculos = new ListBox();
            //            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            //            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            //            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            //            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            //            this.lstCalculos.Name = "lstCalculos";
            //            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            //            this.lstCalculos.TabIndex = 6;
            //            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            //            lstCalculos.Visible = true;
            //            lstCalculos.Show();
            //            lstCalculos.Refresh();
            //            this._Frame1_0.Controls.Add(this.lstCalculos);
            //            #endregion

            //            #region asignacion de la lista de formulas

            //            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            //            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            //            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            //            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            //            this.lstFormulas.Name = "lstFormulas";
            //            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            //            this.lstFormulas.TabIndex = 10;
            //            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


            //            this._Frame1_1.Controls.Add(this.lstFormulas);


            //            #endregion

            //            #region limpieza del proceso por completo

            //            process = new MathProcessor();

            //            #endregion

            //            suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id, ani_id);
            //            if (suma > 0)
            //            {
            //                BuscarDatosTotales();
            //                procesarDetalle();
            //                guardarTotales();
            //            }
            //            suma = 0;

            //            //empiezo con el proceso de los datos

            //            for (z = 0; z <= lstCampos.Items.Count - 1; z++)
            //            //for (z = 0; z <= 1; z++)
            //            {
            //                lstCalculos.Dispose();

            //                #region Asiganción de la lista lstcalculos

            //                lstCalculos = new ListBox();
            //                this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            //                this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            //                this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            //                this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            //                this.lstCalculos.Name = "lstCalculos";
            //                this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //                this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //                this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            //                this.lstCalculos.TabIndex = 6;
            //                this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            //                lstCalculos.Visible = true;
            //                lstCalculos.Show();
            //                lstCalculos.Refresh();
            //                this._Frame1_0.Controls.Add(this.lstCalculos);
            //                #endregion

            //                #region asignacion de la lista de formulas

            //                this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            //                this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            //                this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            //                this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            //                this.lstFormulas.Name = "lstFormulas";
            //                this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //                this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //                this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            //                this.lstFormulas.TabIndex = 10;
            //                this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


            //                this._Frame1_1.Controls.Add(this.lstFormulas);


            //                #endregion

            //                #region limpieza del proceso por completo

            //                process = new MathProcessor();

            //                #endregion
            //                //posicion del campo
            //                lstCampos.SelectedIndex = z;
            //                lstCampos.SelectionMode = SelectionMode.One;
            //                lstCampos.Refresh();

            //                // Recuperar Campo Id
            //                sCampo = lstCampos.Items[z].ToString();
            //                Campo campo = new Campo();
            //                campo = CampoController.SerchCampoByName(sCampo);
            //                cam_id = campo.Cam_id;

            //                flagCalculo = true;

            //                suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
            //                if (suma > 0)
            //                {
            //                    buscarDatos();
            //                    procesarDetalle();
            //                    guardar();
            //                }

            //            }
            //            #region Operacion que no sirve
            //            //if (lstCampos.Items.Count > 1)
            //            //{
            //            //    flagCalculo = true;
            //            //    // Procesar Lista
            //            //    for (z = 0; z <= lstCampos.Items.Count - 1; z++)
            //            //    {
            //            //        lstCalculos.Dispose();

            //            //        #region Asiganción de la lista lstcalculos

            //            //        lstCalculos = new ListBox();
            //            //        this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            //            //        this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            //            //        this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //        this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            //            //        this.lstCalculos.Name = "lstCalculos";
            //            //        this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //        this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //        this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            //            //        this.lstCalculos.TabIndex = 6;
            //            //        this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            //            //        lstCalculos.Visible = true;
            //            //        lstCalculos.Show();
            //            //        lstCalculos.Refresh();

            //            //        this._Frame1_0.Controls.Add(this.lstCalculos);


            //            //        #endregion

            //            //        #region asignacion de la lista de formulas

            //            //        this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            //            //        this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            //            //        this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //        this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            //            //        this.lstFormulas.Name = "lstFormulas";
            //            //        this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //        this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //        this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            //            //        this.lstFormulas.TabIndex = 10;
            //            //        this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


            //            //        this._Frame1_1.Controls.Add(this.lstFormulas);


            //            //        #endregion

            //            //        #region limpieza del proceso por completo

            //            //        process = new MathProcessor();

            //            //        #endregion

            //            //        //posicion del campo
            //            //        lstCampos.SelectedIndex = z;
            //            //        lstCampos.SelectionMode = SelectionMode.One;
            //            //        lstCampos.Refresh();
            //            //        // Recuperar Campo Id
            //            //        sCampo = lstCampos.Items[z].ToString();
            //            //        Campo campo = new Campo();
            //            //        campo = CampoController.SerchCampoByName(sCampo);
            //            //        cam_id = campo.Cam_id;

            //            //        suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
            //            //        if (suma > 0)
            //            //        {
            //            //            // Procesar por campo
            //            //            buscarDatos();
            //            //            procesarDetalle();
            //            //            guardar();
            //            //        }
            //            //        suma = 0;
            //            //    }
            //            //    #region Operacion que no sirve
            //            //    //if (lstCampos.Items.Count == z)
            //            //    //{
            //            //    //    lstCalculos.Dispose();
            //            //    //    #region Asiganción de la lista lstcalculos

            //            //    //    lstCalculos = new ListBox();
            //            //    //    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            //            //    //    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            //            //    //    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //    //    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            //            //    //    this.lstCalculos.Name = "lstCalculos";
            //            //    //    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //    //    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //    //    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            //            //    //    this.lstCalculos.TabIndex = 6;
            //            //    //    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            //            //    //    lstCalculos.Visible = true;
            //            //    //    lstCalculos.Show();
            //            //    //    lstCalculos.Refresh();
            //            //    //    this._Frame1_0.Controls.Add(this.lstCalculos);
            //            //    //    #endregion

            //            //    //    #region asignacion de la lista de formulas

            //            //    //    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            //            //    //    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            //            //    //    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //    //    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            //            //    //    this.lstFormulas.Name = "lstFormulas";
            //            //    //    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //    //    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //    //    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            //            //    //    this.lstFormulas.TabIndex = 10;
            //            //    //    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


            //            //    //    this._Frame1_1.Controls.Add(this.lstFormulas);


            //            //    //    #endregion

            //            //    //    #region limpieza del proceso por completo

            //            //    //    process = new MathProcessor();

            //            //    //    #endregion

            //            //    //    suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, 0, mes_id, ani_id);
            //            //    //    if (suma > 0)
            //            //    //    {
            //            //    //        BuscarDatosTotales();
            //            //    //        procesarDetalle();
            //            //    //        guardarTotales();
            //            //    //    }
            //            //    //    suma = 0;
            //            //    //}

            //            //    //lstCampos.SelectedIndex = 0;

            //            //    #endregion
            //            //}

            //            //else
            //            //{
            //            //    lstCalculos.Dispose();
            //            //    #region Asiganción de la lista lstcalculos

            //            //    lstCalculos = new ListBox();
            //            //    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            //            //    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            //            //    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            //            //    this.lstCalculos.Name = "lstCalculos";
            //            //    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            //            //    this.lstCalculos.TabIndex = 6;
            //            //    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            //            //    lstCalculos.Visible = true;
            //            //    lstCalculos.Show();
            //            //    lstCalculos.Refresh();
            //            //    this._Frame1_0.Controls.Add(this.lstCalculos);
            //            //    #endregion

            //            //    #region asignacion de la lista de formulas

            //            //    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            //            //    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            //            //    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            //            //    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            //            //    this.lstFormulas.Name = "lstFormulas";
            //            //    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            //            //    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //            //    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            //            //    this.lstFormulas.TabIndex = 10;
            //            //    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


            //            //    this._Frame1_1.Controls.Add(this.lstFormulas);


            //            //    #endregion

            //            //    #region limpieza del proceso por completo

            //            //    process = new MathProcessor();

            //            //    #endregion

            //            //    flagCalculo = false;
            //            //    suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
            //            //    if (suma > 0)
            //            //    {
            //            //        buscarDatos();
            //            //        procesarDetalle();
            //            //        guardar();
            //            //    }
            //            //}
            //            #endregion
            //            MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //        catch (Exception e)
            //        {
            //            MessageBox.Show("Hubo error en el procesamiento del campo: " + sCampo + ". \n" + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }

            //        progressBar1.Visible = false;
            //        lblProcesando.Visible = false;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Debe procesar primero los meses anteriores por favor", "validacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }




        private void BuscarDatosTotales()
        {


            int aux = 0;
            var v_ctt_id = cbofields2.SelectedValue;
            ctt_id = System.Convert.ToInt64(v_ctt_id);
            var v_tcl_id = cbofields1.SelectedValue;
            tcl_id = System.Convert.ToInt64(v_tcl_id);
            mes_id = cbxMes.FindString(cbxMes.Text, -1) + 1;
            ani_id = System.Convert.ToInt64(cbxAnio.Text);
            decimal ctt_costrecuacu = 0;




            CalculoObject objCalculoObject = new CalculoObject();
            //cal_id = objCalculoObject.findCalculo(ctt_id, tcl_id, ani_id, mes_id);
            cal_id = objSession.CAL_ID;
            lstCalculos.Refresh();

            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
            lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotal(ctt_id, tcl_id, ani_id, mes_id);
            aux = lstCalculoVariable.Count;
            if (lstCalculoVariable.Count == 0)
            {
                lstCalculos.Items.Clear();
            }
            else
            {
                if (lstCalculoVariable.Count == 0)
                {
                    lstCalculos.Items.Clear();
                }
                else
                {
                    lstCalculos.Items.Clear();
                    lstCalculos.Refresh();
                    lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                    {
                        if ((u.Var_codigo == "qbt" && tcl_id == 2) || u.Var_codigo == "PPijk" && tcl_id == 2)
                        {
                            if (u.Cav_valor > 1)
                                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor / 100);
                            else
                                lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        }
                        else
                            //recuperar la sumartoria de las variables glabales para preceder con el calculo.
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                    });
                    flag = true;
                }
            }


            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject2 = new Calculo_VariableObject();
            lstCalculoVariable2 = objCalculoVariableObject2.listCalculoVariable(ctt_id, tcl_id, ani_id, mes_id);
            if (lstCalculoVariable.Count == 0)
            {
            }
            else
            {
                if (lstCalculoVariable.Count == 0)
                {
                }
                else
                {
                    lstCalculoVariable2.ForEach(delegate(Calculo_Variable u)
                    {
                        if (u.Var_codigo == "Dt")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        else if (u.Var_codigo == "Ot")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        else if (u.Var_codigo == "At")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        else if (u.Var_codigo == "ITFt")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        else if (u.Var_codigo == "It")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        else if (u.Var_codigo == "ITt")
                            lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                        //else if (u.Var_codigo == "qbt" && tcl_id == 2)
                        //    lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor / 100);

                    });
                    flag = true;
                }
            }

            CalculoObject objCalculo = new CalculoObject();
            Calculo calculo = new Calculo();
            // Leer contrato
            // Depreciaciones
            // Inversiones
            if (tcl_id != 2)
            {
                ContratoObject objContratoObject = new ContratoObject();
                List<Contrato> lstContrato = new List<Contrato>();
                lstContrato = objContratoObject.listContrato(ctt_id);
                if (lstContrato.Count == 0)
                {
                }
                else
                {
                    lstContrato.ForEach(delegate(Contrato c)
                    {
                        lstCalculos.Items.Add("DAot" + " = " + c.Ctt_depacu);
                        lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
                        lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
                        lstCalculos.Items.Add("IAot" + " = " + c.Ctt_invacu);
                        lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
                        lstCalculos.Items.Add("LRCt" + " = " + c.Ctt_lrc);
                        lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
                        //lstCalculos.Items.Add("GRt_1" + " = " + c.Ctt_costrecuacu);
                        ctt_costrecuacu = c.Ctt_costrecuacu;
                    });
                }



                calculo = objCalculoObject.listCalculoGDT_1ByMesAndAnio(ctt_id, ani_id, mes_id - 1, tcl_id);
                if (calculo.Cal_costrecuacu == 0)
                {
                    if (ctt_costrecuacu != 0)
                    {

                        lstCalculos.Items.Add("GRt_1t" + " = " + ctt_costrecuacu);
                    }
                    else
                    {
                        lstCalculos.Items.Add("GRt_1t" + " = " + "0.00000000");
                    }
                }
                else
                {
                    lstCalculos.Items.Add("GRt_1t" + " = " + calculo.Cal_costrecuacu);
                }
            }
            else
            {

                ContratoObject objContratoObject = new ContratoObject();
                List<Contrato> lstContrato = new List<Contrato>();
                lstContrato = objContratoObject.listContrato(ctt_id);
                if (lstContrato.Count == 0)
                {
                }
                else
                {
                    lstContrato.ForEach(delegate(Contrato c)
                    {
                        //lstCalculos.Items.Add("DAo" + " = " + c.Ctt_depacu);
                        //lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
                        //lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
                        //lstCalculos.Items.Add("IAo" + " = " + c.Ctt_invacu);
                        //lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
                        //lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
                        lstCalculos.Items.Add("LRCt" + " = " + c.Ctt_lrc);
                        //lstCalculos.Items.Add("GRt_1" + " = " + c.Ctt_depacuma);
                    });
                }
            }
            ////Habilitación del boton de procesar datos.
            //calculo = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            //if (calculo.Cal_valor != -1 )
            //{
            //    cmdProcesar.Enabled = false;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}
            //else
            //{
            //    cmdProcesar.Enabled = true;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}

            // Leer regalias
            RegaliaObject objRegaliaObject = new RegaliaObject();
            List<Regalia> lstRegalia = new List<Regalia>();
            lstRegalia = objRegaliaObject.listRegaliaPorContrato(ctt_id, ani_id, mes_id);
            if (lstRegalia.Count == 0)
            {
            }
            else
            {
                // Sumar todas la regalías
                decimal crudor = 0;
                decimal gnr = 0;
                decimal glpr = 0;
                decimal crudoi = 0;
                decimal gni = 0;
                decimal glpi = 0;

                decimal crudop = 0;
                decimal gnp = 0;
                decimal glpp = 0;

                lstRegalia.ForEach(delegate(Regalia r)
                {
                    if (r.Reg_tipo == "R")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudor += r.Reg_crudome + r.Reg_crudomi;
                        gnr += r.Reg_gasme + r.Reg_gasmi;
                        glpr += r.Reg_glp;
                    }

                    // Código adicional
                    if (r.Reg_tipo == "I")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudoi += r.Reg_crudome + r.Reg_crudomi;
                        gni += r.Reg_gasme + r.Reg_gasmi;
                        glpi += r.Reg_glp;
                    }

                    if (r.Reg_tipo == "P")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudop += r.Reg_crudome + r.Reg_crudomi;
                        gnp += r.Reg_gasme + r.Reg_gasmi;
                        glpp += r.Reg_glp;
                    }
                    // Código adicional

                });


                lstCalculos.Items.Add("Rtgn" + " = " + gnr);
                lstCalculos.Items.Add("Rtpcg" + " = " + crudor);
                lstCalculos.Items.Add("Rtglp" + " = " + glpr);

                // Código adicional
                lstCalculos.Items.Add("Ptgn" + " = " + gnp);
                lstCalculos.Items.Add("Ptpcg" + " = " + crudop);
                lstCalculos.Items.Add("Ptglp" + " = " + glpp);

                lstCalculos.Items.Add("IDHtgn" + " = " + gni);
                lstCalculos.Items.Add("IDHtpcg" + " = " + crudoi);
                lstCalculos.Items.Add("IDHtglp" + " = " + glpi);
            }

            // Formula
            lstFormulas.Items.Clear();
            List<Formula> lstFormula = new List<Formula>();
            FormulaObject objFormulaObject = new FormulaObject();

            lstFormula = objFormulaObject.listFormula(tcl_id);

            if (lstFormula.Count == 0)
            {
                lstFormulas.Items.Clear();
            }
            else
            {
                if (lstFormula.Count == 0)
                {
                    cbTest.Items.Clear();
                }
                else
                {
                    lstFormulas.Items.Clear();
                    lstFormula.ForEach(delegate(Formula f)
                    {
                        cbTest.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                        lstFormulas.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                    });
                    flag = true;
                }




            }


            switch (tcl_id)
            {
                case 1:
                    // Recálculo
                    // Leer contrato
                    // Leer VALORES P0R DEFECTO
                    // CONVERSIONES
                    Conversiones objConversiones = new Conversiones();
                    List<Conversiones> lstConversiones = new List<Conversiones>();
                    lstConversiones = ConversionesController.GetListaConversiones(0);
                    if (lstConversiones.Count == 0)
                    {
                    }
                    else
                    {
                        lstConversiones.ForEach(delegate(Conversiones c)
                        {
                            //lstCalculos.Items.Add(c.Var_codigo + " = " + String.Format("{0:0,0.000000}", System.Convert.ToDouble(c.Con_valor)));
                            lstCalculos.Items.Add(c.Var_codigo + " = " + c.Con_valor);
                        });
                    }
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    lstCalculos.Items.Add("PPijkt" + " = " + "1");
                    //lstCalculos.Items.Add("GRt_1" + " = " + "0");
                    lstConversiones.Clear();
                    break;


                case 2:
                    // A cuenta
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    break;

                default:
                    break;

            }
            //lstCalculoVariable.Clear();
            //lstContrato.Clear();
            //lstFormula.Clear();

        }




        /// <summary>
        /// Method procesar
        /// </summary>
        private void procesarACuentaUltimo()
        {
            Calculo_VariableObject objCalculo_VariableObject = new Calculo_VariableObject();
            //string sCampo = "";

            //Habilitación del boton de procesar datos.
            CalculoObject objCalculo = new CalculoObject();
            Calculo lstCalculo = new Calculo();
            //lstCalculo = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id - 1, tcl_id);


            // Inicio
            if (validarVariables().Equals(""))
            {
            }
            else
            {

                // hourglass cursor
                Cursor.Current = Cursors.WaitCursor;
                //lblProcesando.Visible = true;
                timer1.Enabled = true;



                try
                {
                    lstCalculos.Dispose();

                    #region Asiganción de la lista lstcalculos

                    lstCalculos = new ListBox();
                    this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                    this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                    this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                    this.lstCalculos.Name = "lstCalculos";
                    this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                    this.lstCalculos.TabIndex = 6;
                    this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                    lstCalculos.Visible = true;
                    lstCalculos.Show();
                    lstCalculos.Refresh();
                    this._Frame1_0.Controls.Add(this.lstCalculos);
                    #endregion

                    #region asignacion de la lista de formulas

                    this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                    this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                    this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                    this.lstFormulas.Name = "lstFormulas";
                    this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                    this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                    this.lstFormulas.TabIndex = 10;
                    this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                    this._Frame1_1.Controls.Add(this.lstFormulas);


                    #endregion

                    #region limpieza del proceso por completo

                    process = new MathProcessor();

                    #endregion

                    BuscarDatosTotales();
                    procesarDetalle();
                    guardarTotales();


                    #region para n campos
                    /***
                    CalculoObject calculoObject = new CalculoObject();
                    if (lstCampos.Items.Count > 1)
                    {
                        flagCalculo = true;
                        int z = 0;
                        // Procesar Lista
                        for (z = 0; z <= lstCampos.Items.Count - 1; z++)
                        {


                            decimal suma = 0;

                            lstCalculos.Dispose();
                            #region Asiganción de la lista lstcalculos

                            lstCalculos = new ListBox();
                            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                            this.lstCalculos.Name = "lstCalculos";
                            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                            this.lstCalculos.TabIndex = 6;
                            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                            lstCalculos.Visible = true;
                            lstCalculos.Show();
                            lstCalculos.Refresh();

                            this._Frame1_0.Controls.Add(this.lstCalculos);


                            #endregion

                            #region asignacion de la lista de formulas

                            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                            this.lstFormulas.Name = "lstFormulas";
                            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                            this.lstFormulas.TabIndex = 10;
                            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                            this._Frame1_1.Controls.Add(this.lstFormulas);


                            #endregion

                            #region limpieza del proceso por completo

                            process = new MathProcessor();

                            #endregion

                            lstCampos.SelectedIndex = z;
                            lstCampos.SelectionMode = SelectionMode.One;
                            lstCampos.Refresh();

                            // Recuperar Campo Id
                            sCampo = lstCampos.Items[z].ToString();
                            Campo campo = new Campo();
                            campo = CampoController.SerchCampoByName(sCampo);
                            cam_id = campo.Cam_id;

                            
                            suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                            if (suma > 0)
                            {
                                // Procesar por campo
                                buscar();
                                procesarDetalle();
                                guardar();

                            }

                        }
                        if (lstCampos.Items.Count == z)
                        {
                            lstCalculos.Dispose();
                            #region Asiganción de la lista lstcalculos

                            lstCalculos = new ListBox();
                            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                            this.lstCalculos.Name = "lstCalculos";
                            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                            this.lstCalculos.TabIndex = 6;
                            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                            lstCalculos.Visible = true;
                            lstCalculos.Show();
                            lstCalculos.Refresh();
                            this._Frame1_0.Controls.Add(this.lstCalculos);
                            #endregion

                            #region asignacion de la lista de formulas

                            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                            this.lstFormulas.Name = "lstFormulas";
                            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                            this.lstFormulas.TabIndex = 10;
                            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                            this._Frame1_1.Controls.Add(this.lstFormulas);


                            #endregion

                            #region limpieza del proceso por completo

                            process = new MathProcessor();

                            #endregion

                            BuscarDatosTotales();
                            procesarDetalle();
                            guardarTotales();

                        }
                    }
                    else
                    {
                        lstCalculos.Dispose();
                        #region Asiganción de la lista lstcalculos

                        lstCalculos = new ListBox();
                        this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                        this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                        this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                        this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                        this.lstCalculos.Name = "lstCalculos";
                        this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                        this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                        this.lstCalculos.TabIndex = 6;
                        this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                        lstCalculos.Visible = true;
                        lstCalculos.Show();
                        lstCalculos.Refresh();
                        this._Frame1_0.Controls.Add(this.lstCalculos);
                        #endregion

                        #region asignacion de la lista de formulas

                        this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                        this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                        this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                        this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                        this.lstFormulas.Name = "lstFormulas";
                        this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                        this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                        this.lstFormulas.TabIndex = 10;
                        this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                        this._Frame1_1.Controls.Add(this.lstFormulas);


                        #endregion

                        #region limpieza del proceso por completo

                        process = new MathProcessor();

                        #endregion

                        flagCalculo = false;
                        decimal suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                        if (suma > 0)
                        {
                            buscar();
                            procesarDetalle();
                            guardar();
                        }
                    }

                    MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    */
                    ///
                    #endregion

                    MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Hubo error en el procesamiento del campo. \n" + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            progressBar1.Hide();
            lblProcesando.Visible = false;
            //MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }






        /// <summary>
        /// Method procesarDetalle
        /// </summary>
        private void procesarDetalle()
        {
            string sFormula = "";
            string sVariable = "";
            decimal result = 0;
            //decimal rtsivaT = 0;


            lstCalculos.Refresh();
            lstFormulas.Refresh();

            // Procesar
            // Formulas
            for (int k = 0; k < lstFormulas.Items.Count; k++)
            {
                // Variables
                for (int i = 0; i <= lstCalculos.Items.Count - 1; i++)
                {
                    sVariable = lstCalculos.Items[i].ToString();
                    int j = sVariable.IndexOf("=");
                    if (j <= -1)
                    {
                    }
                    else
                    {
                        process.NewVariable(sVariable.Substring(0, j - 1), sVariable.Substring(j + 1));
                    }
                }
                // Obtener Variable
                sFormula = lstFormulas.Items[k].ToString();
                if (sFormula.Length > 0)
                {
                    int l = sFormula.IndexOf("=");
                    if (l <= -1)
                    {
                    }
                    else
                    {
                        sVariable = sFormula.Substring(0, l).Trim();
                        sFormula = sFormula.Substring(l + 1).Trim();
                    }
                }



                // Procesar
                // Variables que no se procesan con fórmulas
                switch (sVariable)
                {
                    // A CUENTA
                    case "VRPRPI":
                        vrprpi = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                        result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                        // Comparar con IBt
                        string sVariableAux;
                        for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                        {
                            sVariableAux = lstCalculos.Items[m].ToString();
                            if (sVariableAux.Length > 0)
                            {
                                int l = sVariableAux.IndexOf("=");
                                if (l <= -1)
                                {
                                }
                                else
                                {
                                    ibt = sVariableAux.Substring(0, l - 1).Trim();
                                    ibtvalue = decimal.Round(System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim()), 28);
                                    if (ibt.Equals("IB"))
                                    {
                                        if (vrprpi >= ibtvalue)
                                        {
                                            // No procesar ajustes
                                            //MessageBox.Show("No deben procesarse variables ajustadas", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            k = lstFormulas.Items.Count;
                                            flagajustado = false;
                                            break;
                                        }
                                        else
                                        {
                                            flagajustado = true;
                                        }
                                        if (vrprpi < 0)
                                        {
                                            flasACuenta = true;
                                        }
                                        else
                                        {
                                            flasACuenta = false;
                                        }
                                    }

                                }
                            }
                        }
                        break;

                    case "D":
                        // Procesar Lista
                        if (ani_id == 2007 && mes_id == 5)
                        {
                            decimal resulAux = Util.diasMes(ani_id, mes_id);
                            result = resulAux - 1;
                        }
                        else
                        {
                            result = Util.diasMes(ani_id, mes_id);
                        }
                        break;

                    case "Bt":
                        // Procesar Lista
                        indiceb = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        break;

                    case "PFGNdia":
                        mpcdia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        break;

                    case "PFHLdia":
                        bbldia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        break;

                    case "SIMPtA":
                        simpta = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        break;

                    case "SIMPtP":
                        if (simpta > 0)
                        {
                            simpt = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                            result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                        }
                        else
                        {
                            simpt = 0;
                            result = 0;
                        }
                        break;

                    case "qbt":
                        ContratoObject objContratoObject = new ContratoObject();
                        // Dea acuerdo al tipo de producción del hidrocarburo del Operador se debe escoger
                        // mpcdia ó bbldia
                        // Al momento solo mpcdia
                        if (ctt_produccion == 1)
                        {
                            qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, preT), 28);
                            // = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, preT), 28);
                            result = qbt;
                        }
                        else if (ctt_produccion == 2)
                        {
                            qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, bbldia, indiceb, preT), 28);
                            //result = decimal.Round(objContratoObject.buscarIndice(ctt_id, bbldia, indiceb, preT), 28);
                            result = qbt;
                        }
                        sVariable = "qbt";
                        lstCalculos.Items.Add(sVariable + " = " + qbt);
                        lstCalculos.Refresh();

                        // Cálculo modificado de acuerdo a consulta de Isabel 
                        // respecto a la aplicación de la participación de ypfb
                        //if (ani_id == 2007 && mes_id <= 7)
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}

                        // Respecto a valores al periodo de gracia del contrato 83 contrato chaco
                        //Saca condiciones de tiempo de gracia por contrato
                        //indiceb = 1;

                        decimal _condicion = ContratoCondicionTiempoGracia(ctt_id);

                        if (_condicion == -2)
                        {
                            if (ani_id == 2007 && mes_id == 8)
                            {
                                sVariable = "qbt";
                                result = qbt / 31;
                            }
                            else if (ani_id == 2007 && mes_id < 8)
                            {
                                sVariable = "qbt";
                                result = 0;
                            }


                        }
                        else if (_condicion != -1)
                        {
                            sVariable = "qbt";
                            result = _condicion;
                        }

                        else
                        {
                            sVariable = "qbt";
                            result = qbt;
                        }

                        //ContratoMarginalObject objContrato_MarginalObject = new ContratoMarginalObject();
                        //if (objContrato_MarginalObject.listContratoMarginalByIdAndDate(ctt_id,mes_id,ani_id))
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}
                        if (rbttnSiEs.Checked == true)
                        {
                            sVariable = "qbt";
                            result = 0;
                        }


                        ///////////////comentado tiempode gracia 02-10-2012
                        //if (ani_id <= 2012 && ctt_id == 83)
                        //{
                        //    if (ani_id == 2012 && mes_id <= 5)
                        //    {
                        //        sVariable = "qbt";
                        //        result = 0;
                        //    }
                        //    else
                        //    {
                        //        sVariable = "qbt";
                        //        decimal resultAux = qbt / 31;
                        //        resultAux = resultAux * 29;
                        //        result = resultAux;
                        //    }

                        //}

                        //if (ani_id <= 2007 && ctt_id == 75)
                        //{
                        //    if (ani_id == 2007 && mes_id < 12)
                        //    {
                        //        sVariable = "qbt";
                        //        result = 0;
                        //    }
                        //    else if (ani_id == 2007 && mes_id == 12)
                        //    {
                        //        sVariable = "qbt";
                        //        decimal resultAux = qbt / 31;
                        //        resultAux = resultAux * 9;
                        //        result = resultAux;
                        //    }


                        //}
                        ////////////////////////////////


                        // Respecto a valores al periodo de gracia del contrato Bloque xx tarija oeste
                        //if (indiceb >= 1 && ctt_id == 92)
                        //{
                        //    sVariable = "qbt";
                        //    result = qbt;
                        //}
                        //estas condiciones se reemplazan con la funcion de tiempo de gracia generica linea 2961
                        //else if (ctt_id == 92 && mes_id >= 2 && ani_id == 2011)
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}
                        //else if (ctt_id == 92 && ani_id == 2012)
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}
                        //else if (ctt_id == 92 && ani_id == 2013 && mes_id <= 2)
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}
                        //else if (indiceb < 1 && ctt_id == 92)
                        //{
                        //    sVariable = "qbt";
                        //    result = 0;
                        //}


                        //if (ani_id <= 2012 && ctt_id == 83)
                        //{
                        //    if (ani_id == 2012 && mes_id <= 5)
                        //    {
                        //        sVariable = "qbt";
                        //        result = 0;
                        //    }
                        //    else
                        //    {
                        //        sVariable = "qbt";
                        //        result = 0;
                        //    }

                        //}

                        // Respecto a valores al periodo de gracia del contrato 75 contrato caipipendi


                        //calculo para los demas contratos



                        /////caso especial de campo caipipendi que es hasta el mes de diciembre con
                        /////7 dias de aplicacion del qbt.
                        //else if (ani_id == 2007 && mes_id == 12 && ctt_id == 75)
                        //{
                        //    sVariable = "qbt";
                        //    decimal resultAux = qbt / 31;
                        //    resultAux = resultAux * 7;
                        //    result = resultAux;
                        //}
                        break;


                    // TODOS LOS CÁLCULOS
                    default:
                        switch (tcl_id)
                        {
                            case 2:
                                //if (flagajustado)
                                //{
                                //    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                //    if (result < 0)
                                //    {
                                //        flasACuenta = true;
                                //    }
                                //}
                                if (flasACuenta == true)
                                {
                                    if (sVariable.Equals("CRtja"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("GDTtja"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("GDYtja"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("GDTtj"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("GDYtj"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("RTSIj"))
                                    {
                                        result = 0;
                                    }
                                    if (sVariable.Equals("RTCIj"))
                                    {
                                        result = 0;
                                        flasACuenta = false;
                                    }
                                    if (sVariable.Equals("CRtj"))
                                    {
                                        result = ibtvalue;
                                    }
                                }
                                else
                                {
                                    result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);
                                }
                                break;
                            default:
                                // Procesar Fórmula Automáticamente para todos 
                                result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 28);

                                break;
                        }
                        break;
                }

                if (sVariable.Equals("PREt")
                    //|| 
                    //sVariable.Equals("CHNtgnm") || 
                    //sVariable.Equals("CHNtpcgme")||
                    //sVariable.Equals("CHNtpcg") || 
                    //sVariable.Equals("CHNtglpb") || 
                    //sVariable.Equals("CHNtglpt")
                        )
                {
                    List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                    lstTablaCalculo = TablaCalculoController.GetListaTablaCalculoPorContrato(ctt_id);
                    if (lstTablaCalculo.Count > 1)
                    {
                        preT = result;
                    }
                    else
                    {
                        preT = 0;
                        result = 0;
                    }
                }
                lstCalculos.Items.Add(sVariable + " = " + result);
                lstCalculos.Refresh();


                // Mostrar resultado
                lblResultado.Text = Util.formatNumber(System.Convert.ToString(result));

            }
        }



        /// <summary>
        /// Method validarCampos
        /// </summary>
        private bool validarCampos()
        {
            bool flag2 = false;

            flag2 = true;
            return flag2;
        }



        /// <summary>
        /// Method guardar
        /// </summary>
        private void guardar()
        {

            //ctt_id = objSession.CTT_ID;
            cal_id = objSession.CAL_ID;
            //ani_id = objSession.ANI_ID;
            //mes_id = objSession.MES_ID;
            //tcl_id = objSession.TCL_ID;

            long inserted = 0;
            long updated = 0;
            string sVariable = "";
            string dValor = "";

            // Acumulados
            //decimal ctt_depacuma = 0;
            //decimal ctt_acugantit = 0;
            //decimal ctt_invacuma = 0;
            //decimal cal_costrecuacu = 0;

            if (validarCampos())
            {
                lstCalculos.Refresh();
                // **********************************
                // Recuperar Variables y Almacenar
                // **********************************
                for (int i = 0; i < lstCalculos.Items.Count; i++)
                {
                    string sFormula = "";
                    string sVariableAux = "";

                    //
                    // Escoger Variable una a una
                    //
                    sVariable = lstCalculos.Items[i].ToString();
                    if (sVariable.Length > 0)
                    {
                        int k = sVariable.IndexOf("=");
                        if (k <= -1)
                        {
                        }
                        else
                        {
                            dValor = sVariable.Substring(k + 1).Trim();
                            sVariable = sVariable.Substring(0, k).Trim();
                        }
                    }


                    // Determinar si la variable es de fórmula
                    // Recorrer Lista de Formulas
                    for (int k = 0; k < lstFormulas.Items.Count; k++)
                    {
                        // Calcular formula
                        sFormula = lstFormulas.Items[k].ToString();
                        if (sFormula.Length > 0)
                        {
                            int l = sFormula.IndexOf("=");
                            if (l <= -1)
                            {
                            }
                            else
                            {
                                sVariableAux = sFormula.Substring(0, l).Trim();
                            }
                        }
                        string var_codigo = string.Empty;
                        long var_tipo_cal = 0;
                        long umd_id = 0;

                        //
                        // Preguntar si la variable es Fórmula
                        // Y algunas adicionales que deben registrarse de la lista de variables
                        if (sVariable.Equals(sVariableAux) ||
                            //sVariable.Equals("LRC") ||
                            sVariable.Equals("DAo") ||
                            sVariable.Equals("SDt") ||
                            sVariable.Equals("SGDTt") ||
                            sVariable.Equals("IAo") ||
                            sVariable.Equals("SIt") ||
                            sVariable.Equals("SIMPt") ||
                            sVariable.Equals("Rtgn") ||
                            sVariable.Equals("Rtpcg") ||
                            sVariable.Equals("Rtglp") ||
                            sVariable.Equals("Ptgn") ||
                            sVariable.Equals("Ptpcg") ||
                            sVariable.Equals("Ptglp") ||
                            sVariable.Equals("IDHtgn") ||
                            sVariable.Equals("IDHtpcg") ||
                            sVariable.Equals("IDHtglp") ||
                            sVariable.Equals("GRt_1")
                            )
                        {
                            // Es fórmula
                            // Buscar id de la variable
                            List<Variable> lstVariable = new List<Variable>();
                            VariableObject objVariableObject = new VariableObject();
                            lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, tcl_id);
                            if (lstVariable.Count > 0)
                            {
                                lstVariable.ForEach(delegate(Variable v)
                                {
                                    var_id = v.Var_id;
                                    var_codigo = v.Var_codigo;
                                    var_tipo_cal = v.Var_tipo_cal;
                                    umd_id = v.Umd_id;
                                });
                            }


                            else
                            {
                                lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, 3);
                                if (lstVariable.Count != 0)
                                {
                                    lstVariable.ForEach(delegate(Variable v)
                                    {
                                        var_id = v.Var_id;
                                        umd_id = v.Umd_id;
                                    });
                                }
                            }


                            List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                            Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                            Calculo_VariableObject objcalculoVariableE = new Calculo_VariableObject();

                            if (sVariable.Equals("LRC") && tcl_id == 2)
                            {
                                dValor = "0";
                            }
                            if (sVariable.Equals("GRt_1") && tcl_id == 2)
                            {
                                dValor = "0";
                            }
                            if (sVariable.Equals("RTIkana"))
                            {
                                string dvarlor_aux = dValor;
                            }
                            if (flagCalculo)
                            {

                                # region Validacion de valores a ser ingresadas solo 1 ves


                                //if (var_tipo_cal == 2 || var_tipo_cal == 4)
                                if (var_tipo_cal == 2)
                                {
                                    cal_id = objSession.CAL_ID;
                                    bool cal_valor = false;
                                    objcalculoVariableE = new Calculo_VariableObject();
                                    cal_valor = objcalculoVariableE.validarValorVariabvle(cal_id, var_id);
                                    lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                                    if (lstCvT.Count == 0)
                                    {
                                        // Variable no se encuentra registrada
                                        // En tabla tab_calculo_variable
                                        //List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                                        //Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                                        lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                                        if (lstCvT.Count == 0)
                                        {
                                            // No esta
                                            // Insert
                                            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                            Calculo_Variable calculoVariable = new Calculo_Variable();
                                            calculoVariable.Cav_id = System.Convert.ToInt64(0);
                                            calculoVariable.Cal_id = System.Convert.ToInt64(cal_id);
                                            calculoVariable.Var_id = System.Convert.ToInt64(var_id);
                                            calculoVariable.Mon_id = System.Convert.ToInt64(2);
                                            if (umd_id == 13)
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                            }
                                            else
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                            }
                                            calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                            calculoVariable.Cam_id = System.Convert.ToInt64(cam_id);

                                            // Campos no necesarios
                                            calculoVariable.Pro_id = System.Convert.ToInt64(0);
                                            calculoVariable.Mer_id = System.Convert.ToInt64(0);
                                            calculoVariable.Umd_id = System.Convert.ToInt64(0);
                                            //

                                            calculoVariable.Cav_tipo = System.Convert.ToString("P");
                                            calculoVariable.Pex_id = System.Convert.ToInt64(0);
                                            lstCalculoVariable2.Add(calculoVariable);

                                            // Save data from Usuario
                                            inserted = calculoVariable.insert(lstCalculoVariable2);
                                            if (inserted == 0)
                                            {
                                                MessageBox.Show("Hubo error en el registro Tabla Calculo Variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // Esta registrada
                                        //Update
                                        lstCvT.ForEach(delegate(Calculo_Variable cv)
                                        {
                                            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                            Calculo_Variable calculoVariable = new Calculo_Variable();
                                            calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                            calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                            calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                            calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                            if (umd_id == 13)
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                            }
                                            else
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                            }
                                            calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                            calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                            calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                            calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                            calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                            calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                            calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                            lstCalculoVariable2.Add(calculoVariable);
                                            // Save data from Usuario
                                            updated = calculoVariable.update(lstCalculoVariable2);
                                            if (updated == 0)
                                            {
                                                MessageBox.Show("Hubo error en la actualización tabla Calculo Variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        });
                                        break;
                                    }
                                }
                                #endregion

                                else
                                {
                                    //    // Variable se encuentra registrada
                                    //    // En tabla tab_calculo_variable
                                    //    //List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                                    //    //Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                                    //    //if (sVariable.Equals("LRC"))
                                    //    //{
                                    //    //    lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                                    //    //}
                                    //    //else
                                    //        lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                                    //    if (lstCvT.Count == 0)
                                    //    {
                                    //        // No esta
                                    //        // Insert
                                    //        List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                    //        Calculo_Variable calculoVariable = new Calculo_Variable();
                                    //        calculoVariable.Cav_id = System.Convert.ToInt64(0);
                                    //        calculoVariable.Cal_id = System.Convert.ToInt64(cal_id);
                                    //        calculoVariable.Var_id = System.Convert.ToInt64(var_id);
                                    //        calculoVariable.Mon_id = System.Convert.ToInt64(2);
                                    //        if (umd_id == 13)
                                    //        {
                                    //            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                    //        }
                                    //        else
                                    //        {
                                    //            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    //        }
                                    //        calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                    //        calculoVariable.Cam_id = System.Convert.ToInt64(cam_id);

                                    //        // Campos no necesarios
                                    //        calculoVariable.Pro_id = System.Convert.ToInt64(0);
                                    //        calculoVariable.Mer_id = System.Convert.ToInt64(0);
                                    //        calculoVariable.Umd_id = System.Convert.ToInt64(0);
                                    //        //

                                    //        calculoVariable.Cav_tipo = System.Convert.ToString("P");
                                    //        calculoVariable.Pex_id = System.Convert.ToInt64(0);
                                    //        lstCalculoVariable2.Add(calculoVariable);

                                    //        // Save data from Usuario
                                    //        inserted = calculoVariable.insert(lstCalculoVariable2);
                                    //        if (inserted == 0)
                                    //        {
                                    //            throw new Exception("Hubo error en el registro Tabla Calculo Variable");
                                    //        }
                                    //        break;
                                    //    }
                                    //    else
                                    //    {
                                    //        // Esta registrada
                                    //        //Update
                                    //        lstCvT.ForEach(delegate(Calculo_Variable cv)
                                    //        {
                                    //            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                    //            Calculo_Variable calculoVariable = new Calculo_Variable();
                                    //            calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                    //            calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                    //            calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                    //            calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                    //            if (umd_id == 13)
                                    //            {
                                    //                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                    //            }
                                    //            else
                                    //            {
                                    //                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    //            }
                                    //            calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                    //            calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                    //            calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                    //            calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                    //            calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                    //            calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                    //            calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                    //            lstCalculoVariable2.Add(calculoVariable);
                                    //            // Save data from Usuario
                                    //            updated = calculoVariable.update(lstCalculoVariable2);
                                    //            if (updated == 0)
                                    //            {
                                    //                throw new Exception("Hubo error en la actualización tabla Calculo Variable");
                                    //            }
                                    //        });
                                    //        break;
                                    //    }
                                }
                            }
                            else
                            {
                                // Variable se encuentra registrada
                                // En tabla tab_calculo_variable
                                //List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                                //Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                                cal_id = objSession.CAL_ID;
                                lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, cam_id);
                                if (lstCvT.Count == 0)
                                {
                                    //lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                                    //if (lstCvT.Count == 0)
                                    //{
                                    // No esta
                                    // Insert
                                    List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                    Calculo_Variable calculoVariable = new Calculo_Variable();
                                    calculoVariable.Cav_id = System.Convert.ToInt64(0);
                                    calculoVariable.Cal_id = System.Convert.ToInt64(cal_id);
                                    calculoVariable.Var_id = System.Convert.ToInt64(var_id);
                                    calculoVariable.Mon_id = System.Convert.ToInt64(2);
                                    if (umd_id == 13)
                                    {
                                        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                    }
                                    else
                                    {
                                        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    }
                                    calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                    calculoVariable.Cam_id = System.Convert.ToInt64(cam_id);

                                    // Campos no necesarios
                                    calculoVariable.Pro_id = System.Convert.ToInt64(0);
                                    calculoVariable.Mer_id = System.Convert.ToInt64(0);
                                    calculoVariable.Umd_id = System.Convert.ToInt64(0);
                                    //

                                    calculoVariable.Cav_tipo = System.Convert.ToString("P");
                                    calculoVariable.Pex_id = System.Convert.ToInt64(0);
                                    lstCalculoVariable2.Add(calculoVariable);

                                    // Save data from Usuario
                                    inserted = calculoVariable.insert(lstCalculoVariable2);
                                    if (inserted == 0)
                                    {
                                        throw new Exception("Hubo error en el registro Tabla Calculo Variable");
                                    }
                                    else
                                    {
                                        // Esta registrada
                                        //Update
                                        lstCvT.ForEach(delegate(Calculo_Variable cv)
                                        {
                                            lstCalculoVariable2 = new List<Calculo_Variable>();
                                            calculoVariable = new Calculo_Variable();
                                            calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                            calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                            calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                            calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                            if (umd_id == 13)
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                            }
                                            else
                                            {
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                            }
                                            calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                            calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                            calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                            calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                            calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                            calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                            calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                            lstCalculoVariable2.Add(calculoVariable);
                                            // Save data from Usuario
                                            updated = calculoVariable.update(lstCalculoVariable2);
                                            if (updated == 0)
                                            {
                                                throw new Exception("Hubo error en la actualización tabla Calculo Variable");
                                            }
                                        });
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    // Esta registrada
                                    //Update
                                    lstCvT.ForEach(delegate(Calculo_Variable cv)
                                    {
                                        List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                        Calculo_Variable calculoVariable = new Calculo_Variable();
                                        calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                        calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                        calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                        calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                        if (umd_id == 13)
                                        {
                                            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                        }
                                        else
                                        {
                                            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                        }
                                        calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                        calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                        calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                        calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                        calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                        calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                        calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                        lstCalculoVariable2.Add(calculoVariable);
                                        // Save data from Usuario
                                        updated = calculoVariable.update(lstCalculoVariable2);
                                        if (updated == 0)
                                        {
                                            throw new Exception("Hubo error en la actualización tabla Calculo Variable");
                                        }
                                    });
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // NO Es fórmula
                        }
                    }
                }






                // GUARDADO ESPECIAL
                // DE ACUERDO AL TIPO DE CÁLCULO
                switch (tcl_id)
                {

                    // RECALCULO
                    case 1:

                        ///* DEPRECIACIÓN ACUMULADA */
                        //// Guardar Acumulados de Depreciación, etc.
                        //// Buscar Variables de acumulación
                        //// Escoger Variable
                        //lstCalculos.Refresh();
                        //// **********************************
                        //// Recuperar Variables y Almacenar
                        //// **********************************
                        //for (int i = 0; i < lstCalculos.Items.Count; i++)
                        //{
                        //    //MessageBox.Show(lstCalculos.Items[i].ToString(), "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //    // Escoger Variable
                        //    sVariable = lstCalculos.Items[i].ToString();
                        //    if (sVariable.Length > 0)
                        //    {
                        //        int k = sVariable.IndexOf("=");
                        //        if (k <= -1)
                        //        {
                        //        }
                        //        else
                        //        {
                        //            dValor = sVariable.Substring(k + 1).Trim();
                        //            sVariable = sVariable.Substring(0, k).Trim();
                        //        }

                        //        if (sVariable.Equals("Dt"))
                        //        {
                        //            ctt_depacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                        //        }

                        //        if (sVariable.Equals("GDTt"))
                        //        {
                        //            ctt_acugantit = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                        //        }

                        //        if (sVariable.Equals("It"))
                        //        {
                        //            ctt_invacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                        //        }
                        //        if (sVariable.Equals("GRt"))
                        //        {
                        //            cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                        //        }
                        //    }
                        //}



                        ///* TOTAL EN TABLA CALCULO */
                        //// Guardar total                    
                        //// Tabla Calculo Variable
                        //string sVariableAux2;
                        //string variable2;
                        //decimal valor2;
                        //for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                        //{
                        //    sVariableAux2 = lstCalculos.Items[m].ToString();
                        //    if (sVariableAux2.Length > 0)
                        //    {
                        //        int l = sVariableAux2.IndexOf("=");
                        //        if (l <= -1)
                        //        {
                        //        }
                        //        else
                        //        {
                        //            variable2 = sVariableAux2.Substring(0, l - 1).Trim();
                        //            valor2 = System.Convert.ToDecimal(sVariableAux2.Substring(l + 1).Trim());
                        //            if (variable2.Equals("RTT"))
                        //            {
                        //                //Session objSession = new Session();
                        //                //cal_id = objSession.CAL_ID;

                        //                // Fill data      
                        //                List<Calculo> lstCalculo = new List<Calculo>();
                        //                List<Calculo> lstCalculo2 = new List<Calculo>();
                        //                CalculoObject objCalculoObject = new CalculoObject();
                        //                lstCalculo = objCalculoObject.listCalculo(cal_id);
                        //                lstCalculo.ForEach(delegate(Calculo c)
                        //                {
                        //                    Calculo calculo = new Calculo();
                        //                    calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                        //                    calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                        //                    calculo.Cal_fecha = System.Convert.ToDateTime(c.Cal_fecha);
                        //                    calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                        //                    calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                        //                    calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                        //                    calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                        //                    calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor2), 8);
                        //                    calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                        //                    calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                        //                    // Acumulados a esa año y mes de cálculo
                        //                    calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                        //                    calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                        //                    calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                        //                    calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                        //                    //calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);
                        //                    calculo.Cal_costrecuacu = cal_costrecuacu;
                        //                    lstCalculo2.Add(calculo);
                        //                });

                        //                // Save data from Usuario
                        //                Calculo objCalculo = new Calculo();
                        //                inserted = objCalculo.update(lstCalculo2);
                        //                if (inserted == 0)
                        //                {
                        //                    throw new Exception("Hubo error en la actualización Tabla Calculo TOTAL");
                        //                    //this.Close();
                        //                }
                        //            }
                        //        }
                        //    }
                        //}


                        ///* SUBTOTALES A CÁLCULO */
                        //// Guardar Acumulados de Depreciación, etc.
                        //CalculoObject objCalculoObject2 = new CalculoObject();
                        //List<Calculo> lstCalculo3 = new List<Calculo>();
                        //List<Calculo> lstCalculo4 = new List<Calculo>();
                        //lstCalculo3 = objCalculoObject2.listCalculo(cal_id);
                        ////Update
                        //lstCalculo3.ForEach(delegate(Calculo c)
                        //{
                        //    Calculo calculo = new Calculo();
                        //    calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                        //    calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                        //    calculo.Cal_fecha = System.Convert.ToDateTime(c.Cal_fecha);
                        //    calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                        //    calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                        //    calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                        //    calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                        //    calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(c.Cal_valor), 8);
                        //    calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                        //    calculo.Cal_estado = System.Convert.ToInt32(c.Cal_estado);
                        //    //// Acumulados a esa año y mes de cálculo
                        //    //if (mes_id == 5 && ani_id == 2007)
                        //    //{
                        //    //    calculo.Cal_depacuma = System.Convert.ToDecimal(0);
                        //    //}
                        //    //else
                        //    //{
                        //        calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                        //    //}
                        //    calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                        //    calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                        //    calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                        //    calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);
                        //    lstCalculo4.Add(calculo);
                        //});

                        //// Save data from Usuario
                        //updated = objCalculoObject2.update(lstCalculo4);
                        //if (updated == 0)
                        //{
                        //    throw new Exception("Hubo error en la actualización Tabla Calculo SUBTOTALES ACUMULADOS");
                        //}

                        ///* TOTALES A CONTRATO */
                        //// Guardar Acumulados de Depreciación, etc.
                        //ContratoObject objContratoObject = new ContratoObject();
                        //List<Contrato> lstContrato = new List<Contrato>();
                        //List<Contrato> lstContrato2 = new List<Contrato>();
                        //lstContrato = objContratoObject.listContrato(ctt_id);
                        ////Update
                        //lstContrato.ForEach(delegate(Contrato c)
                        //{
                        //    Contrato contrato = new Contrato();
                        //    contrato.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                        //    contrato.Suc_id = System.Convert.ToInt64(c.Suc_id);
                        //    contrato.Ctt_codigo = System.Convert.ToString(c.Ctt_codigo);
                        //    contrato.Ctt_nombre = System.Convert.ToString(c.Ctt_nombre);
                        //    contrato.Ctt_periodo = System.Convert.ToString(c.Ctt_periodo);
                        //    contrato.Ctt_fecini = Convert.ToDateTime(c.Ctt_fecini);
                        //    contrato.Ctt_fecfin = Convert.ToDateTime(c.Ctt_fecfin);
                        //    contrato.Ctt_estado = System.Convert.ToInt64(c.Ctt_estado);
                        //    contrato.Usu_id = System.Convert.ToInt32(c.Usu_id);
                        //    //
                        //    contrato.Ctt_depacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacu), 8);
                        //    if (flagCalculo)
                        //    {
                        //        //guardo de los acumulados se tiene que sumar del anterior
                        //        contrato.Ctt_depacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacuma), 8);
                        //        contrato.Ctt_acugantit = decimal.Round(System.Convert.ToDecimal(c.Ctt_acugantit), 8);
                        //        contrato.Ctt_invacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacuma), 8);
                        //    }
                        //    else
                        //    {
                        //        //guardo de los acumulados se tiene que sumar del anterior
                        //        contrato.Ctt_depacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacuma + ctt_depacuma), 8);
                        //        contrato.Ctt_acugantit = decimal.Round(System.Convert.ToDecimal(c.Ctt_acugantit + ctt_acugantit), 8);
                        //        contrato.Ctt_invacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacuma + ctt_invacuma), 8);
                        //    }

                        //    contrato.Ctt_invacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacu), 8);
                        //    contrato.Ctt_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Ctt_acuimptit), 8);
                        //    contrato.Ctt_invneta = decimal.Round(System.Convert.ToDecimal(c.Ctt_invneta), 8);
                        //    // 
                        //    contrato.Ctt_lrc = decimal.Round(System.Convert.ToDecimal(c.Ctt_lrc), 8);
                        //    contrato.Ctt_vhiena = decimal.Round(System.Convert.ToDecimal(c.Ctt_vhiena), 8);
                        //    contrato.Ctt_cmp = System.Convert.ToInt64(c.Ctt_cmp);
                        //    contrato.Ctt_icpmp = decimal.Round(System.Convert.ToDecimal(c.Ctt_icpmp), 8);
                        //    contrato.Ctt_pppvgnpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvgnpf), 8);
                        //    contrato.Ctt_pppvhlpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvhlpf), 8);
                        //    contrato.Ctt_produccion = Convert.ToInt64(c.Ctt_produccion);
                        //    lstContrato2.Add(contrato);
                        //});

                        //// Save data from Usuario
                        //updated = objContratoObject.update(lstContrato2);
                        //if (updated == 0)
                        //{
                        //    throw new Exception("Hubo error en la actualización Tabla Contratos TOTAL ACUMULADOS");
                        //}
                        break;




                    // A CUENTA
                    case 2:
                        // Registrar Calculo Variable
                        if (flagajustado == true)
                        {
                            // Se ajustaron variables
                            string sVariableAux;
                            string variable;
                            decimal valor;
                            for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                            {
                                sVariableAux = lstCalculos.Items[m].ToString();
                                if (sVariableAux.Length > 0)
                                {
                                    int l = sVariableAux.IndexOf("=");
                                    if (l <= -1)
                                    {
                                    }
                                    else
                                    {
                                        variable = sVariableAux.Substring(0, l - 1).Trim();
                                        valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                        if (variable.Equals("RTCIj"))
                                        {
                                            cal_id = objSession.CAL_ID;

                                            // Fill data      
                                            List<Calculo> lstCalculo = new List<Calculo>();
                                            List<Calculo> lstCalculo2 = new List<Calculo>();
                                            CalculoObject objCalculoObject = new CalculoObject();
                                            lstCalculo = objCalculoObject.listCalculo(cal_id);
                                            lstCalculo.ForEach(delegate(Calculo c)
                                            {
                                                Calculo calculo = new Calculo();
                                                calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor), 8);
                                                calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                                                calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                //
                                                // Acumulados a esa año y mes de cálculo
                                                calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                //
                                                // MODIFIED: CASTELLON
                                                //
                                                if (rbttnSiEs.Checked == true)
                                                    calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                else
                                                    calculo.Cal_cammar = System.Convert.ToInt32(0);


                                                //calculo.Cal_proces = 1;
                                                lstCalculo2.Add(calculo);
                                            });

                                            // Save data from Usuario
                                            Calculo objCalculo = new Calculo();
                                            inserted = objCalculo.update(lstCalculo2);
                                            if (inserted == 0)
                                            {
                                                throw new Exception("Hubo error en la inserción Tabla Cálculo: Variable RTCIj");
                                                //this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // No se ajustaron variables
                            string sVariableAux;
                            string variable;
                            decimal valor;
                            for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                            {
                                sVariableAux = lstCalculos.Items[m].ToString();
                                if (sVariableAux.Length > 0)
                                {
                                    int l = sVariableAux.IndexOf("=");
                                    if (l <= -1)
                                    {
                                    }
                                    else
                                    {
                                        variable = sVariableAux.Substring(0, l - 1).Trim();
                                        valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                        if (variable.Equals("RTCI"))
                                        {
                                            cal_id = objSession.CAL_ID;

                                            // Fill data      
                                            List<Calculo> lstCalculo = new List<Calculo>();
                                            List<Calculo> lstCalculo2 = new List<Calculo>();
                                            CalculoObject objCalculoObject = new CalculoObject();
                                            lstCalculo = objCalculoObject.listCalculo(cal_id);
                                            lstCalculo.ForEach(delegate(Calculo c)
                                            {
                                                Calculo calculo = new Calculo();
                                                calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor), 8);
                                                calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                                                calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                //
                                                calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);
                                                //
                                                // MODIFIED: CASTELLON
                                                //
                                                if (rbttnSiEs.Checked == true)
                                                    calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                else
                                                    calculo.Cal_cammar = System.Convert.ToInt32(0);

                                                //calculo.Cal_proces = 1;
                                                lstCalculo2.Add(calculo);
                                            });
                                            flagajustado = true;
                                            // Save data from Usuario
                                            Calculo objCalculo = new Calculo();
                                            inserted = objCalculo.update(lstCalculo2);
                                            if (inserted == 0)
                                            {
                                                throw new Exception("Hubo error en la actualización Tabla Cálculo: Variable RTCIj");
                                                //this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            //cmdProcesar.Enabled = false;
        }















        /* ***************** */
        /* PROCESOS A CUENTA */
        /* ***************** */


        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscar()
        {
            var v_ctt_id = cbofields2.SelectedValue;
            ctt_id = System.Convert.ToInt64(v_ctt_id);
            var v_tcl_id = cbofields1.SelectedValue;
            tcl_id = System.Convert.ToInt64(v_tcl_id);
            mes_id = cbxMes.FindString(cbxMes.Text, -1) + 1;
            ani_id = System.Convert.ToInt64(cbxAnio.Text);






            CalculoObject objCalculoObject = new CalculoObject();
            cal_id = objSession.CAL_ID;
            //cal_id = objCalculoObject.findCalculo(ctt_id, tcl_id, ani_id, mes_id);
            // Cargar Variables
            lstCalculos.Items.Clear();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
            lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotal(ctt_id, tcl_id, ani_id, mes_id);
            //lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotalPorCampo(ctt_id, tcl_id, ani_id, mes_id, cam_id);
            if (lstCalculoVariable.Count == 0)
            {
                lstFormulas.Items.Clear();
            }
            else
            {
                lstCalculos.Items.Clear();
                lstCalculoVariable.ForEach(delegate(Calculo_Variable u)
                {
                    lstCalculos.Items.Add(u.Var_codigo + " = " + u.Cav_valor);
                });
                flag = true;
            }

            // Formula
            lstFormulas.Items.Clear();
            List<Formula> lstFormula = new List<Formula>();
            FormulaObject objFormulaObject = new FormulaObject();
            lstFormula = objFormulaObject.listFormula(tcl_id);
            if (lstFormula.Count == 0)
            {
                lstFormulas.Items.Clear();
            }
            else
            {
                if (lstFormula.Count == 0)
                {
                    cbTest.Items.Clear();
                }
                else
                {
                    lstFormulas.Items.Clear();
                    lstFormula.ForEach(delegate(Formula f)
                    {
                        cbTest.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                        lstFormulas.Items.Add(f.Var_codigo + " = " + f.For_codigo);
                    });
                    flag = true;
                }
            }


            // Leer contrato
            // Depreciaciones
            // Inversiones
            //ContratoObject objContratoObject = new ContratoObject();
            //List<Contrato> lstContrato = new List<Contrato>();
            //lstContrato = objContratoObject.listContrato(ctt_id);
            //if (lstContrato.Count == 0)
            //{
            //}
            //else
            //{
            //    lstContrato.ForEach(delegate(Contrato c)
            //    {
            //        if (c.Ctt_depacu > 0)
            //        {
            //            lstCalculos.Items.Add("DAo" + " = " + c.Ctt_depacu);
            //        }
            //        if (c.Ctt_depacuma > 0)
            //            lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
            //        if (c.Ctt_acugantit > 0)
            //            lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
            //        if (c.Ctt_invacu > 0)
            //            lstCalculos.Items.Add("IAo" + " = " + c.Ctt_invacu);
            //        if (c.Ctt_invacuma > 0)
            //            lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
            //        if (c.Ctt_depacu > 0)
            //            lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
            //        if (c.Ctt_acuimptit > 0)
            //            lstCalculos.Items.Add("LRC" + " = " + c.Ctt_lrc);
            //        //lstCalculos.Items.Add("GRt_1" + " = " + c.Ctt_depacuma);
            //    });
            //}



            //CalculoObject objCalculo = new CalculoObject();
            //Calculo calculo = new Calculo();
            //calculo = objCalculoObject.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id-1, tcl_id);
            //if (calculo.Cal_costrecuacu == 0)
            //{
            //    lstCalculos.Items.Add("GRt_1" + " = " + "0.00000000");
            //}
            //else
            //{
            //        lstCalculos.Items.Add("GRt_1" + " = " + calculo.Cal_costrecuacu);
            //}

            ////Habilitación del boton de procesar datos.
            //calculo = objCalculo.listCalculoByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            //if (calculo.Cal_valor != -1)
            //{
            //    cmdProcesar.Enabled = false;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}
            //else
            //{
            //    cmdProcesar.Enabled = true;
            //    btnReprosesar.Visible = false;
            //    btnReprosesarMesActual.Visible = false;
            //}


            // Leer regalias
            RegaliaObject objRegaliaObject = new RegaliaObject();
            List<Regalia> lstRegalia = new List<Regalia>();
            lstRegalia = objRegaliaObject.listRegaliaPorContratoCampo(ctt_id, ani_id, mes_id, cam_id);
            if (lstRegalia.Count == 0)
            {
            }
            else
            {
                // Sumar todas la regalías
                decimal crudor = 0;
                decimal gnr = 0;
                decimal glpr = 0;

                decimal crudoi = 0;
                decimal gni = 0;
                decimal glpi = 0;

                decimal crudop = 0;
                decimal gnp = 0;
                decimal glpp = 0;

                lstRegalia.ForEach(delegate(Regalia r)
                {
                    if (r.Reg_tipo == "R")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudor += r.Reg_crudome + r.Reg_crudomi;
                        gnr += r.Reg_gasme + r.Reg_gasmi;
                        glpr += r.Reg_glp;
                    }

                    // Código adicional
                    if (r.Reg_tipo == "I")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudoi += r.Reg_crudome + r.Reg_crudomi;
                        gni += r.Reg_gasme + r.Reg_gasmi;
                        glpi += r.Reg_glp;
                    }

                    if (r.Reg_tipo == "P")
                    {
                        // Revisar o preguntar si las regalias son iguales y si se suman para el calculo
                        crudop += r.Reg_crudome + r.Reg_crudomi;
                        gnp += r.Reg_gasme + r.Reg_gasmi;
                        glpp += r.Reg_glp;
                    }
                    // Código adicional

                });


                lstCalculos.Items.Add("Rtgn" + " = " + gnr);
                lstCalculos.Items.Add("Rtpcg" + " = " + crudor);
                lstCalculos.Items.Add("Rtglp" + " = " + glpr);

                // Código adicional
                lstCalculos.Items.Add("Ptgn" + " = " + gnp);
                lstCalculos.Items.Add("Ptpcg" + " = " + crudop);
                lstCalculos.Items.Add("Ptglp" + " = " + glpp);

                lstCalculos.Items.Add("IDHtgn" + " = " + gni);
                lstCalculos.Items.Add("IDHtpcg" + " = " + crudoi);
                lstCalculos.Items.Add("IDHtglp" + " = " + glpi);


            }


            switch (tcl_id)
            {
                case 1:
                    // Recálculo
                    Conversiones objConversiones = new Conversiones();
                    List<Conversiones> lstConversiones = new List<Conversiones>();
                    lstConversiones = ConversionesController.GetListaConversiones(0);
                    if (lstConversiones.Count == 0)
                    {
                    }
                    else
                    {
                        lstConversiones.ForEach(delegate(Conversiones c)
                        {
                            lstCalculos.Items.Add(c.Var_codigo + " = " + c.Con_valor);
                        });
                    }
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    lstCalculos.Items.Add("PPijk" + " = " + "1");
                    ///lstCalculos.Items.Add("GRt_1" + " = " + "0");
                    break;


                case 2:
                    // A cuenta
                    // Porcentajes Comunes
                    lstCalculos.Items.Add("PVPF" + " = " + "1");
                    break;

                default:
                    break;

            }
        }


        /// <summary>
        /// Method procesar
        /// </summary>
        private void procesarACuenta()
        {
            string sFormula = "";
            string sVariable = "";
            string sVariablesNoCargadas = "";
            //string sVariablesNegativas = "";
            int i;
            int j;
            int k;
            decimal result = 0;

            if (validarVariables().Equals(""))
            {
            }
            else
            {

                try
                {
                    sVariablesNoCargadas = validarVariables();
                    sVariablesNoCargadas = sVariablesNoCargadas.Replace("$", "\n");
                    switch (MessageBox.Show("Se detectó que faltan cargar valores a las siguientes Variables: \n " + sVariablesNoCargadas + "\n\n¿Procesar formulas?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:

                            // hourglass cursor
                            Cursor.Current = Cursors.WaitCursor;
                            lblProcesando.Visible = true;
                            timer1.Enabled = true;

                            lstCalculos.Refresh();
                            lstFormulas.Refresh();

                            // Procesar
                            // Progress Bar
                            count = 0;
                            for (i = 0; i < lstFormulas.Items.Count; i++)
                            {
                                count++;
                            }
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = count;
                            progressBar1.Step = 1;
                            progressBar1.Show();

                            // Procesar Lista
                            for (int z = 0; z <= lstCampos.Items.Count - 1; z++)
                            {
                                try
                                {

                                    // Buscar
                                    //buscar();
                                    buscarDatos();
                                    procesarDetalle();

                                    // Formulas
                                    for (k = 0; k < lstFormulas.Items.Count; k++)
                                    {
                                        // Variables
                                        for (i = 0; i <= lstCalculos.Items.Count - 1; i++)
                                        {
                                            sVariable = lstCalculos.Items[i].ToString();
                                            j = sVariable.IndexOf("=");
                                            if (j <= -1)
                                            {
                                            }
                                            else
                                            {
                                                process.NewVariable(sVariable.Substring(0, j - 1), sVariable.Substring(j + 1));
                                            }
                                        }
                                        // Obtener Variable
                                        sFormula = lstFormulas.Items[k].ToString();
                                        if (sFormula.Length > 0)
                                        {
                                            int l = sFormula.IndexOf("=");
                                            if (l <= -1)
                                            {
                                            }
                                            else
                                            {
                                                sVariable = sFormula.Substring(0, l).Trim();
                                                sFormula = sFormula.Substring(l + 1).Trim();
                                            }
                                        }


                                        // Procesar
                                        // Variables que no se procesan con fórmulas
                                        switch (sVariable)
                                        {
                                            // A CUENTA
                                            case "VRPRPI":
                                                vrprpi = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                                result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                                // Comparar con IBt
                                                string sVariableAux;
                                                for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                                                {
                                                    sVariableAux = lstCalculos.Items[m].ToString();
                                                    if (sVariableAux.Length > 0)
                                                    {
                                                        int l = sVariableAux.IndexOf("=");
                                                        if (l <= -1)
                                                        {
                                                        }
                                                        else
                                                        {
                                                            ibt = sVariableAux.Substring(0, l - 1).Trim();
                                                            ibtvalue = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                                            if (ibt.Equals("IB"))
                                                            {
                                                                if (vrprpi >= ibtvalue)
                                                                {
                                                                    // No procesar ajustes
                                                                    //MessageBox.Show("No deben procesarse variables ajustadas", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                    k = lstFormulas.Items.Count;
                                                                    flagajustado = false;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    flagajustado = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                break;

                                            case "D":
                                                // Procesar Lista
                                                if (mes_id == 5 && ani_id == 2007)
                                                {
                                                    decimal resultAux = Util.diasMes(ani_id, mes_id);
                                                    result = resultAux - 1;
                                                }
                                                else
                                                {
                                                    result = Util.diasMes(ani_id, mes_id);
                                                }
                                                break;

                                            case "Bt":
                                                // Procesar Lista
                                                indiceb = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                break;

                                            case "PFGNdia":
                                                mpcdia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                break;

                                            case "PFHLdia":
                                                bbldia = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                break;

                                            case "qbt":
                                                ContratoObject objContratoObject = new ContratoObject();
                                                // Dea acuerdo al tipo de producción del hidrocarburo del Operador se debe escoger
                                                // mpcdia ó bbldia
                                                // Al momento solo mpcdia
                                                qbt = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla), 8);
                                                result = decimal.Round(objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla), 8);
                                                sVariable = "qbt";
                                                lstCalculos.Items.Add(sVariable + " = " + qbt);
                                                lstCalculos.Refresh();

                                                // Cálculo modificado de acuerdo a consulta de Isabel 
                                                // respecto a la aplicación de la participación de ypfb
                                                if (ani_id == 2007 && mes_id <= 7)
                                                {
                                                    sVariable = "qbt";
                                                    result = 0;
                                                }

                                                // Respecto a valores al periodo de gracia del contrato 83
                                                if (ani_id <= 2011 && ctt_id == 83)
                                                {
                                                    if (ani_id == 2011 && mes_id <= 5)
                                                    {
                                                        sVariable = "qbt";
                                                        result = 0;
                                                    }
                                                    else
                                                    {
                                                        sVariable = "qbt";
                                                        result = 0;
                                                    }
                                                }

                                                if (ani_id <= 2007 && ctt_id == 75)
                                                {
                                                    if (ani_id == 2007 && mes_id < 12)
                                                    {
                                                        sVariable = "qbt";
                                                        result = 0;
                                                    }
                                                    else if (ani_id == 2007 && mes_id == 12)
                                                    {
                                                        sVariable = "qbt";
                                                        decimal resultAux = qbt / 31;
                                                        resultAux = resultAux * 9;
                                                        result = resultAux;
                                                    }

                                                }

                                                //calculo para los demas contratos
                                                if (ani_id == 2007 && mes_id == 8 && ctt_id != 83 && ctt_id != 75)
                                                {
                                                    sVariable = "qbt";
                                                    result = qbt / 31;
                                                }
                                                break;

                                            // TODOS LOS CÁLCULOS
                                            default:
                                                // Procesar Fórmula Automáticamente
                                                result = decimal.Round(System.Convert.ToDecimal(process.ProcessCondition(sFormula)), 8);
                                                break;
                                        }

                                        lstCalculos.Items.Add(sVariable + " = " + result);
                                        lstCalculos.Refresh();

                                        // Mostrar resultado
                                        lblResultado.Text = Util.formatNumber(System.Convert.ToString(result));
                                        progressBar1.PerformStep();
                                    }


                                    // Guardar
                                    guardarACuenta();

                                    MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Hubo error en el procesamiento del campo. \n" + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            progressBar1.Hide();
                            lblProcesando.Visible = false;

                            break;


                        case DialogResult.No:
                            // "No" processing
                            break;

                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }



                }
                catch (Exception e)
                {
                    MessageBox.Show("Hubo error en el procesamiento. \nPor favor revise las variables de entrada cargadas !!" + "\n" + e.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }




        /// <summary>
        /// Method guardar
        /// </summary>
        private void guardarACuenta()
        {
            long inserted = 0;
            long updated = 0;
            string sVariable = "";
            string dValor = "";

            // Acumulados
            decimal ctt_depacuma = 0;
            decimal ctt_acugantit = 0;
            decimal ctt_invacuma = 0;

            if (validarCampos())
            {
                switch (MessageBox.Show("¿Guardar valores del proceso de cálculo?",
                              "Validación del Sistema",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:

                        lstCalculos.Refresh();

                        count = 0;
                        for (int i = 0; i < lstCalculos.Items.Count * 1.7; i++)
                        {
                            count++;
                        }


                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = count;
                        progressBar1.Step = 1;
                        progressBar1.Show();

                        // hourglass cursor
                        Cursor.Current = Cursors.WaitCursor;
                        lblProcesando.Visible = true;
                        timer1.Enabled = true;



                        // **********************************
                        // Recuperar Variables y Almacenar
                        // **********************************
                        for (int i = 0; i < lstCalculos.Items.Count; i++)
                        {
                            string sFormula = "";
                            string sVariableAux = "";

                            //
                            // Escoger Variable una a una
                            //
                            sVariable = lstCalculos.Items[i].ToString();
                            if (sVariable.Length > 0)
                            {
                                int k = sVariable.IndexOf("=");
                                if (k <= -1)
                                {
                                }
                                else
                                {
                                    dValor = sVariable.Substring(k + 1).Trim();
                                    sVariable = sVariable.Substring(0, k).Trim();
                                }
                            }


                            // Determinar si la variable es de fórmula
                            // Recorrer Lista de Formulas
                            for (int k = 0; k < lstFormulas.Items.Count; k++)
                            {
                                // Calcular formula
                                sFormula = lstFormulas.Items[k].ToString();
                                if (sFormula.Length > 0)
                                {
                                    int l = sFormula.IndexOf("=");
                                    if (l <= -1)
                                    {
                                    }
                                    else
                                    {
                                        sVariableAux = sFormula.Substring(0, l).Trim();
                                    }
                                }

                                //
                                // Preguntar si la variable es Fórmula
                                // Y algunas adicionales que deben registrarse de la lista de variables
                                if (sVariable.Equals(sVariableAux) ||
                                    sVariable.Equals("LRC") ||
                                    sVariable.Equals("DAo") ||
                                    sVariable.Equals("SDt") ||
                                    sVariable.Equals("SGDTt") ||
                                    sVariable.Equals("IAo") ||
                                    sVariable.Equals("SIt") ||
                                    sVariable.Equals("SIMPt")
                                   )
                                {
                                    // Es fórmula
                                    // Buscar id de la variable
                                    List<Variable> lstVariable = new List<Variable>();
                                    VariableObject objVariableObject = new VariableObject();
                                    lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, tcl_id);
                                    if (lstVariable.Count > 0)
                                    {
                                        lstVariable.ForEach(delegate(Variable v)
                                        {
                                            var_id = v.Var_id;
                                        });
                                    }
                                    else
                                    {
                                        lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, 3);
                                        if (lstVariable.Count != 0)
                                        {
                                            lstVariable.ForEach(delegate(Variable v)
                                            {
                                                var_id = v.Var_id;
                                            });
                                        }
                                    }


                                    // Variable se encuentra registrada
                                    // En tabla tab_calculo_variable
                                    List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                                    Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                                    lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id);
                                    if (lstCvT.Count == 0)
                                    {
                                        // No esta
                                        // Insert
                                        List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                        Calculo_Variable calculoVariable = new Calculo_Variable();
                                        calculoVariable.Cav_id = System.Convert.ToInt64(0);
                                        calculoVariable.Cal_id = System.Convert.ToInt64(cal_id);
                                        calculoVariable.Var_id = System.Convert.ToInt64(var_id);
                                        calculoVariable.Mon_id = System.Convert.ToInt64(2);
                                        calculoVariable.Cav_valor = System.Convert.ToDecimal(dValor);
                                        calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                        calculoVariable.Cam_id = System.Convert.ToInt64(0);
                                        calculoVariable.Pro_id = System.Convert.ToInt64(0);
                                        calculoVariable.Mer_id = System.Convert.ToInt64(0);
                                        calculoVariable.Umd_id = System.Convert.ToInt64(0);
                                        calculoVariable.Cav_tipo = System.Convert.ToString("P");
                                        calculoVariable.Pex_id = System.Convert.ToInt64(0);
                                        lstCalculoVariable2.Add(calculoVariable);

                                        // Save data from Usuario
                                        inserted = calculoVariable.insert(lstCalculoVariable2);
                                        if (inserted == 0)
                                        {
                                            MessageBox.Show("Hubo error en el registro Tabla Calculo Variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        // Esta registrada
                                        //Update
                                        lstCvT.ForEach(delegate(Calculo_Variable cv)
                                        {
                                            List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                            Calculo_Variable calculoVariable = new Calculo_Variable();
                                            calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                            calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                            calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                            calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                            calculoVariable.Cav_valor = System.Convert.ToDecimal(dValor);
                                            calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                            calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                            calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                            calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                            calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                            calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                            calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                            lstCalculoVariable2.Add(calculoVariable);
                                            // Save data from Usuario
                                            updated = calculoVariable.update(lstCalculoVariable2);
                                            if (updated == 0)
                                            {
                                                MessageBox.Show("Hubo error en la actualización tabla Calculo Variable", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        });
                                        break;
                                    }
                                }
                                else
                                {
                                    // NO Es fórmula
                                }


                            }
                            progressBar1.PerformStep();
                        }





                        // GUARDADO ESPECIAL
                        // DE ACUERDO AL TIPO DE CÁLCULO
                        switch (tcl_id)
                        {

                            // RECALCULO
                            case 1:

                                /* DEPRECIACIÓN ACUMULADA */
                                // Guardar Acumulados de Depreciación, etc.
                                // Buscar Variables de acumulación
                                // Escoger Variable
                                lstCalculos.Refresh();
                                // **********************************
                                // Recuperar Variables y Almacenar
                                // **********************************
                                for (int i = 0; i < lstCalculos.Items.Count; i++)
                                {
                                    //MessageBox.Show(lstCalculos.Items[i].ToString(), "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    // Escoger Variable
                                    sVariable = lstCalculos.Items[i].ToString();
                                    if (sVariable.Length > 0)
                                    {
                                        int k = sVariable.IndexOf("=");
                                        if (k <= -1)
                                        {
                                        }
                                        else
                                        {
                                            dValor = sVariable.Substring(k + 1).Trim();
                                            sVariable = sVariable.Substring(0, k).Trim();
                                        }

                                        if (sVariable.Equals("Dt"))
                                        {
                                            ctt_depacuma = System.Convert.ToDecimal(dValor);
                                        }

                                        if (sVariable.Equals("GDTt"))
                                        {
                                            ctt_acugantit = System.Convert.ToDecimal(dValor);
                                        }

                                        if (sVariable.Equals("It"))
                                        {
                                            ctt_invacuma = System.Convert.ToDecimal(dValor);
                                        }
                                    }
                                }



                                /* TOTAL EN TABLA CALCULO */
                                // Guardar total                    
                                // Tabla Calculo Variable
                                string sVariableAux2;
                                string variable2;
                                decimal valor2;
                                for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                                {
                                    sVariableAux2 = lstCalculos.Items[m].ToString();
                                    if (sVariableAux2.Length > 0)
                                    {
                                        int l = sVariableAux2.IndexOf("=");
                                        if (l <= -1)
                                        {
                                        }
                                        else
                                        {
                                            variable2 = sVariableAux2.Substring(0, l - 1).Trim();
                                            valor2 = System.Convert.ToDecimal(sVariableAux2.Substring(l + 1).Trim());
                                            if (variable2.Equals("RTT"))
                                            {
                                                //Session objSession = new Session();
                                                cal_id = objSession.CAL_ID;

                                                // Fill data      
                                                List<Calculo> lstCalculo = new List<Calculo>();
                                                List<Calculo> lstCalculo2 = new List<Calculo>();
                                                CalculoObject objCalculoObject = new CalculoObject();
                                                lstCalculo = objCalculoObject.listCalculo(cal_id);
                                                lstCalculo.ForEach(delegate(Calculo c)
                                                {
                                                    Calculo calculo = new Calculo();
                                                    calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                    calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                    calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                    calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                    calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                    calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                    calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                    calculo.Cal_valor = System.Convert.ToDecimal(valor2);
                                                    calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                                                    calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                    // Acumulados a esa año y mes de cálculo
                                                    calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                    calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                    calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                    calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                    calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                    //
                                                    // MODIFIED: CASTELLON
                                                    //
                                                    if (rbttnSiEs.Checked == true)
                                                        calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                    else
                                                        calculo.Cal_cammar = System.Convert.ToInt32(0);

                                                    lstCalculo2.Add(calculo);
                                                });

                                                // Save data from Usuario
                                                Calculo objCalculo = new Calculo();
                                                inserted = objCalculo.update(lstCalculo2);
                                                if (inserted == 0)
                                                {
                                                    MessageBox.Show("Hubo error en la actualización Tabla Calculo TOTAL", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    this.Close();
                                                }
                                            }
                                        }
                                    }
                                }





                                // Guardar Variables Acumuladas
                                switch (MessageBox.Show("¿Guardar valores de variables acumuladas?",
                                              "Validación del Sistema",
                                              MessageBoxButtons.YesNoCancel,
                                              MessageBoxIcon.Question))
                                {
                                    case DialogResult.Yes:


                                        /* SUBTOTALES A CÁLCULO */
                                        // Guardar Acumulados de Depreciación, etc.
                                        CalculoObject objCalculoObject = new CalculoObject();
                                        List<Calculo> lstCalculo = new List<Calculo>();
                                        List<Calculo> lstCalculo2 = new List<Calculo>();
                                        lstCalculo = objCalculoObject.listCalculo(cal_id);
                                        //Update
                                        lstCalculo.ForEach(delegate(Calculo c)
                                        {
                                            Calculo calculo = new Calculo();
                                            calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                            calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                            calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                            calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                            calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                            calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                            calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                            calculo.Cal_valor = System.Convert.ToDecimal(c.Cal_valor);
                                            calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                                            calculo.Cal_estado = System.Convert.ToInt32(c.Cal_estado);
                                            // Acumulados a esa año y mes de cálculo
                                            calculo.Cal_depacuma = System.Convert.ToDecimal(ctt_depacuma);
                                            calculo.Cal_acugantit = System.Convert.ToDecimal(ctt_acugantit);
                                            calculo.Cal_invacuma = System.Convert.ToDecimal(ctt_invacuma);
                                            calculo.Cal_acuimptit = System.Convert.ToDecimal(c.Cal_acuimptit);

                                            //
                                            // MODIFIED: CASTELLON
                                            //
                                            if (rbttnSiEs.Checked == true)
                                                calculo.Cal_cammar = System.Convert.ToInt32(1);
                                            else
                                                calculo.Cal_cammar = System.Convert.ToInt32(0);



                                            lstCalculo2.Add(calculo);
                                        });

                                        // Save data from Usuario
                                        updated = objCalculoObject.update(lstCalculo2);
                                        if (updated == 0)
                                        {
                                            throw new Exception("Hubo error en la actualización Tabla Calculo SUBTOTALES ACUMULADOS");
                                        }




                                        /* TOTALES A CONTRATO */
                                        // Guardar Acumulados de Depreciación, etc.
                                        ContratoObject objContratoObject = new ContratoObject();
                                        List<Contrato> lstContrato = new List<Contrato>();
                                        List<Contrato> lstContrato2 = new List<Contrato>();
                                        lstContrato = objContratoObject.listContrato(ctt_id);
                                        //Update
                                        lstContrato.ForEach(delegate(Contrato c)
                                        {
                                            Contrato contrato = new Contrato();
                                            contrato.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                            contrato.Suc_id = System.Convert.ToInt64(c.Suc_id);
                                            contrato.Ctt_codigo = System.Convert.ToString(c.Ctt_codigo);
                                            contrato.Ctt_nombre = System.Convert.ToString(c.Ctt_nombre);
                                            contrato.Ctt_periodo = System.Convert.ToString(c.Ctt_periodo);
                                            contrato.Ctt_fecini = Convert.ToDateTime(c.Ctt_fecini);
                                            contrato.Ctt_fecfin = Convert.ToDateTime(c.Ctt_fecfin);
                                            contrato.Ctt_estado = System.Convert.ToInt64(c.Ctt_estado);
                                            contrato.Usu_id = System.Convert.ToInt32(c.Usu_id);
                                            //
                                            contrato.Ctt_depacu = System.Convert.ToDecimal(c.Ctt_depacu);
                                            contrato.Ctt_depacuma = System.Convert.ToDecimal(c.Ctt_depacuma + ctt_depacuma);
                                            contrato.Ctt_acugantit = System.Convert.ToDecimal(c.Ctt_acugantit + ctt_acugantit);

                                            contrato.Ctt_invacu = System.Convert.ToDecimal(c.Ctt_invacu);
                                            contrato.Ctt_invacuma = System.Convert.ToDecimal(c.Ctt_invacuma + ctt_invacuma);
                                            contrato.Ctt_acuimptit = System.Convert.ToDecimal(c.Ctt_acuimptit);
                                            contrato.Ctt_invneta = System.Convert.ToDecimal(c.Ctt_invneta);
                                            // 
                                            contrato.Ctt_lrc = System.Convert.ToDecimal(c.Ctt_lrc);
                                            contrato.Ctt_vhiena = System.Convert.ToDecimal(c.Ctt_vhiena);
                                            contrato.Ctt_cmp = System.Convert.ToInt64(c.Ctt_cmp);
                                            contrato.Ctt_icpmp = System.Convert.ToDecimal(c.Ctt_icpmp);
                                            contrato.Ctt_pppvgnpf = System.Convert.ToDecimal(c.Ctt_pppvgnpf);
                                            contrato.Ctt_pppvhlpf = System.Convert.ToDecimal(c.Ctt_pppvhlpf);
                                            contrato.Ctt_produccion = Convert.ToInt64(c.Ctt_produccion);
                                            contrato.Ctt_costrecuacu = Convert.ToDecimal(c.Ctt_costrecuacu);
                                            contrato.Ctt_orden = Convert.ToInt32(c.Ctt_orden);
                                            lstContrato2.Add(contrato);
                                        });

                                        // Save data from Usuario
                                        updated = objContratoObject.update(lstContrato2);
                                        if (updated == 0)
                                        {
                                            throw new Exception("Hubo error en la actualización Tabla Contratos TOTAL ACUMULADOS");
                                        }
                                        break;
                                }
                                break;




                            // A CUENTA
                            case 2:
                                // Registrar Calculo Variable
                                if (flagajustado == true)
                                {
                                    // Se ajustaron variables
                                    string sVariableAux;
                                    string variable;
                                    decimal valor;
                                    for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                                    {
                                        sVariableAux = lstCalculos.Items[m].ToString();
                                        if (sVariableAux.Length > 0)
                                        {
                                            int l = sVariableAux.IndexOf("=");
                                            if (l <= -1)
                                            {
                                            }
                                            else
                                            {
                                                variable = sVariableAux.Substring(0, l - 1).Trim();
                                                valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                                if (variable.Equals("RTCIj"))
                                                {
                                                    Session objSession = new Session();
                                                    cal_id = objSession.CAL_ID;

                                                    // Fill data      
                                                    List<Calculo> lstCalculo = new List<Calculo>();
                                                    List<Calculo> lstCalculo2 = new List<Calculo>();
                                                    CalculoObject objCalculoObject = new CalculoObject();
                                                    lstCalculo = objCalculoObject.listCalculo(cal_id);
                                                    lstCalculo.ForEach(delegate(Calculo c)
                                                    {
                                                        Calculo calculo = new Calculo();
                                                        calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                        calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                        calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                        calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                        calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                        calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                        calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                        calculo.Cal_valor = System.Convert.ToDecimal(valor);
                                                        calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                                                        calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                        // Acumulados a esa año y mes de cálculo
                                                        calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                        calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                        calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                        calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                        calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                        //
                                                        // MODIFIED: CASTELLON
                                                        //
                                                        if (rbttnSiEs.Checked == true)
                                                            calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                        else
                                                            calculo.Cal_cammar = System.Convert.ToInt32(0);

                                                        lstCalculo2.Add(calculo);
                                                    });

                                                    // Save data from Usuario
                                                    Calculo objCalculo = new Calculo();
                                                    inserted = objCalculo.update(lstCalculo2);
                                                    if (inserted == 0)
                                                    {
                                                        this.Close();
                                                        throw new Exception("Hubo error en la actualización");
                                                        
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // No se ajustaron variables
                                    string sVariableAux;
                                    string variable;
                                    decimal valor;
                                    for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                                    {
                                        sVariableAux = lstCalculos.Items[m].ToString();
                                        if (sVariableAux.Length > 0)
                                        {
                                            int l = sVariableAux.IndexOf("=");
                                            if (l <= -1)
                                            {
                                            }
                                            else
                                            {
                                                variable = sVariableAux.Substring(0, l - 1).Trim();
                                                valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                                if (variable.Equals("RTCI"))
                                                {
                                                    Session objSession = new Session();
                                                    cal_id = objSession.CAL_ID;

                                                    // Fill data      
                                                    List<Calculo> lstCalculo = new List<Calculo>();
                                                    List<Calculo> lstCalculo2 = new List<Calculo>();
                                                    CalculoObject objCalculoObject = new CalculoObject();
                                                    lstCalculo = objCalculoObject.listCalculo(cal_id);
                                                    lstCalculo.ForEach(delegate(Calculo c)
                                                    {
                                                        Calculo calculo = new Calculo();
                                                        calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                        calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                        calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                        calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                        calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                        calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                        calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                        calculo.Cal_valor = System.Convert.ToDecimal(valor);
                                                        calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                                                        calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                        // Acumulados a esa año y mes de cálculo
                                                        calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                        calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                        calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                        calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                        calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                        //
                                                        // MODIFIED: CASTELLON
                                                        //
                                                        if (rbttnSiEs.Checked == true)
                                                            calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                        else
                                                            calculo.Cal_cammar = System.Convert.ToInt32(0);


                                                        lstCalculo2.Add(calculo);
                                                    });

                                                    flagajustado = true;
                                                    // Save data from Usuario
                                                    Calculo objCalculo = new Calculo();
                                                    inserted = objCalculo.update(lstCalculo2);
                                                    if (inserted == 0)
                                                    {
                                                        this.Close();
                                                        throw new Exception("Hubo error en la actualización");
                                                        
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;

                            default:
                                break;
                        }










                        // ProgressBar1
                        progressBar1.Hide();
                        lblProcesando.Visible = false;
                        // default cursor
                        Cursor.Current = Cursors.Default;
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


        private void guardarTotales()
        {
            long inserted = 0;
            long updated = 0;
            string sVariable = "";
            string dValor = "";
            //Session objSession = new Session();
            cal_id = objSession.CAL_ID;
            // Acumulados
            decimal ctt_depacuma = 0;
            decimal ctt_acugantit = 0;
            decimal ctt_invacuma = 0;
            decimal ctt_acuimptit = 0;
            decimal cal_depacuma = 0;
            decimal cal_acugantit = 0;
            decimal cal_invacuma = 0;
            decimal cal_costrecuacu = 0;
            decimal cal_acuimptit = 0;
            //cal_id = objSession.CAL_ID;

            if (validarCampos())
            {
                lstCalculos.Refresh();
                // **********************************
                // Recuperar Variables y Almacenar
                // **********************************
                for (int i = 0; i < lstCalculos.Items.Count; i++)
                {
                    string sFormula = "";
                    string sVariableAux = "";

                    //
                    // Escoger Variable una a una
                    //
                    sVariable = lstCalculos.Items[i].ToString();
                    if (sVariable.Length > 0)
                    {
                        int k = sVariable.IndexOf("=");
                        if (k <= -1)
                        {
                        }
                        else
                        {
                            dValor = sVariable.Substring(k + 1).Trim();
                            sVariable = sVariable.Substring(0, k).Trim();
                        }
                    }


                    // Determinar si la variable es de fórmula
                    // Recorrer Lista de Formulas
                    for (int k = 0; k < lstFormulas.Items.Count; k++)
                    {
                        // Calcular formula
                        sFormula = lstFormulas.Items[k].ToString();
                        if (sFormula.Length > 0)
                        {
                            int l = sFormula.IndexOf("=");
                            if (l <= -1)
                            {
                            }
                            else
                            {
                                sVariableAux = sFormula.Substring(0, l).Trim();
                            }
                        }
                        string var_codigo = string.Empty;
                        long umd_id = 0;
                        //
                        // Preguntar si la variable es Fórmula
                        // Y algunas adicionales que deben registrarse de la lista de variables
                        if (sVariable.Equals(sVariableAux) ||
                            sVariable.Equals("LRCt") ||
                            sVariable.Equals("DAot") ||
                            sVariable.Equals("SDt") ||
                            sVariable.Equals("SGDTt") ||
                            sVariable.Equals("IAot") ||
                            sVariable.Equals("SIt") ||
                            sVariable.Equals("SIMPt") ||
                            sVariable.Equals("Rtgn") ||
                            sVariable.Equals("Rtpcg") ||
                            sVariable.Equals("Rtglp") ||
                            sVariable.Equals("Ptgn") ||
                            sVariable.Equals("Ptpcg") ||
                            sVariable.Equals("Ptglp") ||
                            sVariable.Equals("IDHtgn") ||
                            sVariable.Equals("IDHtpcg") ||
                            sVariable.Equals("IDHtglp") ||
                            sVariable.Equals("GRt_1t") ||
                            sVariable.Equals("qbt") ||
                            sVariable.Equals("PPijk") ||
                            sVariable.Equals("PVPF"))
                        {

                            if ((sVariable.Equals("Rtgn") ||
                            sVariable.Equals("Rtpcg") ||
                            sVariable.Equals("Rtglp") ||
                            sVariable.Equals("Ptgn") ||
                            sVariable.Equals("Ptpcg") ||
                            sVariable.Equals("Ptglp") ||
                            sVariable.Equals("IDHtgn") ||
                            sVariable.Equals("IDHtpcg") ||
                            sVariable.Equals("IDHtglp")) && tcl_id == 1)
                            {
                                dValor = Convert.ToString(0);
                            }
                            if (sVariable.Equals("CHNtgnm") ||
                                sVariable.Equals("CHNtpcgme") ||
                                sVariable.Equals("CHNtpcg") ||
                                sVariable.Equals("CHNtglpb") ||
                                sVariable.Equals("CHNtglpt"))
                            {
                                List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                                lstTablaCalculo = TablaCalculoController.GetListaTablaCalculoPorContrato(ctt_id);
                                if (lstTablaCalculo.Count > 1)
                                {
                                    //preT = result;
                                }
                                else
                                {
                                    dValor = Convert.ToString(0);
                                }
                            }
                            // Es fórmula
                            // Buscar id de la variable
                            List<Variable> lstVariable = new List<Variable>();
                            VariableObject objVariableObject = new VariableObject();
                            lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, tcl_id);
                            if (lstVariable.Count > 0)
                            {
                                lstVariable.ForEach(delegate(Variable v)
                                {
                                    var_id = v.Var_id;
                                    var_codigo = v.Var_codigo;
                                    umd_id = v.Umd_id;
                                });
                            }


                            else
                            {
                                lstVariable = objVariableObject.listVariablePorCodigoTipoCálculo(sVariable, 3);
                                if (lstVariable.Count != 0)
                                {
                                    lstVariable.ForEach(delegate(Variable v)
                                    {
                                        var_id = v.Var_id;
                                        umd_id = v.Umd_id;
                                    });
                                }
                            }
                            Calculo_VariableObject objcalculoVariableE = new Calculo_VariableObject();
                            bool cal_valor = false;
                            cal_valor = objcalculoVariableE.validarValorVariabvle(cal_id, var_id);
                            List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                            Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                            lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, 0);
                            //if (lstCvT.Count == 0)
                            //{
                            // Variable se encuentra registrada
                            // En tabla tab_calculo_variable
                            if (lstCvT.Count == 0)
                            {
                                // No esta
                                // Insert
                                List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                Calculo_Variable calculoVariable = new Calculo_Variable();
                                calculoVariable.Cav_id = System.Convert.ToInt64(0);
                                calculoVariable.Cal_id = System.Convert.ToInt64(cal_id);
                                calculoVariable.Var_id = System.Convert.ToInt64(var_id);
                                calculoVariable.Mon_id = System.Convert.ToInt64(2);
                                //calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                if (umd_id == 13)
                                {
                                    calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                }
                                else
                                {
                                    calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                }
                                calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                calculoVariable.Cam_id = System.Convert.ToInt64(0);

                                // Campos no necesarios
                                calculoVariable.Pro_id = System.Convert.ToInt64(0);
                                calculoVariable.Mer_id = System.Convert.ToInt64(0);
                                calculoVariable.Umd_id = System.Convert.ToInt64(0);
                                //

                                calculoVariable.Cav_tipo = System.Convert.ToString("P");
                                calculoVariable.Pex_id = System.Convert.ToInt64(0);
                                lstCalculoVariable2.Add(calculoVariable);

                                // Save data from Usuario
                                inserted = calculoVariable.insert(lstCalculoVariable2);
                                if (inserted == 0)
                                {
                                    throw new Exception("Hubo error en el registro Tabla Calculo Variable");
                                }
                                break;
                            }
                            else
                            {
                                // Esta registrada
                                //Update
                                lstCvT.ForEach(delegate(Calculo_Variable cv)
                                {
                                    List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                                    Calculo_Variable calculoVariable = new Calculo_Variable();
                                    calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                                    calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                                    calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                                    calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                                    //if (cv.Cav_tipo != "T")
                                    //{
                                    //    calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    //}
                                    //else
                                    //{
                                    //    if (sVariable.Equals("PPijk"))
                                    //        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    //    else if (sVariable.Equals("qbt"))
                                    //        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    //    else
                                    //        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(cv.Cav_valor), 8);
                                    //}
                                    if (umd_id == 13)
                                    {
                                        if (cv.Pex_id == 0)
                                        {
                                            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                        }
                                        else
                                        {
                                            if (sVariable.Equals("PPijkt"))
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                            else if (sVariable.Equals("qbt"))
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                                            else
                                                calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                        }
                                    }
                                    else
                                    {

                                        calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    }
                                    calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                                    calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                                    calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                                    calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                                    calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                                    calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                                    calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                                    lstCalculoVariable2.Add(calculoVariable);
                                    // Save data from Usuario
                                    updated = calculoVariable.update(lstCalculoVariable2);
                                    if (updated == 0)
                                    {
                                        throw new Exception("Hubo error en la actualización tabla Calculo Variable");
                                    }
                                });
                                break;
                            }
                            //}
                            //else
                            //{
                            //    // Esta registrada
                            //    //Update
                            //    lstCvT.ForEach(delegate(Calculo_Variable cv)
                            //    {
                            //        List<Calculo_Variable> lstCalculoVariable2 = new List<Calculo_Variable>();
                            //        Calculo_Variable calculoVariable = new Calculo_Variable();
                            //        calculoVariable.Cav_id = System.Convert.ToInt64(cv.Cav_id);
                            //        calculoVariable.Cal_id = System.Convert.ToInt64(cv.Cal_id);
                            //        calculoVariable.Var_id = System.Convert.ToInt64(cv.Var_id);
                            //        calculoVariable.Mon_id = System.Convert.ToInt64(cv.Mon_id);
                            //        if (umd_id == 13)
                            //        {
                            //            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor) * 100, 8);
                            //        }
                            //        else
                            //        {
                            //            calculoVariable.Cav_valor = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                            //        }
                            //        calculoVariable.Cav_estado = System.Convert.ToInt64(1);
                            //        calculoVariable.Cam_id = System.Convert.ToInt64(cv.Cam_id);
                            //        calculoVariable.Pro_id = System.Convert.ToInt64(cv.Pro_id);
                            //        calculoVariable.Mer_id = System.Convert.ToInt64(cv.Mer_id);
                            //        calculoVariable.Umd_id = System.Convert.ToInt64(cv.Umd_id);
                            //        calculoVariable.Cav_tipo = System.Convert.ToString(cv.Cav_tipo);
                            //        calculoVariable.Pex_id = System.Convert.ToInt64(cv.Pex_id);
                            //        lstCalculoVariable2.Add(calculoVariable);
                            //        // Save data from Usuario
                            //        updated = calculoVariable.update(lstCalculoVariable2);
                            //        if (updated == 0)
                            //        {
                            //            throw new Exception("Hubo error en la actualización tabla Calculo Variable");
                            //        }
                            //    });
                            //    break;
                            //}
                        }
                        else
                        {
                            // NO Es fórmula
                        }
                    }
                }





                // GUARDADO ESPECIAL
                // DE ACUERDO AL TIPO DE CÁLCULO
                switch (tcl_id)
                {

                    // RECALCULO
                    case 1:

                        /* DEPRECIACIÓN ACUMULADA */
                        // Guardar Acumulados de Depreciación, etc.
                        // Buscar Variables de acumulación
                        // Escoger Variable
                        lstCalculos.Refresh();
                        // **********************************
                        // Recuperar Variables y Almacenar
                        // **********************************
                        for (int i = 0; i < lstCalculos.Items.Count; i++)
                        {
                            //MessageBox.Show(lstCalculos.Items[i].ToString(), "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // Escoger Variable
                            sVariable = lstCalculos.Items[i].ToString();
                            if (sVariable.Length > 0)
                            {
                                int k = sVariable.IndexOf("=");
                                if (k <= -1)
                                {
                                }
                                else
                                {
                                    dValor = sVariable.Substring(k + 1).Trim();
                                    sVariable = sVariable.Substring(0, k).Trim();
                                }

                                if (sVariable.Equals("Dt"))
                                {
                                    ctt_depacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    cal_depacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                }

                                if (sVariable.Equals("GDTt"))
                                {
                                    ctt_acugantit = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    cal_acugantit = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                }

                                if (sVariable.Equals("It"))
                                {
                                    ctt_invacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                    cal_invacuma = decimal.Round(System.Convert.ToDecimal(dValor), 8);
                                }
                                if (sVariable.Equals("GRt"))
                                {
                                    cal_costrecuacu = decimal.Round(Convert.ToDecimal(dValor), 8);
                                }
                                if (sVariable.Equals("SIMPtP"))
                                {
                                    cal_acuimptit = decimal.Round(Convert.ToDecimal(dValor), 8);
                                    ctt_acuimptit = decimal.Round(Convert.ToDecimal(dValor), 8);
                                }
                            }
                        }



                        /* TOTAL EN TABLA CALCULO */
                        // Guardar total                    
                        // Tabla Calculo Variable
                        string sVariableAux2;
                        string variable2;
                        decimal valor2;
                        for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                        {
                            sVariableAux2 = lstCalculos.Items[m].ToString();
                            if (sVariableAux2.Length > 0)
                            {
                                int l = sVariableAux2.IndexOf("=");
                                if (l <= -1)
                                {
                                }
                                else
                                {
                                    variable2 = sVariableAux2.Substring(0, l - 1).Trim();
                                    valor2 = System.Convert.ToDecimal(sVariableAux2.Substring(l + 1).Trim());
                                    if (variable2.Equals("RTTt"))
                                    {
                                        cal_id = objSession.CAL_ID;
                                        // Fill data      
                                        List<Calculo> lstCalculo = new List<Calculo>();
                                        List<Calculo> lstCalculo2 = new List<Calculo>();
                                        CalculoObject objCalculoObject = new CalculoObject();
                                        lstCalculo = objCalculoObject.listCalculo(cal_id);
                                        lstCalculo.ForEach(delegate(Calculo c)
                                        {
                                            Calculo calculo = new Calculo();
                                            calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                            calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                            calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                            calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                            calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                            calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                            calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                            calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor2), 8);
                                            calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                                            calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                            // Acumulados a esa año y mes de cálculo
                                            calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                            calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                            calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                            calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                            calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(cal_costrecuacu), 8); 

                                            //
                                            // MODIFIED: CASTELLON
                                            //
                                            if (rbttnSiEs.Checked == true)
                                                calculo.Cal_cammar = System.Convert.ToInt32(1);
                                            else
                                                calculo.Cal_cammar = System.Convert.ToInt32(0);

                                            lstCalculo2.Add(calculo);
                                        });

                                        // Save data from Usuario
                                        Calculo objCalculo = new Calculo();
                                        inserted = objCalculo.update(lstCalculo2);
                                        if (inserted == 0)
                                        {
                                            throw new Exception("Hubo error en la actualización Tabla Calculo TOTAL");
                                            //this.Close();
                                        }
                                    }
                                }
                            }
                        }


                        /* SUBTOTALES A CÁLCULO */
                        // Guardar Acumulados de Depreciación, etc.
                        CalculoObject objCalculoObject2 = new CalculoObject();
                        List<Calculo> lstCalculo3 = new List<Calculo>();
                        List<Calculo> lstCalculo4 = new List<Calculo>();
                        lstCalculo3 = objCalculoObject2.listCalculo(cal_id);
                        //Update
                        lstCalculo3.ForEach(delegate(Calculo c)
                        {

                            Calculo calculo = new Calculo();
                            calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                            calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                            calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                            calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                            calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                            calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                            calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                            calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(c.Cal_valor), 8);
                            calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                            calculo.Cal_estado = System.Convert.ToInt32(c.Cal_estado);
                            // Acumulados a esa año y mes de cálculo
                            calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(ctt_depacuma), 8);
                            calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(ctt_acugantit), 8);
                            calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(ctt_invacuma), 8);
                            calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(ctt_acuimptit), 8);
                            calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                            //
                            // MODIFIED: CASTELLON
                            //
                            if (rbttnSiEs.Checked == true)
                                calculo.Cal_cammar = System.Convert.ToInt32(1);
                            else
                                calculo.Cal_cammar = System.Convert.ToInt32(0);

                            //calculo.Cal_proces = 1;
                            lstCalculo4.Add(calculo);
                        });

                        // Save data from Usuario
                        updated = objCalculoObject2.update(lstCalculo4);
                        if (updated == 0)
                        {
                            throw new Exception("Hubo error en la actualización Tabla Calculo SUBTOTALES ACUMULADOS");
                        }

                        /* TOTALES A CONTRATO */
                        // Guardar Acumulados de Depreciación, etc.
                        ContratoObject objContratoObject = new ContratoObject();
                        List<Contrato> lstContrato = new List<Contrato>();
                        List<Contrato> lstContrato2 = new List<Contrato>();
                        lstContrato = objContratoObject.listContrato(ctt_id);
                        //Update
                        lstContrato.ForEach(delegate(Contrato c)
                        {
                            Contrato contrato = new Contrato();
                            contrato.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                            contrato.Suc_id = System.Convert.ToInt64(c.Suc_id);
                            contrato.Ctt_codigo = System.Convert.ToString(c.Ctt_codigo);
                            contrato.Ctt_nombre = System.Convert.ToString(c.Ctt_nombre);
                            contrato.Ctt_periodo = System.Convert.ToString(c.Ctt_periodo);
                            contrato.Ctt_fecini = Convert.ToDateTime(c.Ctt_fecini);
                            contrato.Ctt_fecfin = Convert.ToDateTime(c.Ctt_fecfin);
                            contrato.Ctt_estado = System.Convert.ToInt64(c.Ctt_estado);
                            contrato.Usu_id = System.Convert.ToInt32(c.Usu_id);
                            //
                            contrato.Ctt_depacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacu), 8);

                            ///acumulados 
                            contrato.Ctt_depacuma = decimal.Round(System.Convert.ToDecimal(ctt_depacuma + c.Ctt_depacuma), 8);
                            contrato.Ctt_acugantit = decimal.Round(System.Convert.ToDecimal(ctt_acugantit + c.Ctt_acugantit), 8);
                            contrato.Ctt_invacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacu), 8);
                            contrato.Ctt_invacuma = decimal.Round(System.Convert.ToDecimal(ctt_invacuma + c.Ctt_invacuma), 8);
                            
                            contrato.Ctt_acuimptit = decimal.Round(System.Convert.ToDecimal(ctt_acuimptit + c.Ctt_acuimptit), 8);
                            contrato.Ctt_invneta = decimal.Round(System.Convert.ToDecimal(c.Ctt_invneta), 8);
                            // 
                            contrato.Ctt_lrc = decimal.Round(System.Convert.ToDecimal(c.Ctt_lrc), 8);
                            contrato.Ctt_vhiena = decimal.Round(System.Convert.ToDecimal(c.Ctt_vhiena), 8);
                            contrato.Ctt_cmp = System.Convert.ToInt64(c.Ctt_cmp);
                            contrato.Ctt_icpmp = decimal.Round(System.Convert.ToDecimal(c.Ctt_icpmp), 8);
                            contrato.Ctt_pppvgnpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvgnpf), 8);
                            contrato.Ctt_pppvhlpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvhlpf), 8);
                            contrato.Ctt_produccion = Convert.ToInt64(c.Ctt_produccion);
                            contrato.Ctt_costrecuacu = decimal.Round(Convert.ToDecimal(cal_costrecuacu),8);
                            contrato.Ctt_orden = Convert.ToInt32(c.Ctt_orden);

                            lstContrato2.Add(contrato);
                        });

                        // Save data from Usuario
                        updated = objContratoObject.update(lstContrato2);
                        if (updated == 0)
                        {
                            throw new Exception("Hubo error en la actualización Tabla Contratos TOTAL ACUMULADOS");
                        }
                        break;




                    // A CUENTA
                    case 2:
                        // Registrar Calculo Variable
                        if (flagajustado == true)
                        {
                            // Se ajustaron variables
                            string sVariableAux;
                            string variable;
                            decimal valor;
                            for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                            {
                                sVariableAux = lstCalculos.Items[m].ToString();
                                if (sVariableAux.Length > 0)
                                {
                                    int l = sVariableAux.IndexOf("=");
                                    if (l <= -1)
                                    {
                                    }
                                    else
                                    {
                                        variable = sVariableAux.Substring(0, l - 1).Trim();
                                        valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                        if (variable.Equals("RTCIj"))
                                        {
                                            //Session objSession = new Session();
                                            cal_id = objSession.CAL_ID;

                                            // Fill data      
                                            List<Calculo> lstCalculo = new List<Calculo>();
                                            List<Calculo> lstCalculo2 = new List<Calculo>();
                                            CalculoObject objCalculoObject = new CalculoObject();
                                            lstCalculo = objCalculoObject.listCalculo(cal_id);
                                            lstCalculo.ForEach(delegate(Calculo c)
                                            {
                                                Calculo calculo = new Calculo();
                                                calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor), 8);
                                                calculo.Cal_valorajustado = decimal.Round(System.Convert.ToDecimal(c.Cal_valorajustado), 8);
                                                calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                //
                                                // Acumulados a esa año y mes de cálculo
                                                calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                //
                                                // MODIFIED: CASTELLON
                                                //
                                                if (rbttnSiEs.Checked == true)
                                                    calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                else
                                                    calculo.Cal_cammar = System.Convert.ToInt32(0);

                                                //calculo.Cal_proces = 1;
                                                lstCalculo2.Add(calculo);
                                            });

                                            // Save data from Usuario
                                            Calculo objCalculo = new Calculo();
                                            inserted = objCalculo.update(lstCalculo2);
                                            if (inserted == 0)
                                            {
                                                throw new Exception("Hubo error en la inserción Tabla Cálculo: Variable RTCIj");
                                                //this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // No se ajustaron variables
                            string sVariableAux;
                            string variable;
                            decimal valor;
                            for (int m = 0; m <= lstCalculos.Items.Count - 1; m++)
                            {
                                sVariableAux = lstCalculos.Items[m].ToString();
                                if (sVariableAux.Length > 0)
                                {
                                    int l = sVariableAux.IndexOf("=");
                                    if (l <= -1)
                                    {
                                    }
                                    else
                                    {
                                        variable = sVariableAux.Substring(0, l - 1).Trim();
                                        valor = System.Convert.ToDecimal(sVariableAux.Substring(l + 1).Trim());
                                        if (variable.Equals("RTCI"))
                                        {
                                            //Session objSession = new Session();
                                            cal_id = objSession.CAL_ID;

                                            // Fill data      
                                            List<Calculo> lstCalculo = new List<Calculo>();
                                            List<Calculo> lstCalculo2 = new List<Calculo>();
                                            CalculoObject objCalculoObject = new CalculoObject();
                                            lstCalculo = objCalculoObject.listCalculo(cal_id);
                                            lstCalculo.ForEach(delegate(Calculo c)
                                            {
                                                Calculo calculo = new Calculo();
                                                calculo.Cal_id = System.Convert.ToInt64(c.Cal_id);
                                                calculo.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                                                calculo.Cal_fecha = System.Convert.ToDateTime(DateTime.Now);
                                                calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                                                calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                                                calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                                                calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                                                calculo.Cal_valor = decimal.Round(System.Convert.ToDecimal(valor), 8);
                                                calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                                                calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
                                                //
                                                calculo.Cal_depacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_depacuma), 8);
                                                calculo.Cal_acugantit = decimal.Round(System.Convert.ToDecimal(c.Cal_acugantit), 8);
                                                calculo.Cal_invacuma = decimal.Round(System.Convert.ToDecimal(c.Cal_invacuma), 8);
                                                calculo.Cal_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Cal_acuimptit), 8);
                                                calculo.Cal_costrecuacu = decimal.Round(System.Convert.ToDecimal(c.Cal_costrecuacu), 8);

                                                //
                                                // MODIFIED: CASTELLON
                                                //
                                                if (rbttnSiEs.Checked == true)
                                                    calculo.Cal_cammar = System.Convert.ToInt32(1);
                                                else
                                                    calculo.Cal_cammar = System.Convert.ToInt32(0);

                                                //calculo.Cal_proces = 1;
                                                lstCalculo2.Add(calculo);
                                            });

                                            // Save data from Usuario
                                            Calculo objCalculo = new Calculo();
                                            inserted = objCalculo.update(lstCalculo2);
                                            if (inserted == 0)
                                            {
                                                throw new Exception("Hubo error en la actualización Tabla Cálculo: Variable RTCIj");
                                                //this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {


            int index = cbofields2.SelectedIndex;
            lblCtt_nombre.Text = lstContrato[index].Ctt_codigo;

            //ctt_id = ContratoController.FindContratoByCtt_Name(lstContrato[index].Ctt_nombre)[0].Ctt_id;
            // Cargar Campos
            List<Campo> lstCampo = new List<Campo>();
            lstCampo = CampoController.GetListCamposContrato(lstContrato[index].Ctt_id);
            if (lstCampo.Count == 0)
            {
                lstCampos.Items.Clear();
            }
            else
            {
                lstCampos.Items.Clear();
                lstCampo.ForEach(delegate(Campo c)
                {
                    lstCampos.Items.Add(c.Cam_nombre);
                });
                flag = true;
            }


            switch (System.Convert.ToInt64(cbofields1.SelectedValue))
            {
                // Recálculo
                case 1:
                    if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                    {
                        // Procesar por Campo
                        buscarDatos();
                    }
                    break;

                // A cuenta
                case 2:
                    if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                    {
                        buscar();
                    }
                    break;

            }
            lstCampos.SelectedIndex = 0;
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = cbofields2.SelectedIndex;
            lblCtt_nombre.Text = lstContrato[index].Ctt_codigo;

            //ctt_id = ContratoController.FindContratoByCtt_Name(lstContrato[index].Ctt_nombre)[0].Ctt_id;
            // Cargar Campos
            List<Campo> lstCampo = new List<Campo>();
            lstCampo = CampoController.GetListCamposContrato(lstContrato[index].Ctt_id);
            if (lstCampo.Count == 0)
            {
                lstCampos.Items.Clear();
            }
            else
            {
                lstCampos.Items.Clear();
                lstCampo.ForEach(delegate(Campo c)
                {
                    lstCampos.Items.Add(c.Cam_nombre);
                });
                flag = true;
            }


            switch (System.Convert.ToInt64(cbofields1.SelectedValue))
            {
                // Recálculo
                case 1:
                    if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                    {
                        // Procesar por Campo
                        buscarDatos();
                    }
                    break;

                // A cuenta
                case 2:
                    if (cbxAnio.Text != "" && cbxMes.SelectedItem.ToString() != "")
                    {
                        buscar();
                    }
                    break;

            }
            lstCampos.SelectedIndex = 0;
        }



        private void btnReprosesar_Click(object sender, EventArgs e)
        {

            switch (System.Convert.ToInt64(cbofields1.SelectedValue))
            {
                // Recálculo
                case 1:
                    // Procesar por Campo              
                    procesarRecalculo();
                    break;

                // A cuenta
                case 2:
                    procesarACuentaUltimo();
                    break;
            }



        }


        private void procesarRecalculo()
        {
            Calculo_VariableObject objCalculo_VariableObject = new Calculo_VariableObject();
            string sCampo = "";
            long updated = 0;
            decimal cal_depacuma = 0;
            decimal cal_acugantit = 0;
            decimal cal_invacuma = 0;
            decimal cal_costrecuacu = 0;


            ///recupero los valor del mes y año del contrato a ser reprosesado
            CalculoObject objCalculoObject = new CalculoObject();
            Calculo calculo = new Calculo();
            calculo = objCalculoObject.listCalculoGDT_1ByMesAndAnio(ctt_id, ani_id, mes_id, tcl_id);
            cal_depacuma = calculo.Cal_depacuma;
            cal_acugantit = calculo.Cal_acugantit;
            cal_costrecuacu = calculo.Cal_costrecuacu;
            cal_invacuma = calculo.Cal_invacuma;


            ///resto los valores cal_depacuma, cal_acugantit, cal_invacuma al la tabla 
            ///de contratos y resto los valores.
            ContratoObject objContratoObject = new ContratoObject();
            List<Contrato> lstContrato = new List<Contrato>();
            List<Contrato> lstContrato2 = new List<Contrato>();
            lstContrato = objContratoObject.listContrato(ctt_id);
            //Update
            lstContrato.ForEach(delegate(Contrato c)
            {
                Contrato contrato = new Contrato();
                contrato.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
                contrato.Suc_id = System.Convert.ToInt64(c.Suc_id);
                contrato.Ctt_codigo = System.Convert.ToString(c.Ctt_codigo);
                contrato.Ctt_nombre = System.Convert.ToString(c.Ctt_nombre);
                contrato.Ctt_periodo = System.Convert.ToString(c.Ctt_periodo);
                contrato.Ctt_fecini = Convert.ToDateTime(c.Ctt_fecini);
                contrato.Ctt_fecfin = Convert.ToDateTime(c.Ctt_fecfin);
                contrato.Ctt_estado = System.Convert.ToInt64(c.Ctt_estado);
                contrato.Usu_id = System.Convert.ToInt32(c.Usu_id);
                //
                contrato.Ctt_depacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacu), 8);

                ///acumulados 
                contrato.Ctt_depacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_depacuma - cal_depacuma), 8);
                contrato.Ctt_acugantit = decimal.Round(System.Convert.ToDecimal(c.Ctt_acugantit - cal_acugantit), 8);
                contrato.Ctt_invacu = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacu), 8);
                contrato.Ctt_invacuma = decimal.Round(System.Convert.ToDecimal(c.Ctt_invacuma - cal_invacuma), 8);
                
                contrato.Ctt_acuimptit = decimal.Round(System.Convert.ToDecimal(c.Ctt_acuimptit), 8);
                contrato.Ctt_invneta = decimal.Round(System.Convert.ToDecimal(c.Ctt_invneta), 8);
                // 
                contrato.Ctt_lrc = decimal.Round(System.Convert.ToDecimal(c.Ctt_lrc), 8);
                contrato.Ctt_vhiena = decimal.Round(System.Convert.ToDecimal(c.Ctt_vhiena), 8);
                contrato.Ctt_cmp = System.Convert.ToInt64(c.Ctt_cmp);
                contrato.Ctt_icpmp = decimal.Round(System.Convert.ToDecimal(c.Ctt_icpmp), 8);
                contrato.Ctt_pppvgnpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvgnpf), 8);
                contrato.Ctt_pppvhlpf = decimal.Round(System.Convert.ToDecimal(c.Ctt_pppvhlpf), 8);
                contrato.Ctt_produccion = Convert.ToInt64(c.Ctt_produccion);
                contrato.Ctt_costrecuacu = Convert.ToDecimal(c.Ctt_costrecuacu);
                contrato.Ctt_orden = Convert.ToInt32(c.Ctt_orden);

                lstContrato2.Add(contrato);
            });

            // Save data from Usuario
            updated = objContratoObject.update(lstContrato2);
            if (updated == 0)
            {
                throw new Exception("Hubo error en la actualización Tabla Contratos TOTAL ACUMULADOS");
            }



            // Inicio
            if (validarVariables().Equals(""))
            {
            }
            else
            {

                // hourglass cursor
                Cursor.Current = Cursors.WaitCursor;
                lblProcesando.Visible = false;
                progressBar1.Visible = false;
                timer1.Enabled = true;

                int z = 0;
                try
                {
                    CalculoObject calculoObject = new CalculoObject();

                    if (lstCampos.Items.Count > 1)
                    {
                        flagCalculo = true;

                        // Procesar Lista
                        for (z = 0; z <= lstCampos.Items.Count - 1; z++)
                        {
                            lstCalculos.Dispose();

                            #region Asiganción de la lista lstcalculos

                            lstCalculos = new ListBox();
                            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                            this.lstCalculos.Name = "lstCalculos";
                            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                            this.lstCalculos.TabIndex = 6;
                            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                            lstCalculos.Visible = true;
                            lstCalculos.Show();
                            lstCalculos.Refresh();

                            this._Frame1_0.Controls.Add(this.lstCalculos);


                            #endregion

                            #region asignacion de la lista de formulas

                            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                            this.lstFormulas.Name = "lstFormulas";
                            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                            this.lstFormulas.TabIndex = 10;
                            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                            this._Frame1_1.Controls.Add(this.lstFormulas);


                            #endregion

                            #region limpieza del proceso por completo

                            process = new MathProcessor();

                            #endregion

                            //posicion del campo
                            lstCampos.SelectedIndex = z;
                            lstCampos.Refresh();


                            // Recuperar Campo Id
                            sCampo = lstCampos.Items[z].ToString();
                            Campo campo = new Campo();
                            campo = CampoController.SerchCampoByName(sCampo);
                            cam_id = campo.Cam_id;

                            decimal suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                            if (suma > 0)
                            {

                                // Procesar por campo

                                buscarDatos();
                                procesarDetalle();
                                guardar();

                                //progressBar1.PerformStep();

                            }

                        }
                        if (lstCampos.Items.Count == z)
                        {
                            lstCalculos.Dispose();

                            #region Asiganción de la lista lstcalculos

                            lstCalculos = new ListBox();
                            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                            this.lstCalculos.Name = "lstCalculos";
                            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                            this.lstCalculos.TabIndex = 6;
                            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                            lstCalculos.Visible = true;
                            lstCalculos.Show();
                            lstCalculos.Refresh();
                            this._Frame1_0.Controls.Add(this.lstCalculos);
                            #endregion

                            #region asignacion de la lista de formulas

                            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                            this.lstFormulas.Name = "lstFormulas";
                            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                            this.lstFormulas.TabIndex = 10;
                            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                            this._Frame1_1.Controls.Add(this.lstFormulas);


                            #endregion

                            #region limpieza del proceso por completo

                            process = new MathProcessor();

                            #endregion

                            BuscarDatosTotales();
                            procesarDetalle();
                            guardarTotales();
                        }
                        lstCampos.SelectedIndex = 0;
                    }

                    else
                    {
                        lstCalculos.Dispose();

                        #region Asiganción de la lista lstcalculos

                        lstCalculos = new ListBox();
                        this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
                        this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
                        this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
                        this.lstCalculos.Location = new System.Drawing.Point(17, 22);
                        this.lstCalculos.Name = "lstCalculos";
                        this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                        this.lstCalculos.Size = new System.Drawing.Size(281, 290);
                        this.lstCalculos.TabIndex = 6;
                        this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
                        lstCalculos.Visible = true;
                        lstCalculos.Show();
                        lstCalculos.Refresh();
                        this._Frame1_0.Controls.Add(this.lstCalculos);
                        #endregion

                        #region asignacion de la lista de formulas

                        this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
                        this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
                        this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
                        this.lstFormulas.Location = new System.Drawing.Point(17, 22);
                        this.lstFormulas.Name = "lstFormulas";
                        this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
                        this.lstFormulas.Size = new System.Drawing.Size(545, 225);
                        this.lstFormulas.TabIndex = 10;
                        this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);


                        this._Frame1_1.Controls.Add(this.lstFormulas);


                        #endregion

                        #region limpieza del proceso por completo

                        process = new MathProcessor();

                        #endregion

                        flagCalculo = false;
                        decimal suma = objCalculo_VariableObject.ValidarSumaCampo(ctt_id, cam_id, mes_id, ani_id);
                        if (suma > 0)
                        {
                            buscarDatos();
                            procesarDetalle();
                            guardar();
                        }
                    }
                    MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo error en el procesamiento del campo: " + sCampo + ". \n" + ex.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                progressBar1.Visible = false;
                lblProcesando.Visible = false;
            }
        }

        private void radbttnNoEs_CheckedChanged(object sender, EventArgs e)
        {
            if (rbttnSiEs.Checked == true)
            {
                radbttnNoEs.Checked = false;
            }
        }

        private void rbttnSiEs_CheckedChanged(object sender, EventArgs e)
        {
            if (radbttnNoEs.Checked == true)
                rbttnSiEs.Checked = false;
        }

        /// <summary>
        /// funcion que busca las condiciones por contrato
        /// </summary>
        /// 
        private decimal ContratoCondicionTiempoGracia(long _ctt_id)
        {
            ContratoCondicionObject ContratoCondi = new ContratoCondicionObject();
            List<ContratoCondicion> listaContratoCondiciones = ContratoCondi.listContratoCondicionByCon(_ctt_id, 1);
            int _ani_id = 0;
            int _mes_id = 0;
            int _dias_difer = 0;
            int _mes_exp = 0;
            int _ani_exp = 0;
            decimal _indiceB = 0;
            long _oper = 0;
            long _ccn_id = 0;
            decimal _result = 0;
            if (listaContratoCondiciones.Count != 0)
            {
                _ani_id = listaContratoCondiciones[0].Ccn_aniofin;
                _mes_id = listaContratoCondiciones[0].Ccn_mesfin;
                _dias_difer = listaContratoCondiciones[0].Ccn_diasdifer;
                _ccn_id = listaContratoCondiciones[0].Ccn_id;
                _mes_exp = listaContratoCondiciones[0].Ccn_mesiniexp;
                _ani_exp = listaContratoCondiciones[0].Ccn_anioiniexp;

                if (_mes_exp != 0 && _ani_exp != 0)
                {
                    _ani_id = _ani_exp;
                    _mes_id = _mes_exp;
                }

                if (ani_id < _ani_id)
                {
                    //sVariable = "qbt";
                    _result = 0;

                    List<ContratoCondicion> listaContratoCondiciones2 = ContratoCondi.listContratoCondicionByCon(_ctt_id, 2);
                    if (listaContratoCondiciones2.Count != 0)
                    {
                        _indiceB = listaContratoCondiciones2[0].Ccn_valorb;
                        _oper = listaContratoCondiciones2[0].Sim_id;

                        switch (_oper)
                        {

                            case 1:
                                if (indiceb == _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }

                                break;
                            case 2:
                                if (indiceb > _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 3:
                                if (indiceb < _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 4:
                                if (indiceb >= _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 5:
                                if (indiceb <= _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                        }

                    }

                }
                else if (ani_id == _ani_id && mes_id < _mes_id)
                {
                    //sVariable = "qbt";
                    _result = 0;

                    List<ContratoCondicion> listaContratoCondiciones2 = ContratoCondi.listContratoCondicionByCon(_ctt_id, 2);
                    if (listaContratoCondiciones2.Count != 0)
                    {
                        _indiceB = listaContratoCondiciones2[0].Ccn_valorb;
                        _oper = listaContratoCondiciones2[0].Sim_id;

                        switch (_oper)
                        {

                            case 1:
                                if (indiceb == _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }

                                break;
                            case 2:
                                if (indiceb > _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 3:
                                if (indiceb < _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 4:
                                if (indiceb >= _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                            case 5:
                                if (indiceb <= _indiceB)
                                {
                                    _result = -1;
                                    updateFechaB(_ccn_id, Convert.ToInt32(mes_id), Convert.ToInt32(ani_id));
                                }
                                break;
                        }

                    }

                }
                else if (ani_id == _ani_id && mes_id == _mes_id)
                {

                    //sVariable = "qbt";
                    int _dias = DateTime.DaysInMonth(_ani_id, _mes_id);
                    decimal resultAux = qbt / _dias;
                    resultAux = resultAux * _dias_difer;
                    _result = resultAux;
                }
                else
                {
                    _result = -1;
                }
            }
            else
            {

                _result = -2;
            }
            return _result;
        }

        private bool updateFechaB(long ccn_upt, int mes_upt, int anio_upt)
        {
            List<ContratoCondicion> lstContrato_Condicion = new List<ContratoCondicion>();
            List<ContratoCondicion> lstContrato_Condicion2 = new List<ContratoCondicion>();
            ContratoCondicionObject objContrato_CondicionObject = new ContratoCondicionObject();
            lstContrato_Condicion = objContrato_CondicionObject.listContratoCondicionById(ccn_upt);
            bool resp_upt = false;
            if (lstContrato_Condicion.Count != 0)
            {
                lstContrato_Condicion.ForEach(delegate(ContratoCondicion r)
                {
                    lstContrato_Condicion2.Add(new ContratoCondicion(r.Ccn_id, r.Ctt_id, r.Con_id, r.Sim_id, mes_upt, anio_upt, r.Ccn_mesfin, r.Ccn_aniofin, r.Ccn_diasdifer, r.Ccn_valorb, 1));
                });
            }
            if (objContrato_CondicionObject.update(lstContrato_Condicion2) != 0)
            {
                resp_upt = true;
            }

            return resp_upt;
        }

    }
}