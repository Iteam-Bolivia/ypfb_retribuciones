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
using System.Runtime.InteropServices;


namespace ypfbApplication.View
{
    public partial class frmContrato_Marginal : Form
    {

        bool flagValidacion;
        long cma_id = 0;
        long ctt_id;
        Int64 condicion = 1;
        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };


        public frmContrato_Marginal()
        {
            InitializeComponent();
        }

        private void frmContrato_Marginal_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
            {
                Cargar();

            }
            lblContrato.Visible = true;
            lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
            cbofields1.Visible = false;
            lblcbofields1.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (!validarCampos())
            //    return;

            ctt_id = Convert.ToInt64(frmContratoLista.ctt_id1);
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cargar()
        {

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(this.label1, "Indicar el mes");
            toolTip1.SetToolTip(this.cbxMes_ini, "Indicar el mes");
            toolTip1.SetToolTip(this.label2, "Indicar el año");
            toolTip1.SetToolTip(this.cbxAnio_ini, "Indicar el año");

            // Meses
            foreach (string mes in MESES)
            {
                cbxMes_ini.Items.Add(mes);
            }
            //int a = cbxMes_ini.Items.Count;
            //cbxMes.SelectedIndex = Convert.ToInt32(mes_id - 1);

            foreach (int anio in ANIOS)
            {
                cbxAnio_ini.Items.Add(anio);
            }
            //int index = cbxAnio.FindStringExact(ani_id.ToString());
            //cbxAnio.SelectedText = ani_id.ToString();
            //cbxAnio.SelectedIndex = index;


            // Meses
            foreach (string mes in MESES)
            {
                cbxMes.Items.Add(mes);
            }
            //int a = cbxMes_ini.Items.Count;
            //cbxMes.SelectedIndex = Convert.ToInt32(mes_id - 1);

            foreach (int anio in ANIOS)
            {
                cbxAnio.Items.Add(anio);
            }
        }

        public void Buscar()
        {
            try
            {
                Cargar();
                cma_id = frmContrato_MarginalLista.cma_id1;
                List<ContratoMarginal> lstContrato_Marginal = new List<ContratoMarginal>();
                ContratoMarginalObject objContrato_MarginalObject = new ContratoMarginalObject();
                lstContrato_Marginal = objContrato_MarginalObject.listContratoMarginalById(cma_id);
                if (lstContrato_Marginal.Count != 0)
                {
                    lstContrato_Marginal.ForEach(delegate(ContratoMarginal r)
                    {

                        //cbxMes.Text = System.Convert.ToString(r.Cma_mes);
                        cbxMes_ini.SelectedIndex = Convert.ToInt32(r.Cma_mes_ini - 1);
                        //cbxAnio.Text = System.Convert.ToString(r.Cma_anio);
                        int index = cbxAnio_ini.FindStringExact(r.Cma_anio_ini.ToString());
                        cbxAnio_ini.SelectedText = r.Cma_anio.ToString();
                        cbxAnio_ini.SelectedIndex = index;


                        //cbxMes.Text = System.Convert.ToString(r.Cma_mes);
                        cbxMes.SelectedIndex = Convert.ToInt32(r.Cma_mes - 1);
                        //cbxAnio.Text = System.Convert.ToString(r.Cma_anio);
                        int index2 = cbxAnio.FindStringExact(r.Cma_anio.ToString());
                        cbxAnio.SelectedText = r.Cma_anio.ToString();
                        cbxAnio.SelectedIndex = index2;

                    });
                    flagValidacion = true;
                }
                else
                    flagValidacion = false;
            }

            catch (COMException err)
            {

                Console.WriteLine("Error: " + err.Message);

            }
        }

        private bool validarCampos()
        {
            bool flag = false;


            if (cbxMes_ini.Text == "")
            {
                MessageBox.Show("Registre el mes", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxMes_ini.Focus();
                return flag;
            }

            if (cbxMes_ini.Text != "")
            {
                int valorMeses = Convert.ToInt32(cbxMes_ini.Text);
                if (valorMeses > 12)
                {
                    MessageBox.Show("El valor de Meses no puede ser mayor que 12", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbxMes_ini.Focus();
                    return flag;
                }
            }

            if (cbxAnio_ini.Text == "")
            {
                MessageBox.Show("Registre el año", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxAnio_ini.Focus();
                return flag;
            }

            if (cbxAnio_ini.Text != "")
            {
                String valorAnios = cbxAnio_ini.Text;
                if (valorAnios.Length < 4)
                {
                    MessageBox.Show("El valor del Año de Finalización debe tener 4 digitos", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbxAnio_ini.Focus();
                    return flag;
                }
            }


            flag = true;
            return flag;
        }

        private void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)
            {
                switch (MessageBox.Show("Actualizar registro?",
                              "Validación del Sistema",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<ContratoMarginal> lstproyecto = new List<ContratoMarginal>();
                        ContratoMarginal contrato_marginal = new ContratoMarginal();
                        contrato_marginal.Cma_id = Convert.ToInt64(cma_id);
                        contrato_marginal.Ctt_id = Convert.ToInt64(ctt_id);
                        contrato_marginal.Cma_anio = Convert.ToInt32(cbxAnio_ini.Text);
                        contrato_marginal.Cma_mes = Convert.ToInt32(cbxMes.SelectedIndex + 1);
                        contrato_marginal.Cma_mes_ini = Convert.ToInt32(cbxMes_ini.SelectedIndex + 1);
                        contrato_marginal.Cma_anio_ini = Convert.ToInt32(cbxAnio_ini.Text);
                        contrato_marginal.Cma_estado = 1;

                        lstproyecto.Add(contrato_marginal);
                        ContratoMarginal objContrato_Marginal = new ContratoMarginal();
                        accion = objContrato_Marginal.update(lstproyecto);

                        if (accion == 0)
                        {
                            MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
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
                        List<ContratoMarginal> lstproyecto = new List<ContratoMarginal>();
                        ContratoMarginal contrato_marginal = new ContratoMarginal();
                        contrato_marginal.Cma_id = 0;
                        contrato_marginal.Ctt_id = Convert.ToInt64(ctt_id);
                        contrato_marginal.Cma_mes = Convert.ToInt32(cbxMes.SelectedIndex + 1);
                        contrato_marginal.Cma_anio = Convert.ToInt32(cbxAnio.Text);
                        contrato_marginal.Cma_mes_ini = Convert.ToInt32(cbxMes_ini.SelectedIndex + 1);
                        contrato_marginal.Cma_anio_ini = Convert.ToInt32(cbxAnio_ini.Text);
                        contrato_marginal.Cma_estado = 1;

                        lstproyecto.Add(contrato_marginal);
                        ContratoMarginal objContrato_Marginal = new ContratoMarginal();
                        accion = objContrato_Marginal.insert(lstproyecto);
                        if (accion == 0)
                        {
                            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }
    }
}
