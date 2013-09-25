namespace ypfbApplication.View
{
    partial class frmTitularBusqueda
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
          this.gbCabecera = new System.Windows.Forms.GroupBox();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.btnBuscar = new System.Windows.Forms.Button();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.gbCabecera.SuspendLayout();
          this.SuspendLayout();
          // 
          // gbCabecera
          // 
          this.gbCabecera.Controls.Add(this.btnCancelar);
          this.gbCabecera.Controls.Add(this.btnBuscar);
          this.gbCabecera.Controls.Add(this.lbltxtfields1);
          this.gbCabecera.Controls.Add(this.lbltxtfields2);
          this.gbCabecera.Controls.Add(this.txtfields1);
          this.gbCabecera.Controls.Add(this.txtfields2);
          this.gbCabecera.Location = new System.Drawing.Point(12, 12);
          this.gbCabecera.Name = "gbCabecera";
          this.gbCabecera.Size = new System.Drawing.Size(390, 133);
          this.gbCabecera.TabIndex = 0;
          this.gbCabecera.TabStop = false;
          this.gbCabecera.Text = "Opciones de Búsqueda";
          // 
          // btnCancelar
          // 
          this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancelar.Location = new System.Drawing.Point(222, 93);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 3;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // btnBuscar
          // 
          this.btnBuscar.Location = new System.Drawing.Point(106, 93);
          this.btnBuscar.Name = "btnBuscar";
          this.btnBuscar.Size = new System.Drawing.Size(75, 23);
          this.btnBuscar.TabIndex = 2;
          this.btnBuscar.Text = "&Búsqueda";
          this.btnBuscar.UseVisualStyleBackColor = true;
          this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(22, 32);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(62, 13);
          this.lbltxtfields1.TabIndex = 1;
          this.lbltxtfields1.Text = "Por Código:";
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(22, 58);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(66, 13);
          this.lbltxtfields2.TabIndex = 2;
          this.lbltxtfields2.Text = "Por Nombre:";
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(122, 29);
          this.txtfields1.MaxLength = 16;
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(140, 20);
          this.txtfields1.TabIndex = 0;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(122, 55);
          this.txtfields2.MaxLength = 256;
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(237, 20);
          this.txtfields2.TabIndex = 1;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
          // 
          // frmTitularBusqueda
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(420, 166);
          this.Controls.Add(this.gbCabecera);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmTitularBusqueda";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Búsqueda de Empresas";
          this.gbCabecera.ResumeLayout(false);
          this.gbCabecera.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCabecera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbltxtfields1;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.TextBox txtfields2;
    }
}