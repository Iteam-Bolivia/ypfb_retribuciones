using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class Titular_SinonimoObject : Titular_Sinonimo
    {
        public bool existTitular_Sinonimo(long tis_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tis_id FROM tab_titular_sinonimo WHERE tis_id='" + tis_id + "'";

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
        
        public List<Titular_Sinonimo> listTitular_Sinonimo(long tis_id)
        {
            string where = (tis_id != 0 ? ("AND tab_titular_sinonimo.tis_id = " + tis_id + "") : "");
            List<Titular_Sinonimo> lstTitular_Sinonimo = new List<Titular_Sinonimo>();
            try
            {
                SQL = "SELECT tab_titular_sinonimo.tis_id, tab_titular_sinonimo.tit_id, tab_titular.tit_nombre, tab_titular_sinonimo.tis_nombre,tab_titular_sinonimo.tis_estado ";
                SQL += "FROM tab_titular_sinonimo ";
                SQL += "INNER JOIN tab_titular ON tab_titular_sinonimo.tit_id = tab_titular.tit_id ";
                SQL += "WHERE  tab_titular_sinonimo.tis_estado = 1 " + where;

                SQL += " ORDER BY tab_titular_sinonimo.tis_id";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Titular_Sinonimo titular = new Titular_Sinonimo();
                    titular.Tis_id = Convert.ToInt64(rs.Fields["tis_id"].Value);
                    titular.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titular.Tis_nombre = Convert.ToString(rs.Fields["tis_nombre"].Value);
                    titular.Tis_estado = Convert.ToInt32(rs.Fields["tis_estado"].Value);
                    lstTitular_Sinonimo.Add(titular);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitular_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitular_Sinonimo;
            }
        }
        public List<Titular_Sinonimo> listTitular_SinonimoPorTitular(long tit_id)
        {
            string where = (tit_id != 0 ? ("AND tab_titular_sinonimo.tit_id=" + tit_id + "") : "");
            List<Titular_Sinonimo> lstTitular_Sinonimo = new List<Titular_Sinonimo>();
            try
            {
                SQL = "SELECT tab_titular_sinonimo.tis_id, tab_titular_sinonimo.tit_id, tab_titular.tit_nombre, tab_titular_sinonimo.tis_nombre,tab_titular_sinonimo.tis_estado ";
                SQL += "FROM tab_titular_sinonimo ";
                SQL += "INNER JOIN tab_titular ON tab_titular_sinonimo.tit_id = tab_titular.tit_id ";
                SQL += "WHERE tab_titular_sinonimo.tis_estado = 1 ";
                SQL += where;

                SQL += " ORDER BY 1";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Titular_Sinonimo titular = new Titular_Sinonimo();
                    titular.Tis_id = Convert.ToInt64(rs.Fields["tis_id"].Value);
                    titular.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titular.Tis_nombre = Convert.ToString(rs.Fields["tis_nombre"].Value);
                    titular.Tis_estado = Convert.ToInt32(rs.Fields["tis_estado"].Value);
                    lstTitular_Sinonimo.Add(titular);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitular_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitular_Sinonimo;
            }
        }


        public List<Titular_Contrato> buscarSinonimoTitular(string tit_nombre1)
        {
            string tit_nombre = prosesoCadena(tit_nombre1.Replace('\n', ' '));
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
          string Where = (tit_nombre != "" ? ("AND tab_titular.tit_nombre = '" + tit_nombre + "'") : "");
          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_contrato.ctt_id, " +
                  "tab_titular.tit_nombre " +
                  "FROM " +
                  "tab_contrato " +
                  "INNER JOIN tab_titular_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
                  "INNER JOIN tab_titular ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
                  "WHERE " +
                  "tab_titular.tit_estado = 1 " +
                    Where;

            rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
            if (!rs2.EOF)
            {
                while (!rs2.EOF)
                {
                    Titular_Contrato objTitularContrato = new Titular_Contrato();
                    objTitularContrato.Ctt_id = Convert.ToInt64(rs2.Fields["ctt_id"].Value);
                    objTitularContrato.Tit_nombre = Convert.ToString(rs2.Fields["tit_nombre"].Value);
                    lstTitularContrato.Add(objTitularContrato);
                    rs2.MoveNext();
                }
                Connection_Off(2);
              return lstTitularContrato;
            }
            else
            {
              SQL = "SELECT " +
                    "tab_contrato.ctt_id, " +
                    "tab_titular_sinonimo.tis_nombre, " +
                    "tab_titular.tit_nombre " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_titular_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
                    "INNER JOIN tab_titular ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
                    "INNER JOIN tab_titular_sinonimo ON tab_titular.tit_id = tab_titular_sinonimo.tit_id " +
                    "WHERE " +
                    "tab_titular_sinonimo.tis_estado = 1 " +
                    "AND tab_titular_sinonimo.tis_nombre = '" + tit_nombre + "'";
              rs3.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
              if (!rs3.EOF)
              {
                  while (!rs3.EOF)
                  {
                      Titular_Contrato objTitularContrato = new Titular_Contrato();
                      objTitularContrato.Ctt_id = Convert.ToInt64(rs3.Fields["ctt_id"].Value);
                      objTitularContrato.Tit_nombre = Convert.ToString(rs3.Fields["tis_nombre"].Value);
                      objTitularContrato.Tis_nombre = Convert.ToString(rs3.Fields["tis_nombre"].Value);
                      lstTitularContrato.Add(objTitularContrato);
                      rs3.MoveNext();
                  }
              }
              Connection_Off(2);
              Connection_Off(3);
              return lstTitularContrato;
            }
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(3);
            Connection_Off(2);
            return lstTitularContrato;
          }
        }


        private string prosesoCadena(string nombre)
        {
            int count = 0;
            int posi = 0;
            string returnNombre = "";
            for (int i = 0; i < nombre.Length; i++)
            {
                if (nombre[i] == ' ')
                {
                    count++;

                    if (count > 1 && posi == (i - 1))
                    {
                        posi = i;
                        returnNombre = nombre.Remove(posi, 1);
                        break;
                    }
                    posi = i;

                }
            }
            if (returnNombre != "")
            {
                return returnNombre;
            }
            else
                return nombre;
        }
        
    }
}