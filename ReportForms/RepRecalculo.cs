using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Model;
using ypfbApplication.Model;


namespace ypfbApplication.ReportForms
{
    public partial class RepRecalculo : Form
    {
        private bool isLoad = false;

        /// <summary>
        /// RepRecalculo
        /// </summary>        
        public RepRecalculo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// RepRecalculo_Load
        /// </summary>
        private void RepRecalculo_Load(object sender, EventArgs e)
        {
          try
          {
            //setea la variable de cargado de formulario en true 
            isLoad = true;

            List<Titular> lstTitular = new List<Titular>();
            TitularObject objTitularObject = new TitularObject();
            lstTitular = objTitularObject.listTitularCbo(0);
            OperadorCbo.DataSource = lstTitular;
            OperadorCbo.DisplayMember = "tit_nombre";
            OperadorCbo.ValueMember = "tit_id";
            OperadorCbo.SelectedItem = null;

            List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
            Tipo_CalculoObject objTipoCalculoObject = new Tipo_CalculoObject();
            lstTipoCalculo = objTipoCalculoObject.listTipoCalculo(0);
            if (lstTipoCalculo.Count == 0)
            {
              TipoCombo.Items.Clear();
            }
            else
            {
              TipoCombo.Items.Clear();
              TipoCombo.DataSource = lstTipoCalculo;
              TipoCombo.DisplayMember = "tcl_codigo";
              TipoCombo.ValueMember = "tcl_id";
              TipoCombo.SelectedIndex = 0;
            }

            DataTable dt = CargaMeses();
            this.MesIniCbo.DataSource = dt;
            this.MesIniCbo.ValueMember = "Valor";
            this.MesIniCbo.DisplayMember = "Nombre";
            MesIniCbo.SelectedItem = null;

            CargaAnio();

            reportViewer1.Width = Screen.PrimaryScreen.WorkingArea.Width - 45;
            reportViewer1.Height = Screen.PrimaryScreen.WorkingArea.Height - 250;
          }
          catch (Exception exc)
          {
            MessageBox.Show(exc.Message);
          }

        }

        /// <summary>
        /// RepRecalculo_Shown
        /// </summary>
        private void RepRecalculo_Shown(object sender, EventArgs e)
        {
          //setea la variable en false una vez cargado el formulario
          isLoad = false;
        }

        /// <summary>
        /// RepRecalculo_FormClosed
        /// </summary>
        private void RepRecalculo_FormClosed(object sender, FormClosedEventArgs e)
        {
          reportViewer1.LocalReport.Dispose();
        }

        /// <summary>
        /// OperadorCbo_SelectedIndexChanged
        /// </summary>
        private void OperadorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
          // pregunta si el formulario esta cargando 
          // para no lanzar el proceso de carga de el text box
          if (!isLoad)
          {
            long tit_id = Convert.ToInt64(OperadorCbo.SelectedValue);

            List<Contrato> lstContrato = new List<Contrato>();
            ContratoObject objContrato = new ContratoObject();
            lstContrato = objContrato.listContratoCbo(tit_id);

            ContratoCbo.DataSource = lstContrato;
            ContratoCbo.DisplayMember = "ctt_nombre";
            ContratoCbo.ValueMember = "ctt_id";
            ContratoCbo.SelectedItem = null;
          }
        }

        /// <summary>
        /// validarCampos
        /// </summary>
        private bool validarCampos()
        {
          bool flag = true;
          //flag = true;
          if (ContratoCbo.SelectedIndex == -1)
          {
            flag = false;
            MessageBox.Show("Debe seleccionar un Contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ContratoCbo.Focus();
          }
          else if (AnioIniCbo.SelectedIndex == -1)
          {
            flag = false;
            MessageBox.Show("Debe seleccionar un Año", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            AnioIniCbo.Focus();
          }
          else if (MesIniCbo.SelectedIndex == -1)
          {
            flag = false;
            MessageBox.Show("Debe seleccionar un Mes", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MesIniCbo.Focus();
          }
          return flag;
        }


        /// <summary>
        /// GeneraBtn_Click
        /// </summary>
        private void GeneraBtn_Click(object sender, EventArgs e)
        {            
            try
            {
              if (validarCampos())
              {
                // Iniciar proceso
                CargarContratos();
              }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// CargaTipo
        /// </summary>
        private DataTable CargaTipo()
        {
          DataTable dt;
          DataRow dr;
          dt = new DataTable("Tipo");
          dt.Columns.Add("Valor");
          dt.Columns.Add("Nombre");


          // Cambie por que eres un yogalla
          //string[] TIPO = new string[] { "RECÁLCULO", "A CUENTA", "TODOS", "PROYECCIONES" };
          //int cont = 1;

          //foreach (string mes in TIPO)
          //{
          //    //cbxMes.Items.Add(mes);
          //    dr = dt.NewRow();
          //    dr["Valor"] = cont;
          //    dr[1] = mes;
          //    dt.Rows.Add(dr);
          //    cont++;
          //}

          return dt;
        }

        /// <summary>
        /// CargaAnio
        /// </summary>
        private void CargaAnio()
        {
          for (int y = 2000; y <= 2025; y++)
            AnioIniCbo.Items.Add(y);
          AnioIniCbo.SelectedItem = null;
        }


        /// <summary>
        /// CargarContratos
        /// Alimenta el datasoure con un datatable para generar el reporte
        /// </summary>
        private void CargarContratos()
        {
            try
            {

                //obtenemos las variables de operador y contrato
                //int tipo = Convert.ToInt32(TipoCombo.SelectedValue);
                string operador = OperadorCbo.Text;
                string contrato = ContratoCbo.Text;
                string mes = MesIniCbo.Text;
                string anio = AnioIniCbo.Text;
                string tipoS = TipoCombo.Text;
                int ctt_id = Convert.ToInt32(ContratoCbo.SelectedValue);
                int mes_ini = Convert.ToInt32(MesIniCbo.SelectedValue);
                int anio_ini = Convert.ToInt32(AnioIniCbo.SelectedItem);                
                int tipo = Convert.ToInt32(TipoCombo.SelectedValue);  
              
                this.Cursor = Cursors.WaitCursor;
                //Declara el objeto para recuperar el dataset que alimentara el reporte
                ReportsObject objReportObject = new ReportsObject();

                #region Modificado
                //reportViewer1.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Reports\\RepReliquidacionTitular.rdlc";
                #endregion


                //reportViewer1.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Reports\\RepReliquidacionTitular.rdlc";
                ReportParameter[] parameters = new ReportParameter[4];
                //Establecemos el valor de los parámetros
                parameters[0] = new ReportParameter("Param1", operador);
                parameters[1] = new ReportParameter("Param2", contrato);
                parameters[2] = new ReportParameter("Param3", mes);
                parameters[3] = new ReportParameter("Param4", anio);
                //parameters[3] = new ReportParameter("Parameter4", tipoS);
                //Pasamos el array de los parámetros al ReportViewer
                reportViewer1.LocalReport.SetParameters(parameters);
                if (tipo == 1)
                {
                    DataSet ds = new DataSet();
                    DataSet ds2 = new DataSet();
                    DataSet ds3 = new DataSet();


                    ds = objReportObject.fillDataSetRepRecalculo("fnc_recalculo", "RecalculoDataTable", ctt_id, tipo, mes_ini, anio_ini);
                    ds2 = objReportObject.fillDataSetRepRecalculoTit("fnc_recalculoTit", "RecalculoDataTable", ctt_id, mes_ini, anio_ini);
                    ds3 = objReportObject.fillDataSetRepRecalculoTit("fnc_recalculoRti", "RecalculoDataTable", ctt_id, mes_ini, anio_ini);
                    
                    ReportDataSource datasourceCon = null;
                    ReportDataSource datasourceCon2 = null;
                    ReportDataSource datasourceCon3 = null;

                    if (ds.Tables["RecalculoDataTable"].Rows.Count > 0)
                    {
                        datasourceCon = new ReportDataSource("DataSet1", ds.Tables["RecalculoDataTable"]);
                        datasourceCon2 = new ReportDataSource("DataSet2", ds2.Tables["RecalculoDataTable"]);
                        datasourceCon3 = new ReportDataSource("DataSet3", ds3.Tables["RecalculoDataTable"]);
                        reportViewer1.LocalReport.DataSources.Clear();

                        //adiciona el datasourcereport al reportviewer
                        reportViewer1.LocalReport.DataSources.Add(datasourceCon);
                        reportViewer1.LocalReport.DataSources.Add(datasourceCon2);
                        reportViewer1.LocalReport.DataSources.Add(datasourceCon3);
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        MessageBox.Show("No se encontraron resultados", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = objReportObject.fillDataSetRepRecalculo("fnc_recalculo1", "RecalculoDataTable", ctt_id, tipo, mes_ini, anio_ini);
                    ReportDataSource datasourceCon = null;

                    if (ds.Tables["RecalculoDataTable"].Rows.Count > 0)
                    {
                        datasourceCon = new ReportDataSource("DataSet1", ds.Tables["RecalculoDataTable"]);
                        reportViewer1.LocalReport.DataSources.Clear();

                        //adiciona el datasourcereport al reportviewer
                        reportViewer1.LocalReport.DataSources.Add(datasourceCon);
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        MessageBox.Show("No se encontraron resultados", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }







        /// <summary>
        /// CargaMeses
        /// </summary>
        private DataTable CargaMeses()
        {
          string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
          int cont = 1;

          DataTable dt;
          DataRow dr;
          dt = new DataTable("Meses");
          dt.Columns.Add("Valor");
          dt.Columns.Add("Nombre");
          foreach (string mes in MESES)
          {
            //cbxMes.Items.Add(mes);
            dr = dt.NewRow();
            dr["Valor"] = cont;
            dr[1] = mes;
            dt.Rows.Add(dr);
            cont++;
          }
          return dt;
        }



    }
}