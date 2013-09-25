using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmUsuario : Form
    {
        bool flag = false;
        bool flag1 = false;
        long usu_id = 0;
        long suc_id;
        long rol_id;
        string usu_pass = "";

        public frmUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmUsuario_Load
        /// </summary>
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /* View */
        /// <summary>
        /// Method txtfields1_KeyPress
        /// </summary>   
        private void txtfields1_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method txtfields2_KeyPress
        /// </summary>
        private void txtfields2_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method txtfields3_KeyPress
        /// </summary>
        private void txtfields3_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }


        /// <summary>
        /// Method txtfields4
        /// </summary>
        private void txtfields4_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method txtfields1_KeyPress
        /// </summary>
        private void txtfields5_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method txtfields6_KeyPress
        /// </summary>
        private void txtfields6_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method txtfields7_KeyPress
        /// </summary>
        private void txtfields7_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Method txtfields7_KeyPress
        /// </summary>
        private void txtfields7_TextChanged(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method cbofields1_KeyPress
        /// </summary>
        private void cbofields1_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method cbofields2_KeyPress
        /// </summary>
        private void cbofields2_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// Method btnGuardar_Click
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        /// <summary>
        /// Method btnCancelar_Click
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        /// Controller
        /// <summary>
        /// Method cargar
        /// </summary>
        private void cargar()
        {

            List<Sucursal> lstSucursal = new List<Sucursal>();
            SucursalObject objSucursalObject = new SucursalObject();
            lstSucursal = objSucursalObject.listSucursal(0);
            if (lstSucursal.Count == 0)
            {
                cbofields1.Items.Clear();
            }
            else
            {
                cbofields1.Items.Clear();
                cbofields1.DataSource = lstSucursal;
                cbofields1.DisplayMember = "suc_nombre";
                cbofields1.ValueMember = "suc_id";
                cbofields1.SelectedIndex = 0;
            }

            if (!flag1)
            {
                List<Rol> lstRol = new List<Rol>();
                RolObject objRolObject = new RolObject();
                lstRol = objRolObject.listRol(0);
                if (lstRol.Count == 0)
                {
                    cbofields2.Items.Clear();
                }
                else
                {
                    cbofields2.Items.Clear();
                    cbofields2.DataSource = lstRol;
                    cbofields2.DisplayMember = "rol_titulo";
                    cbofields2.ValueMember = "rol_id";
                    cbofields2.SelectedIndex = 0;
                    //cbofields2.SelectedIndex = 0;
                }
            }

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblcbofields1, "Escoger la Sucursal");
            toolTip1.SetToolTip(this.cbofields1, "Escoger la Sucursal");

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar los Nombres");
            toolTip1.SetToolTip(this.txtfields1, "Indicar los Nombres");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar los Apellidos");
            toolTip1.SetToolTip(this.txtfields2, "Indicar los Apellidos");
            toolTip1.SetToolTip(this.lbltxtfields3, "Indicar el Teléfono");
            toolTip1.SetToolTip(this.txtfields3, "Indicar el Teléfono");
            toolTip1.SetToolTip(this.lbltxtfields4, "Indicar el Email");
            toolTip1.SetToolTip(this.txtfields4, "Indicar el Email");

            toolTip1.SetToolTip(this.lblcbofields2, "Indicar el Rol");
            toolTip1.SetToolTip(this.cbofields2, "Indicar el Rol");

            toolTip1.SetToolTip(this.lbltxtfields5, "Indicar el Inicio de Sesión");
            toolTip1.SetToolTip(this.txtfields5, "Indicar el Inicio de Sesión");
            toolTip1.SetToolTip(this.lbltxtfields6, "Indicar la Contraseña");
            toolTip1.SetToolTip(this.txtfields6, "Indicar la Contraseña");
            toolTip1.SetToolTip(this.lbltxtfields7, "Vuelva a escribir la Contraseña");
            toolTip1.SetToolTip(this.txtfields7, "Vuelva a escribir la Contraseña");
        }

        /// <summary>
        /// Method nuevo
        /// </summary>
        public void nuevo()
        {
            txtfields1.Text = "";
            txtfields2.Text = "";
            txtfields3.Text = "";
            txtfields4.Text = "";
            txtfields5.Text = "";
            txtfields6.Text = "";
            txtfields7.Text = "";

            List<Sucursal> lstSucursal = new List<Sucursal>();
            SucursalObject objSucursalObject = new SucursalObject();
            lstSucursal = objSucursalObject.listSucursal(0);
            if (lstSucursal.Count == 0)
            {
                cbofields1.Items.Clear();
            }
            else
            {
                cbofields1.Items.Clear();
                cbofields1.DataSource = lstSucursal;
                cbofields1.DisplayMember = "suc_nombre";
                cbofields1.ValueMember = "suc_id";
                cbofields1.SelectedIndex = 0;
            }

            List<Rol> lstRol = new List<Rol>();
            RolObject objRolObject = new RolObject();
            lstRol = objRolObject.listRol(0);
            if (lstRol.Count == 0)
            {
                cbofields2.Items.Clear();
            }
            else
            {
                cbofields2.Items.Clear();
                cbofields2.DataSource = lstRol;
                cbofields2.DisplayMember = "rol_titulo";
                cbofields2.ValueMember = "rol_id";
                cbofields2.SelectedIndex = 0;
                cbofields2.SelectedIndex = 0;
            }

        }


        /// <summary>
        /// Method buscar
        /// </summary>
        public void buscar()
        {
            flag1 = true;
            Session objSession = new Session();
            usu_id = objSession.ID;

            List<Rol> lstRol = new List<Rol>();
            RolObject objRolObject = new RolObject();
            lstRol = objRolObject.listRol(0);
            if (lstRol.Count == 0)
            {
                cbofields2.Items.Clear();
            }
            else
            {
                cbofields2.Items.Clear();
                cbofields2.DataSource = lstRol;
                cbofields2.DisplayMember = "rol_titulo";
                cbofields2.ValueMember = "rol_id";
                cbofields2.SelectedIndex = 0;
            }

            List<Usuario> lstUsuario = new List<Usuario>();
            UsuarioObject objUsuarioObject = new UsuarioObject();
            lstUsuario = objUsuarioObject.listUsuario(usu_id);
            if (lstUsuario.Count != 0)
            {
                lstUsuario.ForEach(delegate(Usuario u)
                {
                    txtfields1.Text = u.Usu_nombres;
                    txtfields2.Text = u.Usu_apellidos;
                    txtfields3.Text = u.Usu_fono;
                    txtfields4.Text = u.Usu_email;
                    txtfields5.Text = u.Usu_login;
                    cbofields2.Text = u.Rol_Titulo;
                    usu_pass = u.Usu_pass;
                    //txtfields7.Text = u.Usu_pass;
                    int index = cbofields1.FindString(u.Suc_nombre, -1);
                    cbofields1.SelectedIndex = index; //cboSucursal.FindString(p.nombre, -1);
                    //cbofields2.SelectedIndex = cbofields2.FindString(u.Rol_Titulo, -1);          

                });
                flag = true;
            }
        }

        /// <summary>
        /// Method validarCampos
        /// </summary>
        private bool validarCampos()
        {
            bool flag2 = false;
            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre los Nombres del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag2;
            }
            if (txtfields2.Text == "")
            {
                MessageBox.Show("Registre los Apellidos del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag2;
            }
            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre el Teléfono del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag2;
            }
            if (txtfields4.Text == "")
            {
                MessageBox.Show("Registre el Email del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields4.Focus();
                return flag2;
            }
            if (txtfields5.Text == "")
            {
                MessageBox.Show("Registre el Inicio de Sesión", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields5.Focus();
                return flag2;
            }

            if (flag != true)
            {
                if (txtfields6.Text == "")
                {
                    MessageBox.Show("Registre el Password del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtfields6.Focus();
                    return flag2;
                }
                if (txtfields7.Text == "")
                {
                    MessageBox.Show("Vuelva a escribir el Password del Usuario", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtfields7.Focus();
                    return flag2;
                }
            }
            if (txtfields7.Text != txtfields6.Text)
            {
                MessageBox.Show("La contraseñas deben ser iguales", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields7.Focus();
                return flag2;
            }

            var v_suc_id = cbofields1.SelectedValue;
            var v_rol_id = cbofields2.SelectedValue;

            suc_id = System.Convert.ToInt64(v_suc_id);
            rol_id = System.Convert.ToInt64(v_rol_id);


            flag2 = true;
            return flag2;
        }


        /// <summary>
        /// Method guardar
        /// </summary>
        private void guardar()
        {
            long inserted = 0;

            if (validarCampos())
            {
                if (flag == true)
                {
                    switch (MessageBox.Show("Actualizar registro?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            // Fill data      
                            List<Usuario> lstUsuario = new List<Usuario>();
                            Usuario usuario = new Usuario();
                            usuario.Usu_id = System.Convert.ToInt64(usu_id);
                            usuario.Suc_id = System.Convert.ToInt64(suc_id);
                            usuario.Rol_id = System.Convert.ToInt64(rol_id);
                            usuario.Usu_nombres = System.Convert.ToString(txtfields1.Text);
                            usuario.Usu_apellidos = System.Convert.ToString(txtfields2.Text);
                            usuario.Usu_iniciales = System.Convert.ToString("AA");
                            usuario.Usu_fono = System.Convert.ToString(txtfields3.Text);
                            usuario.Usu_email = System.Convert.ToString(txtfields4.Text);
                            usuario.Usu_login = System.Convert.ToString(txtfields5.Text);
                            if (txtfields6.Text != "")
                            {
                                UsuarioObject objUsuarioObject = new UsuarioObject();
                                usuario.Usu_pass = System.Convert.ToString(objUsuarioObject.generateMD5(txtfields6.Text));
                            }
                            else
                            {
                                //UsuarioObject objUsuarioObject = new UsuarioObject();
                                usuario.Usu_pass = System.Convert.ToString(usu_pass);
                            }

                            usuario.Usu_intento = System.Convert.ToInt64(0);
                            usuario.Usu_estado = System.Convert.ToInt64(1);
                            lstUsuario.Add(usuario);

                            // Save data from Usuario
                            Usuario objUsuario = new Usuario();
                            inserted = objUsuario.update(lstUsuario);
                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            flag = false;

                            break;
                        case DialogResult.No:
                            // "No" processing
                            break;
                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                }
                else
                {
                    switch (MessageBox.Show("Grabar registro?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:

                            // Fill data      
                            List<Usuario> lstUsuario = new List<Usuario>();
                            Usuario usuario = new Usuario();
                            usuario.Usu_id = System.Convert.ToInt64(0);
                            usuario.Suc_id = System.Convert.ToInt64(suc_id);
                            usuario.Rol_id = System.Convert.ToInt64(rol_id);
                            usuario.Usu_nombres = System.Convert.ToString(txtfields1.Text);
                            usuario.Usu_apellidos = System.Convert.ToString(txtfields2.Text);
                            usuario.Usu_iniciales = System.Convert.ToString("AA");
                            usuario.Usu_fono = System.Convert.ToString(txtfields3.Text);
                            usuario.Usu_email = System.Convert.ToString(txtfields4.Text);
                            usuario.Usu_login = System.Convert.ToString(txtfields5.Text);
                            UsuarioObject objUsuarioObject = new UsuarioObject();
                            usuario.Usu_pass = System.Convert.ToString(objUsuarioObject.generateMD5(txtfields6.Text));
                            usuario.Usu_intento = System.Convert.ToInt64(0);
                            usuario.Usu_estado = System.Convert.ToInt64(1);
                            lstUsuario.Add(usuario);

                            // Save data from Usuario
                            Usuario objUsuario = new Usuario();
                            inserted = objUsuario.insert(lstUsuario);
                            if (inserted == 0)
                            {
                                MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }

                            break;

                        case DialogResult.No:
                            // "No" processing
                            break;

                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                }
            }
            else
            {
            }
        }



    }
}