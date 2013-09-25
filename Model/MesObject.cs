/*
 * @author acastellon
 * MesObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class MesObject : Mes
    {

        /// <summary>
        /// existMes Method
        /// </summary>
        public bool existMes(long mes_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT mes_id " +
                      "FROM tab_mes " +
                      "WHERE mes_id='" + mes_id + " AND mes_estado = 1";

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
        }

        /// <summary>
        /// findMes Method
        /// </summary>
        public List<Mes> findMes(long mes_id)
        {
            List<Mes> lstMes = new List<Mes>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_mes.mes_id, " +
                      "tab_mes.mes_codigo, " +
                      "tab_mes.mes_nombre, " +
                      "tab_mes.mes_estado " +
                      "FROM " +
                      "tab_mes " +
                      "WHERE tab_mes.mes_estado = 1 AND tab_mes.mes_id='" + mes_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Mes mes = new Mes();
                    mes.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    mes.Mes_codigo = System.Convert.ToString(rs.Fields["mes_codigo"].Value);
                    mes.Mes_nombre = System.Convert.ToString(rs.Fields["mes_nombre"].Value);
                    mes.Mes_estado = System.Convert.ToInt64(rs.Fields["mes_estado"].Value);
                    lstMes.Add(mes);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstMes;
                }
                else
                {
                    Connection_Off(1);
                    return lstMes;
                }
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMes;
            }
        }


        /// <summary>
        /// listMes Method
        /// </summary>
        public List<Mes> listMes(long mes_id)
        {
            String where = (mes_id != 0 ? ("AND mes_id=" + mes_id + " ") : " ");
            List<Mes> lstMes = new List<Mes>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_mes.mes_id, " +
                      "tab_mes.mes_codigo, " +
                      "tab_mes.mes_nombre, " +
                      "tab_mes.mes_estado " +
                      "FROM " +
                      "tab_mes " +
                      "WHERE tab_mes.mes_estado = 1 " +
                      where +
                      " ORDER BY tab_mes.mes_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Mes mes = new Mes();
                    mes.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    mes.Mes_codigo = System.Convert.ToString(rs.Fields["mes_codigo"].Value);
                    mes.Mes_nombre = System.Convert.ToString(rs.Fields["mes_nombre"].Value);
                    mes.Mes_estado = System.Convert.ToInt64(rs.Fields["mes_estado"].Value);
                    lstMes.Add(mes);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMes;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMes;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}