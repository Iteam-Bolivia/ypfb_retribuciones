using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ypfbApplication.Controller;
using Model;

namespace ypfbApplication.View
{
    public partial class frmTablaCalculo : Form
    {
        bool flagValidacion;
        public static long tca_id = 0;

        public frmTablaCalculo()
        {
            InitializeComponent();
            Cargar();
            lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
        }
        #region Eventos Pagina
        private void frmTablaCalculo_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
                CargarCombo();
        }

        /// <summary>
        /// Method txtfields1_KeyPress
        /// </summary>
        private void txtfields1_KeyPress(object sender,
                            System.Windows.Forms.KeyPressEventArgs e)
        {
          if (e.KeyChar == 13)
          {
            e.Handled = true;
            SendKeys.Send("{TAB}");
          }
          if (Char.IsDigit(e.KeyChar))
          {
            e.Handled = false;
          }
          else if (Char.IsControl(e.KeyChar))
          {
            e.Handled = false;
          }
          else if (Char.IsSeparator(e.KeyChar))
          {
            e.Handled = false;
          }
          else if (Char.IsPunctuation(e.KeyChar))
          {
            e.Handled = false;
          }
          else
          {
            e.Handled = true;
          }
        }

        /// <summary>
        /// Method cbofields1_KeyPress
        /// </summary>
        private void cbofields1_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar == 13)
          {
            e.Handled = true;
            SendKeys.Send("{TAB}");
          }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdTablas":
                    frmTablaVisualLista frmTablaVisualListaNew = new frmTablaVisualLista();
                    //frmTablaCalculoNew.FormClosed += new FormClosedEventHandler(frmTablaCalculoLista_FormClosed);
                    frmTablaVisualListaNew.ShowDialog();
                    break;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        #endregion


        #region Metodos Controller
        public void Buscar()
        {
            cbofields1.Items.Clear();
            cbofields1.DataSource = TablaController.GetListaTabla(0);
            cbofields1.DisplayMember = "tab_nombre";
            cbofields1.ValueMember = "tab_id";

            SimboloObject objsimbolo = new SimboloObject();
            cbxOpLog.DataSource = objsimbolo.listSimbolo(0);
            cbxOpLog.DisplayMember = "sim_simbolo";
            cbxOpLog.ValueMember = "sim_id";


            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
            lstTablaCalculo = TablaCalculoController.GetListaTablaCalculo(frmTablaCalculoLista.tca_id1);
            if (lstTablaCalculo.Count != 0)
            {
                foreach (Tabla_Calculo item in lstTablaCalculo)
                {
                    cbofields1.Text = item.Tab_nombre;
                    txtfields1.Text = System.Convert.ToString(item.Tca_precio);
                    tca_id = item.Tca_id;
                    cbxOpLog.SelectedIndex = (int)item.tca_oplogi;
                }
                flagValidacion = true;
            }
            else
            {
                tca_id = 0;
                flagValidacion = false;
            }
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                        Tabla_Calculo tabla_Calculo =  new Tabla_Calculo();
                        tabla_Calculo.Tca_id = tca_id;
                        tabla_Calculo.Ctt_id = frmContratoLista.ctt_id1; 
                        tabla_Calculo.Tab_id = Convert.ToInt64(cbofields1.SelectedValue);
                        tabla_Calculo.Tca_estado = 1;
                        tabla_Calculo.Tca_fecha = DateTime.Now;
                        tabla_Calculo.Tca_precio = System.Convert.ToDecimal(txtfields1.Text);
                        tabla_Calculo.Tca_oplogi = (int)cbxOpLog.SelectedValue;
                        lstTablaCalculo.Add(tabla_Calculo);
                        //lstTablaCalculo.Add(new Tabla_Calculo(tca_id, frmContratoLista.ctt_id1, Convert.ToInt64(cbofields1.SelectedValue), 1, DateTime.Now, System.Convert.ToDecimal(txtfields1.Text)));
                        Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                        accion = tablaCalculo.update(lstTablaCalculo);
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
                        List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
                        Tabla_Calculo tabla_Calculo =  new Tabla_Calculo();
                        tabla_Calculo.Tca_id =  0;
                        tabla_Calculo.Ctt_id = frmContratoLista.ctt_id1; 
                        tabla_Calculo.Tab_id = Convert.ToInt64(cbofields1.SelectedValue);
                        tabla_Calculo.Tca_estado = 1;
                        tabla_Calculo.Tca_fecha = DateTime.Now;
                        tabla_Calculo.Tca_precio = System.Convert.ToDecimal(txtfields1.Text);
                        tabla_Calculo.Tca_oplogi = Convert.ToInt32(cbxOpLog.SelectedValue);
                        lstTablaCalculo.Add(tabla_Calculo);
                        Tabla_Calculo tablaCalculo = new Tabla_Calculo();
                        accion = tablaCalculo.insert(lstTablaCalculo);
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
        protected void CargarCombo()
        {
            cbofields1.DataSource = TablaController.GetListaTabla(0);
            cbofields1.DisplayMember = "tab_nombre";
            cbofields1.ValueMember = "tab_id";

            SimboloObject objsimbolo = new SimboloObject();
            cbxOpLog.DataSource = objsimbolo.listSimbolo(0);
            cbxOpLog.DisplayMember = "sim_simbolo";
            cbxOpLog.ValueMember = "sim_id";
        }
        protected void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblcbofields1, "Seleccionar una Tabla de Cálculo");
            toolTip1.SetToolTip(this.cbofields1, "Seleccionar una Tabla de Cálculo");
        }
        #endregion
    }
}