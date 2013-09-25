namespace ypfbApplication.ReportForms
{
    partial class RepRecalculo
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MesIniCbo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OperadorCbo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TipoCombo = new System.Windows.Forms.ComboBox();
            this.GeneraBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AnioIniCbo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ContratoCbo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ypfbApplication.Reports.RepRecalculo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(23, 103);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(859, 340);
            this.reportViewer1.TabIndex = 48;
            // 
            // MesIniCbo
            // 
            this.MesIniCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MesIniCbo.FormattingEnabled = true;
            this.MesIniCbo.Location = new System.Drawing.Point(592, 44);
            this.MesIniCbo.Name = "MesIniCbo";
            this.MesIniCbo.Size = new System.Drawing.Size(99, 21);
            this.MesIniCbo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Mes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Año:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.OperadorCbo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TipoCombo);
            this.groupBox1.Controls.Add(this.GeneraBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AnioIniCbo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MesIniCbo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ContratoCbo);
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 73);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones:";
            // 
            // OperadorCbo
            // 
            this.OperadorCbo.FormattingEnabled = true;
            this.OperadorCbo.Location = new System.Drawing.Point(314, 19);
            this.OperadorCbo.Name = "OperadorCbo";
            this.OperadorCbo.Size = new System.Drawing.Size(204, 21);
            this.OperadorCbo.TabIndex = 2;
            this.OperadorCbo.SelectedIndexChanged += new System.EventHandler(this.OperadorCbo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Operador:";
            // 
            // TipoCombo
            // 
            this.TipoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoCombo.FormattingEnabled = true;
            this.TipoCombo.Location = new System.Drawing.Point(81, 19);
            this.TipoCombo.Name = "TipoCombo";
            this.TipoCombo.Size = new System.Drawing.Size(138, 21);
            this.TipoCombo.TabIndex = 1;
            // 
            // GeneraBtn
            // 
            this.GeneraBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GeneraBtn.Location = new System.Drawing.Point(720, 17);
            this.GeneraBtn.Name = "GeneraBtn";
            this.GeneraBtn.Size = new System.Drawing.Size(122, 23);
            this.GeneraBtn.TabIndex = 4;
            this.GeneraBtn.Text = "Generar Reporte";
            this.GeneraBtn.UseVisualStyleBackColor = true;
            this.GeneraBtn.Click += new System.EventHandler(this.GeneraBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Tipo Calculo:";
            // 
            // AnioIniCbo
            // 
            this.AnioIniCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnioIniCbo.FormattingEnabled = true;
            this.AnioIniCbo.Location = new System.Drawing.Point(592, 19);
            this.AnioIniCbo.Name = "AnioIniCbo";
            this.AnioIniCbo.Size = new System.Drawing.Size(99, 21);
            this.AnioIniCbo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Contrato:";
            // 
            // ContratoCbo
            // 
            this.ContratoCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContratoCbo.FormattingEnabled = true;
            this.ContratoCbo.Location = new System.Drawing.Point(314, 44);
            this.ContratoCbo.Name = "ContratoCbo";
            this.ContratoCbo.Size = new System.Drawing.Size(204, 21);
            this.ContratoCbo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(276, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "RETRIBUCIONES POR CONTRATO";
            // 
            // RepRecalculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(904, 455);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "RepRecalculo";
            this.Text = "RETRIBUCIONES CONTRATO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RepRecalculo_FormClosed);
            this.Load += new System.EventHandler(this.RepRecalculo_Load);
            this.Shown += new System.EventHandler(this.RepRecalculo_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox MesIniCbo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox AnioIniCbo;
        private System.Windows.Forms.Button GeneraBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ContratoCbo;
        private System.Windows.Forms.ComboBox TipoCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OperadorCbo;
        private System.Windows.Forms.Label label6;
    }
}