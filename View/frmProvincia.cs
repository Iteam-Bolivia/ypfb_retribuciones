using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
  public partial class frmProvincia : Form
  {
    bool flag = false;
    bool flag1 = false;
    long dep_id = 0;
    long pro_id = 0;
    

    public frmProvincia()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmProvincia_Load
    /// </summary>
    private void frmProvincia_Load(object sender, EventArgs e)
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
    {
      e.KeyChar = Char.ToUpper(e.KeyChar);     
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
        List<Departamento> lstDepartamento = new List<Departamento>();
        DepartamentoObject objDepartamentoObject = new DepartamentoObject();
        lstDepartamento = objDepartamentoObject.listDepartamento(0);
        if (lstDepartamento.Count == 0)
        {
          cbofields1.Items.Clear();
        }
        else
        {
          //cbofields1.Items.Clear();
          cbofields1.DataSource = lstDepartamento;
          cbofields1.DisplayMember = "dep_nombre";
          cbofields1.ValueMember = "dep_id";
          cbofields1.SelectedIndex = 0;
        }
      }

      
      ToolTip toolTip1 = new ToolTip();
      toolTip1.IsBalloon = true;
      toolTip1.ToolTipTitle = "Ayuda";
      toolTip1.UseFading = true;
      toolTip1.UseAnimation = true;

      toolTip1.SetToolTip(this.lblcbofields1, "Escoger el Departamento");
      toolTip1.SetToolTip(this.cbofields1, "Escoger el Departamento");

      toolTip1.SetToolTip(this.lbltxtfields1, "Indicar codigo provincia");
      toolTip1.SetToolTip(this.txtfields2, "Indicar codigo provincia");

      toolTip1.SetToolTip(this.lbltxtfields2, "Indicar el provincia");
      toolTip1.SetToolTip(this.txtfields3, "Indicar el provincia");

      
      

    }


    /// <summary>
    /// Method nuevo
    /// </summary>
    public void nuevo()
    {
      cbofields1.Text = "";
      txtfields2.Text = "";
      txtfields3.Text = "";


      List<Departamento> lstDepartamento = new List<Departamento>();
      DepartamentoObject objDepartamentoObject = new DepartamentoObject();
      lstDepartamento = objDepartamentoObject.listDepartamento(0);
      if (lstDepartamento.Count == 0)
      {
        cbofields1.Items.Clear();
      }
      else
      {
        cbofields1.Items.Clear();
        cbofields1.DataSource = lstDepartamento;
        cbofields1.DisplayMember = "dep_nombre";
        cbofields1.ValueMember = "dep_id";
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
      pro_id = objSession.ID;

      List<Departamento> lstDepartamento = new List<Departamento>();
      DepartamentoObject objDepartamentoObject = new DepartamentoObject();
      lstDepartamento = objDepartamentoObject.listDepartamento(0);
      if (lstDepartamento.Count == 0)
      {
        cbofields1.Items.Clear();
      }
      else
      {
        //cbofields1.Items.Clear();
        cbofields1.DataSource = lstDepartamento;
        cbofields1.DisplayMember = "dep_nombre";
        cbofields1.ValueMember = "dep_id";
        cbofields1.SelectedIndex = 0;

      }

      List<Provincia> lstProvincia = new List<Provincia>();
      ProvinciaObject objProvinciaObject = new ProvinciaObject();
      lstProvincia = objProvinciaObject.listProvincia(pro_id);
      
      if (lstProvincia.Count != 0)
      {
        lstProvincia.ForEach(delegate(Provincia u)
        {
          txtfields2.Text = u.Pro_codigo;
          txtfields3.Text = u.Pro_nombre;
          cbofields1.SelectedValue = u.Dep_id;
          //cbofields1.SelectedIndex = cbofields1.FindString(u.Dep_nombre, -1);
          
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
        MessageBox.Show("Registre el Nombre del Departamento", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        cbofields1.Focus();
        return flag2;
      }
      if (txtfields2.Text == "")
      {
        MessageBox.Show("Registre el Codigo de la Provincia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields2.Focus();
        return flag2;
      }
      if (txtfields3.Text == "")
      {
        MessageBox.Show("Registre el Nombre de la Provincia", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields3.Focus();
        return flag2;
      }

      var v_dep_id = cbofields1.SelectedValue;
      //var v_rol_id = cbofields2.SelectedValue;

      dep_id = System.Convert.ToInt64(v_dep_id);
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
              List<Provincia> lstProvincia = new List<Provincia>();
              Provincia provincia = new Provincia();
              provincia.Pro_id = System.Convert.ToInt64(pro_id);
              provincia.Dep_id = System.Convert.ToInt64(dep_id);
              provincia.Pro_codigo = System.Convert.ToString(txtfields2.Text);
              provincia.Pro_nombre = System.Convert.ToString(txtfields3.Text);
              provincia.Pro_estado = System.Convert.ToInt64(1);
              lstProvincia.Add(provincia);

              // Save data from Provincia
              Provincia objProvincia = new Provincia();
              inserted = objProvincia.update(lstProvincia);
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
              List<Provincia> lstProvincia = new List<Provincia>();
              Provincia provincia = new Provincia();
              provincia.Pro_id = System.Convert.ToInt64(0);
             provincia.Dep_id = System.Convert.ToInt64(dep_id);
              provincia.Pro_codigo = System.Convert.ToString(txtfields2.Text);
              provincia.Pro_nombre = System.Convert.ToString(txtfields3.Text);
              provincia.Pro_estado = System.Convert.ToInt64(1);
              lstProvincia.Add(provincia);

              // Save data from Provincia
              Provincia objProvincia = new Provincia();
              inserted = objProvincia.insert(lstProvincia);
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

    private void cbofields1_KeyPress(object sender, KeyPressEventArgs e)
    {

    }



  }
}