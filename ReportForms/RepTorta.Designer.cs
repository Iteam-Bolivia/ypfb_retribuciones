namespace ypfbApplication.ReportForms
{
    partial class RepTorta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exportaBtn = new System.Windows.Forms.Button();
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.cbxMesFin = new System.Windows.Forms.ComboBox();
            this.cbxAnioFin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTituloReporte = new System.Windows.Forms.ComboBox();
            this.lblTipoTorta = new System.Windows.Forms.Label();
            this.cbxTipoCalculo = new System.Windows.Forms.ComboBox();
            this.lblTipoCalculo = new System.Windows.Forms.Label();
            this.cbxVariable = new System.Windows.Forms.ComboBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.cbxGrafico = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblContrato = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.exportaBtn);
            this.groupBox1.Controls.Add(this.limpiarBtn);
            this.groupBox1.Controls.Add(this.cbxMesFin);
            this.groupBox1.Controls.Add(this.cbxAnioFin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxTituloReporte);
            this.groupBox1.Controls.Add(this.lblTipoTorta);
            this.groupBox1.Controls.Add(this.cbxTipoCalculo);
            this.groupBox1.Controls.Add(this.lblTipoCalculo);
            this.groupBox1.Controls.Add(this.cbxVariable);
            this.groupBox1.Controls.Add(this.lblVariable);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Controls.Add(this.cbxMes);
            this.groupBox1.Controls.Add(this.cbxAnio);
            this.groupBox1.Controls.Add(this.cbxGrafico);
            this.groupBox1.Controls.Add(this.lblMes);
            this.groupBox1.Controls.Add(this.lblAnio);
            this.groupBox1.Controls.Add(this.lblContrato);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuracion de parmetros";
            // 
            // exportaBtn
            // 
            this.exportaBtn.Location = new System.Drawing.Point(675, 132);
            this.exportaBtn.Name = "exportaBtn";
            this.exportaBtn.Size = new System.Drawing.Size(97, 23);
            this.exportaBtn.TabIndex = 18;
            this.exportaBtn.Text = "Exportar a excel";
            this.exportaBtn.UseVisualStyleBackColor = true;
            this.exportaBtn.Click += new System.EventHandler(this.exportaBtn_Click);
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(778, 132);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 17;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // cbxMesFin
            // 
            this.cbxMesFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMesFin.FormattingEnabled = true;
            this.cbxMesFin.Location = new System.Drawing.Point(395, 77);
            this.cbxMesFin.Name = "cbxMesFin";
            this.cbxMesFin.Size = new System.Drawing.Size(249, 21);
            this.cbxMesFin.TabIndex = 16;
            // 
            // cbxAnioFin
            // 
            this.cbxAnioFin.FormattingEnabled = true;
            this.cbxAnioFin.Location = new System.Drawing.Point(97, 77);
            this.cbxAnioFin.Name = "cbxAnioFin";
            this.cbxAnioFin.Size = new System.Drawing.Size(217, 21);
            this.cbxAnioFin.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mes Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Año Final:";
            // 
            // cbxTituloReporte
            // 
            this.cbxTituloReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTituloReporte.FormattingEnabled = true;
            this.cbxTituloReporte.Location = new System.Drawing.Point(97, 104);
            this.cbxTituloReporte.Name = "cbxTituloReporte";
            this.cbxTituloReporte.Size = new System.Drawing.Size(547, 21);
            this.cbxTituloReporte.TabIndex = 12;
            // 
            // lblTipoTorta
            // 
            this.lblTipoTorta.AutoSize = true;
            this.lblTipoTorta.Location = new System.Drawing.Point(8, 107);
            this.lblTipoTorta.Name = "lblTipoTorta";
            this.lblTipoTorta.Size = new System.Drawing.Size(72, 13);
            this.lblTipoTorta.TabIndex = 11;
            this.lblTipoTorta.Text = "Titulo reporte:";
            // 
            // cbxTipoCalculo
            // 
            this.cbxTipoCalculo.FormattingEnabled = true;
            this.cbxTipoCalculo.Location = new System.Drawing.Point(97, 24);
            this.cbxTipoCalculo.Name = "cbxTipoCalculo";
            this.cbxTipoCalculo.Size = new System.Drawing.Size(217, 21);
            this.cbxTipoCalculo.TabIndex = 10;
            // 
            // lblTipoCalculo
            // 
            this.lblTipoCalculo.AutoSize = true;
            this.lblTipoCalculo.Location = new System.Drawing.Point(8, 28);
            this.lblTipoCalculo.Name = "lblTipoCalculo";
            this.lblTipoCalculo.Size = new System.Drawing.Size(83, 13);
            this.lblTipoCalculo.TabIndex = 9;
            this.lblTipoCalculo.Text = "Tipo de calculo:";
            // 
            // cbxVariable
            // 
            this.cbxVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVariable.FormattingEnabled = true;
            this.cbxVariable.Location = new System.Drawing.Point(395, 24);
            this.cbxVariable.Name = "cbxVariable";
            this.cbxVariable.Size = new System.Drawing.Size(249, 21);
            this.cbxVariable.TabIndex = 8;
            // 
            // lblVariable
            // 
            this.lblVariable.AutoSize = true;
            this.lblVariable.Location = new System.Drawing.Point(320, 27);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(48, 13);
            this.lblVariable.TabIndex = 7;
            this.lblVariable.Text = "Variable:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesar.Location = new System.Drawing.Point(859, 131);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // cbxMes
            // 
            this.cbxMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Location = new System.Drawing.Point(395, 50);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.Size = new System.Drawing.Size(249, 21);
            this.cbxMes.TabIndex = 5;
            // 
            // cbxAnio
            // 
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(97, 50);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(217, 21);
            this.cbxAnio.TabIndex = 4;
            // 
            // cbxGrafico
            // 
            this.cbxGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGrafico.FormattingEnabled = true;
            this.cbxGrafico.Location = new System.Drawing.Point(724, 24);
            this.cbxGrafico.Name = "cbxGrafico";
            this.cbxGrafico.Size = new System.Drawing.Size(198, 21);
            this.cbxGrafico.TabIndex = 3;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(320, 53);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(60, 13);
            this.lblMes.TabIndex = 2;
            this.lblMes.Text = "Mes Inicial:";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(8, 53);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(58, 13);
            this.lblAnio.TabIndex = 1;
            this.lblAnio.Text = "Año inicial:";
            // 
            // lblContrato
            // 
            this.lblContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrato.AutoSize = true;
            this.lblContrato.Location = new System.Drawing.Point(650, 27);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(68, 13);
            this.lblContrato.TabIndex = 0;
            this.lblContrato.Text = "Tipo Grafico:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 396);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.IsSoftShadows = false;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 19);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "MinimumRelativePieSize=20, PieDrawingStyle=Concave, CollectedLabel=Other, Doughnu" +
    "tRadius=25";
            series1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            series1.Label = "#PERCENT{P1}";
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(923, 371);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Grafico";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // RepTorta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(964, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RepTorta";
            this.Text = "RepPastel";
            this.Load += new System.EventHandler(this.RepPastel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.ComboBox cbxMes;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.ComboBox cbxGrafico;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbxVariable;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox cbxTipoCalculo;
        private System.Windows.Forms.Label lblTipoCalculo;
        private System.Windows.Forms.ComboBox cbxTituloReporte;
        private System.Windows.Forms.Label lblTipoTorta;
        private System.Windows.Forms.ComboBox cbxMesFin;
        private System.Windows.Forms.ComboBox cbxAnioFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button exportaBtn;
    }
}