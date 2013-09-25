namespace ypfbApplication.View
{
    partial class frmContratoCampo
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
          this.btnGuardar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.cbofields1 = new System.Windows.Forms.ComboBox();
          this.lblcboFields = new System.Windows.Forms.Label();
          this.lblContrato = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // btnGuardar
          // 
          this.btnGuardar.Location = new System.Drawing.Point(140, 89);
          this.btnGuardar.Name = "btnGuardar";
          this.btnGuardar.Size = new System.Drawing.Size(75, 23);
          this.btnGuardar.TabIndex = 0;
          this.btnGuardar.Text = "&Guardar";
          this.btnGuardar.UseVisualStyleBackColor = true;
          this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(290, 89);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 1;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // cbofields1
          // 
          this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields1.FormattingEnabled = true;
          this.cbofields1.Location = new System.Drawing.Point(146, 43);
          this.cbofields1.Name = "cbofields1";
          this.cbofields1.Size = new System.Drawing.Size(292, 21);
          this.cbofields1.TabIndex = 2;
          this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCampos_KeyPress);
          // 
          // lblcboFields
          // 
          this.lblcboFields.AutoSize = true;
          this.lblcboFields.Location = new System.Drawing.Point(52, 46);
          this.lblcboFields.Name = "lblcboFields";
          this.lblcboFields.Size = new System.Drawing.Size(88, 13);
          this.lblcboFields.TabIndex = 3;
          this.lblcboFields.Text = "Lista de Campos:";
          // 
          // lblContrato
          // 
          this.lblContrato.AutoSize = true;
          this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblContrato.Location = new System.Drawing.Point(54, 9);
          this.lblContrato.Name = "lblContrato";
          this.lblContrato.Size = new System.Drawing.Size(0, 13);
          this.lblContrato.TabIndex = 12;
          // 
          // frmContratoCampo
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(480, 132);
          this.Controls.Add(this.lblContrato);
          this.Controls.Add(this.lblcboFields);
          this.Controls.Add(this.cbofields1);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnGuardar);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmContratoCampo";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Contrato Campo";
          this.Load += new System.EventHandler(this.frmContratoCampo_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Label lblcboFields;
        private System.Windows.Forms.Label lblContrato;
    }
}