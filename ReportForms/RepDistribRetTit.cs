using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Model;
using ypfbApplication.Model;
using ypfbApplication.Controller;

namespace ypfbApplication.ReportForms
{
    public partial class RepDistribRetTit : Form
    {
        public RepDistribRetTit()
        {
            InitializeComponent();
        }

        private void RepDistribRetTit_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = CargaMeses();
                CargaAnio();

                this.MesCbo.DataSource = dt;
                this.MesCbo.ValueMember = "Valor";
                this.MesCbo.DisplayMember = "Nombre";
                MesCbo.SelectedItem = null;

                reportViewer1.Width = Screen.PrimaryScreen.WorkingArea.Width - 45;
                reportViewer1.Height = Screen.PrimaryScreen.WorkingArea.Height - 250;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private DataTable CargaMeses()
        {
            DataTable dt;
            dt = new DataTable("Meses");

            dt.Columns.Add("Valor");
            dt.Columns.Add("Nombre");

            DataRow dr;

            string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
            int cont = 1;

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
        private void CargaAnio()
        {
            for (int y = 2000; y <= 2025; y++)
                AnioCbo.Items.Add(y);
            AnioCbo.SelectedItem = null;
        }

        private void GeneraBtn_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                if (AnioCbo.SelectedIndex == -1)
                {
                    res = false;
                    MessageBox.Show("Debe seleccionar un Año", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AnioCbo.Focus();
                }
                else if (MesCbo.SelectedIndex == -1)
                {
                    res = false;
                    MessageBox.Show("Debe seleccionar un Mes", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MesCbo.Focus();
                }
                else
                {
                    res = true;
                }
                if (res == false)
                    return;
                CargarContratos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarContratos()
        {
            try
            {

                //obtenemos las variables de operador y contrato
                string mes = MesCbo.Text;
                string anio = " de " + AnioCbo.Text;

                int mes_ini = Convert.ToInt32(MesCbo.SelectedValue);
                int anio_ini = Convert.ToInt32(AnioCbo.SelectedItem);
               
                //int tipo = Convert.ToInt32(TipoCombo.SelectedValue);


                this.Cursor = Cursors.WaitCursor;
                //Declara el objeto para recuperar el dataset que alimentara el reporte
                ReportsObject rptRedis = new ReportsObject();

                #region Modificado
                //reportViewer1.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Reports\\RepReliquidacionTitular.rdlc";
                #endregion


                //reportViewer1.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Reports\\RepReliquidacionTitular.rdlc";
                ReportParameter[] parameters = new ReportParameter[2];
                //Establecemos el valor de los parámetros
                parameters[0] = new ReportParameter("Param1", mes);
                parameters[1] = new ReportParameter("Param2", anio);
                //parameters[3] = new ReportParameter("Parameter4", tipoS);
                //Pasamos el array de los parámetros al ReportViewer
                reportViewer1.LocalReport.SetParameters(parameters);

                DataSet ds = new DataSet();
                ds = rptRedis.fillDataSetResumenEjec("fnc_distribrettit", "DistribDataTable", mes_ini, anio_ini);

                ReportDataSource datasourceCon = null;

                if (ds.Tables["DistribDataTable"].Rows.Count > 0)
                {
                    datasourceCon = new ReportDataSource("DataSet1", ds.Tables["DistribDataTable"]);
                    reportViewer1.LocalReport.DataSources.Clear();

                    //adiciona el datasourcereport al reportviewer
                    reportViewer1.LocalReport.DataSources.Add(datasourceCon);
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    MessageBox.Show("No se encontraron resultados", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
