using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class CampoProductoObject:CampoProducto
    {
        /// <summary>
        /// Verificacion si existe campo producto
        /// </summary>
        /// <param name="cam_id">Campo Id</param>
        /// <returns>true si existe el campo con algun producto</returns>
        public bool existCampoProducto(long cam_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT cam_id FROM tab_campo_producto WHERE cam_id='" + cam_id + "'";

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
        }/* Method existCampoProducto */


        /// <summary>
        /// Lista todos los campos y sus productos 
        /// </summary>
        /// <param name="cam_id">campo Id</param>
        /// <returns>Lista de todos los campos y sus productos</returns>
        public List<CampoProducto> listCampoProducto(long cam_id)
        {
            String where = (cam_id != 0 ? ("AND cam_id=" + cam_id + "") : "");
            List<CampoProducto> lstCampoProducto = new List<CampoProducto>();

            try
            {
                Connection_On();
                SQL = "SELECT cap_id, pro_id, cam_id" +
                          "FROM tab_campo_producto " +
                          "WHERE  " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    CampoProducto campoProducto = new CampoProducto();
                    campoProducto.Cap_id = System.Convert.ToInt64(rs.Fields["cap_id"].Value);


                    

                    List<Campo> campo = new List<Campo>();
                    CampoObject campoObject = new CampoObject();
                    //Cargo el campo por su id
                    campo = campoObject.listCampo(System.Convert.ToInt64(rs.Fields["cam_id"].Value));

                    campoProducto.Cam = new Campo();
                    campoProducto.Cam.Cam_id= campo[0].Cam_id;
                    campoProducto.Cam.Cam_codigo = campo[0].Cam_codigo;
                    campoProducto.Cam.Cam_estado = campo[0].Cam_estado;
                    campoProducto.Cam.Cam_nombre = campo[0].Cam_nombre;
                    campoProducto.Cam.Cam_codigo = campo[0].Cam_codigo;


                    List<Producto> producto = new List<Producto>();
                    ProductoObject productoobject = new ProductoObject();

                    producto = productoobject.listProducto(System.Convert.ToInt64(rs.Fields["ctt_id"].Value));

                    if (producto.Count == 0)
                    {
                        campoProducto.Pro = new Producto();
                        campoProducto.Pro.Pro_id = producto[0].Pro_id;
                        campoProducto.Pro.Pro_codigo = producto[0].Pro_codigo;
                        campoProducto.Pro.Pro_estado = producto[0].Pro_estado;
                        campoProducto.Pro.Pro_nombre = producto[0].Pro_nombre;
                    }
                    else
                    {
                        campoProducto.ListPro = new List<Producto>();
                        foreach (Producto item in producto)
                        {
                            Producto aux = new Producto();
                            aux.Pro_id = item.Pro_id;
                            aux.Pro_codigo = item.Pro_codigo;
                            aux.Pro_estado = item.Pro_estado;
                            aux.Pro_nombre = item.Pro_nombre;
                            campoProducto.ListPro.Add(aux);
                        }
                        
                    }


                    lstCampoProducto.Add(campoProducto);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampoProducto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampoProducto;
            }
        }/* Method lisCampoProduto */

        public List<CampoProducto> listaProductosPorCampo(long cam_id)
        {
            string Where = (cam_id != 0 ? ("AND cam_id = " + cam_id) : "");
            List<CampoProducto> listaCamposProducto = new List<CampoProducto>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_producto.pro_id, tab_producto.pro_codigo, tab_producto.pro_nombre, tab_producto.pro_estado " +
                    "FROM tab_producto " +
                    "Inner Join tab_campo_producto ON tab_campo_producto.pro_id = tab_producto.pro_id " +
                    "WHERE pro_estado = 1 " +                    
                    Where +
                    " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    CampoProducto campo = new CampoProducto();
                    campo.Pro = new Producto();
                    campo.Pro.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    campo.Pro.Pro_codigo = Convert.ToString(rs.Fields["pro_codigo"].Value);
                    campo.Pro.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    campo.Pro.Pro_estado = Convert.ToInt32(rs.Fields["pro_estado"].Value);
                    listaCamposProducto.Add(campo);
                    rs.MoveNext();
                }

                Connection_Off(1);
                return listaCamposProducto;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return listaCamposProducto;
            }
        }
    }
}