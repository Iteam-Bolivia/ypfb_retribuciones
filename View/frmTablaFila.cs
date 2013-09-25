using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaFila : Form
    {
        bool flagValidacion;
        long taf_id = 0;
        public frmTablaFila()
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
            taf_id = frmTablaFilaLista.taf_id1;

            List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();
            lstTabla = TablaFilaController.GetListaTablaFila(taf_id);
            if (lstTabla.Count != 0)
            {
                lstTabla.ForEach(delegate(Tabla_Fila t)
                {
                    txtfields1.Text = System.Convert.ToString(t.Taf_valfila);
                    txtfields2.Text = System.Convert.ToString(t.Taf_valor);
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

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Número de Fila");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Valor de la Fila");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Número de Fila");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Valor de la Fila");
        }
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
              MessageBox.Show(this, "Registre la Fila", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              txtfields1.Focus();
              return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el valor de la Fila", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();
                        lstTabla.Add(new Tabla_Fila(taf_id, frmTablaLista.tab_id1, System.Convert.ToDecimal(txtfields1.Text.Trim().Replace(",", ".")), System.Convert.ToDecimal(txtfields2.Text.Trim().Replace(",", ".")), 1));
                        Tabla_Fila tabla = new Tabla_Fila();
                        accion = tabla.update(lstTabla);
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
                        List<Tabla_Fila> lstTabla = new List<Tabla_Fila>();
                        lstTabla.Add(new Tabla_Fila(0, frmTablaLista.tab_id1, System.Convert.ToDecimal(txtfields1.Text.Trim().Replace(",", ".")), System.Convert.ToDecimal(txtfields2.Text.Trim().Replace(",", ".")), 1));
                        Tabla_Fila tabla = new Tabla_Fila();
                        accion = tabla.insert(lstTabla);
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