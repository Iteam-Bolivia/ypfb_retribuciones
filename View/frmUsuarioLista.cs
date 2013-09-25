using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
  public partial class frmUsuarioLista : Form
  {
    long usu_id;


    /// <summary>
    /// Method frmUsuarioLista
    /// </summary>
    public frmUsuarioLista()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Method frmUsuarioLista_Load
    /// </summary>
    private void frmUsuarioLista_Load(object sender, EventArgs e)
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
      usu_id = (long)celda.Value;
      Session objSession = new Session();
      objSession.ID = usu_id;
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
      usu_id = (long)celda.Value;

      // Edit
      Session objSession = new Session();
      objSession.ID = usu_id;

      // Edit Usuario
      frmUsuario childForm = new frmUsuario();
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
          frmUsuario childForm2 = new frmUsuario();
          childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
          childForm2.Show();
          break;

        case "cmdEdit":
          objSession.ID = usu_id;
          // Edit Usuario
          frmUsuario childForm = new frmUsuario();
          childForm.buscar();
          childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          childForm.Show();
          break;

        case "cmdDelete":
          switch (MessageBox.Show("Eliminar registro " + usu_id + " ?",
                                  "Validación del Sistema",
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              usu_id = objSession.ID;
              List<Usuario> lstUsuario = new List<Usuario>();
              List<Usuario> lstusuario2 = new List<Usuario>();
              UsuarioObject objUsuarioObject = new UsuarioObject();
              lstUsuario = objUsuarioObject.listUsuario(usu_id);
              if (lstUsuario.Count != 0)
              {
                lstUsuario.ForEach(delegate(Usuario u)
                {                  
                  lstusuario2.Add(new Usuario(u.Usu_id, u.Suc_id, u.Rol_id, u.Usu_nombres, u.Usu_apellidos, u.Usu_iniciales, u.Usu_fono, u.Usu_email, u.Usu_login, u.Usu_pass, u.Usu_intento, 0));
                });
                UsuarioController objUsuarioController2 = new UsuarioController();
                objUsuarioController2.update(lstusuario2);

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
          //frmUsuarioBusqueda childForm = new frmUsuarioBusqueda();
          //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
          //childForm.Show();
          //buscar();
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

      List<Usuario> lstUsuario = new List<Usuario>();

      UsuarioController objUsuarioController = new UsuarioController();
      lstUsuario = objUsuarioController.load();
      if (lstUsuario.Count == 0)
      {
        //MessageBox.Show("¡NO EXISTEN UsuarioS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        // DataTable
        DataTable table = new DataTable();
        Misc objMisc = new Misc();
        table = objMisc.GenericListToDataTable(lstUsuario);
        dataGridView1.DataSource = table;
        dataGridView1.Update();
        dataGridView1.Refresh();

      }
    }

    /// <summary>
    /// Method buscar
    /// </summary>
    private void buscar(List<Usuario> lstUsuario)
    {
      if (lstUsuario.Count == 0)
      {
        MessageBox.Show("¡NO EXISTEN UsuarioS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DataTable dt = new DataTable();
        Misc objMisc = new Misc();
        dt = objMisc.GenericListToDataTable(lstUsuario);
        dataGridView1.DataSource = dt;
      }
    }

  }
}
