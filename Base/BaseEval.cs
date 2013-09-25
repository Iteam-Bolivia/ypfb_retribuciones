using System;

namespace LibFormula
{
    public abstract class BaseEval
    {
        #region Base Parameters

        protected IFunctionProcessor _fncProcessor ;
        protected IOperatorProcessor _opProcessor ;
        protected Variables aVariable;           
        
        
        string simbols;
        char _noEval;

        public BaseEval()
        { 
            _fncProcessor = new FunctionProcessor();
            _opProcessor = new OperatorProcessor();
            aVariable = new Variables();           
        }

        public IFunctionProcessor FncProcessor
        {
            set {  _fncProcessor = value; }
            get { return _fncProcessor; }
        }

        protected OperatorProcessor Operador
        {
            //get { return _operador; }
            set { _opProcessor = value; }
        }
               
        public Variables Variables
        {
            get { return aVariable; }
        }

        public string Simbols
        {
            get { return simbols; }
            set { simbols = value; }
        }

        public char NoEval
        {
            get { return _noEval; }
            set { _noEval = value; }
        }


        public void NewVariable(string sName, string sValue)
        {
            aVariable.AddIfNotExist(sName, sValue);
        }

        #endregion

        public string ProcessCondition(string sExpresion)
        {
            sExpresion = DiscardNoEvals(sExpresion);
            sExpresion = FillVariables(sExpresion);
            sExpresion = ParseCondition(sExpresion);
            return _opProcessor.ProcessBatch(sExpresion);

        }

        public string ProcessConditionValidarFormula(string sExpresion)
        {   string r="";
            sExpresion = DiscardNoEvals(sExpresion);
            sExpresion = FillVariables(sExpresion);
            r = ParseConditionValidarFormula(sExpresion);
            return r;

        }

        protected abstract string ParseCondition(string sExpresion);
        protected abstract string ParseConditionValidarFormula(string sExpresion);

                

        private string DiscardNoEvals(string expression)
        {
            int j = 0;

            expression = Util.MTrim(expression, NoEval);

            if (NoEval.ToString().Length  > 0)
            {
                do
                {
                    j = expression.IndexOf(NoEval);
                    if (j != -1)
                    {
                        int k = expression.IndexOf(NoEval, j + 1);
                        if (k == -1) k = expression.Length;
                        expression = expression.Substring(0, j) + expression.Substring(k + 1);
                    }
                } while (j >= 0);
            }

            return expression;
        }

        private string FillVariables(string svar)
        {
            int i, j;
            string sExpr = "";

            do
            {
                i = svar.IndexOf("=");
                if (i >= 0)
                {
                    string sNom = svar.Substring(0, i);
                    j = sNom.IndexOf(":");
                    if (j >= 0)
                    {
                        sExpr = sExpr + sNom.Substring(0, j);
                        sNom = sNom.Substring(j + 1);
                    }

                    j = svar.IndexOf(":", i + 1);

                    if (j == -1) j = svar.Length;

                    string sVal = svar.Substring(i + 1, (j - i - 1));

                    svar = svar.Substring(j + 1);

                    if (svar.Length == 0) i = 0;

                    j = aVariable.IsVar(sNom);

                    if (j >= 0)
                    {
                        string sOp = "";
                        string sValTmp = sVal; 
                        string sValAnt = GetToken(ref sVal, ref sOp);
                        if (sValAnt == sNom)
                        {
                            sVal = aVariable[j].Value + sOp + sVal;
                            sVal = ParseCondition(sVal);
                            sVal = _opProcessor.ProcessBatch(sVal);
                        }
                        else sVal = sValTmp;

                        aVariable[j].Value = sVal;
                    }
                    else
                        aVariable.AddIfNotExist(sNom, sVal);

                }

            } while (i >= 0);

            return svar;

        }


        protected string GetToken(ref string sF, ref string sSimbol)
        {
            int j;
            string _aToken;

            if (sF.Trim().Length == 0)
            {
                _aToken = "";
                sF = "";
            }
            else
            {
                j = Util.MultInStr(sF, Simbols, ref sSimbol);

                if (j == -1)
                {
                    _aToken = sF;
                    sF = "";
                }
                else
                {
                    _aToken = sF.Substring(0, j);
                    sF = sF.Substring(j + sSimbol.Length);

                    if (_aToken.Length > 0)
                    {
                        if (_aToken.Substring(_aToken.Length - 1) == "E")
                        {
                            _aToken = _aToken + sSimbol + sF.Substring(0, 2);
                            sF = sF.Substring(3);
                            sSimbol = "";
                        }
                    }
                }
            }
            return _aToken;
        }

       

        

        
        
             
    }
}
