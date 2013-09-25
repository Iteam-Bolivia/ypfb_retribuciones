namespace ypfbApplication.View
{
    partial class frmCalculoProyeccionVariable
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
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMes2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.cmdTasa = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this._Label1_1 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxMes
            // 
            this.cbxMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Location = new System.Drawing.Point(176, 38);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxMes.Size = new System.Drawing.Size(209, 21);
            this.cbxMes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(56, 41);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 66;
            this.label4.Text = "Periodo Inicial:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(56, 68);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Periodo Final:";
            // 
            // cbxMes2
            // 
            this.cbxMes2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMes2.FormattingEnabled = true;
            this.cbxMes2.Location = new System.Drawing.Point(176, 65);
            this.cbxMes2.Name = "cbxMes2";
            this.cbxMes2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxMes2.Size = new System.Drawing.Size(209, 21);
            this.cbxMes2.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(56, 14);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Variable:";
            // 
            // cbofields1
            // 
            this.cbofields1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(176, 11);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbofields1.Size = new System.Drawing.Size(209, 21);
            this.cbofields1.TabIndex = 69;
            // 
            // cmdTasa
            // 
            this.cmdTasa.Location = new System.Drawing.Point(457, 34);
            this.cmdTasa.Name = "cmdTasa";
            this.cmdTasa.Size = new System.Drawing.Size(101, 27);
            this.cmdTasa.TabIndex = 71;
            this.cmdTasa.Text = "&Calcular Tasa";
            this.cmdTasa.UseVisualStyleBackColor = true;
            this.cmdTasa.Click += new System.EventHandler(this.cmdTasa_Click);
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValue.Location = new System.Drawing.Point(176, 92);
            this.txtValue.MaxLength = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValue.Size = new System.Drawing.Size(209, 20);
            this.txtValue.TabIndex = 73;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // _Label1_1
            // 
            this._Label1_1.BackColor = System.Drawing.Color.AliceBlue;
            this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_1.Location = new System.Drawing.Point(56, 95);
            this._Label1_1.Name = "_Label1_1";
            this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_1.Size = new System.Drawing.Size(43, 17);
            this._Label1_1.TabIndex = 72;
            this._Label1_1.Text = "Valor:";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(176, 156);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(101, 27);
            this.cmdAceptar.TabIndex = 74;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(293, 156);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(101, 27);
            this.cmdCancelar.TabIndex = 75;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // frmCalculoProyeccionVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(595, 233);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this._Label1_1);
            this.Controls.Add(this.cmdTasa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbofields1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMes2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMes);
            this.Name = "frmCalculoProyeccionVariable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCalculoProyeccionVariable";
            this.Load += new System.EventHandler(this.frmCalculoProyeccionVariable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMes;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMes2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Button cmdTasa;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.Label _Label1_1;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
    }
}