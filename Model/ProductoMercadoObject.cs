using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ProductoMercadoObject:ProductoMercado
    {
        /// <summary>
        /// Verifica la existencia de un producto en que mercados
        /// </summary>
        /// <param name="pro_id">Prodicto Id</param>
        /// <returns>true si existe false si no existe</returns>
        public bool existProductoMercado(long pro_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT pro_id FROM tab_producto_mercado WHERE pro_id='" + pro_id + "'";

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
        /// listProductoMercado Method
        /// </summary>
        public List<ProductoMercado> listProductoMercado(long pro_id)
        {
            String where = (pro_id != 0 ? ("where pro_id=" + pro_id + "") : "");
            List<ProductoMercado> lstProductoMercado = new List<ProductoMercado>();

            try
            {
                Connection_On();
                SQL = "SELECT cae_id, pro_id, mer_id, mon_id " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    ProductoMercado productoMercado = new ProductoMercado();
                    productoMercado.Cae_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);

                    List<Producto> producto = new List<Producto>();
                    ProductoObject productoObject = new ProductoObject();

                    producto = productoObject.listProducto(System.Convert.ToInt64(rs.Fields["pro_id"].Value));

                    if (producto.Count == 0)
                    {
                        productoMercado.Pro = new Producto();
                        productoMercado.Pro.Pro_codigo = producto[0].Pro_codigo;
                        productoMercado.Pro.Pro_estado = producto[0].Pro_estado;
                        productoMercado.Pro.Pro_id = producto[0].Pro_id;
                        productoMercado.Pro.Pro_nombre = producto[0].Pro_nombre;
                    }
                    else
                    {
                        productoMercado.ListPro = new List<Producto>();
                        foreach (Producto item in producto)
                        {
                            Producto aux = new Producto();
                            aux.Pro_codigo = item.Pro_codigo;
                            aux.Pro_estado = item.Pro_estado;
                            aux.Pro_id = item.Pro_id;
                            aux.Pro_nombre = item.Pro_nombre;
                            productoMercado.ListPro.Add(aux);
                        }
                        
                    }
                    List<Mercado> mercado = new List<Mercado>();
                    MercadoObject mercadoObject = new MercadoObject();
                    mercado = mercadoObject.listMercado(System.Convert.ToInt64(rs.Fields["mer_id"].Value));
                    if (mercado.Count == 0)
                    {
                        productoMercado.Mer = new Mercado();
                        productoMercado.Mer.Mer_codigo = mercado[0].Mer_codigo;
                        productoMercado.Mer.Mer_estado = mercado[0].Mer_estado;
                        productoMercado.Mer.Mer_id = mercado[0].Mer_id;
                        productoMercado.Mer.Mer_nombre = mercado[0].Mer_nombre;
                    }
                    else
                    {
                        productoMercado.ListMer = new List<Mercado>();
                        foreach (Mercado item in mercado)
                        {
                            Mercado aux = new Mercado();
                            aux.Mer_codigo = item.Mer_codigo;
                            aux.Mer_estado = item.Mer_estado;
                            aux.Mer_id = item.Mer_id;
                            aux.Mer_nombre = item.Mer_nombre;
                            productoMercado.ListMer.Add(aux);
                        }
                    }
                    Moneda moneda = new Moneda();
                    MonedaObject monedaObject = new MonedaObject();
                    moneda = monedaObject.listMoneda(System.Convert.ToInt64(rs.Fields["mon_id"].Value));

                    productoMercado.Mon = new Moneda();
                    productoMercado.Mon.Mon_id = moneda.Mon_id;
                    productoMercado.Mon.Mon_codigo = moneda.Mon_codigo;
                    productoMercado.Mon.Mon_estado = moneda.Mon_estado;
                    productoMercado.Mon.Mon_nombre = moneda.Mon_nombre;


                    lstProductoMercado.Add(productoMercado);


                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProductoMercado;
            }
        }/* Method listProducto */

        public List<ProductoMercado> listaMercadosPorProducto(long pro_id)
        {
            string Where = (pro_id != 0 ? ("AND pro_id = " + pro_id) : "");
            List<ProductoMercado> lstProductoMercado = new List<ProductoMercado>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_mercado.mer_id, tab_mercado.mer_codigo, tab_mercado.mer_nombre, tab_mercado.mer_estado " +
                    "FROM tab_mercado " +
                    "Inner Join tab_producto_mercado ON tab_mercado.mer_id = tab_producto_mercado.mer_id " +
                    "WHERE mer_estado = 1 " +
                    Where +
                    " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    ProductoMercado producto = new ProductoMercado();                    
                    producto.Mer = new Mercado();
                    producto.Mer.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    producto.Mer.Mer_codigo = Convert.ToString(rs.Fields["mer_codigo"].Value);
                    producto.Mer.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    //producto.Pro = new Producto();
                    //producto.Pro.Lista_Mercados = Convert.ToString(rs.Fields["mer_nombre"]);
                    lstProductoMercado.Add(producto);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstProductoMercado;
            }
        }
    }
}
