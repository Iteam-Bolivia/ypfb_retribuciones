using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class MenuController
    {
        public static List<Menus> GetListaMenus(int men_id)
        {
            MenuObject objMenu = new MenuObject();
            //return objMenu.listMenu(men_id);
            return objMenu.listMenusSorted(men_id);
        }
        public static List<Menus> GetListaMenus(int men_id, int rol_id)
        {
            MenuObject objMenu = new MenuObject();
            return objMenu.listMenusPorRolSorted(men_id, rol_id);
        }
        public static List<Menus> GetListaMenu(int men_id)
        {
            MenuObject objMenu = new MenuObject();
            return objMenu.listMenu(men_id);
        }
    }
}