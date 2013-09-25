using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class TitularObject:Titular
    {
        /// <summary>
        /// Pregunta si existe titular
        /// </summary>
        /// <param name="tit_id">El id del titular</param>
        /// <returns>True si existe, Flase so no existe</returns>
        public bool existTitular(long tit_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tit_id FROM tab_titular WHERE tit_id='" + tit_id + "'";

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
      /* Method existTitular */
        /// <summary>
        /// listTitular Method
        /// </summary>
        public List<Titular> listTitular(long tit_id)
        {
            String where = (tit_id != 0 ? ("AND tit_id=" + tit_id + "") : "");
            List<Titular> lstTitular = new List<Titular>();

            try
            {
                Connection_On();
                SQL = "SELECT tit_id, tit_codigo, tit_nombre, tit_estado, tit_orden " +
                          "FROM tab_titular " +
                          "WHERE tit_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs2.EOF)
                {
                    // Fill data List
                    lstTitular.Add(new Titular(System.Convert.ToInt64(rs2.Fields["tit_id"].Value),
                        (string)rs2.Fields["tit_codigo"].Value,
                        (string)rs2.Fields["tit_nombre"].Value,
                        System.Convert.ToInt32(rs2.Fields["tit_estado"].Value),
                        System.Convert.ToInt32(rs2.Fields["tit_estado"].Value)));
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstTitular;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstTitular;
            }
        }/* Method listTitular */

        public List<Titular> listTitularSegunCriterio(string tit_codigo, string tit_nombre)
        {
            List<Titular> lstTitular = new List<Titular>();
            try
            {
                Connection_On();
                SQL = "SELECT tit_id, tit_codigo, tit_nombre, tit_estado, tit_orden ";
                SQL += "FROM tab_titular ";
                SQL += "WHERE tit_codigo LIKE '%" + tit_codigo + "%' ";
                SQL += "AND tit_nombre LIKE '%" + tit_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Titular titular = new Titular();
                    titular.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit_codigo = Convert.ToString(rs.Fields["tit_codigo"].Value);
                    titular.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titular.Tit_estado = Convert.ToInt32(rs.Fields["tit_estado"].Value);
                    titular.Tit_orden = Convert.ToInt32(rs.Fields["tit_orden"].Value);
                    lstTitular.Add(titular);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitular;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitular;
            }
        }

        public List<Titular> listTitularesPorContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id=" + ctt_id + "") : "");
            List<Titular> lstTitular = new List<Titular>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_titular.tit_id,tab_titular.tit_codigo,tab_titular.tit_nombre,tab_titular.tit_estado, tit_orden " +
                          "FROM tab_titular " +
                          "Inner Join tab_titular_contrato ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
                          "WHERE tit_estado = 1 " +
                          "AND ttc_estado = 1 " +
                          where +
                          " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Titular titular = new Titular();
                    titular.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit_codigo = Convert.ToString(rs.Fields["tit_codigo"].Value);
                    titular.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titular.Tit_estado = Convert.ToInt32(rs.Fields["tit_estado"].Value);
                    titular.Tit_orden = Convert.ToInt32(rs.Fields["tit_orden"].Value);
                    lstTitular.Add(titular);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitular;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitular;
            }
        }



        public string GetOperadorContra(long ctt_id)
        {
          string oper = "";
          try
          {

            Connection_On();
            SQL = "SELECT ti.tit_nombre " +
                      "FROM tab_contrato co " +
                      "INNER JOIN tab_titular_contrato tc ON co.ctt_id = tc.ctt_id " +
                      "INNER JOIN tab_titular ti ON tc.tit_id = ti.tit_id " +
                      "WHERE tc.ttc_tipo = 'O' AND co.ctt_id='" + ctt_id + "'";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            if (!rs.EOF)
            {
              oper = Convert.ToString(rs.Fields["tit_nombre"].Value);
            }
            Connection_Off(1);
            return oper;

          }
          catch (COMException err)
          {
              Connection_Off(1);
            Console.WriteLine("Error: " + err.Message);
            return oper;
          }
          finally
          {
            Connection_Off(1);
          }

        }




        /// <summary>
        /// listTitular Method for combobox
        /// </summary>
        public List<Titular> listTitularCbo(long _ctt_id)
        {
          String where = (_ctt_id != 0 ? ("AND ti.ctt_id=" + _ctt_id + "") : "");

          List<Titular> lstTitular = new List<Titular>();

          try
          {
            Connection_On();
            SQL = "SELECT DISTINCT ti.tit_id,ti.tit_nombre " +
                   "FROM tab_titular ti INNER JOIN " +
                      "tab_titular_contrato tc ON  ti.tit_id = tc.tit_id INNER JOIN " +
                      "tab_contrato ct ON tc.ctt_id = ct.ctt_id " +
                   "WHERE tc.ttc_tipo = 'O' AND ti.tit_estado = 1 " +
                       where + "order by ti.tit_nombre ";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Titular titu = new Titular();
              titu.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
              titu.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);

              // Fill data List
              lstTitular.Add(titu);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstTitular;
          }
          catch (COMException err)
          {
              Connection_Off(1);
            Console.WriteLine("Error: " + err.Message);
            return lstTitular;
          }
          finally
          {
            Connection_Off(1);
          }
        }/* Method listMenu */


        public Titular TitularPorCodigo(long tit_id)
        {
            String where = (tit_id != 0 ? ("AND tit_id = " + tit_id + "") : "");
            Titular titular = null;
            try
            {
                Connection_On();
                SQL = "SELECT tit_id, tit_codigo, tit_nombre, tit_estado, tit_orden " +
                    "FROM tab_titular " +
                    "WHERE tit_estado = 1 " +
                    where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    titular = new Titular();
                    titular.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit_codigo = (string)rs.Fields["tit_codigo"].Value;
                    titular.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titular.Tit_estado = Convert.ToInt32(rs.Fields["tit_estado"].Value);
                    titular.Tit_orden = Convert.ToInt32(rs.Fields["tit_orden"].Value);
                }
                Connection_Off(1);
                return titular;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return titular;
            }
        }

    }
}