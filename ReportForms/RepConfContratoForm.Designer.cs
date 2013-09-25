namespace ypfbApplication.ReportForms
{
    partial class RepConfContratoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepConfContratoForm));
            this.label2 = new System.Windows.Forms.Label();
            this.ContratoCbo = new System.Windows.Forms.ComboBox();
            this.GeneraBtn = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contrato";
            // 
            // ContratoCbo
            // 
            this.ContratoCbo.FormattingEnabled = true;
            this.ContratoCbo.Location = new System.Drawing.Point(60, 36);
            this.ContratoCbo.Name = "ContratoCbo";
            this.ContratoCbo.Size = new System.Drawing.Size(188, 21);
            this.ContratoCbo.TabIndex = 17;
            // 
            // GeneraBtn
            // 
            this.GeneraBtn.Image = ((System.Drawing.Image)(resources.GetObject("GeneraBtn.Image")));
            this.GeneraBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GeneraBtn.Location = new System.Drawing.Point(13, 63);
            this.GeneraBtn.Name = "GeneraBtn";
            this.GeneraBtn.Size = new System.Drawing.Size(127, 34);
            this.GeneraBtn.TabIndex = 26;
            this.GeneraBtn.Text = "Generar Reporte";
            this.GeneraBtn.UseVisualStyleBackColor = true;
            this.GeneraBtn.Click += new System.EventHandler(this.GeneraBtn_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ypfbApplication.Reports.ReportConfContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 103);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(968, 452);
            this.reportViewer1.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(359, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "REPORTE DE CONTRATOS";
            // 
            // RepConfContratoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(993, 567);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.GeneraBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ContratoCbo);
            this.Name = "RepConfContratoForm";
            this.Text = "Reporte de Contratos";
            this.Load += new System.EventHandler(this.RepConfContratoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ContratoCbo;
        private System.Windows.Forms.Button GeneraBtn;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label4;
    }
}