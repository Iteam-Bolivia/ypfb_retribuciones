using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class SistemaObject:Sistema
    {
        /// <summary>
        /// existSistema Method
        /// </summary>
        public bool existSistema(long sis_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT sis_id FROM tab_sistema WHERE sis_id='" + sis_id + "'";

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
        /// listRol Method
        /// </summary>
        public List<Sistema> listSistema(long sis_id)
        {
            String where = (sis_id != 0 ? ("AND sis_id=" + sis_id + "") : "");
            List<Sistema> lstSistema = new List<Sistema>();

            try
            {
                Connection_On();
                SQL = "SELECT sis_id, sis_nombre, sis_bd, sis_estado " +
                          "FROM tab_sistema " +
                          "WHERE sis_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstSistema.Add(new Sistema(
                        System.Convert.ToInt32(rs.Fields["sis_id"].Value),
                        (string)(rs.Fields["sis_nombre"].Value),
                        (string)rs.Fields["sis_bd"].Value,
                        System.Convert.ToInt32(rs.Fields["sis_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstSistema;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSistema;
            }
        }/* Method listMenu */


        /// <summary>
        /// findSistema Method
        /// </summary>
        public List<Sistema> findSistema(long sis_id)
        {
            List<Sistema> lstSistema = new List<Sistema>();
            try
            {
                Connection_On();
                SQL = "SELECT sis_id, sis_nombre, sis_bd, sis_estado " +
                          "FROM tab_sistema " +
                          "WHERE sis_id='" + sis_id + "' AND sis_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstSistema.Add(new Sistema(
                        System.Convert.ToInt64(rs.Fields["sis_id"].Value),
                        (string)(rs.Fields["sis_nombre"].Value),
                        (string)rs.Fields["sis_bd"].Value,
                        System.Convert.ToInt32(rs.Fields["sis_estado"].Value)));
                    Connection_Off(1);
                    return lstSistema;
                }
                else
                {
                    Connection_Off(1);
                    return lstSistema;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSistema;
            }
        }
    }
}
