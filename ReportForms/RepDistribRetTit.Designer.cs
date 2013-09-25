namespace ypfbApplication.ReportForms
{
    partial class RepDistribRetTit
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
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.GeneraBtn = new System.Windows.Forms.Button();
          this.AnioCbo = new System.Windows.Forms.ComboBox();
          this.MesCbo = new System.Windows.Forms.ComboBox();
          this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(34, 40);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(30, 13);
          this.label1.TabIndex = 60;
          this.label1.Text = "Mes:";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(175, 40);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(29, 13);
          this.label2.TabIndex = 61;
          this.label2.Text = "Año:";
          // 
          // GeneraBtn
          // 
          this.GeneraBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.GeneraBtn.Location = new System.Drawing.Point(366, 37);
          this.GeneraBtn.Name = "GeneraBtn";
          this.GeneraBtn.Size = new System.Drawing.Size(122, 23);
          this.GeneraBtn.TabIndex = 58;
          this.GeneraBtn.Text = "Generar Reporte";
          this.GeneraBtn.UseVisualStyleBackColor = true;
          this.GeneraBtn.Click += new System.EventHandler(this.GeneraBtn_Click);
          // 
          // AnioCbo
          // 
          this.AnioCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.AnioCbo.FormattingEnabled = true;
          this.AnioCbo.Location = new System.Drawing.Point(210, 37);
          this.AnioCbo.Name = "AnioCbo";
          this.AnioCbo.Size = new System.Drawing.Size(99, 21);
          this.AnioCbo.TabIndex = 57;
          // 
          // MesCbo
          // 
          this.MesCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.MesCbo.FormattingEnabled = true;
          this.MesCbo.Location = new System.Drawing.Point(70, 37);
          this.MesCbo.Name = "MesCbo";
          this.MesCbo.Size = new System.Drawing.Size(99, 21);
          this.MesCbo.TabIndex = 59;
          // 
          // reportViewer1
          // 
          this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.reportViewer1.LocalReport.ReportEmbeddedResource = "ypfbApplication.Reports.ReportDistribRetTit.rdlc";
          this.reportViewer1.Location = new System.Drawing.Point(12, 66);
          this.reportViewer1.Name = "reportViewer1";
          this.reportViewer1.Size = new System.Drawing.Size(817, 395);
          this.reportViewer1.TabIndex = 62;
          // 
          // RepDistribRetTit
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(841, 473);
          this.Controls.Add(this.reportViewer1);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.GeneraBtn);
          this.Controls.Add(this.AnioCbo);
          this.Controls.Add(this.MesCbo);
          this.Name = "RepDistribRetTit";
          this.Text = "ANÁLISIS DE RETRIBUCIÓN - ESTIMACIÓN DE VALOR EN PUNTO DE FISCALIZACIÓN";
          this.Load += new System.EventHandler(this.RepDistribRetTit_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GeneraBtn;
        private System.Windows.Forms.ComboBox AnioCbo;
        private System.Windows.Forms.ComboBox MesCbo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}