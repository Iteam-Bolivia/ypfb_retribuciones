using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class TablaColumnaObject : Tabla_Columna
    {
        public bool existTablaColumna(long tac_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tac_id FROM tab_tabla_columna WHERE tac_id='" + tac_id + "'";

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
        public List<Tabla_Columna> listTablaColumna(long tac_id)
        {
            String where = (tac_id != 0 ? ("AND tac_id = " + tac_id + "") : "");
            List<Tabla_Columna> lstTabla = new List<Tabla_Columna>();

            try
            {
                Connection_On();
                SQL = "SELECT tac_id, taf_id, tac_valcolumna, tac_valor, tac_estado " +
                          "FROM tab_tabla_columna " +
                          "WHERE tac_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Columna tablaValores = new Tabla_Columna();
                    tablaValores.Tac_id = Convert.ToInt64(rs.Fields["tac_id"].Value);
                    tablaValores.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tablaValores.Tac_valcolumna = Convert.ToDecimal(rs.Fields["tac_valcolumna"].Value);
                    tablaValores.Tac_valor = Convert.ToDecimal(rs.Fields["tac_valor"].Value);
                    tablaValores.Tac_estado = Convert.ToInt32(rs.Fields["tac_estado"].Value);
                    lstTabla.Add(tablaValores);
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
        public List<Tabla_Columna> ListaTablaColumnaPorTablaFila(long taf_id)
        {
            String where = (taf_id != 0 ? ("AND taf_id = " + taf_id + "") : "");
            List<Tabla_Columna> lstTabla = new List<Tabla_Columna>();

            try
            {
                Connection_On();
                SQL = "SELECT tac_id, taf_id, tac_valcolumna, tac_valor, tac_estado " +
                          "FROM tab_tabla_columna " +
                          "WHERE tac_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Columna tablaValores = new Tabla_Columna();
                    tablaValores.Tac_id = Convert.ToInt64(rs.Fields["tac_id"].Value);
                    tablaValores.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tablaValores.Tac_valcolumna = Convert.ToDecimal(rs.Fields["tac_valcolumna"].Value);
                    tablaValores.Tac_valor = Convert.ToDecimal(rs.Fields["tac_valor"].Value);
                    tablaValores.Tac_estado = Convert.ToInt32(rs.Fields["tac_estado"].Value);
                    lstTabla.Add(tablaValores);
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
        public int CantidadColumnasPorFila(long taf_id)
        {
            string where = (taf_id != 0 ? ("AND taf_id = " + taf_id + "") : "");
            int cantidad = 0;
            try
            {
                Connection_On();
                SQL = "SELECT COUNT(tac_id) AS tac_id " +
                          "FROM tab_tabla_columna " +
                          "WHERE tac_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    cantidad = Convert.ToInt32(rs.Fields["tac_id"].Value);
                }
                Connection_Off(1);
                return cantidad;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return cantidad;
            }
        }
        public Tabla_Columna datosTablaColumnaPorFila(long taf_id)
        {
            String where = (taf_id != 0 ? ("AND taf_id = " + taf_id + "") : "");
            Tabla_Columna tabla = null;
            try
            {
                Connection_On();
                SQL = "SELECT tac_id, taf_id, tac_valcolumna, tac_valor, tac_estado " +
                          "FROM tab_tabla_columna " +
                          "WHERE tac_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    tabla = new Tabla_Columna();
                    tabla.Tac_id = Convert.ToInt64(rs.Fields["tac_id"].Value);
                    tabla.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tabla.Tac_valcolumna = Convert.ToDecimal(rs.Fields["tac_valcolumna"].Value);
                    tabla.Tac_valor = Convert.ToDecimal(rs.Fields["tac_valor"].Value);
                    tabla.Tac_estado = Convert.ToInt32(rs.Fields["tac_estado"].Value);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return tabla;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return tabla;
            }
        }


        public List<Tabla_Columna> listTablaColumnaValores(long taf_id)
        {
            String where = (taf_id != 0 ? ("AND tab_tabla_columna.taf_id = " + taf_id + "") : "");
            List<Tabla_Columna> lstTabla = new List<Tabla_Columna>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_tabla_fila.taf_id, " +
                      "tab_tabla_columna.tac_id, " +
                      "tab_tabla_columna.tac_valcolumna, " +
                      "tab_tabla_columna.tac_valor, " +
                      "tab_tabla_columna.tac_estado " +
                      "FROM " +
                      "tab_tabla_fila " +
                      "INNER JOIN tab_tabla_columna ON tab_tabla_fila.taf_id = tab_tabla_columna.taf_id " +
                      "WHERE tab_tabla_columna.tac_estado = 1 AND tab_tabla_fila.taf_estado = 1 " +
                      where +
                      " ORDER BY tab_tabla_fila.taf_id, tab_tabla_columna.tac_id, tab_tabla_columna.tac_valcolumna ";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Columna tablaColumna = new Tabla_Columna();
                    tablaColumna.Taf_id = Convert.ToInt64(rs.Fields["taf_id"].Value);
                    tablaColumna.Tac_id = Convert.ToInt64(rs.Fields["tac_id"].Value);
                    tablaColumna.Tac_valcolumna = Convert.ToDecimal(rs.Fields["tac_valcolumna"].Value);
                    tablaColumna.Tac_valor = Convert.ToDecimal(rs.Fields["tac_valor"].Value);
                    tablaColumna.Tac_estado = Convert.ToInt32(rs.Fields["tac_estado"].Value);
                    lstTabla.Add(tablaColumna);
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