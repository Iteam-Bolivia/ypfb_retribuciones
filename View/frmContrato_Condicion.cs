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
    public partial class frmContrato_Condicion : Form
    {

        bool flagValidacion;
        long ccn_id = 0;
        long ctt_id;
        Int64 condicion = 1;
        private bool isLoad = false;


        public frmContrato_Condicion()
        {
            InitializeComponent();
        }

        private void frmContrato_Condicion_Load(object sender, EventArgs e)
        {
            //setea la variable de cargado de formulario en true 
            isLoad = true;

            if (flagValidacion == false)
            {
                Cargar();
                CargarContratos();
                CargarCondicion();
                CargarSimbolo();
            }
            //if (frmContratoLista.ctt_id1 == 0)//Si es igual a 0 significa que se inserta desde el Menu regalias
            //{
            //    lblContrato.Visible = false;
            //    lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
            //    cbofields1.Visible = true;
            //    lblcbofields1.Visible = true;
            //}
            //else
            //{
            lblContrato.Visible = true;
            lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
            cbofields1.Visible = false;
            lblcbofields1.Visible = false;
            //}
        }
        private void CargarContratos()
        {
            List<Contrato> listaContratos = new List<Contrato>();
            listaContratos = ContratoController.GetListContrato(0);
            cbofields1.DataSource = listaContratos;
            cbofields1.DisplayMember = "ctt_nombre";
            cbofields1.ValueMember = "ctt_id";
        }

        private void CargarCondicion()
        {
            CondicionObject condition = new CondicionObject();
            List<Condicion> listaCondicion = new List<Condicion>();
            listaCondicion = condition.listCondicion(0);
            cbofields2.DataSource = listaCondicion;
            cbofields2.DisplayMember = "con_nombre";
            cbofields2.ValueMember = "con_id";
        }

        private void CargarSimbolo()
        {
            SimboloObject simbolo = new SimboloObject();
            List<Simbolo> listaSimbolo = new List<Simbolo>();
            listaSimbolo = simbolo.listSimbolo(0);
            cbofields3.DataSource = listaSimbolo;
            cbofields3.DisplayMember = "sim_simbolo";
            cbofields3.ValueMember = "sim_id";
            cbofields3.SelectedItem = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            if (frmContratoLista.ctt_id1 == 0)
                ctt_id = Convert.ToInt64(cbofields1.SelectedValue);
            else
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
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar el contrato");
            toolTip1.SetToolTip(this.cbofields1, "Indicar el contrato");
            toolTip1.SetToolTip(this.label1, "Indicar la Condición");
            toolTip1.SetToolTip(this.cbofields2, "Indicar la Condición");


        }

        public void Buscar()
        {
            try
            {
                Cargar();
                CargarContratos();
                CargarCondicion();
                CargarSimbolo();
                ccn_id = frmContrato_CondicionLista.ccn_id1;
                List<ContratoCondicion> lstContrato_Condicion = new List<ContratoCondicion>();
                ContratoCondicionObject objContrato_CondicionObject = new ContratoCondicionObject();
                lstContrato_Condicion = objContrato_CondicionObject.listContratoCondicionById(ccn_id);
                if (lstContrato_Condicion.Count != 0)
                {
                    lstContrato_Condicion.ForEach(delegate(ContratoCondicion r)
                    {
                        //cbofields1.Text = r.Ctt_nombre;
                        cbofields2.Text = r.Con_nombre;
                        cbofields2.Enabled = false;
                        cbofields3.Text = r.Sim_simbolo;
                        //dtpfields1.Value = System.Convert.ToDateTime(r.Ccn_iniexp);
                        txtfields1.Text = System.Convert.ToString(r.Ccn_mesiniexp);
                        txtfields2.Text = System.Convert.ToString(r.Ccn_anioiniexp);
                        txtfields3.Text = System.Convert.ToString(r.Ccn_mesfin);
                        txtfields4.Text = System.Convert.ToString(r.Ccn_aniofin);
                        //dtpfields2.Value = System.Convert.ToDateTime(r.Ccn_tiempodur);
                        txtfields5.Text = System.Convert.ToString(r.Ccn_diasdifer);
                        txtfields6.Text = System.Convert.ToString(r.Ccn_valorb);

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

            if (cbofields2.SelectedValue == "")
            {
                MessageBox.Show("Registre la Condición", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbofields2.Focus();
                return flag;
            }
            //if (txtfields1.Text == "" && condicion == 1)
            //{
            //    MessageBox.Show("Registre el mes de Inicio de Explotación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtfields3.Focus();
            //    return flag;
            //}
            //if (txtfields1.Text != "" && condicion == 1)
            //{
            //    int valorMesesIni = Convert.ToInt32(txtfields1.Text);
            //    if (valorMesesIni > 12)
            //    {
            //        MessageBox.Show("El valor de Meses no puede ser mayor que 12", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtfields1.Focus();
            //        return flag;
            //    }
            //}
            //if (txtfields2.Text == "" && condicion == 1)
            //{
            //    MessageBox.Show("Registre el año de Inicio de Explotación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtfields2.Focus();
            //    return flag;
            //}
            //if (txtfields2.Text != "" && condicion == 1)
            //{
            //    String valorAniosIni = txtfields2.Text;
            //    if (valorAniosIni.Length < 4)
            //    {
            //        MessageBox.Show("El valor del Año de Inicio de Explotación debe tener 4 digitos", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtfields2.Focus();
            //        return flag;
            //    }
            //}
            if (txtfields3.Text == "" && condicion == 1)
            {
                MessageBox.Show("Registre el mes de Finalización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag;
            }
            if (txtfields3.Text != "" && condicion == 1)
            {
                int valorMeses = Convert.ToInt32(txtfields3.Text);
                if (valorMeses > 12)
                {
                    MessageBox.Show("El valor de Meses no puede ser mayor que 12", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtfields3.Focus();
                    return flag;
                }
            }

            if (txtfields4.Text == "" && condicion == 1)
            {
                MessageBox.Show("Registre el año de Finalización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag;
            }
            if (txtfields4.Text != "" && condicion == 1)
            {
                String valorAnios = txtfields4.Text;
                if (valorAnios.Length < 4)
                {
                    MessageBox.Show("El valor del Año de Finalización debe tener 4 digitos", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtfields3.Focus();
                    return flag;
                }
            }
            if (txtfields5.Text == "" && condicion == 1)
            {
                MessageBox.Show("Registre los dias de Diferencia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields5.Focus();
                return flag;
            }

            if (txtfields5.Text != "" && condicion == 1)
            {
                int valorDias = Convert.ToInt32(txtfields5.Text);
                if (valorDias > 31)
                {
                    MessageBox.Show("El valor de Dias de diferencia no puede ser mayor que 31", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtfields5.Focus();
                    return flag;
                }
            }
            if (cbofields3.SelectedValue == "" && condicion == 2)
            {
                MessageBox.Show("Registre el operador de Comparación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbofields2.Focus();
                return flag;
            }
            if (txtfields6.Text == "" && condicion == 2)
            {
                MessageBox.Show("Registre el Valor de Indice B", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields6.Focus();
                return flag;
            }

            flag = true;
            return flag;
        }

        private void Guardar()
        {
            long accion = 0;
            Int64 Condi = Convert.ToInt64(cbofields2.SelectedValue);
            if (flagValidacion == true)
            {
                switch (MessageBox.Show("Actualizar registro?",
                              "Validación del Sistema",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<ContratoCondicion> lstproyecto = new List<ContratoCondicion>();
                        ContratoCondicion contrato_condicion = new ContratoCondicion();
                        contrato_condicion.Ccn_id = Convert.ToInt64(ccn_id);
                        contrato_condicion.Ctt_id = Convert.ToInt64(ctt_id);
                        contrato_condicion.Con_id = Convert.ToInt64(Condi);
                        //if (Condi == 2)
                        //{
                            contrato_condicion.Sim_id = Convert.ToInt64(cbofields3.SelectedValue);
                        //}
                        //else
                        //{
                        //    contrato_condicion.Sim_id = 1;
                        //}
                        //contrato_condicion.Ccn_iniexp = Convert.ToDateTime(dtpfields1.Value);
                        contrato_condicion.Ccn_mesiniexp = Convert.ToInt32(txtfields1.Text);
                        contrato_condicion.Ccn_anioiniexp = Convert.ToInt32(txtfields2.Text);
                        contrato_condicion.Ccn_mesfin = Convert.ToInt32(txtfields3.Text);
                        contrato_condicion.Ccn_aniofin = Convert.ToInt32(txtfields4.Text);
                        //contrato_condicion.Ccn_tiempodur = Convert.ToDateTime(dtpfields2.Value);
                        if (Condi == 2)
                        {
                            contrato_condicion.Ccn_diasdifer = 0;
                        }
                        else
                        {
                            contrato_condicion.Ccn_diasdifer = Convert.ToInt32(txtfields5.Text);
                        }
                        if (Condi == 1)
                        {
                            contrato_condicion.Ccn_valorb = 0;
                        }
                        else
                        {
                            contrato_condicion.Ccn_valorb = Convert.ToDecimal(txtfields6.Text);
                        }
                        contrato_condicion.Ccn_estado = 1;

                        lstproyecto.Add(contrato_condicion);
                        ContratoCondicion objContrato_Condicion = new ContratoCondicion();
                        accion = objContrato_Condicion.update(lstproyecto);

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
                        ContratoCondicionObject contrato_condicionVal = new ContratoCondicionObject();
                        bool valida = contrato_condicionVal.ValCondicion(ctt_id, Convert.ToInt64(cbofields2.SelectedValue));
                        if (valida)
                        {
                            List<ContratoCondicion> lstproyecto = new List<ContratoCondicion>();
                            ContratoCondicion contrato_condicion = new ContratoCondicion();

                            contrato_condicion.Ccn_id = 0;
                            contrato_condicion.Ctt_id = Convert.ToInt64(ctt_id);
                            contrato_condicion.Con_id = Condi;
                            //if (Condi == 2)
                            //{
                                contrato_condicion.Sim_id = Convert.ToInt64(cbofields3.SelectedValue);
                            //}
                            //else
                            //{
                            //    contrato_condicion.Sim_id = 1;
                            //}
                            //contrato_condicion.Ccn_iniexp = Convert.ToDateTime(dtpfields1.Value);
                            contrato_condicion.Ccn_mesiniexp = Convert.ToInt32(0);
                            contrato_condicion.Ccn_anioiniexp = Convert.ToInt32(0);
                            contrato_condicion.Ccn_mesfin = Convert.ToInt32(txtfields3.Text);
                            contrato_condicion.Ccn_aniofin = Convert.ToInt32(txtfields4.Text);
                            //contrato_condicion.Ccn_tiempodur = Convert.ToDateTime(dtpfields2.Value);
                            if (Condi == 2)
                            {
                                contrato_condicion.Ccn_diasdifer = 0;
                            }
                            else
                            {
                                contrato_condicion.Ccn_diasdifer = Convert.ToInt32(txtfields5.Text);
                            }
                            if (Condi == 1)
                            {
                                contrato_condicion.Ccn_valorb = 0;
                            }
                            else
                            {
                                contrato_condicion.Ccn_valorb = Convert.ToDecimal(txtfields6.Text);
                            }
                            contrato_condicion.Ccn_estado = 1;


                            lstproyecto.Add(contrato_condicion);
                            ContratoCondicion objContrato_Condicion = new ContratoCondicion();
                            accion = objContrato_Condicion.insert(lstproyecto);
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
                        }
                        else
                        {
                            MessageBox.Show("No se registró con exito, Ya exite una condición del mismo tipo, Para registra una condición de Indice B debe tener registrda antes una condición de Tiempo de Gracia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        private void txtfields1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtfields2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtfields3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtfields4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtfields5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtfields6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbofields2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pregunta si el formulario esta cargando 
            // para no lanzar el proceso de carga de el text box
            if (!isLoad)
            {
                condicion = Convert.ToInt64(cbofields2.SelectedValue);
                if (condicion == 1)
                {
                    //txtfields1.Enabled = true;
                    //txtfields2.Enabled = true;
                    txtfields3.Enabled = true;
                    txtfields4.Enabled = true;
                    txtfields5.Enabled = true;
                    cbofields3.Enabled = false;
                    cbofields3.SelectedItem = null;
                    txtfields6.Enabled = false;
                }
                if (condicion == 2)
                {
                    //txtfields1.Enabled = false;
                    //txtfields2.Enabled = false;
                    txtfields3.Enabled = false;
                    txtfields4.Enabled = false;
                    txtfields5.Enabled = false;
                    cbofields3.Enabled = true;
                    txtfields6.Enabled = true;

                    List<ContratoCondicion> lstContrato_Condicion = new List<ContratoCondicion>();
                    ContratoCondicionObject objContrato_CondicionObject = new ContratoCondicionObject();
                    lstContrato_Condicion = objContrato_CondicionObject.listContratoCondicionByCon(frmContratoLista.ctt_id1, 1);
                    if (lstContrato_Condicion.Count != 0)
                    {
                        lstContrato_Condicion.ForEach(delegate(ContratoCondicion r)
                        {

                            //txtfields1.Text = System.Convert.ToString(r.Ccn_mesiniexp);
                            //txtfields2.Text = System.Convert.ToString(r.Ccn_anioiniexp);
                            txtfields3.Text = System.Convert.ToString(r.Ccn_mesfin);
                            txtfields4.Text = System.Convert.ToString(r.Ccn_aniofin);

                        });

                    }
                    else
                    {
                        MessageBox.Show("La condicion de Indice B debe tener registrda antes una condición de Tiempo de Gracia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
            }
        }

        private void frmContrato_Condicion_Shown(object sender, EventArgs e)
        {
            //setea la variable en false una vez cargado el formulario
            isLoad = false;
        }




    }
}
