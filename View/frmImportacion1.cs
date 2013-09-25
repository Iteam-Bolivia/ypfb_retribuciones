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
using System.IO;
using Controller;
using System.Data.OleDb;
using ypfbApplication.Model;

namespace ypfbApplication.View
{
    public partial class frmImportacion1 : Form
    {
        public Bd bd;
        // Vars
        string ruta;
        string rutaArchivo;
        long mes_id = 0;
        long ani_id = 0;

        string[] arreglo = new string[100]; //Definimos el numero de elementos

        // Listas
        List<Contrato> lstContrato = new List<Contrato>();
        List<ParExcel> lstParExcel = new List<ParExcel>();
        List<ParExcel> lstParExcelAux = new List<ParExcel>();
        List<ParExcel_Tipo> lstParExcel_Tipo = new List<ParExcel_Tipo>();
        List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
        DataSet dataSetExcel = null;



        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        public frmImportacion1()
        {
            InitializeComponent();
        }

        private void frmImportacion1_Load(object sender, EventArgs e)
        {
            Cargar();
            cbxAnio.Focus();
            this.cbxContrato.Enabled = false;
        }

        private void Cargar()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblAnio, "Seleccione un año");
            toolTip1.SetToolTip(this.cbxAnio, "Seleccione un año");

            toolTip1.SetToolTip(this.lblPeriodo, "Seleccione un mes");
            toolTip1.SetToolTip(this.cbxMes, "Seleccione un mes");

            toolTip1.SetToolTip(this.lblRutas, "muestra la ruta seleccionado");
            toolTip1.SetToolTip(this.txtRuta, "muestra la ruta seleccionado");

            toolTip1.SetToolTip(this.chbTodos, "Seleccione si desea cargar todos los archivos de la carpeta");
            //toolTip1.SetToolTip(this.lblDirectorios, "Seleccione si desea cargar todos los archivos de la carpeta");

            toolTip1.SetToolTip(this.lblContrato, "Seleccione un contrato");
            toolTip1.SetToolTip(this.lblContrato, "seleccione un contrato");

            toolTip1.SetToolTip(this.btnCargar, "Seleccion de los archivos a ser cargados");
            toolTip1.SetToolTip(this.lblContrato, "Seleccion de los archivos a ser cargados");
            
            cbxMes.Items.Add("ENERO");
            cbxMes.Items.Add("FEBRERO");
            cbxMes.Items.Add("MARZO");
            cbxMes.Items.Add("ABRIL");
            cbxMes.Items.Add("MAYO");
            cbxMes.Items.Add("JUNIO");
            cbxMes.Items.Add("JULIO");
            cbxMes.Items.Add("AGOSTO");
            cbxMes.Items.Add("SEPTIEMBRE");
            cbxMes.Items.Add("OCTUBRE");
            cbxMes.Items.Add("NOVIEMBRE");
            cbxMes.Items.Add("DICIEMBRE");
            cbxMes.SelectedIndex = DateTime.Now.Month - 1;

            int j = 2000;
            cbxAnio.Items.Add(j);
            for (int i = 1; i < 31; i++)
            {
                cbxAnio.Items.Add(j + i);
            }
            cbxAnio.Text = DateTime.Now.Year.ToString();

            List<Contrato> lstContrato = new List<Contrato>();
            lstContrato = ContratoController.GetListContrato(0);

            cbxContrato.DataSource = lstContrato;
            cbxContrato.DisplayMember = "ctt_nombre";
            cbxContrato.ValueMember = "ctt_id";

           
        }

        private void btnLoad1_Click(object sender, EventArgs e)
        {
            string hojaexcelse = "";
            DataSet DatosExcel = new DataSet();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Seleccione un archivo de excel.";
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog1.Filter = "Hojas de cálculo de Excel 2007 (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtRuta.Text = openFileDialog1.FileName;
                    hojaexcelse = txtRuta.Text.Substring(txtRuta.Text.LastIndexOf("\\") + 1).ToUpper().Replace(".XLSX","");
                     DatosExcel= CargarDataSet(txtRuta.Text, "select * from [" + hojaexcelse + "$]");
                     dgvDatosExcel.DataSource = DatosExcel.Tables[0];
                     if (hojaexcelse == "TIT" || hojaexcelse == "INV")
                     {
                         this.cbxContrato.Enabled = true;
                     }
                     else
                         this.cbxContrato.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede leer el archivo. Error original: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            mes_id = cbxMes.SelectedIndex + 1;
            ani_id = System.Convert.ToInt64(cbxAnio.Text);
            char[] delimitador = new char[] {'\\'};
            string fullname = "";
            string mesString = cbxMes.Text;
            string anioString = cbxAnio.Text;
            string contratoString = cbxContrato.Text;
            DirectoryInfo directorio = null;
            int mesInt  = 0;
            int anioInt = 0;
            int contratoInt =0;
            try
            {
                lstParExcel_Tipo = new List<ParExcel_Tipo>();
                if (txtRuta.Text != "")
                {
                    directorio = new DirectoryInfo(txtRuta.Text);
                }
                else
                {
                    throw new Exception("Error Seleccione una archivo porfavor");
                }
                ruta = System.Convert.ToString(directorio.FullName).Replace(directorio.Name, "");
                fullname = directorio.FullName;
                rutaArchivo = directorio.Name;
                rutaArchivo = rutaArchivo.Replace(".XLSX", "");
                rutaArchivo = rutaArchivo.Replace(".xlsx", "");

                foreach (var cadena in fullname.Split(delimitador))
                {
                    if (cadena.ToUpper() == contratoString.ToUpper())
                    {
                        contratoInt = 1;
                    }
                    if (cadena.ToUpper() == mesString.ToUpper())
                    {
                        mesInt = 1;
                    }
                    if (cadena.ToUpper() == anioString.ToUpper())
                    {
                        anioInt = 1;
                    }
                }
                if (cbxContrato.Enabled != false)
                {
                    if (contratoInt == 0)
                    {
                        throw new Exception("Por favor ingrese el contrato correcto.");
                    }
                }

                if (mesInt == 0)
                {
                    throw new Exception("Por favor ingrese el mes correcto");
                }
                if (anioInt == 0)
                {
                    throw new Exception("Por favor ingrese el año correcto");
                }
                // hourglass cursor
                DialogResult result = MessageBox.Show("¿Está seguro de cargar los datos?", "Inserción de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (chbTodos.Checked)
                    {
                        // Cargar varios archivos
                        if (WalkDirectoryTree(directorio.Parent))
                        {
                            ProcesarInformacion();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron una o varias hojas Excel ...");
                        }
                    }
                    else
                    {
                        // Cargar un solo archivo
                        ParExcel_Tipo objParexcel_Tipo = new ParExcel_Tipo();
                        objParexcel_Tipo.Pxt_codigo = System.Convert.ToString(rutaArchivo) + ".XLSX";
                        lstParExcel_Tipo.Add(objParexcel_Tipo);
                        ProcesarInformacion();
                    }
                    Cursor.Current = Cursors.Arrow;
                    MessageBox.Show("Se registraron la(s) hoja(s) Excel con exito !!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la carga de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// realizara el proseso de cargado de la hoja de excel y la vacia 
        /// a la base de datos
        /// </summary>
        private void ProcesarInformacion()
        {
          //dataSetExcel = new DataSet();
          string hojaexcel;
          string hojaexcelse;
          long pxt_id = 0;
          long pxt_tipo = 0;
          long pxt_recorrido = 0;
          long pxt_contratos = 0;
          ParExcelController objParExcelController = new ParExcelController();
          ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();

          // Recorrer hojas Excel
          foreach (ParExcel_Tipo item in lstParExcel_Tipo)
        	{
            //try
            //{
              DirectoryInfo directorio = new DirectoryInfo(txtRuta.Text);
              ruta = System.Convert.ToString(directorio.FullName).Replace(directorio.Name, "");

              hojaexcel = item.Pxt_codigo; // +".XLSX";
              hojaexcelse = hojaexcel.Replace(".XLSX", "");
              ruta = ruta + hojaexcel; 
              //valor de la columna
              List<ParExcel_Tipo> lstParExcelTipo = new List<ParExcel_Tipo>();
              ParExcel_TipoObject objParExcelTipo = new ParExcel_TipoObject();
              lstParExcelTipo = objParExcelTipo.listParExcel_TipoPorCodigo(hojaexcelse);

              // Verificar el tipo de parexcel:
              // Save Sesion
              lstParExcelTipo.ForEach(delegate(ParExcel_Tipo pet)
              {
                pxt_id = pet.Pxt_id;
                pxt_tipo = pet.Pxt_tipo;
                pxt_recorrido = pet.Pxt_recorrido;
                pxt_contratos = pet.Pxt_contratos;

              });

              // Lista ParExcel
              ParExcelObject objParExcel = new ParExcelObject();
              lstParExcel = objParExcel.listParExcelTipo(pxt_id);
              // DataSet
              dataSetExcel = new DataSet();
              dataSetExcel.Dispose();
              dataSetExcel = CargarDataSet(ruta, "select * from [" + hojaexcelse + "$]");


              switch (pxt_recorrido)
              {
                case 1:
                  Excel objExcel = new Excel();
                  bool flag1 = objExcel.validarRecorridoNormal(ani_id, mes_id, dataSetExcel, lstParExcel,hojaexcelse);
                  if (!flag1)
                  objExcel.RecorridoNormal(dataSetExcel,  lstParExcel,hojaexcelse);
                  else
                  {
                      DialogResult result = MessageBox.Show("Ya se registro la hoja excel " + hojaexcelse + ", desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                      if (result == DialogResult.Yes)
                      {
                          objExcel.eliminarCalculo_variable(ani_id, mes_id, lstParExcel,0);
                          objExcel.RecorridoNormal(dataSetExcel, lstParExcel, hojaexcelse);
                          Cursor.Current = Cursors.WaitCursor;
                      }
                      Cursor.Current = Cursors.WaitCursor;
                  }
                  break;

                case 2:
                  Excel objExcel2 = new Excel();
                  bool flag2 = objExcel2.ValidarRecorridoColumna(dataSetExcel, mes_id, ani_id, lstParExcel, hojaexcelse);
                  if (!flag2)
                      objExcel2.RecorridoColumna(dataSetExcel, mes_id, ani_id, lstParExcel, hojaexcelse);
                  else
                  {
                      DialogResult result = MessageBox.Show("Ya se registro la hoja excel " + hojaexcelse + ", desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                      if (result == DialogResult.Yes)
                      {
                          objExcel2.eliminarCalculo_variable(ani_id, mes_id, lstParExcel,0);
                          objExcel2.RecorridoColumna(dataSetExcel, mes_id, ani_id, lstParExcel,hojaexcelse);
                          Cursor.Current = Cursors.WaitCursor;
                      }
                      Cursor.Current = Cursors.WaitCursor;
                  }
                  break;

                case 3:
                  Excel objExcel3 = new Excel();
                  bool flag3 = objExcel3.validaRecorridoFila(dataSetExcel, lstParExcel, mes_id, ani_id, System.Convert.ToInt64(cbxContrato.SelectedValue),hojaexcelse);
                  if (!flag3)
                      objExcel3.RecorridoFila(dataSetExcel, mes_id, ani_id, lstParExcel, System.Convert.ToInt64(cbxContrato.SelectedValue),hojaexcelse);
                  else
                  {
                      DialogResult result = MessageBox.Show("Ya se registro la hoja excel " + hojaexcelse + ", desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                      if (result == DialogResult.Yes)
                      {
                          objExcel3.eliminarCalculo_variable(ani_id, mes_id, lstParExcel, System.Convert.ToInt64(cbxContrato.SelectedValue));
                          objExcel3.RecorridoFila(dataSetExcel, mes_id, ani_id, lstParExcel, System.Convert.ToInt64(cbxContrato.SelectedValue),hojaexcelse);
                          Cursor.Current = Cursors.WaitCursor;
                      }
                      Cursor.Current = Cursors.WaitCursor;
                  }
                  break;

                case 4:
                  Excel objExcel4 = new Excel();
                  bool flag4 = false;
                      if(hojaexcelse == "IDH")
                          flag4 = objExcel4.validarAuxiliarIDHyREG(ani_id, mes_id, dataSetExcel, lstParExcel, "I", "",hojaexcelse);
                      else
                        flag4 = objExcel4.validarAuxiliarIDHyREG(ani_id, mes_id, dataSetExcel, lstParExcel, "P", "R", hojaexcelse);
                  if (!flag4)
                      objExcel4.AuxiliarIDHyREG(dataSetExcel, lstParExcel, hojaexcelse);
                  else
                  {
                      DialogResult result = MessageBox.Show("Ya se registro la hoja excel " + hojaexcelse + ", desea actualizar los datos", "Actualización de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                      if (result == DialogResult.Yes)
                      {
                          if (hojaexcelse == "IDH")
                          {
                              objExcel4.ActualizarRegaliasIDH(ani_id, mes_id, 'I');
                              Cursor.Current = Cursors.WaitCursor;
                          }
                          else
                          {
                              objExcel4.ActualizarRegaliasIDH(ani_id, mes_id, 'P');
                              objExcel4.ActualizarRegaliasIDH(ani_id, mes_id, 'R');
                              Cursor.Current = Cursors.WaitCursor;
                          }
                          objExcel4.AuxiliarIDHyREG(dataSetExcel, lstParExcel, hojaexcelse);
                          Cursor.Current = Cursors.WaitCursor;
                      }
                  }
                  break;
                default:
                  break;

              }
              dataSetExcel.Dispose();
            //}
            //catch (Exception ex)
            //{
                
            //}
          }
          lstParExcel_Tipo = null;


        }



        /// <summary>
        /// Procedimiento para cargar una seria de archivos
        /// </summary>
        /// <param name="directory">Directorio a cargar</param>
        private bool WalkDirectoryTree(DirectoryInfo directory)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            int i = 0;
            // First, process all the files directly under this folder
            try
            {
                files = directory.GetFiles("*.xlsx");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            List<ParExcel> lstparexcel = new List<ParExcel>();
            ParExcelController objParExcelController = new ParExcelController();
            lstparexcel = objParExcelController.load();
            bool Flag= false;
            if (files != null)
            {
                foreach (ParExcel parExcel in lstparexcel)
                
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    //MessageBox.Show(fi.FullName, "Carga siclo de archivos");


                  
                    
                    foreach (System.IO.FileInfo fi in files)
                    {
                        string file = fi.Name.ToUpper();
                        string pxtCodigo = parExcel.Pxt_codigo.ToUpper() + ".XLSX";
                        if (file.Equals(pxtCodigo) )
                        {
                            // Buscar las hojas excel que se encuentra en el directorio
                          ParExcel_Tipo objParexcel_Tipo = new ParExcel_Tipo();
                            objParexcel_Tipo.Pxt_codigo = System.Convert.ToString(file);
                            lstParExcel_Tipo.Add(objParexcel_Tipo);
                            Flag = true;
                            i++;
                            //break;
                        }
                        else
                        {
                            //Flag = false;
                        }
                        
                    }
                    if (!Flag)
                    {
                        //MessageBox.Show("No se encontro la hoja excel " + parExcel.Pxt_codigo);
                        //break;
                    }
                    else
                    {
                        //Flag = false;
                    }
                }
                //if (Flag)
                //{
                //    //MessageBox.Show("se encontraron todas las hoja excel");
                //}



                //// Now find all the subdirectories under this directory.
                //subDirs = directory.GetDirectories();

                //foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                //{
                //    // Resursive call for each subdirectory.
                //    WalkDirectoryTree(dirInfo);
                //}
            }
            return Flag;
        }




        /// <summary>
        /// realizo la coneccion y envio la consulta
        /// </summary>
        /// <param name="QueryString">Consulta a ser prosedada</param>
        /// <returns>DataSet cargado.</returns>
        public DataSet CargarDataSet(string ruta, string QueryString)
        {
          string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=\'Excel 12.0;HDR=NO\'";
          DataSet SetDeDatos;
          SetDeDatos = new DataSet();

          try
          {
            using (OleDbConnection SqlConnection = new OleDbConnection(ConnectionString))
            {
              if (SqlConnection != null)
              {
                OleDbCommand SqlCommand = new OleDbCommand();

                SqlCommand.CommandTimeout = 0;
                SqlCommand.CommandText = QueryString;
                SqlCommand.Connection = SqlConnection;

                using (OleDbDataAdapter SqlDataAdapter = new OleDbDataAdapter(SqlCommand))
                {
                  SqlDataAdapter.Fill(SetDeDatos);
                }
              }
              SqlConnection.Close();
            }

          }
          catch (Exception ex)
          {
            throw new Exception(ex.Message);
          }
          return SetDeDatos;
        }

        private void cbxAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void chbTodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnLoad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        
    }
}
