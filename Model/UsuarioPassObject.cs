using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class UsuarioPassObject:UsuarioPass
    {
        /// <summary>
        /// existUsuarioPass Method
        /// </summary>
        public bool existUsuarioPass(long usp_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT usp_id FROM tab_usuario_pass WHERE usp_id='" + usp_id + "'";

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
        /// listUsuarioPass Method
        /// </summary>
        public List<UsuarioPass> listUsuarioPass(long usp_id)
        {
            String where = (usp_id != 0 ? ("AND usp_id=" + usp_id + "") : "");
            List<UsuarioPass> lstUsuarioPass = new List<UsuarioPass>();

            try
            {
                Connection_On();
                SQL = "SELECT usp_id, usp_id, usp_login, usp_pass, usp_estado " +
                          "FROM tab_usuario_pass " +
                          "WHERE usp_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstUsuarioPass.Add(new UsuarioPass(
                        System.Convert.ToInt64(rs.Fields["usp_id"].Value),
                        System.Convert.ToInt32(rs.Fields["usu_id"].Value),
                        (string)rs.Fields["usu_login"].Value,
                        (string)rs.Fields["usu_pass"].Value,
                        System.Convert.ToInt32(rs.Fields["usp_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstUsuarioPass;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsuarioPass;
            }
        }/* Method listMenu */


        /// <summary>
        /// findBloque Method
        /// </summary>
        public List<UsuarioPass> findUsuarioPass(long usp_id)
        {
            List<UsuarioPass> lstBloque = new List<UsuarioPass>();
            try
            {
                Connection_On();
                SQL = "SELECT usp_id, usu_id, usu.login, usu_pass, usp_estado " +
                          "FROM tab_usuario_pass " +
                          "WHERE usp_id='" + usp_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstBloque.Add(new UsuarioPass(
                        System.Convert.ToInt64(rs.Fields["usp_id"].Value),
                        System.Convert.ToInt32(rs.Fields["usu_id"].Value), 
                        (string)rs.Fields["usu_login"].Value,
                        (string)rs.Fields["usu_pass"].Value, 
                        System.Convert.ToInt32(rs.Fields["blo_estado"].Value)));
                    Connection_Off(1);
                    return lstBloque;
                }
                else
                {
                    Connection_Off(1);
                    return lstBloque;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstBloque;
            }
        }
    }
}
