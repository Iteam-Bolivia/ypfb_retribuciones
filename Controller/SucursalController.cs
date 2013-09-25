using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class SucursalController
    {
        public static List<Sucursal> GetSucursales(long suc_id)
        {
            SucursalObject objSucursal = new SucursalObject();
            return objSucursal.listSucursal(suc_id);
        }
    }
}