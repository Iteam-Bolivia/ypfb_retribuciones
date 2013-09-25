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

namespace ypfbApplication.View
{
    public partial class frmMoneda : Form
    {
        bool flagValidacion;
        long mon_id;
        public frmMoneda()
        {
            InitializeComponent();
            Cargar();
        }
        #region Eventos Pagina
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Guardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtfields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private void txtfields2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
        #region Metodos Controller
        public void Buscar()
        {
            mon_id = frmMonedaLista.mon_id1;

            List<Moneda> lstMoneda = new List<Moneda>();
            lstMoneda = MonedaController.GetListMonedas(mon_id);
            if (lstMoneda.Count != 0)
            {
                lstMoneda.ForEach(delegate(Moneda m)
                {
                    txtfields1.Text = m.Mon_codigo;
                    txtfields2.Text = m.Mon_nombre;
                });
                flagValidacion = true;
            }
            else
            {
                flagValidacion = false;
            }
        }
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código de la Moneda");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre de la Moneda");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Código de la Moneda");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre de la Moneda");
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Moneda> lstMoneda = new List<Moneda>();
                        lstMoneda.Add(new Moneda(mon_id, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        Moneda moneda = new Moneda();
                        accion = moneda.update(lstMoneda);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else//Registrar
            {
                switch (MessageBox.Show("Grabar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Moneda> lstMoneda = new List<Moneda>();
                        lstMoneda.Add(new Moneda(0, txtfields1.Text.Trim().ToUpper(), txtfields2.Text.Trim().ToUpper(), 1));
                        Moneda moneda = new Moneda();
                        accion = moneda.insert(lstMoneda);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
                MessageBox.Show(this, "Registre el Código de la Moneda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre de la Moneda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion
    }
}