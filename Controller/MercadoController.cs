using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class MercadoController
    {
        public static List<Mercado> GetListMercados(long mer_id)
        {
            MercadoObject objMercados = new MercadoObject();
            return objMercados.listMercado(mer_id);
        }

        public static List<Mercado> GetListMercadosSegunCriterio(string mer_codigo, string mer_nombre)
        {
            MercadoObject mercado = new MercadoObject();
            return mercado.listMercadoSegunCriterio(mer_codigo, mer_nombre);
        }

        public static List<Mercado> GetListMercadosPorProducto(long pro_id)
        {
            MercadoObject objMercados = new MercadoObject();
            return objMercados.listMercadosPorProducto(pro_id);
        }
    }
}