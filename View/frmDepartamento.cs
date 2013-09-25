using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
  public partial class frmDepartamento : Form
  {
    bool flag = false;
    long dep_id = 0;

    public frmDepartamento()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmDepartamento_Load
    /// </summary>
    private void frmDepartamento_Load(object sender, EventArgs e)
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
    /// Method txtfields3_KeyPress
    /// </summary>
    private void txtfields2_KeyPress(object sender,
                        System.Windows.Forms.KeyPressEventArgs e)
    {
      e.KeyChar = char.ToUpper(e.KeyChar);     
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
    private void cargar()
    {

      ToolTip toolTip1 = new ToolTip();
      toolTip1.IsBalloon = true;
      toolTip1.ToolTipTitle = "Ayuda";
      toolTip1.UseFading = true;
      toolTip1.UseAnimation = true;

      toolTip1.SetToolTip(this.lbltxtfields1, "Indicar código departamento");
      toolTip1.SetToolTip(this.txtfields1, "Indicar código departamento");

      toolTip1.SetToolTip(this.lbltxtfields2, "Indicar departamento");
      toolTip1.SetToolTip(this.txtfields2, "Indicar departamento");
      
    }


    /// <summary>
    /// Method nuevo
    /// </summary>
    public void nuevo()
    {
      txtfields1.Text = "";
      txtfields2.Text = "";
      
      }


    /// <summary>
    /// Method buscar
    /// </summary>
    public void buscar()
    {
      Session objSession = new Session();
      dep_id = objSession.ID;

      List<Departamento> lstDepartamento = new List<Departamento>();
      DepartamentoObject objDepartamentoObject = new DepartamentoObject();
      lstDepartamento = objDepartamentoObject.listDepartamento(dep_id);
      if (lstDepartamento.Count != 0)
      {
        lstDepartamento.ForEach(delegate(Departamento u)
        {
          txtfields1.Text = u.Dep_codigo;
          txtfields2.Text = u.Dep_nombre;
          
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
      if (txtfields1.Text == "")
      {
        MessageBox.Show("Registre el codigo del Departamento", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields1.Focus();
        return flag2;
      }
      if (txtfields2.Text == "")
      {
        MessageBox.Show("Registre el Departamento", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtfields2.Focus();
        return flag2;
      }
      

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
              List<Departamento> lstproyecto = new List<Departamento>();
              Departamento departamento = new Departamento();
              departamento.Dep_id = System.Convert.ToInt64(dep_id);
              departamento.Dep_codigo = System.Convert.ToString(txtfields1.Text);
              departamento.Dep_nombre = System.Convert.ToString(txtfields2.Text);
              departamento.Dep_estado = System.Convert.ToInt64(1);
              lstproyecto.Add(departamento);
              // Save data from Departamento
              Departamento objDepartamento = new Departamento();
              inserted = objDepartamento.update(lstproyecto);
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
             List<Departamento> lstproyecto = new List<Departamento>();
             Departamento departamento = new Departamento();
             departamento.Dep_id = System.Convert.ToInt64(0);
             departamento.Dep_codigo = System.Convert.ToString(txtfields1.Text);
             departamento.Dep_nombre = System.Convert.ToString(txtfields2.Text);
             departamento.Dep_estado = System.Convert.ToInt64(1);
             lstproyecto.Add(departamento);
              // Save data from Departamento
              Departamento objDepartamento = new Departamento();
              inserted = objDepartamento.insert(lstproyecto);
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