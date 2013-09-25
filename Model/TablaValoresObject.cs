using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class TablaValoresObject: Tabla_Valores
    {
        public bool existTablaValores(long tva_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tva_id FROM tab_tabla_valores WHERE tva_id='" + tva_id + "'";

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
        public List<Tabla_Valores> listTablaValores(long tva_id)
        {
            String where = (tva_id != 0 ? ("AND tva_id=" + tva_id + "") : "");
            List<Tabla_Valores> lstTabla = new List<Tabla_Valores>();

            try
            {
                Connection_On();
                SQL = "SELECT tva_id, tab_id, tab_valcolumna, tva_valor, tva_estado " +
                          "FROM tab_tabla_valores " +
                          "WHERE tva_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Valores tablaValores = new Tabla_Valores();
                    tablaValores.Tva_id = Convert.ToInt64(rs.Fields["tva_id"].Value);
                    tablaValores.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tablaValores.Tab_valcolumna = Convert.ToString(rs.Fields["tab_valcolumna"].Value);
                    tablaValores.Tva_valor = Convert.ToString(rs.Fields["tva_valor"].Value);
                    tablaValores.Tva_estado = Convert.ToInt32(rs.Fields["tva_estado"].Value);
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
        public List<Tabla_Valores> ListaTablaValoresPorTabla(long tab_id)
        {
            String where = (tab_id != 0 ? ("AND tab_id=" + tab_id + "") : "");
            List<Tabla_Valores> lstTabla = new List<Tabla_Valores>();

            try
            {
                Connection_On();
                SQL = "SELECT tva_id, tab_id, tab_valcolumna, tva_valor, tva_estado " +
                          "FROM tab_tabla_valores " +
                          "WHERE tva_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Valores tablaValores = new Tabla_Valores();
                    tablaValores.Tva_id = Convert.ToInt64(rs.Fields["tva_id"].Value);
                    tablaValores.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tablaValores.Tab_valcolumna = Convert.ToString(rs.Fields["tab_valcolumna"].Value);
                    tablaValores.Tva_valor = Convert.ToString(rs.Fields["tva_valor"].Value);
                    tablaValores.Tva_estado = Convert.ToInt32(rs.Fields["tva_estado"].Value);
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
    }
}