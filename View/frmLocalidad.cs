using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
  public partial class frmLocalidad : Form
  {
    bool flag = false;
    bool flag1 = false;
    long pro_id = 0;
    long loc_id = 0;
    

    public frmLocalidad()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmLocalidad_Load
    /// </summary>
    private void frmLocalidad_Load(object sender, EventArgs e)
    {
      cargar();
    }

    /* View */
    /// <summary>
    /// Method txtfields1_KeyPress
    /// </summary>   
    private void txtfields1_KeyPress(object sender,
                        System.Windows.Forms.KeyPressEventArgs e)
    {
      e.KeyChar = Char.ToUpper(e.KeyChar);
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }

    /// <summary>
    /// Method txtfields2_KeyPress
    /// </summary>
    private void txtfields2_KeyPress(object sender,
                        System.Windows.Forms.KeyPressEventArgs e)
    {
      e.KeyChar = Char.ToUpper(e.KeyChar);
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }

    /// <summary>
    /// Method txtfields3_KeyPress
    /// </summary>
    private void txtfields3_KeyPress(object sender,
                        System.Windows.Forms.KeyPressEventArgs e)
    {  e.KeyChar = Char.ToUpper(e.KeyChar);    
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
      
    }

    /// <summary>
    /// Method txtfields3_KeyPress
    /// </summary>
    private void cbofields1_KeyPress(object sender,
                        System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }

    }


    
    /// <summary>
    /// Method btnGuardar_Click
    /// </summary>
    private void btnGuardar_Click(object sender, EventArgs e)
    {
      guardar();
    }

    /// <summary>
    /// Method btnCancelar_Click
    /// </summary>
    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }





    /// Controller
    /// <summary>
    /// Method cargar
    /// </summary>
    public void cargar()
    {
      if (!flag1)
      {
        List<Provincia> lstProvincia = new List<Provincia>();
        ProvinciaObject objProvinciaObject = new ProvinciaObject();
        lstProvincia = objProvinciaObject.listProvincia(0);
        if (lstProvincia.Count == 0)
        {
          cbofields1.Items.Clear();
        }
        else
        {
          cbofields1.Items.Clear();
          cbofields1.DataSource = lstProvincia;
          cbofields1.DisplayMember = "pro_nombre";
          cbofields1.ValueMember = "pro_id";
          cbofields1.SelectedIndex = 0;
        }
      }

      ToolTip toolTip1 = new ToolTip();
      toolTip1.IsBalloon = true;
      toolTip1.ToolTipTitle = "Ayuda";
      toolTip1.UseFading = true;
      toolTip1.UseAnimation = true;

      toolTip1.SetToolTip(this.lblcbofields1, "Escoger la Provincia");
      toolTip1.SetToolTip(this.cbofields1, "Escoger la Provincia");

      toolTip1.SetToolTip(this.lbltxtfields1, "Indicar codigo localidad");
      toolTip1.SetToolTip(this.txtfields2, "Indicar codigo localidad");

      toolTip1.SetToolTip(this.lbltxtfields2, "Indicar la localidad");
      toolTip1.SetToolTip(this.txtfields3, "Indicar la localidad");

     // buscar();
      
    }


    /// <summary>
    /// Method nuevo
    /// </summary>
    public void nuevo()
    {
      cbofields1.Text = "";
      txtfields2.Text = "";
      txtfields3.Text = "";


      List<Provincia> lstProvincia = new List<Provincia>();
      ProvinciaObject objProvinciaObject = new ProvinciaObject();
      lstProvincia = objProvinciaObject.listProvincia(0);
      if (lstProvincia.Count == 0)
      {
        cbofields1.Items.Clear();
      }
      else
      {
        cbofields1.Items.Clear();
        cbofields1.DataSource = lstProvincia;
        cbofields1.DisplayMember = "pro_nombre";
        cbofields1.ValueMember = "pro_id";
        cbofields1.SelectedIndex = 0;
      }

      

    }


    /// <summary>
    /// Method buscar
    /// </summary>
    public void buscar()
    {
      flag1 = true;
      Session objSession = new Session();
      loc_id = objSession.ID;

      List<Provincia> lstProvincia = new List<Provincia>();
      ProvinciaObject objProvinciaObject = new ProvinciaObject();
      lstProvincia = objProvinciaObject.listProvincia(0);
      if (lstProvincia.Count == 0)
      {
        cbofields1.Items.Clear();
      }
      else
      {
        cbofields1.Items.Clear();
        cbofields1.DataSource = lstProvincia;
        cbofields1.DisplayMember = "pro_nombre";
        cbofields1.ValueMember = "pro_id";
        cbofields1.SelectedIndex = 0;
      }

      List<Localidad> lstLocalidad = new List<Localidad>();
      LocalidadObject objLocalidadObject = new LocalidadObject();
      lstLocalidad = objLocalidadObject.listLocalidad(loc_id);
      if (lstLocalidad.Count != 0)
      {
        lstLocalidad.ForEach(delegate(Localidad u)
        {
          txtfields2.Text = u.Loc_codigo;
          txtfields3.Text = u.Loc_nombre;
          cbofields1.SelectedValue = u.Pro_id;
          //cbofields1.SelectedIndex = cbofields1.FindString(u.Pro_nombre, -1);          
        });
        flag = true;
      }
    }

    /// <summary>
    /// Method validarCampos
    /// </summary>
    private bool validarCampos()
    {
      bool flag2 = false;
      if (cbofields1.Text == "")
      {
        MessageBox.Show("Registre el Nombre de la Provincia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        cbofields1.Focus();
        return flag2;
      }
      if (txtfields2.Text == "")
      {
        MessageBox.Show("Registre el Codigo de la Localidad", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields2.Focus();
        return flag2;
      }
      if (txtfields3.Text == "")
      {
        MessageBox.Show("Registre el Nombre de la Localidad", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields3.Focus();
        return flag2;
      }

      var v_pro_id = cbofields1.SelectedValue;
      //var v_rol_id = cbofields2.SelectedValue;

      pro_id = System.Convert.ToInt64(v_pro_id);
      //rol_id = System.Convert.ToInt64(v_rol_id);


      flag2 = true;
      return flag2;
    }


    /// <summary>
    /// Method guardar
    /// </summary>
    private void guardar()
    {
      long inserted = 0;

      if (validarCampos())
      {
        if (flag == true)
        {
          switch (MessageBox.Show("Actualizar registro?",
                        "Validación del Sistema",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              // Fill data      
              List<Localidad> lstLocalidad = new List<Localidad>();
              Localidad localidad = new Localidad();
              localidad.Loc_id = System.Convert.ToInt64(loc_id);
              localidad.Pro_id = System.Convert.ToInt64(pro_id);
              localidad.Loc_codigo = System.Convert.ToString(txtfields2.Text);
              localidad.Loc_nombre = System.Convert.ToString(txtfields3.Text);
              localidad.Loc_estado = System.Convert.ToInt64(1);
              lstLocalidad.Add(localidad);

              // Save data from Localidad
              Localidad objLocalidad = new Localidad();
              inserted = objLocalidad.update(lstLocalidad);
              if (inserted == 0)
              {
                MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
              }
              else
              {
                MessageBox.Show("Se actualizó registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
              }
              flag = false;

              break;
            case DialogResult.No:
              // "No" processing
              break;
            case DialogResult.Cancel:
              // "Cancel" processing
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

              // Fill data      
              List<Localidad> lstLocalidad = new List<Localidad>();
              Localidad localidad = new Localidad();
              localidad.Loc_id = System.Convert.ToInt64(0);
             localidad.Pro_id = System.Convert.ToInt64(pro_id);
              localidad.Loc_codigo = System.Convert.ToString(txtfields2.Text);
              localidad.Loc_nombre = System.Convert.ToString(txtfields3.Text);
              localidad.Loc_estado = System.Convert.ToInt64(1);
              lstLocalidad.Add(localidad);

              // Save data from Localidad
              Localidad objLocalidad = new Localidad();
              inserted = objLocalidad.insert(lstLocalidad);
              if (inserted == 0)
              {
                MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
              else
              {
                MessageBox.Show("Se registró con exito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
              }
              
              break;

            case DialogResult.No:
              // "No" processing
              break;

            case DialogResult.Cancel:
              // "Cancel" processing
              break;
          }
        }
      }
      else
      {
      }
    }

 


  }
}