using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ParExcelObject : ParExcel
    {
        public List<ParExcel> listParExcel(long pex_id)
        {
            String where = (pex_id != 0 ? ("AND pex_id=" + pex_id + "") : "");
            List<ParExcel> lstParExce = new List<ParExcel>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_parexcel.pex_id, " +
                      "tab_parexcel.pex_codigo, " +
                      "tab_parexcel.pex_nombre, " +
                      "tab_parexcel.pex_hoja, " +
                      "tab_parexcel.pex_estado, " +
                      "tab_parexcel.tcl_id, " +
                      "tab_parexcel.pro_id, " +
                      "tab_parexcel.pxt_id, " +
                      "tab_tipo_calculo.tcl_nombre, " +
                      "tab_parexcel_tipo.pxt_codigo " +
                      "FROM " +
                      "tab_parexcel " +
                      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_parexcel.tcl_id " +
                      "INNER JOIN tab_parexcel_tipo ON tab_parexcel_tipo.pxt_id = tab_parexcel.pxt_id " +
                      "WHERE tab_parexcel.pex_estado = 1 AND " +
                      "tab_tipo_calculo.tcl_id = tab_parexcel.tcl_id " +
                      where + " order by tab_parexcel.pex_id ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ParExcel objParexcel = new ParExcel();
                    objParexcel.Pex_id = System.Convert.ToInt64(rs.Fields["pex_id"].Value);
                    objParexcel.Pex_codigo = (string)rs.Fields["pex_codigo"].Value;
                    objParexcel.Pex_nombre = (string)rs.Fields["pex_nombre"].Value;
                    objParexcel.Pex_hoja = (string)rs.Fields["pex_hoja"].Value;
                    objParexcel.Pex_estado = System.Convert.ToInt64(rs.Fields["pex_estado"].Value);
                    objParexcel.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
                    objParexcel.Tcl_nombre = (string)rs.Fields["tcl_nombre"].Value;
                    objParexcel.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    objParexcel.Pxt_id = System.Convert.ToInt64(rs.Fields["pxt_id"].Value);
                    objParexcel.Pxt_codigo = System.Convert.ToString(rs.Fields["pxt_codigo"].Value);
                    if (System.Convert.ToInt64(rs.Fields["pro_id"].Value) != 0)
                    {
                        objParexcel.Pro_nombre = GetProducto(System.Convert.ToInt64(rs.Fields["pro_id"].Value));
                    }
                    else
                        objParexcel.Pro_nombre = "";
                    lstParExce.Add(objParexcel);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExce;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExce;
            }
            finally
            {
                Connection_Off(1);
            }
        }




        public List<ParExcel> listParExcelTipo(long pxt_id)
        {
            String where = (pxt_id != 0 ? ("AND tab_parexcel.pxt_id=" + pxt_id + "") : "");
            List<ParExcel> lstParExce = new List<ParExcel>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_parexcel.pex_id, " +
                      "tab_parexcel.pex_codigo, " +
                      "tab_parexcel.pex_nombre, " +
                      "tab_parexcel.pex_hoja, " +
                      "tab_parexcel.pex_estado, " +
                      "tab_parexcel.tcl_id, " +
                      "tab_parexcel.pro_id, " +
                      "tab_parexcel.pxt_id, " +
                      "tab_tipo_calculo.tcl_nombre, " +
                      "tab_parexcel_tipo.pxt_codigo " +
                      "FROM " +
                      "tab_parexcel " +
                      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_parexcel.tcl_id " +
                      "INNER JOIN tab_parexcel_tipo ON tab_parexcel_tipo.pxt_id = tab_parexcel.pxt_id " +
                      "WHERE tab_parexcel.pex_estado = 1 AND " +
                      "tab_tipo_calculo.tcl_id = tab_parexcel.tcl_id " +
                      where + " order by tab_parexcel.pex_id ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ParExcel objParexcel = new ParExcel();
                    objParexcel.Pex_id = System.Convert.ToInt64(rs.Fields["pex_id"].Value);
                    objParexcel.Pex_codigo = (string)rs.Fields["pex_codigo"].Value;
                    objParexcel.Pex_nombre = (string)rs.Fields["pex_nombre"].Value;
                    objParexcel.Pex_hoja = (string)rs.Fields["pex_hoja"].Value;
                    objParexcel.Pex_estado = System.Convert.ToInt64(rs.Fields["pex_estado"].Value);
                    objParexcel.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
                    objParexcel.Tcl_nombre = (string)rs.Fields["tcl_nombre"].Value;
                    objParexcel.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    objParexcel.Pxt_id = System.Convert.ToInt64(rs.Fields["pxt_id"].Value);
                    objParexcel.Pxt_codigo = System.Convert.ToString(rs.Fields["pxt_codigo"].Value);
                    if (System.Convert.ToInt64(rs.Fields["pro_id"].Value) != 0)
                    {
                        objParexcel.Pro_nombre = GetProducto(System.Convert.ToInt64(rs.Fields["pro_id"].Value));
                    }
                    else
                        objParexcel.Pro_nombre = "";
                    lstParExce.Add(objParexcel);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstParExce;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstParExce;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public string GetProducto(long pro_id)
        {
            List<Producto> producto = new List<Producto>();
            ProductoObject objProducto = new ProductoObject();
            producto = objProducto.listProducto(pro_id);
            return producto[0].Pro_nombre;
        }
    }
}
