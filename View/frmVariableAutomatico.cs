using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;
using System.Drawing;

namespace ypfbApplication.View
{
  public partial class frmVariableAutomatico : Form
  {


    private int eventCount = 0;
    private int indexOfItemUnderMouseToDrop;
    private int indexOfItemUnderMouseToDrag;
    private Point screenOffset;
    private DateTime eventTime;

    public frmVariableAutomatico()
    {
      InitializeComponent();
    }


    private void frmVariableAutomatico_Load(object sender, EventArgs e)
    {
      listBox1.Refresh();
      List<Variable> lstVariable = new List<Variable>();
      VariableObject objVariableObject = new VariableObject();
      lstVariable = objVariableObject.listVariablePorCondicionyOrden(" AND var_m = 1 ", " ORDER BY tcl_id, var_orden ");
      //aux = lstVariable.Count;
      if (lstVariable.Count == 0)
      {
        listBox1.Items.Clear();
      }
      else
      {
        if (lstVariable.Count == 0)
        {
          listBox1.Items.Clear();
        }
        else
        {
          listBox1.Items.Clear();
          listBox1.Refresh();
          lstVariable.ForEach(delegate(Variable v)
          {
            //recuperar la sumartoria de las variables glabales para preceder con el calculo.
            listBox1.Items.Add(v.Var_codigo);
          });
        }
      }

      // ComboBox1
      comboBox1.Items.Add("Variables TIPO 1: Variable producto");
      comboBox1.Items.Add("Variables TIPO 2: Variable mercado");
      comboBox1.Items.Add("Variables TIPO 3: Variable campo");
      comboBox1.Items.Add("Variables TIPO 4: Variable producto, mercado");
      comboBox1.Items.Add("Variables TIPO 5: Variable producto, mercado, campo");

    }


    private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
    {
      string sTmp = listBox1.Text;
      List<Variable> lstVariable = new List<Variable>();
      if (sTmp.Length > 0)
      {
        //txtName.Text = sTmp.Trim();
        VariableObject objVariableObject = new VariableObject();
        lstVariable = objVariableObject.listVariablePorCodigo(sTmp.Trim());
        lstVariable.ForEach(delegate(Variable v)
        {
          txtDescripcionVariable.Text = v.Var_descripcion;
        });
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        if (listBox1.Items.Count >= 1)
        {
          if (listBox1.SelectedItem != null)
          {
            listBox2.Items.Add(listBox1.SelectedItem);
          }
          else
          {
            MessageBox.Show("Debe escoger un item de la lista origen", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          MessageBox.Show("No existen items en la lista origen", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception e1)
      {
        MessageBox.Show("Error: " + e1.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      listBox2.Items.Clear();
      for (int i = 0; i < listBox1.Items.Count; i++)
      {
        listBox2.Items.Add(listBox1.Items[i]);
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      listBox2.Items.Clear();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      try
      {
        if (listBox2.Items.Count >= 1)
        {
          if (listBox2.SelectedItem != null)
          {
            //string selecteditem2 = listBox2.SelectedItem.ToString();
            listBox2.Items.Remove(listBox2.SelectedItem);
          }
          else
          {
            MessageBox.Show("Debe escoger un item de la lista destino", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          MessageBox.Show("No existen items en la lista destino", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception e1)
      {
        MessageBox.Show("Error: " + e1.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }





    private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      // starts a DoDragDrop operation with allowed effect  "Copy"
      eventCount = eventCount + 1;  // increment event counter
      DateTime date = DateTime.Now; // get time of event
      int indexOfItem = listBox1.IndexFromPoint(e.X, e.Y);
      if (indexOfItem >= 0 && indexOfItem < listBox1.Items.Count)  // check that an string is selected
      {
        listBox1.DoDragDrop(listBox1.Items[indexOfItem], DragDropEffects.Copy);
      }


    }

    private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
      eventTime = DateTime.Now;
      e.Effect = DragDropEffects.Copy;  // The cursor changes to show Copy
      GiveInfoAboutDragDropEvent(eventTime, "listBox1_DragEnter", sender, e);
    }

    private void listBox1_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
    {
      screenOffset = SystemInformation.WorkingArea.Location;
      ListBox lb = sender as ListBox;

      if (lb != null)
      {
        Form f = lb.FindForm();
        if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
          ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
          ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
          ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
        {
          e.Action = DragAction.Cancel;
        }
      }

      eventCount = eventCount + 1;  // increment event counter
      DateTime date = DateTime.Now; // get time of event
    }






    private void listBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      eventCount = eventCount + 1;
      int indexOfItem = listBox2.IndexFromPoint(e.X, e.Y);
      DateTime date = DateTime.Now;
      if (indexOfItem >= 0 && indexOfItem < listBox2.Items.Count)  // check we clicked down on a string
      {
      }
    }

    private void listBox2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
      eventTime = DateTime.Now;
      GiveInfoAboutDragDropEvent(eventTime, "listBox2_DragEnter", sender, e);
      if (e.Data.GetDataPresent(DataFormats.StringFormat) && (e.AllowedEffect == DragDropEffects.Copy))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.Move;
    }

    private void listBox2_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
    {
      screenOffset = SystemInformation.WorkingArea.Location;
      ListBox lb = sender as ListBox;

      if (lb != null)
      {
        Form f = lb.FindForm();
        if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
          ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
          ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
          ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
        {
          e.Action = DragAction.Cancel;
        }
      }

      eventCount = eventCount + 1;  // increment event counter
      DateTime date = DateTime.Now; // get time of event
    }


    private void listBox2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.StringFormat))
      {
        if (indexOfItemUnderMouseToDrop >= 0 && indexOfItemUnderMouseToDrop < listBox2.Items.Count)
        {
          listBox2.Items.Insert(indexOfItemUnderMouseToDrop, e.Data.GetData(DataFormats.Text));
        }
        else
        {
          // add the selected string to bottom of list
          listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
        }


      }
      // fill info listBox
      eventTime = DateTime.Now;
      GiveInfoAboutDragDropEvent(eventTime, "listBox2_DragDrop", sender, e);
      DateTime date = DateTime.Now;
      label1.Text = "";  // Erase info label.

    }

    private void listBox2_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
    {

      indexOfItemUnderMouseToDrop =
        listBox2.IndexFromPoint(listBox2.PointToClient(new Point(e.X, e.Y)));

      if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
      {
        // if the computed index is not within listBox2, then put it at the end (bottom)
        //label1.Text = "\'" + e.Data.GetData(DataFormats.Text) + "\'" + " will be placed  before item #" + (indexOfItemUnderMouseToDrop + 1) +
        //           "\n which is " + listBox2.SelectedItem;
        // pass the location back to use in the dragDrop event method.
        listBox2.SelectedIndex = indexOfItemUnderMouseToDrop;

      }
      else
      {
        // prompt the user where the drop will occur
        //label1.Text = "\'" + e.Data.GetData(DataFormats.Text) + "\'" + " will be added to the bottom of the listBox.";
        // save the intended drop location as an index number into the listBox2 Item collection.
        listBox2.SelectedIndex = indexOfItemUnderMouseToDrop;
      }

      // listBox2
      if (e.Effect == DragDropEffects.Move)  // When moving an item within listBox2
        listBox2.Items.Remove((string)e.Data.GetData(DataFormats.Text));

      // fill the informational listBox3
      eventTime = DateTime.Now;
      GiveInfoAboutDragDropEvent(eventTime, "listBox2_DragOver", sender, e);
    }



    private void GiveInfoAboutDragDropEvent(DateTime eventTime, string dragDropEventName, object originalSender, System.Windows.Forms.DragEventArgs e)
    {
      eventCount = eventCount + 1;
    }

    private void Form1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
    {
      Size dragSize = SystemInformation.DragSize;
      GiveInfoAboutDragDropEvent(eventTime, "Form1_DragOver", sender, e);
    }

    private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
      eventTime = DateTime.Now;
      GiveInfoAboutDragDropEvent(eventTime, "Form1_DragEnter", sender, e);
    }


    private void button1_Click(object sender, EventArgs e)
    {
      switch (comboBox1.Text){
        case "Variables TIPO 1: Variable producto":
          VarTipo1();
          break;

        case "Variables TIPO 2: Variable mercado":
          VarTipo2();
          break;

        case "Variables TIPO 3: Variable campo":
          VarTipo3();
          break;

        case "Variables TIPO 4: Variable producto, mercado":
          VarTipo4();
          break;

        case "Variables TIPO 5: Variable producto, mercado, campo":
          VarTipo5();
          break;
      }
    }




    private void VarTipo1()
    {

      // Variable maestra
      String vmp = "";
      String vm = "";
      String prd = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      int for_m = 0;
      String var_tipo = "";
      long inserted = 0;

      

      label1.Text = "Procesando ...";
      VariableController objVariableController = new VariableController();
      for (int z = 0; z <= listBox2.Items.Count - 1; z++)
      {

        VariableObject objVariableObject3 = new VariableObject();
        List<Variable> lstVariable4 = new List<Variable>();
        lstVariable4 = objVariableObject3.listVariablePorCodigo(listBox2.Items[z].ToString());
        if (lstVariable4.Count != 0)
        {
          // Recorrer VARIABLES
          lstVariable4.ForEach(delegate(Variable v)
          {
            // Recorrer las variables maestras
            for_m = v.For_m;
            vm = v.Var_codigo;
            var_cam = v.Var_cam;
            var_tipo = v.Var_tipo;
            var_id = v.Var_id;
            cam_id = v.Cam_id;


            #region RECORRER PRODUCTOS
            // **********************************************
            // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
            // **********************************************
            // 1er. Nivel
            // Selección de productos
            ProductoObject objProductoObject = new ProductoObject();
            List<Producto> lstProducto = new List<Producto>();
            lstProducto = objProductoObject.listProductoPorCondicion("");
            if (lstProducto.Count != 0)
            {
              long pro_id = 0;
              // Recorrer PRODUCTOS
              lstProducto.ForEach(delegate(Producto p)
              {
                i++;
                // Generar variable
                // Variable Maestra = Variable Maestra + Codigo Producto
                pro_id = p.Pro_id;
                prd = p.Pro_codigo;
                vmp = vm + prd;

                // Insertar variable tab_variable
                //textBox1.Text = textBox1.Text + vmp;
                Console.WriteLine("{1} Variable {0}", vmp, i);

                // INSERTAR VARIABLE A LA BASE DE DATOS              
                List<Variable> lstVariable1 = new List<Variable>();
                Variable variable1 = new Variable();
                variable1.Var_id = System.Convert.ToInt64(0);
                variable1.Var_codigo = System.Convert.ToString(vmp);
                variable1.Var_nombre = System.Convert.ToString(v.Var_nombre);
                variable1.Var_tipo = System.Convert.ToString(var_tipo);
                variable1.Var_valini = System.Convert.ToDecimal(0);
                variable1.Var_estado = System.Convert.ToInt64(1);
                variable1.Var_orden = System.Convert.ToInt64(v.Var_orden);
                variable1.Umd_id = System.Convert.ToInt64(v.Umd_id);
                variable1.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                variable1.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                variable1.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                variable1.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                variable1.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                variable1.Mer_id = System.Convert.ToInt64(v.Mer_id);
                variable1.Pro_id = System.Convert.ToInt64(p.Pro_id);
                variable1.Var_codigod = System.Convert.ToString(v.Var_codigod);
                variable1.Var_total = System.Convert.ToString(v.Var_total);
                variable1.Vard_id = System.Convert.ToInt64(v.Vard_id);
                variable1.Var_posicion = Convert.ToInt64(v.Var_posicion);
                variable1.Var_impresion = Convert.ToInt64(v.Var_impresion);
                variable1.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                variable1.Cam_id = Convert.ToInt64(v.Cam_id);
                variable1.Var_m = Convert.ToInt32(0);
                variable1.Var_cam = Convert.ToInt32(0);
                variable1.For_m = Convert.ToInt32(for_m);
                lstVariable1.Add(variable1);
                // Save data from Variable
                inserted = objVariableController.save(lstVariable1);
                if (inserted == 0)
                {
                  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // Nuevo
                else
                {

                  #region GENERAR FORMULA PRODUCTO
                  //Session objSession2 = new Session();
                  //if (var_tipo.Equals("S"))
                  //{
                  //  switch (v.For_m)
                  //  {
                  //    // No tiene formula
                  //    case 0:
                  //      break;

                  //    // Tiene formula general
                  //    case 1:
                  //      objSession2.FUNCION = 2;
                  //      if (!generarFormulaProducto(var_id, pro_id, inserted))
                  //      {
                  //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      }
                  //      break;

                  //    // Tiene formula solo total
                  //    case 2:
                  //      objSession2.FUNCION = 2;
                  //      if (!generarFormulaTotal(vm, pro_id, inserted))
                  //      {
                  //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      }
                  //      break;
                  //  }
                  //}
                  #endregion

                }

              }); // Fin recorrer productos
              #endregion

            }

          });
        };




      } // Fin recorrer variables maestras



      Console.WriteLine("FIN");
      label1.Text = "FIN";
      MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    } // End button1_Click



    private void VarTipo2()
    {

      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      int for_m = 0;
      String var_tipo = "";
      long inserted = 0;
      long mer_id = 0;

      label1.Text = "Procesando ...";
      VariableController objVariableController = new VariableController();
      for (int z = 0; z <= listBox2.Items.Count - 1; z++)
      {
        VariableObject objVariableObject3 = new VariableObject();
        List<Variable> lstVariable4 = new List<Variable>();
        lstVariable4 = objVariableObject3.listVariablePorCodigo(listBox2.Items[z].ToString());
        if (lstVariable4.Count != 0)
        {
          // Recorrer VARIABLES
          lstVariable4.ForEach(delegate(Variable v)
          {
            // Recorrer las variables maestras
            for_m = v.For_m;
            vm = v.Var_codigo;
            var_cam = v.Var_cam;
            var_tipo = v.Var_tipo;
            var_id = v.Var_id;
            cam_id = v.Cam_id;

            #region RECORRER MERCADOS
            // ANTES AQUI LA GENERACIÓN DE FORMULAS
            // 2do Nivel
            // Seleccionar mercados
            MercadoObject objMercadoObject = new MercadoObject();
            List<Mercado> lstMercado = new List<Mercado>();
            lstMercado = objMercadoObject.listMercadoPorCondicion("");
            if (lstMercado.Count != 0)
            {
              // Recorrer MERCADOS
              lstMercado.ForEach(delegate(Mercado m)
              {
                i++;
                // Generar variable 
                // Variable Maestra = Variable Maestra + Codigo Mercado
                mer = m.Mer_codigo;
                mer_id = m.Mer_id;
                vmpm = vm + mer;

                // Mostrar variable en la consola
                //textBox1.Text = textBox1.Text + vmpm;
                Console.WriteLine("{1} Variable {0}", vmpm, i);

                // INSERTAR VARIABLE A LA BASE DE DATOS  
                List<Variable> lstVariable2 = new List<Variable>();
                Variable variable2 = new Variable();
                variable2.Var_id = System.Convert.ToInt64(0);
                variable2.Var_codigo = System.Convert.ToString(vmpm);
                variable2.Var_nombre = System.Convert.ToString(v.Var_nombre);
                variable2.Var_tipo = System.Convert.ToString(var_tipo);
                variable2.Var_valini = System.Convert.ToDecimal(0);
                variable2.Var_estado = System.Convert.ToInt64(1);
                variable2.Var_orden = System.Convert.ToInt64(v.Var_orden);
                variable2.Umd_id = System.Convert.ToInt64(v.Umd_id);
                variable2.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                variable2.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                variable2.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                variable2.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                variable2.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                variable2.Mer_id = System.Convert.ToInt64(m.Mer_id);
                variable2.Pro_id = System.Convert.ToInt64(0);
                variable2.Var_codigod = System.Convert.ToString(v.Var_codigod);
                variable2.Var_total = System.Convert.ToString(v.Var_total);
                variable2.Vard_id = System.Convert.ToInt64(v.Vard_id);
                variable2.Var_posicion = Convert.ToInt64(v.Var_posicion);
                variable2.Var_impresion = Convert.ToInt64(v.Var_impresion);
                variable2.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                variable2.Cam_id = Convert.ToInt64(v.Cam_id);
                variable2.Var_m = Convert.ToInt32(0);
                lstVariable2.Add(variable2);
                // Save data from Variable                  
                inserted = objVariableController.save(lstVariable2);
                if (inserted == 0)
                {
                  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // Nuevo
                else
                {

                  #region GENERAR FORMULA MERCADO
                  //if (var_tipo.Equals("S"))
                  //{
                  //  switch (v.For_m)
                  //  {
                  //    // No tiene formula
                  //    case 0:
                  //      break;

                  //    // Tiene formula general
                  //    case 1:
                  //      if (!generarFormulaProductoMercado(var_id, pro_id, mer_id, inserted))
                  //      {
                  //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      }
                  //      break;

                  //    // Tiene formula solo total
                  //    case 2:
                  //      //if (!generarFormulaTotal(var_id, inserted))
                  //      //{
                  //      //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      //}
                  //      break;
                  //  }
                  //}
                  #endregion


                }

              }); // Fin recorrer mercados
            }
            #endregion

          });
        };




      } // Fin recorrer variables maestras



      Console.WriteLine("FIN");
      label1.Text = "FIN";
      MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    } // End button1_Click



    private void VarTipo3()
    {

      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      int for_m = 0;
      String var_tipo = "";
      long inserted = 0;
      long mer_id = 0;

      label1.Text = "Procesando ...";
      VariableController objVariableController = new VariableController();
      for (int z = 0; z <= listBox2.Items.Count - 1; z++)
      {
        VariableObject objVariableObject3 = new VariableObject();
        List<Variable> lstVariable4 = new List<Variable>();
        lstVariable4 = objVariableObject3.listVariablePorCodigo(listBox2.Items[z].ToString());
        if (lstVariable4.Count != 0)
        {
          // Recorrer VARIABLES
          lstVariable4.ForEach(delegate(Variable v)
          {
            // Recorrer las variables maestras
            for_m = v.For_m;
            vm = v.Var_codigo;
            var_cam = v.Var_cam;
            var_tipo = v.Var_tipo;
            var_id = v.Var_id;
            cam_id = v.Cam_id;

            #region RECORRER CAMPOS

            // Generar Variable campo
            // **********************************************
            // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
            // **********************************************
            CampoObject objCampoObject = new CampoObject();
            List<Campo> lstCampo = new List<Campo>();

            // 3er. Nivel
            // Seleccionar campos
            //CampoObject objCampoObject = new CampoObject();
            //List<Campo> lstCampo = new List<Campo>();
            lstCampo = objCampoObject.listCampoPorCondicion("");
            if (lstCampo.Count != 0)
            {
              String var = "";
              // Recorrer CAMPOS
              lstCampo.ForEach(delegate(Campo c)
              {
                i++;
                // Generar variable 
                // Variable Maestra = Variable Maestra + Codigo Campo
                cam = c.Cam_codigo;
                var = vm + cam;
                cam_id = c.Cam_id;

                // INSERTAR VARIABLE A LA BASE DE DATOS
                //textBox1.Text = textBox1.Text + var;
                Console.WriteLine("{1} Variable {0}", var, i);

                // INSERTAR VARIABLE A LA BASE DE DATOS  
                List<Variable> lstVariable3 = new List<Variable>();
                Variable variable3 = new Variable();
                variable3.Var_id = System.Convert.ToInt64(0);
                variable3.Var_codigo = System.Convert.ToString(var);
                variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
                variable3.Var_tipo = System.Convert.ToString(var_tipo);
                variable3.Var_valini = System.Convert.ToDecimal(0);
                variable3.Var_estado = System.Convert.ToInt64(1);
                variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
                variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
                variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                variable3.Mer_id = System.Convert.ToInt64(0);
                variable3.Pro_id = System.Convert.ToInt64(0);
                variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
                variable3.Var_total = System.Convert.ToString(v.Var_total);
                variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
                variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
                variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
                variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                variable3.Cam_id = Convert.ToInt64(c.Cam_id);
                variable3.Var_m = Convert.ToInt32(0);
                lstVariable3.Add(variable3);
                // Save data from Variable                  
                inserted = objVariableController.save(lstVariable3);
                if (inserted == 0)
                {
                  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // Nuevo
                else
                {

                  #region GENERAR FORMULA CAMPO
                  //Session objSession2 = new Session();
                  //if (var_tipo.Equals("S"))
                  //{
                  //  switch (v.For_m)
                  //  {
                  //    // No tiene formula
                  //    case 0:
                  //      break;

                  //    // Tiene formula general
                  //    case 1:
                  //      objSession2.FUNCION = 2;
                  //      if (!generarFormulaProductoMercadoCampoPPijk(var_id, vm, pro_id, mer_id, cam_id, cam, inserted))
                  //      {
                  //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      }
                  //      break;

                  //    // Tiene formula solo total
                  //    case 2:
                  //      //if (!generarFormulaTotal(var_id, inserted))
                  //      //{
                  //      //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  //      //}
                  //      break;
                  //  }
                  //}
                  #endregion


                }

                // Limpiar variable
                var = "";
              }); // Fin recorrer campos
            }

            #endregion

          });
        };

      } // Fin recorrer variables maestras

      Console.WriteLine("FIN");
      label1.Text = "FIN";
      MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    } // End button1_Click




    private void VarTipo4()
    {

      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String vmp = "";
      String vmpm = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      int for_m = 0;
      String var_tipo = "";
      long inserted = 0;
      long mer_id = 0;

      label1.Text = "Procesando ...";
      VariableController objVariableController = new VariableController();
      for (int z = 0; z <= listBox2.Items.Count - 1; z++)
      {

        VariableObject objVariableObject3 = new VariableObject();
        List<Variable> lstVariable4 = new List<Variable>();
        lstVariable4 = objVariableObject3.listVariablePorCodigo(listBox2.Items[z].ToString());
        if (lstVariable4.Count != 0)
        {
          // Recorrer VARIABLES
          lstVariable4.ForEach(delegate(Variable v)
          {
            // Recorrer las variables maestras
            for_m = v.For_m;
            vm = v.Var_codigo;
            var_cam = v.Var_cam;
            var_tipo = v.Var_tipo;
            var_id = v.Var_id;
            cam_id = v.Cam_id;


            #region RECORRER PRODUCTOS
            // **********************************************
            // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
            // **********************************************
            // 1er. Nivel
            // Selección de productos
            ProductoObject objProductoObject = new ProductoObject();
            List<Producto> lstProducto = new List<Producto>();
            lstProducto = objProductoObject.listProductoPorCondicion("");
            if (lstProducto.Count != 0)
            {
              long pro_id = 0;
              // Recorrer PRODUCTOS
              lstProducto.ForEach(delegate(Producto p)
              {
                i++;
                // Generar variable
                // Variable Maestra = Variable Maestra + Codigo Producto
                pro_id = p.Pro_id;
                prd = p.Pro_codigo;
                vmp = vm + prd;

                // Insertar variable tab_variable
                //textBox1.Text = textBox1.Text + vmp;
                Console.WriteLine("{1} Variable {0}", vmp, i);

                #region RECORRER MERCADOS
                // ANTES AQUI LA GENERACIÓN DE FORMULAS
                // 2do Nivel
                // Seleccionar mercados
                MercadoObject objMercadoObject = new MercadoObject();
                List<Mercado> lstMercado = new List<Mercado>();
                lstMercado = objMercadoObject.listMercadoPorCondicion("");
                if (lstMercado.Count != 0)
                {
                  // Recorrer MERCADOS
                  lstMercado.ForEach(delegate(Mercado m)
                  {
                    i++;
                    // Generar variable 
                    // Variable Maestra = Variable Maestra + Codigo Mercado
                    mer = m.Mer_codigo;
                    mer_id = m.Mer_id;
                    vmpm = vm + prd + mer;

                    // Mostrar variable en la consola
                    //textBox1.Text = textBox1.Text + vmpm;
                    Console.WriteLine("{1} Variable {0}", vmpm, i);

                    // INSERTAR VARIABLE A LA BASE DE DATOS  
                    List<Variable> lstVariable2 = new List<Variable>();
                    Variable variable2 = new Variable();
                    variable2.Var_id = System.Convert.ToInt64(0);
                    variable2.Var_codigo = System.Convert.ToString(vmpm);
                    variable2.Var_nombre = System.Convert.ToString(v.Var_nombre);
                    variable2.Var_tipo = System.Convert.ToString(var_tipo);
                    variable2.Var_valini = System.Convert.ToDecimal(0);
                    variable2.Var_estado = System.Convert.ToInt64(1);
                    variable2.Var_orden = System.Convert.ToInt64(v.Var_orden);
                    variable2.Umd_id = System.Convert.ToInt64(v.Umd_id);
                    variable2.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                    variable2.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                    variable2.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                    variable2.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                    variable2.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                    variable2.Mer_id = System.Convert.ToInt64(m.Mer_id);
                    variable2.Pro_id = System.Convert.ToInt64(p.Pro_id);
                    variable2.Var_codigod = System.Convert.ToString(v.Var_codigod);
                    variable2.Var_total = System.Convert.ToString(v.Var_total);
                    variable2.Vard_id = System.Convert.ToInt64(v.Vard_id);
                    variable2.Var_posicion = Convert.ToInt64(v.Var_posicion);
                    variable2.Var_impresion = Convert.ToInt64(v.Var_impresion);
                    variable2.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                    variable2.Cam_id = Convert.ToInt64(v.Cam_id);
                    variable2.Var_m = Convert.ToInt32(0);
                    lstVariable2.Add(variable2);
                    // Save data from Variable                  
                    inserted = objVariableController.save(lstVariable2);
                    if (inserted == 0)
                    {
                      MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // Nuevo
                    else
                    {

                      #region GENERAR FORMULA MERCADO
                      //if (var_tipo.Equals("S"))
                      //{
                      //  switch (v.For_m)
                      //  {
                      //    // No tiene formula
                      //    case 0:
                      //      break;

                      //    // Tiene formula general
                      //    case 1:
                      //      if (!generarFormulaProductoMercado(var_id, pro_id, mer_id, inserted))
                      //      {
                      //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      //      }
                      //      break;

                      //    // Tiene formula solo total
                      //    case 2:
                      //      //if (!generarFormulaTotal(var_id, inserted))
                      //      //{
                      //      //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      //      //}
                      //      break;
                      //  }
                      //}
                      #endregion

                    }

                  }); // Fin recorrer mercados
                }
                #endregion

              }); // Fin recorrer productos

            }
            #endregion

          }); 
        };




      } // Fin recorrer variables maestras



      Console.WriteLine("FIN");
      label1.Text = "FIN";
      MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    } // End button1_Click



    private void VarTipo5()
    {

      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      int for_m = 0;
      String var_tipo = "";
      long inserted = 0;
      long mer_id = 0;

      label1.Text = "Procesando ...";
      VariableController objVariableController = new VariableController();
      for (int z = 0; z <= listBox2.Items.Count - 1; z++)
      {
        VariableObject objVariableObject3 = new VariableObject();
        List<Variable> lstVariable4 = new List<Variable>();
        lstVariable4 = objVariableObject3.listVariablePorCodigo(listBox2.Items[z].ToString());
        if (lstVariable4.Count != 0)
        {
          // Recorrer VARIABLES
          lstVariable4.ForEach(delegate(Variable v)
          {
            // Recorrer las variables maestras
            for_m = v.For_m;
            vm = v.Var_codigo;
            var_cam = v.Var_cam;
            var_tipo = v.Var_tipo;
            var_id = v.Var_id;
            cam_id = v.Cam_id;


            #region RECORRER PRODUCTOS
            // **********************************************
            // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
            // **********************************************
            // 1er. Nivel
            // Selección de productos
            ProductoObject objProductoObject = new ProductoObject();
            List<Producto> lstProducto = new List<Producto>();
            lstProducto = objProductoObject.listProductoPorCondicion("");
            if (lstProducto.Count != 0)
            {
              long pro_id = 0;
              // Recorrer PRODUCTOS
              lstProducto.ForEach(delegate(Producto p)
              {
                i++;
                // Generar variable
                // Variable Maestra = Variable Maestra + Codigo Producto
                pro_id = p.Pro_id;
                prd = p.Pro_codigo;
                vmp = vm + prd;

                // Insertar variable tab_variable
                //textBox1.Text = textBox1.Text + vmp;
                Console.WriteLine("{1} Variable {0}", vmp, i);

                #region RECORRER MERCADOS
                // ANTES AQUI LA GENERACIÓN DE FORMULAS
                // 2do Nivel
                // Seleccionar mercados
                MercadoObject objMercadoObject = new MercadoObject();
                List<Mercado> lstMercado = new List<Mercado>();
                lstMercado = objMercadoObject.listMercadoPorCondicion("");
                if (lstMercado.Count != 0)
                {
                  // Recorrer MERCADOS
                  lstMercado.ForEach(delegate(Mercado m)
                  {
                    i++;
                    // Generar variable 
                    // Variable Maestra = Variable Maestra + Codigo Mercado
                    mer = m.Mer_codigo;
                    mer_id = m.Mer_id;
                    vmpm = vm + prd + mer;

                    // Mostrar variable en la consola
                    //textBox1.Text = textBox1.Text + vmpm;
                    Console.WriteLine("{1} Variable {0}", vmpm, i);


                    #region RECORRER CAMPOS

                    // Generar Variable campo
                    // **********************************************
                    // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
                    // **********************************************
                    CampoObject objCampoObject = new CampoObject();
                    List<Campo> lstCampo = new List<Campo>();

                    // 3er. Nivel
                    // Seleccionar campos
                    //CampoObject objCampoObject = new CampoObject();
                    //List<Campo> lstCampo = new List<Campo>();
                    lstCampo = objCampoObject.listCampoPorCondicion("");
                    if (lstCampo.Count != 0)
                    {
                      String var = "";
                      // Recorrer CAMPOS
                      lstCampo.ForEach(delegate(Campo c)
                      {
                        i++;
                        // Generar variable 
                        // Variable Maestra = Variable Maestra + Codigo Campo
                        cam = c.Cam_codigo;
                        var = vm + prd + mer + cam;
                        cam_id = c.Cam_id;

                        // INSERTAR VARIABLE A LA BASE DE DATOS
                        //textBox1.Text = textBox1.Text + var;
                        Console.WriteLine("{1} Variable {0}", var, i);

                        // INSERTAR VARIABLE A LA BASE DE DATOS  
                        List<Variable> lstVariable3 = new List<Variable>();
                        Variable variable3 = new Variable();
                        variable3.Var_id = System.Convert.ToInt64(0);
                        variable3.Var_codigo = System.Convert.ToString(var);
                        variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
                        variable3.Var_tipo = System.Convert.ToString(var_tipo);
                        variable3.Var_valini = System.Convert.ToDecimal(0);
                        variable3.Var_estado = System.Convert.ToInt64(1);
                        variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
                        variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
                        variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                        variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                        variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                        variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                        variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                        variable3.Mer_id = System.Convert.ToInt64(m.Mer_id);
                        variable3.Pro_id = System.Convert.ToInt64(p.Pro_id);
                        variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
                        variable3.Var_total = System.Convert.ToString(v.Var_total);
                        variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
                        variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
                        variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
                        variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                        variable3.Cam_id = Convert.ToInt64(c.Cam_id);
                        variable3.Var_m = Convert.ToInt32(0);
                        lstVariable3.Add(variable3);
                        // Save data from Variable                  
                        inserted = objVariableController.save(lstVariable3);
                        if (inserted == 0)
                        {
                          MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        // Nuevo
                        else
                        {

                          #region GENERAR FORMULA CAMPO
                          //Session objSession2 = new Session();
                          //if (var_tipo.Equals("S"))
                          //{
                          //  switch (v.For_m)
                          //  {
                          //    // No tiene formula
                          //    case 0:
                          //      break;

                          //    // Tiene formula general
                          //    case 1:
                          //      objSession2.FUNCION = 2;
                          //      if (!generarFormulaProductoMercadoCampoPPijk(var_id, vm, pro_id, mer_id, cam_id, cam, inserted))
                          //      {
                          //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          //      }
                          //      break;

                          //    // Tiene formula solo total
                          //    case 2:
                          //      //if (!generarFormulaTotal(var_id, inserted))
                          //      //{
                          //      //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          //      //}
                          //      break;
                          //  }
                          //}
                          #endregion

                        }

                        // Limpiar variable
                        var = "";
                      }); // Fin recorrer campos
                    }

                    #endregion


                  }); // Fin recorrer mercados
                }
                #endregion

              }); // Fin recorrer productos

            }

            #endregion

          });
        };

      } // Fin recorrer variables maestras



      Console.WriteLine("FIN");
      label1.Text = "FIN";
      MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    } // End button1_Click





    //private void VarTipoBACK(){

    //  // Variable maestra
    //  String vm = "";
    //  String prd = "";
    //  String mer = "";
    //  String cam = "";
    //  String vmp = "";
    //  String vmpm = "";
    //  long i = 0;
    //  long var_id = 0;
    //  long cam_id = 0;
    //  int var_cam = 0;
    //  int for_m = 0;
    //  String var_tipo = "";
    //  long inserted = 0;
    //  long mer_id = 0;







    //  // Selección de variables maestras
    //  VariableObject objVariableObject = new VariableObject();
    //  List<Variable> lstVariable = new List<Variable>();

    //  VariableController objVariableController = new VariableController();
    //  lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 ");
    //  //lstVariable = objVariableObject.listVariablePorCondicion(" ");
    //  if (lstVariable.Count != 0)
    //  {
    //    label1.Text = "Procesando ...";
    //    // Recorrer las variables maestras
    //    lstVariable.ForEach(delegate(Variable v)
    //    {
    //      for_m = v.For_m;
    //      vm = v.Var_codigo;
    //      var_cam = v.Var_cam;
    //      var_tipo = v.Var_tipo;
    //      var_id = v.Var_id;
    //      cam_id = v.Cam_id;


    //      #region RECORRER PRODUCTOS
    //      // **********************************************
    //      // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
    //      // **********************************************
    //      // 1er. Nivel
    //      // Selección de productos
    //      ProductoObject objProductoObject = new ProductoObject();
    //      List<Producto> lstProducto = new List<Producto>();
    //      lstProducto = objProductoObject.listProductoPorCondicion("");
    //      if (lstProducto.Count != 0)
    //      {
    //        long pro_id = 0;
    //        // Recorrer PRODUCTOS
    //        lstProducto.ForEach(delegate(Producto p)
    //        {
    //          i++;
    //          // Generar variable
    //          // Variable Maestra = Variable Maestra + Codigo Producto
    //          pro_id = p.Pro_id;
    //          prd = p.Pro_codigo;
    //          vmp = vm + prd;

    //          // Insertar variable tab_variable
    //          //textBox1.Text = textBox1.Text + vmp;
    //          Console.WriteLine("{1} Variable {0}", vmp, i);

    //          // INSERTAR VARIABLE A LA BASE DE DATOS              
    //          List<Variable> lstVariable1 = new List<Variable>();
    //          Variable variable1 = new Variable();
    //          variable1.Var_id = System.Convert.ToInt64(0);
    //          variable1.Var_codigo = System.Convert.ToString(vmp);
    //          variable1.Var_nombre = System.Convert.ToString(v.Var_nombre);
    //          variable1.Var_tipo = System.Convert.ToString(var_tipo);
    //          variable1.Var_valini = System.Convert.ToDecimal(0);
    //          variable1.Var_estado = System.Convert.ToInt64(1);
    //          variable1.Var_orden = System.Convert.ToInt64(v.Var_orden);
    //          variable1.Umd_id = System.Convert.ToInt64(v.Umd_id);
    //          variable1.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
    //          variable1.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
    //          variable1.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
    //          variable1.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
    //          variable1.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
    //          variable1.Mer_id = System.Convert.ToInt64(v.Mer_id);
    //          variable1.Pro_id = System.Convert.ToInt64(p.Pro_id);
    //          variable1.Var_codigod = System.Convert.ToString(v.Var_codigod);
    //          variable1.Var_total = System.Convert.ToString(v.Var_total);
    //          variable1.Vard_id = System.Convert.ToInt64(v.Vard_id);
    //          variable1.Var_posicion = Convert.ToInt64(v.Var_posicion);
    //          variable1.Var_impresion = Convert.ToInt64(v.Var_impresion);
    //          variable1.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
    //          variable1.Cam_id = Convert.ToInt64(v.Cam_id);
    //          variable1.Var_m = Convert.ToInt32(0);
    //          variable1.Var_cam = Convert.ToInt32(0);
    //          variable1.For_m = Convert.ToInt32(for_m);
    //          lstVariable1.Add(variable1);
    //          // Save data from Variable
    //          inserted = objVariableController.save(lstVariable1);
    //          if (inserted == 0)
    //          {
    //            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //          }
    //          // Nuevo
    //          else
    //          {
    //            #region GENERAR FORMULA PRODUCTO
    //            Session objSession2 = new Session();
    //            if (var_tipo.Equals("S"))
    //            {
    //              switch (v.For_m)
    //              {
    //                // No tiene formula
    //                case 0:
    //                  break;

    //                // Tiene formula general
    //                case 1:
    //                  objSession2.FUNCION = 2;
    //                  if (!generarFormulaProducto(var_id, pro_id, inserted))
    //                  {
    //                    MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                  }
    //                  break;

    //                // Tiene formula solo total
    //                case 2:
    //                  objSession2.FUNCION = 2;
    //                  if (!generarFormulaTotal(vm, pro_id, inserted))
    //                  {
    //                    MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                  }
    //                  break;
    //              }
    //            }
    //            #endregion
    //          }


    //          #region RECORRER MERCADOS
    //          // ANTES AQUI LA GENERACIÓN DE FORMULAS
    //          // 2do Nivel
    //          // Seleccionar mercados
    //          MercadoObject objMercadoObject = new MercadoObject();
    //          List<Mercado> lstMercado = new List<Mercado>();
    //          lstMercado = objMercadoObject.listMercadoPorCondicion("");
    //          if (lstMercado.Count != 0)
    //          {
    //            // Recorrer MERCADOS
    //            lstMercado.ForEach(delegate(Mercado m)
    //            {
    //              i++;
    //              // Generar variable 
    //              // Variable Maestra = Variable Maestra + Codigo Mercado
    //              mer = m.Mer_codigo;
    //              mer_id = m.Mer_id;
    //              vmpm = vm + prd + mer;

    //              // Mostrar variable en la consola
    //              //textBox1.Text = textBox1.Text + vmpm;
    //              Console.WriteLine("{1} Variable {0}", vmpm, i);

    //              // INSERTAR VARIABLE A LA BASE DE DATOS  
    //              List<Variable> lstVariable2 = new List<Variable>();
    //              Variable variable2 = new Variable();
    //              variable2.Var_id = System.Convert.ToInt64(0);
    //              variable2.Var_codigo = System.Convert.ToString(vmpm);
    //              variable2.Var_nombre = System.Convert.ToString(v.Var_nombre);
    //              variable2.Var_tipo = System.Convert.ToString(var_tipo);
    //              variable2.Var_valini = System.Convert.ToDecimal(0);
    //              variable2.Var_estado = System.Convert.ToInt64(1);
    //              variable2.Var_orden = System.Convert.ToInt64(v.Var_orden);
    //              variable2.Umd_id = System.Convert.ToInt64(v.Umd_id);
    //              variable2.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
    //              variable2.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
    //              variable2.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
    //              variable2.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
    //              variable2.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
    //              variable2.Mer_id = System.Convert.ToInt64(m.Mer_id);
    //              variable2.Pro_id = System.Convert.ToInt64(p.Pro_id);
    //              variable2.Var_codigod = System.Convert.ToString(v.Var_codigod);
    //              variable2.Var_total = System.Convert.ToString(v.Var_total);
    //              variable2.Vard_id = System.Convert.ToInt64(v.Vard_id);
    //              variable2.Var_posicion = Convert.ToInt64(v.Var_posicion);
    //              variable2.Var_impresion = Convert.ToInt64(v.Var_impresion);
    //              variable2.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
    //              variable2.Cam_id = Convert.ToInt64(v.Cam_id);
    //              variable2.Var_m = Convert.ToInt32(0);
    //              lstVariable2.Add(variable2);
    //              // Save data from Variable                  
    //              inserted = objVariableController.save(lstVariable2);
    //              if (inserted == 0)
    //              {
    //                MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //              }
    //              // Nuevo
    //              else
    //              {
    //                #region GENERAR FORMULA MERCADO
    //                if (var_tipo.Equals("S"))
    //                {
    //                  switch (v.For_m)
    //                  {
    //                    // No tiene formula
    //                    case 0:
    //                      break;

    //                    // Tiene formula general
    //                    case 1:
    //                      if (!generarFormulaProductoMercado(var_id, pro_id, mer_id, inserted))
    //                      {
    //                        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                      }
    //                      break;

    //                    // Tiene formula solo total
    //                    case 2:
    //                      //if (!generarFormulaTotal(var_id, inserted))
    //                      //{
    //                      //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                      //}
    //                      break;
    //                  }
    //                }
    //                #endregion
    //              }












    //              #region RECORRER CAMPOS
    //              // Verificar si se va a recorrer campos
    //              if (var_cam == 1)
    //              {

    //                // Generar Variable campo
    //                // **********************************************
    //                // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
    //                // **********************************************
    //                CampoObject objCampoObject = new CampoObject();
    //                List<Campo> lstCampo = new List<Campo>();
    //                lstCampo = objCampoObject.listCampoPorCondicion("");
    //                if (lstCampo.Count != 0)
    //                {
    //                  String var = "";
    //                  // Recorrer CAMPOS
    //                  lstCampo.ForEach(delegate(Campo c)
    //                  {
    //                    i++;
    //                    // Generar variable 
    //                    // Variable Maestra = Variable Maestra + Codigo Campo
    //                    cam = c.Cam_codigo;
    //                    var = vm + cam;

    //                    // INSERTAR VARIABLE A LA BASE DE DATOS              
    //                    List<Variable> lstVariable3 = new List<Variable>();
    //                    Variable variable3 = new Variable();
    //                    variable3.Var_id = System.Convert.ToInt64(0);
    //                    variable3.Var_codigo = System.Convert.ToString(var);
    //                    variable3.Var_nombre = System.Convert.ToString(c.Cas_nombre);
    //                    variable3.Var_tipo = System.Convert.ToString(var_tipo);
    //                    variable3.Var_valini = System.Convert.ToDecimal(0);
    //                    variable3.Var_estado = System.Convert.ToInt64(1);
    //                    variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
    //                    variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
    //                    variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
    //                    variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
    //                    variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
    //                    variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
    //                    variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
    //                    variable3.Mer_id = System.Convert.ToInt64(m.Mer_id);  // Mercado
    //                    variable3.Pro_id = System.Convert.ToInt64(p.Pro_id);  // Producto
    //                    variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
    //                    variable3.Var_total = System.Convert.ToString(v.Var_total);
    //                    variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
    //                    variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
    //                    variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
    //                    variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
    //                    variable3.Cam_id = Convert.ToInt64(c.Cam_id); // Campo
    //                    variable3.Var_m = Convert.ToInt32(0);
    //                    variable3.Var_cam = Convert.ToInt32(0);
    //                    variable3.For_m = Convert.ToInt32(for_m);
    //                    lstVariable3.Add(variable3);
    //                    // Save data from Variable
    //                    inserted = objVariableController.save(lstVariable3);
    //                    if (inserted == 0)
    //                    {
    //                      MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                    }
    //                    // Nuevo
    //                    else
    //                    {
    //                      #region GENERAR FORMULA PRODUCTO
    //                      Session objSession2 = new Session();
    //                      if (var_tipo.Equals("S"))
    //                      {
    //                        switch (v.For_m)
    //                        {
    //                          // No tiene formula
    //                          case 0:
    //                            break;

    //                          // Tiene formula general
    //                          case 1:
    //                            objSession2.FUNCION = 2;
    //                            if (!generarFormulaProductoMercadoCampoNoVariaciones(var_id, pro_id, mer_id, cam_id, inserted))
    //                            {
    //                              MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                            }
    //                            break;

    //                          //// Tiene formula solo total
    //                          //case 2:
    //                          //  objSession2.FUNCION = 2;
    //                          //  if (!generarFormulaTotal(vm, cam_id, inserted))
    //                          //  {
    //                          //    MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                          //  }
    //                          //  break;
    //                        }
    //                      }
    //                      #endregion
    //                    }
    //                  }); // Fin recorrer campos
    //                }
    //                //





    //                // 3er. Nivel
    //                // Seleccionar campos
    //                //CampoObject objCampoObject = new CampoObject();
    //                //List<Campo> lstCampo = new List<Campo>();
    //                lstCampo = objCampoObject.listCampoPorCondicion("");
    //                if (lstCampo.Count != 0)
    //                {
    //                  String var = "";
    //                  // Recorrer CAMPOS
    //                  lstCampo.ForEach(delegate(Campo c)
    //                  {
    //                    i++;
    //                    // Generar variable 
    //                    // Variable Maestra = Variable Maestra + Codigo Campo
    //                    cam = c.Cam_codigo;
    //                    var = vm + prd + mer + cam;
    //                    cam_id = c.Cam_id;

    //                    // INSERTAR VARIABLE A LA BASE DE DATOS
    //                    //textBox1.Text = textBox1.Text + var;
    //                    Console.WriteLine("{1} Variable {0}", var, i);

    //                    // INSERTAR VARIABLE A LA BASE DE DATOS  
    //                    List<Variable> lstVariable3 = new List<Variable>();
    //                    Variable variable3 = new Variable();
    //                    variable3.Var_id = System.Convert.ToInt64(0);
    //                    variable3.Var_codigo = System.Convert.ToString(var);
    //                    variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
    //                    variable3.Var_tipo = System.Convert.ToString(var_tipo);
    //                    variable3.Var_valini = System.Convert.ToDecimal(0);
    //                    variable3.Var_estado = System.Convert.ToInt64(1);
    //                    variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
    //                    variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
    //                    variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
    //                    variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
    //                    variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
    //                    variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
    //                    variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
    //                    variable3.Mer_id = System.Convert.ToInt64(m.Mer_id);
    //                    variable3.Pro_id = System.Convert.ToInt64(p.Pro_id);
    //                    variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
    //                    variable3.Var_total = System.Convert.ToString(v.Var_total);
    //                    variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
    //                    variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
    //                    variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
    //                    variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
    //                    variable3.Cam_id = Convert.ToInt64(c.Cam_id);
    //                    variable3.Var_m = Convert.ToInt32(0);
    //                    lstVariable3.Add(variable3);
    //                    // Save data from Variable                  
    //                    inserted = objVariableController.save(lstVariable3);
    //                    if (inserted == 0)
    //                    {
    //                      MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                    }
    //                    // Nuevo
    //                    else
    //                    {
    //                      #region GENERAR FORMULA CAMPO
    //                      Session objSession2 = new Session();
    //                      if (var_tipo.Equals("S"))
    //                      {
    //                        switch (v.For_m)
    //                        {
    //                          // No tiene formula
    //                          case 0:
    //                            break;

    //                          // Tiene formula general
    //                          case 1:
    //                            objSession2.FUNCION = 2;
    //                            if (!generarFormulaProductoMercadoCampoPPijk(var_id, vm, pro_id, mer_id, cam_id, cam, inserted))
    //                            {
    //                              MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                            }
    //                            break;

    //                          // Tiene formula solo total
    //                          case 2:
    //                            //if (!generarFormulaTotal(var_id, inserted))
    //                            //{
    //                            //  MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                            //}
    //                            break;
    //                        }
    //                      }
    //                      #endregion
    //                    }

    //                    // Limpiar variable
    //                    var = "";
    //                  }); // Fin recorrer campos
    //                }

    //              } // Fin verificar campos
    //              #endregion


    //            }); // Fin recorrer mercados
    //          }
    //          #endregion

    //        }); // Fin recorrer productos

    //      }

    //      #endregion

    //    }); // Fin recorrer variables maestras


    //  }

    //  Console.WriteLine("FIN");
    //  label1.Text = "FIN";
    //  MessageBox.Show("FIN", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //} // End button1_Click


























    //// Formulas
    //String for_codigo = "";
    //int for_tipo = 0;
    //long for_id = 0;
    //String for_nombre = "";
    //long insertedf = 0;
    //int contador = 0;
    //// 
      



    //// *********************************
    //// GENERAR FORMULAS PARA LA VARIABLE
    //// *********************************
    //if (var_tipo.Equals("S"))
    //{

    //  // Generar formula
    //  // Buscar formula
    //  FormulaObject objFormulaObject = new FormulaObject();
    //  List<Formula> lstformula = new List<Formula>();
    //  lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
    //  if (lstformula.Count != 0)
    //  {
    //    lstformula.ForEach(delegate(Formula f)
    //    {
    //      for_id = f.For_id;
    //      var_id = f.Var_id;
    //      for_codigo = f.For_codigo;
    //      for_tipo = f.For_tipo;
    //      for_nombre = f.For_nombre;
    //      for_tipo = f.For_tipo;
    //    });
    //  }



    //  List<Variable> lstVariableFinal = new List<Variable>();
    //  VariableObject objVariableObject1 = new VariableObject();
    //  char[] delimiter = { ' ', '\t' };


    //  MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //  string[] tokens = for_codigo.Split(delimiter);

    //  // GENERAR FORMULA EN BASE A TOKENS
    //  foreach (string token in tokens)
    //  {
    //    Console.WriteLine("VARIABLE DE FORMULA {0}", token);
    //    //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
    //    lstVariableFinal = objVariableObject1.generarFormulaGeneric(lstVariableFinal, token, contador);
    //    if (lstVariableFinal.Count != 0)
    //    {
    //      contador = lstVariableFinal.Count;
    //    }
    //  }

    //  // Guardar formula
    //  if (lstVariableFinal.Count != 0)
    //  {
    //    lstVariableFinal.ForEach(delegate(Variable vf)
    //    {
    //      // INSERTAR FÓRMULAS A LA BASE DE DATOS
    //      List<Formula> lstFormula = new List<Formula>();
    //      Formula Formula = new Formula();
    //      Formula.For_id = System.Convert.ToInt64(0);
    //      Formula.Var_id = System.Convert.ToInt64(inserted);
    //      Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
    //      Formula.For_nombre = System.Convert.ToString(for_nombre);
    //      Formula.For_valini = System.Convert.ToDecimal(0);
    //      Formula.For_estado = System.Convert.ToInt64(0);
    //      Formula.For_tipo = System.Convert.ToInt32(for_tipo);
    //      lstFormula.Add(Formula);

    //      // Save data from Formula
    //      FormulaController objFormulaController = new FormulaController();
    //      insertedf = objFormulaController.save(lstFormula);
    //      if (insertedf == 0)
    //      {
    //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //      }
    //    });
    //  }
    //}




    //if (var_tipo.Equals("S"))
    //{
    //  switch (v.For_m)
    //  {
    //    // Tiene formula solo total
    //    case 2:
    //      Session objSession2 = new Session();
    //      objSession2.FUNCION = 1;
    //      if (!generarFormulaTotal(var_id, var_id))
    //      {
    //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //      }
    //      break;
    //  }
    //}


    //// ****************************************
    //// SI LA VARIABLE TIENE RECORRIDO POR CAMPO
    //// ****************************************
    //if (cam_id != 0)
    //{
    //  // ****************************************
    //  // GENERAR COMBINACIONES VARIABLE CAMPO
    //  // ****************************************
    //  // Seleccionar campos
    //  CampoObject objCampoObject = new CampoObject();
    //  List<Campo> lstCampo = new List<Campo>();
    //  lstCampo = objCampoObject.listCampoPorCondicion("");
    //  if (lstCampo.Count != 0)
    //  {
    //    String var = "";
    //    // Recorrer CAMPOS
    //    lstCampo.ForEach(delegate(Campo c)
    //    {
    //      i++;
    //      // Generar variable 
    //      // Variable Maestra = Variable Maestra + Codigo Campo
    //      cam = c.Cam_codigo;
    //      var = vm + cam;

    //      // INSERTAR VARIABLE A LA BASE DE DATOS
    //      //textBox1.Text = textBox1.Text + var;
    //      Console.WriteLine("{1} Variable {0}", var, i);

    //      // INSERTAR VARIABLE A LA BASE DE DATOS  
    //      List<Variable> lstVariable3 = new List<Variable>();
    //      Variable variable3 = new Variable();
    //      variable3.Var_id = System.Convert.ToInt64(0);
    //      variable3.Var_codigo = System.Convert.ToString(var);
    //      variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
    //      variable3.Var_tipo = System.Convert.ToString(var_tipo);
    //      variable3.Var_valini = System.Convert.ToDecimal(0);
    //      variable3.Var_estado = System.Convert.ToInt64(1);
    //      variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
    //      variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
    //      variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
    //      variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
    //      variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
    //      variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
    //      variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
    //      variable3.Mer_id = System.Convert.ToInt64(v.Mer_id);
    //      variable3.Pro_id = System.Convert.ToInt64(v.Pro_id);
    //      variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
    //      variable3.Var_total = System.Convert.ToString(v.Var_total);
    //      variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
    //      variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
    //      variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
    //      variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
    //      variable3.Cam_id = Convert.ToInt64(v.Cam_id);
    //      variable3.Var_m = Convert.ToInt32(0);
    //      lstVariable3.Add(variable3);
    //      // Save data from Variable                  
    //      inserted = objVariableController.save(lstVariable3);
    //      if (inserted == 0)
    //      {
    //        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //      }
    //      // Nuevo
    //      else
    //      {
    //        if (var_tipo.Equals("S"))
    //        {
    //          if (v.Var_m == 1)
    //          {
    //            if (!generarFormula(var_id, inserted))
    //            {
    //              MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //            }
    //          }
    //          else
    //          {
    //            if (!generarFormulaSuma(var_id, inserted))
    //            {
    //              MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //            }
    //          }

    //        }
    //      }
    //      //

    //      // Limpiar variable
    //      var = "";
    //    }); // Fin recorrer campos
    //  }            
    //}       





    private bool generarFormulaProducto(long var_id, long pro_id, long varn_id)
    {

      // Formulas
      long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;      
      String for_nombre = "";

      // 
      long inserted = 0;
      int contador = 0;

      // Generar formula
      // Buscar formula
      FormulaObject objFormulaObject = new FormulaObject();
      List<Formula> lstformula = new List<Formula>();
      lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
      if (lstformula.Count != 0)
      {
        lstformula.ForEach(delegate(Formula f)
        {
          for_id = f.For_id;
          var_id = f.Var_id;
          for_codigo = f.For_codigo;
          for_tipo = f.For_tipo;
          for_nombre = f.For_nombre;
          for_tipo = f.For_tipo;
        });
      }



      List<Variable> lstVariableFinal = new List<Variable>();
      VariableObject objVariableObject1 = new VariableObject();
      char[] delimiter = { ' ', '\t' };


      //MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      string[] tokens = for_codigo.Split(delimiter);
      // GENERAR FORMULA EN BASE A TOKENS
      foreach (string token in tokens)
      {
        Console.WriteLine("VARIABLE DE FORMULA {0}", token);
        //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
        lstVariableFinal = objVariableObject1.generarFormulaGeneric(lstVariableFinal, pro_id, token, contador);
        if (lstVariableFinal.Count != 0)
        {
          contador = lstVariableFinal.Count;
        }
      }

      // Guardar formula
      if (lstVariableFinal.Count != 0)
      {
        lstVariableFinal.ForEach(delegate(Variable vf)
        {
          // INSERTAR FÓRMULAS A LA BASE DE DATOS
          List<Formula> lstFormula = new List<Formula>();
          Formula Formula = new Formula();
          Formula.For_id = System.Convert.ToInt64(0);
          Formula.Var_id = System.Convert.ToInt64(varn_id);
          Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
          Formula.For_nombre = System.Convert.ToString(for_nombre);
          Formula.For_valini = System.Convert.ToDecimal(0);
          Formula.For_estado = System.Convert.ToInt64(0);
          Formula.For_tipo = System.Convert.ToInt32(for_tipo);
          lstFormula.Add(Formula);

          // Save data from Formula
          FormulaController objFormulaController = new FormulaController();
          inserted = objFormulaController.save(lstFormula);
          if (inserted == 0)
          {
            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        });
      }
      return true;
    }



    private bool generarFormulaProductoMercado(long var_id, long pro_id, long mer_id, long varn_id)
    {

      // Formulas
      long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;
      String for_nombre = "";

      // 
      long inserted = 0;
      int contador = 0;

      // Generar formula
      // Buscar formula
      FormulaObject objFormulaObject = new FormulaObject();
      List<Formula> lstformula = new List<Formula>();
      lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
      if (lstformula.Count != 0)
      {
        lstformula.ForEach(delegate(Formula f)
        {
          for_id = f.For_id;
          var_id = f.Var_id;
          for_codigo = f.For_codigo;
          for_tipo = f.For_tipo;
          for_nombre = f.For_nombre;
          for_tipo = f.For_tipo;
        });
      }



      List<Variable> lstVariableFinal = new List<Variable>();
      VariableObject objVariableObject1 = new VariableObject();
      char[] delimiter = { ' ', '\t' };


      //MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      string[] tokens = for_codigo.Split(delimiter);
      // GENERAR FORMULA EN BASE A TOKENS
      foreach (string token in tokens)
      {
        Console.WriteLine("VARIABLE DE FORMULA {0}", token);
        //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
        lstVariableFinal = objVariableObject1.generarFormulaProductoMercadoGeneric(lstVariableFinal, pro_id, mer_id, token, contador);
        if (lstVariableFinal.Count != 0)
        {
          contador = lstVariableFinal.Count;
        }
      }

      // Guardar formula
      if (lstVariableFinal.Count != 0)
      {
        lstVariableFinal.ForEach(delegate(Variable vf)
        {
          // INSERTAR FÓRMULAS A LA BASE DE DATOS
          List<Formula> lstFormula = new List<Formula>();
          Formula Formula = new Formula();
          Formula.For_id = System.Convert.ToInt64(0);
          Formula.Var_id = System.Convert.ToInt64(varn_id);
          Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
          Formula.For_nombre = System.Convert.ToString(for_nombre);
          Formula.For_valini = System.Convert.ToDecimal(0);
          Formula.For_estado = System.Convert.ToInt64(0);
          Formula.For_tipo = System.Convert.ToInt32(for_tipo);
          lstFormula.Add(Formula);

          // Save data from Formula
          FormulaController objFormulaController = new FormulaController();
          inserted = objFormulaController.save(lstFormula);
          if (inserted == 0)
          {
            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        });
      }
      return true;
    }



    private bool generarFormulaProductoMercadoCampo(long var_id, long pro_id, long mer_id, long cam_id, long varn_id)
    {

      // Formulas
      long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;
      String for_nombre = "";

      // 
      long inserted = 0;
      int contador = 0;

      // Generar formula
      // Buscar formula
      FormulaObject objFormulaObject = new FormulaObject();
      List<Formula> lstformula = new List<Formula>();
      lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
      if (lstformula.Count != 0)
      {
        lstformula.ForEach(delegate(Formula f)
        {
          for_id = f.For_id;
          var_id = f.Var_id;
          for_codigo = f.For_codigo;
          for_tipo = f.For_tipo;
          for_nombre = f.For_nombre;
          for_tipo = f.For_tipo;
        });
      }



      List<Variable> lstVariableFinal = new List<Variable>();
      VariableObject objVariableObject1 = new VariableObject();
      char[] delimiter = { ' ', '\t' };

      

      //MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      string[] tokens = for_codigo.Split(delimiter);
      // GENERAR FORMULA EN BASE A TOKENS
      foreach (string token in tokens)
      {
        Console.WriteLine("VARIABLE DE FORMULA {0}", token);
        //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
        lstVariableFinal = objVariableObject1.generarFormulaProductoMercadoCampoGeneric(lstVariableFinal, pro_id, mer_id, cam_id, token, contador);
        if (lstVariableFinal.Count != 0)
        {
          contador = lstVariableFinal.Count;
        }
      }

      // Guardar formula
      if (lstVariableFinal.Count != 0)
      {
        lstVariableFinal.ForEach(delegate(Variable vf)
        {
          // INSERTAR FÓRMULAS A LA BASE DE DATOS
          List<Formula> lstFormula = new List<Formula>();
          Formula Formula = new Formula();
          Formula.For_id = System.Convert.ToInt64(0);
          Formula.Var_id = System.Convert.ToInt64(varn_id);
          Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
          Formula.For_nombre = System.Convert.ToString(for_nombre);
          Formula.For_valini = System.Convert.ToDecimal(0);
          Formula.For_estado = System.Convert.ToInt64(0);
          Formula.For_tipo = System.Convert.ToInt32(for_tipo);
          lstFormula.Add(Formula);

          // Save data from Formula
          FormulaController objFormulaController = new FormulaController();
          inserted = objFormulaController.save(lstFormula);
          if (inserted == 0)
          {
            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        });
      }
      return true;
    }



    private bool generarFormulaProductoMercadoCampoPPijk(long var_id, string var_codigo, long pro_id, long mer_id, long cam_id, string cam_codigo, long varn_id)
    {

      // Formulas
      long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;
      String for_nombre = "";

      // 
      long inserted = 0;
      int contador = 0;

      // Generar formula
      // Buscar formula
      FormulaObject objFormulaObject = new FormulaObject();
      List<Formula> lstformula = new List<Formula>();
      lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
      if (lstformula.Count != 0)
      {
        lstformula.ForEach(delegate(Formula f)
        {
          for_id = f.For_id;
          var_id = f.Var_id;
          for_codigo = f.For_codigo;
          for_tipo = f.For_tipo;
          for_nombre = f.For_nombre;
          for_tipo = f.For_tipo;
        });
      }



      List<Variable> lstVariableFinal = new List<Variable>();
      VariableObject objVariableObject1 = new VariableObject();
      char[] delimiter = { ' ', '\t' };


      for_codigo = var_codigo + cam_codigo + " * "+ "PPijkt"; 
      //MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      string[] tokens = for_codigo.Split(delimiter);
      // GENERAR FORMULA EN BASE A TOKENS
      foreach (string token in tokens)
      {
        Console.WriteLine("VARIABLE DE FORMULA {0}", token);
        //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
        //lstVariableFinal = objVariableObject1.generarFormulaProductoMercadoCampoGeneric(lstVariableFinal, pro_id, mer_id, cam_id, token, contador);
        lstVariableFinal = objVariableObject1.generarFormulaProductoMercadoCampoPersonalizado(lstVariableFinal, pro_id, mer_id, cam_id, token, 1);
        if (lstVariableFinal.Count != 0)
        {
          contador = lstVariableFinal.Count;
        }
      }

      // Guardar formula
      if (lstVariableFinal.Count != 0)
      {
        lstVariableFinal.ForEach(delegate(Variable vf)
        {
          // INSERTAR FÓRMULAS A LA BASE DE DATOS
          List<Formula> lstFormula = new List<Formula>();
          Formula Formula = new Formula();
          Formula.For_id = System.Convert.ToInt64(0);
          Formula.Var_id = System.Convert.ToInt64(varn_id);
          Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
          Formula.For_nombre = System.Convert.ToString(for_nombre);
          Formula.For_valini = System.Convert.ToDecimal(0);
          Formula.For_estado = System.Convert.ToInt64(0);
          Formula.For_tipo = System.Convert.ToInt32(for_tipo);
          lstFormula.Add(Formula);

          // Save data from Formula
          FormulaController objFormulaController = new FormulaController();
          inserted = objFormulaController.save(lstFormula);
          if (inserted == 0)
          {
            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        });
      }
      return true;
    }



    // Formula para Variable Producto, campo, mercado general sin variaciones
    private bool generarFormulaProductoMercadoCampoNoVariaciones(long var_id, long pro_id, long mer_id, long cam_id, long varn_id)
    {

      // Formulas
      long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;
      String for_nombre = "";

      // 
      long inserted = 0;
      int contador = 0;

      // Generar formula
      // Buscar formula
      FormulaObject objFormulaObject = new FormulaObject();
      List<Formula> lstformula = new List<Formula>();
      lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
      if (lstformula.Count != 0)
      {
        lstformula.ForEach(delegate(Formula f)
        {
          for_id = f.For_id;
          var_id = f.Var_id;
          for_codigo = f.For_codigo;
          for_tipo = f.For_tipo;
          for_nombre = f.For_nombre;
          for_tipo = f.For_tipo;
        });
      }

      // Genera directamente la formula
      List<Variable> lstVariableFinal = new List<Variable>();
      VariableObject objVariableObject1 = new VariableObject();
      Variable variable3 = new Variable();
      variable3.Var_codigo = System.Convert.ToString(for_codigo);
      lstVariableFinal.Add(variable3);


      // Guardar formula
      if (lstVariableFinal.Count != 0)
      {
        lstVariableFinal.ForEach(delegate(Variable vf)
        {
          // INSERTAR FÓRMULAS A LA BASE DE DATOS
          List<Formula> lstFormula = new List<Formula>();
          Formula Formula = new Formula();
          Formula.For_id = System.Convert.ToInt64(0);
          Formula.Var_id = System.Convert.ToInt64(varn_id);
          Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
          Formula.For_nombre = System.Convert.ToString(for_nombre);
          Formula.For_valini = System.Convert.ToDecimal(0);
          Formula.For_estado = System.Convert.ToInt64(0);
          Formula.For_tipo = System.Convert.ToInt32(for_tipo);
          lstFormula.Add(Formula);

          // Save data from Formula
          FormulaController objFormulaController = new FormulaController();
          inserted = objFormulaController.save(lstFormula);
          if (inserted == 0)
          {
            MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        });
      }
      return true;
    }


    private bool generarFormulaTotal(string var_codigo, long pro_id, long varn_id)
    {

      // Formulas
      //long for_id = 0;
      //long var_id = 0;
      String for_codigo = "";
      int for_tipo = 0;
      String for_nombre = "";

      long inserted = 0;
      VariableObject objVariableObjectSuma = new VariableObject();
      Session objSession2 = new Session();

      if (objSession2.FUNCION == 1)
      {
        // Hallar Suma Por Producto de Token 
        for_codigo = objVariableObjectSuma.sumaProducto(var_codigo);

      }
      else if (objSession2.FUNCION == 2)
      {
        // Hallar Suma Por Producto - Mercado de Token 
        for_codigo = objVariableObjectSuma.sumaProductoMercado(var_codigo, pro_id);

      }

      // INSERTAR FÓRMULAS A LA BASE DE DATOS
      List<Formula> lstFormula = new List<Formula>();
      Formula Formula = new Formula();
      Formula.For_id = System.Convert.ToInt64(0);
      Formula.Var_id = System.Convert.ToInt64(varn_id);
      Formula.For_codigo = System.Convert.ToString(for_codigo);
      Formula.For_nombre = System.Convert.ToString(for_nombre);
      Formula.For_valini = System.Convert.ToDecimal(0);
      Formula.For_estado = System.Convert.ToInt64(1);
      Formula.For_tipo = System.Convert.ToInt32(for_tipo);
      lstFormula.Add(Formula);

      // Save data from Formula
      FormulaController objFormulaController = new FormulaController();
      inserted = objFormulaController.save(lstFormula);
      if (inserted == 0)
      {
        MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      return true;
    }

  } // End Class 


}
