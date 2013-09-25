using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmCalculoBusqueda : Form
    {
        public static int flagBusqueda = 0;
        public static List<Calculo> listaCalculos;
        
        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };

        public frmCalculoBusqueda()
        {
            InitializeComponent();
        }

        private void txt_tipocalculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32 || Convert.ToInt32(e.KeyChar) == 45)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txt_nombrecontrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32 || Convert.ToInt32(e.KeyChar) == 45)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void cbo_anio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbo_mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar = Char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            else
                Buscar(out listaCalculos);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaCalculos = null;
            flagBusqueda = 0;
            this.Close();
        }


        #region Metodos Controller
        public bool Buscar(out List<Calculo> listaCalculos)
        {
            string var1 = txt_tipocalculo.Text;
            string var2 = txt_nombrecontrato.Text;
            long var3 = 0;
            long var4=0;
            if (!string.IsNullOrEmpty(cbo_anio.Text))
                var3 = Convert.ToInt64(cbo_anio.Text);
            if (cbo_mes.SelectedIndex != -1)
                var4 = cbo_mes.SelectedIndex + 1;


            CalculoController objCalculoController = new CalculoController();

            listaCalculos = objCalculoController.GetListCalculosSegunCriterio(Convert.ToString(txt_tipocalculo.Text), var3, var4, Convert.ToString(txt_nombrecontrato.Text));
            
            if (listaCalculos.Count == 0)
            {
                flagBusqueda = 0;
                MessageBox.Show(this, "No se encontraron datos según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                flagBusqueda = 1;
                this.Close();
                return true;
            }
        }

        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txt_tipocalculo.Text) && string.IsNullOrWhiteSpace(txt_nombrecontrato.Text) && cbo_mes.Text=="" && cbo_anio.Text=="")
            {
                MessageBox.Show(this, "Introdusca valores para realizar la búsqueda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tipocalculo.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion

        private void frmCalculoBusqueda_Load(object sender, EventArgs e)
        {
            Cargar();   
        }

        private void Cargar()
        {

            
            foreach (int anio in ANIOS)
                cbo_anio.Items.Add(anio);
            //cbo_anio.Text = DateTime.Today.Year.ToString();

            foreach (string mes in MESES)
            cbo_mes.Items.Add(mes);
            //cbo_mes.SelectedIndex = 0;
            
            
        }
    }
}
