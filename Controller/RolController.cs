using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class RolController
    {
        public static List<Rol> GetListRoles(long rol_id)
        {
            RolObject rol = new RolObject();
            return rol.listRol(rol_id);
        }
        //public static List<Rol> GetListRolesSegunCriterio(string rol_cod, string rol_titulo, string rol_descripcion)
        //{
        //    RolObject rol = new RolObject();
        //    return rol.listRolSegunCriterio(rol_cod, rol_titulo, rol_descripcion);
        //}
    }
}