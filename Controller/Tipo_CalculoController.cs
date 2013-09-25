using System.Collections.Generic;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class Tipo_CalculoController
    {
        public static List<Tipo_Calculo> GetListTipoCalculo(long tcl_id)
        {
            Tipo_CalculoObject objTipoCalculo = new Tipo_CalculoObject();
            return objTipoCalculo.listTipoCalculo(tcl_id);
        }
    }
}