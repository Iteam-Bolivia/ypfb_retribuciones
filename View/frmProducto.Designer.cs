namespace ypfbApplication.View
{
    partial class frmProducto
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
            this.lblcbofields1 = new System.Windows.Forms.Label();
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.txtPro_var = new System.Windows.Forms.TextBox();
            this.txtPro_mer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(243, 124);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(126, 124);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtfields2
            // 
            this.txtfields2.Location = new System.Drawing.Point(126, 48);
            this.txtfields2.Name = "txtfields2";
            this.txtfields2.Size = new System.Drawing.Size(275, 20);
            this.txtfields2.TabIndex = 1;
            this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtfields1
            // 
            this.txtfields1.Location = new System.Drawing.Point(126, 21);
            this.txtfields1.Name = "txtfields1";
            this.txtfields1.Size = new System.Drawing.Size(100, 20);
            this.txtfields1.TabIndex = 0;
            this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lbltxtfields2
            // 
            this.lbltxtfields2.AutoSize = true;
            this.lbltxtfields2.Location = new System.Drawing.Point(35, 51);
            this.lbltxtfields2.Name = "lbltxtfields2";
            this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
            this.lbltxtfields2.TabIndex = 13;
            this.lbltxtfields2.Text = "Nombre:";
            // 
            // lbltxtfields1
            // 
            this.lbltxtfields1.AutoSize = true;
            this.lbltxtfields1.Location = new System.Drawing.Point(35, 24);
            this.lbltxtfields1.Name = "lbltxtfields1";
            this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
            this.lbltxtfields1.TabIndex = 12;
            this.lbltxtfields1.Text = "Código:";
            // 
            // lblcbofields1
            // 
            this.lblcbofields1.AutoSize = true;
            this.lblcbofields1.Location = new System.Drawing.Point(35, 77);
            this.lblcbofields1.Name = "lblcbofields1";
            this.lblcbofields1.Size = new System.Drawing.Size(82, 13);
            this.lblcbofields1.TabIndex = 14;
            this.lblcbofields1.Text = "Unidad Medida:";
            // 
            // cbofields1
            // 
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(126, 74);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.Size = new System.Drawing.Size(192, 21);
            this.cbofields1.TabIndex = 2;
            this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields1_KeyPress);
            // 
            // txtPro_var
            // 
            this.txtPro_var.Location = new System.Drawing.Point(13, 150);
            this.txtPro_var.Name = "txtPro_var";
            this.txtPro_var.Size = new System.Drawing.Size(100, 20);
            this.txtPro_var.TabIndex = 15;
            // 
            // txtPro_mer
            // 
            this.txtPro_mer.Location = new System.Drawing.Point(168, 150);
            this.txtPro_mer.Name = "txtPro_mer";
            this.txtPro_mer.Size = new System.Drawing.Size(100, 20);
            this.txtPro_mer.TabIndex = 16;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(446, 168);
            this.Controls.Add(this.txtPro_mer);
            this.Controls.Add(this.txtPro_var);
            this.Controls.Add(this.cbofields1);
            this.Controls.Add(this.lblcbofields1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtfields2);
            this.Controls.Add(this.txtfields1);
            this.Controls.Add(this.lbltxtfields2);
            this.Controls.Add(this.lbltxtfields1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
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
        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.TextBox txtPro_var;
        private System.Windows.Forms.TextBox txtPro_mer;
    }
}