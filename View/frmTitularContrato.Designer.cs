namespace ypfbApplication.View
{
    partial class frmTitularContrato
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
          this.cbofields1 = new System.Windows.Forms.ComboBox();
          this.lblcbofields1 = new System.Windows.Forms.Label();
          this.btnGuardar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.cbofields2 = new System.Windows.Forms.ComboBox();
          this.lblContrato = new System.Windows.Forms.Label();
          this.lblPorcentaje = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // cbofields1
          // 
          this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields1.FormattingEnabled = true;
          this.cbofields1.Location = new System.Drawing.Point(95, 42);
          this.cbofields1.Name = "cbofields1";
          this.cbofields1.Size = new System.Drawing.Size(270, 21);
          this.cbofields1.TabIndex = 0;
          this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTitulares_KeyPress);
          // 
          // lblcbofields1
          // 
          this.lblcbofields1.AutoSize = true;
          this.lblcbofields1.Location = new System.Drawing.Point(29, 45);
          this.lblcbofields1.Name = "lblcbofields1";
          this.lblcbofields1.Size = new System.Drawing.Size(56, 13);
          this.lblcbofields1.TabIndex = 1;
          this.lblcbofields1.Text = "Empresas:";
          // 
          // btnGuardar
          // 
          this.btnGuardar.Location = new System.Drawing.Point(103, 145);
          this.btnGuardar.Name = "btnGuardar";
          this.btnGuardar.Size = new System.Drawing.Size(75, 23);
          this.btnGuardar.TabIndex = 3;
          this.btnGuardar.Text = "&Guardar";
          this.btnGuardar.UseVisualStyleBackColor = true;
          this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(215, 145);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 4;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(29, 72);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(31, 13);
          this.lbltxtfields1.TabIndex = 4;
          this.lbltxtfields1.Text = "Tipo:";
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(29, 98);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(61, 13);
          this.lbltxtfields2.TabIndex = 5;
          this.lbltxtfields2.Text = "Porcentaje:";
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(95, 95);
          this.txtfields2.MaxLength = 5;
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(117, 20);
          this.txtfields2.TabIndex = 2;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
          // 
          // cbofields2
          // 
          this.cbofields2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields2.FormattingEnabled = true;
          this.cbofields2.Location = new System.Drawing.Point(95, 68);
          this.cbofields2.Name = "cbofields2";
          this.cbofields2.Size = new System.Drawing.Size(117, 21);
          this.cbofields2.TabIndex = 1;
          this.cbofields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipos_KeyPress);
          // 
          // lblContrato
          // 
          this.lblContrato.AutoSize = true;
          this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblContrato.Location = new System.Drawing.Point(29, 9);
          this.lblContrato.Name = "lblContrato";
          this.lblContrato.Size = new System.Drawing.Size(0, 13);
          this.lblContrato.TabIndex = 11;
          // 
          // lblPorcentaje
          // 
          this.lblPorcentaje.AutoSize = true;
          this.lblPorcentaje.Location = new System.Drawing.Point(228, 98);
          this.lblPorcentaje.Name = "lblPorcentaje";
          this.lblPorcentaje.Size = new System.Drawing.Size(0, 13);
          this.lblPorcentaje.TabIndex = 12;
          // 
          // frmTitularContrato
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(377, 189);
          this.Controls.Add(this.lblPorcentaje);
          this.Controls.Add(this.lblContrato);
          this.Controls.Add(this.cbofields2);
          this.Controls.Add(this.txtfields2);
          this.Controls.Add(this.lbltxtfields2);
          this.Controls.Add(this.lbltxtfields1);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnGuardar);
          this.Controls.Add(this.lblcbofields1);
          this.Controls.Add(this.cbofields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmTitularContrato";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Contrato Empresa";
          this.Load += new System.EventHandler(this.frmTitularContrato_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbltxtfields1;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.TextBox txtfields2;
        private System.Windows.Forms.ComboBox cbofields2;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.Label lblPorcentaje;
    }
}