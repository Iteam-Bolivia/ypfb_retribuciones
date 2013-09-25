using System;
using System.Windows.Forms;
using ypfbApplication.Controller;
using System.Collections.Generic;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmConversiones : Form
    {
        bool flagValidacion;
        long con_id = 0;
        public frmConversiones()
        {
            InitializeComponent();
            Cargar();
        }
        #region Eventos
        private void frmConversiones_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
                CargarCombo();
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
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Guardar();
        }
        #endregion
        #region Metodos Controller
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Valor de la Conversión");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Valor de la Conversión");
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar la Unidad de Medida");
            toolTip1.SetToolTip(this.cbofields1, "Indicar la Unidad de Medida");
            toolTip1.SetToolTip(this.lblcbofields2, "Indicar la Unidad de Medida");
            toolTip1.SetToolTip(this.cbofields2, "Indicar la Unidad de Medida");
            toolTip1.SetToolTip(this.cbofields3, "Indicar la Variable");
            toolTip1.SetToolTip(this.cbofields3, "Indicar la Variable");
        }
        protected void CargarCombo()
        {
            cbofields1.DataSource = UnidadMedidaController.GetListaUnidadMedida(0);
            cbofields1.DisplayMember = "umd_codigo";
            cbofields1.ValueMember = "umd_id";
            if (frmUnidadMedidaLista.umd_id1 != 0)
            {
                cbofields1.SelectedValue = frmUnidadMedidaLista.umd_id1;
                cbofields1.Enabled = false;
            }

            cbofields2.DataSource = UnidadMedidaController.GetListaUnidadMedida(0);
            cbofields2.DisplayMember = "umd_codigo";
            cbofields2.ValueMember = "umd_id";

            cbofields3.DataSource = VariableController.GetListaVariable(0);
            cbofields3.DisplayMember = "var_codigo";
            cbofields3.ValueMember = "var_id";

        }
        public void Buscar()
        {
            con_id = frmConversionesLista.con_id1;
            CargarCombo();
            List<Conversiones> lstConversiones = new List<Conversiones>();
            lstConversiones = ConversionesController.GetListaConversiones(con_id);
            if (lstConversiones.Count != 0)
            {
                foreach (Conversiones item in lstConversiones)
                {
                    cbofields1.Text = item.Umd_nombre;
                    cbofields2.Text = item.Umdc_nombre;
                    txtfields1.Text = item.Con_valor;
                    cbofields3.Text = item.Var_codigo;
                }
                flagValidacion = true;
            }
            else
                flagValidacion = false;
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Conversiones> lstConversiones = new List<Conversiones>();
                        lstConversiones.Add(new Conversiones(con_id, Convert.ToInt64(cbofields1.SelectedValue), Convert.ToInt64(cbofields2.SelectedValue), txtfields1.Text, 1, Convert.ToInt64(cbofields3.SelectedValue)));
                        Conversiones conversiones = new Conversiones();
                        accion = conversiones.update(lstConversiones);
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
                        List<Conversiones> lstConversiones = new List<Conversiones>();
                        lstConversiones.Add(new Conversiones(0, Convert.ToInt64(cbofields1.SelectedValue), Convert.ToInt64(cbofields2.SelectedValue), txtfields1.Text.Trim().ToUpper(), 1, Convert.ToInt64(cbofields3.SelectedValue)));
                        Conversiones conversiones = new Conversiones();
                        accion = conversiones.insert(lstConversiones);
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
                MessageBox.Show(this, "Registre el Valor de la Conversión", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (Convert.ToDecimal(txtfields1.Text) <= 0)
            {
                MessageBox.Show(this, "El valor de la Conversión debe ser mayor a Cero", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion
    }
}