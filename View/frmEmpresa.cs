using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmEmpresa : Form
    {
        bool flag = false;
        long emp_id = 0;

        public frmEmpresa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmEmpresa_Load
        /// </summary>
        private void frmEmpresa_Load(object sender, EventArgs e)
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
            e.KeyChar = Char.ToUpper(e.KeyChar);
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
            e.KeyChar = Char.ToUpper(e.KeyChar);
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
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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

        ///// <summary>
        ///// Method txtfields7_KeyPress
        ///// </summary>
        //private void txtfields7_KeyPress(object sender,
        //                    System.Windows.Forms.KeyPressEventArgs e)
        //{
        //  if (e.KeyChar == 13)
        //  {
        //    e.Handled = true;
        //    SendKeys.Send("{TAB}");
        //  }
        //}


        /// <summary>
        /// Method txtfields7_KeyPress
        /// </summary>
        //private void txtfields7_TextChanged(object sender,
        //                    System.Windows.Forms.KeyPressEventArgs e)
        //{
        //  if (e.KeyChar == 13)
        //  {
        //    e.Handled = true;
        //    SendKeys.Send("{TAB}");
        //  }
        //}

        ///// <summary>
        ///// Method cbofields1_KeyPress
        ///// </summary>
        //private void cbofields1_KeyPress(object sender,
        //                    System.Windows.Forms.KeyPressEventArgs e)
        //{
        //  if (e.KeyChar == 13)
        //  {
        //    e.Handled = true;
        //    SendKeys.Send("{TAB}");
        //  }
        //}

        ///// <summary>
        ///// Method cbofields2_KeyPress
        ///// </summary>
        //private void cbofields2_KeyPress(object sender,
        //                    System.Windows.Forms.KeyPressEventArgs e)
        //{
        //  if (e.KeyChar == 13)
        //  {
        //    e.Handled = true;
        //    SendKeys.Send("{TAB}");
        //  }
        //}

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

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar NIT");
            toolTip1.SetToolTip(this.txtfields1, "Indicar NIT");

            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar nombre de la empresa");
            toolTip1.SetToolTip(this.txtfields2, "Indicar nombre de la empresa");

            toolTip1.SetToolTip(this.lbltxtfields3, "Indicar propietario");
            toolTip1.SetToolTip(this.txtfields3, "Indicar propietario");

            toolTip1.SetToolTip(this.lbltxtfields4, "Indicar dirección");
            toolTip1.SetToolTip(this.txtfields4, "Indicar dirección");

            toolTip1.SetToolTip(this.lbltxtfields5, "Indicar teléfono");
            toolTip1.SetToolTip(this.txtfields5, "Indicar teléfono");

            toolTip1.SetToolTip(this.lbltxtfields6, "Indicar email");
            toolTip1.SetToolTip(this.txtfields6, "Indicar email");


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

        }


        /// <summary>
        /// Method buscar
        /// </summary>
        public void buscar()
        {
            Session objSession = new Session();
            emp_id = objSession.ID;

            List<Empresa> lstEmpresa = new List<Empresa>();
            EmpresaObject objEmpresaObject = new EmpresaObject();
            lstEmpresa = objEmpresaObject.listEmpresa(emp_id);
            if (lstEmpresa.Count != 0)
            {
                lstEmpresa.ForEach(delegate(Empresa u)
                {
                    txtfields1.Text = u.Emp_nit;
                    txtfields2.Text = u.Emp_nombre;
                    txtfields3.Text = u.Emp_propietario;
                    txtfields4.Text = u.Emp_dir;
                    txtfields5.Text = u.Emp_telefono;
                    txtfields6.Text = u.Emp_email;

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
                MessageBox.Show("Registre el NIT de la Empresa", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag2;
            }
            if (txtfields2.Text == "")
            {
                MessageBox.Show("Registre el nombre de la Empresa", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag2;
            }
            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre el propietario de la Empresa", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag2;
            }
            if (txtfields4.Text == "")
            {
                MessageBox.Show("Registre la direccion de la Empresa", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields4.Focus();
                return flag2;
            }
            if (txtfields5.Text == "")
            {
                MessageBox.Show("Registre el teléfono de la Empresa", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields5.Focus();
                return flag2;
            }
            if (txtfields6.Text == "")
            {
                MessageBox.Show("Registre un email", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields6.Focus();
                return flag2;
            }

            if (flag != true)
            {
                EmpresaObject objEmpresaObject = new EmpresaObject();
                emp_id = objEmpresaObject.generateIdEmpresa();
            }

            flag2 = true;
            return flag2;
        }


        /// <summary>
        /// Method guardar
        /// </summary>
        private void guardar()
        {
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
                            //List<Empresa> lstproyecto = new List<Empresa>();
                            //lstproyecto.Add(new Empresa(0, idproyecto, codigoproyecto, txtNombreProyecto.Text, idinstitucion, idgrupoproyecto, txtRemitente.Text, txtCite.Text, fechanota, idempresa, fecharegistro, idestadoproyecto, idempresaresponsable, idtipoproyecto, activo, "", "0", txtHojaRuta.Text, int.Parse(txtPoblacionReferencial.Text), decimal.Parse(txtMontoReferencial.Text), txtResultadoReferencial.Text, id_comu, tipocambio));
                            //EmpresaController objEmpresaController = new EmpresaController();
                            //objEmpresaController.update(lstproyecto);

                            MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            flag = false;
                            this.Close();
                            //doNew();

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
                            // Save Empresa
                            Empresa empresa = new Empresa();
                            empresa.Emp_id = 1;
                            empresa.Emp_nit = "";
                            empresa.Emp_nombre = "";
                            empresa.Emp_propietario = "";
                            empresa.Emp_dir = "";
                            empresa.Emp_telefono = "";
                            empresa.Emp_email = "";
                            empresa.Emp_estado = 1;

                            //List<Empresa> lstproyecto = new List<Empresa>();
                            //lstproyecto.Add(new Empresa(0, suc_id, rol_id, txtfields1.Text, txtfields2.Text, "AA", txtfields3.Text, txtfields4.Text, txtfields5.Text, txtfields6.Text, 0,  1));
                            //EmpresaController objEmpresaController = new EmpresaController();
                            //objEmpresaController.save(lstproyecto);
                            //MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
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

        private void frmEmpresa_Load_1(object sender, EventArgs e)
        {

        }

        private void txtfields5_TextChanged(object sender, EventArgs e)
        {

        }



    }
}