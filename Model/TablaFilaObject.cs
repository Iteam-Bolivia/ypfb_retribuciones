using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class TablaFilaObject : Tabla_Fila
    {
        public bool existTablaFila(long taf_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT taf_id FROM tab_tabla_fila WHERE taf_id='" + taf_id + "'";

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
        /// listTabla Method
        /// </summary>
        public List<Tabla_Fila> listTablaFila(long taf_id)
        {
            String where = (taf_id != 0 ? ("AND taf_id = " + taf_id + "") : "");
            List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();

            try
            {
                Connection_On();
                SQL = "SELECT taf_id, tab_id, taf_valfila, taf_valor, taf_estado " +
                          "FROM tab_tabla_fila " +
                          "WHERE taf_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Fila tabla = new Tabla_Fila();
                    tabla.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tabla.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tabla.Taf_valfila = Convert.ToDecimal(rs.Fields["taf_valfila"].Value);
                    tabla.Taf_valor = Convert.ToDecimal(rs.Fields["taf_valor"].Value);
                    tabla.Taf_estado = Convert.ToInt32(rs.Fields["taf_estado"].Value);
                    lstTabla.Add(tabla);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTabla;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTabla;
            }
        }
        public List<Tabla_Fila> listTablaFilaPorTabla(long tab_id)
        {
            String where = (tab_id != 0 ? ("AND tab_id = " + tab_id + "") : "");
            List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();

            try
            {
                Connection_On();
                SQL = "SELECT taf_id, tab_id, taf_valfila, taf_valor, taf_estado " +
                          "FROM tab_tabla_fila " +
                          "WHERE taf_estado = 1 " +
                          where;
                SQL += "ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Fila tabla = new Tabla_Fila();
                    tabla.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tabla.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tabla.Taf_valfila = Convert.ToDecimal(rs.Fields["taf_valfila"].Value);
                    tabla.Taf_valor = Convert.ToDecimal(rs.Fields["taf_valor"].Value);
                    tabla.Taf_estado = Convert.ToInt32(rs.Fields["taf_estado"].Value);
                    lstTabla.Add(tabla);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTabla;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTabla;
            }
        }


        // modificacion de freddy
        public List<Tabla_Fila> listTablaFilaPorContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND a.ctt_id =" + ctt_id) : "");
            List<Tabla_Fila> lstTablaFila = new List<Tabla_Fila>();
            try
            {
                Connection_On();
                SQL = "SELECT c.taf_id,c.taf_valfila,c.taf_valor " +
                "FROM tab_tabla_calculo AS a " +
                "Inner Join tab_tabla AS b ON a.tab_id = b.tab_id " +
                "Inner Join tab_tabla_fila AS c ON b.tab_id = c.tab_id " +
                "WHERE a.ctt_id =  '" + ctt_id + "' AND a.tca_estado =  '1' AND c.taf_estado =  '1' " +
                "ORDER BY a.tca_id, c.taf_id ASC";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    Tabla_Fila tablaFila = new Tabla_Fila();
                    tablaFila.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tablaFila.Taf_valfila = Convert.ToDecimal(rs.Fields["taf_valfila"].Value);
                    tablaFila.Taf_valor = Convert.ToDecimal(rs.Fields["taf_valor"].Value);
                    lstTablaFila.Add(tablaFila);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTablaFila;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTablaFila;
            }
        }



        public List<Tabla_Fila> listTablaFilaValores(long ctt_id, long tab_id)
        {
          String where = (ctt_id != 0 ? (" AND tab_contrato.ctt_id = " + ctt_id + " ") : " ");
          where += (tab_id != 0 ? (" AND tab_tabla.tab_id = " + tab_id + " ") : " ");
          List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();

          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_tabla_calculo.tca_id, " +
                  "tab_tabla.tab_id, " +              
                  "tab_tabla_fila.taf_id, " +
                  "tab_tabla_fila.taf_valfila, " +
                  "tab_tabla_fila.taf_estado " +
                  "FROM " +
                  "tab_contrato " +
                  "INNER JOIN tab_tabla_calculo ON tab_contrato.ctt_id = tab_tabla_calculo.ctt_id " +
                  "INNER JOIN tab_tabla ON tab_tabla.tab_id = tab_tabla_calculo.tab_id " +
                  "INNER JOIN tab_tabla_fila ON tab_tabla.tab_id = tab_tabla_fila.tab_id " +
                  "WHERE tab_tabla.tab_estado = 1 AND tab_tabla_fila.taf_estado = 1 AND tab_tabla_calculo.tca_estado = 1 " +
                  where +
                  " ORDER BY tab_tabla.tab_id, tab_tabla_fila.taf_id, tab_tabla_fila.taf_valfila ";
            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Tabla_Fila tablaFila = new Tabla_Fila();
              tablaFila.Tca_id = Convert.ToInt64(rs.Fields["tca_id"].Value);
              tablaFila.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
              tablaFila.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
              tablaFila.Taf_valfila = Convert.ToDecimal(rs.Fields["taf_valfila"].Value);
              tablaFila.Taf_estado = Convert.ToInt32(rs.Fields["taf_estado"].Value);
              lstTabla.Add(tablaFila);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstTabla;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstTabla;
          }
        }
    }
}