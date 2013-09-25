using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class PaginaObject:Pagina
    {

        public bool existMercado(long pag_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT pag_id FROM tab_pagina WHERE pag_id='" + pag_id + "'";

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

        /// <summary>
        /// listPagina Method
        /// </summary>
        public List<Pagina> listPagina(long pag_id)
        {
            String where = (pag_id != 0 ? ("AND pag_id=" + pag_id + "") : "");
            List<Pagina> lstPagina = new List<Pagina>();

            try
            {
                Connection_On();
                SQL = "SELECT pag_id, men_id, pag_nombre, pag_estado " +
                          "FROM tab_pagina " +
                          "WHERE pag_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    //// Fill data List
                    lstPagina.Add(new Pagina(
                        System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                        (string)rs.Fields["pag_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    //// Fill data List
                    //lstPagina.Add(new Pagina(
                    //    System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                    //    System.Convert.ToInt32(rs.Fields["men_id"].Value),
                    //    (string)rs.Fields["pag_nombre"].Value,
                    //    System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstPagina;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstPagina;
            }
        }/* Method listMenu */


        /// <summary>
        /// listPagina Method
        /// </summary>
        public List<Pagina> listPaginaMenu(long pag_id)
        {
            String where = (pag_id != 0 ? ("AND pag_id=" + pag_id + "") : "");
            List<Pagina> lstPagina = new List<Pagina>();

            try
            {
                Connection_On();
                SQL = "SELECT pag_id, men_id, pag_nombre, pag_estado, men_id, men_par, men_titulo, men_enlace, " +
                          "men_posicion, men_imagen, men_estado " +
                          "FROM tab_pagina, tab_menu " +
                          "WHERE pag_estado = 1 AND men_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    //// Fill data List
                    lstPagina.Add(new Pagina(
                        System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                        (string)rs.Fields["pag_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    //// Fill data List
                    //lstPagina.Add(new Pagina(
                    //    System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                    //    System.Convert.ToInt32(rs.Fields["men_id"].Value),
                    //    (string)rs.Fields["pag_nombre"].Value,
                    //    System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstPagina;
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstPagina;
            }
        }/* Method listMenu */


        /// <summary>
        /// findPagina
        /// </summary>
        public List<Pagina> findPagina(long pag_id)
        {
            List<Pagina> lstPagina = new List<Pagina>();
            try
            {
                Connection_On();
                SQL = "SELECT pag_id, men_id, pag_nombre, pag_estado, men_id, men_par, men_titulo, men_enlace, " +
                          "men_posicion, men_imagen, men_estado " +
                          "FROM tab_pagina, tab_menu " +
                          "WHERE pag_id='" + pag_id + "' AND pag_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstPagina.Add(new Pagina(
                        System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                        new Menus(System.Convert.ToInt32(rs.Fields["men_id"].Value),
                            System.Convert.ToInt32(rs.Fields["men_par"].Value),
                            (string)rs.Fields["men_titulo"].Value,
                            (string)rs.Fields["men_enlace"].Value,
                            (string)rs.Fields["men_posicion"].Value,
                            (string)rs.Fields["men_imagen"].Value,
                            System.Convert.ToInt32(rs.Fields["men_estado"].Value)),
                        (string)rs.Fields["pag_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    Connection_Off(1);
                    return lstPagina;
                }
                else
                {
                    Connection_Off(1);
                    return lstPagina;
                }
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstPagina;
            }
        }


        /// <summary>
        /// findPagina
        /// </summary>
        public List<Pagina> findPaginaMenu(long pag_id)
        {
            List<Pagina> lstPagina = new List<Pagina>();
            try
            {
                Connection_On();
                SQL = "SELECT pag_id, men_id, pag_nombre, pag_estado " +
                          "FROM tab_pagina " +
                          "WHERE pag_id='" + pag_id + "' AND pag_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    lstPagina.Add(new Pagina(
                        System.Convert.ToInt64(rs.Fields["pag_id"].Value),
                        new Menus(System.Convert.ToInt32(rs.Fields["men_id"].Value),
                            System.Convert.ToInt32(rs.Fields["men_par"].Value),
                            (string)rs.Fields["men_titulo"].Value,
                            (string)rs.Fields["men_enlace"].Value,
                            (string)rs.Fields["men_posicion"].Value,
                            (string)rs.Fields["men_imagen"].Value,
                            System.Convert.ToInt32(rs.Fields["men_estado"].Value)),
                        (string)rs.Fields["pag_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["pag_estado"].Value)));
                    Connection_Off(1);
                    return lstPagina;
                }
                else
                {
                    Connection_Off(1);
                    return lstPagina;
                }
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstPagina;
            }
        }
    }
}
