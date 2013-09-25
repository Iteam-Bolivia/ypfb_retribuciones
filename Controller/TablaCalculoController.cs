using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TablaCalculoController
    {
        public static List<Tabla_Calculo> GetListaTablaCalculo(long tca_id)
        {
            TablaCalculoObject objTablaCalculo = new TablaCalculoObject();
            return objTablaCalculo.listTablaCalculo(tca_id);
        }
        public static List<Tabla_Calculo> GetListaTablaCalculoPorContrato(long ctt_id)
        {
            TablaCalculoObject objTablaCalculo = new TablaCalculoObject();
            return objTablaCalculo.listTablaCalculoPorContrato(ctt_id);
        }
    }
}