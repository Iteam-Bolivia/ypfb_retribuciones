using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Model;

namespace Model
{
    public class ParExcel_ColumnaObject : ParExcel_Columna
    {
        public List<ParExcel_Columna> listParExcelColumna(long pec_id)
        {
            String where = (pec_id != 0 ? ("AND tab_parexcel_columna.pec_id=" + pec_id + "") : "");
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_parexcel.pex_codigo, " +
                        "tab_parexcel.pex_nombre, " +
                        "tab_parexcel.pex_hoja, " +
                        "tab_parexcel_columna.pec_columna, " +
                        "tab_parexcel_columna.pec_fila, " +
                        "tab_parexcel_columna.pec_id, " +
                        "tab_parexcel_columna.pex_id, " +
                        "tab_parexcel_columna.mer_id, " +
                        "tab_parexcel_columna.umd_id, " +
                        "tab_parexcel_columna.pec_iva, " +
                        "tab_parexcel_columna.pec_estado, " +
                        "tab_parexcel_columna.var_id, " +
                        "tab_parexcel_columna.pec_Convercion " +
                        "FROM " +
                        "tab_parexcel " +
                        "INNER JOIN tab_parexcel_columna ON tab_parexcel_columna.pex_id = tab_parexcel.pex_id " +
                        "WHERE " +
                        "tab_parexcel_columna.pec_estado = 1 " +
                        "AND tab_parexcel.pex_estado = 1 " +
                         where + " order by tab_parexcel_columna.pec_columna, tab_parexcel_columna.pec_fila ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    bool iva = (Convert.ToInt32(rs.Fields["pec_iva"].Value) != 0 ? (true) : false);
                    ParExcel_Columna objParExcel_Columna = new ParExcel_Columna();
                    //objParExcel_Columna.Tco_nombre = (string)rs.Fields["tco_nombre"].Value;
                    objParExcel_Columna.Pec_Columna = (string)rs.Fields["pec_columna"].Value;
                    objParExcel_Columna.Pec_id = System.Convert.ToInt64(rs.Fields["pec_id"].Value);
                    objParExcel_Columna.Pex_id = System.Convert.ToInt64(rs.Fields["pex_id"].Value);
                    objParExcel_Columna.Pec_Convercion = System.Convert.ToInt64(rs.Fields["pec_Convercion"].Value);
                    objParExcel_Columna.Pec_fila = System.Convert.ToInt64(rs.Fields["pec_fila"].Value);
                    objParExcel_Columna.Pec_Estado = System.Convert.ToInt64(rs.Fields["pec_estado"].Value);
                    objParExcel_Columna.Pex_hoja = (string)rs.Fields["pex_hoja"].Value;
                    objParExcel_Columna.Pex_codigo = (string)rs.Fields["pex_codigo"].Value;
                    objParExcel_Columna.Mer_nombre = GetMercado(System.Convert.ToInt64(rs.Fields["mer_id"].Value));
                    objParExcel_Columna.Umd_nombre = GetUnidadMedida(System.Convert.ToInt64(rs.Fields["umd_id"].Value));
                    objParExcel_Columna.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
                    objParExcel_Columna.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
                    if (Convert.ToString(rs.Fields["var_id"].Value) != "")
                    {
                        objParExcel_Columna.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                        objParExcel_Columna.Var_nombre = GetVariable(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                        objParExcel_Columna.Var_codigo = GetVariableCodigo(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                    }
                    objParExcel_Columna.Pec_iva = iva;

                    lstParExcelColumna.Add(objParExcel_Columna);

                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExcelColumna;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExcelColumna;
            }
            finally
            {
                Connection_Off(1);
            }
        }


        public List<ParExcel_Columna> listParExcelColumnaByPex_id(long pex_id)
        {
            String where = (pex_id != 0 ? ("AND tab_parexcel_columna.pex_id=" + pex_id + "") : "");
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                       "tab_parexcel.pex_codigo, " +
                       "tab_parexcel.pex_nombre, " +
                       "tab_parexcel.pex_hoja, " +
                       "tab_parexcel_columna.pec_columna, " +
                       "tab_parexcel_columna.pec_fila, " +
                       "tab_parexcel_columna.pec_id, " +
                       "tab_parexcel_columna.pex_id, " +
                       "tab_parexcel_columna.mer_id, " +
                       "tab_parexcel_columna.umd_id, " +
                       "tab_parexcel_columna.pec_iva, " +
                       "tab_parexcel_columna.pec_estado, " +
                       "tab_parexcel_columna.var_id, " +
                       "tab_parexcel_columna.pec_Convercion " +
                       "FROM " +
                       "tab_parexcel " +
                       "INNER JOIN tab_parexcel_columna ON tab_parexcel_columna.pex_id = tab_parexcel.pex_id " +
                        "WHERE " +
                       "tab_parexcel_columna.pec_estado = '1' AND " +
                       "tab_parexcel.pex_estado ='1'  " + where + " " +
                       " ORDER BY substring(tab_parexcel_columna.pec_columna,2), " +
                       "tab_parexcel_columna.pec_columna";
                //SQL = "SELECT " +
                //        "tab_parexcel.pex_codigo, " +
                //        "tab_parexcel.pex_nombre, " +
                //        "tab_parexcel.pex_hoja, " +
                //        "tab_parexcel_columna.pec_columna, " +
                //        "tab_parexcel_columna.pec_fila, " +
                //        "tab_parexcel_columna.pec_id, " +
                //        "tab_parexcel_columna.pex_id, " +
                //        "tab_parexcel_columna.mer_id, " +
                //        "tab_parexcel_columna.umd_id, " +
                //        "tab_parexcel_columna.pec_iva, " +
                //        "tab_parexcel_columna.pec_estado, " +
                //        "tab_parexcel_columna.var_id " +
                //        "FROM " +
                //        "tab_parexcel " +
                //        "INNER JOIN tab_parexcel_columna ON tab_parexcel_columna.pex_id = tab_parexcel.pex_id " +
                //        "WHERE " +
                //        "tab_parexcel_columna.pec_estado = '1' AND " +
                //        "tab_parexcel.pex_estado ='1'  " + where + " "+
                //        "ORDER BY tab_parexcel_columna.pec_fila, substring(tab_parexcel_columna.pec_columna, 2) ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    bool iva = (Convert.ToInt32(rs.Fields["pec_iva"].Value) != 0 ? (true) : false);
                    ParExcel_Columna objParExcelColumna = new ParExcel_Columna();
                    //objParExcelColumna.Tco_nombre = (string)rs.Fields["tco_nombre"].Value;
                    objParExcelColumna.Pec_Columna = (string)rs.Fields["pec_columna"].Value;
                    objParExcelColumna.Pec_id = System.Convert.ToInt64(rs.Fields["pec_id"].Value);
                    objParExcelColumna.Pex_id = System.Convert.ToInt32(rs.Fields["pex_id"].Value);
                    objParExcelColumna.Pec_Convercion = System.Convert.ToInt64(rs.Fields["pec_Convercion"].Value);

                    if (Convert.ToInt64(rs.Fields["pec_Convercion"].Value) == 0)
                    {
                        objParExcelColumna.Pec_Convercion_String = "Ninguno";
                    }
                    else if (Convert.ToInt64(rs.Fields["pec_Convercion"].Value) == 1)
                    {
                        objParExcelColumna.Pec_Convercion_String = "68º F base saturada";
                    }
                    else
                    {
                        objParExcelColumna.Pec_Convercion_String = "60º F base seca";
                    }

                    objParExcelColumna.Pec_fila = System.Convert.ToInt32(rs.Fields["pec_fila"].Value);
                    objParExcelColumna.Pec_Estado = System.Convert.ToInt32(rs.Fields["pec_estado"].Value);
                    objParExcelColumna.Pex_hoja = (string)rs.Fields["pex_hoja"].Value;
                    objParExcelColumna.Pex_codigo = (string)rs.Fields["pex_codigo"].Value;
                    objParExcelColumna.Mer_nombre = GetMercado(System.Convert.ToInt64(rs.Fields["mer_id"].Value));
                    objParExcelColumna.Umd_nombre = GetUnidadMedida(System.Convert.ToInt64(rs.Fields["umd_id"].Value));
                    objParExcelColumna.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
                    objParExcelColumna.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
                    objParExcelColumna.Pec_iva = iva;
                    if (System.Convert.ToInt32(rs.Fields["var_id"].Value) != 0)
                    {
                        objParExcelColumna.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                        objParExcelColumna.Var_nombre = GetVariable(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                        objParExcelColumna.Var_descripcion = GetVariableDescripcion(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                        objParExcelColumna.Var_codigo = GetVariableCodigo(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                        objParExcelColumna.Umd_nombre = GetVariableUnidadMedida(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                    }
                    lstParExcelColumna.Add(objParExcelColumna);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExcelColumna;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExcelColumna;
            }
            finally
            {
                Connection_Off(1);
            }
        }





        public List<ParExcel_Columna> listParExcelColumnaByPex_idOrderByColumna(long pex_id)
        {
            String where = (pex_id != 0 ? ("AND tab_parexcel_columna.pex_id=" + pex_id + "") : "");
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_parexcel.pex_codigo, " +
                        "tab_parexcel.pex_nombre, " +
                        "tab_parexcel.pex_hoja, " +
                        "tab_parexcel_columna.pec_columna, " +
                        "tab_parexcel_columna.pec_fila, " +
                        "tab_parexcel_columna.pec_id, " +
                        "tab_parexcel_columna.pex_id, " +
                         "tab_parexcel_columna.mer_id, " +
                        "tab_parexcel_columna.umd_id, " +
                        "tab_parexcel_columna.pec_iva, " +
                        "tab_parexcel_columna.pec_estado, " +
                        "tab_parexcel_columna.var_id, " +
                         "FROM " +
                        "tab_parexcel " +
                        "INNER JOIN tab_parexcel_columna ON tab_parexcel_columna.pex_id = tab_parexcel.pex_id " +
                         "WHERE " +
                        "tab_parexcel_columna.pec_estado = 1 AND " +
                        " " + where + " order by " +
                        "substring(tab_parexcel_columna.pec_columna,2), " +
                        "tab_parexcel_columna.pec_columna ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    bool iva = (Convert.ToInt32(rs.Fields["pec_iva"].Value) != 0 ? (true) : false);
                    ParExcel_Columna objParExcelColumna = new ParExcel_Columna();
                    //objParExcelColumna.Tco_nombre = (string)rs.Fields["tco_nombre"].Value;
                    objParExcelColumna.Pec_Columna = (string)rs.Fields["pec_columna"].Value;
                    objParExcelColumna.Pec_id = System.Convert.ToInt64(rs.Fields["pec_id"].Value);
                    objParExcelColumna.Pex_id = System.Convert.ToInt32(rs.Fields["pex_id"].Value);
                    //objParExcelColumna.Tco_id = System.Convert.ToInt32(rs.Fields["tco_id"].Value);
                    objParExcelColumna.Pec_fila = System.Convert.ToInt32(rs.Fields["pec_fila"].Value);
                    objParExcelColumna.Pec_Estado = System.Convert.ToInt32(rs.Fields["pec_estado"].Value);
                    objParExcelColumna.Pex_hoja = (string)rs.Fields["pex_hoja"].Value;
                    objParExcelColumna.Pex_codigo = (string)rs.Fields["pex_codigo"].Value;
                    objParExcelColumna.Mer_nombre = GetMercado(System.Convert.ToInt64(rs.Fields["mer_id"].Value));
                    objParExcelColumna.Umd_nombre = GetUnidadMedida(System.Convert.ToInt64(rs.Fields["umd_id"].Value));
                    objParExcelColumna.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
                    objParExcelColumna.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
                    objParExcelColumna.Pec_iva = iva;
                    if (Convert.ToString(rs.Fields["var_id"].Value) != "")
                    {
                        objParExcelColumna.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                        objParExcelColumna.Var_nombre = GetVariable(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                        objParExcelColumna.Var_codigo = GetVariableCodigo(System.Convert.ToInt64(rs.Fields["var_id"].Value));
                    }
                    lstParExcelColumna.Add(objParExcelColumna);
                    rs.MoveNext();
                }
                return lstParExcelColumna;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExcelColumna;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        private string GetVariable(long var_id)
        {
            List<Variable> objVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            if (var_id != 0)
            {
                objVariable = objVariableObject.listVariable(var_id);
                if (objVariable.Count != 0)
                    return objVariable[0].Var_nombre;
            }
            return null;
        }


        private string GetVariableDescripcion(long var_id)
        {
            List<Variable> objVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            if (var_id != 0)
            {
                objVariable = objVariableObject.listVariable(var_id);
                if (objVariable.Count != 0)
                    return objVariable[0].Var_descripcion;
            }
            return null;
        }
        private string GetVariableCodigo(long var_id)
        {
            List<Variable> objVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            if (var_id != 0)
            {
                objVariable = objVariableObject.listVariable(var_id);
                if (objVariable.Count != 0)
                    return objVariable[0].Var_codigo;
            }
            return null;
        }


        private string GetVariableUnidadMedida(long var_id)
        {
            List<Variable> objVariable = new List<Variable>();
            VariableObject objVariableObject = new VariableObject();
            if (var_id != 0)
            {
                objVariable = objVariableObject.listVariable(var_id);
                if (objVariable.Count != 0)
                    return objVariable[0].Umd_codigo;
            }
            return null;
        }

        private string GetMercado(long mer_id)
        {
            List<Mercado> mercadoAux = new List<Mercado>();
            MercadoObject merObject = new MercadoObject();
            if (mer_id != 0)
            {
                mercadoAux = merObject.listMercado(mer_id);
                if (mercadoAux.Count != 0)
                    return mercadoAux[0].Mer_nombre;
            }
            return null;
        }

        private string GetUnidadMedida(long umd_id)
        {
            List<Unidad_Medida> unidadMedidaAux = new List<Unidad_Medida>();
            UnidadMedidaObject uniObject = new UnidadMedidaObject();
            if (umd_id != 0)
            {
                unidadMedidaAux = uniObject.listUnidadMedida(umd_id);

                if (unidadMedidaAux.Count != 0)
                {
                    return unidadMedidaAux[0].Umd_nombre;
                }
            }
            return null;
        }


        public List<ParExcel_Columna> listParExcelColumnas(long pex_id)
        {
            String where = (pex_id != 0 ? ("AND pex_id=" + pex_id + "") : "");
            List<ParExcel_Columna> lstParexcelColumna = new List<ParExcel_Columna>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_parexcel_tipo.pxt_id, " +
                      "tab_parexcel_tipo.pxt_codigo, " +
                      "tab_parexcel_columna.pec_columna, " +
                      "tab_parexcel_columna.pec_fila, " +
                      "tab_variable.var_codigo, " +
                      "tab_unidad_medida.umd_codigo " +
                      "FROM " +
                      "tab_parexcel " +
                      "INNER JOIN tab_parexcel_columna ON tab_parexcel.pex_id = tab_parexcel_columna.pex_id " +
                      "INNER JOIN tab_parexcel_tipo ON tab_parexcel_tipo.pxt_id = tab_parexcel.pxt_id " +
                      "INNER JOIN tab_variable ON tab_variable.var_id = tab_parexcel_columna.var_id " +
                      "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                      "WHERE tab_parexcel.pex_estado = 1 " +
                      where + " ORDER by tab_parexcel_columna.pec_fila, tab_parexcel_columna.pec_columna ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ParExcel_Columna objParexcelColumna = new ParExcel_Columna();
                    objParexcelColumna.Pxt_codigo = System.Convert.ToString(rs.Fields["pxt_codigo"].Value);
                    objParexcelColumna.Pec_Columna = System.Convert.ToString(rs.Fields["pec_columna"].Value);
                    objParexcelColumna.Pec_fila = System.Convert.ToString(rs.Fields["pec_fila"].Value);
                    objParexcelColumna.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    objParexcelColumna.Umd_nombre = System.Convert.ToString(rs.Fields["umd_nombre"].Value);
                    lstParexcelColumna.Add(objParexcelColumna);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParexcelColumna;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParexcelColumna;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
