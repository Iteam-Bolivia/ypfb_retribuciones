using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class Tipo_CalculoObject : Tipo_Calculo
    {
        public bool existTipoCalculo(long tcl_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT tcl_id FROM tab_tipo_calculo WHERE tcl_id='" + tcl_id + "'";
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


        public List<Tipo_Calculo> listTipoCalculo(long tcl_id)
        {
            String where = (tcl_id != 0 ? ("AND tcl_id = " + tcl_id + "") : "");
            List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();

            try
            {
                Connection_On();
                SQL = "SELECT tcl_id, tcl_codigo, tcl_nombre, tcl_estado " +
                    "FROM tab_tipo_calculo " +
                    "WHERE tcl_estado = 1 " +
                    where;
                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tipo_Calculo tablaCalculo = new Tipo_Calculo();
                    tablaCalculo.Tcl_id = Convert.ToInt64(rs.Fields["tcl_id"].Value);
                    tablaCalculo.Tcl_codigo = Convert.ToString(rs.Fields["tcl_codigo"].Value);
                    tablaCalculo.Tcl_nombre = Convert.ToString(rs.Fields["tcl_nombre"].Value);
                    tablaCalculo.Tcl_estado = Convert.ToInt32(rs.Fields["tcl_estado"].Value);
                    lstTipoCalculo.Add(tablaCalculo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipoCalculo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipoCalculo;
            }
        }


        public List<Tipo_Calculo> listTipoCalculo(string tcl_codigo)
        {
            String where = (!tcl_codigo.Equals("") ? ("AND tcl_codigo = '" + tcl_codigo + "' ") : "");
            List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();

            try
            {
                Connection_On();
                SQL = "SELECT tcl_id, tcl_codigo, tcl_nombre, tcl_estado " +
                    "FROM tab_tipo_calculo " +
                    "WHERE tcl_estado = 1 " +
                    where;
                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Tipo_Calculo tablaCalculo = new Tipo_Calculo();
                    tablaCalculo.Tcl_id = Convert.ToInt64(rs.Fields["tcl_id"].Value);
                    tablaCalculo.Tcl_codigo = Convert.ToString(rs.Fields["tcl_codigo"].Value);
                    tablaCalculo.Tcl_nombre = Convert.ToString(rs.Fields["tcl_nombre"].Value);
                    tablaCalculo.Tcl_estado = Convert.ToInt32(rs.Fields["tcl_estado"].Value);
                    lstTipoCalculo.Add(tablaCalculo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTipoCalculo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTipoCalculo;
            }
        }
    }
}