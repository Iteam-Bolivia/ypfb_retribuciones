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
using Controller;

namespace ypfbApplication.View
{
  public partial class frmContrato : Form
  {
    bool flagValidacion;
    static long ctt_id = 0;

    public frmContrato()
    {
      InitializeComponent();
      txtfields1.Focus();
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

    private void frmContrato_Load(object sender, EventArgs e)
    {
      txtfields1.Focus();
      if (flagValidacion == false)
        CargarCombo();
      Cargar();
    }

    private void cboSucursales_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }

    private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.KeyChar = char.ToUpper(e.KeyChar);
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      //else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
      //  e.Handled = false;
      //else if (Char.IsControl(e.KeyChar))
      //{
      //  e.Handled = false;
      //}
      //else
      //  e.Handled = true;
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

    private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else if (char.IsNumber(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }
    private void dtpFin_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }
    private void txtfields4_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void txtfields5_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void txtfields6_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void txtfields7_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void txtfields8_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    private void txtfields9_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      else if (char.IsDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 46 || e.KeyChar == '-')
        e.Handled = false;
      else if (Char.IsControl(e.KeyChar))
        e.Handled = false;
      else
        e.Handled = true;
    }
    #region Metodos Controller()
    protected void Cargar()
    {
      ToolTip toolTip1 = new ToolTip();
      toolTip1.IsBalloon = true;
      toolTip1.ToolTipTitle = "Ayuda";
      toolTip1.UseFading = true;
      toolTip1.UseAnimation = true;

      toolTip1.SetToolTip(this.lblcbofields1, "Seleccionar la Sucursal");
      toolTip1.SetToolTip(this.lbltxtfields1, "Indicar el Código del Contrato");
      toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el Nombre del Contrato");
      toolTip1.SetToolTip(this.lbltxtfields3, "Indicar el Periodo del Contrato");
      toolTip1.SetToolTip(this.lbldtpfields1, "Seleccionar una Fecha de Inicio de Contrato");
      toolTip1.SetToolTip(this.lbldtpfields2, "Seleccionar una Fecha de Fin de Contrato");
      toolTip1.SetToolTip(this.lblcbofields2, "Seleccionar Usuario");
      toolTip1.SetToolTip(this.lbltxtfields4, "Indicar la depreciación acumulada");
      toolTip1.SetToolTip(this.lbltxtfields5, "Indicar la depreciación acumulada al mes anterior");
      toolTip1.SetToolTip(this.lbltxtfields6, "Indicar la ganancia acumulada");
      toolTip1.SetToolTip(this.lbltxtfields7, "Indicar la inversión acumulada");
      toolTip1.SetToolTip(this.lbltxtfields8, "Indicar la inversión acumulada al mes anterior");
      toolTip1.SetToolTip(this.lbltxtfields9, "Indicar el impuesto acumulado");
      toolTip1.SetToolTip(this.label7, "Indicar el tipo de producción para las tablas");

      toolTip1.SetToolTip(this.cbofields1, "Seleccionar la Sucursal");
      toolTip1.SetToolTip(this.txtfields1, "Indicar el Código del Contrato");
      toolTip1.SetToolTip(this.txtfields2, "Indicar el Nombre del Contrato");
      toolTip1.SetToolTip(this.txtfields3, "Indicar el Periodo del Contrato");
      toolTip1.SetToolTip(this.dtpfields1, "Seleccionar una Fecha de Inicio de Contrato");
      toolTip1.SetToolTip(this.dtpfields2, "Seleccionar una Fecha de Fin de Contrato");
      toolTip1.SetToolTip(this.cbofields2, "Seleccionar Usuario");
      toolTip1.SetToolTip(this.txtfields4, "Indicar la depreciación acumulada");
      toolTip1.SetToolTip(this.txtfields5, "Indicar la depreciación acumulada al mes anterior");
      toolTip1.SetToolTip(this.txtfields6, "Indicar la ganancia acumulada");
      toolTip1.SetToolTip(this.txtfields7, "Indicar la inversión acumulada");
      toolTip1.SetToolTip(this.txtfields8, "Indicar la inversión acumulada al mes anterior");
      toolTip1.SetToolTip(this.txtfields9, "Indicar el impuesto acumulado");
      toolTip1.SetToolTip(this.cbxProduccion, "Indicar el tipo de producción para las tablas");

    }
    protected void CargarCombo()
    {
      cbofields1.DataSource = SucursalController.GetSucursales(0);
      cbofields1.DisplayMember = "suc_nombre";
      cbofields1.ValueMember = "suc_id";

      cbofields2.DataSource = UsuarioController.lstUsuariosByRol(0, 2);
      cbofields2.DisplayMember = "nombre_completo";
      cbofields2.ValueMember = "usu_id";
    }

    public void Buscar()
    {
      CargarCombo();
      ctt_id = frmContratoLista.ctt_id1;

      List<Contrato> lstContrato = new List<Contrato>();
      lstContrato = ContratoController.GetListContrato(ctt_id);
      if (lstContrato.Count != 0)
      {
        foreach (Contrato item in lstContrato)
        {
          txtfields1.Text = item.Ctt_codigo;
          txtfields2.Text = item.Ctt_nombre;
          txtfields3.Text = item.Ctt_periodo;
          dtpfields1.Value = Convert.ToDateTime(item.Ctt_fecini);
          dtpfields2.Value = Convert.ToDateTime(item.Ctt_fecfin);
          cbofields1.Text = item.Suc_id.ToString();
          if (UsuarioController.GetNombreCompleto(item.Usu_id) != null)
            cbofields2.Text = UsuarioController.GetNombreCompleto(item.Usu_id).Nombre_Completo;
          txtfields4.Text = item.Ctt_depacu.ToString();
          txtfields5.Text = item.Ctt_depacuma.ToString();
          txtfields6.Text = item.Ctt_acugantit.ToString();
          txtfields7.Text = item.Ctt_invacu.ToString();
          txtfields8.Text = item.Ctt_invacuma.ToString();
          txtfields9.Text = item.Ctt_acuimptit.ToString();
          txtfields10.Text = item.Ctt_lrc.ToString();
          txtfields11.Text = item.Ctt_vhiena.ToString();
          txtfields12.Text = item.Ctt_cmp.ToString();
          txtfields13.Text = item.Ctt_icpmp.ToString();
          txtfields14.Text = item.Ctt_pppvgnpf.ToString();
          txtfields15.Text = item.Ctt_pppvhlpf.ToString();
          txtcostrecuacu.Text = item.Ctt_costrecuacu.ToString();
          txtorden.Text = item.Ctt_orden.ToString();
          if (item.Ctt_produccion == -1)
          {
            cbxProduccion.SelectedIndex = 0;
          }
          else if (item.Ctt_produccion == 1)
          {
            cbxProduccion.SelectedIndex = 1;
          }
          else if (item.Ctt_produccion == 2)
          {
            cbxProduccion.SelectedIndex = 2;
          }


        }
        flagValidacion = true;
      }
      else
        flagValidacion = false;
    }

    protected bool ValidarCampos()
    {
      bool flag = false;
      if (string.IsNullOrWhiteSpace(txtfields1.Text.Trim()))
      {
        MessageBox.Show(this, "Registre el Código del Contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields1.Focus();
        return flag;
      }
      if (string.IsNullOrWhiteSpace(txtfields2.Text.Trim()))
      {
        MessageBox.Show(this, "Registre el Nombre del Contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields2.Focus();
        return flag;
      }
      if (string.IsNullOrWhiteSpace(txtfields3.Text.Trim()))
      {
        MessageBox.Show(this, "Registre el Periodo del Contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields3.Focus();
        return flag;
      }
      if (DateTime.Compare(dtpfields1.Value, dtpfields2.Value) >= 0)
      {
        MessageBox.Show(this, "La fecha de Fin de Contrato debe ser mayor a la fecha de inicio de contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        dtpfields2.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields4.Text))
      {
        MessageBox.Show(this, "Registre la Depreciación acumulada", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields4.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields5.Text))
      {
        MessageBox.Show(this, "Registre la Depreciación acumulada al mes anterior", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields5.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields6.Text))
      {
        MessageBox.Show(this, "Registre la ganancia acumulada", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields6.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields7.Text))
      {
        MessageBox.Show(this, "Registre la inversión acumulada", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields7.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields8.Text))
      {
        MessageBox.Show(this, "Registre la inversión acumulada al mes anterior", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields8.Focus();
        return flag;
      }
      if (string.IsNullOrEmpty(txtfields9.Text))
      {
        MessageBox.Show(this, "Registre el impuesto acumulado", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields9.Focus();
        return flag;
      }
      return flag = true;
    }

    protected void Guardar()
    {
      Session objSesion = new Session();
      long accion = 0;
      try
      {
        if (flagValidacion == true)//Actualizar
        {
          switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              List<Contrato> lstContrato = new List<Contrato>();
              Contrato datosContrato = new Contrato();
              datosContrato.Ctt_id = ctt_id;
              datosContrato.Suc_id = Convert.ToInt64(cbofields1.SelectedValue);
              datosContrato.Ctt_codigo = txtfields1.Text;
              datosContrato.Ctt_nombre = txtfields2.Text;
              datosContrato.Ctt_periodo = txtfields3.Text;
              datosContrato.Ctt_fecini = dtpfields1.Value;
              datosContrato.Ctt_fecfin = dtpfields2.Value;
              datosContrato.Ctt_estado = 1;
              datosContrato.Usu_id = Convert.ToInt32(cbofields2.SelectedValue);
              datosContrato.Ctt_depacu = Convert.ToDecimal(txtfields4.Text.Replace(",", "."));
              datosContrato.Ctt_depacuma = Convert.ToDecimal(txtfields5.Text.Replace(",", "."));
              datosContrato.Ctt_acugantit = Convert.ToDecimal(txtfields6.Text.Replace(",", "."));
              datosContrato.Ctt_invacu = Convert.ToDecimal(txtfields7.Text.Replace(",", "."));
              datosContrato.Ctt_invacuma = Convert.ToDecimal(txtfields8.Text.Replace(",", "."));
              datosContrato.Ctt_acuimptit = Convert.ToDecimal(txtfields9.Text.Replace(",", "."));
              datosContrato.Ctt_invneta = Convert.ToDecimal(0);
              datosContrato.Ctt_costrecuacu = Convert.ToDecimal(txtcostrecuacu.Text.Replace(",", "."));
              datosContrato.Ctt_orden = Convert.ToInt32(txtorden.Text);
              if (cbxProduccion.Text == "Ninguno")
              {
                datosContrato.Ctt_produccion = -1;
              }
              else if (cbxProduccion.Text == "Producción Gas")
              {
                datosContrato.Ctt_produccion = 1;
              }
              else if (cbxProduccion.Text == "Producción Crudo")
              {
                datosContrato.Ctt_produccion = 2;
              }


              datosContrato.Ctt_lrc = Convert.ToDecimal(txtfields10.Text.Replace(",", "."));
              datosContrato.Ctt_vhiena = Convert.ToDecimal(txtfields11.Text.Replace(",", "."));
              datosContrato.Ctt_cmp = Convert.ToInt64(txtfields12.Text.Replace(",", "."));
              datosContrato.Ctt_icpmp = Convert.ToDecimal(txtfields13.Text.Replace(",", "."));
              datosContrato.Ctt_pppvgnpf = Convert.ToDecimal(txtfields14.Text.Replace(",", "."));
              datosContrato.Ctt_pppvhlpf = Convert.ToDecimal(txtfields15.Text.Replace(",", "."));


              lstContrato.Add(datosContrato);
              Contrato contrato = new Contrato();
              accion = contrato.update(lstContrato);
              if (accion == 0)
              {
                MessageBox.Show(this, "Hubo error en la actualización ULTIMO", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
              List<Contrato> lstContrato = new List<Contrato>();
              Contrato datosContrato = new Contrato();
              datosContrato.Ctt_id = 0;
              datosContrato.Ctt_codigo = txtfields1.Text;
              datosContrato.Ctt_nombre = txtfields2.Text;
              datosContrato.Ctt_periodo = txtfields3.Text;
              datosContrato.Ctt_fecini = dtpfields1.Value;
              datosContrato.Ctt_fecfin = dtpfields2.Value;
              datosContrato.Ctt_estado = 1;
              datosContrato.Suc_id = Convert.ToInt64(cbofields1.SelectedValue);
              datosContrato.Usu_id = Convert.ToInt32(cbofields2.SelectedValue);
              datosContrato.Ctt_depacu = Convert.ToDecimal(txtfields4.Text.Replace(",", "."));
              datosContrato.Ctt_depacuma = Convert.ToDecimal(txtfields5.Text.Replace(",", "."));
              datosContrato.Ctt_acugantit = Convert.ToDecimal(txtfields6.Text.Replace(",", "."));
              datosContrato.Ctt_invacu = Convert.ToDecimal(txtfields7.Text.Replace(",", "."));
              datosContrato.Ctt_invacuma = Convert.ToDecimal(txtfields8.Text.Replace(",", "."));
              datosContrato.Ctt_acuimptit = Convert.ToDecimal(txtfields9.Text.Replace(",", "."));
              datosContrato.Ctt_invneta = Convert.ToDecimal(0);

              datosContrato.Ctt_lrc = Convert.ToDecimal(txtfields10.Text.Replace(",", "."));
              datosContrato.Ctt_vhiena = Convert.ToDecimal(txtfields11.Text.Replace(",", "."));
              datosContrato.Ctt_cmp = Convert.ToInt64(txtfields12.Text.Replace(",", "."));
              datosContrato.Ctt_icpmp = Convert.ToDecimal(txtfields13.Text.Replace(",", "."));
              datosContrato.Ctt_pppvgnpf = Convert.ToDecimal(txtfields14.Text.Replace(",", "."));
              datosContrato.Ctt_pppvhlpf = Convert.ToDecimal(txtfields15.Text.Replace(",", "."));
              datosContrato.Ctt_costrecuacu = Convert.ToDecimal(txtcostrecuacu.Text.Replace(",", "."));
              datosContrato.Ctt_orden = Convert.ToInt32(txtorden.Text);

              if (cbxProduccion.Text == "Ninguno")
              {
                datosContrato.Ctt_produccion = -1;
              }
              else if (cbxProduccion.Text == "Producción Gas")
              {
                datosContrato.Ctt_produccion = 1;
              }
              else if (cbxProduccion.Text == "Producción Crudo")
              {
                datosContrato.Ctt_produccion = 2;
              }

              lstContrato.Add(datosContrato);
              Contrato contrato = new Contrato();
              accion = contrato.insert(lstContrato);
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
      catch (Exception err)
      {
        MessageBox.Show(this, "Error en el registro " + err.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        Console.WriteLine("Error: " + err.Message);
      }

    }
    #endregion
  }
}