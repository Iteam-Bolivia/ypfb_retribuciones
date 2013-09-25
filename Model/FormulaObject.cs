using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class FormulaObject : Formula
    {
        /// <summary>
        /// existFormulario Method
        /// </summary>
        public bool existFormula(long for_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT for_id FROM tab_formula WHERE for_id='" + for_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Connection_Off(1);
                    flag = true;
                }
                else
                {
                    Connection_Off(1);
                    flag = false;
                }
                return flag;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }/* Method existUser */



        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormula(long tcl_id)
        {
            String where = "";
            where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");

            //if (tcl_id == 1)
            //{
            //  where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            //}
            //else
            //{
            //  where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
            //}

            //String where = (for_id != 0 ? ("AND for_id=" + for_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "inner join tab_mercado on tab_mercado.mer_id = tab_variable.mer_id "+
                        "WHERE tab_variable.var_tipo = 'S' " +
                        " and tab_variable.cam_id = 1 " +
                        " and tab_mercado.mer_estado = 1 " +
                        where +
                        " ORDER BY tab_variable.var_orden, tab_variable.var_id asc";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */



        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaConTipo(long tcl_id, long for_id)
        {
            String where = "";
            //where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            if (tcl_id == 1)
            {
                where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            }
            else
            {
                where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
            }

            //String where = (for_id != 0 ? ("AND for_id=" + for_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "WHERE tab_variable.var_tipo = 'S' " +
                      where +
                      " ORDER BY tab_variable.var_orden, tab_variable.var_id asc";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */



        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaPorCodigo(string for_codigo)
        {
            String where = (!for_codigo.Equals("") ? ("AND tab_formula.for_codigo='" + for_codigo + "'") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "WHERE tab_variable.var_tipo = 'S' and" +
                        "(tab_variable.tcl_id = 1 or tab_variable.tcl_id = 3)" +
                      where +
                      " ORDER BY var_orden";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */


        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaPorVariableId(long var_id)
        {
            String where = (var_id != 0 ? ("AND tab_formula.var_id=" + var_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();
            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_formula.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado, " +
                        "tab_formula.for_tipo " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "WHERE tab_formula.for_estado = 1 " +
                      where +
                      " ORDER BY for_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    formula.For_tipo = System.Convert.ToInt32(rs.Fields["for_tipo"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */

        public bool cambiarEstadoVariableTipo(long for_id, string estado)
        {
            try
            {
                Connection_On();
                SQL = "UPDATE tab_variable SET var_tipo = '" + estado + "' WHERE var_id = (SELECT var_id FROM tab_formula WHERE for_id=" + for_id + ")";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                Connection_Off(1);
                return true;
            }
            catch (Exception)
            {
                Connection_Off(1);
                return false;
                throw;
            }
        }

        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaTotla(long tcl_id)
        {
            String where = "";
            where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");

            //if (tcl_id == 1)
            //{
            //  where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            //}
            //else
            //{
            //  where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
            //}

            //String where = (for_id != 0 ? ("AND for_id=" + for_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "WHERE " +
                        "tab_variable.var_tipo_cal = 2  " +
                      where +
                      " ORDER BY tab_variable.var_orden, tab_variable.var_id asc";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */


        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaCam(long tcl_id, long cam_id)
        {
            String where = "";
            where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");

            where += (cam_id != 0 ? ("AND (tab_variable.cam_id = " + cam_id + " or tab_variable.cam_id = 1) "): "" );
            //if (tcl_id == 1)
            //{
            //  where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            //}
            //else
            //{
            //  where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
            //}

            //String where = (for_id != 0 ? ("AND for_id=" + for_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_variable.mer_id " +
                        "WHERE tab_variable.var_tipo = 'S' " +
                      where +
                      " and tab_mercado.mer_estado = 1 " +
                      " ORDER BY tab_variable.var_orden, tab_variable.var_id asc "; //, tab_variable.var_id asc";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }


        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaTotla1(long tcl_id,long cam_id)
        {
            String where = "";
            where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            where += (cam_id != 0 ? ("AND (tab_variable.cam_id = " + cam_id + ") ") : "");
            //if (tcl_id == 1)
            //{
            //  where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            //}
            //else
            //{
            //  where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
            //}

            //String where = (for_id != 0 ? ("AND for_id=" + for_id + "") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "WHERE " +
                        "tab_variable.var_tipo_cal = 2  " +
                        where +
                        " ORDER BY tab_variable.var_orden asc";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */


        /// <summary>
        /// listFormulñario Method
        /// </summary>
        public List<Formula> listFormulaPorCodigoAndCam_id(string for_codigo,long cam_id)
        {
            String where = (!for_codigo.Equals("") ? ("AND tab_formula.for_codigo='" + for_codigo + "'") : "");
            where += (cam_id != 0 ? ("AND (tab_variable.cam_id =" + cam_id + " or tab_variable.cam_id = 1)") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM " +
                        "tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "WHERE tab_variable.var_tipo = 'S' and" +
                        "(tab_variable.tcl_id = 1 or tab_variable.tcl_id = 3)" +
                      where +
                      " ORDER BY var_orden";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */



        /// <summary>
        /// Lista de formulas par el calculo global y calculo por campo Method
        /// </summary>
        public List<Formula> listFormulaPorCodigoAndCam_idyTotales(long tcl_id, long cam_id)
        {
            string where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
            where += (cam_id != 0 ? ("AND (tab_variable.cam_id =" + cam_id + " or tab_variable.cam_id = 1)") : "");
            List<Formula> lstFormula = new List<Formula>();

            try
            {
                Connection_On();

                SQL = "SELECT  " +
                        "tab_formula.for_id, " +
                        "tab_variable.var_id, " +
                        "tab_variable.var_codigo, " +
                        "tab_formula.for_codigo, " +
                        "tab_formula.for_nombre, " +
                        "tab_formula.for_valini, " +
                        "tab_formula.for_estado " +
                        "FROM tab_variable " +
                        "Inner Join tab_formula ON tab_variable.var_id = tab_formula.var_id " +
                        "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                        "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_variable.mer_id " +
                        "WHERE tab_variable.var_tipo = 'S' " +
                        " and (tab_variable.var_tipo_cal = 4 or tab_variable.var_tipo_cal = 2) " +
                      where +
                        " and tab_mercado.mer_estado = 1  " +
                        "ORDER BY " +
                        "tab_variable.var_orden, " +
                        "tab_variable.var_id asc ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Formula formula = new Formula();
                    formula.For_id = System.Convert.ToInt64(rs.Fields["for_id"].Value);
                    formula.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    formula.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    formula.For_codigo = System.Convert.ToString(rs.Fields["for_codigo"].Value);
                    formula.For_nombre = System.Convert.ToString(rs.Fields["for_nombre"].Value);
                    formula.For_valini = System.Convert.ToDecimal(rs.Fields["for_valini"].Value);
                    formula.For_estado = System.Convert.ToInt64(rs.Fields["for_estado"].Value);
                    lstFormula.Add(formula);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstFormula;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstFormula;
            }
        }/* Method listMenu */
    }
}
