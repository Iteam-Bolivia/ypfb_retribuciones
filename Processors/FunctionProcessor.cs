
using System;


namespace LibFormula
{
    public class FunctionProcessor :IFunctionProcessor 
    {
        Functions aFunction;



        public Functions Functions
        {
            get { return aFunction; }
        }
        
        public FunctionProcessor()
        {
            aFunction = new Functions();
            aFunction.AddIfNotExist("Sum", "Num1,Num2,...", "Num1+Num2+...");
            aFunction.AddIfNotExist("Subs", "Num1,Num2,...", "Num1-Num2-...");
            aFunction.AddIfNotExist("Mult", "Num1,Num2,...", "Num1*Num2*...");
            aFunction.AddIfNotExist("Max", "Num1,Num2", "@Max(Num1,Num2)");
            aFunction.AddIfNotExist("Min", "Num1,Num2", "@Min(Num1,Num2)");
            //aumentado por freddy 
            aFunction.AddIfNotExist("MAX", "Num1,Num2", "@Max(Num1,Num2)");
            aFunction.AddIfNotExist("max", "Num1,Num2", "@Max(Num1,Num2)");
            aFunction.AddIfNotExist("MIN", "Num1,Num2", "@Min(Num1,Num2)");
            aFunction.AddIfNotExist("min", "Num1,Num2", "@Min(Num1,Num2)");
            ///////////////
            aFunction.AddIfNotExist("Rnd", "", "@Rnd");
            aFunction.AddIfNotExist("Int", "Num", "@Int(Num)");
            aFunction.AddIfNotExist("Fix", "Num", "@Fix(Num)");
            aFunction.AddIfNotExist("Abs", "Num", "@Abs(Num)");
            aFunction.AddIfNotExist("Sgn", "Num", "@Sgn(Num)");
            aFunction.AddIfNotExist("Sqr", "Num", "@Sqr(Num)");
            aFunction.AddIfNotExist("Cos", "Num", "@Cos(Num)");
            aFunction.AddIfNotExist("Sin", "Num", "@Sin(Num)");
            aFunction.AddIfNotExist("Tan", "Num", "@Tan(Num)");
            aFunction.AddIfNotExist("Atn", "Num", "@Atn(Num)");
            aFunction.AddIfNotExist("Exp", "Num", "@Exp(Num)");
            aFunction.AddIfNotExist("Log", "Num", "@Log(Num)");
            aFunction.AddIfNotExist("Sec", "Num", "1/Cos(Num)");
            aFunction.AddIfNotExist("CoSec", "Num", "1/Sin(Num)");
            aFunction.AddIfNotExist("CoTan", "Num", "1/Tan(Num)");
            aFunction.AddIfNotExist("EQ", "Num1, Num2, Num3, Num4", "@EQ(Num1,Num2,Num3,Num4)");
            aFunction.AddIfNotExist("NEQ", "Num1, Num2, Num3, Num4", "@NEQ(Num1,Num2,Num3,Num4)");
            aFunction.AddIfNotExist("LT", "Num1, Num2, Num3, Num4", "@LT(Num1,Num2,Num3,Num4)");
            aFunction.AddIfNotExist("LET", "Num1, Num2, Num3, Num4", "@LET(Num1,Num2,Num3,Num4)");
            aFunction.AddIfNotExist("GT", "Num1, Num2, Num3, Num4", "@GT(Num1,Num2,Num3,Num4)");
            aFunction.AddIfNotExist("GET", "Num1, Num2, Num3, Num4", "@GET(Num1,Num2,Num3,Num4)");
        }

        public string GetParametros(int index)
        {
            return aFunction[index].Param;   
        }

        public string GetFormula(int index)
        {
            return aFunction[index].Formula;
        }


        public int IsFunction(string sNameFun)
        {
            return aFunction.IsFunction(sNameFun);           
        }


        public string Process(string sNameFun, string[] parameters)
        {
            string sReturn = "";

            switch (sNameFun)
                    {
                        case "Int": sReturn = "(" + Math.Floor(decimal.Parse(parameters[0])).ToString() + ")"; break;
                        case "Fix": sReturn = "(" + (Math.Sign(decimal.Parse(parameters[0])) * Math.Floor(Math.Abs(decimal.Parse(parameters[0])))).ToString() + ")"; break;
                        case "Abs": sReturn = "(" + Math.Abs(decimal.Parse(parameters[0])).ToString() + ")"; break;
                        case "Sgn": sReturn = "(" + Math.Sign(decimal.Parse(parameters[0])).ToString() + ")"; break;
                        case "Sqr": sReturn = "(" + Math.Sqrt(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Cos": sReturn = "(" + Math.Cos(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Sin": sReturn = "(" + Math.Sin(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Tan": sReturn = "(" + Math.Tan(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Atn": sReturn = "(" + Math.Atan(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Exp": sReturn = "(" + Math.Exp(double.Parse(parameters[0])).ToString() + ")"; break;
                        case "Log": sReturn = "(" + Math.Log(double.Parse(parameters[0])).ToString() + ")"; break;

                        case "Max": sReturn = (decimal.Parse(parameters[0]) > decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        case "Min": sReturn = (decimal.Parse(parameters[0]) < decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        //Aumentado por Freddy
                        case "MAX": sReturn = (decimal.Parse(parameters[0]) > decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        case "max": sReturn = (decimal.Parse(parameters[0]) > decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        case "MIN": sReturn = (decimal.Parse(parameters[0]) < decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        case "min": sReturn = (decimal.Parse(parameters[0]) < decimal.Parse(parameters[1])) ? parameters[0] : parameters[1]; break;
                        //////////////
                        case "EQ": sReturn = (decimal.Parse(parameters[0]) == decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                        case "NEQ": sReturn = (decimal.Parse(parameters[0]) != decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                        case "LT": sReturn = (decimal.Parse(parameters[0]) < decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                        case "LET": sReturn = (decimal.Parse(parameters[0]) <= decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                        case "GT": sReturn = (decimal.Parse(parameters[0]) > decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                        case "GET": sReturn = (decimal.Parse(parameters[0]) >= decimal.Parse(parameters[1])) ? parameters[2] : parameters[3]; break;
                    }
                
            return sReturn;
        
        
        }

    }
}
