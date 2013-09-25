using System;

namespace LibFormula
{
    public class OperatorProcessor : IOperatorProcessor
    {
        public OperatorProcessor()
        { }


        public string ProcessBatch(string sFormula)
        {
            sFormula = SetPriorities(sFormula);
            sFormula = ProcessInnerExpression(sFormula);
            return ProcessOperator(sFormula);
        }


        private string ProcessOperator(string sformula)
        {
            string Operador = "";
            string Cifra1, Cifra2;
            decimal n3 = 0;

            string sOperadores = "% ^ * / + - ";

            if (Util.MultInStr(sformula, sOperadores, ref Operador) != -1)
            {
                Operador = "";
                Cifra1 = "";
                Cifra2 = "";
                do
                {
                    if (sformula.Length > 0)
                    {
                        if (Cifra1 == "")
                            Util.BuscarCifra(ref sformula, ref Cifra1);

                        Operador = sformula.Length > 0 ? sformula.Substring(0, 1) : "";
                        sformula = sformula.Length > 0 ? sformula.Substring(1) : "";

                        Util.BuscarCifra(ref sformula, ref Cifra2);

                        decimal n1 = 0;
                        if (Cifra1.Length > 0) n1 = decimal.Parse(Cifra1);

                        decimal n2 = 0;
                        if (Cifra2.Length > 0) n2 = decimal.Parse(Cifra2);

                        n3 = decimal.Round(CalculateByOperator(n1, n2, Operador), 28);

                        Cifra1 = n3.ToString();
                    }
                    else
                        break;

                } while (Operador != "");

                return n3.ToString();

            }
            else
            {
                if (sformula.Length > 0)
                {
                    if (sformula.Substring(0, 1) != "\"")
                    {
                        sOperadores = "0123456789,.";
                        Cifra1 = "";
                        foreach (char c in sformula)
                            if (sOperadores.IndexOf(c) != -1)
                                Cifra1 = Cifra1 + c;

                        if (Cifra1 != "")
                            sformula = Cifra1;
                        else
                            sformula = Convert.ToDecimal(0).ToString();
                    }
                }
                return sformula;
            }

        }


        private string SetPriorities(string sformula)
        {
            int i,j;
            int k;
            int j1;
            int k1;
            int pn;

            string sOperadores = "";

            const string cOperadores = "%^*/+-()";

            sformula = sformula.Trim();

            sOperadores = "% ^ * /";

            if (Util.MultInStr(sformula, sOperadores) != -1)
            {
                string Cifra1 = sformula;
                int n = Cifra1.Length;

                string[] operators = sOperadores.Split(' ');

                for (i = 0; i < operators.Length; i++)
                {
                    string Operador = operators[i]; 
                    pn = Util.RInStr(n, Cifra1, Operador);
                    if (pn != -1)
                    {
                        k = 0;
                        for (j = pn - 1; j >= 0; j--)
                        {
                            k = cOperadores.IndexOf(Cifra1.Substring(j, 1));
                            if (k >= 0)
                            {

                                if (cOperadores.Substring(k, 1) != ")")
                                {
                                    k1 = 0;
                                    for (j1 = pn + 1; j1 < Cifra1.Length; j1++)
                                    {
                                        k1 = cOperadores.IndexOf(Cifra1.Substring(j1, 1));
                                        if (k1 != -1)
                                        {
                                            k = Util.MultInStr(Cifra1, "*- /- ");
                                            if (k != -1)
                                                Cifra1 = Cifra1.Substring(0, j) + "(" + Cifra1.Substring(j + 1, j1 - j - 2) + ")" + Cifra1.Substring(k);
                                            else
                                            {
                                                string sComodin = Cifra1.Substring(j + 1, j1 - j - 1) + ")" + Cifra1.Substring(j1, 1);
                                                if (sComodin.Substring(sComodin.Length - 3) == "*)(")
                                                    Cifra1 = Cifra1.Substring(0, j + 1) + "(" + Cifra1.Substring(j + 1, j1 - j - 2) + Cifra1.Substring(j1 - 1) + ")";
                                                else
                                                    Cifra1 = Cifra1.Substring(0, j + 1) + "(" + Cifra1.Substring(j + 1, j1 - j - 1) + ")" + Cifra1.Substring(j1);

                                            }
                                            break;
                                        }
                                    }

                                    if (k1 == -1)
                                        Cifra1 = Cifra1.Substring(0, j + 1) + "(" + Cifra1.Substring(j + 1) + ")";

                                }
                                break;
                            }
                        }
                        pn = Util.RInStr(n, Cifra1, Operador);
                        n = pn - 1;
                        i--;
                    }
                }
                sformula = Cifra1;
            }

            return sformula;
        }


        

        private string ProcessInnerExpression(string sformula)
        {
            while (sformula.IndexOf("(") != -1)
            {
                int pn = sformula.IndexOf(")");

                if (pn != -1)
                {
                    for (int i = pn; i >= 0; i--)
                    {
                        if (sformula.Substring(i, 1) == "(")
                        {
                            string strP = sformula.Substring(i + 1, pn - i - 1);
                            strP = ProcessBatch(strP);
                            sformula = sformula.Substring(0, i) + strP + sformula.Substring(pn + 1);
                            break;
                        }
                    }
                }
                else
                    sformula = sformula + ")";

            }
            return sformula;
        }



        private decimal CalculateByOperator(decimal n1, decimal n2, string op)
        {
            decimal n3 = 0;

            switch (op)
            {
                case "+": n3 = n1 + n2; break;
                case "-": n3 = n1 - n2; break;
                case "*": n3 = n1 * n2; break;
                case "/": if (n2 != 0) n3 = n1 / n2;
                          else n3 = 0;
                          break;
                case "^": n3 =Convert.ToDecimal(Math.Pow(Convert.ToDouble(n1),Convert.ToDouble(n2))); break;

                case "%": n3 = n1 % n2; break;

                default:
                    {
                        n3 = n1 + n2;
                        break;
                    }
            }

            return n3; 
        }


        
    }
}
