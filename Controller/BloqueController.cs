using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class BloqueController
    {
        public static List<Bloque> GetListBloques(long blo_id)
        {
            BloqueObject bloque = new BloqueObject();
            return bloque.listBloque(blo_id);
        }
        public static List<Bloque> GetListBloquesSegunCriterio(string blo_codigo, string blo_nombre)
        {
            BloqueObject bloque = new BloqueObject();
            return bloque.listBloqueSegunCriterio(blo_codigo, blo_nombre);
        }
    }
}