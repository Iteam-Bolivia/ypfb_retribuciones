using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class TablaCalculoObject: Tabla_Calculo
    {
        public bool existTablaCalculo(long tca_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tca_id FROM tab_tabla_calculo WHERE tca_id='" + tca_id + "'";

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
        public List<Tabla_Calculo> listTablaCalculo(long tca_id)
        {
            String where = (tca_id != 0 ? ("AND tca_id = " + tca_id + "") : "");
            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();

            try
            {
                Connection_On();
                SQL = "SELECT tca_id, " +
                      "ctt_id,  " +
                      "A.tab_id,  " +
                      "tab_nombre, " +
                      "tca_estado, " +
                      "tca_fecha, " +
                      "tca_precio, " +
                      "tca_oplogi, " +
                      "s.sim_simbolo " +
                      "FROM tab_tabla_calculo A " +
                      "INNER JOIN tab_tabla B ON A.tab_id = B.tab_id " +
                      "INNER JOIN tab_simbolo as s ON s.sim_id = a.tca_oplogi " +
                      "WHERE tca_estado = 1 " +
                      "AND tab_estado = 1 " +
                      where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                    tablaCalculo.Tca_id = Convert.ToInt64(rs.Fields["tca_id"].Value);
                    tablaCalculo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    tablaCalculo.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tablaCalculo.Tab_nombre = Convert.ToString(rs.Fields["tab_nombre"].Value);
                    tablaCalculo.Tca_estado = Convert.ToInt32(rs.Fields["tca_estado"].Value);
                    tablaCalculo.Tca_fecha = Convert.ToDateTime(rs.Fields["tca_fecha"].Value);
                    tablaCalculo.Tca_precio = Convert.ToDecimal(rs.Fields["tca_precio"].Value);
                    tablaCalculo.Tca_oplogi = Convert.ToInt32(rs.Fields["tca_oplogi"].Value);
                    tablaCalculo.sim_simbolo = Convert.ToString(rs.Fields["sim_simbolo"].Value);
                    lstTablaCalculo.Add(tablaCalculo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTablaCalculo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTablaCalculo;
            }
        }
        public List<Tabla_Calculo> listTablaCalculoPorContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND A.ctt_id = " + ctt_id + "") : "");
            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();

            try
            {
                Connection_On();
                SQL = "SELECT tca_id, " +
                      "C.tab_id, " + 
                      "ctt_nombre, " +
                      "tab_nombre, " +
                      "tca_estado, " +
                      "tca_fecha, " +
                      "tca_precio, " +
                      "tca_oplogi, " +
                      "s.sim_simbolo " +
                      "FROM tab_tabla_calculo A " +
                      "INNER JOIN tab_contrato B ON A.ctt_id = B.ctt_id " +
                      "INNER JOIN tab_tabla C ON A.tab_id = C.tab_id " +
                      "INNER JOIN tab_simbolo as s ON s.sim_id = a.tca_oplogi " +
                      "WHERE tca_estado = 1 AND  ctt_estado = 1 AND tab_estado = 1 " +
                      where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                    tablaCalculo.Tca_id = Convert.ToInt64(rs.Fields["tca_id"].Value);
                    tablaCalculo.Tab_id = Convert.ToInt64(rs.Fields["tab_id"].Value);
                    tablaCalculo.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    tablaCalculo.Tab_nombre = Convert.ToString(rs.Fields["tab_nombre"].Value);
                    tablaCalculo.Tca_estado = Convert.ToInt32(rs.Fields["tca_estado"].Value);
                    tablaCalculo.Tca_fecha = Convert.ToDateTime(rs.Fields["tca_fecha"].Value);
                    tablaCalculo.Tca_precio = Convert.ToDecimal(rs.Fields["tca_precio"].Value);
                    tablaCalculo.Tca_oplogi = Convert.ToInt32(rs.Fields["tca_oplogi"].Value);
                    tablaCalculo.sim_simbolo = Convert.ToString(rs.Fields["sim_simbolo"].Value);
                    lstTablaCalculo.Add(tablaCalculo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTablaCalculo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTablaCalculo;
            }
        }

        


        public List<Tabla_Calculo> listaTablaCalculoNombrePorContrato(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id) : "");
            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_nombre " +
                      "FROM tab_tabla_calculo A " +
                      "INNER JOIN tab_tabla B ON A.tab_id = B.tab_id " +
                      "WHERE tca_estado = 1 " +
                      "AND tab_estado = 1 " +
                      Where +
                      " ORDER BY 1";

                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs2.EOF)
                {
                    Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                    tablaCalculo.Tab_nombre = Convert.ToString(rs2.Fields["tab_nombre"].Value);
                    lstTablaCalculo.Add(tablaCalculo);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstTablaCalculo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstTablaCalculo;
            }
        }
    }
}