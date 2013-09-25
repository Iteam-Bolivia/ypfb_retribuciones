using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
  public partial class frmDepartamentoLista : Form
  {
    long dep_id;

    /// <summary>
    /// Method frmDepartamentoLista
    /// </summary>
    public frmDepartamentoLista()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmDepartamentoLista_Load
    /// </summary>
    private void frmDepartamentoLista_Load(object sender, EventArgs e)
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
      dep_id = (long)celda.Value;
      Session objSession = new Session();
      objSession.ID = dep_id;
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
      dep_id = (long)celda.Value;

      // Edit
      Session objSession = new Session();
      objSession.ID = dep_id;

      // Edit Departamento
      frmDepartamento childForm = new frmDepartamento();
      childForm.buscar();
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
          frmDepartamento childForm2 = new frmDepartamento();
          childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
          childForm2.Show();
          break;

        case "cmdEdit":
          objSession.ID = dep_id;
          // Edit Departamento
          frmDepartamento childForm = new frmDepartamento();
          childForm.buscar();
          childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm.Show();
          break;

        case "cmdDelete":
          switch (MessageBox.Show("Eliminar registro " + dep_id + " ?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              dep_id = objSession.ID;
              List<Departamento> lstDepartamento = new List<Departamento>();
              List<Departamento> lstdepartamento2 = new List<Departamento>();
              DepartamentoObject objDepartamentoObject = new DepartamentoObject();
              lstDepartamento = objDepartamentoObject.listDepartamento(dep_id);
              if (lstDepartamento.Count != 0)
              {
                lstDepartamento.ForEach(delegate(Departamento u)
                {                  
                  lstdepartamento2.Add(new Departamento(u.Dep_id, u.Dep_codigo, u.Dep_nombre,0));
                });
                DepartamentoController objDepartamentoController2 = new DepartamentoController();
                objDepartamentoController2.update(lstdepartamento2);

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
          break;

        case "cmdPrint":
          break;
        case "cmdClose":
          this.Close();
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
    /// Method cargar
    /// </summary>
    private void cargar()
    {
      formatDataGridView();
      dataGridView1.Width = this.Width - 20;
      dataGridView1.Height = this.Height - 50;

      List<Departamento> lstDepartamento = new List<Departamento>();

      DepartamentoController objDepartamentoController = new DepartamentoController();
      lstDepartamento = objDepartamentoController.load();
      if (lstDepartamento.Count == 0)
      {
        //MessageBox.Show("¡NO EXISTEN DepartamentoS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        // DataTable
        DataTable table = new DataTable();
        Misc objMisc = new Misc();
        table = objMisc.GenericListToDataTable(lstDepartamento);
        dataGridView1.DataSource = table;
        dataGridView1.Update();
        dataGridView1.Refresh();

      }
    }

    /// <summary>
    /// Method buscar
    /// </summary>
    private void buscar(List<Departamento> lstDepartamento)
    {
      if (lstDepartamento.Count == 0)
      {
        MessageBox.Show("¡NO EXISTEN DepartamentoS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DataTable dt = new DataTable();
        Misc objMisc = new Misc();
        dt = objMisc.GenericListToDataTable(lstDepartamento);
        dataGridView1.DataSource = dt;
      }
    }

  }
}
