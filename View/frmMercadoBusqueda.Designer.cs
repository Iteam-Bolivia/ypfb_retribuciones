namespace ypfbApplication.View
{
    partial class frmMercadoBusqueda
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
          this.lblCodigo = new System.Windows.Forms.Label();
          this.lblNombre = new System.Windows.Forms.Label();
          this.txtCodigo = new System.Windows.Forms.TextBox();
          this.txtNombre = new System.Windows.Forms.TextBox();
          this.gbCabecera.SuspendLayout();
          this.SuspendLayout();
          // 
          // gbCabecera
          // 
          this.gbCabecera.Controls.Add(this.btnCancelar);
          this.gbCabecera.Controls.Add(this.btnBuscar);
          this.gbCabecera.Controls.Add(this.lblCodigo);
          this.gbCabecera.Controls.Add(this.lblNombre);
          this.gbCabecera.Controls.Add(this.txtCodigo);
          this.gbCabecera.Controls.Add(this.txtNombre);
          this.gbCabecera.Location = new System.Drawing.Point(28, 23);
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
          // lblCodigo
          // 
          this.lblCodigo.AutoSize = true;
          this.lblCodigo.Location = new System.Drawing.Point(22, 32);
          this.lblCodigo.Name = "lblCodigo";
          this.lblCodigo.Size = new System.Drawing.Size(62, 13);
          this.lblCodigo.TabIndex = 1;
          this.lblCodigo.Text = "Por Código:";
          // 
          // lblNombre
          // 
          this.lblNombre.AutoSize = true;
          this.lblNombre.Location = new System.Drawing.Point(22, 58);
          this.lblNombre.Name = "lblNombre";
          this.lblNombre.Size = new System.Drawing.Size(66, 13);
          this.lblNombre.TabIndex = 2;
          this.lblNombre.Text = "Por Nombre:";
          // 
          // txtCodigo
          // 
          this.txtCodigo.Location = new System.Drawing.Point(122, 29);
          this.txtCodigo.MaxLength = 16;
          this.txtCodigo.Name = "txtCodigo";
          this.txtCodigo.Size = new System.Drawing.Size(140, 20);
          this.txtCodigo.TabIndex = 0;
          this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
          // 
          // txtNombre
          // 
          this.txtNombre.Location = new System.Drawing.Point(122, 55);
          this.txtNombre.MaxLength = 256;
          this.txtNombre.Name = "txtNombre";
          this.txtNombre.Size = new System.Drawing.Size(237, 20);
          this.txtNombre.TabIndex = 1;
          this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
          // 
          // frmMercadoBusqueda
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(458, 173);
          this.Controls.Add(this.gbCabecera);
          this.Name = "frmMercadoBusqueda";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Búsqueda de Mercados";
          this.gbCabecera.ResumeLayout(false);
          this.gbCabecera.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCabecera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
    }
}