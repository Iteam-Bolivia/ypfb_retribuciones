using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmCalculoProyeccionVariable : Form
    {


        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };

        public frmCalculoProyeccionVariable()
        {
            InitializeComponent();
        }

        private void frmCalculoProyeccionVariable_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /// <summary>
        /// Method txtfields3_KeyPress
        /// </summary>
        private void txtValue_KeyPress(object sender,
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








        private void cargar()
        {


            // Tipo de Cálculo
            List<Variable> lstVariable = new List<Variable>();
            VariableController objVariableController = new VariableController();
            lstVariable = objVariableController.findByTcl_id(2);
            if (lstVariable.Count == 0)
            {
                cbofields1.Items.Clear();
            }
            else
            {
                cbofields1.Items.Clear();
                cbofields1.DataSource = lstVariable;
                cbofields1.DisplayMember = "var_codigo";
                cbofields1.ValueMember = "var_id";
                cbofields1.SelectedIndex = 0;
            }

            // Meses
            foreach (string mes in MESES)
            {
                cbxMes.Items.Add(mes);
            }
            cbxMes.SelectedIndex = 0;

            // Meses
            foreach (string mes in MESES)
            {
                cbxMes2.Items.Add(mes);
            }
            cbxMes2.SelectedIndex = 0;


            //foreach (int anio in ANIOS)
            //{
            //    cbxAnio.Items.Add(anio);
            //}
            //cbxAnio.SelectedIndex = 0;

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTasa_Click(object sender, EventArgs e)
        {

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Session objSession = new Session();
            objSession.VAR_ID = cbofields1.SelectedIndex;
            objSession.VAR_VALOR = System.Convert.ToDecimal(txtValue.Text);
        }
    }
}
