using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class RolObject : Rol
    {
        /// <summary>
        /// existRol Method
        /// </summary>
        public bool existRol(long rol_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT rol_id FROM tab_rol WHERE rol_id='" + rol_id + "'";

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
        /// findRol Method
        /// </summary>
        public long findRol(string rol_titulo)
        {
            long rol_id = 0;
            String where = (!rol_titulo.Equals("") ? ("AND rol_titulo='" + rol_titulo + "'") : "");
            try
            {
                Connection_On();
                SQL = "SELECT rol_id " +
                      "FROM tab_rol " +
                      "WHERE rol_estado = 1 " +
                       where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    rol_id = System.Convert.ToInt64(rs.Fields["rol_id"].Value);
                }
                Connection_Off(1);
                return rol_id;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return rol_id;
            }
        }/* Method listMenu */

        /// <summary>
        /// listRol Method
        /// </summary>
        public List<Rol> listRol(long rol_id)
        {
            String where = (rol_id != 0 ? ("AND rol_id=" + rol_id + "") : "");
            List<Rol> lstRol = new List<Rol>();

            try
            {
                Connection_On();
                SQL = "SELECT rol_id, rol_cod, rol_titulo, rol_descripcion, rol_estado " +
                    "FROM tab_rol " +
                    "WHERE rol_estado = 1 " +
                    where;
                SQL += " ORDER BY rol_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstRol.Add(new Rol(
                        System.Convert.ToInt32(rs.Fields["rol_id"].Value),
                        (string)(rs.Fields["rol_cod"].Value),
                        (string)rs.Fields["rol_titulo"].Value,
                        (string)rs.Fields["rol_descripcion"].Value,
                        System.Convert.ToInt32(rs.Fields["rol_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstRol;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRol;
            }
        }/* Method listMenu */


        /// <summary>
        /// findRol Method
        /// </summary>
        public List<Rol> findRol(long rol_id)
        {
            List<Rol> lstRol = new List<Rol>();
            try
            {
                Connection_On();
                SQL = "SELECT rol_id, rol_cod, rol_titulo, rol_descripcion, rol_estado " +
                          "FROM tab_rol " +
                          "WHERE rol_id='" + rol_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstRol.Add(new Rol(
                        System.Convert.ToInt32(rs.Fields["rol_id"].Value),
                        (string)(rs.Fields["rol_cod"].Value),
                        (string)rs.Fields["rol_titulo"].Value,
                        (string)rs.Fields["rol_descripcion"].Value,
                        System.Convert.ToInt32(rs.Fields["rol_estado"].Value)));
                    Connection_Off(1);
                    return lstRol;
                }
                else
                {
                    Connection_Off(1);
                    return lstRol;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRol;
            }
        }
        #region Uso Futuro
        //public List<Rol> listRolSegunCriterio(string rol_cod, string rol_titulo, string rol_descripcion)
        //{
        //    //String where = (rol_id != 0 ? ("AND rol_id=" + rol_id + "") : "");
        //    List<Rol> lstRol = new List<Rol>();

        //    try
        //    {
        //        Connection_On();
        //        SQL = "SELECT rol_id, rol_cod, rol_titulo, rol_descripcion, rol_estado " +
        //            "FROM tab_rol " +
        //            "WHERE rol_estado = 1 ";
        //        SQL += "AND rol_cod LIKE '%" + rol_cod + "%' ";
        //        SQL += "AND rol_titulo LIKE '%" + rol_titulo + "%' ";
        //        SQL += "AND rol_descripcion LIKE '%" + rol_descripcion + "%' ";
        //        // Execute the query specifying static sursor, batch optimistic locking
        //        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //        while (!rs.EOF)
        //        {
        //            // Fill data List
        //            lstRol.Add(new Rol(
        //                System.Convert.ToInt32(rs.Fields["rol_id"].Value),
        //                (string)(rs.Fields["rol_cod"].Value),
        //                (string)rs.Fields["rol_titulo"].Value,
        //                (string)rs.Fields["rol_descripcion"].Value,
        //                System.Convert.ToInt32(rs.Fields["rol_estado"].Value)));
        //            rs.MoveNext();
        //        }
        //        Connection_Off(1);
        //        return lstRol;
        //    }
        //    catch (COMException err)
        //    {
        //        Console.WriteLine("Error: " + err.Message);
        //        Connection_Off(1);
        //        return lstRol;
        //    }
        //}
        #endregion
    }
}