using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TablaFilaController
    {
        public static List<Tabla_Fila> GetListaTablaFila(long taf_id)
        {
            TablaFilaObject objTabla = new TablaFilaObject();
            return objTabla.listTablaFila(taf_id);
        }
        public static List<Tabla_Fila> GetListaTablaFilaPorTabla(long tab_id)
        {
            TablaFilaObject objTablaFila = new TablaFilaObject();
            return objTablaFila.listTablaFilaPorTabla(tab_id);
        }
        public static List<Tabla_Fila> GetDatosTablaFilaValor(long ctt_id, long tab_id)
        {
          TablaFilaObject objTablaValores = new TablaFilaObject();
          return objTablaValores.listTablaFilaValores(ctt_id, tab_id);
        }
    }
}