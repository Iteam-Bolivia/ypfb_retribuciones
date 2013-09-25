using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Model;
using ypfbApplication.Model;
using ypfbApplication.Controller;

namespace ypfbApplication.ReportForms
{
    public partial class RepDistribPart : Form
    {
        public RepDistribPart()
        {
            InitializeComponent();
        }

        private void RepDistribRet_Load(object sender, EventArgs e)
        {

            try
            {
                // Tipo de Cálculo
                List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
                Tipo_CalculoController objTipoCalculoController = new Tipo_CalculoController();
                lstTipoCalculo = Tipo_CalculoController.GetListTipoCalculo(0);
                if (lstTipoCalculo.Count == 0)
                {
                    cbxTipoCalculo.Items.Clear();
                }
                else
                {
                    cbxTipoCalculo.Items.Clear();
                    cbxTipoCalculo.DataSource = lstTipoCalculo;
                    cbxTipoCalculo.DisplayMember = "tcl_codigo";
                    cbxTipoCalculo.ValueMember = "tcl_id";
                }

                DataTable dt = CargaMeses();
                CargaAnio();

                this.MesIniCbo.DataSource = dt;
                this.MesIniCbo.ValueMember = "Valor";
                this.MesIniCbo.DisplayMember = "Nombre";
                MesIniCbo.SelectedItem = null;


                List<Variable> lstVariable = new List<Variable>();
                VariableObject objVariable = new VariableObject();

                lstVariable = objVariable.listVariableByTcl(Convert.ToInt64(cbxTipoCalculo.SelectedValue));

                //VarCbo.DataSource = lstVariable;
                //VarCbo.DisplayMember = "var_codigo";
                //VarCbo.ValueMember = "var_id";
                //VarCbo.SelectedItem = null;
                
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
                AnioIniCbo.Items.Add(y);
            AnioIniCbo.SelectedItem = null;
        }

        private void GeneraBtn_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                if (AnioIniCbo.SelectedIndex == -1)
                {
                    res = false;
                    MessageBox.Show("Debe seleccionar un Año", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AnioIniCbo.Focus();
                }
                else if (MesIniCbo.SelectedIndex == -1)
                {
                    res = false;
                    MessageBox.Show("Debe seleccionar un Mes", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MesIniCbo.Focus();
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
                string mes = MesIniCbo.Text;
                string anio = AnioIniCbo.Text;
                //int var_id = 0;
                int mes_ini = Convert.ToInt32(MesIniCbo.SelectedValue);
                int anio_ini = Convert.ToInt32(AnioIniCbo.SelectedItem);
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

                long tcl_id = Convert.ToInt64(cbxTipoCalculo.SelectedValue);

                ds = rptRedis.fillDataSetRepParticipacion("fnc_participacion_titular_campos", "DistribDataTable", mes_ini, anio_ini, tcl_id);

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

        //private void cbxTipoCalculo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<Variable> lstVariable = new List<Variable>();
        //    VariableObject objVariable = new VariableObject();
        //    long tclIndex = Convert.ToInt64(cbxTipoCalculo.SelectedIndex);


        //    lstVariable = objVariable.listVariableByTcl(tclIndex+1);

        //    VarCbo.DataSource = lstVariable;
        //    VarCbo.DisplayMember = "var_codigo";
        //    VarCbo.ValueMember = "var_id";
        //    VarCbo.SelectedItem = null;
        //}

        
    }
}
