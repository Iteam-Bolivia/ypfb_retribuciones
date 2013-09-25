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
using System.Windows.Forms.DataVisualization.Charting;


namespace ypfbApplication.ReportForms
{
    public partial class RepTorta : Form
    {

        List<Contrato> lstContrato = new List<Contrato>();
        List<Variable> lstVariable = new List<Variable>();

        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };


        public RepTorta()
        {
            InitializeComponent();
        }

        private void RepPastel_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.cbxGrafico, "Escoger el contrato");
            toolTip1.SetToolTip(this.cbxAnio, "Escoger el año");
            toolTip1.SetToolTip(this.cbxMes, "Escoger el mes");

            // Meses
            foreach (string mes in MESES)
            {
                cbxMes.Items.Add(mes);
            }

            foreach (int anio in ANIOS)
            {
                cbxAnio.Items.Add(anio);
            }

            foreach (string mes in MESES)
            {
                cbxMesFin.Items.Add(mes);
            }

            foreach (int anio in ANIOS)
            {
                cbxAnioFin.Items.Add(anio);
            }

            //// Load
            //lstContrato = ContratoController.GetListContrato(0);
            //cbxContrato.DataSource = lstContrato;
            //cbxContrato.DisplayMember = "Ctt_nombre";
            //cbxContrato.ValueMember = "Ctt_id";
            //cbxContrato.SelectedIndex = 0;
            //cbxContrato.Refresh();

            VariableObject objVariable = new VariableObject();
            lstVariable = objVariable.listVariableTotales(0);

            cbxVariable.DataSource = lstVariable;
            cbxVariable.DisplayMember = "var_descripcion";
            cbxVariable.ValueMember = "var_id";
            cbxVariable.SelectedIndex = 0;
            cbxGrafico.Refresh();

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
                cbxTipoCalculo.SelectedIndex = 0;
                cbxGrafico.Refresh();
            }

            cbxTituloReporte.Items.Add("Composición de la Retribución del Titular a Cuenta Ajustado por Contrato de Operación.");
            cbxTituloReporte.Items.Add("Composición de la Participación YPFB a Cuenta Ajustada por Contrato de Operación.");
            
            cbxGrafico.Items.Add("Area");
            cbxGrafico.Items.Add("Barras");
            cbxGrafico.Items.Add("Burbujas");
            cbxGrafico.Items.Add("Vela japonesa");
            cbxGrafico.Items.Add("Columnas");
            cbxGrafico.Items.Add("Anillos");
            cbxGrafico.Items.Add("Barras de error");
            cbxGrafico.Items.Add("Fast line");
            cbxGrafico.Items.Add("Fast point");
            cbxGrafico.Items.Add("Embudo");
            cbxGrafico.Items.Add("Kagi");
            cbxGrafico.Items.Add("Lineas");
            cbxGrafico.Items.Add("Circular");
            cbxGrafico.Items.Add("Puntos");
            cbxGrafico.Items.Add("Puntos y figura");
            cbxGrafico.Items.Add("Piramidal");
            cbxGrafico.Items.Add("Intervalos");
            cbxGrafico.Items.Add("Intervalo de barras");
            cbxGrafico.Items.Add("Intervalo de columnas");
            cbxGrafico.Items.Add("Renko");
            cbxGrafico.Items.Add("Spline");
            cbxGrafico.Items.Add("Arce de spline");
            cbxGrafico.Items.Add("Arces apilados");
            cbxGrafico.Items.Add("Arces 100% apilados");
            cbxGrafico.Items.Add("Barras apiladas");
            cbxGrafico.Items.Add("Barras 100% apiladas");
            cbxGrafico.Items.Add("Columnas apiladas");
            cbxGrafico.Items.Add("Columnas 100% apiladas");
            cbxGrafico.Items.Add("Step Line");
            //cbxGrafico.Items.Add("Barras");
            //cbxGrafico.Items.Add("Barras");
            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_VariableController objCalculoController = new Calculo_VariableController();

            lstCalculoVariable = objCalculoController.listCalculoVariableTotales(
                Convert.ToInt64(cbxAnioFin.SelectedItem),
                Convert.ToInt64(cbxTipoCalculo.SelectedValue),
                Convert.ToInt64(cbxAnio.SelectedItem),
                Convert.ToInt64(cbxMes.SelectedIndex + 1),
                Convert.ToInt64(cbxMesFin.SelectedIndex + 1), 
                Convert.ToInt64(cbxVariable.SelectedValue));
            chart1.Series["Series1"].Points.Clear();
            if (lstCalculoVariable.Count > 0)
            {
                chart1.Series[0].ChartType = SeriesChartType.Column;
                //chart1.Series[0]("Drawing Style") = "Cylinder";
                chart1.Series[0].Name = "Numeros Aleatorios";
                chart1.Series[0].Color = Color.RoyalBlue;
                foreach (Calculo_Variable item in lstCalculoVariable)
                {
                    chart1.Series[0].Points.Add(Convert.ToDouble(item.Cav_valor));
                    chart1.Series[0].Name = item.Cam_nombre;
                }

                chart1.Series[0].ChartType = SeriesChartType.Pie;
            }
            else
            {
                MessageBox.Show("No existe datos");
            }
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
        }

        private void exportaBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
