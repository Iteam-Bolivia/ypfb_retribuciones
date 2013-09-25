/*
 * @author acastellon
 * LocalidadObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class LocalidadObject : Localidad
    {

        /// <summary>
        /// existLocalidad Method
        /// </summary>
        public bool existLocalidad(long loc_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT loc_id " +
                      "FROM tab_localidad " +
                      "WHERE loc_id='" + loc_id + " AND loc_estado = 1";

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
        /// findLocalidad Method
        /// </summary>
        public List<Localidad> findLocalidad(long loc_id)
        {
            List<Localidad> lstLocalidad = new List<Localidad>();

            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_localidad.loc_id, " +
                      "tab_localidad.pro_id, " +
                      "tab_provincia.pro_nombre, " +
                      "tab_localidad.loc_codigo, " +
                      "tab_localidad.loc_nombre, " +
                      "tab_localidad.loc_estado " +
                      "FROM " +
                      "tab_localidad " +
                      "INNER JOIN tab_provincia ON tab_localidad.pro_id = tab_provincia.pro_id " +
                      "WHERE tab_localidad.loc_estado = 1 AND tab_localidad.loc_id='" + loc_id;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Localidad localidad = new Localidad();
                    localidad.Loc_id = System.Convert.ToInt64(rs.Fields["loc_id"].Value);
                    localidad.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    localidad.Pro_nombre = System.Convert.ToString(rs.Fields["pro_nombre"].Value);
                    localidad.Loc_codigo = System.Convert.ToString(rs.Fields["loc_codigo"].Value);
                    localidad.Loc_nombre = System.Convert.ToString(rs.Fields["loc_nombre"].Value);
                    localidad.Loc_estado = System.Convert.ToInt64(rs.Fields["loc_estado"].Value);
                    lstLocalidad.Add(localidad);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstLocalidad;
                }
                else
                {
                    Connection_Off(1);
                    return lstLocalidad;
                }
                Connection_Off(1);
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstLocalidad;
            }
        }


        /// <summary>
        /// listLocalidad Method
        /// </summary>
        public List<Localidad> listLocalidad(long loc_id)
        {
            String where = (loc_id != 0 ? ("AND loc_id=" + loc_id + " ") : " ");
            List<Localidad> lstLocalidad = new List<Localidad>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_localidad.loc_id, " +
                      "tab_localidad.pro_id, " +
                      "tab_provincia.pro_nombre, " +
                      "tab_localidad.loc_codigo, " +
                      "tab_localidad.loc_nombre, " +
                      "tab_localidad.loc_estado " +
                      "FROM " +
                      "tab_localidad " +
                      "INNER JOIN tab_provincia ON tab_localidad.pro_id = tab_provincia.pro_id " +
                      "WHERE tab_localidad.loc_estado = 1 " +
                      where +
                      " ORDER BY tab_localidad.loc_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Localidad localidad = new Localidad();
                    localidad.Loc_id = System.Convert.ToInt64(rs.Fields["loc_id"].Value);
                    localidad.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    localidad.Pro_nombre = System.Convert.ToString(rs.Fields["pro_nombre"].Value);
                    localidad.Loc_codigo = System.Convert.ToString(rs.Fields["loc_codigo"].Value);
                    localidad.Loc_nombre = System.Convert.ToString(rs.Fields["loc_nombre"].Value);
                    localidad.Loc_estado = System.Convert.ToInt64(rs.Fields["loc_estado"].Value);
                    lstLocalidad.Add(localidad);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstLocalidad;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstLocalidad;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}