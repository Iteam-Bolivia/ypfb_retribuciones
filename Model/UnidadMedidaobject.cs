using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class UnidadMedidaObject : Unidad_Medida
    {
        public bool existUnidadMedida(long umd_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT umd_id FROM tab_unidad_medida WHERE umd_id='" + umd_id + "'";

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
        /// listUnidadMedida Method
        /// </summary>
        public List<Unidad_Medida> listUnidadMedida(long umd_id)
        {
            String where = (umd_id != 0 ? ("AND umd_id=" + umd_id + "") : "");
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();

            try
            {
                Connection_On();
                SQL = "SELECT umd_id, umd_codigo, umd_nombre, umd_estado " +
                    "FROM tab_unidad_medida " +
                    "WHERE umd_estado = 1 " +
                    where +
                    " ORDER BY umd_codigo ASC";

                // Execute the query specifying static sursor, batch optimistic locking
                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs2.EOF)
                {
                    Unidad_Medida unidadMedida = new Unidad_Medida();
                    unidadMedida.Umd_id = Convert.ToInt64(rs2.Fields["umd_id"].Value);
                    unidadMedida.Umd_codigo = Convert.ToString(rs2.Fields["umd_codigo"].Value);
                    unidadMedida.Umd_nombre = Convert.ToString(rs2.Fields["umd_nombre"].Value);
                    unidadMedida.Umd_estado = Convert.ToInt32(rs2.Fields["umd_estado"].Value);
                    lstUnidadMedida.Add(unidadMedida);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstUnidadMedida;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstUnidadMedida;
            }
        }/* Method listMenu */


        /// <summary>
        /// findUnidadMedida Method
        /// </summary>
        public List<Unidad_Medida> findUnidadMedida(long umd_id)
        {
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            try
            {
                Connection_On();
                SQL = "SELECT umd_id, umd_codigo, umd_nombre, umd_estado " +
                          "FROM tab_unidad_medida " +
                          "WHERE umd_id='" + umd_id + "' AND umd_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstUnidadMedida.Add(new Unidad_Medida(
                        System.Convert.ToInt64(rs.Fields["umd_id"].Value),
                        (string)(rs.Fields["umd_codigo"].Value),
                        (string)rs.Fields["umd_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["umd_estado"].Value)));
                    Connection_Off(1);
                    return lstUnidadMedida;
                }
                else
                {
                    Connection_Off(1);
                    return lstUnidadMedida;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUnidadMedida;
            }
        }
        public List<Unidad_Medida> listaUnidadMedidaPorProducto(long pro_id)
        {
            string Where = (pro_id != 0 ? ("AND A.pro_id = " + pro_id) : "");
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            try
            {
                Connection_On();
                SQL = "SELECT umd_id, A.pro_id, pro_nombre, umd_codigo, umd_nombre, umd_estado " +
                    "FROM tab_producto A " +
                    "INNER JOIN tab_unidad_medida B ON A.pro_id = B.pro_id " +
                    "WHERE pro_estado = 1 AND umd_estado = 1 " +
                    Where +
                    " ORDER BY umd_codigo";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    Unidad_Medida unidadMedida = new Unidad_Medida();
                    unidadMedida.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    //unidadMedida.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    //unidadMedida.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    unidadMedida.Umd_codigo = Convert.ToString(rs.Fields["umd_codigo"].Value);
                    unidadMedida.Umd_nombre = Convert.ToString(rs.Fields["umd_nombre"].Value);
                    unidadMedida.Umd_estado = Convert.ToInt32(rs.Fields["umd_estado"].Value);

                    //List<Conversiones> conversiones = new List<Conversiones>();
                    //ConversionesObject objConversiones = new ConversionesObject();
                    //conversiones = objConversiones.listaConversionesPorUnidadMedida(unidadMedida.Umd_id);

                    //foreach (Conversiones item in conversiones)
                    //{
                    //    unidadMedida.Lista_Conversiones += item.Umd_nombre + ", ";
                    //}
                    //if (!string.IsNullOrWhiteSpace(producto.Lista_Unidad_Medida))
                    //    producto.Lista_Unidad_Medida = producto.Lista_Unidad_Medida.Substring(0, producto.Lista_Unidad_Medida.Length - 2);

                    lstUnidadMedida.Add(unidadMedida);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstUnidadMedida;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUnidadMedida;
            }
        }
        public List<Unidad_Medida> ListaUnidadMedidaNombrePorProducto(long umd_id)
        {
            string Where = (umd_id != 0 ? ("AND umd_id = " + umd_id) : "");
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            try
            {
                Connection_On();
                SQL = "SELECT umd_id, umd_nombre ";
                SQL += "FROM tab_unidad_medida ";
                SQL += "WHERE umd_estado = 1 ";
                SQL += Where;
                SQL += " ORDER BY 1";
                rs3.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs3.EOF)
                {
                    Unidad_Medida unidadMedida = new Unidad_Medida();
                    unidadMedida.Umd_id = Convert.ToInt64(rs3.Fields["umd_id"].Value);
                    unidadMedida.Umd_nombre = Convert.ToString(rs3.Fields["umd_nombre"].Value);
                    lstUnidadMedida.Add(unidadMedida);
                    rs3.MoveNext();
                }
                Connection_Off(3);
                return lstUnidadMedida;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(3);
                return lstUnidadMedida;
            }
        }
    }
}