using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using Controller;
using View;

namespace ypfbApplication.View
{
  public partial class frmCalculoVariableLista : Form
  {
    long ctt_id;
    long tcl_id;
    long mes2_id;
    long ani2_id;
    bool estadoDataGridView = true;

    // indicador para ajustar la altura de las celdas // al presentar inicialmente el DataGridView 

    /// <summary>
    /// Method frmCalculoVariableLista
    /// </summary>
    public frmCalculoVariableLista()
    {
      InitializeComponent();
      this.Width = Screen.PrimaryScreen.Bounds.Width;
    }

    /// <summary>
    /// Method frmCalculoVariableLista_Load
    /// </summary>
    private void frmCalculoVariableLista_Load(object sender, EventArgs e)
    {
      cargar();
    }

    

    /// <summary>
    /// Method dataGridView1_Click
    /// </summary>
    private void dataGridView1_Click(object sender, EventArgs e)
    {
      int row = 0;
      int cell = 0;
      DataGridViewCell celda;
      // Find Name of material
      row = dataGridView1.CurrentRow.Index;
      cell = dataGridView1.CurrentCell.ColumnIndex;
      celda = dataGridView1.Rows[row].Cells[0];
      ctt_id = (long)celda.Value;
      Session objSession = new Session();
      objSession.ID = ctt_id;
    }

    /// <summary>
    /// Method dataGridView1_DoubleClick
    /// </summary>
    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
      int row = 0;
      int cell = 0;
      DataGridViewCell celda;
      // Find Name of material
      row = dataGridView1.CurrentRow.Index;
      cell = dataGridView1.CurrentCell.ColumnIndex;
      celda = dataGridView1.Rows[row].Cells[0];
      ctt_id = (long)celda.Value;

      // Edit
      Session objSession = new Session();
      objSession.ID = ctt_id;

      // Edit Calculo_Variable
      frmCalculoManual childForm = new frmCalculoManual();
      childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
      childForm.Show();


    }


    /// <summary>
    /// Method dataGridView1_CellFormatting
    /// </summary>
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      try
      {
        if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[6].Value == "En revisión")
        {
          foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
          {
            celda.Style.BackColor = System.Drawing.Color.NavajoWhite;
          }
        }
      }
      catch (ArgumentOutOfRangeException)
      {
        Console.WriteLine("Un ArgumentOutOfRangeException ocurrió");
      }
    }






    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
      if (estadoDataGridView)
      {
        estadoDataGridView = false;
        this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
      }
    }
    private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
      this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
    }


    /// <summary>
    /// Method formatDataGridView
    /// </summary>
    private void formatDataGridView()
    {
      dataGridView1.AutoGenerateColumns = false;
    }

    /// <summary>
    /// Method toolBar1_ButtonClick
    /// </summary>
    private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      Session objSession = new Session();
      ToolBarButton button = e.Button;
      switch (button.Name)
      {
        case "cmdNew":
          objSession.ID = 0;
          frmCalculoManual childForm3 = new frmCalculoManual();
          childForm3.FormClosed += new FormClosedEventHandler(childForm3_FormClosed);
          childForm3.Show();
          break;

        case "cmdEdit":
          objSession.ID = ctt_id;
          // Edit Calculo_Variable
          frmCalculoManual childForm = new frmCalculoManual();
          childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm.Show();
          break;

        case "cmdDelete":
          switch (MessageBox.Show("Eliminar registro " + ctt_id + " ?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              ctt_id = objSession.ID;
              List<Calculo_Variable> lstCalculo = new List<Calculo_Variable>();
              List<Calculo_Variable> lstCalculo2 = new List<Calculo_Variable>();
              Calculo_VariableObject objCalculoObject = new Calculo_VariableObject();
              lstCalculo = objCalculoObject.listCalculoVariable(ctt_id);
              if (lstCalculo.Count != 0)
              {
                lstCalculo.ForEach(delegate(Calculo_Variable u)
                {
                  //lstCalculo2.Add(new Calculo_Variable(0, u.Suc_id, u.Rol_id, u.Usu_nombres, u.Usu_apellidos, u.Usu_iniciales, u.Usu_fono, u.Usu_email, u.Usu_login, u.Usu_pass, u.Usu_intento, 0));
                });
                Calculo_VariableController objCalculoController2 = new Calculo_VariableController();
                objCalculoController2.update(lstCalculo2);

                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cargar();
              }
              break;

            case DialogResult.No:
              // "No" processing
              break;
            case DialogResult.Cancel:
              // "Cancel" processing
              break;
          }
          break;

        case "cmdRefresh":
          cargar();
          break;

        case "cmdFind":
          //frmCalculoBusqueda childForm = new frmCalculoBusqueda();
          //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          //childForm.Show();
          //buscar();
          break;

        case "cmdPrint":
          break;
        case "cmdClose":
          this.Close();
          break;

        case "cmdCalculateManual":
          objSession.ID = 0;
          frmCalculoManual childForm2 = new frmCalculoManual();
          childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
          childForm2.Show();
         break;


        default:
          break;
      }

    }
    


    /// <summary>
    /// Method childForm_FormClosed
    /// </summary>
    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      cargar();
    }

    /// <summary>
    /// Method childForm2_FormClosed
    /// </summary>
    private void childForm2_FormClosed(object sender, FormClosedEventArgs e)
    {
      cargar();
    }


    /// <summary>
    /// Method childForm3_FormClosed
    /// </summary>
    private void childForm3_FormClosed(object sender, FormClosedEventArgs e)
    {
      cargar();
    }












    /// <summary>
    /// Method cargar
    /// </summary>
    private void cargar()
    {
      formatDataGridView();
      dataGridView1.Width = this.Width - 20;
      dataGridView1.Height = this.Height - 50;
      Session objSession = new Session();
      ctt_id = objSession.ID;
      tcl_id = objSession.TCL_ID;
      ani2_id = objSession.ANI_ID;
      mes2_id = objSession.MES_ID;


      List<Calculo_Variable> lstCalculo = new List<Calculo_Variable>();

      Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
      lstCalculo = objCalculoVariableController.load(ctt_id, tcl_id, ani2_id, mes2_id);
      if (lstCalculo.Count == 0)
      {
        //MessageBox.Show("¡NO EXISTEN CalculoS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        // DataTable
        DataTable table = new DataTable();
        Misc objMisc = new Misc();
        table = objMisc.GenericListToDataTable(lstCalculo);
        dataGridView1.DataSource = table;
        dataGridView1.Update();
        dataGridView1.Refresh();
      }
      this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
      dataGridView1.ClearSelection();
    }

    /// <summary>
    /// Method buscar
    /// </summary>
    private void buscar(List<Calculo_Variable> lstCalculo)
    {
      if (lstCalculo.Count == 0)
      {
        MessageBox.Show("¡NO EXISTEN CalculoS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DataTable dt = new DataTable();
        Misc objMisc = new Misc();
        dt = objMisc.GenericListToDataTable(lstCalculo);
        dataGridView1.DataSource = dt;
      }
    }



  

  }
}
