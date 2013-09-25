namespace ypfbApplication.View
{
    partial class frmTitular
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
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.btnGuardar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.txtfields3 = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(9, 28);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
          this.lbltxtfields1.TabIndex = 0;
          this.lbltxtfields1.Text = "Código:";
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(12, 54);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
          this.lbltxtfields2.TabIndex = 1;
          this.lbltxtfields2.Text = "Nombre:";
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(69, 29);
          this.txtfields1.MaxLength = 16;
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(100, 20);
          this.txtfields1.TabIndex = 0;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(69, 55);
          this.txtfields2.MaxLength = 256;
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(229, 20);
          this.txtfields2.TabIndex = 1;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
          // 
          // btnGuardar
          // 
          this.btnGuardar.Location = new System.Drawing.Point(69, 131);
          this.btnGuardar.Name = "btnGuardar";
          this.btnGuardar.Size = new System.Drawing.Size(75, 23);
          this.btnGuardar.TabIndex = 2;
          this.btnGuardar.Text = "&Guardar";
          this.btnGuardar.UseVisualStyleBackColor = true;
          this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(180, 131);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 3;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // txtfields3
          // 
          this.txtfields3.Location = new System.Drawing.Point(69, 81);
          this.txtfields3.MaxLength = 16;
          this.txtfields3.Name = "txtfields3";
          this.txtfields3.Size = new System.Drawing.Size(100, 20);
          this.txtfields3.TabIndex = 2;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(9, 80);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(39, 13);
          this.label1.TabIndex = 4;
          this.label1.Text = "Orden:";
          // 
          // frmTitular
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(310, 199);
          this.Controls.Add(this.txtfields3);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnGuardar);
          this.Controls.Add(this.txtfields2);
          this.Controls.Add(this.txtfields1);
          this.Controls.Add(this.lbltxtfields2);
          this.Controls.Add(this.lbltxtfields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmTitular";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Empresas";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltxtfields1;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.TextBox txtfields2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtfields3;
        private System.Windows.Forms.Label label1;
    }
}