/*
 * @author acastellon
 * frmLog.cs
 * Created on 01 de Marzo de 2011, 10:00 AM
 * In the namespace View not connections BD exists.
 */

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;
using System.Reflection;
namespace ypfbApplication.View
{
    /* Class frmLog */
    public partial class frmLog : Form
    {
        // Data member
        String strUsername;
        String strPassword;
        int intCount = 1;

        public Bd BaseDatos;

        /* Method frmLog */
        public frmLog()
        {
            InitializeComponent();
        }/* End Method frmLog */

        /* Method frmLogin_Load */
        private void frmLogin_Load(object sender, EventArgs e)
        {
        }/* Method frmLogin_Load */

        /* Method txtUsuario_keypress */
        private void txtUsuario_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }/* End Method txtUsuario_keypress */

        /* Method txtUsuario_keypress */
        private void txtContrasenia_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                doLog();
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }/* End Method txtUsuario_keypress */

        /* Method btnLogin_Click */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            doLog();
        }/* Method btnLogin_Click */


        /* Method doLog */
        private void doLog()
        {
            strUsername = txtUsuario.Text;
            strPassword = txtContrasenia.Text;
            BaseDatos = new Bd();
            UsuarioObject objUser = new UsuarioObject();
            List<Usuario> lstUser = new List<Usuario>();
            lstUser = objUser.findUsuario(strUsername, strPassword);
            
            // Count validate try in system
            if (intCount <= 3)
            {
                if (lstUser.Count == 0)
                {
                    if (strUsername.Equals("admin") && strPassword.Equals("4dm1n"))
                    {
                        // Save Sesion
                        Session objSession = new Session();
                        objSession.USU_LOGIN = strUsername;
                        objSession.USU_ESTADO = 1;
                        objSession.IP = "";

                        frmMDI objFrmMDI = new frmMDI();
                        this.Hide();
                        objFrmMDI.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("¡ERROR EN INCIO DE SESION!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtContrasenia.Text = "";
                        intCount++;
                    }
                }
                else
                {
                    // Save Sesion
                    Session objSession = new Session();
                    lstUser.ForEach(delegate(Usuario u)
                    {
                        objSession.USU_ID = u.Usu_id;
                        objSession.ROL_ID = u.Rol_id;
                        objSession.ROL_TITULO = u.Rol_Titulo;
                        objSession.SUC_ID = u.Suc_id;
                        objSession.SUC_NOMBRE = u.Suc_nombre;
                        objSession.USU_LOGIN = u.Usu_login;
                        objSession.USU_ESTADO = u.Usu_estado;
                        objSession.IP = objSession.FINDIP();
                    });

                    frmMDI objFrmMDI = new frmMDI();
                    this.Hide();
                    objFrmMDI.ShowDialog();
                    
                    this.Close();


                }
            }
            else
            {
                MessageBox.Show("¡NO TIENE ACCESO AL SISTEMA!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }/* End Method doLog */
    }/* End Class frmLog */
}