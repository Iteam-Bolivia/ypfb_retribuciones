﻿namespace ypfbApplication.View
{
    partial class frmBloque
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
          this.btnCancelar = new System.Windows.Forms.Button();
          this.btnGuardar = new System.Windows.Forms.Button();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(197, 101);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 3;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // btnGuardar
          // 
          this.btnGuardar.Location = new System.Drawing.Point(86, 101);
          this.btnGuardar.Name = "btnGuardar";
          this.btnGuardar.Size = new System.Drawing.Size(75, 23);
          this.btnGuardar.TabIndex = 2;
          this.btnGuardar.Text = "&Guardar";
          this.btnGuardar.UseVisualStyleBackColor = true;
          this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(86, 55);
          this.txtfields2.MaxLength = 256;
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(208, 20);
          this.txtfields2.TabIndex = 1;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(86, 28);
          this.txtfields1.MaxLength = 16;
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(100, 20);
          this.txtfields1.TabIndex = 0;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(29, 54);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
          this.lbltxtfields2.TabIndex = 7;
          this.lbltxtfields2.Text = "Nombre:";
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(26, 28);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
          this.lbltxtfields1.TabIndex = 6;
          this.lbltxtfields1.Text = "Código:";
          // 
          // frmBloque
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(328, 162);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnGuardar);
          this.Controls.Add(this.txtfields2);
          this.Controls.Add(this.txtfields1);
          this.Controls.Add(this.lbltxtfields2);
          this.Controls.Add(this.lbltxtfields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmBloque";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Bloques";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtfields2;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.Label lbltxtfields1;
    }
}