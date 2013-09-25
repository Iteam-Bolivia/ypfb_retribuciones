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
    public partial class frmMercado : Form
    {
        bool flagValidacion;
        long mer_id = 0;
        public frmMercado()
        {
            InitializeComponent();
            Cargar();
        }

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
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #region Metodos Controller()
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            List<Bloque> bloque = new List<Bloque>();
            bloque = BloqueController.GetListBloques(0);

            cbxCampoNombre.DataSource = bloque;
            cbxCampoNombre.DisplayMember = "blo_nombre";
            cbxCampoNombre.ValueMember = "blo_id";

            toolTip1.SetToolTip(this.lbltxtfields3, "Indicar el Campo del Mercado");
            toolTip1.SetToolTip(this.cbxCampoNombre, "Indicar el Campo del Mercado");
            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Mercado");
            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Mercado");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el Código del Mercado");
            toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre del Mercado");
        }

        public void Buscar()
        {
            mer_id = frmMercadoLista.mer_id1;

            List<Bloque> bloque = new List<Bloque>();
            bloque = BloqueController.GetListBloques(0);

            cbxCampoNombre.DataSource = bloque;
            cbxCampoNombre.DisplayMember = "blo_nombre";
            cbxCampoNombre.ValueMember = "blo_id";

            List<Mercado> lstMercado = new List<Mercado>();
            lstMercado = MercadoController.GetListMercados(mer_id);
            if (lstMercado.Count != 0)
            {
                lstMercado.ForEach(delegate(Mercado m)
                {
                    txtfields1.Text = m.Mer_codigo;
                    txtfields2.Text = m.Mer_nombre;

                    txtMer_tipo.Text = m.Mer_tipo;
                    txtMer_orden.Text = Convert.ToString(m.Mer_orden);
                    txtMer_ordenletra.Text = m.Mer_ordenletra;
                    txtMer_var.Text = Convert.ToString(m.Mer_var);
                    txtPro_mer.Text = Convert.ToString(m.Pro_mer);
                });
                flagValidacion = true;
                //gbCabecera.Text = "Actualizacíón de Contratos";
            }
            else
            {
                flagValidacion = false;
            }
        }

        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields1.Text))
            {
                MessageBox.Show(this, "Registre el Código del Mercado", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Nombre del Mercado", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        List<Mercado> lstMercado = new List<Mercado>();
                        lstMercado.Add(new Mercado(mer_id, txtfields1.Text.Trim(), txtfields2.Text.Trim().ToUpper(), 1, txtMer_tipo.Text.Trim(), Convert.ToInt64(txtMer_orden.Text), txtMer_ordenletra.Text.Trim(), Convert.ToInt32(txtMer_var.Text), Convert.ToInt32(txtPro_mer.Text)));
                        Mercado mercado = new Mercado();
                        accion = mercado.update(lstMercado);
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
                        List<Mercado> lstMercado = new List<Mercado>();
                        lstMercado.Add(new Mercado(0, txtfields1.Text.Trim(), txtfields2.Text.Trim().ToUpper(), 1, txtMer_tipo.Text.Trim(),Convert.ToInt64(txtMer_orden.Text),txtMer_ordenletra.Text.Trim(),Convert.ToInt32(txtMer_var.Text),Convert.ToInt32(txtPro_mer.Text)));
                        Mercado mercado = new Mercado();
                        accion = mercado.insert(lstMercado);
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

        private void frmMercado_Load(object sender, EventArgs e)
        {

        }
    }
}