using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using Model;

namespace LibFormula
{
    public class MathProcessor :BaseEval 
    {

        const string allFunctions = " Int Fix Abs Sgn Sqr Cos Sin Tan Atn Exp Log Max Min EQ NEQ LT LET GT GET";
                      
        public MathProcessor():base()
        {
            Simbols = ":= < > = >= <= ( ) ^ * / - + $ ! # @ { } [ ] ; ' / && ||";
            NoEval = ((char)34);
        }
                

        private string FunctionVal(string sName)
        { 
            string sValue;
            string sParams;
            string sNameFun="";
            
            Random Rnd = new Random(); 
        
            sName = sName.Trim();
            int i = sName.IndexOf("@");

            if (i >= 0)
            { 
                if (i==0)
                    sValue =  sName.Substring(1);
                else
                    sValue = sName.Substring(0, i - 1) + sName.Substring(i + 1);                   
                        
                i = sValue.IndexOf("Rnd");

                if (i >= 0)
                {
                    if (i > 0)
                        sName = sValue.Substring(0, i - 1) + "(" + Rnd.NextDouble() + ")" + sValue.Substring(i + 3, sValue.Length);
                    else
                        sName = "(" + Rnd.NextDouble() + ")" + sValue.Substring(i + 3);
                }

                i = Util.MultInStr(sValue, allFunctions, ref sNameFun);

                if (i >= 0)
                {                   
                    StringCollection strList = new StringCollection();
                    string[] aValues = null;

                    sName = sValue.Substring(i + sNameFun.Length );
                    sParams = Parametros(ref sName);

                    aValues = sParams.Split(',');
                    for (int j = 0; j < aValues.Length; j++)
                    {
                        aValues[j] = ParseCondition(aValues[j]);
                        aValues[j] = _opProcessor.ProcessBatch(aValues[j]);
                    }

                    sName = _fncProcessor.Process(sNameFun, aValues);   
                }
            }
            return sName;
        }
        
        protected override string ParseCondition(string sSF)
        {

            int qFuncion;
            string sFormula="";
            string sToken;          
            string sOp;             
            string sVar;            
            string sParams="";        
            string sFunFormula;     
                     
            do 
            {
                sOp = "";
                sToken = GetToken(ref sSF, ref sOp);

                if (sToken.Length >0)
                {
                     if (!IsFuncOrVar(sToken))
                        sFormula = sFormula + sToken + sOp;
                     else
                     {
                         sVar = Variables.GetValue(sToken);
                         if (sVar.Length > 0)
                         {
                            sVar = ParseCondition(sVar);
                            sToken = _opProcessor.ProcessBatch(sVar);
                         }

                         qFuncion = _fncProcessor.IsFunction(sToken);
                         

                         if (qFuncion>=0) 
                         {
                             sVar = _fncProcessor.GetParametros(qFuncion);
                            sFunFormula = _fncProcessor.GetFormula(qFuncion);
                            
                             if (sVar.Length >0) 
                             {
                        
                                if (sOp == "(" )
                                {
                                    sSF = sOp + sSF;
                                    sParams = Parametros(ref sSF);
                                    if (sParams.Length >0) 
                                        sOp = "";
                                }

                                if (sParams.Length >0) 
                                {
                                    sParams = ParseCondition(sParams);
                                                       
                                    if (sVar.IndexOf(",") == -1) 
                                    {
                                        sFunFormula = SetParenthesis(sParams, sVar, sFunFormula);
                                    }
                                    else
                                    {
                                        GetPattern(ref  sParams, ref sVar, ref sFunFormula);
                                        GetFormula(ref sParams, ref sVar, ref sFunFormula);
                                    }
                                }
                             }
                             sVar = "";
                             sVar = FunctionVal(sFunFormula);
                             if (sVar.Length >0)
                                 sFunFormula = ParseCondition(sVar);

                            if (sOp != "\"")
                            {
                                sFunFormula = sFunFormula + sOp + sSF;
                                sFunFormula = ParseCondition(sFunFormula);
                                sFormula = sFormula + _opProcessor.ProcessBatch(sFunFormula);
                                sSF = "";
                            }
                            else
                            {
                                sFormula = sFormula + _opProcessor.ProcessBatch(sFunFormula);
                                sFormula = sFormula + sOp + sSF;
                                sSF = "";
                            }
                         }
                         else 
                         {
                            sFormula = sFormula + sToken + sOp;
                         }
                     }
                    
                }
                else 
                    {
                        sFormula = sFormula + sToken + sOp;
                    }

            } while (sSF.Length >0);

            return sFormula;

        }
        
        
        /***********************/

        private bool IsNumber(object valor)
        {
            try
            {
                decimal r = Convert.ToDecimal(valor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        protected override string ParseConditionValidarFormula(string sSF)
        {
            int qFuncion;
            string sFormula = "";
            string sToken;
            string sOp;
            string sVar;
            string sParams = "";
            string sFunFormula;

            List<string> operaciones = new List<string>();

            operaciones.Add("+");
            operaciones.Add("-");
            operaciones.Add("*");
            operaciones.Add("/");
            operaciones.Add("^");
            operaciones.Add("%");
            operaciones.Add("Max");
            operaciones.Add("max");
            operaciones.Add("MAX");
            operaciones.Add("Min");
            operaciones.Add("min");
            operaciones.Add("MIN");
            operaciones.Add("");

            List<Variable> lstVariable2 = new List<Variable>();
            VariableObject objVariableObject2 = new VariableObject();
            lstVariable2 = objVariableObject2.listVariable(0);

            do
            {
                sOp = "";
                sToken = GetToken(ref sSF, ref sOp);
                //validar stoken

                bool flag = false;
                foreach (Variable item in lstVariable2)
                {
                    if (item.Var_codigo == sToken)
                    {
                        flag = true;
                    }

                }

                if (!flag)
                {
                    foreach (string item in operaciones)
                    {

                        if (IsNumber(sToken))
                        {
                            flag = true;
                        }
                        if (item == sToken)
                        {
                            flag = true;
                        }

                    }
                }

                //if (1 == 1)
                if (flag)
                {

                    if (sToken.Length > 0)
                    {
                        if (!IsFuncOrVar(sToken))
                            sFormula = sFormula + sToken + sOp;
                        else
                        {
                            sVar = Variables.GetValue(sToken);
                            if (sVar.Length > 0)
                            {
                                sVar = ParseConditionValidarFormula(sVar);
                                sToken = _opProcessor.ProcessBatch(sVar);
                            }

                            qFuncion = _fncProcessor.IsFunction(sToken);


                            if (qFuncion < 0)
                            {
                                sVar = _fncProcessor.GetParametros(qFuncion);
                                sFunFormula = _fncProcessor.GetFormula(qFuncion);

                                if (sVar.Length > 0)
                                {

                                    if (sOp == "(")
                                    {
                                        sSF = sOp + sSF;
                                        sParams = Parametros(ref sSF);
                                        if (sParams.Length > 0)
                                            sOp = "";
                                    }

                                    if (sParams.Length > 0)
                                    {
                                        sParams = ParseConditionValidarFormula(sParams);

                                        if (sVar.IndexOf(",") == -1)
                                        {
                                            sFunFormula = SetParenthesis(sParams, sVar, sFunFormula);
                                        }
                                        else
                                        {
                                            GetPattern(ref  sParams, ref sVar, ref sFunFormula);
                                            GetFormula(ref sParams, ref sVar, ref sFunFormula);
                                        }
                                    }
                                }
                                sVar = "";
                                sVar = FunctionVal(sFunFormula);
                                if (sVar.Length > 0)
                                    sFunFormula = ParseConditionValidarFormula(sVar);

                                if (sOp != "\"")
                                {
                                    sFunFormula = sFunFormula + sOp + sSF;
                                    sFunFormula = ParseConditionValidarFormula(sFunFormula);
                                    sFormula = sFormula + _opProcessor.ProcessBatch(sFunFormula);
                                    sSF = "";
                                }
                                else
                                {
                                    sFormula = sFormula + _opProcessor.ProcessBatch(sFunFormula);
                                    sFormula = sFormula + sOp + sSF;
                                    sSF = "";
                                }
                            }
                            else
                            {
                                sFormula = sFormula + sToken + sOp;
                            }
                        }

                    }
                    else
                    {
                        sFormula = sFormula + sToken + sOp;
                    }
                }
                else
                {
                    //return sToken;
                    return "La variable no existe: " + sToken;
                }

            } while (sSF.Length > 0);

            return ""; //return sFormula;
        }
        /*******************************/




        public bool IsFuncOrVar(string sName)
        { 
            if (! Util.IsNumeric(sName))
            {
                if (_fncProcessor.IsFunction(sName) != -1)
                    return true;
                else
                    if (Variables.IsVar(sName) != -1)
                        return true;
            }
            return false; 
        }

        private string Parametros(ref string sExp )
        { 
            int i=0;
            string sParams="";
            string sExpAnt;
            
            sExp = sExp.Trim(); 
            sExpAnt = sExp;
            
            if (sExp.Substring(0, 1) == "(" )
            {
                sExp = sExp.Substring(1);
                
                int k = -1;
                int j = -1;
                foreach (char c in sExp)
                {
                    if (c == '(') j++;

                    if (c == ')')
                    {
                        j --;
                        if (j == -2)
                        {
                            k = i;
                            break;
                        }
                    }
                    i++;
                }
                
                if( k >-1)
                {
                    sParams = sExp.Substring(0, k);
                    sExp = sExp.Substring(k+1);
                }
            }
            else
            {
                sParams = "";
                sExp = sExpAnt;
            }
            return  sParams;
        }

        private void GetPattern(ref string sParams, ref string sVar, ref string sFunFormula)
        {
            int i, j, k, n;
            string sParamF;
            

            sVar = sVar + ",";
            sParams = sParams + ",";

            if (sFunFormula.IndexOf("...") > 0)
            {
                i = Util.GetNumberOfItems(sParams, ',');

                string sParamX = "NumX1";
                n = 0;

                sParamF = sFunFormula.Substring(sFunFormula.Length - 4);
                sFunFormula = sFunFormula.Substring(0, sFunFormula.Length - 4);
                sVar = sVar.Substring(0, sVar.Length - 5);

                do
                {
                    k = Util.GetNumberOfItems(sVar, ',');

                    if (i > k + 1)
                    {

                        for (j = sVar.Length - 1; j >= 0; j--)
                        {
                            if (sVar.Substring(j, 1) == ",")
                            {
                                sVar = sVar + "," + sParamX + n.ToString().Trim();
                                sFunFormula = sFunFormula + sParamF.Substring(0, 1) + sParamX + n.ToString().Trim();
                                n = n + 1;
                                break;
                            }
                        }
                    }
                } while (i > k + 1);

                if (sVar.Substring(sVar.Length - 1) != ",")
                    sVar = sVar + ",";
            }
        }


        private void GetFormula(ref string sParams, ref string sVar, ref string sFunFormula)
        {
            int i, j;
            string sParamF;
            string sParamE;

            do
            {
                j = sVar.IndexOf(",");
                if (j != -1)
                {
                    sParamF = sVar.Substring(0, j).Trim();
                    sVar = sVar.Substring(j + 1).Trim();
                    i = sParams.IndexOf(",");
                    if (i >= 0)
                    {
                        sParamE = sParams.Substring(0, i).Trim();
                        sParams = sParams.Substring(i + 1);
                    }
                    else
                    {
                        sParamE = sParams;
                        sParams = "";
                    }

                    do
                    {
                        i = sFunFormula.IndexOf(sParamF);
                        sFunFormula = SetParenthesis(sParamE, sParamF, sFunFormula);

                    } while (i >= 0);
                }
            } while (j >= 0);
        
        
        }


        private string SetParenthesis(string sParam, string sVar, string sFunFormula)
        {
            int i = sFunFormula.IndexOf(sVar);
            if (i >= 0)
                sFunFormula = sFunFormula.Substring(0, i) + "(" + sParam + ")" + sFunFormula.Substring(i + sVar.Length);

            return sFunFormula; 
        }






       
    }




    }

