namespace ypfbApplication.View
{
    partial class frmMercado
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
            this.lbltxtfields3 = new System.Windows.Forms.Label();
            this.cbxCampoNombre = new System.Windows.Forms.ComboBox();
            this.txtMer_tipo = new System.Windows.Forms.TextBox();
            this.txtMer_orden = new System.Windows.Forms.TextBox();
            this.txtMer_ordenletra = new System.Windows.Forms.TextBox();
            this.txtMer_var = new System.Windows.Forms.TextBox();
            this.txtPro_mer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(51, 108);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtfields2
            // 
            this.txtfields2.Location = new System.Drawing.Point(71, 69);
            this.txtfields2.MaxLength = 256;
            this.txtfields2.Name = "txtfields2";
            this.txtfields2.Size = new System.Drawing.Size(208, 20);
            this.txtfields2.TabIndex = 1;
            this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtfields1
            // 
            this.txtfields1.Location = new System.Drawing.Point(71, 42);
            this.txtfields1.MaxLength = 20;
            this.txtfields1.Name = "txtfields1";
            this.txtfields1.Size = new System.Drawing.Size(100, 20);
            this.txtfields1.TabIndex = 0;
            this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lbltxtfields2
            // 
            this.lbltxtfields2.AutoSize = true;
            this.lbltxtfields2.Location = new System.Drawing.Point(14, 68);
            this.lbltxtfields2.Name = "lbltxtfields2";
            this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
            this.lbltxtfields2.TabIndex = 19;
            this.lbltxtfields2.Text = "Nombre:";
            // 
            // lbltxtfields1
            // 
            this.lbltxtfields1.AutoSize = true;
            this.lbltxtfields1.Location = new System.Drawing.Point(14, 42);
            this.lbltxtfields1.Name = "lbltxtfields1";
            this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
            this.lbltxtfields1.TabIndex = 18;
            this.lbltxtfields1.Text = "Código:";
            // 
            // lbltxtfields3
            // 
            this.lbltxtfields3.AutoSize = true;
            this.lbltxtfields3.Location = new System.Drawing.Point(14, 13);
            this.lbltxtfields3.Name = "lbltxtfields3";
            this.lbltxtfields3.Size = new System.Drawing.Size(43, 13);
            this.lbltxtfields3.TabIndex = 20;
            this.lbltxtfields3.Text = "Campo:";
            this.lbltxtfields3.Visible = false;
            // 
            // cbxCampoNombre
            // 
            this.cbxCampoNombre.FormattingEnabled = true;
            this.cbxCampoNombre.Location = new System.Drawing.Point(71, 10);
            this.cbxCampoNombre.Name = "cbxCampoNombre";
            this.cbxCampoNombre.Size = new System.Drawing.Size(208, 21);
            this.cbxCampoNombre.TabIndex = 21;
            this.cbxCampoNombre.Visible = false;
            // 
            // txtMer_tipo
            // 
            this.txtMer_tipo.Location = new System.Drawing.Point(-3, 133);
            this.txtMer_tipo.Name = "txtMer_tipo";
            this.txtMer_tipo.Size = new System.Drawing.Size(37, 20);
            this.txtMer_tipo.TabIndex = 22;
            this.txtMer_tipo.Visible = false;
            // 
            // txtMer_orden
            // 
            this.txtMer_orden.Location = new System.Drawing.Point(40, 133);
            this.txtMer_orden.Name = "txtMer_orden";
            this.txtMer_orden.Size = new System.Drawing.Size(37, 20);
            this.txtMer_orden.TabIndex = 23;
            this.txtMer_orden.Visible = false;
            // 
            // txtMer_ordenletra
            // 
            this.txtMer_ordenletra.Location = new System.Drawing.Point(89, 133);
            this.txtMer_ordenletra.Name = "txtMer_ordenletra";
            this.txtMer_ordenletra.Size = new System.Drawing.Size(37, 20);
            this.txtMer_ordenletra.TabIndex = 24;
            this.txtMer_ordenletra.Visible = false;
            // 
            // txtMer_var
            // 
            this.txtMer_var.Location = new System.Drawing.Point(134, 133);
            this.txtMer_var.Name = "txtMer_var";
            this.txtMer_var.Size = new System.Drawing.Size(37, 20);
            this.txtMer_var.TabIndex = 25;
            this.txtMer_var.Visible = false;
            // 
            // txtPro_mer
            // 
            this.txtPro_mer.Location = new System.Drawing.Point(187, 133);
            this.txtPro_mer.Name = "txtPro_mer";
            this.txtPro_mer.Size = new System.Drawing.Size(37, 20);
            this.txtPro_mer.TabIndex = 26;
            this.txtPro_mer.Visible = false;
            // 
            // frmMercado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(299, 151);
            this.Controls.Add(this.txtPro_mer);
            this.Controls.Add(this.txtMer_var);
            this.Controls.Add(this.txtMer_ordenletra);
            this.Controls.Add(this.txtMer_orden);
            this.Controls.Add(this.txtMer_tipo);
            this.Controls.Add(this.cbxCampoNombre);
            this.Controls.Add(this.lbltxtfields3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtfields2);
            this.Controls.Add(this.txtfields1);
            this.Controls.Add(this.lbltxtfields2);
            this.Controls.Add(this.lbltxtfields1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMercado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercado";
            this.Load += new System.EventHandler(this.frmMercado_Load);
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
        private System.Windows.Forms.Label lbltxtfields3;
        private System.Windows.Forms.ComboBox cbxCampoNombre;
        private System.Windows.Forms.TextBox txtMer_tipo;
        private System.Windows.Forms.TextBox txtMer_orden;
        private System.Windows.Forms.TextBox txtMer_ordenletra;
        private System.Windows.Forms.TextBox txtMer_var;
        private System.Windows.Forms.TextBox txtPro_mer;
    }
}