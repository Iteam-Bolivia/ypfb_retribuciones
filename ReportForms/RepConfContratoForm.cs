using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
//using Controller;
using Microsoft.Reporting.WinForms;
using ypfbApplication.Model;

namespace ypfbApplication.ReportForms
{
    public partial class RepConfContratoForm : Form
    {
        public RepConfContratoForm()
        {
            InitializeComponent();
        }

        private void RepConfContratoForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Contrato> lstContrato = new List<Contrato>();
                ContratoObject objContrato = new ContratoObject();
                lstContrato = objContrato.listContratoCbo(0);

                ContratoCbo.DataSource = lstContrato;
                ContratoCbo.DisplayMember = "ctt_nombre";
                ContratoCbo.ValueMember = "ctt_id";
                ContratoCbo.SelectedItem = null;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void GeneraBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CargarContratos();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// alimenta el datasoure con un datatable para generar el reporte
        /// </summary>
        private void CargarContratos()
        {
            try
            {

                //obtenemos las variables de operador y contrato

                string contrato = ContratoCbo.Text;
                int ctt_id = Convert.ToInt32(ContratoCbo.SelectedValue);

                this.Cursor = Cursors.WaitCursor;
                //Declara el objeto para recuperar el dataset que alimentara el reporte
                ReportsObject rptRedis = new ReportsObject();
                //busca la ruta pero saca con /bin/debug por hacer correr probar en produccion
                //String ruta = Directory.GetCurrentDirectory() + "\\Reports\\ReportDistrib.rdlc";
                
                //setea la ruta del reporte a mostrar
                //reportViewer1.LocalReport.ReportPath = "D:/ypfb_retribuciones_snv/Reports/ReportDistrib.rdlc";
                //reportViewer1.LocalReport.ReportPath = ruta;
                
                //Array que contendrá los parámetros
                ReportParameter[] parameters = new ReportParameter[1];
                //Establecemos el valor de los parámetros
                parameters[0] = new ReportParameter("Param1", contrato);

                //Pasamos el array de los parámetros al ReportViewer
                reportViewer1.LocalReport.SetParameters(parameters);

                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                ds = rptRedis.fillDataSet("fnc_getTitulares", "TitularesDataTable", ctt_id);
                ds2 = rptRedis.fillDataSet("fnc_distribmes", "DistribDataTable", ctt_id);

                //Alimenta el datasource del reporte
                //ReportDataSource datasourceCon = new ReportDataSource("DataSet1", dsContratos.Tables[1]);
                ReportDataSource datasourceCon = new ReportDataSource("DataSet1", ds.Tables["TitularesDataTable"]);
                ReportDataSource datasourceCon2 = new ReportDataSource("DataSet2", ds2.Tables["DistribDataTable"]);
                
                //limpiar data source anteriores
                reportViewer1.LocalReport.DataSources.Clear();

                //adiciona el datasourcereport al reportviewer
                reportViewer1.LocalReport.DataSources.Add(datasourceCon);
                reportViewer1.LocalReport.DataSources.Add(datasourceCon2);

                //refresca el reporte
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
    }
}
