using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class MonedaObject : Moneda
    {

        public bool existMoneda(long mon_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT mon_id FROM tab_moneda WHERE mon_id='" + mon_id + "'";

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
                Connection_Off(1);
                return flag;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }/* Method existMoneda */



        /// <summary>
        /// Lista de todas las monedas
        /// </summary>
        /// <param name="mon_id">moendad Id</param>
        /// <returns>Lista de monedas</returns>
        public List<Moneda> listMoneda(long mon_id)
        {
            String where = (mon_id != 0 ? ("AND mon_id=" + mon_id + "") : "");
            List<Moneda> lstMoneda = new List<Moneda>();

            try
            {
                Connection_On();
                SQL = "SELECT mon_id, mon_codigo, mon_nombre, mon_estado " +
                          "FROM tab_moneda " +
                          "WHERE mon_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMoneda.Add(new Moneda(
                        Convert.ToInt64(rs.Fields["mon_id"].Value),
                        Convert.ToString(rs.Fields["mon_codigo"].Value),
                        Convert.ToString(rs.Fields["mon_nombre"].Value),
                        Convert.ToInt32(rs.Fields["mon_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMoneda;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMoneda;
            }
        }/* Method listMoneda */
    }
}