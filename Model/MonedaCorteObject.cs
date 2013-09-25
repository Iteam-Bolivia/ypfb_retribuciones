using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class MonedaCorteObject: MonedaCorte
    {
        /// <summary>
        /// existMonedaCorte Method
        /// </summary>
        public bool existMonedaCorte(long mco_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT mco_id FROM tab_moneda_corte WHERE mco_id='" + mco_id + "'";

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
        }/* Method existUser */

        /// <summary>
        /// listMonedaCorte Method
        /// </summary>
        public List<MonedaCorte> listMonedaCorteByMonedaId(long mon_id)
        {
            String where = (mon_id != 0 ? ("AND tab_moneda.mon_id=" + mon_id + "") : "");
            List<MonedaCorte> lstMonedaCorte = new List<MonedaCorte>();

            try
            {
                Connection_On();
                SQL = "SELECT mco_id, mco_tipo, mco_valor, mco_estado, " +
                          "tab_moneda.mon_id, mon_codigo, mon_nombre, nom_estado " +
                          "FROM tab_moneda_corte, tab_moneda" +
                          "WHERE mco_estado = 1 AND mon_estado = 1  AND "+
                          "tab_moneda.mon_id=tab_moneda_core.mco_id " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMonedaCorte.Add(new MonedaCorte(
                        System.Convert.ToInt64(rs.Fields["mco_id"].Value),
                        new Moneda(System.Convert.ToInt64(rs.Fields["mon_id"].Value),
                            (string)rs.Fields["mon_codigo"].Value,
                            (string)rs.Fields["mon_nombre"].Value,
                            System.Convert.ToInt32(rs.Fields["mon_estado"].Value)),
                        (int)rs.Fields["mco_tipo"].Value,
                        (decimal)rs.Fields["mco_valor"].Value,
                        System.Convert.ToInt32(rs.Fields["mco_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMonedaCorte;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMonedaCorte;
            }
        }/* Method listMenu */


        /// <summary>
        /// findBloque Method
        /// </summary>
        public List<MonedaCorte> findMonedaCorteByMonedaId(long mon_id)
        {
            List<MonedaCorte> lstMonedaCorte = new List<MonedaCorte>();
            try
            {
                Connection_On();
                SQL = "SELECT mco_id, tab_moneda_corte.mon_id, mco_tipo, mco_valor, mco_estado " +
                          "tab_moneda.mon_id, mon_codigo, mon_nombre, nom_estado" +
                          "FROM tab_moneda_corte, tab_moneda " +
                          "WHERE mon_id='" + mon_id + "' AND mon_estado = 1 AND " +
                          "mco_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstMonedaCorte.Add(new MonedaCorte(
                        System.Convert.ToInt64(rs.Fields["mco_id"].Value),
                        new Moneda(System.Convert.ToInt64(rs.Fields["mon_id"].Value),
                            (string)rs.Fields["mon_codigo"].Value,
                            (string)rs.Fields["mon_nombre"].Value, 
                            System.Convert.ToInt32(rs.Fields["mon_estado"].Value)),
                        (int)rs.Fields["mco_tipo"].Value, 
                        (decimal)rs.Fields["mco_valor"].Value, 
                        System.Convert.ToInt32(rs.Fields["mco_estado"].Value)));
                    Connection_Off(1);
                    return lstMonedaCorte;
                }
                else
                {
                    Connection_Off(1);
                    return lstMonedaCorte;
                }
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMonedaCorte;
            }
        }
    }
}
