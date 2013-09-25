using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class Tipo_ProyeccionObject:Tipo_Proyeccion
    {
        /// <summary>
        /// Pregunta si existe tipo_proyeccion
        /// </summary>
        /// <param name="tpy_id">El id del tipo_proyeccion</param>
        /// <returns>True si existe, Flase so no existe</returns>
        public bool existTipo_Proyeccion(long tpy_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tpy_id FROM tab_tipo_proyeccion WHERE tpy_id='" + tpy_id + "'";

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
      /* Method existTipo_Proyeccion */
        /// <summary>
        /// listTipo_Proyeccion Method
        /// </summary>
        public List<Tipo_Proyeccion> listTipo_Proyeccion(long tpy_id)
        {
            String where = (tpy_id != 0 ? ("AND tpy_id=" + tpy_id + "") : "");
            List<Tipo_Proyeccion> lstTipo_Proyeccion = new List<Tipo_Proyeccion>();

            try
            {
                Connection_On();
                SQL = "SELECT tpy_id, tpy_codigo, tpy_nombre, tpy_estado " +
                          "FROM tab_tipo_proyeccion " +
                          "WHERE tpy_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstTipo_Proyeccion.Add(new Tipo_Proyeccion(System.Convert.ToInt64(rs.Fields["tpy_id"].Value),
                        (string)rs.Fields["tpy_codigo"].Value,
                        (string)rs.Fields["tpy_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["tpy_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
        }/* Method listTipo_Proyeccion */

        public List<Tipo_Proyeccion> listTipo_ProyeccionSegunCriterio(string tpy_codigo, string tpy_nombre)
        {
            List<Tipo_Proyeccion> lstTipo_Proyeccion = new List<Tipo_Proyeccion>();
            try
            {
                Connection_On();
                SQL = "SELECT tpy_id, tpy_codigo, tpy_nombre, tpy_estado ";
                SQL += "FROM tab_tipo_proyeccion ";
                SQL += "WHERE tpy_codigo LIKE '%" + tpy_codigo + "%' ";
                SQL += "AND tpy_nombre LIKE '%" + tpy_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Tipo_Proyeccion tipo_proyeccion = new Tipo_Proyeccion();
                    tipo_proyeccion.Tpy_id = Convert.ToInt64(rs.Fields["tpy_id"].Value);
                    tipo_proyeccion.Tpy_codigo = Convert.ToString(rs.Fields["tpy_codigo"].Value);
                    tipo_proyeccion.Tpy_nombre = Convert.ToString(rs.Fields["tpy_nombre"].Value);
                    tipo_proyeccion.Tpy_estado = Convert.ToInt32(rs.Fields["tpy_estado"].Value);
                    lstTipo_Proyeccion.Add(tipo_proyeccion);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
        }

        public List<Tipo_Proyeccion> listTipo_ProyeccionesPorContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id=" + ctt_id + "") : "");
            List<Tipo_Proyeccion> lstTipo_Proyeccion = new List<Tipo_Proyeccion>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_tipo_proyeccion.tpy_id,tab_tipo_proyeccion.tpy_codigo,tab_tipo_proyeccion.tpy_nombre,tab_tipo_proyeccion.tpy_estado " +
                          "FROM tab_tipo_proyeccion " +
                          "Inner Join tab_tipo_proyeccion_contrato ON tab_tipo_proyeccion.tpy_id = tab_tipo_proyeccion_contrato.tpy_id " +
                          "WHERE tpy_estado = 1 " +
                          "AND ttc_estado = 1 " +
                          where +
                          " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tipo_Proyeccion tipo_proyeccion = new Tipo_Proyeccion();
                    tipo_proyeccion.Tpy_id = Convert.ToInt64(rs.Fields["tpy_id"].Value);
                    tipo_proyeccion.Tpy_codigo = Convert.ToString(rs.Fields["tpy_codigo"].Value);
                    tipo_proyeccion.Tpy_nombre = Convert.ToString(rs.Fields["tpy_nombre"].Value);
                    tipo_proyeccion.Tpy_estado = Convert.ToInt32(rs.Fields["tpy_estado"].Value);
                    lstTipo_Proyeccion.Add(tipo_proyeccion);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipo_Proyeccion;
            }
        }



        public string GetOperadorContra(long ctt_id)
        {
          string oper = "";
          try
          {

            cnn = Connection_On();
            SQL = "SELECT ti.tpy_nombre " +
                      "FROM tab_contrato co " +
                      "INNER JOIN tab_tipo_proyeccion_contrato tc ON co.ctt_id = tc.ctt_id " +
                      "INNER JOIN tab_tipo_proyeccion ti ON tc.tpy_id = ti.tpy_id " +
                      "WHERE tc.ttc_tipo = 'O' AND co.ctt_id='" + ctt_id + "'";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            if (!rs.EOF)
            {
              oper = Convert.ToString(rs.Fields["tpy_nombre"].Value);
            }
            return oper;

          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            return oper;
          }
          finally
          {
            Connection_Off(1);
          }

        }




        /// <summary>
        /// listTipo_Proyeccion Method for combobox
        /// </summary>
        public List<Tipo_Proyeccion> listTipo_ProyeccionCbo(long _ctt_id)
        {
          String where = (_ctt_id != 0 ? ("AND ti.ctt_id=" + _ctt_id + "") : "");

          List<Tipo_Proyeccion> lstTipo_Proyeccion = new List<Tipo_Proyeccion>();

          try
          {
            Connection_On();
            SQL = "SELECT DISTINCT ti.tpy_id,ti.tpy_nombre " +
                   "FROM tab_tipo_proyeccion ti INNER JOIN " +
                      "tab_tipo_proyeccion_contrato tc ON  ti.tpy_id = tc.tpy_id INNER JOIN " +
                      "tab_contrato ct ON tc.ctt_id = ct.ctt_id " +
                   "WHERE tc.ttc_tipo = 'O' AND ti.tpy_estado = 1 " +
                       where;

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Tipo_Proyeccion tpyu = new Tipo_Proyeccion();
              tpyu.Tpy_id = Convert.ToInt64(rs.Fields["tpy_id"].Value);
              tpyu.Tpy_nombre = Convert.ToString(rs.Fields["tpy_nombre"].Value);

              // Fill data List
              lstTipo_Proyeccion.Add(tpyu);
              rs.MoveNext();
            }

            return lstTipo_Proyeccion;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            return lstTipo_Proyeccion;
          }
          finally
          {
            Connection_Off(1);
          }
        }/* Method listMenu */


        public Tipo_Proyeccion Tipo_ProyeccionPorCodigo(long tpy_id)
        {
            String where = (tpy_id != 0 ? ("AND tpy_id = " + tpy_id + "") : "");
            Tipo_Proyeccion tipo_proyeccion = null;
            try
            {
                Connection_On();
                SQL = "SELECT tpy_id, tpy_codigo, tpy_nombre, tpy_estado " +
                    "FROM tab_tipo_proyeccion " +
                    "WHERE tpy_estado = 1 " +
                    where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    tipo_proyeccion = new Tipo_Proyeccion();
                    tipo_proyeccion.Tpy_id = Convert.ToInt64(rs.Fields["tpy_id"].Value);
                    tipo_proyeccion.Tpy_codigo = (string)rs.Fields["tpy_codigo"].Value;
                    tipo_proyeccion.Tpy_nombre = Convert.ToString(rs.Fields["tpy_nombre"].Value);
                    tipo_proyeccion.Tpy_estado = Convert.ToInt32(rs.Fields["tpy_estado"].Value);
                }
                Connection_Off(1);
                return tipo_proyeccion;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return tipo_proyeccion;
            }
        }

    }
}