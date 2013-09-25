using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class Campo_SinonimoController
    {


      public static Campo ExisteCampoContrato(string cam_nombre)
      {
        Campo_SinonimoObject obj = new Campo_SinonimoObject();
        return obj.buscarSinonimoCampo(cam_nombre);
      }


        public static List<Campo_Sinonimo> GetListCampo_SinonimoPorCampo(long cam_id)
        {
            Campo_SinonimoObject obj = new Campo_SinonimoObject();
            return obj.listCampo_SinonimoPorCampo(cam_id);
        }
        //public static List<Campo_Sinonimo> GetListCampo_SinonimoPorCampoProducto(long cam_id, long pro_id)
        //{
        //    Campo_SinonimoObject obj = new Campo_SinonimoObject();
        //    return obj.listCampo_SinonimoPorCampoProducto(cam_id, pro_id);
        //}
        //public static List<Campo_Sinonimo> GetListMercadosPorCampoProducto(long cam_id, long pro_id)
        //{
        //    Campo_SinonimoObject obj = new Campo_SinonimoObject();
        //    return obj.ListaMercadosAsociadosPorCampoProducto(cam_id, pro_id);
        //}
        public static List<Campo_Sinonimo> GetListCampo_Sinonimo(long cpm_id)
        {
            Campo_SinonimoObject obj = new Campo_SinonimoObject();
            return obj.listCampo_Sinonimo(cpm_id);
        }
    }
}