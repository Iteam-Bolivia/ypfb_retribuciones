using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class MonedaController
    {
        public static List<Moneda> GetListMonedas(long mon_id)
        {
            MonedaObject objMoneda = new MonedaObject();
            return objMoneda.listMoneda(mon_id);
        }
    }
}