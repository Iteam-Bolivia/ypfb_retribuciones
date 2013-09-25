using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using Controller;
using System.Drawing;

namespace ypfbApplication.View
{
  public partial class frmVariableLista : Form
  {
    long var_id = 0;
    bool estadoDataGridView = true;
    List<Variable> listaVariable;

    private Rectangle dragBoxSrc;
    private int rowIndexSrc;
    private int rowIndexTar;
    DataGridView dgv;


    /// <summary>
    /// Method frmVariableLista
    /// </summary>
    public frmVariableLista()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmVariableLista_Load
    /// </summary>
    private void frmVariableLista_Load(object sender, EventArgs e)
    {
      dgv = dataGridView1;
      cargar(listaVariable);
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
      if (dataGridView1.CurrentRow.Index > 0)
      {
          row = dataGridView1.CurrentRow.Index;
          cell = dataGridView1.CurrentCell.ColumnIndex;
          celda = dataGridView1.Rows[row].Cells[0];
          var_id = (long)celda.Value;
          Session objSession = new Session();
          objSession.ID = var_id;
      }
      toolBar1.Buttons[1].Enabled = false;
      toolBar1.Buttons[1].Enabled = true;
      toolBar1.Buttons[2].Enabled = true;
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
      if (dataGridView1.Rows.Count > 0)
      {
          row = dataGridView1.CurrentRow.Index;
          cell = dataGridView1.CurrentCell.ColumnIndex;
          celda = dataGridView1.Rows[row].Cells[0];
          var_id = (long)celda.Value;
      }
      // Edit
      Session objSession = new Session();
      objSession.ID = var_id;

      toolBar1.Buttons[0].Enabled = true;
      toolBar1.Buttons[1].Enabled = true;
      toolBar1.Buttons[2].Enabled = true;
      
      // Edit Variable
      frmVariable childForm = new frmVariable();
      childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
      childForm.ShowDialog();
    }


    /// <summary>
    /// Method dataGridView1_CellFormatting
    /// </summary>
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      try
      {

        if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "RETRIBUCIÓN RECÁLCULO" || (String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "RECÁLCULO")
        {
          foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
          {
            if (celda.ColumnIndex == 1)
            {
              celda.Style.BackColor = System.Drawing.Color.AliceBlue;
            }
          }
        }

        if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "TODOS LOS CÁLCULOS" || (String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "TODOS")
        {
          foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
          {
            if (celda.ColumnIndex == 1)
            {
              celda.Style.BackColor = System.Drawing.Color.Azure;
            }
          }
        }

        if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "RETRIBUCIÓN A CUENTA" || (String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "A CUENTA")
        {
          foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
          {
            if (celda.ColumnIndex == 1)
            {
              celda.Style.BackColor = System.Drawing.Color.LightCyan;
            }
          }
        }


        if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value == "PROYECCIONES")
        {
            foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
            {
                if (celda.ColumnIndex == 1)
                {
                    celda.Style.BackColor = System.Drawing.Color.AliceBlue;
                }
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




    /**/

    // Drag && Drop
    // Drag && Drop
    private bool IsCellOrRowHeader(int x, int y)
    {
      DataGridViewHitTestType dgt = dgv.HitTest(x, y).Type;
      return (dgt == DataGridViewHitTestType.Cell ||
              dgt == DataGridViewHitTestType.RowHeader);
    }

    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        if (!IsCellOrRowHeader(e.X, e.Y) && rowIndexSrc >= 0)
        {
          DragDropEffects dropEffect = dgv.DoDragDrop(
            dgv.Rows[rowIndexSrc], DragDropEffects.None);
          return;
        }

        if (dragBoxSrc != Rectangle.Empty &&
            !dragBoxSrc.Contains(e.X, e.Y))
        {
          DragDropEffects dropEffect = dgv.DoDragDrop(
            dgv.Rows[rowIndexSrc], DragDropEffects.Move);
        }
      }
    }

    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
      rowIndexSrc = dgv.HitTest(e.X, e.Y).RowIndex;
      if (rowIndexSrc != -1)
      {
        Size dragSize = SystemInformation.DragSize;
        dragBoxSrc = new Rectangle(new Point(e.X, e.Y), dragSize);
      }
      else
        dragBoxSrc = Rectangle.Empty;
    }

    private void dataGridView1_DragDrop(object sender, DragEventArgs e)
    {
      Point clientPoint = dgv.PointToClient(new Point(e.X, e.Y));
      rowIndexTar = dgv.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
      if (e.Effect == DragDropEffects.Move)
      {
        DataGridViewRow rowToMove = e.Data.GetData(
          typeof(DataGridViewRow)) as DataGridViewRow;
        MoveRow(rowIndexSrc, rowIndexTar);
      }
    }

    void SwapCell(int c, int srcRow, int tarRow, out object tmp0, out object tmp1)
    {
      DataGridViewCell srcCell = dgv.Rows[srcRow].Cells[c];
      DataGridViewCell tarCell = dgv.Rows[tarRow].Cells[c];
      tmp0 = tarCell.Value;
      tmp1 = srcCell.Value;
      tarCell.Value = tmp1;
    }

    void MoveRow(int srcRow, int tarRow)
    {
      int cellCount = dgv.Rows[srcRow].Cells.Count;
      for (int c = 0; c < cellCount; c++)
        ShiftRows(srcRow, tarRow, c);
    }

    private void ShiftRows(int srcRow, int tarRow, int c)
    {
      object tmp0, tmp1;
      SwapCell(c, srcRow, tarRow, out tmp0, out tmp1);
      int delta = tarRow < srcRow ? 1 : -1;
      for (int r = tarRow + delta; r != srcRow + delta; r += delta)
      {
        tmp1 = dgv.Rows[r].Cells[c].Value;
        dgv.Rows[r].Cells[c].Value = tmp0;
        tmp0 = tmp1;
      }
      dgv.Rows[tarRow].Selected = true;
      //dgv.CurrentCell = dgv.Rows[tarRow].Cells[0];
      dgv.CurrentCell = dgv.Rows[tarRow].Cells[1];
    }

    private void dataGridView1_DragOver(object sender, DragEventArgs e)
    {
      Point p = dgv.PointToClient(new Point(e.X, e.Y));
      DataGridViewHitTestType dgt = dgv.HitTest(p.X, p.Y).Type;
      if (IsCellOrRowHeader(p.X, p.Y))
        e.Effect = DragDropEffects.Move;
      else e.Effect = DragDropEffects.None;
    }


    /**/





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
          frmVariable childForm2 = new frmVariable();
          childForm2.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm2.ShowDialog();
          break;

        case "cmdEdit":
          objSession.ID = var_id;
          // Edit Variable
          frmVariable childForm = new frmVariable();
          childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm.ShowDialog();
          break;

        case "cmdDelete":
          switch (MessageBox.Show("Eliminar registro " + var_id + " ?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              var_id = objSession.ID;
              List<Variable> lstVariable = new List<Variable>();
              List<Variable> lstVariable2 = new List<Variable>();
              VariableObject objVariableObject = new VariableObject();
              lstVariable = objVariableObject.listVariable(var_id);
              if (lstVariable.Count != 0)
              {
                lstVariable.ForEach(delegate(Variable v)
                {
                  lstVariable2.Add(new Variable(v.Var_id, v.Var_codigo, v.Var_nombre, v.Var_tipo, 0, 0));
                });
                VariableController objVariableController2 = new VariableController();
                objVariableController2.edit(lstVariable2);

                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cargar(lstVariable);
              }
              break;
          }
          break;

        case "cmdRefresh":
          frmVariableLista_Load(sender, e);
          break;

        case "cmdTotales":
          cargarTotal(0);
          break;

        case "cmdFind":
          frmVariableBusqueda childForm4 = new frmVariableBusqueda();
          childForm4.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm4.ShowDialog();

          break;

        case "cmdPrint":
          break;

        case "cmdClose":
          this.Close();
          break;


        case "cmdFormula":
          objSession.ID = var_id;
          // Edit Variable
          frmFormula childForm3 = new frmFormula();
          childForm3.buscar();
          childForm3.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm3.ShowDialog();
          break;


        case "cmdOrden":
          ordenar();
          break;


        default:
          break;
      }
    }


    /// <summary>
    /// Method childForm4_FormClosed
    /// </summary>
    private void childForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      //Cargar();
      if (frmVariableBusqueda.flagBusqueda == 0)
      {
        cargar(listaVariable);
        frmVariableBusqueda.flagBusqueda = 0;
        frmVariableBusqueda.listaVariables = null;
      }
      else
      {
        cargar(frmVariableBusqueda.listaVariables);
        frmVariableBusqueda.flagBusqueda = 0;
        frmVariableBusqueda.listaVariables = null;
      }
    }











    /// <summary>
    /// Method cargar
    /// </summary>
    private void cargar(List<Variable> listaVariables)
    {
      Session objSession = new Session();
      this.Text = this.Text + " - " + objSession.SISTEMA;  

      dataGridView1.AutoGenerateColumns = false;
      dataGridView1.Width = this.Width - 20;
      dataGridView1.Height = this.Height - 50;

      if (listaVariables == null)
      {
        listaVariables = new List<Variable>();
        VariableController objVariableController = new VariableController();
        listaVariables = objVariableController.list(0);
      }
      DataTable table = null;

      if (listaVariables.Count != 0)
      {
        table = new DataTable();
        Misc objMisc = new Misc();
        table = objMisc.GenericListToDataTable(listaVariables);
      }
      toolBar1.Buttons[1].Enabled = false;
      toolBar1.Buttons[2].Enabled = false;
      dataGridView1.DataSource = table;
      
      // Comented 
      this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
      dataGridView1.ClearSelection();
    }



    /// <summary>
    /// Method cargar
    /// </summary>
    private void cargarTotal(long var_id)
    {
      List<Variable> listaVariables = new List<Variable>();
      dataGridView1.AutoGenerateColumns = false;
      dataGridView1.Width = this.Width - 20;
      dataGridView1.Height = this.Height - 50;

      listaVariables = new List<Variable>();
      VariableController objVariableController = new VariableController();
      listaVariables = objVariableController.listTotal(var_id);

      DataTable table = null;

      if (listaVariables.Count != 0)
      {
        table = new DataTable();
        Misc objMisc = new Misc();
        table = objMisc.GenericListToDataTable(listaVariables);
      }
      toolBar1.Buttons[1].Enabled = false;
      toolBar1.Buttons[2].Enabled = false;
      dataGridView1.DataSource = table;

      // Comented 
      this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
      dataGridView1.ClearSelection();
    }




    /// <summary>
    /// Method buscar
    /// </summary>
    private void buscar(List<Variable> lstVariable)
    {
      if (lstVariable.Count == 0)
      {
        MessageBox.Show("¡NO EXISTEN VariableS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DataTable dt = new DataTable();
        Misc objMisc = new Misc();
        dt = objMisc.GenericListToDataTable(lstVariable);
        dataGridView1.DataSource = dt;
      }
    }


    /// <summary>
    /// Method ordenar
    /// </summary>
    private void ordenar()
    {

      Int32 i;
      long var_id;
      long updated = 0;
      DataGridViewCell dgc;


      // hourglass cursor
      Cursor.Current = Cursors.WaitCursor;
      //Recorremos el DataGridView con un bucle for
      for (i = 0; i < dataGridView1.Rows.Count; i++)
      {
        // Columna 0
        dgc = dataGridView1.Rows[i].Cells[0];
        var_id = System.Convert.ToInt64(dgc.Value);


        // Fill data      
        List<Variable> lstVariable = new List<Variable>();
        List<Variable> lstVariable2 = new List<Variable>();
        lstVariable = VariableController.GetListaVariable(var_id);

        if (lstVariable.Count != 0)
        {
          lstVariable.ForEach(delegate(Variable v)
          {
            Variable variable = new Variable();
            variable.Var_id = System.Convert.ToInt64(v.Var_id);
            variable.Var_codigo = System.Convert.ToString(v.Var_codigo);
            variable.Var_nombre = System.Convert.ToString(v.Var_nombre);
            variable.Var_tipo = System.Convert.ToString(v.Var_tipo);
            variable.Var_valini = System.Convert.ToDecimal(v.Var_valini);
            variable.Var_estado = System.Convert.ToInt64(v.Var_estado);
            variable.Var_orden = System.Convert.ToInt64(i+1);
            variable.Umd_id = System.Convert.ToInt64(v.Umd_id);
            variable.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
            variable.Var_impresion = System.Convert.ToInt64(v.Var_impresion);
            variable.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
            variable.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
            variable.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
            variable.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
            variable.Mer_id = System.Convert.ToInt64(v.Mer_id);
            variable.Pro_id = System.Convert.ToInt64(v.Pro_id);
            variable.Var_codigod = System.Convert.ToString(v.Var_codigod);
            variable.Var_total = System.Convert.ToString(v.Var_total);
            variable.Vard_id = System.Convert.ToInt64(v.Vard_id);
            variable.Var_tipo_cal = System.Convert.ToInt64(v.Var_tipo_cal);
            variable.Var_posicion = System.Convert.ToInt64(v.Var_posicion);
            variable.Cam_id = Convert.ToInt64(v.Cam_id);
            lstVariable2.Add(variable);
          });


          // Save data from Variable
          VariableController objVariableController = new VariableController();
          updated = objVariableController.edit(lstVariable2);
          if (updated == 0)
          {
            MessageBox.Show("Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }

        }
      }
      cargar(listaVariable);
      // default cursor
      Cursor.Current = Cursors.Default;
    }

    // Colorear DataGridView
    private void ColorearFilaDGV(DataGridView DGV, int Fila, System.Drawing.Color fondo)
    {
      foreach (DataGridViewCell celda in DGV.Rows[Fila].Cells)
      {
        celda.Style.BackColor = fondo;
      }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
