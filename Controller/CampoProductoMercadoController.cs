using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class CampoProductoMercadoController
    {
        public static List<Campo_Producto_Mercado> GetListCampoProductoMercadoPorCampo(long cam_id)
        {
            CampoProductoMercadoObject obj = new CampoProductoMercadoObject();
            return obj.listCampoProductoMercadoPorCampo(cam_id);
        }
        public static List<Campo_Producto_Mercado> GetListCampoProductoMercadoPorCampoProducto(long cam_id, long pro_id)
        {
            CampoProductoMercadoObject obj = new CampoProductoMercadoObject();
            return obj.listCampoProductoMercadoPorCampoProducto(cam_id, pro_id);
        }
        public static List<Campo_Producto_Mercado> GetListMercadosPorCampoProducto(long cam_id, long pro_id)
        {
            CampoProductoMercadoObject obj = new CampoProductoMercadoObject();
            return obj.ListaMercadosAsociadosPorCampoProducto(cam_id, pro_id);
        }
        public static List<Campo_Producto_Mercado> GetListCampoProductoMercado(long cpm_id)
        {
            CampoProductoMercadoObject obj = new CampoProductoMercadoObject();
            return obj.listCampoProductoMercado(cpm_id);
        }
    }
}