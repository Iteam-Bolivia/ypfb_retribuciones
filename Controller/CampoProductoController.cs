using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class CampoProductoController
    {
        public static List<CampoProducto> GetListProductosPorCampo(long cam_id)
        {
            CampoProductoObject objCampoProducto = new CampoProductoObject();
            return objCampoProducto.listaProductosPorCampo(cam_id);
        }
    }
}