using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class Tipo_CostoObject:TipoCosto
    {
        public List<TipoCosto> listTipoCosto(long tco_id)
        {
            String where = (tco_id != 0 ? ("AND tco_id=" + tco_id + "") : "");
            List<TipoCosto> lstTipoCosto = new List<TipoCosto>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_tipo_costo.tco_id, " +
                      "tab_tipo_costo.tco_codigo, " +
                      "tab_tipo_costo.tco_nombre, " +
                      "tab_tipo_costo.tco_estado " +
                      "FROM tab_tipo_costo " +
                      "WHERE tab_tipo_costo.tco_estado = 1 " + where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    lstTipoCosto.Add(new TipoCosto(
                        System.Convert.ToInt64(rs.Fields["tco_id"].Value),
                        (string)rs.Fields["tco_codigo"].Value,
                        (string)rs.Fields["tco_nombre"].Value,
                        System.Convert.ToInt64(rs.Fields["tco_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipoCosto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipoCosto;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
