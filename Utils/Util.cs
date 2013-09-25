//----------------------------------------------------------------------------------
// Util
// Helper Class 
//
// Elaborado por Gino Llerena T. ----- <gino.llerena@gmail.com> - Febrero del 2008
//
// Versión portada a CSharp del Programa CFormulas(VB6.0) del Guille tomado de http://www.elguille.info/
//
// (Trujillo - Perú)
//----------------------------------------------------------------------------------

using System;


namespace LibFormula
{
    public static class Util
    {

        public static bool IsNumeric(string sName)
        {
            foreach (char c in sName)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }
                 

        public static string MTrim(string sVar, char NoEval)
        {
            String sBlancos;
            string sTmp = "";

            sBlancos = @" " + '\t' + (char)0;

            int i = 0;
            for (i = 0; i < sVar.Length;i++)
            {
                char c = char.Parse(sVar.Substring(i, 1)); 

                if (c == NoEval)
                {
                    int j = sVar.IndexOf(NoEval, i + 1);
                    if (j == -1)
                    {
                        sVar = sVar + NoEval;
                        j = sVar.Length;
                    }
                    sTmp = sTmp + sVar.Substring(i, j - i + 1);
                    i = j;
                }
                else
                    if (sBlancos.IndexOf(c) == -1)
                        sTmp = sTmp + c;
                
            }

            return sTmp;

        }




        public static int MultInStr(string String1, string String2)
        {
            string sSimb = "";
            return MultInStr(String1, String2, ref sSimb, 1);
        }

        public static int MultInStr(string String1, string String2, ref string sSimb)
        {
            return MultInStr(String1, String2, ref sSimb, 0);
        }

        public static int MultInStr(string String1, string String2, ref string sSimb, int iStart)
        {
            int iElMenor=-1;    

            string[] operators = String2.Split(' ');   

            if (iStart <= String1.Length)
            {
                foreach(string cad in operators) 
                {
                    if (cad.Trim().Length > 0)
                    {
                        int j = String1.IndexOf(cad, iStart);

                        if (j != -1)
                        {
                            if (iElMenor == -1 || iElMenor > j)
                            {
                                iElMenor = j;
                                sSimb = cad;
                            }

                            if (iElMenor == iStart)
                                break;
                        }
                    }

                } 
            }
            return iElMenor;
        }
               
       
        public static int RInStr(string sV1, string sV2)
        {
            return RInStr(sV1.Trim().Length, sV1, sV2);
        }

        public static int RInStr(int startIndex, string sV1, string sV2)
        {

            string s1;
            string s2;

            s1 = sV1.Trim();       // La primera cadena
            s2 = sV2.Trim();       // la segunda cadena

            for (int i = startIndex - s2.Length; i >= 0; i--)
            {
                string sTmp = s1.Substring(i, s2.Length);
                if (sTmp == s2) // Si son iguales...
                {
                    return i; // esa es la posición
                }
            }

            return -1;

        }


        public static int GetNumberOfItems(string cadena, char item)
        {
            int k = 0;

            foreach (char c in cadena)
                if (c == item) k = k + 1;

            return k;
        }



        // Error
        // Realizar pruebas de validación
        // Error
        public static void BuscarCifra(ref string sExpresion, ref string sCifra)
        {
            const string CIFRAS = "0123456789., ";

            const int POSITIVO = 1;
            const int NEGATIVO = -1;

            int Signo;
            string n = "";


            sExpresion = sExpresion.TrimStart(' ');

            if (sExpresion.Length > 0)
            {
                if (sExpresion.Substring(0, 1) != "\"")
                {
                    Signo = POSITIVO;
                    if (sExpresion.Substring(0, 1) == "-") //Comprobar si es un número negativo
                    {
                        Signo = NEGATIVO;
                        sExpresion = sExpresion.Substring(1);
                    }

                    int ultima = -1;
                    int i = 0;
                    foreach (char c in sExpresion)
                    {
                        if (CIFRAS.IndexOf(c) != -1)
                        {
                            n = n + c;
                            ultima = i;
                        }
                        else
                            break;
                        i++;
                    }


                    if (n.Length > 0)
                    {
                        decimal nValor = decimal.Round((decimal.Parse(n) * Signo), 28);
                        sCifra = nValor.ToString();
                    }
                    else
                        sCifra = "";

                    if (ultima != -1)
                        sExpresion = sExpresion.Substring(ultima + 1).TrimStart(' ');
                    else
                        sExpresion = sExpresion.TrimStart(' ');


                }
            }
        }



        /// <summary>
        /// Method formatNumber
        /// </summary>
        public static string formatNumber(string n)
        {
          string numero = "";
          numero = String.Format("{0:0,0.00000000}", System.Convert.ToDecimal(n));
          return numero;
        }

        /// <summary>
        /// Method unFormatNumber
        /// </summary>
        public static string unFormatNumber(string n)
        {
          string numero = "";
          numero = String.Format("{0:0.00000000}", System.Convert.ToDecimal(n));
          return numero;
        }


        /// <summary>
        /// Method unFormatNumber
        /// </summary>
        public static long diasMes(long ani_id, long mes_id)
        {
            long dias = 0;
            switch (mes_id)
            {
                case 1:
                    dias = 31;
                    break;
                case 2:
                    // Si es año bisiesto
                    if (ani_id % 4 == 0 && ani_id % 100 != 0 || ani_id % 400 == 0)
                    {
                      dias = 29;
                    }
                    else
                    {
                      dias = 28;
                    }
                    break;
                case 3:
                    dias = 31;
                    break;
                case 4:
                    dias = 30;
                    break;
                case 5:
                    dias = 31;
                    break;
                case 6:
                    dias = 30;
                    break;
                case 7:
                    dias = 31;
                    break;
                case 8:
                    dias = 31;
                    break;
                case 9:
                    dias = 30;
                    break;
                case 10:
                    dias = 31;
                    break;
                case 11:
                    dias = 30;
                    break;
                case 12:
                    dias = 31;
                    break;

            }
            return dias;
        }


        public static long[] vectorMesAnio(long anii_id, long mesi_id, long anif_id, long mesf_id)
        {
          long[] matriz = new long[200];
          int i = 0;
            while (anii_id <= anif_id)
            {
              while (mesi_id <= mesf_id || (mesi_id > mesf_id && anii_id <= anif_id))
              {
                
                if (mesi_id == 12)
                {
                  matriz[i] = mesi_id;
                  matriz[i + 1] = anii_id;
                  mesi_id = 1;
                  anii_id++;
                  i = i + 2;
                  break;
                }
                else
                {
                  matriz[i] = mesi_id;
                  matriz[i + 1] = anii_id;
                  mesi_id++;
                }
                i = i + 2;
                if (mesi_id > mesf_id && anii_id == anif_id)
                {
                  anii_id++;
                  break;
                }
              }              
          }
          return matriz;
        }

    }
}
