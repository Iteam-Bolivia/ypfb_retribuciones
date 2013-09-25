/*
 * @author acastellon
 * UsuarioObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Model
{
    public class UsuarioObject : Usuario
    {
        /// <summary>
        /// existUsuario Method
        /// </summary>
        public bool existUsuario(String usu_login, String usu_pass)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "usu_id " +
                      "FROM tab_usuario " +
                      "WHERE usu_login='" + usu_login + "' AND usu_pass='" + usu_pass + "' ";

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
                rs.Close();
                Connection_Off(1);
                return flag;
            }
            catch (COMException err)
            {
                rs.Close();
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }

        /// <summary>
        /// findUsuario Method
        /// </summary>
        public List<Usuario> findUsuario(String usu_login, String usu_pass)
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_usuario.usu_id, " +
                      "tab_usuario.suc_id, " +
                      "tab_sucursal.suc_nombre, " +
                      "tab_usuario.usu_nombres, " +
                      "tab_usuario.usu_apellidos, " +
                      "tab_usuario.usu_fono, " +
                      "tab_usuario.usu_email, " +
                      "tab_usuario.usu_login, " +
                      "tab_rol.rol_id, " +
                      "tab_rol.rol_titulo, " +
                      "tab_usuario.usu_estado " +
                      "FROM " +
                      "tab_usuario " +
                      "Inner Join tab_rol ON tab_rol.rol_id = tab_usuario.rol_id " +
                      "Inner Join tab_sucursal ON tab_sucursal.suc_id = tab_usuario.suc_id " +
                      "WHERE tab_usuario.usu_estado = 1 AND tab_usuario.usu_login='" + usu_login + "' AND tab_usuario.usu_pass='" + this.generateMD5(usu_pass) + "' ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, 1);
                if (!rs.EOF)
                {
                    Usuario usuario = new Usuario();
                    usuario.Usu_id = System.Convert.ToInt64(rs.Fields["usu_id"].Value);
                    usuario.Suc_id = Convert.ToInt64(rs.Fields["suc_id"].Value);
                    usuario.Suc_nombre = System.Convert.ToString(rs.Fields["suc_nombre"].Value);
                    usuario.Usu_nombres = System.Convert.ToString(rs.Fields["usu_nombres"].Value);
                    usuario.Usu_apellidos = System.Convert.ToString(rs.Fields["usu_apellidos"].Value);
                    usuario.Usu_fono = System.Convert.ToString(rs.Fields["usu_fono"].Value);
                    usuario.Usu_email = System.Convert.ToString(rs.Fields["usu_email"].Value);
                    usuario.Usu_login = System.Convert.ToString(rs.Fields["usu_login"].Value);
                    usuario.Rol_id = System.Convert.ToInt64(rs.Fields["rol_id"].Value);
                    usuario.Rol_Titulo = System.Convert.ToString(rs.Fields["rol_titulo"].Value);
                    usuario.Usu_estado = System.Convert.ToInt64(rs.Fields["usu_estado"].Value);
                    lstUsuario.Add(usuario);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstUsuario;
                }
                else
                {
                    Connection_Off(1);
                    return lstUsuario;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsuario;
            }
        }


        /// <summary>
        /// listUsuario Method
        /// </summary>
        public List<Usuario> listUsuario(long usu_id)
        {
            String where = (usu_id != 0 ? ("AND usu_id=" + usu_id + " ") : " ");
            List<Usuario> lstUsuario = new List<Usuario>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_usuario.usu_id, " +
                      "tab_sucursal.suc_id, " +
                      "tab_sucursal.suc_nombre, " +
                      "tab_usuario.usu_nombres, " +
                      "tab_usuario.usu_apellidos, " +
                      "tab_usuario.usu_fono, " +
                      "tab_usuario.usu_email, " +
                      "tab_usuario.usu_login, " +
                      "tab_usuario.usu_pass, " +
                      "tab_rol.rol_id, " +
                      "tab_rol.rol_titulo, " +
                      "tab_usuario.usu_estado " +
                      "FROM " +
                      "tab_usuario " +
                      "Inner Join tab_rol ON tab_rol.rol_id = tab_usuario.rol_id " +
                      "Inner Join tab_sucursal ON tab_sucursal.suc_id = tab_usuario.suc_id " +
                      "WHERE tab_usuario.usu_estado = 1 " +
                      where +
                      " ORDER BY tab_usuario.usu_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Usuario usuario = new Usuario();
                    usuario.Usu_id = System.Convert.ToInt64(rs.Fields["usu_id"].Value);
                    usuario.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    usuario.Suc_nombre = System.Convert.ToString(rs.Fields["suc_nombre"].Value);
                    usuario.Usu_nombres = System.Convert.ToString(rs.Fields["usu_nombres"].Value);
                    usuario.Usu_apellidos = System.Convert.ToString(rs.Fields["usu_apellidos"].Value);
                    usuario.Usu_fono = System.Convert.ToString(rs.Fields["usu_fono"].Value);
                    usuario.Usu_email = System.Convert.ToString(rs.Fields["usu_email"].Value);
                    usuario.Usu_login = System.Convert.ToString(rs.Fields["usu_login"].Value);
                    usuario.Usu_pass = System.Convert.ToString(rs.Fields["usu_pass"].Value);
                    usuario.Rol_id = System.Convert.ToInt64(rs.Fields["rol_id"].Value);
                    usuario.Rol_Titulo = System.Convert.ToString(rs.Fields["rol_titulo"].Value);
                    usuario.Usu_estado = System.Convert.ToInt64(rs.Fields["usu_estado"].Value);
                    lstUsuario.Add(usuario);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstUsuario;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsuario;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        /// <summary>
        /// generateMD5 Method
        /// </summary>
        public string generateMD5(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string usu_pass = s.ToString();
            return usu_pass;
        }

        public List<Usuario> listaUsuariosSegunRol(int usu_id, int rol_id)
        {
            String where = (usu_id != 0 ? ("AND usu_id = " + usu_id + " ") : " ");
            where += (rol_id != 0 ? ("AND tab_rol.rol_id = " + rol_id + " ") : " "); ;
            List<Usuario> lstUsuario = new List<Usuario>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_usuario.usu_id, " +
                      "tab_sucursal.suc_id, " +
                      "tab_sucursal.suc_nombre, " +
                      "tab_usuario.usu_nombres, " +
                      "tab_usuario.usu_apellidos, " +
                      "(TRIM(tab_usuario.usu_nombres) || ' ' || TRIM(tab_usuario.usu_apellidos)) AS nombre_completo, "+
                      "tab_usuario.usu_fono, " +
                      "tab_usuario.usu_email, " +
                      "tab_usuario.usu_login, " +
                      "tab_usuario.usu_pass, " +
                      "tab_rol.rol_id, " +
                      "tab_rol.rol_titulo, " +
                      "tab_usuario.usu_estado " +
                      "FROM " +
                      "tab_usuario " +
                      "Inner Join tab_rol ON tab_rol.rol_id = tab_usuario.rol_id " +
                      "Inner Join tab_sucursal ON tab_sucursal.suc_id = tab_usuario.suc_id " +
                      "WHERE tab_usuario.usu_estado = 1 " +
                      where +                      
                      " ORDER BY tab_usuario.usu_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Usuario usuario = new Usuario();
                    usuario.Usu_id = System.Convert.ToInt64(rs.Fields["usu_id"].Value);
                    usuario.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    usuario.Suc_nombre = System.Convert.ToString(rs.Fields["suc_nombre"].Value);
                    usuario.Usu_nombres = System.Convert.ToString(rs.Fields["usu_nombres"].Value);
                    usuario.Usu_apellidos = System.Convert.ToString(rs.Fields["usu_apellidos"].Value);
                    usuario.Usu_fono = System.Convert.ToString(rs.Fields["usu_fono"].Value);
                    usuario.Usu_email = System.Convert.ToString(rs.Fields["usu_email"].Value);
                    usuario.Usu_login = System.Convert.ToString(rs.Fields["usu_login"].Value);
                    usuario.Usu_pass = System.Convert.ToString(rs.Fields["usu_pass"].Value);
                    usuario.Rol_id = System.Convert.ToInt64(rs.Fields["rol_id"].Value);
                    usuario.Rol_Titulo = System.Convert.ToString(rs.Fields["rol_titulo"].Value);
                    usuario.Usu_estado = System.Convert.ToInt64(rs.Fields["usu_estado"].Value);
                    usuario.Nombre_Completo = Convert.ToString(rs.Fields["nombre_completo"].Value);
                    lstUsuario.Add(usuario);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstUsuario;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstUsuario;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public Usuario NombreCompleto(int usu_id)
        {
            Usuario usuario = null;
            try
            {
                Connection_On();
                SQL = "SELECT (TRIM(usu_nombres) || ' ' || TRIM(usu_apellidos)) AS nombre_completo ";
                SQL += "FROM tab_usuario ";
                SQL += "WHERE usu_id = " + usu_id;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    usuario = new Usuario();
                    usuario.Nombre_Completo = Convert.ToString(rs.Fields["nombre_completo"].Value);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return usuario;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return usuario;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}