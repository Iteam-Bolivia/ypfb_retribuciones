using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ParExcel_TipoObject : ParExcel_Tipo
    {
        public List<ParExcel_Tipo> listParExcel_Tipo(long pxt_id)
        {
            String where = (pxt_id != 0 ? ("AND pxt_id=" + pxt_id + "") : "");
            List<ParExcel_Tipo> lstParExcelTipo = new List<ParExcel_Tipo>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_ParExcel_Tipo.pxt_id, " +
                      "tab_ParExcel_Tipo.pxt_codigo, " +
                      "tab_ParExcel_Tipo.pxt_nombre, " +
                      "tab_ParExcel_Tipo.pxt_recorrido, " +
                      "tab_ParExcel_Tipo.pxt_contratos, " +
                      "tab_ParExcel_Tipo.pxt_estado " +
                      "FROM tab_parexcel_tipo " +
                      "WHERE tab_parexcel_tipo.pxt_estado = 1 " +
                      where + " order by tab_parexcel_tipo.pxt_id ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ParExcel_Tipo objParExcel_Tipo = new ParExcel_Tipo();
                    objParExcel_Tipo.Pxt_id = System.Convert.ToInt64(rs.Fields["pxt_id"].Value);
                    objParExcel_Tipo.Pxt_codigo = (string)rs.Fields["pxt_codigo"].Value;
                    objParExcel_Tipo.Pxt_nombre = (string)rs.Fields["pxt_nombre"].Value;
                    objParExcel_Tipo.Pxt_recorrido = System.Convert.ToInt64(rs.Fields["pxt_recorrido"].Value);
                    objParExcel_Tipo.Pxt_contratos = System.Convert.ToInt64(rs.Fields["pxt_contratos"].Value);
                    objParExcel_Tipo.Pxt_estado = System.Convert.ToInt64(rs.Fields["pxt_estado"].Value);
                    lstParExcelTipo.Add(objParExcel_Tipo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExcelTipo;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExcelTipo;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public List<ParExcel_Tipo> listParExcel_TipoPorCodigo(string pxt_codigo)
        {
            String where = (!pxt_codigo.Equals("") ? ("AND pxt_codigo='" + pxt_codigo + "'") : "");
            List<ParExcel_Tipo> lstParExcelTipo = new List<ParExcel_Tipo>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_ParExcel_Tipo.pxt_id, " +
                      "tab_ParExcel_Tipo.pxt_codigo, " +
                      "tab_ParExcel_Tipo.pxt_nombre, " +
                      "tab_ParExcel_Tipo.pxt_recorrido, " +
                      "tab_ParExcel_Tipo.pxt_contratos, " +
                      "tab_ParExcel_Tipo.pxt_estado " +
                      "FROM tab_parexcel_tipo " +
                      "WHERE tab_parexcel_tipo.pxt_estado = 1 " +
                      where + " order by tab_parexcel_tipo.pxt_id ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ParExcel_Tipo objParExcel_Tipo = new ParExcel_Tipo();
                    objParExcel_Tipo.Pxt_id = System.Convert.ToInt64(rs.Fields["pxt_id"].Value);
                    objParExcel_Tipo.Pxt_codigo = (string)rs.Fields["pxt_codigo"].Value;
                    objParExcel_Tipo.Pxt_nombre = (string)rs.Fields["pxt_nombre"].Value;
                    objParExcel_Tipo.Pxt_recorrido = System.Convert.ToInt64(rs.Fields["pxt_recorrido"].Value);
                    objParExcel_Tipo.Pxt_contratos = System.Convert.ToInt64(rs.Fields["pxt_contratos"].Value);
                    objParExcel_Tipo.Pxt_estado = System.Convert.ToInt64(rs.Fields["pxt_estado"].Value);
                    lstParExcelTipo.Add(objParExcel_Tipo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExcelTipo;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExcelTipo;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
