/*
 * @author acastellon
 * EmpresaObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class EmpresaObject : Empresa
    {

        public long generateIdEmpresa()
        {
            long emp_id = 0;
            try
            { //Open Connection objeto
                Connection_On();
                SQL = "SELECT nextval('tab_empresa_emp_id_seq')";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                // If recorser is OEF
                if (!rs.EOF)
                {
                    if (rs.Fields["nextval"].Value == null)
                    {
                        emp_id = 0;
                    }
                    else
                    {
                        emp_id = System.Convert.ToInt64(rs.Fields["nextval"].Value);
                    }
                    Connection_Off(1);

                }
                else
                {
                    emp_id = 0;
                    Connection_Off(1);
                }
                return emp_id;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error; " + err.Message);
                emp_id = 0;
                return emp_id;
            }
        }



        /// <summary>
        /// listEmpresa Method
        /// </summary>
        public List<Empresa> listEmpresa(long emp_id)
        {
            String where = (emp_id != 0 ? ("AND emp_id=" + emp_id + "") : "");
            List<Empresa> lstEmpresa = new List<Empresa>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_empresa.emp_id, " +
                      "tab_empresa.emp_nit, " +
                      "tab_empresa.emp_nombre, " +
                      "tab_empresa.emp_propietario, " +
                      "tab_empresa.emp_dir, " +
                      "tab_empresa.emp_telefono, " +
                      "tab_empresa.emp_email, " +
                      "tab_empresa.emp_estado " +
                      "FROM " + "tab_empresa " +
                      "WHERE tab_empresa.emp_estado = 1 " + where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    lstEmpresa.Add(new Empresa(System.Convert.ToInt64(rs.Fields["emp_id"].Value), (string)rs.Fields["emp_nit"].Value, (string)rs.Fields["emp_nombre"].Value, (string)rs.Fields["emp_propietario"].Value, (string)rs.Fields["emp_dir"].Value, (string)rs.Fields["emp_telefono"].Value, (string)rs.Fields["emp_email"].Value, System.Convert.ToInt64(rs.Fields["emp_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstEmpresa;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstEmpresa;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
