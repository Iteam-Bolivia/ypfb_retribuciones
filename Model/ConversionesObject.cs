using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class ConversionesObject : Conversiones
    {
        public bool existContratoCampo(long con_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT con_id FROM tab_conversiones WHERE con_id='" + con_id + "'";

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
        public List<Conversiones> listConversiones(long con_id)
        {
            String where = (con_id != 0 ? ("AND con_id = " + con_id + "") : "");
            List<Conversiones> lstConversiones = new List<Conversiones>();

            try
            {
                Connection_On();

                //SQL = "SELECT con_id, A.umd_id, umd_nombre, umdc_id, (SELECT umd_nombre FROM tab_unidad_medida WHERE umd_id = A.umdc_id AND con_id = A.con_id AND con_estado = 1) AS umdc_nombre, con_valor, con_estado ";
                //SQL += "FROM tab_conversiones A ";
                //SQL += "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id ";

                SQL = "SELECT " +
                "tab_conversiones.con_id, " +
                "tab_conversiones.umd_id, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_conversiones.umdc_id, " +
                "(SELECT umd_codigo FROM tab_unidad_medida WHERE umd_id = tab_conversiones.umdc_id AND con_id = tab_conversiones.con_id AND con_estado = 1) AS umdc_codigo, " +
                "tab_conversiones.con_valor, " +
                "tab_conversiones.con_estado, " +
                "tab_variable.var_codigo " +
                "FROM " +
                "tab_conversiones " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_conversiones.var_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_conversiones.umd_id ";
                SQL += "WHERE con_estado = 1 AND umd_estado = 1 ";
                SQL += where;
                SQL += " ORDER BY 1";

                //SQL = "SELECT con_id, A.umd_id, umd_nombre, umdc_id, con_valor, con_estado " +
                //    "FROM tab_conversiones A " +
                //    "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id " +
                //    "WHERE con_estado = 1 AND umd_estado = 1 " +
                //    where +
                //    " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Conversiones conversiones = new Conversiones();
                    conversiones.Con_id = Convert.ToInt64(rs.Fields["con_id"].Value);
                    conversiones.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    conversiones.Umd_nombre = Convert.ToString(rs.Fields["umd_codigo"].Value);
                    conversiones.Umdc_id = Convert.ToInt64(rs.Fields["umdc_id"].Value);
                    conversiones.Umdc_nombre = Convert.ToString(rs.Fields["umdc_codigo"].Value);
                    conversiones.Con_valor = Convert.ToString(rs.Fields["con_valor"].Value);
                    conversiones.Con_estado = Convert.ToInt32(rs.Fields["con_estado"].Value);
                    conversiones.Var_codigo = Convert.ToString(rs.Fields["var_codigo"].Value);
                    lstConversiones.Add(conversiones);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstConversiones;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstConversiones;
            }
        }

        public List<Conversiones> listaConversionesPorUnidadMedida(long umd_id)
        {
            string where = (umd_id != 0 ? ("AND tab_conversiones.umd_id = " + umd_id) : " ");
            List<Conversiones> lstConversiones = new List<Conversiones>();
            try
            {
                Connection_On();
                //SQL = "SELECT con_id, A.umd_id, umd_nombre, umdc_id, con_valor, con_estado " +
                //    "FROM tab_conversiones A " +
                //    "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id " +
                //    "WHERE con_estado = 1 AND umd_estado = 1 " +
                //    Where +
                //    " ORDER BY 1";

                //SQL = "SELECT con_id, A.umd_id, umd_nombre, umdc_id, (SELECT umd_nombre FROM tab_unidad_medida WHERE umd_id = A.umdc_id AND con_id = A.con_id AND con_estado = 1) AS umdc_nombre, con_valor, con_estado ";
                //SQL += "FROM tab_conversiones A ";
                //SQL += "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id ";
                //SQL += "WHERE con_estado = 1 AND umd_estado = 1 ";
                //SQL += Where;
                //SQL += "ORDER BY 1";

                SQL = "SELECT " +
                "tab_conversiones.con_id, " +
                "tab_conversiones.umd_id, " +
                "tab_unidad_medida.umd_nombre, " +
                "tab_conversiones.umdc_id, " +
                "(SELECT umd_nombre FROM tab_unidad_medida WHERE umd_id = tab_conversiones.umdc_id AND con_id = tab_conversiones.con_id AND con_estado = 1) AS umdc_nombre, " +
                "tab_conversiones.con_valor, " +
                "tab_conversiones.con_estado, " +
                "tab_variable.var_codigo " +
                "FROM " +
                "tab_conversiones " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_conversiones.var_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_conversiones.umd_id ";
                SQL += "WHERE con_estado = 1 AND umd_estado = 1 ";
                SQL += where;
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    Conversiones conversiones = new Conversiones();
                    conversiones.Con_id = Convert.ToInt64(rs.Fields["con_id"].Value);
                    conversiones.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    conversiones.Umd_nombre = Convert.ToString(rs.Fields["umd_nombre"].Value);
                    conversiones.Umdc_id = Convert.ToInt64(rs.Fields["umdc_id"].Value);
                    conversiones.Umdc_nombre = Convert.ToString(rs.Fields["umdc_nombre"].Value);
                    conversiones.Con_valor = Convert.ToString(rs.Fields["con_valor"].Value);
                    conversiones.Con_estado = Convert.ToInt32(rs.Fields["con_estado"].Value);
                    conversiones.Var_codigo = Convert.ToString(rs.Fields["var_codigo"].Value);
                    lstConversiones.Add(conversiones);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstConversiones;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstConversiones;
            }
        }
    }
}