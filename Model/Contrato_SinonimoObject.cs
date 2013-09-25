using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class Contrato_SinonimoObject : Contrato_Sinonimo
    {
        
        public bool existContrato_Sinonimo(long cts_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT cts_id " +
                      "FROM tab_contrato_sinonimo " +
                      "WHERE cts_id='" + cts_id + " AND cts_estado = 1";

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
        /// findContrato_Sinonimo Method
        /// </summary>
        public List<Contrato_Sinonimo> findContrato_Sinonimo(long cts_id)
        {
            //string where = 
            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
            try
            {
                Connection_On();
                SQL = "SELECT a.cts_id, a.ctt_id,b.ctt_nombre, cts_nombre, cts_estado " +
                    " FROM tab_contrato_sinonimo a, tab_contrato b" +
                    " WHERE a.ctt_id = b.ctt_id AND a.cts_id = '" + cts_id + "' AND a.cts_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Contrato_Sinonimo Contrato_Sinonimo = new Contrato_Sinonimo();
                    Contrato_Sinonimo.Cts_id = Convert.ToInt64(rs.Fields["cts_id"].Value);
                    Contrato_Sinonimo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    Contrato_Sinonimo.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    Contrato_Sinonimo.Cts_nombre = Convert.ToString(rs.Fields["cts_nombre"].Value);
                    Contrato_Sinonimo.Cts_estado = Convert.ToInt32(rs.Fields["cts_estado"].Value);
                    lstContrato_Sinonimo.Add(Contrato_Sinonimo);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstContrato_Sinonimo;
                }
                else
                {
                    Connection_Off(1);
                    return lstContrato_Sinonimo;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato_Sinonimo;
            }
        }
        public List<Contrato_Sinonimo> listContrato_Sinonimo(long cts_id)
        {
            string where = (cts_id != 0 ? ("AND cts_id=" + cts_id + " ") : " ");
            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
            try
            {
                Connection_On();
                SQL = "SELECT a.cts_id, a.ctt_id,b.ctt_nombre, cts_nombre, cts_estado " +
                    " FROM tab_contrato_sinonimo a, tab_contrato b" +
                    " WHERE a.ctt_id = b.ctt_id AND a.cts_estado = 1 " + 
                    where +
                    " ORDER BY a.cts_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato_Sinonimo Contrato_Sinonimo = new Contrato_Sinonimo();
                    Contrato_Sinonimo.Cts_id = Convert.ToInt64(rs.Fields["cts_id"].Value);
                    Contrato_Sinonimo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    Contrato_Sinonimo.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    Contrato_Sinonimo.Cts_nombre = Convert.ToString(rs.Fields["cts_nombre"].Value);
                    Contrato_Sinonimo.Cts_estado= Convert.ToInt32(rs.Fields["cts_estado"].Value);
                    lstContrato_Sinonimo.Add(Contrato_Sinonimo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContrato_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato_Sinonimo;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public List<Contrato_Sinonimo> listContrato_SinonimoPorContrato(long ctt_id)
        {
            string where = (ctt_id != 0 ? ("AND a.ctt_id=" + ctt_id + " ") : " ");
            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
            try
            {
                Connection_On();
                SQL = "SELECT a.cts_id, a.ctt_id,b.ctt_nombre, cts_nombre, cts_estado " +
                    " FROM tab_contrato_sinonimo a, tab_contrato b" +
                    " WHERE a.ctt_id = b.ctt_id AND a.cts_estado = 1 " +
                    where +
                    " ORDER BY a.cts_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato_Sinonimo Contrato_Sinonimo = new Contrato_Sinonimo();
                    Contrato_Sinonimo.Cts_id = Convert.ToInt64(rs.Fields["cts_id"].Value);
                    Contrato_Sinonimo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    Contrato_Sinonimo.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    Contrato_Sinonimo.Cts_nombre = Convert.ToString(rs.Fields["cts_nombre"].Value);
                    Contrato_Sinonimo.Cts_estado = Convert.ToInt32(rs.Fields["cts_estado"].Value);
                    lstContrato_Sinonimo.Add(Contrato_Sinonimo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContrato_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato_Sinonimo;
            }
            finally
            {
                Connection_Off(1);
            }
        }


        public Contrato buscarSinonimoContrato(string ctt_nombre)
        {
            Contrato objContrato = null;
          string Where = (ctt_nombre != "" ? ("AND tab_contrato.ctt_nombre = '" + ctt_nombre + "'") : "");
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_nombre " +
                    "FROM " +
                    "tab_contrato " +
                    "WHERE " +
                    "tab_contrato.ctt_estado = 1 " +
                      Where;

              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
              if (!rs.EOF)
              {
                  objContrato = new Contrato();
                  objContrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  objContrato.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  Connection_Off(1);
                  return objContrato;
              }
              else
              {
                  SQL = "SELECT " +
                        "tab_contrato.ctt_nombre, " +
                        "tab_contrato_sinonimo.ctt_id, " +
                        "tab_contrato_sinonimo.cts_nombre " +
                        "FROM " +
                        "tab_contrato " +
                        "INNER JOIN tab_contrato_sinonimo ON tab_contrato.ctt_id = tab_contrato_sinonimo.ctt_id " +
                        "WHERE " +
                        "tab_contrato_sinonimo.cts_estado = 1 " +
                        "AND tab_contrato_sinonimo.cts_nombre = '" + ctt_nombre + "'";
                  rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                  if (!rs2.EOF)
                  {
                      objContrato = new Contrato();
                      objContrato.Ctt_id = Convert.ToInt64(rs2.Fields["ctt_id"].Value);
                      objContrato.Ctt_nombre = Convert.ToString(rs2.Fields["ctt_nombre"].Value);
                      objContrato.Cts_nombre = Convert.ToString(rs2.Fields["cts_nombre"].Value);
                  }
                  Connection_Off(2);
                  return objContrato;
              }
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              Connection_Off(2);
              return objContrato;
          }
          finally
          {
              Connection_Off(1);
              Connection_Off(2);
          }
       }

    }
}