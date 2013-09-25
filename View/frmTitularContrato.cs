using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitularContrato : Form
    {
        bool flagValidacion;
        public static long ttc_id = 0;
        public long titd_id;

        public frmTitularContrato()
        {
            InitializeComponent();
            lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
            lblPorcentaje.Text = "Faltante: " + string.Format("{0:n}", 100 - TitularContratoController.GetVerificaTitularContratoPorcentaje(frmContratoLista.ctt_id1));
        }
        private void frmTitularContrato_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
                Cargar();
        }
        private void cboTitulares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void cboTipos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Guardar();
        }
        #region Metodos Controller
        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtfields2.Text))
            {
                MessageBox.Show(this, "Registre el Porcentaje", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            if (Convert.ToDecimal(txtfields2.Text) <= 0)
            {
                MessageBox.Show(this, "El Porcentaje debe ser mayor a 0", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            return flag = true;
        }
        public void Buscar()
        {
            cbofields1.Items.Clear();
            cbofields1.DataSource = TitularController.GetListTitulares(0);
            cbofields1.DisplayMember = "tit_nombre";
            cbofields1.ValueMember = "tit_id";

            DataTable dt = null;
            dt = new DataTable("Lista");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Oculto");
            DataRow drT = dt.NewRow();
            drT["Visible"] = "TITULAR";
            drT["Oculto"] = "T";
            dt.Rows.Add(drT);
            DataRow drO = dt.NewRow();
            drO[0] = "OPERADOR";
            drO[1] = "O";
            dt.Rows.Add(drO);
            cbofields2.DataSource = dt;
            cbofields2.DisplayMember = "Visible";
            cbofields2.ValueMember = "Oculto";

            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            lstTitularContrato = TitularContratoController.GetListTitularContratos(frmTitularContratoLista.ttc_id1);
            if (lstTitularContrato.Count != 0)
            {
                foreach (Titular_Contrato item in lstTitularContrato)
                {
                    ttc_id = item.Ttc_id;
                    cbofields1.Text = item.Tit_nombre.ToString();
                    cbofields2.Text = item.Ttc_tipo;
                    txtfields2.Text = item.Ttc_porcentaje;
                }
                flagValidacion = true;
            }
            else
            {
                ttc_id = 0;
                flagValidacion = false;
            }
        }
        protected void Guardar()
        {
            int accionOperador = 0;
            
            //else if (accion == 0)

            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                decimal valorPorcentajeGeneral = 0;
                string tipoEmpresa = "";
                decimal valorPorcentajeTitularContrato = 0;
                Titular_Contrato titularContratoPorcentaje = TitularContratoController.GetDatosTitularContrato(ttc_id);
                if (titularContratoPorcentaje != null)
                {
                    valorPorcentajeTitularContrato = Convert.ToDecimal(titularContratoPorcentaje.Ttc_porcentaje);//TitularContratoActual
                    tipoEmpresa = titularContratoPorcentaje.Ttc_tipo;
                }

                if (valorPorcentajeTitularContrato > Convert.ToDecimal(txtfields2.Text))
                    valorPorcentajeGeneral = valorPorcentajeTitularContrato - Convert.ToDecimal(txtfields2.Text);
                else if (valorPorcentajeTitularContrato < Convert.ToDecimal(txtfields2.Text))
                    valorPorcentajeGeneral = Convert.ToDecimal(txtfields2.Text) - valorPorcentajeTitularContrato;
                else
                    valorPorcentajeGeneral = valorPorcentajeTitularContrato - Convert.ToDecimal(txtfields2.Text);

                if (Convert.ToDecimal(lblPorcentaje.Text.Replace("Faltante: ", "")) == 0)
                {
                    if (valorPorcentajeGeneral > 100)
                    {
                        MessageBox.Show(this, "El Porcentaje no puede exceder el 100%", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    if (valorPorcentajeGeneral > Convert.ToDecimal(lblPorcentaje.Text.Replace("Faltante: ", "")))
                    {
                        MessageBox.Show(this, "El Porcentaje no puede exceder el 100%", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                //Operador
                accionOperador = TitularContratoController.GetVerificaTitularContratoOperador(frmContratoLista.ctt_id1, "");

                if (tipoEmpresa == "O" && Convert.ToString(cbofields2.SelectedValue) == "O")
                {
                    if (accionOperador == 1)
                    {
                        if (titularContratoPorcentaje.Ttc_tipo != "O")
                        {
                            MessageBox.Show(this, "Un Contrato solo puede tener un Operador", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                else
                {
                    if (Convert.ToString(cbofields2.SelectedValue) == "O")
                    {
                        if (accionOperador == 1)
                        {
                            MessageBox.Show(this, "Un Contrato solo puede tener un Operador", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else if (accionOperador == 0)
                        {
                        }
                    }
                }
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
                        Titular_Contrato titularContratoObj=new Titular_Contrato();
                        titularContratoObj.Ttc_id= ttc_id;
                        titularContratoObj.Ctt_id = frmContratoLista.ctt_id1;
                        titularContratoObj.Tit_id = Convert.ToInt64(cbofields1.SelectedValue);
                        titularContratoObj.Ttc_tipo =  cbofields2.SelectedValue.ToString();
                        titularContratoObj.Ttc_porcentaje = txtfields2.Text.Replace(",", ".");
                        titularContratoObj.Ttc_estado = 1;
                        titularContratoObj.Titd_id = titd_id;
                        lstTitularContrato.Add(titularContratoObj);
                        Titular_Contrato titularContrato = new Titular_Contrato();
                        accion = titularContrato.update(lstTitularContrato);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                accionOperador = TitularContratoController.GetVerificaTitularContratoOperador(frmContratoLista.ctt_id1, Convert.ToString(cbofields2.SelectedValue));
                if (accionOperador == 1 && cbofields2.SelectedValue.ToString() == "O")
                {
                    MessageBox.Show(this, "Un Contrato solo puede tener un Operador", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Convert.ToDecimal(txtfields2.Text) > Convert.ToDecimal(lblPorcentaje.Text.Replace("Faltante: ", "")))
                {
                    MessageBox.Show(this, "El Porcentaje no puede exceder el 100%", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                switch (MessageBox.Show("Grabar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
                        Titular_Contrato titularContratoObj=new Titular_Contrato();
                        titularContratoObj.Ttc_id= ttc_id;
                        titularContratoObj.Ctt_id = frmContratoLista.ctt_id1;
                        titularContratoObj.Tit_id = Convert.ToInt64(cbofields1.SelectedValue);
                        titularContratoObj.Ttc_tipo =  cbofields2.SelectedValue.ToString();
                        titularContratoObj.Ttc_porcentaje = txtfields2.Text.Replace(",", ".");
                        titularContratoObj.Ttc_estado = 1;
                        titularContratoObj.Titd_id = titd_id;
                        lstTitularContrato.Add(titularContratoObj);
                        Titular_Contrato titularContrato = new Titular_Contrato();
                        accion = titularContrato.insert(lstTitularContrato);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se registró con éxito", "Validación de SGP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        protected void Cargar()
        {
            cbofields1.DataSource = TitularController.GetListTitulares(0);
            cbofields1.DisplayMember = "tit_nombre";
            cbofields1.ValueMember = "tit_id";
            DataTable dt = null;
            dt = new DataTable("Lista");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Oculto");
            DataRow drT = dt.NewRow();
            drT["Visible"] = "TITULAR";
            drT["Oculto"] = "T";
            dt.Rows.Add(drT);
            DataRow drO = dt.NewRow();
            drO[0] = "OPERADOR";
            drO[1] = "O";
            dt.Rows.Add(drO);
            cbofields2.DataSource = dt;
            cbofields2.DisplayMember = "Visible";
            cbofields2.ValueMember = "Oculto";
        }
        #endregion
    }
}