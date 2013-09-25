/*
 * @author acastellon
 * ProvinciaObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class ProvinciaObject : Provincia
    {

        /// <summary>
        /// existProvincia Method
        /// </summary>
        public bool existProvincia(long pro_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT pro_id " +
                      "FROM tab_provincia " +
                      "WHERE pro_id='" + pro_id + " AND pro_estado = 1";

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
        /// findProvincia Method
        /// </summary>
        public List<Provincia> findProvincia(long pro_id)
        {
            List<Provincia> lstProvincia = new List<Provincia>();

            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_provincia.pro_id, " +
                      "tab_provincia.dep_id, " +
                      "tab_departamento.dep_nombre, " +
                      "tab_provincia.pro_codigo, " +
                      "tab_provincia.pro_nombre, " +
                      "tab_provincia.pro_estado " +
                      "FROM " +
                      "tab_provincia " +
                      "INNER JOIN tab_departamento ON tab_provincia.dep_id = tab_departamento.dep_id " +
                      "WHERE tab_provincia.pro_estado = 1 AND tab_provincia.pro_id='" + pro_id;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Provincia provincia = new Provincia();
                    provincia.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    provincia.Dep_nombre = System.Convert.ToString(rs.Fields["dep_nombre"].Value);
                    provincia.Pro_codigo = System.Convert.ToString(rs.Fields["pro_codigo"].Value);
                    provincia.Pro_nombre = System.Convert.ToString(rs.Fields["pro_nombre"].Value);
                    provincia.Pro_estado = System.Convert.ToInt64(rs.Fields["Pro_estado"].Value);
                    lstProvincia.Add(provincia);
                    rs.MoveNext();
                }
                else
                {
                    Connection_Off(1);
                    return lstProvincia;
                }
                Connection_Off(1);
                return lstProvincia;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProvincia;
            }
        }


        /// <summary>
        /// listProvincia Method
        /// </summary>
        public List<Provincia> listProvincia(long pro_id)
        {
            String where = (pro_id != 0 ? ("AND pro_id=" + pro_id + " ") : " ");
            List<Provincia> lstProvincia = new List<Provincia>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_provincia.pro_id, " +
                      "tab_provincia.dep_id, " +
                      "tab_departamento.dep_nombre, " +
                      "tab_provincia.pro_codigo, " +
                      "tab_provincia.pro_nombre, " +
                      "tab_provincia.pro_estado " +
                      "FROM " +
                      "tab_provincia " +
                      "INNER JOIN tab_departamento ON tab_provincia.dep_id = tab_departamento.dep_id " +
                      "WHERE tab_provincia.pro_estado = 1 " +
                      where +
                      " ORDER BY tab_provincia.pro_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Provincia provincia = new Provincia();
                    provincia.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    provincia.Dep_id = System.Convert.ToInt64(rs.Fields["dep_id"].Value);
                    provincia.Dep_nombre = System.Convert.ToString(rs.Fields["dep_nombre"].Value);
                    provincia.Pro_codigo = System.Convert.ToString(rs.Fields["pro_codigo"].Value);
                    provincia.Pro_nombre = System.Convert.ToString(rs.Fields["pro_nombre"].Value);
                    provincia.Pro_estado = System.Convert.ToInt64(rs.Fields["Pro_estado"].Value);
                    lstProvincia.Add(provincia);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstProvincia;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProvincia;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}