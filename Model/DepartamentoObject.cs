/*
 * @author acastellon
 * DepartamentoObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class DepartamentoObject : Departamento
    {

        /// <summary>
        /// existDepartamento Method
        /// </summary>
        public bool existDepartamento(long dep_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT dep_id " +
                      "FROM tab_departamento " +
                      "WHERE dep_id='" + dep_id + " AND dep_estado = 1";

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
                return flag;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }

        /// <summary>
        /// findDepartamento Method
        /// </summary>
        public List<Departamento> findDepartamento(long dep_id)
        {
            List<Departamento> lstDepartamento = new List<Departamento>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_departamento.dep_id, " +
                      "tab_departamento.dep_codigo, " +
                      "tab_departamento.dep_nombre, " +
                      "tab_departamento.dep_estado " +
                      "FROM " +
                      "tab_departamento " +
                      "WHERE tab_departamento.dep_estado = 1 AND tab_departamento.dep_id='" + dep_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Departamento departamento = new Departamento();
                    departamento.Dep_id = System.Convert.ToInt64(rs.Fields["dep_id"].Value);
                    departamento.Dep_codigo = System.Convert.ToString(rs.Fields["dep_codigo"].Value);
                    departamento.Dep_nombre = System.Convert.ToString(rs.Fields["dep_nombre"].Value);
                    departamento.Dep_estado = System.Convert.ToInt64(rs.Fields["dep_estado"].Value);
                    lstDepartamento.Add(departamento);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstDepartamento;
                }
                else
                {
                    Connection_Off(1);
                    return lstDepartamento;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstDepartamento;
            }
        }


        /// <summary>
        /// listDepartamento Method
        /// </summary>
        public List<Departamento> listDepartamento(long dep_id)
        {
            String where = (dep_id != 0 ? ("AND dep_id=" + dep_id + " ") : " ");
            List<Departamento> lstDepartamento = new List<Departamento>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_departamento.dep_id, " +
                      "tab_departamento.dep_codigo, " +
                      "tab_departamento.dep_nombre, " +
                      "tab_departamento.dep_estado " +
                      "FROM " +
                      "tab_departamento " +
                      "WHERE tab_departamento.dep_estado = 1 " +
                      where +
                      " ORDER BY tab_departamento.dep_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Departamento departamento = new Departamento();
                    departamento.Dep_id = System.Convert.ToInt64(rs.Fields["dep_id"].Value);
                    departamento.Dep_codigo = System.Convert.ToString(rs.Fields["dep_codigo"].Value);
                    departamento.Dep_nombre = System.Convert.ToString(rs.Fields["dep_nombre"].Value);
                    departamento.Dep_estado = System.Convert.ToInt64(rs.Fields["dep_estado"].Value);
                    lstDepartamento.Add(departamento);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstDepartamento;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstDepartamento;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}