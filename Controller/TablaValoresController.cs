using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TablaValoresController
    {
        public static List<Tabla_Valores> GetListaTablaValores(long tva_id)
        {
            TablaValoresObject objTablaValores = new TablaValoresObject();
            return objTablaValores.listTablaValores(tva_id);
        }
        public static List<Tabla_Valores> GetListaTablaValoresPorTabla(long tab_id)
        {
            TablaValoresObject objTablaValores = new TablaValoresObject();
            return objTablaValores.ListaTablaValoresPorTabla(tab_id);
        }
    }
}