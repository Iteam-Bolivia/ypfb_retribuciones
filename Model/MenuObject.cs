/*
 * @author acastellon
 * MenuObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class MenuObject : Menus
    {
        /* Method generateIdMenu */
        public long generateIdMenu()
        {
            long men_id = 0;
            try
            {

                // Open Connection object
                Connection_On();
                SQL = "SELECT nextval('tab_menu_men_id_seq')";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                // If recordser is EOF
                if (!rs.EOF)
                {
                    if (rs.Fields["nextval"].Value == null)
                    {
                        men_id = 0;
                    }
                    else
                    {
                        men_id = System.Convert.ToInt64(rs.Fields["nextval"].Value);
                    }
                    Connection_Off(1);
                }
                else
                {
                    men_id = 0;
                    Connection_Off(1);
                }
                Connection_Off(1);
                return men_id;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                men_id = 0;
                return men_id;
            }
        }/* Method generateIdMenu */
        /// <summary>
        /// existMenu Method
        /// </summary>
        public bool existMenu(long men_id)
        {
            bool flag = false;
            try
            {
                cnn = Connection_On();
                SQL = "SELECT men_id FROM tab_menu WHERE men_id='" + men_id;

                // Execute the query specifying static sursor, batch optimistic locking
                //this.rs.Open(this.SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Connection_Off(1);
                    flag = true;
                }
                else
                {
                    Connection_Off(1);
                    flag = false;
                }
                Connection_Off(1);
                return flag;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                flag = false;
                return flag;
            }
        }

        /// <summary>
        /// listMenu Method
        /// </summary>
        public List<Menus> listMenu(long men_id)
        {

            String where = (men_id != 0 ? ("AND men_id=" + men_id + "") : "");
            List<Menus> lstMenu = new List<Menus>();

            try
            {
                Connection_On();
                SQL = "SELECT men_id, men_titulo, men_enlace, men_posicion, men_imagen, men_estado, men_par " +
                       "FROM tab_menu " +
                       "WHERE men_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMenu.Add(new Menus(System.Convert.ToInt32(rs.Fields["men_id"].Value), System.Convert.ToInt64(rs.Fields["men_par"].Value), (string)rs.Fields["men_titulo"].Value, (string)rs.Fields["men_enlace"].Value, (string)rs.Fields["men_posicion"].Value, (string)rs.Fields["men_imagen"].Value, System.Convert.ToInt32(rs.Fields["men_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }/* Method listMenu */



        /// <summary>
        /// listMenu Method
        /// </summary>
        public List<Menus> listMenuPar(long men_id)
        {

            String where = (men_id != 0 ? ("AND men_id=" + men_id + "") : "");
            List<Menus> lstMenu = new List<Menus>();

            try
            {
                Connection_On();
                SQL = "SELECT m.men_id, " +
                            "(SELECT mp.men_titulo FROM tab_menu mp WHERE mp.men_id = m.men_par) AS men_par," +
                             "m.men_titulo, m.men_enlace, m.men_posicion, m.men_imagen, m.men_estado " +
                       " FROM tab_menu m" +
                       " WHERE m.men_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMenu.Add(new Menus(System.Convert.ToInt64(rs.Fields["men_id"].Value), System.Convert.ToString(rs.Fields["men_par"].Value), (string)rs.Fields["men_titulo"].Value, (string)rs.Fields["men_enlace"].Value, (string)rs.Fields["men_posicion"].Value, (string)rs.Fields["men_imagen"].Value, System.Convert.ToInt64(rs.Fields["men_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }/* Method listMenu */

        /// <summary>
        /// listMenu Method
        /// </summary>
        public List<Menus> listParentMenu(long men_par, long rol_id)
        {
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_rol.rol_id, " +
                      "tab_menu.men_id, " +
                      "tab_menu.men_par, " +
                      "tab_menu.men_titulo, " +
                      "tab_menu.men_enlace, " +
                      "tab_menu.men_posicion, " +
                      "tab_menu.men_imagen, " +
                      "tab_menu.men_estado " +
                      "FROM " +
                      "tab_rol " +
                      "INNER JOIN tab_usurolmenu ON tab_rol.rol_id = tab_usurolmenu.rol_id " +
                      "INNER JOIN tab_menu ON tab_menu.men_id = tab_usurolmenu.men_id " +
                      "WHERE tab_menu.men_estado = 1 " +
                      "AND tab_menu.men_par = " + men_par + " " +
                      "AND tab_rol.rol_id = " + rol_id + " " +
                      "ORDER BY tab_menu.men_id ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMenu.Add(new Menus(System.Convert.ToInt64(rs.Fields["men_id"].Value), System.Convert.ToInt64(rs.Fields["men_par"].Value), (string)rs.Fields["men_titulo"].Value, (string)rs.Fields["men_enlace"].Value, (string)rs.Fields["men_posicion"].Value, (string)rs.Fields["men_imagen"].Value, System.Convert.ToInt64(rs.Fields["men_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                return lstMenu;
            }
        }/* Method listMenu */




        /// <summary>
        /// listMenu Method
        /// </summary>
        public List<Menus> listParentMenu(long men_par)
        {
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                SQL = "SELECT men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, men_estado " +
                          "FROM tab_menu " +
                          "WHERE men_estado = 1 " +
                          "AND men_par = " + men_par + " " + 
                          "ORDER BY men_id ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstMenu.Add(new Menus(System.Convert.ToInt32(rs.Fields["men_id"].Value), System.Convert.ToInt32(rs.Fields["men_par"].Value), (string)rs.Fields["men_titulo"].Value, (string)rs.Fields["men_enlace"].Value, (string)rs.Fields["men_posicion"].Value, (string)rs.Fields["men_imagen"].Value, System.Convert.ToInt32(rs.Fields["men_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }/* Method listMenu */


        /// <summary>
        /// Metodo Interno no usado en Controller
        /// </summary>
        /// <param name="men_par"></param>
        /// <returns></returns>
        public List<Menus> listMenusSegunRol(long men_par, long rol_id)
        {
            String where = (men_par != 0 ? ("AND men_par = " + men_par + "") : "");
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                SQL = "SELECT men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, men_estado " +
                       "FROM tab_menu " +
                       "WHERE men_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Menus menu = new Menus();
                    menu.Men_id = Convert.ToInt32(rs.Fields["men_id"].Value);
                    menu.Men_par = Convert.ToInt32(rs.Fields["men_par"].Value);
                    menu.Men_titulo = Convert.ToString(rs.Fields["men_titulo"].Value);
                    menu.Men_enlace = Convert.ToString(rs.Fields["men_enlace"].Value);
                    menu.Men_posicion = Convert.ToString(rs.Fields["men_posicion"].Value);
                    menu.Men_imagen = Convert.ToString(rs.Fields["men_imagen"].Value);
                    menu.Men_estado = Convert.ToInt32(rs.Fields["men_estado"].Value);

                    List<Usurolmenu> listaUsuarioRolMenu = new List<Usurolmenu>();
                    UsurolMenuObject usuarioRolMenuObject = new UsurolMenuObject();
                    listaUsuarioRolMenu = usuarioRolMenuObject.listaUsuarioRolMenuPorRol(rol_id);
                    foreach (Usurolmenu item in listaUsuarioRolMenu)
                    {
                        if (item.Men_id1.Men_id == menu.Men_id)
                        {
                            menu.Menu_visible = true;
                            break;
                        }
                        else
                        {
                            menu.Menu_visible = false;
                            //break;
                        }
                    }

                    lstMenu.Add(menu);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }
        public List<Menus> listMenusPorRolSorted(int men_id, int rol_id)
        {
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                List<Menus> lstMenuPadres = this.listParentMenu(0);
                List<Menus> lstMenuHijos = new List<Menus>();
                Menus menuGeneral = null;
                foreach (Menus item in lstMenuPadres)
                {
                    menuGeneral = new Menus();
                    menuGeneral.Men_id = item.Men_id;
                    menuGeneral.Men_titulo = item.Men_titulo;
                    menuGeneral.Menu_visible = false;
                    menuGeneral.Men_par = item.Men_par;
                    lstMenu.Add(menuGeneral);
                    lstMenuHijos = this.listMenusSegunRol(item.Men_id, rol_id);
                    foreach (Menus itemHijos in lstMenuHijos)
                    {
                        menuGeneral = new Menus();
                        menuGeneral.Men_id = itemHijos.Men_id;
                        menuGeneral.Men_titulo = itemHijos.Men_titulo;
                        menuGeneral.Menu_visible = itemHijos.Menu_visible;
                        menuGeneral.Men_par = itemHijos.Men_par;
                        lstMenu.Add(menuGeneral);
                    }
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }
        public List<Menus> listMenus(long men_par)
        {
            String where = (men_par != 0 ? ("AND men_par = " + men_par + "") : "");
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                SQL = "SELECT men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, men_estado " +
                       "FROM tab_menu " +
                       "WHERE men_estado = 1 " +
                          where;
                SQL += "ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Menus menu = new Menus();
                    menu.Men_id = Convert.ToInt32(rs.Fields["men_id"].Value);
                    menu.Men_par = Convert.ToInt32(rs.Fields["men_par"].Value);
                    menu.Men_titulo = Convert.ToString(rs.Fields["men_titulo"].Value);
                    menu.Men_enlace = Convert.ToString(rs.Fields["men_enlace"].Value);
                    menu.Men_posicion = Convert.ToString(rs.Fields["men_posicion"].Value);
                    menu.Men_imagen = Convert.ToString(rs.Fields["men_imagen"].Value);
                    menu.Men_estado = Convert.ToInt32(rs.Fields["men_estado"].Value);
                    menu.Menu_visible = false;
                    lstMenu.Add(menu);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }
        public List<Menus> listMenusSorted(long men_id)
        {
            List<Menus> lstMenu = new List<Menus>();
            try
            {
                Connection_On();
                List<Menus> lstMenuPadres = this.listParentMenu(0);
                List<Menus> lstMenuHijos = new List<Menus>();
                Menus menuGeneral = null;
                foreach (Menus item in lstMenuPadres)
                {
                    menuGeneral = new Menus();
                    menuGeneral.Men_id = item.Men_id;
                    menuGeneral.Men_par = item.Men_par;
                    menuGeneral.Men_titulo = item.Men_titulo;
                    menuGeneral.Men_enlace = item.Men_enlace;
                    menuGeneral.Men_posicion = item.Men_posicion;
                    menuGeneral.Men_imagen = item.Men_imagen;
                    menuGeneral.Men_estado = item.Men_estado;
                    menuGeneral.Menu_visible = false;
                    lstMenu.Add(menuGeneral);
                    lstMenuHijos = this.listMenus(item.Men_id);
                    foreach (Menus itemHijos in lstMenuHijos)
                    {
                        menuGeneral = new Menus();
                        menuGeneral.Men_id = itemHijos.Men_id;
                        menuGeneral.Men_par = itemHijos.Men_par;
                        menuGeneral.Men_titulo = itemHijos.Men_titulo;
                        menuGeneral.Men_enlace = itemHijos.Men_enlace;
                        menuGeneral.Men_posicion = itemHijos.Men_posicion;
                        menuGeneral.Men_imagen = itemHijos.Men_imagen;
                        menuGeneral.Men_estado = itemHijos.Men_estado;
                        menuGeneral.Menu_visible = itemHijos.Menu_visible;
                        lstMenu.Add(menuGeneral);
                    }
                }
                Connection_Off(1);
                return lstMenu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstMenu;
            }
        }
        public Menus DatosMenu(long men_id)
        {
            String where = (men_id != 0 ? ("AND men_id=" + men_id + "") : "");
            Menus menu = null;
            try
            {
                Connection_On();
                SQL = "SELECT men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, men_estado " +
                       "FROM tab_menu " +
                       "WHERE men_estado = 1 " +
                          where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    menu = new Menus();
                    menu.Men_id = Convert.ToInt32(rs.Fields["men_id"].Value);
                    menu.Men_par = Convert.ToInt32(rs.Fields["men_par"].Value);
                    menu.Men_titulo = Convert.ToString(rs.Fields["men_titulo"].Value);
                    menu.Men_enlace = Convert.ToString(rs.Fields["men_enlace"].Value);
                    menu.Men_posicion = Convert.ToString(rs.Fields["men_posicion"].Value);
                    menu.Men_imagen = Convert.ToString(rs.Fields["men_imagen"].Value);
                    menu.Men_estado = Convert.ToInt32(rs.Fields["men_estado"].Value);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return menu;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return menu;
            }
        }
    }
}