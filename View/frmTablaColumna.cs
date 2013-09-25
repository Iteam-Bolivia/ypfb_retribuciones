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
    public partial class frmTablaColumna : Form
    {
        
        bool flagValidacion;
        long tac_id = 0;
        long tab_id = 0;

        public frmTablaColumna()
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
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
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
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        #endregion
        #region Metodos Controller()
        public void Buscar()
        {
            tac_id = frmTablaColumnaLista.tac_id1;

            List<Tabla_Columna> lstTablaValores = new List<Tabla_Columna>();
            lstTablaValores = TablaColumnaController.GetListaTablaColumna(tac_id);
            if (lstTablaValores.Count != 0)
            {
                lstTablaValores.ForEach(delegate(Tabla_Columna tc)
                {
                    txtfields1.Text = System.Convert.ToString(tc.Tac_valcolumna);
                    txtfields2.Text = System.Convert.ToString(tc.Tac_valor);
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
            Session objSession = new Session();
            tab_id = objSession.ID;
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
            else
            {
              if ((txtfields1.Text.Equals("0.00") || txtfields1.Text.Equals("0")) && tab_id == 0)
              {
                txtfields2.Text = "-1";
              }
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
                        List<Tabla_Columna> lstTablaValores = new List<Tabla_Columna>();
                        lstTablaValores.Add(new Tabla_Columna(tac_id, frmTablaFilaLista.taf_id1, System.Convert.ToDecimal(txtfields1.Text.Trim().Replace(",", ".")), System.Convert.ToDecimal(txtfields2.Text.Trim().Replace(",", ".")), 1));
                        Tabla_Columna tablaValores = new Tabla_Columna();
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
                        List<Tabla_Columna> lstTablaValores = new List<Tabla_Columna>();
                        lstTablaValores.Add(new Tabla_Columna(0, frmTablaFilaLista.taf_id1, System.Convert.ToDecimal(txtfields1.Text.Trim().Replace(",", ".")), System.Convert.ToDecimal(txtfields2.Text.Trim().Replace(",", ".")), 1));
                        Tabla_Columna tablaValores = new Tabla_Columna();
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