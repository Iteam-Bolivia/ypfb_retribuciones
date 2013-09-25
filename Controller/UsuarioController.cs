/*
 * @author acastellon
 * User Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */
using System.Collections.Generic;
using Model;
using View;
using ypfbApplication.View;
using System;

namespace Controller
{
    public sealed class UsuarioController
    {
        public void index()
        {
            // Open List Usuario Form
            frmUsuarioLista objUsuarioLista = new frmUsuarioLista();
            objUsuarioLista.Show();
        }

        public List<Usuario> load()
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            UsuarioObject objUsuarioObject = new UsuarioObject();
            lstUsuario = objUsuarioObject.listUsuario(0);
            return lstUsuario;
        }

        public void view()
        {
        }

        public void create()
        {
        }

        public void edit()
        {
        }

        public void save(List<Usuario> lstUsuario, Bd bd)
        {
            // Save data from Usuario
            Usuario objUsuario = new Usuario();
            objUsuario.insert(lstUsuario);
        }

        public void update(List<Usuario> lstUsuario)
        {
            string condition = "";
            // Update data from Usuario
            Usuario objUsuario = new Usuario();
            if (lstUsuario.Count == 0)
            {
            }
            else
            {
                lstUsuario.ForEach(delegate(Usuario u)
                {
                    condition = "usu_id=" + u.Usu_id;
                });
            }
            objUsuario.update(lstUsuario);
        }

        public List<Usuario> find()
        {
            long usu_id = 0;
            Session objSession = new Session();
            usu_id = objSession.ID;
            List<Usuario> lstUsuario = new List<Usuario>();
            UsuarioObject objUsuarioObject = new UsuarioObject();
            lstUsuario = objUsuarioObject.listUsuario(usu_id);
            return lstUsuario;
        }

        public static List<Usuario> lstUsuariosByRol(int usu_id, int rol_id)
        {
            UsuarioObject objUsuario = new UsuarioObject();
            return objUsuario.listaUsuariosSegunRol(usu_id, rol_id);
        }
        public static Usuario GetNombreCompleto(int usu_id)
        {
            UsuarioObject objUsuario = new UsuarioObject();
            return objUsuario.NombreCompleto(usu_id);
        }
    }
}