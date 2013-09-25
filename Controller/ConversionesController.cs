using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class ConversionesController
    {
        public static List<Conversiones> GetListaConversiones(long con_id)
        {
            ConversionesObject objConversiones = new ConversionesObject();
            return objConversiones.listConversiones(con_id);
        }
        public static List<Conversiones> GetListaConversionesPorUnidadMedida(long umd_id)
        {
            ConversionesObject objConversiones = new ConversionesObject();
            return objConversiones.listaConversionesPorUnidadMedida(umd_id);
        }
    }
}