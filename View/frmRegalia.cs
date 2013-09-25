using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using System.Data;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmRegalia : Form
    {
        bool flagValidacion;
        long reg_id = 0;
        long mes_id;
        long mon_id;
        long ani_id;
        long ctt_id;

        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };


        public frmRegalia()
        {
            InitializeComponent();
        }
        private void frmRegalia_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
            {
                Cargar();
                CargarContratos();
            }
            if (frmContratoLista.ctt_id1 == 0)//Si es igual a 0 significa que se inserta desde el Menu regalias
            {
                lblContrato.Visible = false;
                lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
                cbofields5.Visible = true;
                lblcbofields5.Visible = true;
            }
            else
            {
                lblContrato.Visible = true;
                lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
                cbofields5.Visible = false;
                lblcbofields5.Visible = false;
            }
        }
        private void CargarContratos()
        {
            List<Contrato> listaContratos = new List<Contrato>();
            listaContratos = ContratoController.GetListContrato(0);
            cbofields5.DataSource = listaContratos;
            cbofields5.DisplayMember = "ctt_nombre";
            cbofields5.ValueMember = "ctt_id";
        }
        private void cbofields1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void cbofields2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void cbofields3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void cbofields4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtfields1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        private void txtfields2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        private void txtfields3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            if (frmContratoLista.ctt_id1 == 0)
                ctt_id = Convert.ToInt64(cbofields5.SelectedValue);
            else
                ctt_id = Convert.ToInt64(frmContratoLista.ctt_id1);
            ani_id = Convert.ToInt64(cbofields1.Text);
            mes_id = cbofields2.SelectedIndex + 1;
            mon_id = Convert.ToInt64(cbofields3.SelectedValue);
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
            toolTip1.SetToolTip(this.lblcbofields1, "Indicar el Año");
            toolTip1.SetToolTip(this.cbofields1, "Indicar el Año");
            toolTip1.SetToolTip(this.lblcbofields2, "Indicar el Mes");
            toolTip1.SetToolTip(this.cbofields2, "Indicar el Mes");
            toolTip1.SetToolTip(this.lblcbofields3, "Indicar la Moneda");
            toolTip1.SetToolTip(this.cbofields3, "Indicar la Moneda");
            toolTip1.SetToolTip(this.lblcbofields4, "Indicar el Tipo");
            toolTip1.SetToolTip(this.cbofields4, "Indicar el Tipo");
            toolTip1.SetToolTip(this.lblcbofields5, "Indicar el Contrato");
            toolTip1.SetToolTip(this.cbofields5, "Indicar el Contrato");

            toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el monto");
            toolTip1.SetToolTip(this.txtfields1, "Indicar el monto");

            toolTip1.SetToolTip(this.lbltxtfields2, "Indicar la participacion");
            toolTip1.SetToolTip(this.txtfields2, "Indicar la participacion");

            toolTip1.SetToolTip(this.lbltxtfields3, "Indicar el IDH");
            toolTip1.SetToolTip(this.txtfields3, "Indicar el IDH");
            foreach (int anio in ANIOS)
                cbofields1.Items.Add(anio);
            cbofields1.Text = DateTime.Today.Year.ToString();

            foreach (string mes in MESES)
                cbofields2.Items.Add(mes);
            cbofields2.SelectedIndex = 0;
            List<Moneda> lstMoneda = new List<Moneda>();
            MonedaObject objMonedaObject = new MonedaObject();
            lstMoneda = objMonedaObject.listMoneda(0);
            if (lstMoneda.Count == 0)
                cbofields3.Items.Clear();
            else
            {
                cbofields3.Items.Clear();
                cbofields3.DataSource = lstMoneda;
                cbofields3.DisplayMember = "mon_nombre";
                cbofields3.ValueMember = "mon_id";
                cbofields3.SelectedIndex = 0;
            }
            DataTable dt = null;
            dt = new DataTable("Lista");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Oculto");
            DataRow drR = dt.NewRow();
            drR["Visible"] = "REGALÍAS";
            drR["Oculto"] = "R";
            dt.Rows.Add(drR);
            DataRow drP = dt.NewRow();
            drP[0] = "PARTICIPACIÓN";
            drP[1] = "P";
            dt.Rows.Add(drP);
            DataRow drI = dt.NewRow();
            drI[0] = "IDH";
            drI[1] = "I";
            dt.Rows.Add(drI);
            cbofields4.DataSource = dt;
            cbofields4.DisplayMember = "Visible";
            cbofields4.ValueMember = "Oculto";
        }
        public void Buscar()
        {
            Cargar();
            CargarContratos();
            reg_id = frmRegaliaLista.reg_id1;
            List<Regalia> lstRegalia = new List<Regalia>();
            RegaliaObject objRegaliaObject = new RegaliaObject();
            lstRegalia = objRegaliaObject.listRegalia(reg_id);
            if (lstRegalia.Count != 0)
            {
                lstRegalia.ForEach(delegate(Regalia r)
                {
                    cbofields1.SelectedIndex = cbofields1.FindString(r.Ani_id.ToString(), -1);
                    cbofields2.SelectedIndex = cbofields2.FindString(r.Mes_nombre, -1);
                    cbofields3.SelectedIndex = cbofields3.FindString(r.Mon_nombre, -1);
                    cbofields4.Text = r.Reg_tiponombre;
                    cbofields5.Text = r.Ctt_nombre;
                    txtfields1.Text = System.Convert.ToString(r.Reg_gasmi);
                    txtfields2.Text = System.Convert.ToString(r.Reg_gasme);
                    txtfields3.Text = System.Convert.ToString(r.Reg_crudomi);
                    txtfields4.Text = System.Convert.ToString(r.Reg_crudome);
                    txtfields5.Text = System.Convert.ToString(r.Reg_glp);
                    txtfields6.Text = System.Convert.ToString(r.Reg_total);
                });
                flagValidacion = true;
            }
            else
                flagValidacion = false;
        }

        private bool validarCampos()
        {
            bool flag = false;
            if (txtfields1.Text == "")
            {
                MessageBox.Show("Registre el monto de la Regalia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields1.Focus();
                return flag;
            }
            if (txtfields2.Text == "")
            {
                MessageBox.Show("Registre la participacion", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields2.Focus();
                return flag;
            }
            if (txtfields3.Text == "")
            {
                MessageBox.Show("Registre el IDH", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfields3.Focus();
                return flag;
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
                        List<Regalia> lstproyecto = new List<Regalia>();
                        Regalia regalia = new Regalia();
                        regalia.Reg_id = Convert.ToInt64(reg_id);
                        regalia.Ctt_id = Convert.ToInt64(ctt_id);                        
                        regalia.Ani_id = Convert.ToInt64(ani_id);
                        regalia.Mes_id = Convert.ToInt64(mes_id);
                        regalia.Mon_id = Convert.ToInt64(mon_id);
                        regalia.Reg_tipo = Convert.ToString(cbofields4.SelectedValue).Trim();
                        regalia.Reg_gasmi = Convert.ToDecimal(txtfields1.Text);
                        regalia.Reg_gasme = Convert.ToDecimal(txtfields2.Text);
                        regalia.Reg_crudomi = Convert.ToDecimal(txtfields3.Text);
                        regalia.Reg_crudome = Convert.ToDecimal(txtfields4.Text);
                        regalia.Reg_glp = Convert.ToDecimal(txtfields5.Text);
                        regalia.Reg_total = Convert.ToDecimal(txtfields6.Text);
                        regalia.Reg_estado = 1;

                        lstproyecto.Add(regalia);
                        Regalia objRegalia = new Regalia();
                        accion = objRegalia.update(lstproyecto);

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
                        List<Regalia> lstproyecto = new List<Regalia>();
                        Regalia regalia = new Regalia();
                        regalia.Reg_id = 0;
                        regalia.Ctt_id = Convert.ToInt64(ctt_id);
                        regalia.Ani_id = Convert.ToInt64(ani_id);
                        regalia.Mes_id = Convert.ToInt64(mes_id);
                        regalia.Mon_id = Convert.ToInt64(mon_id);
                        regalia.Reg_tipo = Convert.ToString(cbofields4.SelectedValue).Trim();
                        regalia.Reg_gasmi = Convert.ToDecimal(txtfields1.Text);
                        regalia.Reg_gasme = Convert.ToDecimal(txtfields2.Text);
                        regalia.Reg_crudomi = Convert.ToDecimal(txtfields3.Text);
                        regalia.Reg_crudome = Convert.ToDecimal(txtfields4.Text);
                        regalia.Reg_glp = Convert.ToDecimal(txtfields5.Text);
                        regalia.Reg_total = Convert.ToDecimal(txtfields6.Text);
                        regalia.Reg_estado = 1;
                        lstproyecto.Add(regalia);
                        Regalia objRegalia = new Regalia();
                        accion = objRegalia.insert(lstproyecto);
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