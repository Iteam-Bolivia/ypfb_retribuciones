using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class SistemaLogObject:SistemaLog
    {
        /// <summary>
        /// existSistemaLog Method
        /// </summary>
        public bool existSistemaLog(long isl_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT isl_id FROM tab_sistema_log WHERE isl_id='" + isl_id + "'";

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
       /// Lista de usuarios del sistema logeados por el codigo del usuario
       /// </summary>
       /// <param name="usu_id">usuario</param>
       /// <returns>lista de usuario y a que base de datos se logeran</returns>
        public List<SistemaLog> listSistemaLogByUsuario(long usu_id)
        {
            String where = (usu_id != 0 ? ("AND usu_id=" + usu_id + "") : "");
            List<SistemaLog> lstSistemaLog = new List<SistemaLog>();

            try
            {
                Connection_On();
                SQL = "SELECT isl_id, usu_login, isl_fecha, isl_hora, " +
                        "isl_accion, isl_estado, tab_usuaro.usu_id, suc_id, tab_rol.rol_id,  " +
                        "usu_nombre, usu_apellidos, usu_iniciales, usu_fono, usu_email, usu_login, " +
                        "usu_pass, usu_estado sis_id, sis_nombre sis_bd, sis_estado " +
                          "FROM tab_sistema_log, tab_usuario, tab_sistema " +
                          "WHERE isl_estado = 1 AND usu_estado = 1 AND sis_estado AND " +
                          "tab_sistema_log.sis_id = tab_sistema.sis_id AND tab_sistema_log.usu_id = " +
                          "tab_usuario.usu_id and isl_estado = 1 and usu_estado = 1" +
                          "and sis_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstSistemaLog.Add(new SistemaLog(
                        System.Convert.ToInt64(rs.Fields["isl_id"].Value),
                        new Sistema(
                            System.Convert.ToInt64(rs.Fields["sis_id"].Value),
                            (string)rs.Fields["sis_nombre"].Value,
                            (string)rs.Fields["sis_bd"].Value,
                            System.Convert.ToInt32(rs.Fields["sis_estado"].Value)),
                        new Usuario(
                            System.Convert.ToInt32(rs.Fields["usu_id"].Value),
                            (string)rs.Fields["suc_nombre"].Value,
                            (string)rs.Fields["usu_nombres"].Value,
                            (string)rs.Fields["usu_apellidos"].Value,
                            (string)rs.Fields["usu_fono"].Value,
                            (string)rs.Fields["usu_email"].Value,
                            (string)rs.Fields["usu_login"].Value,
                            (string)rs.Fields["rol_titulo"].Value,
                            System.Convert.ToInt64(rs.Fields["usu_estado"].Value)),
                        (string)rs.Fields["usu_login"].Value,
                        (string)rs.Fields["isl_fecha"].Value,
                        (string)rs.Fields["isl_hora"].Value,
                        (string)rs.Fields["isl_accion"].Value,
                        System.Convert.ToInt32(rs.Fields["urm_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstSistemaLog;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSistemaLog;
            }
        }/* Method listMenu */


        /// <summary>
        /// findSistemLog Method
        /// </summary>
        public List<SistemaLog> findSistemLog(long usu_id)
        {
            List<SistemaLog> lstSistemaLog = new List<SistemaLog>();
            try
            {
                Connection_On();
                SQL = "SELECT isl_id, usu_login, isl_fecha, isl_hora, " +
                        "isl_accion, isl_estado, tab_usuaro.usu_id, suc_id, tab_rol.rol_id,  " +
                        "usu_nombre, usu_apellidos, usu_iniciales, usu_fono, usu_email, usu_login, " +
                        "usu_pass, usu_estado sis_id, sis_nombre sis_bd, sis_estado " +
                          "FROM tab_sistema_log, tab_usuario, tab_sistema " +
                          "WHERE isl_estado = 1 AND usu_estado = 1 AND sis_estado AND " +
                          "tab_sistema_log.sis_id = tab_sistema.sis_id AND tab_sistema_log.usu_id = " +
                          "tab_usuario.usu_id AND tab_usuario.usu_id = '" + usu_id + "' AND sis_estado = 1" + 
                          " usu_estado = 1 AND isl_estado = 1 ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstSistemaLog.Add(new SistemaLog(
                        System.Convert.ToInt64(rs.Fields["isl_id"].Value),
                         new Sistema(
                            System.Convert.ToInt64(rs.Fields["sis_id"].Value),
                            (string)rs.Fields["sis_nombre"].Value,
                            (string)rs.Fields["sis_bd"].Value,
                            System.Convert.ToInt32(rs.Fields["sis_estado"].Value)),
                        new Usuario(
                            System.Convert.ToInt64(rs.Fields["usu_id"].Value),
                            (string)rs.Fields["suc_nombre"].Value,
                            (string)rs.Fields["usu_nombres"].Value,
                            (string)rs.Fields["usu_apellidos"].Value,
                            (string)rs.Fields["usu_fono"].Value,
                            (string)rs.Fields["usu_email"].Value,
                            (string)rs.Fields["usu_login"].Value,
                            (string)rs.Fields["rol_titulo"].Value,
                            System.Convert.ToInt64(rs.Fields["usu_estado"].Value)),
                        (string)rs.Fields["usu_login"].Value,
                        (string)rs.Fields["isl_fecha"].Value,
                        (string)rs.Fields["isl_hora"].Value,
                        (string)rs.Fields["isl_accion"].Value,
                        System.Convert.ToInt32(rs.Fields["isl_estado"].Value)));
                    Connection_Off(1);
                    return lstSistemaLog;
                }
                else
                {
                    Connection_Off(1);
                    return lstSistemaLog;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSistemaLog;
            }
        }
    }
}
