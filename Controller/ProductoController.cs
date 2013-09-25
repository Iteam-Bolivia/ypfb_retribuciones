using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class ProductoController
    {
        public static List<Producto> GetListProductosPorCampo(long cam_id)
        {
            ProductoObject producto = new ProductoObject();
            return producto.listProductosPorCampo(cam_id);
        }

        public static List<Producto> GetListProducto(long pro_id)
        {
            ProductoObject objetoProducto = new ProductoObject();
            return objetoProducto.listProducto(pro_id);
        }
        public static List<Producto> GetListProductosSegunCriterio(string pro_codigo, string pro_nombre)
        {
            ProductoObject producto = new ProductoObject();
            return producto.listProductoSegunCriterio(pro_codigo, pro_nombre);
        }
        public static Producto GetDatosProducto(long pro_id)
        {
            ProductoObject objetoProducto = new ProductoObject();
            return objetoProducto.ProductoPorCodigo(pro_id);
        }
    }
}