using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class UsurolMenuObject : Usurolmenu
    {
        /// <summary>
        /// existUsurolMenu Method
        /// </summary>
        public bool existUsurolMenu(long urm_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT urm_id FROM tab_usurolmenu WHERE urm_id='" + urm_id + "'";

                // Execute the query specifying static sursor, batch optimistic locking
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
                flag = false;
                return flag;
            }
        }/* Method existUser */

        ///// <summary>
        ///// listUsurolMenu Method
        ///// </summary>
        //public List<Usurolmenu> listUsurolMenu(long urm_id)
        //{
        //    String where = (urm_id != 0 ? ("AND urm_id=" + urm_id + "") : "");
        //    List<Usurolmenu> lstUsurolmenu = new List<Usurolmenu>();

        //    try
        //    {
        //        Connection_On();
        //        SQL = "SELECT umr_id, rol_id, men_codigo, umr_privilegios, umr_estado " +
        //                  "FROM tab_umurolmenu " +
        //                  "WHERE umr_estado = 1 " +
        //                  where;

        //        // Execute the query specifying static sursor, batch optimistic locking
        //        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //        while (!rs.EOF)
        //        {
        //            // Fill data List
        //            lstUsurolmenu.Add(new Usurolmenu(
        //                System.Convert.ToInt32(rs.Fields["urm_id"].Value),
        //                (string)rs.Fields["urm_privilegios"].Value,
        //                System.Convert.ToInt32(rs.Fields["urm_estado"].Value)));
        //            rs.MoveNext();
        //        }
        //        Connection_Off(1);
        //        return lstUsurolmenu;
        //    }
        //    catch (COMException err)
        //    {
        //        Console.WriteLine("Error: " + err.Message);
        //        Connection_Off(1);
        //        return lstUsurolmenu;
        //    }
        //}/* Method listMenu */


        /// <summary>
        /// listUsurolMenu Method Rol Menu
        /// </summary>
        public List<Usurolmenu> listUsurolByRolId(long rol_id)
        {
            String where = (rol_id != 0 ? ("AND rol_id=" + rol_id + "") : "");
            List<Usurolmenu> lstUsurolmenu = new List<Usurolmenu>();

            try
            {
                Connection_On();
                SQL = "SELECT umr_id, tab_usurolmen.rol_id, tab_usurolmen.men_id, umr_privilegios, umr_estado, " +
                          " tab_rol.rol_id, rol_cod, rol_titulo, rol_descripcion, rol_estado, " +
                          " tab_menu.men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, " +
                          " men_estado " +
                          "FROM tab_usurolmenu, tab_rol, tab_menu " +
                          "WHERE umr_estado = 1 AND rol_estado=1 AND men_estado = 1 AND " +
                          "tab_rol.rol_id = tab_usurolmen.rol_id AND tab_menu.men_id = tab_menu.men_id " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstUsurolmenu.Add(new Usurolmenu(
                        System.Convert.ToInt32(rs.Fields["urm_id"].Value),
                        new Rol(
                             System.Convert.ToInt32(rs.Fields["rol_id"].Value),
                             (string)rs.Fields["rol_cod"].Value,
                             (string)rs.Fields["rol_titulo"].Value,
                             (string)rs.Fields["rol_descripcion"].Value,
                             System.Convert.ToInt32(rs.Fields["rol_estado"].Value)),
                             new Menus(
                                 System.Convert.ToInt64(rs.Fields["men_id"].Value),
                                 System.Convert.ToInt64(rs.Fields["men_par"].Value),
                                 (string)rs.Fields["men_titulo"].Value,
                                 (string)rs.Fields["men_enlace"].Value,
                                 (string)rs.Fields["men_posicion"].Value,
                                 (string)rs.Fields["men_imagen"].Value,
                                 System.Convert.ToInt32(rs.Fields["men_estado"].Value)),
                        (string)rs.Fields["urm_privilegios"].Value,
                        System.Convert.ToInt32(rs.Fields["urm_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstUsurolmenu;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsurolmenu;
            }
        }/* Method listMenu */


        ///// <summary>
        ///// findBloque Method
        ///// </summary>
        //public List<Usurolmenu> findUsurolmenu(long urm_id)
        //{
        //    List<Usurolmenu> lstUsurolmenu = new List<Usurolmenu>();
        //    try
        //    {
        //        cnn = Connection_On();
        //        SQL = "SELECT urm_id, rol_id, men_id, urm_privilegios, urm_estado " +
        //                  "FROM tab_usurolmenu " +
        //                  "WHERE urm_id='" + urm_id + "'";

        //        // Execute the query specifying static sursor, batch optimistic locking
        //        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //        if (!rs.EOF)
        //        {
        //            lstUsurolmenu.Add(new Usurolmenu(
        //                System.Convert.ToInt32(rs.Fields["urm_id"].Value),
        //                (string)rs.Fields["urm_privilegios"].Value,
        //                System.Convert.ToInt32(rs.Fields["urm_estado"].Value)));
        //            Connection_Off(1);
        //            return lstUsurolmenu;
        //        }
        //        else
        //        {
        //            Connection_Off(1);
        //            return lstUsurolmenu;
        //        }
        //    }
        //    catch (COMException err)
        //    {
        //        Console.WriteLine("Error: " + err.Message);
        //        Connection_Off(1);
        //        return lstUsurolmenu;
        //    }
        //}


        /// <summary>
        /// findBloque Method
        /// </summary>
        public List<Usurolmenu> findUsurolMenuByRolId(long rol_id)
        {
            List<Usurolmenu> lstUsurolmenu = new List<Usurolmenu>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_usurolmenu.umr_id, rol_id, men_id, umr_privilegios, umr_estado, " +
                          " rol_id, rol_cod, rol_titulo, rol_descripcion, rol_estado, " +
                          " men_id, men_par, men_titulo, men_enlace, men_posicion, men_imagen, " +
                          " men_estado " +
                          "FROM tab_usurolmenu, tab_rol, tab_menu " +
                          "WHERE tab_rol.rol_id='" + rol_id + "' AND tab_usurolmenu.rol_id = tab_rol.rol_id AND " +
                          "tab_usurolmenu.men_id = tab_menu.men_id AND tab_usurolmenu.urm.estado = 1 " +
                          "AND tab_rol.estado = 1, AND tab_menu.men_estado = 1 ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstUsurolmenu.Add(new Usurolmenu(
                       System.Convert.ToInt32(rs.Fields["urm_id"].Value),
                        new Rol(
                             System.Convert.ToInt32(rs.Fields["rol_id"].Value),
                             (string)rs.Fields["rol_cod"].Value,
                             (string)rs.Fields["rol_titulo"].Value,
                             (string)rs.Fields["rol_descripcion"].Value,
                             System.Convert.ToInt32(rs.Fields["rol_estado"].Value)),
                             new Menus(
                                 System.Convert.ToInt64(rs.Fields["men_id"].Value),
                                 System.Convert.ToInt64(rs.Fields["men_par"].Value),
                                 (string)rs.Fields["men_titulo"].Value,
                                 (string)rs.Fields["men_enlace"].Value,
                                 (string)rs.Fields["men_posicion"].Value,
                                 (string)rs.Fields["men_imagen"].Value,
                                 System.Convert.ToInt32(rs.Fields["men_estado"].Value)),
                        (string)rs.Fields["urm_privilegios"].Value,
                        System.Convert.ToInt32(rs.Fields["urm_estado"].Value)));
                    Connection_Off(1);
                    return lstUsurolmenu;
                }
                else
                {
                    Connection_Off(1);
                    return lstUsurolmenu;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsurolmenu;
            }
        }
        public List<Usurolmenu> listaUsuarioRolMenuPorRol(long rol_id)
        {
            string where = (rol_id != 0 ? ("AND rol_id = " + rol_id + "") : "");
            List<Usurolmenu> listaUsuarioRolMenu = new List<Usurolmenu>();
            try
            {
                SQL = "SELECT tab_usurolmenu.men_id, tab_menu.men_titulo ";
                SQL += "FROM tab_menu ";
                SQL += "INNER JOIN tab_usurolmenu ON tab_menu.men_id = tab_usurolmenu.men_id ";
                SQL += "WHERE urm_estado = 1 ";
                SQL += where;
                SQL += " ORDER BY 1";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Usurolmenu usuarioRolMenu = new Usurolmenu();
                    usuarioRolMenu.Men_id1 = new Menus();
                    usuarioRolMenu.Men_id1.Men_id = Convert.ToInt32(rs.Fields["men_id"].Value);
                    usuarioRolMenu.Men_id1.Men_titulo = Convert.ToString(rs.Fields["men_titulo"].Value);
                    listaUsuarioRolMenu.Add(usuarioRolMenu);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return listaUsuarioRolMenu;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return listaUsuarioRolMenu;
            }
        }
    }
}
