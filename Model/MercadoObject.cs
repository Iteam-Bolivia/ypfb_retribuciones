using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class MercadoObject:Mercado
    {
        /// <summary>
        /// Verifica si existe un mercado por su id
        /// </summary>
        /// <param name="mer_id">Mercado id</param>
        /// <returns>True si existe el mercado, flase si no existe el mercado.</returns>
        public bool existMercado(long mer_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT mer_id FROM tab_mercado WHERE mer_id='" + mer_id + "'";

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
        }/* Method existMercado */



        /// <summary>
        /// listMercado Method
        /// </summary>
        public List<Mercado> listMercado(long mer_id)
        {
            String where = (mer_id != 0 ? ("AND mer_id=" + mer_id + "") : "");
            List<Mercado> lstMercado = new List<Mercado>();

            try
            {
                Connection_On();
                SQL = "SELECT mer_id, mer_codigo, mer_nombre, mer_estado, mer_tipo, mer_orden, mer_ordenletra, mer_var, pro_mer " +
                          "FROM tab_mercado " +
                          "WHERE mer_estado = 1  " +
                          where;
                SQL += "ORDER BY mer_nombre";
                // Execute the query specifying static sursor, batch optimistic locking
                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs2.EOF)
                {
                    // Fill data List
                    Mercado objMercado = new Mercado();
                    objMercado.Mer_id = System.Convert.ToInt64(rs2.Fields["mer_id"].Value);
                    objMercado.Mer_codigo = (string)(rs2.Fields["mer_codigo"].Value);
                    objMercado.Mer_nombre = (string)rs2.Fields["mer_nombre"].Value;
                    objMercado.Mer_estado = System.Convert.ToInt64(rs2.Fields["mer_estado"].Value);
                    objMercado.Mer_tipo = (string)rs2.Fields["mer_tipo"].Value;
                    objMercado.Mer_orden = System.Convert.ToInt64(rs2.Fields["mer_orden"].Value);
                    objMercado.Mer_ordenletra = (string)rs2.Fields["mer_ordenletra"].Value;
                    objMercado.Mer_var = System.Convert.ToInt32(rs2.Fields["mer_var"].Value);
                    objMercado.Pro_mer = System.Convert.ToInt32(rs2.Fields["pro_mer"].Value);

                    lstMercado.Add(objMercado);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstMercado;
            }
            catch (COMException err)
            {
                Connection_Off(2);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstMercado;
            }
        }/* Method listMercado */


        /// <summary>
        /// listMercado Method
        /// </summary>
        public List<Mercado> listMercadoPorCondicion(String condicion)
        {
          List<Mercado> lstMercado = new List<Mercado>();

          try
          {
            Connection_On();
            SQL = "SELECT mer_id, mer_codigo, mer_nombre, mer_estado, pro_mer " +
                  "FROM tab_mercado " +
                  "WHERE mer_estado = 1 AND mer_var = 1 " +
                  condicion;
            SQL += "ORDER BY mer_id ";
            // Execute the query specifying static sursor, batch optimistic locking
            rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs2.EOF)
            {
              // Fill data List
              Mercado objMercado = new Mercado();
              objMercado.Mer_id = System.Convert.ToInt64(rs2.Fields["mer_id"].Value);
              objMercado.Mer_codigo = (string)(rs2.Fields["mer_codigo"].Value);
              objMercado.Mer_nombre = (string)rs2.Fields["mer_nombre"].Value;
              objMercado.Mer_estado = System.Convert.ToInt64(rs2.Fields["mer_estado"].Value);
              objMercado.Pro_mer = System.Convert.ToInt32(rs2.Fields["pro_mer"].Value);

              lstMercado.Add(objMercado);
              rs2.MoveNext();
            }
            Connection_Off(2);
            return lstMercado;
          }
          catch (COMException err)
          {
            Connection_Off(2);
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(2);
            return lstMercado;
          }
        }/* Method listMercado */
        public List<Mercado> listMercadoSegunCriterio(string mer_codigo, string mer_nombre)
        {
            List<Mercado> lstMercado = new List<Mercado>();
            try
            {
                Connection_On();
                SQL = "SELECT mer_id, mer_codigo, mer_nombre, mer_estado, pro_mer ";
                SQL += "FROM tab_mercado ";
                SQL += "WHERE mer_codigo LIKE '%" + mer_codigo + "%' ";
                SQL += "AND mer_nombre LIKE '%" + mer_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Mercado mercado = new Mercado();
                    mercado.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    mercado.Mer_codigo = Convert.ToString(rs.Fields["mer_codigo"].Value);
                    mercado.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    mercado.Mer_estado = Convert.ToInt32(rs.Fields["mer_estado"].Value);
                    mercado.Pro_mer = Convert.ToInt32(rs.Fields["pro_mer"].Value);

                    lstMercado.Add(mercado);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMercado;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMercado;
            }
        }
        public List<Mercado> listMercadosPorProducto(long pro_id)
        {
            String where = (pro_id != 0 ? ("AND tab_campo_producto_mercado.pro_id=" + pro_id + "") : "");
            List<Mercado> lstMercados = new List<Mercado>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_mercado.mer_id, tab_mercado.mer_codigo, tab_mercado.mer_nombre, tab_mercado.mer_estado, tab_mercado.pro_mer " +
                    "FROM tab_mercado " +
                    "Inner Join tab_campo_producto_mercado ON tab_mercado.mer_id = tab_campo_producto_mercado.mer_id " +
                    "WHERE mer_estado = 1 " +
                    where +
                    " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {

                    Mercado mercado = new Mercado();
                    mercado.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    mercado.Mer_codigo = Convert.ToString(rs.Fields["mer_codigo"].Value);
                    mercado.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    mercado.Mer_estado = Convert.ToInt32(rs.Fields["mer_estado"].Value);
                    mercado.Pro_mer = Convert.ToInt32(rs.Fields["pro_mer"].Value);

                    lstMercados.Add(mercado);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMercados;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMercados;
            }
        }
    }
}
