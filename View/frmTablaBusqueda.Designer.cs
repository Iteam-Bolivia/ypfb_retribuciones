namespace ypfbApplication.View
{
    partial class frmTablaBusqueda
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
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.btnBuscar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(154, 26);
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(118, 20);
          this.txtfields1.TabIndex = 0;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(154, 55);
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(174, 20);
          this.txtfields2.TabIndex = 1;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
          // 
          // btnBuscar
          // 
          this.btnBuscar.Location = new System.Drawing.Point(84, 95);
          this.btnBuscar.Name = "btnBuscar";
          this.btnBuscar.Size = new System.Drawing.Size(75, 23);
          this.btnBuscar.TabIndex = 2;
          this.btnBuscar.Text = "&Buscar";
          this.btnBuscar.UseVisualStyleBackColor = true;
          this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(221, 95);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 3;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(39, 55);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(109, 13);
          this.lbltxtfields2.TabIndex = 5;
          this.lbltxtfields2.Text = "Por nombre de Tabla:";
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(39, 29);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(107, 13);
          this.lbltxtfields1.TabIndex = 7;
          this.lbltxtfields1.Text = "Por Código de Tabla:";
          // 
          // frmTablaBusqueda
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(385, 143);
          this.Controls.Add(this.lbltxtfields1);
          this.Controls.Add(this.lbltxtfields2);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnBuscar);
          this.Controls.Add(this.txtfields2);
          this.Controls.Add(this.txtfields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmTablaBusqueda";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Búsqueda de Tablas";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.TextBox txtfields2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.Label lbltxtfields1;
    }
}