using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class TablaObject : Tabla
    {
        public bool existTabla(long tab_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tab_id FROM tab_tabla WHERE tab_id='" + tab_id + "'";

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
        public List<Tabla> listTabla(long tab_id)
        {
            String where = (tab_id != 0 ? ("AND tab_id = " + tab_id + "") : "");
            List<Tabla> lstTabla = new List<Tabla>();

            try
            {
                Connection_On();
                SQL = "SELECT tab_id, tab_codigo, tab_nombre, tab_estado " +
                          "FROM tab_tabla " +
                          "WHERE tab_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla tabla = new Tabla();
                    tabla.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tabla.Tab_codigo = Convert.ToString(rs.Fields["Tab_codigo"].Value);
                    tabla.Tab_nombre = Convert.ToString(rs.Fields["Tab_nombre"].Value);
                    tabla.Tab_estado = Convert.ToInt32(rs.Fields["tab_estado"].Value);
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
        public List<Tabla> ListaTablaPorCriterio(string tab_codigo, string tab_nombre)
        {
            List<Tabla> lstTabla = new List<Tabla>();

            try
            {
                Connection_On();
                SQL = "SELECT tab_id, tab_codigo, tab_nombre, tab_estado " +
                    "FROM tab_tabla " +
                    "WHERE tab_estado = 1 ";
                SQL += " AND tab_codigo LIKE '%" + tab_codigo + "%'";
                SQL += " AND tab_nombre LIKE '%" + tab_nombre + "%'";
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla tabla = new Tabla();
                    tabla.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tabla.Tab_codigo = Convert.ToString(rs.Fields["Tab_codigo"].Value);
                    tabla.Tab_nombre = Convert.ToString(rs.Fields["Tab_nombre"].Value);
                    tabla.Tab_estado = Convert.ToInt32(rs.Fields["tab_estado"].Value);
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
        public List<Tabla> listTablaByCtt(long tab_id)
        {
            String where = (tab_id != 0 ? ("AND tab_id = " + tab_id + "") : "");
            List<Tabla> lstTabla = new List<Tabla>();

            try
            {
                Connection_On();
                SQL = "SELECT tab_id, tab_codigo, tab_nombre, tab_estado " +
                          "FROM tab_tabla " +
                          "WHERE tab_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla tabla = new Tabla();
                    tabla.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tabla.Tab_codigo = Convert.ToString(rs.Fields["Tab_codigo"].Value);
                    tabla.Tab_nombre = Convert.ToString(rs.Fields["Tab_nombre"].Value);
                    tabla.Tab_estado = Convert.ToInt32(rs.Fields["tab_estado"].Value);
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
    }
}