namespace ypfbApplication.ReportForms
{
  partial class RepDistribPart
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
            this.GeneraBtn = new System.Windows.Forms.Button();
            this.AnioIniCbo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MesIniCbo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipoCalculo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // GeneraBtn
            // 
            this.GeneraBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GeneraBtn.Location = new System.Drawing.Point(543, 10);
            this.GeneraBtn.Name = "GeneraBtn";
            this.GeneraBtn.Size = new System.Drawing.Size(122, 23);
            this.GeneraBtn.TabIndex = 46;
            this.GeneraBtn.Text = "Generar Reporte";
            this.GeneraBtn.UseVisualStyleBackColor = true;
            this.GeneraBtn.Click += new System.EventHandler(this.GeneraBtn_Click);
            // 
            // AnioIniCbo
            // 
            this.AnioIniCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnioIniCbo.FormattingEnabled = true;
            this.AnioIniCbo.Location = new System.Drawing.Point(438, 12);
            this.AnioIniCbo.Name = "AnioIniCbo";
            this.AnioIniCbo.Size = new System.Drawing.Size(99, 21);
            this.AnioIniCbo.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-87, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Mes:";
            // 
            // MesIniCbo
            // 
            this.MesIniCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MesIniCbo.FormattingEnabled = true;
            this.MesIniCbo.Location = new System.Drawing.Point(298, 12);
            this.MesIniCbo.Name = "MesIniCbo";
            this.MesIniCbo.Size = new System.Drawing.Size(99, 21);
            this.MesIniCbo.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-86, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Mes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Año:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ypfbApplication.Reports.ReportDistribPart.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(676, 496);
            this.reportViewer1.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Tipo de calculo:";
            // 
            // cbxTipoCalculo
            // 
            this.cbxTipoCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCalculo.FormattingEnabled = true;
            this.cbxTipoCalculo.Location = new System.Drawing.Point(108, 12);
            this.cbxTipoCalculo.Name = "cbxTipoCalculo";
            this.cbxTipoCalculo.Size = new System.Drawing.Size(148, 21);
            this.cbxTipoCalculo.TabIndex = 55;
            // 
            // RepDistribPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(700, 565);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxTipoCalculo);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GeneraBtn);
            this.Controls.Add(this.AnioIniCbo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MesIniCbo);
            this.Controls.Add(this.label5);
            this.Name = "RepDistribPart";
            this.Text = "Reporte Distribución de la Participación";
            this.Load += new System.EventHandler(this.RepDistribRet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button GeneraBtn;
    private System.Windows.Forms.ComboBox AnioIniCbo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox MesIniCbo;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbxTipoCalculo;
  }
}