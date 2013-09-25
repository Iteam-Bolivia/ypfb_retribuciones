using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TablaController
    {
        public static List<Tabla> GetListaTabla(long tab_id)
        {
            TablaObject objTabla = new TablaObject();
            return objTabla.listTabla(tab_id);
        }
        public static List<Tabla> GetListaTablaSegunCriterio(string tab_codigo, string tab_nombre)
        {
            TablaObject objTabla = new TablaObject();
            return objTabla.ListaTablaPorCriterio(tab_codigo, tab_nombre);
        }

       
    }
}