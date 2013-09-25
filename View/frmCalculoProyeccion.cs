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
using ypfbApplication.View;

namespace View
{
    public partial class frmCalculoProyeccion : Form
    {
        long cal_id;
        long ctt_id;
        long tcl_id;
        long anii_id;
        long mesi_id;
        long var_id;
        long cam_id;

        int count = 0;
        bool flag;
        bool flag1;
        bool flagajustado = false;

        // qbt
        decimal mpcdia = 0;
        decimal bbldia = 0;
        decimal indiceb = 0;
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
        /// Method frmCalculoProyeccion
        /// </summary>
        public frmCalculoProyeccion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmCalculoProyeccion_Load
        /// </summary>
        private void frmCalculoProyeccion_Load(object sender, EventArgs e)
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
                if (i<=-1){
                }else{
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
              lstFormula = objFormulaObject.listFormulaPorCodigo(sFormula);
              lstFormula.ForEach(delegate(Formula f)
              {
                txtFormulaDescripcion.Text = f.For_nombre;
              });
            }

        }

        /// <summary>
        /// Method cbofields2_SelectedIndexChanged
        /// </summary>
        private void cbofields2_SelectedIndexChanged(object sender, EventArgs e)
        {
          int index = cbofields2.SelectedIndex;
          lblCtt_nombre.Text = lstContrato[index].Ctt_codigo;
        }

        /// <summary>
        /// Method ChangeOnList
        /// </summary>
        private void ChangeOnList(string sName , string sValue )
        {
            int i, j;
            string sVariable; 
        
            for( i = 0; i<=  lstCalculos.Items.Count - 1; i++)
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

            if (i == lstCalculos.Items.Count )
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
          //buscar();
        }


        /// <summary>
        /// Method cmdProcesar_Click
        /// </summary>
        private void cmdProcesar_Click(object sender, EventArgs e)
        {
          procesar();
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
            /**/
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
                  e.Graphics.DrawString(sDescripcion+  "= " + sValor, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
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
          ToolTip toolTip1 = new ToolTip();
          toolTip1.IsBalloon = true;
          toolTip1.ToolTipTitle = "Ayuda";
          toolTip1.UseFading = true;
          toolTip1.UseAnimation = true;

          toolTip1.SetToolTip(this.cbofields1, "Escoger el contrato");
          toolTip1.SetToolTip(this.cbofields2, "Escoger el tipo de proceso cálculo");
          toolTip1.SetToolTip(this.cbxAnioi, "Escoger el año");
          toolTip1.SetToolTip(this.cbxMesf, "Escoger el mes");
          toolTip1.SetToolTip(this.lstCalculos, "Variables del proceso de cálculo escogido");
          toolTip1.SetToolTip(this.lstFormulas, "Fórmulas de proceso del cálculo escogido");
          toolTip1.SetToolTip(this.txtDescripcionVariable, "Descripción de la Variable");
          toolTip1.SetToolTip(this.txtFormulaDescripcion, "Descripción de la Fórmula");
          toolTip1.SetToolTip(this.cbTest, "Procesar la fórmula");

          toolTip1.SetToolTip(this.txtName, "Nombre de la Variable");
          toolTip1.SetToolTip(this.txtValue, "Nombre de la Fórmula");
          toolTip1.SetToolTip(this.lblResultado, "Resultado del proceso de cálculo de las variables");


          // Vars of Session
          Session objSession = new Session();
          ctt_id = objSession.CTT_ID;
          cal_id = objSession.CAL_ID;
          anii_id = objSession.ANI_ID;
          mesi_id = objSession.MES_ID;
          tcl_id = objSession.TCL_ID;
          
          // Load
          lstContrato = ContratoController.GetListContrato(0);
          cbofields2.DataSource = lstContrato;
          cbofields2.DisplayMember = "Ctt_nombre";
          cbofields2.ValueMember = "Ctt_id";
          cbofields2.Refresh();
          
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
            cbofields1.SelectedIndex = 3;
          }


          // Meses
          foreach (string mes in MESES)
          {
            cbxMesi.Items.Add(mes);
          }
          cbxMesi.SelectedIndex = 0;

          foreach (string mes in MESES)
          {
            cbxMesf.Items.Add(mes);
          }
          cbxMesf.SelectedIndex = 0;

          foreach (string mes in MESES)
          {
            cbxMesiP.Items.Add(mes);
          }
          cbxMesiP.SelectedIndex = 0;

          foreach (string mes in MESES)
          {
            cbxMesfP.Items.Add(mes);
          }
          cbxMesfP.SelectedIndex = 0;

          // Años
          foreach (int anio in ANIOS)
          {
            cbxAnioi.Items.Add(anio);
          }
          cbxAnioi.SelectedIndex = 0;

          foreach (int anio in ANIOS)
          {
              cbxAniof.Items.Add(anio);
          }
          cbxAniof.SelectedIndex = 0;

          foreach (int anio in ANIOS)
          {
            cbxAnioiP.Items.Add(anio);
          }
          cbxAnioiP.SelectedIndex = 0;

          foreach (int anio in ANIOS)
          {
            cbxAniofP.Items.Add(anio);
          }
          cbxAniofP.SelectedIndex = 0;




          buscarContrato();
          lstVariables.Items.Clear();
          List<Variable> lstVariable = new List<Variable>();
          VariableObject objVariableObject = new VariableObject();
          lstVariable = objVariableObject.findByTcl_idNoFormulaP(4);
          if (lstVariable.Count == 0)
          {
            lstVariables.Items.Clear();
          }
          else
          {
            if (lstVariable.Count == 0)
            {
              lstCalculos.Items.Clear();
            }
            else
            {
              lstCalculos.Items.Clear();
              lstVariable.ForEach(delegate(Variable v)
              {
                lstVariables.Items.Add(v.Var_codigo);
              });
              flag = true;
            }
          }


          // Formula
          lstFormulas.Items.Clear();
          List<Formula> lstFormula = new List<Formula>();
          FormulaObject objFormulaObject = new FormulaObject();
          lstFormula = objFormulaObject.listFormulaConTipo(4, 0);
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


        }

        /// <summary>
        /// Method buscarContrato
        /// </summary>
        public void buscarContrato()
        {
          string ctt_nombre = "";
          ContratoObject objContratoObjecto = new ContratoObject();
          List<Contrato> lstContrato = new List<Contrato>();
          lstContrato = objContratoObjecto.listContrato(ctt_id);
          lstContrato.ForEach(delegate(Contrato c)
          {
            ctt_nombre = c.Ctt_nombre;
          });
          cbofields2.SelectedIndex = cbofields2.FindString(ctt_nombre, -1);
          if (mesi_id == 0) mesi_id = 1;
          cbxMesi.Text = MESES[mesi_id - 1];
          cbxAnioi.Text = System.Convert.ToString(anii_id);

          cbxMesf.Text = MESES[mesi_id - 1];
          cbxAniof.Text = System.Convert.ToString(anii_id);

          string tcl_codigo = "";
          Tipo_CalculoObject objTipoCalculoObjecto = new Tipo_CalculoObject();
          List<Tipo_Calculo> lstTipo_Calculo = new List<Tipo_Calculo>();
          lstTipo_Calculo = objTipoCalculoObjecto.listTipoCalculo(tcl_id);
          lstTipo_Calculo.ForEach(delegate(Tipo_Calculo tc)
          {
            tcl_codigo = tc.Tcl_codigo;
          });
          cbofields1.SelectedIndex = cbofields1.FindString(tcl_codigo, -1);

        }



        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscar(long ctt_id, long tcl_id, long ani_id, long mes_id)
        {
          var v_ctt_id = cbofields2.SelectedValue;
          ctt_id = System.Convert.ToInt64(v_ctt_id);
          var v_tcl_id = cbofields1.SelectedValue;
          tcl_id = System.Convert.ToInt64(v_tcl_id);








          // Variables de Cálculo
          lstCalculos.Items.Clear();
          List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
          Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
          lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotal(ctt_id, tcl_id, ani_id, mes_id);
          if (lstCalculoVariable.Count == 0)
          {
            lstFormulas.Items.Clear();
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
              lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
              lstCalculos.Items.Add("LRC" + " = " + c.Ctt_lrc);
            });
          }


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


            // Adicionar a la lista Participación e IDH
            //lstRegalia.ForEach(delegate(Regalia r)
            //{
            //  //Adicionar variables
            //  switch (r.Reg_tipo)
            //  {
            //    case "P":
            //      lstCalculos.Items.Add("Ptgn" + " = " + System.Convert.ToDecimal(r.Reg_gasme + r.Reg_gasmi));
            //      lstCalculos.Items.Add("Ptpcg" + " = " + System.Convert.ToDecimal(r.Reg_crudome + r.Reg_crudomi));
            //      lstCalculos.Items.Add("Ptglp" + " = " + System.Convert.ToDecimal(r.Reg_glp));

            //      break;

            //    case "I":
            //      lstCalculos.Items.Add("IDHtgn" + " = " + System.Convert.ToDecimal(r.Reg_gasme + r.Reg_gasmi));
            //      lstCalculos.Items.Add("IDHtpcg" + " = " + System.Convert.ToDecimal(r.Reg_crudome + r.Reg_crudomi));
            //      lstCalculos.Items.Add("IDHtglp" + " = " + System.Convert.ToDecimal(r.Reg_glp));

            //      break;
            //  }
            //});

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
          int i;
          int j;
          string sVariable = "";
          string sFormula = "";
          decimal result = 0;

          // Procesar Lista
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
                result = Util.diasMes(anii_id, mesi_id);
                break;
            case "B":
              // Almacenar Valor
              indiceb = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              break;

            case "PFGN_dia":
              // Almacenar Valor
              mpcdia = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              break;


            case "PFHL_dia":
              // Almacenar Valor
              bbldia = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              break;

            case "qbt":
              ContratoObject objContratoObject = new ContratoObject();
              // Dea acuerdo al tipo de producción del hidrocarburo del Operador se debe escoger
              // mpcdia ó bbldia
              // Al momento solo mpcdia
              qbt = objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla);
              result = objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla);
              sVariable = "qbt";
              lstCalculos.Items.Add(sVariable + " = " + qbt);
              lstCalculos.Refresh();

              //Cálculo modificado de acuerdo a consulta de Isabel respecto a valores cero de las Tablas de Cálculo
              if (anii_id == 2007 && mesi_id <= 7)
              {
                sVariable = "qbt";
                result = 0;
              }
              break;

            default:
              // PROCESAR CÁLCULO CON FÓRMULAS
              result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              break;
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




        /// <summary>
        /// Method validarProceso
        /// </summary>
        private string validarProceso()
        {
          int i;
          int j;
          int k;

          bool flagProceso = true;
          string sVariable = "";
          string sFormula = "";
          decimal result = 0;

          string sVariablesNegativas = "";

          // Inicializar variables
          //buscar();
          lstCalculos.Refresh();
          lstFormulas.Refresh();
          try
          {
            for (k = 0; k < lstFormulas.Items.Count; k++)
            {
              // Procesar Lista
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
                  sVariable = sFormula.Substring(0, l).Trim();
                  sFormula = sFormula.Substring(l + 1).Trim();
                }
              }

              //
              // PROBAR FÓRMULAS SI LOS RESULTADOS SON NEGATIVOS
              //
              result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
              lblResultado.Text = process.ProcessCondition(sFormula);              
              lstCalculos.Items.Add(sVariable + " = " + lblResultado.Text);
              lstCalculos.Refresh();
              if (result < 0)
              {
                sVariablesNegativas = lblResultado.Text;
                return sVariablesNegativas;
              }

            }
            return sVariablesNegativas;
          }
          catch {
            return sVariablesNegativas;
          }
          
        }




        /// <summary>
        /// Method procesar
        /// </summary>
        private void procesar()
        {
          string sFormula = "";
          string sVariable = "";
          int i;
          int j;
          int k;
          decimal result = 0;
          decimal vp = 0;

          long[] vector = new long[200];


          // Ratios
          long mesir_id = cbxMesi.SelectedIndex + 1;
          long aniir_id = System.Convert.ToInt64(cbxAnioi.Text);          
          long mesfr_id = cbxMesf.SelectedIndex + 1;
          long anifr_id = System.Convert.ToInt64(cbxAniof.Text);

          // Proyección
          long mesiP_id = cbxMesiP.SelectedIndex + 1;
          long aniiP_id = System.Convert.ToInt64(cbxAnioiP.Text);          
          long mesfP_id = cbxMesfP.SelectedIndex + 1;
          long anifP_id = System.Convert.ToInt64(cbxAniofP.Text);

          ctt_id = System.Convert.ToInt64(cbofields2.SelectedValue);

          switch (MessageBox.Show("¿Procesar y guardar la proyección requerida?",
                        "Validación del Sistema",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              // hourglass cursor
              Cursor.Current = Cursors.WaitCursor;
              lblProcesando.Visible = true;
              timer1.Enabled = true;

              lstCalculos.Items.Clear();
              lstCalculos.Refresh();
              lstFormulas.Refresh();
                  
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


              try
              {

                // For externo
                vector = Util.vectorMesAnio(aniiP_id, mesiP_id, anifP_id, mesfP_id);


                // Recoger meses y años
                for (int z = 0; z < vector.Length; z = z + 2)
                {
                  mesi_id = vector[z];
                  anii_id = vector[z + 1];
                  if (mesi_id != 0 && anii_id != 0)
                  {

                    /**/
                    lstCalculos.Items.Clear();
                    /**/

                    // Variables
                    for (i = 0; i <= lstVariables.Items.Count - 1; i++)
                    {
                      sVariable = lstVariables.Items[i].ToString();
                      //
                      // Procesar Proyectar Variable
                      // Calcular con año y meses de los ratios con el tipo de cálculo: RECALCULO
                      tcl_id = 2;
                      vp = this.proyectar(ctt_id, tcl_id, aniir_id, anifr_id, mesir_id, mesfr_id, sVariable);

                      lstCalculos.Items.Add(sVariable + " = " + vp);
                      lstCalculos.Refresh();
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
                            //lstCalculos.Items.Add("DAo" + " = " + c.Ctt_depacu);
                            //lstCalculos.Items.Add("SDt" + " = " + c.Ctt_depacuma);
                            //lstCalculos.Items.Add("SGDTt" + " = " + c.Ctt_acugantit);
                            //lstCalculos.Items.Add("IAo" + " = " + c.Ctt_invacu);
                            //lstCalculos.Items.Add("SIt" + " = " + c.Ctt_invacuma);
                            //lstCalculos.Items.Add("SIMPt" + " = " + c.Ctt_acuimptit);
                            lstCalculos.Items.Add("LRC" + " = " + c.Ctt_lrc);
                        });
                    }


                    /**/
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
                        } // end for

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
                                            if (ibt.Equals("IBt"))
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

                            // A cuenta
                            case "D":
                                // Procesar Lista
                                result = Util.diasMes(anii_id, mesi_id);
                                break;
                            case "B":
                                // Procesar Lista
                                indiceb = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                break;
                            case "PFGNdia":
                                mpcdia = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                break;

                            case "PFHLdia":
                                bbldia = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                break;

                            case "qbt":
                                //
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
                                            if (ibt.Equals("PFGNdia"))
                                            {
                                                mpcdia = ibtvalue;
                                            }
                                        }
                                    }
                                }




                                //ContratoObject objContratoObject = new ContratoObject();
                                // Dea acuerdo al tipo de producción del hidrocarburo del Operador se debe escoger
                                // mpcdia ó bbldia
                                // Al momento solo mpcdia
                                qbt = objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla);
                                result = objContratoObject.buscarIndice(ctt_id, mpcdia, indiceb, tabla);
                                sVariable = "qbt";
                                lstCalculos.Items.Add(sVariable + " = " + qbt);
                                lstCalculos.Refresh();

                                //Cálculo modificado de acuerdo a consulta de Isabel respecto a valores cero de las Tablas de Cálculo
                                if (anii_id == 2007 && mesi_id <= 7)
                                {
                                    sVariable = "qbt";
                                    result = 0;
                                }
                                if (anii_id <= 2011 && ctt_id == 83)
                                {
                                    if (anii_id == 2011 && mesi_id <= 5)
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
                                break;

                            // TODOS LOS CÁLCULOS
                            default:
                                // Procesar Fórmula Automáticamente
                                result = System.Convert.ToDecimal(process.ProcessCondition(sFormula));
                                break;
                        }

                        lstCalculos.Items.Add(sVariable + " = " + result);
                        lstCalculos.Refresh();

                        // Mostrar resultado
                        lblResultado.Text = Util.formatNumber(System.Convert.ToString(result));
                        progressBar1.PerformStep();
                    }
                    /**/


                  }
                  else
                  {
                    if (mesi_id == 0 && anii_id != 0)
                      throw new Exception("Error en el mes");
                    if (mesi_id != 0 && anii_id == 0)
                      throw new Exception("Error en el año");
                    z = vector.Length;
                  }

                  //
                  // Guardar Valores
                  //
                  if (anii_id != 0 && mesi_id != 0)
                  {
                      /**/
                      // Con valores del mes y año actuales
                      guardar(anii_id, mesi_id);
                      /**/
                  }
                } // Siguiente periodo

                progressBar1.Hide();
                lblProcesando.Visible = false;
                MessageBox.Show("Se procesaron todas las fórmulas con éxito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
              }
              catch (Exception e)
              {
                MessageBox.Show("No se procesaron todas las fórmulas con éxito \n Revise las variables de entrada\n" + e.Message , "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void guardar(long ani_id, long mes_id)
        {
          long inserted = 0;
          long updated = 0;
          string sVariable = "";
          string dValor = "";

          // Acumulados
          decimal ctt_depacuma = 0;
          decimal ctt_acugantit = 0;
          decimal ctt_invacuma = 0;


          lstCalculos.Refresh();

            //Consultar si ya existe el calculo
           
          /**/
          CalculoController objCalculoController = new CalculoController();
          // Guardar Tabla Calculo
          List<Calculo> lstAddCalculo = new List<Calculo>();
          lstAddCalculo = objCalculoController.Validar(ctt_id, mes_id, ani_id, 4);
          if (lstAddCalculo.Count == 0)
          {
              Calculo AddCaldulo = new Calculo();
              AddCaldulo.Cal_id = 0;
              AddCaldulo.Ctt_id = ctt_id;
              AddCaldulo.Cal_fecha = DateTime.Now;
              AddCaldulo.Ani_id = ani_id;
              AddCaldulo.Mes_id = mes_id;
              AddCaldulo.Mon_id = 2;
              AddCaldulo.Cal_valor = 0;
              AddCaldulo.Cal_valorajustado = 0;
              AddCaldulo.Tcl_id = 4;
              AddCaldulo.Cal_estado = 1;
              lstAddCalculo.Add(AddCaldulo);
              cal_id = objCalculoController.save(lstAddCalculo);
          }
          else
          {
              cal_id = lstAddCalculo[0].Cal_id;
          }
          /**/
            

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
            }
            if (sVariable.Equals("RTT"))
            {
                //Session objSession = new Session();
                //cal_id = objSession.CAL_ID;

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
                    calculo.Cal_fecha = System.Convert.ToDateTime(c.Cal_fecha);
                    calculo.Ani_id = System.Convert.ToInt64(c.Ani_id);
                    calculo.Mes_id = System.Convert.ToInt64(c.Mes_id);
                    calculo.Mon_id = System.Convert.ToInt64(c.Mon_id);
                    calculo.Tcl_id = System.Convert.ToInt64(c.Tcl_id);
                    calculo.Cal_valor = System.Convert.ToDecimal(dValor);
                    calculo.Cal_valorajustado = System.Convert.ToDecimal(c.Cal_valorajustado);
                    calculo.Cal_estado = System.Convert.ToInt64(c.Cal_estado);
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
            string sFormula = "";
            string sVariableAux = "";

           
                // Preguntar Si esta Registrada
                List<Variable> lstVariable = new List<Variable>();
                VariableObject objVariableObject = new VariableObject();
                lstVariable = objVariableObject.listVariablePorCodigo(sVariable);
                lstVariable.ForEach(delegate(Variable v)
                {
                  var_id = v.Var_id;
                });



                // Determinar si la Variable se encuentra registrada
                List<Calculo_Variable> lstCvT = new List<Calculo_Variable>();
                Calculo_VariableObject objCalculoVariableT = new Calculo_VariableObject();
                lstCvT = objCalculoVariableT.listCalculoVariable(cal_id, var_id, cam_id);
                if (lstCvT.Count == 0)
                {
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
                    MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
                  //break;

                }
                else
                {
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
                      MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  });
                }
          }
                


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


          //// Guardar Variables Acumuladas
          //ContratoObject objContratoObject = new ContratoObject();
          //List<Contrato> lstContrato = new List<Contrato>();
          //List<Contrato> lstContrato2 = new List<Contrato>();
          //lstContrato = objContratoObject.listContrato(ctt_id);
          ////Update
          //lstContrato.ForEach(delegate(Contrato c)
          //{
          //  Contrato contrato = new Contrato();
          //  contrato.Ctt_id = System.Convert.ToInt64(c.Ctt_id);
          //  contrato.Suc_id = System.Convert.ToInt64(c.Suc_id);
          //  contrato.Ctt_codigo = System.Convert.ToString(c.Ctt_codigo);
          //  contrato.Ctt_nombre = System.Convert.ToString(c.Ctt_nombre);
          //  contrato.Ctt_periodo = System.Convert.ToString(c.Ctt_periodo);
          //  contrato.Ctt_fecini = System.Convert.ToString(c.Ctt_fecini);
          //  contrato.Ctt_fecfin = System.Convert.ToString(c.Ctt_fecfin);
          //  contrato.Ctt_estado = System.Convert.ToInt64(c.Ctt_estado);
          //  contrato.Usu_id = System.Convert.ToInt32(c.Usu_id);
          //  //
          //  contrato.Ctt_depacu = System.Convert.ToDecimal(c.Ctt_depacu);
          //  contrato.Ctt_depacuma = System.Convert.ToDecimal(c.Ctt_depacuma + ctt_depacuma);
          //  contrato.Ctt_acugantit = System.Convert.ToDecimal(c.Ctt_acugantit + ctt_acugantit);

          //  contrato.Ctt_invacu = System.Convert.ToDecimal(c.Ctt_invacu);
          //  contrato.Ctt_invacuma = System.Convert.ToDecimal(c.Ctt_invacuma + ctt_invacuma);
          //  contrato.Ctt_acuimptit = System.Convert.ToDecimal(c.Ctt_acuimptit);
          //  contrato.Ctt_invneta = System.Convert.ToDecimal(c.Ctt_invneta);
          //  // 
          //  contrato.Ctt_lrc = System.Convert.ToDecimal(c.Ctt_lrc);
          //  contrato.Ctt_vhiena = System.Convert.ToDecimal(c.Ctt_vhiena);
          //  contrato.Ctt_cmp = System.Convert.ToInt64(c.Ctt_cmp);
          //  contrato.Ctt_icpmp = System.Convert.ToDecimal(c.Ctt_icpmp);
          //  contrato.Ctt_pppvgnpf = System.Convert.ToDecimal(c.Ctt_pppvgnpf);
          //  contrato.Ctt_pppvhlpf = System.Convert.ToDecimal(c.Ctt_pppvhlpf);
          //  lstContrato2.Add(contrato);
          //});

          //// Save data from Usuario
          //updated = objContratoObject.update(lstContrato2);
          //if (updated == 0)
          //{
          //}
          //else
          //{
          //}


          cal_id = 0;

        }








      
      
      
        /// <summary>
        /// Method childForm_FormClosed
        /// </summary>
        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cargar Variable a Lista


        }



        private decimal proyectar(long ctt_id, long tcl_id, long ani_id, long ani_idf, long mes_idi, long mes_id, string var_codigo)
        {
          decimal tcma = 0;
          decimal vp = 0;
          long tpy_id = 0;

          
          tcl_id = System.Convert.ToInt64(cbofields1.SelectedValue);          
          VariableController objVariableController = new VariableController();
          List<Variable> lstVariable = new List<Variable>();
          lstVariable = objVariableController.findByVar_CodigoTclUnico(var_codigo, tcl_id);
          lstVariable.ForEach(delegate(Variable v)
          {
            var_id = v.Var_id;
            // Variable Auxiliar en la base de datos
            tpy_id = v.Tpy_id;
          });

          tcl_id = 1;
          // Calcular Proyección de Variable
          VariableObject objVariableObject = new VariableObject();
          tcma = objVariableObject.valorVariableProyectada(ctt_id, tcl_id, ani_id, ani_idf, mes_idi, mes_id, var_id, var_codigo, tpy_id);
          vp = objVariableObject.calcularProyeccion(tcma);
          return vp;
        }


        private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sTmp = lstVariables.Text;
            List<Variable> lstVariable = new List<Variable>();
            if (sTmp.Length > 0)
            {
                txtName.Text = sTmp.Trim();
                txtValue.Text = "";
                VariableObject objVariableObject = new VariableObject();
                lstVariable = objVariableObject.listVariablePorCodigo(txtName.Text);
                lstVariable.ForEach(delegate(Variable v)
                {
                    txtDescripcionVariable.Text = v.Var_descripcion;
                });

            }
        }

    }
}