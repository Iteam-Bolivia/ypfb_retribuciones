using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class Titular_SinonimoController
    {

      public static List<Titular_Contrato> ExisteTitularSinonimo(string tit_nombre)
      {
        Titular_SinonimoObject obj = new Titular_SinonimoObject();
        return obj.buscarSinonimoTitular(tit_nombre);
      }


        public static List<Titular_Sinonimo> GetListTitular_SinonimoPorTitular(long tit_id)
        {
            Titular_SinonimoObject obj = new Titular_SinonimoObject();
            return obj.listTitular_SinonimoPorTitular(tit_id);
        }
        //public static List<Titular_Sinonimo> GetListTitular_SinonimoPorTitularProducto(long tit_id, long pro_id)
        //{
        //    Titular_SinonimoObject obj = new Titular_SinonimoObject();
        //    return obj.listTitular_SinonimoPorTitularProducto(tit_id, pro_id);
        //}
        //public static List<Titular_Sinonimo> GetListMercadosPorTitularProducto(long tit_id, long pro_id)
        //{
        //    Titular_SinonimoObject obj = new Titular_SinonimoObject();
        //    return obj.ListaMercadosAsociadosPorTitularProducto(tit_id, pro_id);
        //}
        public static List<Titular_Sinonimo> GetListTitular_Sinonimo(long cpm_id)
        {
            Titular_SinonimoObject obj = new Titular_SinonimoObject();
            return obj.listTitular_Sinonimo(cpm_id);
        }

    }
}