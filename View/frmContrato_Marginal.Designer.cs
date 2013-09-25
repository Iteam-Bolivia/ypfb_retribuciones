namespace ypfbApplication.View
{
    partial class frmContrato_Marginal
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
            this.lblcbofields1 = new System.Windows.Forms.Label();
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblContrato = new System.Windows.Forms.Label();
            this.cbxAnio_ini = new System.Windows.Forms.ComboBox();
            this.cbxMes_ini = new System.Windows.Forms.ComboBox();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblcbofields1
            // 
            this.lblcbofields1.AutoSize = true;
            this.lblcbofields1.Location = new System.Drawing.Point(24, 27);
            this.lblcbofields1.Name = "lblcbofields1";
            this.lblcbofields1.Size = new System.Drawing.Size(50, 13);
            this.lblcbofields1.TabIndex = 34;
            this.lblcbofields1.Text = "Contrato:";
            // 
            // cbofields1
            // 
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(80, 24);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.Size = new System.Drawing.Size(433, 21);
            this.cbofields1.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Año inicial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Periodo inicial:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(380, 148);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 27);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(111, 148);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 27);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrato.Location = new System.Drawing.Point(99, 28);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(0, 13);
            this.lblContrato.TabIndex = 52;
            // 
            // cbxAnio_ini
            // 
            this.cbxAnio_ini.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAnio_ini.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAnio_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAnio_ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAnio_ini.FormattingEnabled = true;
            this.cbxAnio_ini.Location = new System.Drawing.Point(106, 106);
            this.cbxAnio_ini.Name = "cbxAnio_ini";
            this.cbxAnio_ini.Size = new System.Drawing.Size(165, 21);
            this.cbxAnio_ini.TabIndex = 95;
            // 
            // cbxMes_ini
            // 
            this.cbxMes_ini.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxMes_ini.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMes_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes_ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMes_ini.FormattingEnabled = true;
            this.cbxMes_ini.Location = new System.Drawing.Point(106, 62);
            this.cbxMes_ini.Name = "cbxMes_ini";
            this.cbxMes_ini.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxMes_ini.Size = new System.Drawing.Size(165, 21);
            this.cbxMes_ini.TabIndex = 94;
            // 
            // cbxAnio
            // 
            this.cbxAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(348, 106);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(165, 21);
            this.cbxAnio.TabIndex = 99;
            // 
            // cbxMes
            // 
            this.cbxMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Location = new System.Drawing.Point(348, 62);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxMes.Size = new System.Drawing.Size(165, 21);
            this.cbxMes.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Año final:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "Periodo final:";
            // 
            // frmContrato_Marginal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 188);
            this.Controls.Add(this.cbxAnio);
            this.Controls.Add(this.cbxMes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxAnio_ini);
            this.Controls.Add(this.cbxMes_ini);
            this.Controls.Add(this.lblContrato);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblcbofields1);
            this.Controls.Add(this.cbofields1);
            this.Name = "frmContrato_Marginal";
            this.Text = "frmContrato_Marginal";
            this.Load += new System.EventHandler(this.frmContrato_Marginal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.ComboBox cbxAnio_ini;
        private System.Windows.Forms.ComboBox cbxMes_ini;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.ComboBox cbxMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}