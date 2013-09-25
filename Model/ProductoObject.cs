using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    class ProductoObject : Producto
    {
        /// <summary>
        /// existProducto Method
        /// </summary>
        public bool existProducto(long pro_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT pro_id FROM tab_producto WHERE pro_id='" + pro_id + "'";

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
        }/* Method existProducto */

        /// <summary>
        /// listProducto Method
        /// </summary>
        public List<Producto> listProducto(long pro_id)
        {
            String where = (pro_id != 0 ? ("AND A.pro_id=" + pro_id + "") : "");
            List<Producto> lstProducto = new List<Producto>();

            try
            {
                Connection_On();
                SQL = "SELECT A.pro_id, pro_codigo, pro_nombre, pro_estado, A.umd_id, umd_nombre, pro_var, pro_mer " +
                    "FROM tab_producto A " +
                    "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id " +
                    "WHERE pro_estado = 1 " +
                    where;
                SQL += " ORDER BY pro_nombre";
                // Execute the query specifying static sursor, batch optimistic locking
                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs2.EOF)
                {
                    Producto producto = new Producto();
                    producto.Pro_id = Convert.ToInt64(rs2.Fields["pro_id"].Value);
                    producto.Pro_codigo = Convert.ToString(rs2.Fields["pro_codigo"].Value);
                    producto.Pro_nombre = Convert.ToString(rs2.Fields["pro_nombre"].Value);
                    producto.Pro_estado = Convert.ToInt32(rs2.Fields["pro_estado"].Value);
                    producto.Umd_id = Convert.ToInt64(rs2.Fields["umd_id"].Value);
                    producto.Umd_nombre = Convert.ToString(rs2.Fields["umd_nombre"].Value);
                    producto.Pro_var = Convert.ToInt32(rs2.Fields["pro_var"].Value);
                    producto.Pro_mer = Convert.ToInt32(rs2.Fields["pro_mer"].Value);

                    List<Unidad_Medida> unidadMedida = new List<Unidad_Medida>();
                    UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
                    unidadMedida = objUnidadMedida.ListaUnidadMedidaNombrePorProducto(producto.Umd_id);
                    foreach (Unidad_Medida item in unidadMedida)
                    {
                        producto.Lista_Unidad_Medida += item.Umd_nombre + ", ";
                    }
                    if (!string.IsNullOrWhiteSpace(producto.Lista_Unidad_Medida))
                        producto.Lista_Unidad_Medida = producto.Lista_Unidad_Medida.Substring(0, producto.Lista_Unidad_Medida.Length - 2);
                    lstProducto.Add(producto);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstProducto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstProducto;
            }
        }


        public List<Producto> listProductoPorCondicion(String condicion)
        {
          List<Producto> lstProducto = new List<Producto>();
          try
          {
            Connection_On();
            SQL = "SELECT A.pro_id, pro_codigo, pro_nombre, pro_estado, A.umd_id, umd_nombre, pro_mer " +
                  "FROM tab_producto A " +
                  "INNER JOIN tab_unidad_medida B ON A.umd_id = B.umd_id " +
                  "WHERE pro_estado = 1 AND pro_var = 1 " +
                  condicion;
            SQL += " ORDER BY pro_id";
            // Execute the query specifying static sursor, batch optimistic locking
            rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs2.EOF)
            {
              Producto producto = new Producto();
              producto.Pro_id = Convert.ToInt64(rs2.Fields["pro_id"].Value);
              producto.Pro_codigo = Convert.ToString(rs2.Fields["pro_codigo"].Value);
              producto.Pro_nombre = Convert.ToString(rs2.Fields["pro_nombre"].Value);
              producto.Pro_estado = Convert.ToInt32(rs2.Fields["pro_estado"].Value);
              producto.Umd_id = Convert.ToInt64(rs2.Fields["umd_id"].Value);
              producto.Umd_nombre = Convert.ToString(rs2.Fields["umd_nombre"].Value);
              producto.Pro_mer = Convert.ToInt32(rs2.Fields["pro_mer"].Value);

              List<Unidad_Medida> unidadMedida = new List<Unidad_Medida>();
              UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
              unidadMedida = objUnidadMedida.ListaUnidadMedidaNombrePorProducto(producto.Umd_id);
              foreach (Unidad_Medida item in unidadMedida)
              {
                producto.Lista_Unidad_Medida += item.Umd_nombre + ", ";
              }
              if (!string.IsNullOrWhiteSpace(producto.Lista_Unidad_Medida))
                producto.Lista_Unidad_Medida = producto.Lista_Unidad_Medida.Substring(0, producto.Lista_Unidad_Medida.Length - 2);
              lstProducto.Add(producto);
              rs2.MoveNext();
            }
            Connection_Off(2);
            return lstProducto;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(2);
            return lstProducto;
          }
        }
    

        public List<Producto> listProductosPorCampo(long cam_id)
        {
            String where = (cam_id != 0 ? ("AND cam_id=" + cam_id + "") : "");
            List<Producto> lstProducto = new List<Producto>();

            try
            {
                Connection_On();
                SQL = "SELECT tab_producto.pro_id, tab_producto.pro_codigo, tab_producto.pro_nombre, tab_producto.pro_estado, tab_producto.umd_id, tab_producto.pro_mer " +
                    "" +
                    "FROM tab_producto " +
                    "Inner Join tab_campo_producto ON tab_campo_producto.pro_id = tab_producto.pro_id " +
                    "WHERE pro_estado = 1 " +
                    where +
                    " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {

                    Producto producto = new Producto();
                    producto.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    producto.Pro_codigo = Convert.ToString(rs.Fields["pro_codigo"].Value);
                    producto.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    producto.Pro_estado = Convert.ToInt32(rs.Fields["pro_estado"].Value);
                    producto.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    producto.Pro_mer = Convert.ToInt32(rs.Fields["pro_mer"].Value);

                    //List<Unidad_Medida> unidadMedida = new List<Unidad_Medida>();
                    //UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
                    //unidadMedida = objUnidadMedida.listaUnidadMedidaPorProducto(producto.Pro_id);

                    //foreach (Unidad_Medida item in unidadMedida)
                    //{
                    //    producto.Lista_Unidad_Medida += item.Umd_nombre + ", ";
                    //}
                    //if (!string.IsNullOrWhiteSpace(producto.Lista_Unidad_Medida))
                    //    producto.Lista_Unidad_Medida = producto.Lista_Unidad_Medida.Substring(0, producto.Lista_Unidad_Medida.Length - 2);
                    lstProducto.Add(producto);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstProducto;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProducto;
            }
        }
        public List<Producto> listProductoSegunCriterio(string pro_codigo, string pro_nombre)
        {
            List<Producto> lstProducto = new List<Producto>();
            try
            {
                Connection_On();
                SQL = "SELECT pro_id, pro_codigo, pro_nombre, pro_estado, umd_id, pro_mer ";
                SQL += "FROM tab_producto ";
                SQL += "WHERE pro_codigo LIKE '%" + pro_codigo + "%' ";
                SQL += "AND pro_nombre LIKE '%" + pro_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Producto producto = new Producto();
                    producto.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    producto.Pro_codigo = Convert.ToString(rs.Fields["pro_codigo"].Value);
                    producto.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    producto.Pro_estado = Convert.ToInt32(rs.Fields["pro_estado"].Value);
                    producto.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    producto.Pro_mer = Convert.ToInt32(rs.Fields["pro_mer"].Value);

                    lstProducto.Add(producto);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstProducto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProducto;
            }
        }


        public Producto ProductoPorCodigo(long pro_id)
        {
            String where = (pro_id != 0 ? ("AND pro_id=" + pro_id + "") : "");
            Producto producto = new Producto();

            try
            {
                Connection_On();
                SQL = "SELECT pro_id, pro_codigo, pro_nombre, pro_estado, umd_id, pro_mer " +
                          "FROM tab_producto " +
                          "WHERE pro_estado = 1 " +
                          where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    producto = new Producto();
                    producto.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    producto.Pro_codigo = Convert.ToString(rs.Fields["pro_codigo"].Value);
                    producto.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    producto.Pro_estado = Convert.ToInt32(rs.Fields["pro_estado"].Value);
                    producto.Umd_id = Convert.ToInt64(rs.Fields["umd_id"].Value);
                    producto.Pro_mer = Convert.ToInt32(rs.Fields["pro_mer"].Value);
                }
                Connection_Off(1);
                return producto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return producto;
            }
        }
    }
}