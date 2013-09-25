using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;
using Controller;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace ypfbApplication.View
{
    public partial class frmImportacion : Form
    {
        List<Contrato> lstContrato = new List<Contrato>();
        List<ParExcel> lstParExcel = new List<ParExcel>();
        List<ParExcel> lstParExcelAux = new List<ParExcel>();
        List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
        Contrato_Campo[] contratoCampoValidador = null;
        int tipoHoja = 0;

        int index = 0;
        string ruta;
        DataSet dataSetExcel = null;

        long mesInt = 0;
        long anio = 0;



        public frmImportacion()
        {
            InitializeComponent();
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Seleccione un archivo de excel.";
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog1.Filter = "Hojas de cálculo de Excel 1997-2003 (*.xls)|*.xls|Hojas de cálculo de Excel 2007-2010 (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (dataGridView1.DataSource != null)
                dataGridView1.DataSource = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lblDireccion.Text = openFileDialog1.SafeFileName;
                    ruta = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblDireccion.Text != "")
                ProsesarInformacion();
            else
                MessageBox.Show("Por favor seleccione la hoja a ser cargado.");
        }


        private void frmImportacion_Load(object sender, EventArgs e)
        {
            Cargar();
        }



        private void cbxCttCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index1 = cbxCttCodigo.SelectedIndex;
            //lblCtt_nombre.Text = lstContrato[index].Ctt_nombre;
        }



        private void cbxPex_hoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = cbxPex_hoja.SelectedIndex;
            lblNombreHoja.Text = lstParExcel[index].Pex_hoja;
            //if (lblNombreHoja.Text == "inf_empresa")
            //{
            //    cbxCttCodigo.Visible = true;
            //    lblCttCodigo.Visible = true;
            //    lblCttNombre.Visible = true;
            //    lblCtt_nombre.Visible = true;
            //}
            //else
            //{
            //    cbxCttCodigo.Visible = false;
            //    lblCttCodigo.Visible = false;
            //    lblCttNombre.Visible = false;
            //    lblCtt_nombre.Visible = false;
            //}
            if (dataGridView1.DataSource != null)
                dataGridView1.DataSource = null;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        /// <summary>
        /// Carga todos los valores necesarios para el load.
        /// </summary>
        private void Cargar()
        {

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            //toolTip1.SetToolTip(this.lblCtt_nombre, "Muestra el nombre del contrato seleccionado");
            //toolTip1.SetToolTip(this.lblCttNombre, "Muestra el nombre del contrato seleccionado");

            //toolTip1.SetToolTip(this.lblCttCodigo, "Seleccione el código del contrato");
            //toolTip1.SetToolTip(this.cbxCttCodigo, "Seleccione el código del contrato");

            toolTip1.SetToolTip(this.LblExplorar, "Muestra el nombre de diección del archivo de excel a ser cargado");
            toolTip1.SetToolTip(this.lblDireccion, "Muestra el nombre de diección del archivo de excel a ser cargado");


            toolTip1.SetToolTip(this.LblHoja, "Seleccione el nombre de la hoja que sera cargar");
            toolTip1.SetToolTip(this.cbxPex_hoja, "Seleccione el nombre de la hoja que sera cargar");


            toolTip1.SetToolTip(this.LblPeriodo, "seleccione el mes y el año de la hoja a carga");
            toolTip1.SetToolTip(this.cbxMes, "Seleccione el mes de la hoja a carga");
            toolTip1.SetToolTip(this.cbxAnio, "Seleccione el año de la hoja a carga");

            toolTip1.SetToolTip(this.btnLoad, "Mostrata una ventana para selección el archivo excel");

            //lstContrato = ContratoController.GetListContratosBySucursal(0);
            //cbxCttCodigo.DataSource = lstContrato;
            //cbxCttCodigo.DisplayMember = "Ctt_codigo";
            //cbxCttCodigo.ValueMember = "Ctt_id";

            //lblCtt_nombre.Text = lstContrato[0].Ctt_nombre;


            ParExcelController objParExcelController = new ParExcelController();
            lstParExcel = objParExcelController.load();

            lstParExcel = objParExcelController.load();

            cbxPex_hoja.DataSource = lstParExcel;
            cbxPex_hoja.DisplayMember = "Pex_Nombre";
            cbxPex_hoja.ValueMember = "Pex_id";

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

            int j = 2007;
            cbxAnio.Items.Add(j);
            for (int i = 1; i < 24; i++)
            {
                cbxAnio.Items.Add(j + i);
            }

            cbxAnio.Text = DateTime.Now.Year.ToString();
        }




        /// <summary>
        /// realizara el proseso de cargado de la hoja de excel y la vacia 
        /// a la base de datos
        /// </summary>
        private void ProsesarInformacion()
        {
            //dataSetExcel = new DataSet();

            ParExcelController objParExcelController = new ParExcelController();
            ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();

            Session session = new Session();
            session.ID = Convert.ToInt64(cbxPex_hoja.SelectedValue);

            //valor de la columna
            try
            {
                //Cargo la clase parExcel
                lstParExcelAux = objParExcelController.find();

                //Cargo la Calse ParExcelColumna
                lstParExcelColumna = objParExcelColumnaController.findOrderByColumna();
                int indexParExcel = cbxPex_hoja.SelectedIndex;
                //Cargo el con la consulta la hoja de excel y la vasio en un DataSet.3
                string[] hoja = lstParExcel[indexParExcel].Pex_hoja.Split(',');
                for (int i = 0; i < hoja.Count(); i++)
                {
                    if (dataSetExcel != null)
                    {
                        dataSetExcel = CargarDataSet("select * from [" + hoja[i].ToString() + "$]");
                    }
                    else
                    {
                        dataSetExcel = new DataSet();
                        dataSetExcel = CargarDataSet("select * from [" + hoja[i].ToString() + "$]");
                    }
                    //dataSetExcel = CargarDataSet("select * from [" + lstParExcelAux[indexParExcel].Pex_hoja + "$]");
                    tipoHoja = cbxPex_hoja.SelectedIndex;
                    ////verificar tanto campos campos como operadores
                    if (ValidarCampo(dataSetExcel, lstParExcelColumna))
                    {
                        cargarBaseDatos(dataSetExcel, lstParExcelColumna);
                        dataGridView1.DataSource = dataSetExcel.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show(ex.Message, "Error en la carga de datos.", MessageBoxButtons.OK);
            }
        }

        //Validar Campos
        private bool ValidarCampo(DataSet dataSetExcel, List<ParExcel_Columna> lstParExcelColumna)
        {
            int valorColumna = recuperarValorColumna(lstParExcelColumna, 0);
            int cambioColumna = 0;
            int contadorPaxExcelColumna = 0;
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();

            List<Campo> lstCampo = null;
            int fila = 0;
            string messtring = "";
            Campo objCampo = null;
            bool flag = true;
            //Validar Fecha

            // CONSULTAR CON TIPOS DE CARGA: GN, GNE, ETC.
            
            //if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "INVERSION Y COSTO")
            //{
            //    if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "CERTIFICACIONES PRODUCCIÓN")
            //    {
            //        if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "REGALIAS")
            //        {
            //            if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "IDH")
            //            {
                            if (messtring.ToUpper() != cbxMes.Text || anio.ToString() != cbxAnio.Text)
                            {
                                throw new Exception("Por favor seleccione una fecha y un año igual a la hoja de calculo a ser cargada");
                            }
            //            else
            //            {
            //                DialogResult result = MessageBox.Show("Ya se registro la hoja excel de IDH, desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo);
            //                if (result == DialogResult.Yes)
            //                {
            //                    ActualizarIDH();
            //                }
            //                else
            //                {
            //                    flag = false;
            //                    return flag;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            DialogResult result = MessageBox.Show("Ya se registro la hoja excel de REGALIAS, desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo);
            //            if (result == DialogResult.Yes)
            //            {
            //                ActualizarRegalias();
            //            }
            //            else
            //            {
            //                flag = false;
            //                return flag;
            //            }
            //        }
            //    }
            //}
            //if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "INSUMOS")
            //{

                valorColumna = recuperarValorColumna(lstParExcelColumna, 0);
                int filaComienzo = (int)lstParExcelColumna[0].Pec_fila - 2;
                for (fila = filaComienzo; fila < dataSetExcel.Tables[0].Rows.Count; fila++)
                {
                    if (fila >= 0)
                    {
                        if (lstParExcelColumna[contadorPaxExcelColumna].Tco_nombre.ToUpper() == "OPERADOR")
                        {
                            if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() != "")
                            {
                                string total = dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim().ToUpper();
                                if (!total.StartsWith("TOTAL") )//&& total.ToLower() !="OPERADOR".ToLower())
                                {
                                    if (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Length <= 50)
                                    {
                                        lstTitularContrato = TitularContratoController.SerchByName(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim());
                                        if (lstTitularContrato.Count != 0)
                                        {
                                            cambioColumna++;
                                            valorColumna = recuperarValorColumna(lstParExcelColumna, cambioColumna);
                                            contadorPaxExcelColumna++;
                                        }
                                        else
                                        {
                                            throw new Exception("Por favor verifique el operador: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() + " no existe en la base de datos");
                                        }
                                    }
                                }
                                else
                                {
                                    fila = dataSetExcel.Tables[0].Rows.Count;
                                }
                            }
                        }
                        if (lstParExcelColumna[contadorPaxExcelColumna].Tco_nombre.ToUpper() == "CAMPO")
                        {
                            lstCampo = new List<Campo>();
                            objCampo = new Campo();
                            for (int c = fila; c < dataSetExcel.Tables[0].Rows.Count; c++)
                            {
                                if (dataSetExcel.Tables[0].Rows[c][valorColumna].ToString() != "" && dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().StartsWith("TOTAL") == false && dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Length < 50)
                                {
                                    objCampo = CampoController.SerchCampoByName(dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().Replace("*", ""));
                                    if (objCampo != null)
                                    {
                                        lstCampo.Add(objCampo);
                                    }
                                    else
                                    {

                                        throw new Exception("Por favor revise el campo: " + dataSetExcel.Tables[0].Rows[c][valorColumna].ToString() +
                                            " no se encuentra en la base de datos");
                                    }
                                }
                                else if (dataSetExcel.Tables[0].Rows[c][valorColumna].ToString().Trim().StartsWith("TOTAL"))
                                {
                                    //Verificar que cada campo tengo su respectivo contrato
                                    if (lstTitularContrato.Count > 0)
                                    {
                                        contratoCampoValidador = new Contrato_Campo[lstCampo.Count];
                                        List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                                        for (int t = 0; t < lstTitularContrato.Count; t++)
                                        {
                                            lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitularContrato[t].Ctt.Ctt_id);

                                            for (int contContrato = 0; contContrato < lstContratoCampo.Count; contContrato++)
                                            {
                                                for (int c1 = 0; c1 < lstCampo.Count; c1++)
                                                {
                                                    if (lstCampo[c1].Cam_nombre == lstContratoCampo[contContrato].Cam_nombre)
                                                    {
                                                        contratoCampoValidador[c1] = lstContratoCampo[contContrato];
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (contratoCampoValidador.Count() == lstCampo.Count)
                                        {
                                            for (int m = 0; m < lstCampo.Count(); m++)
                                            {
                                                if (contratoCampoValidador[m] == null)
                                                {
                                                    throw new Exception("Error con el operador " + lstTitularContrato[0].Tit.Tit_nombre + " y con el campo: " + lstCampo[m].Cam_nombre);
                                                }
                                            }
                                            cambioColumna = 0;
                                            valorColumna = recuperarValorColumna(lstParExcelColumna, cambioColumna);
                                            fila = (int)lstParExcelColumna[0].Pec_fila - 2;
                                            contadorPaxExcelColumna = 0;
                                            fila = c;
                                            c = dataSetExcel.Tables[0].Rows.Count;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                flag = objCalculoVariableController.ValidaCalculo(anio, mesInt, lstParExcel[tipoHoja].Pex_id, 0,0);
                if (lstCalculoVariable.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Ya se registro la hoja excel, desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        eliminarCalculo_variable(lstCalculoVariable);
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }

            //}
            //else if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "CERTIFICACIONES PRODUCCIÓN")
            //{
                for (int i = 0; i < lstParExcelColumna.Count; i++)
                {
                    if (lstParExcelColumna[i].Tco_nombre.ToUpper() == "OPERADOR")
                    {
                        cambioColumna = i;
                        valorColumna = recuperarValorColumna(lstParExcelColumna, cambioColumna);
                        break;
                    }
                }
                filaComienzo = (int)lstParExcelColumna[0].Pec_fila - 2;
                for (fila = filaComienzo; fila < dataSetExcel.Tables[0].Rows.Count; fila++)
                {
                    if (fila >= 0)
                    {
                        if ((dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() != "" && dataSetExcel.Tables[0].Rows[fila][valorColumna + 1].ToString() != "")
                            && (dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() != "-" && dataSetExcel.Tables[0].Rows[fila][valorColumna + 1].ToString() != "-"))
                        {
                            lstTitularContrato = TitularContratoController.SerchByName(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim());
                            if (lstTitularContrato.Count == 0)
                            {
                                throw new Exception("Por favor verifique el operador: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() + " no existe en la base de datos");
                            }
                            else
                            {
                                cambioColumna++;
                                valorColumna = recuperarValorColumna(lstParExcelColumna, cambioColumna);
                                contadorPaxExcelColumna++;
                            }
                            objCampo = CampoController.SerchCampoByName(dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString().Trim().Replace("*", ""));
                            if (objCampo == null)
                            {
                                throw new Exception("Por favor revise el campo: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() +
                                    " no se encuentra en la base de datos");
                            }
                        }
                        if (cambioColumna > 0)
                        {
                            cambioColumna--;
                            valorColumna = recuperarValorColumna(lstParExcelColumna, cambioColumna);
                        }
                    }
                }
            //}
            //else if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "TITULAR")
            //{
                fila = recuperarValorColumna(lstParExcelColumna, 0);
                for (int f = fila; f < dataSetExcel.Tables[0].Rows.Count - 1; f++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("CONTRATO"))
                        {
                            string nombreContrato = dataSetExcel.Tables[0].Rows[f][i].ToString().Replace("CONTRATO:", "");
                            lstTitularContrato = TitularContratoController.listaTitularesPorNombreContrato(nombreContrato.Trim());
                            if (lstTitularContrato.Count > 0)
                            {
                                flag = objCalculoVariableController.ValidaCalculo(anio, mesInt, lstParExcel[tipoHoja].Pex_id, 0, lstParExcel[tipoHoja].Tcl_id);
                                if (lstCalculoVariable.Count > 0)
                                {
                                    DialogResult result = MessageBox.Show("Ya se registro la hoja excel, desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                    {
                                        eliminarCalculo_variable(lstCalculoVariable);
                                    }
                                    else
                                    {
                                        flag = false;
                                        return flag;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Error no se encontro al operador: " + dataSetExcel.Tables[0].Rows[fila][valorColumna].ToString() + "Por favor verifique");
                            }
                        }
                    }
                    
                }
            //}
            //else
            //{
            //    if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "INVERSION Y COSTO" || lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() != "CERTIFICACIONES PRODUCCIÓN")
            //    {
                    for (int f = 0; f < dataSetExcel.Tables[0].Rows.Count; f++)
                    {
                        if (lstParExcelColumna[contadorPaxExcelColumna].Tco_nombre.ToLower().Trim() == "contrato".Trim().ToLower())
                        {
                            Contrato contrato = new Contrato();
                            if (f >= 0)
                            {
                                if (dataSetExcel.Tables[0].Rows[f][valorColumna].ToString().StartsWith("CONTRATO"))
                                {
                                    string nombreContrato = dataSetExcel.Tables[0].Rows[f][valorColumna].ToString().Replace("CONTRATO: ", "");
                                    lstTitularContrato = TitularContratoController.listaTitularesPorNombreContrato(nombreContrato.Trim());
                                    if (lstTitularContrato.Count > 0)
                                    {
                                        flag = objCalculoVariableController.ValidaCalculo(anio, mesInt, lstParExcel[tipoHoja].Pex_id, lstTitularContrato[0].Ctt.Ctt_id, 0);
                                        if (lstCalculoVariable.Count > 0)
                                        {
                                            DialogResult result = MessageBox.Show("Ya se registro la hoja excel, desea actualizar los datos", "Actualizacion de datos", MessageBoxButtons.YesNo);
                                            if (result == DialogResult.Yes)
                                            {
                                                eliminarCalculo_variable(lstCalculoVariable);
                                            }
                                            else
                                            {
                                                flag = false;
                                                return flag;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
            //    }
            //}
            return flag;
        }






        private void cargarBaseDatos(DataSet dataSetExcel, List<ParExcel_Columna> lstParExcelColumna)
        {
            List<Contrato> lstContrato = new List<Contrato>();

            List<Titular_Contrato> lstTitutla = new List<Titular_Contrato>();
            List<Campo> lstCampo = new List<Campo>();
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
            List<Contrato_Campo> lstContratoCampoPorCtt = new List<Contrato_Campo>();
            List<Contrato_Campo> lstContratoAIngresar = new List<Contrato_Campo>();
            List<Calculo> lstAddCalculo = null;
            Titular_Contrato titularContrato = null;
            List<Calculo_Variable> lstCalculoVariable = null;
            Variable variable = new Variable();
            VariableController objVariableController = new VariableController();
            Contrato contrato = null;
            Calculo AddCaldulo = new Calculo();
            CalculoController objCalculoController = new CalculoController();
            Campo campo;
            Calculo_Variable AddCalculo_Variable = new Calculo_Variable();
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();

            List<Calculo> lstCalculo = new List<Calculo>();
            Calculo objCalculo = new Calculo();

            int cont1 = 0;

            string titular = string.Empty;
            string campoString = string.Empty;

            long Cal_id = 0;

            Contrato_Campo[] lstContratoCampoPorCtt1 = new Contrato_Campo[100];

            int q = 0;
            int i = recuperarValorColumna(lstParExcelColumna, q);
            int fila = (int)lstParExcelColumna[0].Pec_fila - 2;

            int parexcel1 = 0;
            //int parexcel11 = 0;
            string mes = "";
            for (int f = fila; f < dataSetExcel.Tables[0].Rows.Count - 1; f++)
            {
                //if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "INSUMOS")
                //{
                    if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "operador")
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                        {
                            string total = dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToUpper();
                            if (!total.StartsWith("TOTAL")) ///&& !total.StartsWith("OPERADOR"))
                            {
                                lstTitutla = TitularContratoController.SerchByName(dataSetExcel.Tables[0].Rows[f][i].ToString().Trim());
                                if (lstTitutla.Count != 0)
                                {
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    f = f - 1;
                                    parexcel1++;
                                }
                            }
                            else
                            {
                                f = dataSetExcel.Tables[0].Rows.Count;
                            }
                        }
                    }

                    else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "campo")
                    {
                        lstCampo = new List<Campo>();
                        for (int c = f; c < dataSetExcel.Tables[0].Rows.Count; c++)
                        {
                            if (dataSetExcel.Tables[0].Rows[c][i].ToString() != "" && dataSetExcel.Tables[0].Rows[c][i].ToString().StartsWith("TOTAL") == false)
                            {
                                lstCampo.Add(CampoController.SerchCampoByName(dataSetExcel.Tables[0].Rows[c][i].ToString().Trim().Replace("*", "")));

                            }
                            else if (dataSetExcel.Tables[0].Rows[c][i].ToString().Trim().StartsWith("TOTAL"))
                            {
                                q++;
                                i = recuperarValorColumna(lstParExcelColumna, q);
                                f = f - 1;
                                parexcel1++;
                                break;
                            }
                        }
                        if (lstTitutla.Count > 0)
                        {
                            contratoCampoValidador = new Contrato_Campo[lstCampo.Count];
                            //List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                            for (int t = 0; t < lstTitutla.Count; t++)
                            {
                                lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitutla[t].Ctt.Ctt_id);
                                for (int contContrato = 0; contContrato < lstContratoCampo.Count; contContrato++)
                                {
                                    for (int c1 = 0; c1 < lstCampo.Count; c1++)
                                    {
                                        if (lstCampo[c1].Cam_nombre == lstContratoCampo[contContrato].Cam_nombre)
                                        {
                                            contratoCampoValidador[c1] = lstContratoCampo[contContrato];
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        titularContrato = new Titular_Contrato();
                        int comienza = i;
                        int ComienzaQ = q;
                        foreach (Contrato_Campo item in contratoCampoValidador)
                        {
                            lstCalculo = objCalculoController.Validar(item.Ctt_id, mesInt, anio,0);
                            if (lstCalculo.Count > 0)
                            {
                                foreach (Calculo calculo in lstCalculo)
                                {
                                    if (item.Ctt_id != calculo.Ctt_id)
                                    {
                                        lstAddCalculo = new List<Calculo>();
                                        AddCaldulo = new Calculo();
                                        AddCaldulo.Cal_id = 0;
                                        AddCaldulo.Ctt_id = item.Ctt_id;
                                        AddCaldulo.Cal_fecha = DateTime.Now;
                                        AddCaldulo.Ani_id = Convert.ToInt64(cbxAnio.Text);
                                        AddCaldulo.Mes_id = cbxMes.SelectedIndex + 1;
                                        AddCaldulo.Mon_id = 2;
                                        AddCaldulo.Cal_valor = 0;
                                        AddCaldulo.Cal_valorajustado = 0;
                                        AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                        AddCaldulo.Cal_estado = 1;
                                        lstAddCalculo.Add(AddCaldulo);
                                        Cal_id = objCalculoController.save(lstAddCalculo);
                                    }
                                    else if ((calculo.Mes_id != mesInt) || (calculo.Ani_id != anio))
                                    {
                                        lstAddCalculo = new List<Calculo>();
                                        AddCaldulo = new Calculo();
                                        AddCaldulo.Cal_id = 0;
                                        AddCaldulo.Ctt_id = item.Ctt_id;
                                        AddCaldulo.Cal_fecha = DateTime.Now;
                                        AddCaldulo.Ani_id = Convert.ToInt64(cbxAnio.Text);
                                        AddCaldulo.Mes_id = cbxMes.SelectedIndex + 1;
                                        AddCaldulo.Mon_id = 2;
                                        AddCaldulo.Cal_valor = 0;
                                        AddCaldulo.Cal_valorajustado = 0;
                                        AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                        AddCaldulo.Cal_estado = 1;
                                        lstAddCalculo.Add(AddCaldulo);
                                        Cal_id = objCalculoController.save(lstAddCalculo);
                                    }
                                    else
                                    {
                                        Cal_id = calculo.Cal_id;
                                        break;
                                    }
                                }
                            }
                            if (lstCalculo.Count == 0)
                            {
                                lstAddCalculo = new List<Calculo>();
                                AddCaldulo = new Calculo();
                                AddCaldulo.Cal_id = 0;
                                AddCaldulo.Ctt_id = item.Ctt_id;
                                AddCaldulo.Cal_fecha = DateTime.Now;
                                AddCaldulo.Ani_id = Convert.ToInt64(cbxAnio.Text);
                                AddCaldulo.Mes_id = cbxMes.SelectedIndex + 1;
                                AddCaldulo.Mon_id = 2;
                                AddCaldulo.Cal_valor = 0;
                                AddCaldulo.Cal_valorajustado = 0;
                                AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                AddCaldulo.Cal_estado = 1;
                                lstAddCalculo.Add(AddCaldulo);
                                Cal_id = objCalculoController.save(lstAddCalculo);
                            }
                            for (int c = q; c < lstParExcelColumna.Count; c++)
                            {
                                if ((item.Ctt_id > 0) || (Cal_id > 0))
                                {
                                    if (!dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToLower().StartsWith("total"))
                                    {
                                        lstCalculoVariable = new List<Calculo_Variable>();
                                        AddCalculo_Variable.Cav_id = 0;
                                        AddCalculo_Variable.Cal_id = Cal_id;
                                        AddCalculo_Variable.Cam_id = item.Cam_id;
                                        AddCalculo_Variable.Pro_id = lstParExcel[tipoHoja].Pro_id;
                                        AddCalculo_Variable.Mer_id = lstParExcelColumna[c].Mer_id;
                                        AddCalculo_Variable.Var_id = lstParExcelColumna[c].Var_id;
                                        AddCalculo_Variable.Umd_id = lstParExcelColumna[c].Umd_id;
                                        if (lstParExcelColumna[c].Tco_nombre.Trim().ToLower() == "MONTO".ToLower().Trim())
                                        {
                                            AddCalculo_Variable.Mon_id = 2;
                                        }
                                        else
                                        {
                                            AddCalculo_Variable.Mon_id = 0;
                                        }
                                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                                            if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "-")
                                                if (lstParExcelColumna[c].Pec_iva == false)
                                                {
                                                    if (lstParExcel[tipoHoja].Tcl_id == 2)
                                                    {
                                                        decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()) / 1000;
                                                        AddCalculo_Variable.Cav_valor = valorsinIva * Convert.ToDecimal(0.87);
                                                    }
                                                    else
                                                    {
                                                        decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                                        AddCalculo_Variable.Cav_valor = valorsinIva * Convert.ToDecimal(0.87);
                                                    }
                                                }
                                                else
                                                {
                                                    if (lstParExcel[tipoHoja].Tcl_id == 2)
                                                    {
                                                        AddCalculo_Variable.Cav_valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString()) / 1000;
                                                    }
                                                    else
                                                    {
                                                        AddCalculo_Variable.Cav_valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                                    }
                                                }
                                            else
                                                AddCalculo_Variable.Cav_valor = 0;
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                        AddCalculo_Variable.Cav_estado = 1;
                                        AddCalculo_Variable.Cav_tipo = "Y";
                                        AddCalculo_Variable.Pex_id = lstParExcel[tipoHoja].Pex_id;
                                        lstCalculoVariable.Add(AddCalculo_Variable);
                                        objCalculoVariableController.save(lstCalculoVariable);
                                    }
                                }
                                else
                                {
                                    if (objCalculo.Cal_id != 0)
                                        throw new Exception("Error en el id del calculo. " + objCalculo.Cal_id);
                                    if (item.Cam_id != 0)
                                        throw new Exception("Error en el id del campo. " + item.Cam_id + " " + item.Cam_nombre);
                                    if (titularContrato.Ctt.Ctt_id != 0)
                                        throw new Exception("Error en el id del titular. " + titularContrato.Ctt.Ctt_id + " " + titularContrato.Ctt.Ctt_nombre);
                                    if (item.Ctt_id != 0)
                                        throw new Exception("Error en el id del contrato. " + item.Ctt_id);
                                }
                                if (q < lstParExcelColumna.Count - 1)
                                {
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                }
                            }
                            i = comienza;
                            q = ComienzaQ;
                            f = f + 1;
                        }
                        q = 0;
                        i = recuperarValorColumna(lstParExcelColumna, q);
                        parexcel1 = 0;
                    }
                //}
                //else if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "TITULAR")
                //{
                    if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "contrato".Trim().ToLower())
                    {
                        contrato = new Contrato();
                        if (f >= 0)
                        {
                            if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("CONTRATO"))
                            {
                                string nombreContrato = dataSetExcel.Tables[0].Rows[f][i].ToString().Replace("CONTRATO: ", "");
                                lstTitutla = TitularContratoController.listaTitularesPorNombreContrato(nombreContrato.Trim());
                            }
                            else if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("PERIODO"))
                            {
                                mes = dataSetExcel.Tables[0].Rows[f][i].ToString().Replace("PERIODO (MES): ", "").Trim().ToString().ToUpper();
                                switch (mes)
                                {
                                    case "ENERO":
                                        mesInt = 1;
                                        break;
                                    case "FEBRERO":
                                        mesInt = 2;
                                        break;
                                    case "MARZO":
                                        mesInt = 3;
                                        break;
                                    case "ABRIL":
                                        mesInt = 4;
                                        break;
                                    case "MAYO":
                                        mesInt = 5;
                                        break;
                                    case "JUNIO":
                                        mesInt = 6;
                                        break;
                                    case "JULIO":
                                        mesInt = 7;
                                        break;
                                    case "AGOSTO":
                                        mesInt = 8;
                                        break;
                                    case "SEPTIEMBRE":
                                        mesInt = 9;
                                        break;
                                    case "OCTUBRE":
                                        mesInt = 10;
                                        break;
                                    case "NOVIEMBRE":
                                        mesInt = 11;
                                        break;
                                    case "DICIEMBRE":
                                        mesInt = 10;
                                        break;
                                }

                            }
                            else if (dataSetExcel.Tables[0].Rows[f][i].ToString().StartsWith("AÑO"))
                            {
                                anio = Convert.ToInt32(dataSetExcel.Tables[0].Rows[f][i].ToString().Replace("AÑO: ", "").Trim().ToString());
                            }
                            else
                            {
                                if (lstTitutla.Count() > 0)
                                {
                                    lstCalculo = objCalculoController.Validar(lstTitutla[0].Ctt.Ctt_id, mesInt, anio,0);
                                    if (lstCalculo.Count == 0)
                                    {
                                        ///empiezo el carago de los datos
                                        lstAddCalculo = new List<Calculo>();
                                        AddCaldulo = new Calculo();
                                        AddCaldulo.Cal_id = 0;
                                        AddCaldulo.Ctt_id = lstTitutla[0].Ctt.Ctt_id;
                                        AddCaldulo.Cal_fecha = DateTime.Now;
                                        AddCaldulo.Ani_id = Convert.ToInt64(cbxAnio.Text);
                                        AddCaldulo.Mes_id = cbxMes.SelectedIndex + 1;
                                        AddCaldulo.Mon_id = 2;
                                        AddCaldulo.Cal_valor = 0;
                                        AddCaldulo.Cal_valorajustado = 0;
                                        AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                        AddCaldulo.Cal_estado = 1;
                                        lstAddCalculo.Add(AddCaldulo);
                                        Cal_id = objCalculoController.save(lstAddCalculo);
                                    }
                                    else
                                    {
                                        if ((lstCalculo[0].Ani_id == anio) && (lstCalculo[0].Mes_id == mesInt) && (lstCalculo[0].Ctt_id == lstTitutla[0].Ctt.Ctt_id))
                                        {
                                            Cal_id = lstCalculo[0].Cal_id;
                                        }


                                    }
                                    int fil2 = (int)lstParExcelColumna[i].Pec_fila - 2;
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    for (int a = q; a < lstParExcelColumna.Count; a++)
                                    {
                                        lstCalculoVariable = new List<Calculo_Variable>();
                                        AddCalculo_Variable.Cav_id = 0;
                                        AddCalculo_Variable.Cal_id = Cal_id;
                                        AddCalculo_Variable.Cam_id = 0;
                                        AddCalculo_Variable.Pro_id = lstParExcel[tipoHoja].Pro_id;
                                        AddCalculo_Variable.Mer_id = lstParExcelColumna[a].Mer_id;
                                        AddCalculo_Variable.Var_id = lstParExcelColumna[a].Var_id;
                                        AddCalculo_Variable.Umd_id = lstParExcelColumna[a].Umd_id;
                                        if (lstParExcelColumna[a].Tco_nombre.Trim().ToLower() == "TOTAL MES".ToLower().Trim())
                                        {
                                            AddCalculo_Variable.Mon_id = 2;
                                        }
                                        else
                                        {
                                            AddCalculo_Variable.Mon_id = 0;
                                        }
                                        if (dataSetExcel.Tables[0].Rows[fil2][i].ToString() != "")
                                        {
                                            if (dataSetExcel.Tables[0].Rows[fil2][i].ToString() != "-")
                                                if (lstParExcelColumna[a].Pec_iva == false)
                                                {
                                                    decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fil2][i].ToString());
                                                    AddCalculo_Variable.Cav_valor = valorsinIva * Convert.ToDecimal(0.87);
                                                }
                                                else
                                                {
                                                    if (dataSetExcel.Tables[0].Rows[fil2][i].ToString().EndsWith("%"))
                                                    {
                                                        string porcentaje = dataSetExcel.Tables[0].Rows[fil2][i].ToString().Replace("%", "");
                                                        decimal porciento = Convert.ToDecimal(porcentaje) / 100;
                                                        AddCalculo_Variable.Cav_valor = porciento;
                                                    }
                                                    else
                                                    {
                                                        AddCalculo_Variable.Cav_valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fil2][i].ToString());
                                                    }
                                                }
                                            else
                                                AddCalculo_Variable.Cav_valor = 0;
                                        }
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                        AddCalculo_Variable.Cav_estado = 1;
                                        AddCalculo_Variable.Cav_tipo = "T";
                                        AddCalculo_Variable.Pex_id = lstParExcel[tipoHoja].Pex_id;
                                        lstCalculoVariable.Add(AddCalculo_Variable);
                                        objCalculoVariableController.save(lstCalculoVariable);
                                        if (lstParExcelColumna.Count != (a + 1))
                                        {
                                            fil2 = (int)lstParExcelColumna[a + 1].Pec_fila - 2;
                                            q++;
                                            i = recuperarValorColumna(lstParExcelColumna, q);
                                        }

                                    }
                                    f = dataSetExcel.Tables[0].Rows.Count;
                                }
                            }
                        }
                        q = 0;
                        i = recuperarValorColumna(lstParExcelColumna, q);
                        parexcel1 = 0;
                    }
                //}
                //else if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "INVERSION Y COSTO")
                //{
                    if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "contrato".Trim().ToLower())
                    {
                        if (f >= 0)
                        {
                            i = 1;
                            string nombreContrato = dataSetExcel.Tables[0].Columns[i].ColumnName;
                            lstTitutla = TitularContratoController.listaTitularesPorNombreContrato(nombreContrato);
                            if (lstTitutla.Count < 0)
                            {
                                throw new Exception("Error porfavor verifique el nombre del contrato");
                            }
                            else
                            {
                                //lstCalculo = objCalculoController.findByCtt_Id(lstTitutla[0].Ctt.Ctt_id);
                                lstCalculo = objCalculoController.Validar(lstTitutla[0].Ctt.Ctt_id, cbxMes.SelectedIndex + 1, Convert.ToInt64(cbxAnio.Text),0);
                                if (lstCalculo.Count == 0)
                                {
                                    ///empiezo el carago de los datos
                                    lstAddCalculo = new List<Calculo>();
                                    AddCaldulo = new Calculo();
                                    AddCaldulo.Cal_id = 0;
                                    AddCaldulo.Ctt_id = lstTitutla[0].Ctt.Ctt_id;
                                    AddCaldulo.Cal_fecha = DateTime.Now;
                                    AddCaldulo.Ani_id = Convert.ToInt64(cbxAnio.Text);
                                    AddCaldulo.Mes_id = cbxMes.SelectedIndex + 1;
                                    AddCaldulo.Mon_id = 2;
                                    AddCaldulo.Cal_valor = 0;
                                    AddCaldulo.Cal_valorajustado = 0;
                                    AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                    AddCaldulo.Cal_estado = 1;
                                    lstAddCalculo.Add(AddCaldulo);
                                    Cal_id = objCalculoController.save(lstAddCalculo);
                                }
                                else
                                {
                                    if ((lstCalculo[0].Ani_id == Convert.ToInt64(cbxAnio.Text) && lstCalculo[0].Mes_id == cbxMes.SelectedIndex + 1) && (lstCalculo[0].Ctt_id == lstTitutla[0].Ctt.Ctt_id))
                                    {
                                        Cal_id = lstCalculo[0].Cal_id;
                                    }
                                }

                                //Empiezo con el caragado de los datos para 
                                q = 1;
                                i = recuperarValorColumna(lstParExcelColumna, q);

                                //q++;

                                for (int a = q; a < lstParExcelColumna.Count; a++)
                                {
                                    int fil2 = (int)lstParExcelColumna[a].Pec_fila - 3;
                                    lstCalculoVariable = new List<Calculo_Variable>();
                                    AddCalculo_Variable.Cav_id = 0;
                                    AddCalculo_Variable.Cal_id = Cal_id;
                                    AddCalculo_Variable.Cam_id = 0;
                                    AddCalculo_Variable.Pro_id = lstParExcel[tipoHoja].Pro_id;
                                    AddCalculo_Variable.Mer_id = lstParExcelColumna[a].Mer_id;
                                    AddCalculo_Variable.Var_id = lstParExcelColumna[a].Var_id;
                                    AddCalculo_Variable.Umd_id = lstParExcelColumna[a].Umd_id;
                                    if (lstParExcelColumna[a].Tco_nombre.Trim().ToLower() == "MONTO".ToLower().Trim())
                                    {
                                        AddCalculo_Variable.Mon_id = 2;
                                    }
                                    else
                                    {
                                        AddCalculo_Variable.Mon_id = 0;
                                    }
                                    if (dataSetExcel.Tables[0].Rows[fil2][i].ToString() != "")
                                    {
                                        if (dataSetExcel.Tables[0].Rows[fil2][i].ToString() != "-")
                                            if (lstParExcelColumna[a].Pec_iva == false)
                                            {
                                                decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fil2][i].ToString());
                                                AddCalculo_Variable.Cav_valor = valorsinIva * Convert.ToDecimal(0.87);
                                            }
                                            else
                                            {
                                                AddCalculo_Variable.Cav_valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[fil2][i].ToString());
                                            }
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                    }
                                    else
                                        AddCalculo_Variable.Cav_valor = 0;
                                    AddCalculo_Variable.Cav_estado = 1;
                                    AddCalculo_Variable.Cav_tipo = "Y";
                                    AddCalculo_Variable.Pex_id = lstParExcel[tipoHoja].Pex_id;
                                    lstCalculoVariable.Add(AddCalculo_Variable);
                                    objCalculoVariableController.save(lstCalculoVariable);
                                    if (lstParExcelColumna.Count != (a + 1))
                                    {
                                        q++;
                                        i = recuperarValorColumna(lstParExcelColumna, q);
                                        fil2 = (int)lstParExcelColumna[i].Pec_fila - 3;
                                    }

                                }
                                f = dataSetExcel.Tables[0].Rows.Count;
                            }
                        }
                        q = 0;
                        i = recuperarValorColumna(lstParExcelColumna, q);
                        parexcel1 = 0;
                    }
                //}
                //else if (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "CERTIFICACIONES PRODUCCIÓN")
                //{
                    if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "año")
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                        {
                            anio = int.Parse(dataSetExcel.Tables[0].Rows[f][i].ToString());
                            parexcel1++;
                            q++;
                            i = recuperarValorColumna(lstParExcelColumna, q);
                            f--;
                        }
                    }
                    else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "mes")
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                        {
                            mes = dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper();
                            parexcel1++;

                            switch (mes)
                            {
                                case "ENERO":
                                    mesInt = 1;
                                    break;
                                case "FEBRERO":
                                    mesInt = 2;
                                    break;
                                case "MARZO":
                                    mesInt = 3;
                                    break;
                                case "ABRIL":
                                    mesInt = 4;
                                    break;
                                case "MAYO":
                                    mesInt = 5;
                                    break;
                                case "JUNIO":
                                    mesInt = 6;
                                    break;
                                case "JULIO":
                                    mesInt = 7;
                                    break;
                                case "AGOSTO":
                                    mesInt = 8;
                                    break;
                                case "SEPTIEMBRE":
                                    mesInt = 9;
                                    break;
                                case "OCTUBRE":
                                    mesInt = 10;
                                    break;
                                case "NOVIEMBRE":
                                    mesInt = 11;
                                    break;
                                case "DICIEMBRE":
                                    mesInt = 12;
                                    break;
                            }
                            q++;
                            i = recuperarValorColumna(lstParExcelColumna, q);
                            f--;
                        }
                    }
                    else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "operador")
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                        {
                            titular = dataSetExcel.Tables[0].Rows[f][i].ToString();
                            parexcel1++;
                            lstTitutla = TitularContratoController.listaTitularesPorNombreTitular(titular.Trim().ToUpper());
                            q++;
                            i = recuperarValorColumna(lstParExcelColumna, q);
                            f--;
                        }
                        else
                        {

                            if (cont1 != 10)
                            {
                                cont1++;
                            }
                            else
                            {
                                f = dataSetExcel.Tables[0].Rows.Count;
                            }
                        }
                    }

                    else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "campo")
                    {
                        if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                        {
                            campoString = dataSetExcel.Tables[0].Rows[f][i].ToString();
                            campo = CampoController.SerchCampoByName(campoString.Trim().ToUpper());
                            contratoCampoValidador = new Contrato_Campo[1];
                            for (int l = 0; l < lstTitutla.Count; l++)
                            {
                                lstContratoCampo = ContratoCampoController.GetListContratoCamposPorContrato(lstTitutla[l].Ctt.Ctt_id);
                                if (lstContratoCampo.Count > 0)
                                {
                                    for (int cont = 0; cont < lstContratoCampo.Count; cont++)
                                    {
                                        if (campo.Cam_nombre == lstContratoCampo[cont].Cam_nombre)
                                        {
                                            contratoCampoValidador[0] = lstContratoCampo[cont];
                                            cont = lstContratoCampo.Count;
                                            l = lstTitutla.Count;
                                            break;
                                        }
                                    }
                                }
                            }
                            parexcel1++;
                            q++;
                            i = recuperarValorColumna(lstParExcelColumna, q);
                            f--;
                        }
                    }
                    else
                    {
                        if (contratoCampoValidador != null)
                        {
                            bool flag = objCalculoVariableController.ValidaCalculo(anio, mesInt, 0, contratoCampoValidador[0].Ctt_id,0);
                            //lstCalculo = objCalculoController.findByCtt_Id(contratoCampoValidador[0].Ctt_id);
                            if (lstCalculoVariable.Count == 0)
                            {
                                lstAddCalculo = new List<Calculo>();
                                AddCaldulo = new Calculo();
                                AddCaldulo.Cal_id = 0;
                                AddCaldulo.Ctt_id = contratoCampoValidador[0].Ctt_id;
                                AddCaldulo.Cal_fecha = DateTime.Now;
                                AddCaldulo.Ani_id = anio;
                                AddCaldulo.Mes_id = mesInt;
                                AddCaldulo.Mon_id = 2;
                                AddCaldulo.Cal_valor = 0;
                                AddCaldulo.Cal_valorajustado = 0;
                                AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                AddCaldulo.Cal_estado = 1;
                                lstAddCalculo.Add(AddCaldulo);
                                Cal_id = objCalculoController.save(lstAddCalculo);
                            }
                            else
                            {
                                foreach (Calculo_Variable cal in lstCalculoVariable)
                                {
                                    if ((cal.Ani_id == anio && cal.Mes_id == mesInt) && (cal.Ctt_id == contratoCampoValidador[0].Ctt_id))
                                    {
                                        Cal_id = cal.Cal_id;
                                    }
                                    else
                                    {
                                        lstAddCalculo = new List<Calculo>();
                                        AddCaldulo = new Calculo();
                                        AddCaldulo.Cal_id = 0;
                                        AddCaldulo.Ctt_id = contratoCampoValidador[0].Ctt_id;
                                        AddCaldulo.Cal_fecha = DateTime.Now;
                                        AddCaldulo.Ani_id = anio;
                                        AddCaldulo.Mes_id = mesInt;
                                        AddCaldulo.Mon_id = 2;
                                        AddCaldulo.Cal_valor = 0;
                                        AddCaldulo.Cal_valorajustado = 0;
                                        AddCaldulo.Tcl_id = lstParExcel[tipoHoja].Tcl_id;
                                        AddCaldulo.Cal_estado = 1;
                                        lstAddCalculo.Add(AddCaldulo);
                                        Cal_id = objCalculoController.save(lstAddCalculo);
                                    }
                                }
                            }
                            for (int c = q; c < lstParExcelColumna.Count; c++)
                            {
                                if ((contratoCampoValidador[0].Ctt_id > 0) || (Cal_id > 0))
                                {
                                    if (!dataSetExcel.Tables[0].Rows[f][i].ToString().Trim().ToLower().StartsWith("total"))
                                    {
                                        lstCalculoVariable = new List<Calculo_Variable>();
                                        AddCalculo_Variable.Cav_id = 0;
                                        AddCalculo_Variable.Cal_id = Cal_id;
                                        AddCalculo_Variable.Cam_id = contratoCampoValidador[0].Cam_id;
                                        AddCalculo_Variable.Pro_id = lstParExcel[tipoHoja].Pro_id;
                                        AddCalculo_Variable.Mer_id = lstParExcelColumna[c].Mer_id;
                                        AddCalculo_Variable.Var_id = lstParExcelColumna[c].Var_id;
                                        AddCalculo_Variable.Umd_id = lstParExcelColumna[c].Umd_id;
                                        if (lstParExcelColumna[c].Tco_nombre.Trim().ToLower() == "MONTO".ToLower().Trim())
                                        {
                                            AddCalculo_Variable.Mon_id = 2;
                                        }
                                        else
                                        {
                                            AddCalculo_Variable.Mon_id = 0;
                                        }
                                        if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "")
                                            if (dataSetExcel.Tables[0].Rows[f][i].ToString().Trim() != "-")
                                                if (lstParExcelColumna[c].Pec_iva == false)
                                                {
                                                    decimal valorsinIva = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                                    AddCalculo_Variable.Cav_valor = valorsinIva * Convert.ToDecimal(0.87);
                                                }
                                                else
                                                {
                                                    AddCalculo_Variable.Cav_valor = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                                }
                                            else
                                                AddCalculo_Variable.Cav_valor = 0;
                                        else
                                            AddCalculo_Variable.Cav_valor = 0;
                                        AddCalculo_Variable.Cav_estado = 1;
                                        AddCalculo_Variable.Cav_tipo = "Y";
                                        AddCalculo_Variable.Pex_id = lstParExcel[tipoHoja].Pex_id;
                                        lstCalculoVariable.Add(AddCalculo_Variable);
                                        objCalculoVariableController.save(lstCalculoVariable);
                                    }
                                }
                                else
                                {
                                    if (objCalculo.Cal_id != 0)
                                        throw new Exception("Error en el id del calculo. " + objCalculo.Cal_id);
                                    if (contratoCampoValidador[0].Cam_id != 0)
                                        throw new Exception("Error en el id del campo. " + contratoCampoValidador[0].Cam_id + " " + contratoCampoValidador[0].Cam_nombre);
                                    if (titularContrato.Ctt.Ctt_id != 0)
                                        throw new Exception("Error en el id del titular. " + titularContrato.Ctt.Ctt_id + " " + titularContrato.Ctt.Ctt_nombre);
                                    if (contratoCampoValidador[0].Ctt_id != 0)
                                        throw new Exception("Error en el id del contrato. " + contratoCampoValidador[0].Ctt_id);
                                }
                                if (q < lstParExcelColumna.Count - 1)
                                {
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                }
                            }
                        }
                        i = 1;
                        q = 0;
                        parexcel1 = 0;
                    }
                //}
                //else if ((lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "REGALIAS") || (lstParExcel[tipoHoja].Pex_tipo.ToUpper().Trim() == "IDH"))
                //{
                    if (f > 0)
                    {
                        if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "año")
                        {
                            if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                            {
                                anio = int.Parse(dataSetExcel.Tables[0].Rows[f][i].ToString());
                                parexcel1++;
                                q++;
                                i = recuperarValorColumna(lstParExcelColumna, q);
                                f--;
                            }
                        }
                        else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "mes")
                        {
                            if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                            {
                                mes = dataSetExcel.Tables[0].Rows[f][i].ToString().ToUpper();
                                parexcel1++;

                                switch (mes)
                                {
                                    case "ENERO":
                                        mesInt = 1;
                                        break;
                                    case "FEBRERO":
                                        mesInt = 2;
                                        break;
                                    case "MARZO":
                                        mesInt = 3;
                                        break;
                                    case "ABRIL":
                                        mesInt = 4;
                                        break;
                                    case "MAYO":
                                        mesInt = 5;
                                        break;
                                    case "JUNIO":
                                        mesInt = 6;
                                        break;
                                    case "JULIO":
                                        mesInt = 7;
                                        break;
                                    case "AGOSTO":
                                        mesInt = 8;
                                        break;
                                    case "SEPTIEMBRE":
                                        mesInt = 9;
                                        break;
                                    case "OCTUBRE":
                                        mesInt = 10;
                                        break;
                                    case "NOVIEMBRE":
                                        mesInt = 11;
                                        break;
                                    case "DICIEMBRE":
                                        mesInt = 12;
                                        break;
                                }
                                q++;
                                i = recuperarValorColumna(lstParExcelColumna, q);
                                f--;
                            }
                        }
                        else if (lstParExcelColumna[parexcel1].Tco_nombre.ToLower().Trim() == "contrato")
                        {
                            if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                            {

                                lstContrato = ContratoController.FindContratoByCtt_Name(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                parexcel1++;
                                if (lstContrato.Count > 0)
                                {
                                    Regalia regaliaAdd = new Regalia();
                                    regaliaAdd.Reg_id = 0;
                                    regaliaAdd.Ctt_id = lstContrato[0].Ctt_id;
                                    //q++;
                                    //i = recuperarValorColumna(lstParExcelColumna, q);
                                    regaliaAdd.Ani_id = anio;
                                    //q++;
                                    //i = recuperarValorColumna(lstParExcelColumna, q);
                                    regaliaAdd.Mes_id = mesInt;
                                    regaliaAdd.Mon_id = 2;
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f ][i].ToString().StartsWith("REGALIA"))
                                        regaliaAdd.Reg_tipo = "R";
                                    else if (dataSetExcel.Tables[0].Rows[f ][i].ToString().StartsWith("PARTICIPACION"))
                                        regaliaAdd.Reg_tipo = "P";
                                    else
                                        regaliaAdd.Reg_tipo = "I";
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f][i].ToString() != "")
                                    {
                                        regaliaAdd.Reg_gasmi = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    }
                                    else
                                        regaliaAdd.Reg_gasmi = 0;

                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                                    {
                                        regaliaAdd.Reg_gasme = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    }
                                    else
                                        regaliaAdd.Reg_gasmi = 0;
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                                    {
                                        regaliaAdd.Reg_crudomi = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    }
                                    else
                                        regaliaAdd.Reg_gasmi = 0;
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                                    {
                                        regaliaAdd.Reg_crudome = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    }
                                    else
                                        regaliaAdd.Reg_gasmi = 0;
                                    q++;
                                    i = recuperarValorColumna(lstParExcelColumna, q);
                                    if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                                    {
                                        regaliaAdd.Reg_glp = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    }
                                    else
                                        regaliaAdd.Reg_gasmi = 0;
                                    //q++;
                                    //i = recuperarValorColumna(lstParExcelColumna, q);
                                    //if (dataSetExcel.Tables[0].Rows[f ][i].ToString() != "")
                                    //{
                                    //    regaliaAdd.Reg_total = Convert.ToDecimal(dataSetExcel.Tables[0].Rows[f ][i].ToString());
                                    //}
                                    //else
                                    regaliaAdd.Reg_gasmi = 0;
                                    regaliaAdd.Reg_estado = 1;
                                    List<Regalia> lstRegalia = new List<Regalia>();
                                    lstRegalia.Add(regaliaAdd);
                                    RegaliaController.save(lstRegalia);
                                }
                                q = 0;
                                i = recuperarValorColumna(lstParExcelColumna, q);
                                parexcel1 = 0;
                            }
                        }
                    }
                }
            //}
        }

        /// <summary>
        /// recupero el valor de i para la busqueda por las filas.
        /// </summary>
        /// <param name="lstparExcelColumna">Lista de ExcelColumna</param>
        /// <returns>la collumna del excel</returns>
        private int recuperarValorColumna(List<ParExcel_Columna> lstparExcelColumna, int z)
        {
            string column = "";
            int i = 0;
            if (lstparExcelColumna.Count != 0)
            {
                column = lstparExcelColumna[z].Pec_Columna;
                string[] cadena = {"A","B","C","D","E","F","G","H","I","J",
                                   "K","L","M","N","O","P","Q","R","S","T",
                                   "U","V","W","X","Y","Z","AA","AB","AC","AD",
                                   "AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN",
                                   "AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX",
                                   "AY","AZ"};
                foreach (string item in cadena)
                {
                    if (column.ToUpper() != item.ToString())
                    {
                        i++;
                    }
                    else
                        break;
                }
            }
            return i;
        }








        private List<Titular_Contrato> GetOperadorCampo(DataSet dataSetExcel, int fila, int i)
        {
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();


            for (int j = (int)fila; j < dataSetExcel.Tables[0].Rows.Count - 1; j++)
            {
                if (dataSetExcel.Tables[0].Rows[j][i].ToString() != "")
                {
                    string titular = dataSetExcel.Tables[0].Rows[j][i].ToString().Trim();
                    if (titular.Trim().ToUpper().StartsWith("TOTAL"))
                    {
                        titular = titular.Replace("TOTAL", "");
                        //titular = titular + " SA";
                        lstTitularContrato = TitularContratoController.SerchByName(titular.Trim());
                        if (lstTitularContrato.Count == 0)
                            throw new Exception("Error, porfavor verifique el operador: " + titular.ToUpper());
                        else
                            return lstTitularContrato;
                    }
                }
            }
            return lstTitularContrato;
        }




        /// <summary>
        /// realizo la coneccion y envio la consulta
        /// </summary>
        /// <param name="QueryString">Consulta a ser prosedada</param>
        /// <returns>DataSet cargado.</returns>
        public DataSet CargarDataSet(string QueryString)
        {
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=\'Excel 12.0;HDR=YES\'";
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


        private void eliminarCalculo_variable(List<Calculo_Variable> lstCalculoVariable)
        {
            Calculo_VariableController objCalculoVariableController = new Calculo_VariableController();
            foreach (Calculo_Variable item in lstCalculoVariable)
            {
                //objCalculoVariableController.Eliminar(item.Cav_id);
            }
        }


        //private void ActualizarRegalias()
        //{
        //    RegaliaController.EliminarRegaliaz();
        //}


        //private void ActualizarIDH()
        //{
        //    RegaliaController.ActualizarIDH();
        //}

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdRefresh":
                    Cargar();
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Step = 1;
            progressBar1.PerformStep();

        }
    }
}
