using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class SucursalObject:Sucursal
    {
        /// <summary>
        /// existSucursal Method
        /// </summary>
        public bool existSucursal(long suc_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT suc_id FROM tab_sucursal WHERE suc_id='" + suc_id + "'";

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
        /// findSucursal Method
        /// </summary>
        public long findSucursal(string suc_nombre)
        {
          long suc_id = 0;
          String where = (!suc_nombre.Equals("") ? ("AND suc_nombre='" + suc_nombre + "'") : "");
          try
          {
            Connection_On();
            SQL = "SELECT suc_id " +
                  "FROM tab_sucursal " +
                  "WHERE suc_estado = 1 " +
                   where;

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            if (!rs.EOF)
            {
              suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
            }
            Connection_Off(1);
            return suc_id;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return suc_id;
          }
        }/* Method listMenu */


        /// <summary>
        /// listSucursal Method
        /// </summary>
        public List<Sucursal> listSucursal(long suc_id)
        {
            String where = (suc_id != 0 ? ("AND suc_id=" + suc_id + "") : "");
            List<Sucursal> lstSistema = new List<Sucursal>();

            try
            {
                Connection_On();
                SQL = "SELECT suc_id, suc_codigo, emp_id, loc_id, suc_nosucursal, " +
                      "suc_nombre, suc_direccion, suc_telefono, suc_responsable, "+
                      "suc_estado "+
                      "FROM tab_sucursal " +
                      "WHERE suc_estado = 1 " +
                      where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstSistema.Add(new Sucursal(
                        System.Convert.ToInt64(rs.Fields["suc_id"].Value),
                        (string)(rs.Fields["suc_codigo"].Value),
                        System.Convert.ToInt64(rs.Fields["emp_id"].Value),
                        System.Convert.ToInt64(rs.Fields["loc_id"].Value),
                        (string)rs.Fields["suc_nosucursal"].Value,
                        (string)rs.Fields["suc_nombre"].Value,
                        (string)rs.Fields["suc_direccion"].Value,
                        (string)rs.Fields["suc_telefono"].Value,
                        (string)rs.Fields["suc_responsable"].Value,
                        System.Convert.ToInt32(rs.Fields["suc_estado"].Value)));
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
        public List<Sucursal> findSucursal(long suc_id)
        {
            List<Sucursal> lstSucursal = new List<Sucursal>();
            try
            {
                Connection_On();
                SQL = "SELECT suc_id, suc_codigo, emp_id, loc_id, suc_nosucursal, " +
                          "suc_nombre, suc_direccion, suc_telefono, suc_responsable, " +
                          "suc_estado" +
                          "FROM tab_sucursal " +
                          "WHERE suc_id='" + suc_id + "' AND suc_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstSucursal.Add(new Sucursal(
                        System.Convert.ToInt64(rs.Fields["suc_id"].Value),
                        (string)(rs.Fields["suc_codigo"].Value),
                        System.Convert.ToInt64(rs.Fields["emp_id"].Value),
                        System.Convert.ToInt64(rs.Fields["loc_id"].Value),
                        (string)rs.Fields["suc_nosucursal"].Value,
                        (string)rs.Fields["suc_nombre"].Value,
                        (string)rs.Fields["suc_direccion"].Value,
                        (string)rs.Fields["suc_telefono"].Value,
                        (string)rs.Fields["suc_responsable"].Value,
                        System.Convert.ToInt32(rs.Fields["suc_estado"].Value)));
                    Connection_Off(1);
                    return lstSucursal;
                }
                else
                {
                    Connection_Off(1);
                    return lstSucursal;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSucursal;
            }
        }
    }
}
