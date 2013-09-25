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
    public partial class frmTablaValores : Form
    {
        bool flagValidacion;
        long tva_id = 0;
        public frmTablaValores()
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
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46)
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
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        #endregion
        #region Metodos Controller()
        public void Buscar()
        {
            tva_id = frmTablaValoresLista.tva_id1;

            List<Tabla_Valores> lstTablaValores = new List<Tabla_Valores>();
            lstTablaValores = TablaValoresController.GetListaTablaValores(tva_id);
            if (lstTablaValores.Count != 0)
            {
                lstTablaValores.ForEach(delegate(Tabla_Valores tv)
                {
                    txtfields1.Text = tv.Tab_valcolumna;
                    txtfields2.Text = tv.Tva_valor;
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

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Número de Columna");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Valor de la Columna");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Número de Columna");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Valor de la Columna");
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
                MessageBox.Show(this, "Registre la Columna", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el valor de la Columna", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            return flag = true;
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Tabla_Valores> lstTablaValores = new List<Tabla_Valores>();
                        //lstTablaValores.Add(new Tabla_Valores(tva_id, frmTablaLista.tab_id1, txtfields1.Text.Trim().Replace(",", "."), txtfields2.Text.Trim().Replace(",", "."), 1));
                        Tabla_Valores tablaValores = new Tabla_Valores();
                        accion = tablaValores.update(lstTablaValores);
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
                        List<Tabla_Valores> lstTablaValores = new List<Tabla_Valores>();
                        //lstTablaValores.Add(new Tabla_Valores(0, frmTablaLista.tab_id1, txtfields1.Text.Trim().Replace(",", "."), txtfields2.Text.Trim().Replace(",", "."), 1));
                        Tabla_Valores tablaValores = new Tabla_Valores();
                        accion = tablaValores.insert(lstTablaValores);
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
        #endregion
    }
}