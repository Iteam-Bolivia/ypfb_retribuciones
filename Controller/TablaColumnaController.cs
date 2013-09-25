using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TablaColumnaController
    {
        public static List<Tabla_Columna> GetListaTablaColumna(long tac_id)
        {
            TablaColumnaObject objTablaValores = new TablaColumnaObject();
            return objTablaValores.listTablaColumna(tac_id);
        }
        public static List<Tabla_Columna> GetListaTablaColumnaPorTablaFila(long taf_id)
        {
            TablaColumnaObject objTablaValores = new TablaColumnaObject();
            return objTablaValores.ListaTablaColumnaPorTablaFila(taf_id);
        }
        public static int GetCantidadColumnasPorTablaFila(long taf_id)
        {
            TablaColumnaObject objTablaValores = new TablaColumnaObject();
            return objTablaValores.CantidadColumnasPorFila(taf_id);
        }
        public static Tabla_Columna GetDatosTablaColumnaPorTablaFila(long taf_id)
        {
            TablaColumnaObject objTablaValores = new TablaColumnaObject();
            return objTablaValores.datosTablaColumnaPorFila(taf_id);
        }

        public static List<Tabla_Columna> GetDatosTablaColumnaValor(long taf_id)
        {
          TablaColumnaObject objTablaValores = new TablaColumnaObject();
          return objTablaValores.listTablaColumnaValores(taf_id);
        }
    }
}