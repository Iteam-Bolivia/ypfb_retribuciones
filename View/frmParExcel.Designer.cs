namespace ypfbApplication.View
{
    partial class frmParExcel
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPex_Codigo = new System.Windows.Forms.TextBox();
            this.txtPex_Nombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblHoja = new System.Windows.Forms.Label();
            this.txtPex_Hoja = new System.Windows.Forms.TextBox();
            this.lblPex_Tipo = new System.Windows.Forms.Label();
            this.cbxPex_Tipo = new System.Windows.Forms.ComboBox();
            this.cbxTipoCalculo = new System.Windows.Forms.ComboBox();
            this.lblTca_nombre = new System.Windows.Forms.Label();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(61, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(61, 158);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtPex_Codigo
            // 
            this.txtPex_Codigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPex_Codigo.Location = new System.Drawing.Point(180, 22);
            this.txtPex_Codigo.Name = "txtPex_Codigo";
            this.txtPex_Codigo.Size = new System.Drawing.Size(304, 20);
            this.txtPex_Codigo.TabIndex = 1;
            this.txtPex_Codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPex_Codigo_KeyPress);
            // 
            // txtPex_Nombre
            // 
            this.txtPex_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPex_Nombre.Location = new System.Drawing.Point(180, 155);
            this.txtPex_Nombre.Name = "txtPex_Nombre";
            this.txtPex_Nombre.Size = new System.Drawing.Size(304, 20);
            this.txtPex_Nombre.TabIndex = 8;
            this.txtPex_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPex_Nombre_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardar.Location = new System.Drawing.Point(204, 181);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(351, 181);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblHoja
            // 
            this.lblHoja.AutoSize = true;
            this.lblHoja.Location = new System.Drawing.Point(61, 132);
            this.lblHoja.Name = "lblHoja";
            this.lblHoja.Size = new System.Drawing.Size(101, 13);
            this.lblHoja.TabIndex = 11;
            this.lblHoja.Text = "Nombre Hoja Excel:";
            // 
            // txtPex_Hoja
            // 
            this.txtPex_Hoja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPex_Hoja.Location = new System.Drawing.Point(180, 129);
            this.txtPex_Hoja.Name = "txtPex_Hoja";
            this.txtPex_Hoja.Size = new System.Drawing.Size(304, 20);
            this.txtPex_Hoja.TabIndex = 5;
            this.txtPex_Hoja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPex_Hoja_KeyPress);
            // 
            // lblPex_Tipo
            // 
            this.lblPex_Tipo.AutoSize = true;
            this.lblPex_Tipo.Location = new System.Drawing.Point(61, 78);
            this.lblPex_Tipo.Name = "lblPex_Tipo";
            this.lblPex_Tipo.Size = new System.Drawing.Size(77, 13);
            this.lblPex_Tipo.TabIndex = 13;
            this.lblPex_Tipo.Text = "Tipo de Carga:";
            // 
            // cbxPex_Tipo
            // 
            this.cbxPex_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPex_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPex_Tipo.FormattingEnabled = true;
            this.cbxPex_Tipo.Items.AddRange(new object[] {
            "",
            "CRUDO",
            "GAS NATURAL",
            "GLP",
            "PROPANO",
            "BASE  RyP",
            "Certificaciones Producción",
            "Inversiones y Costosl"});
            this.cbxPex_Tipo.Location = new System.Drawing.Point(180, 75);
            this.cbxPex_Tipo.Name = "cbxPex_Tipo";
            this.cbxPex_Tipo.Size = new System.Drawing.Size(304, 21);
            this.cbxPex_Tipo.TabIndex = 3;
            this.cbxPex_Tipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxPex_Tipo_KeyPress);
            // 
            // cbxTipoCalculo
            // 
            this.cbxTipoCalculo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTipoCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCalculo.FormattingEnabled = true;
            this.cbxTipoCalculo.Items.AddRange(new object[] {
            "",
            "CRUDO",
            "GAS NATURAL",
            "GLP",
            "PROPANO",
            "BASE  RyP",
            "Certificaciones Producción",
            "Inversiones y Costosl"});
            this.cbxTipoCalculo.Location = new System.Drawing.Point(180, 48);
            this.cbxTipoCalculo.Name = "cbxTipoCalculo";
            this.cbxTipoCalculo.Size = new System.Drawing.Size(304, 21);
            this.cbxTipoCalculo.TabIndex = 2;
            this.cbxTipoCalculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxTipoCalculo_KeyPress);
            // 
            // lblTca_nombre
            // 
            this.lblTca_nombre.AutoSize = true;
            this.lblTca_nombre.Location = new System.Drawing.Point(61, 51);
            this.lblTca_nombre.Name = "lblTca_nombre";
            this.lblTca_nombre.Size = new System.Drawing.Size(83, 13);
            this.lblTca_nombre.TabIndex = 15;
            this.lblTca_nombre.Text = "Tipo de calculo:";
            // 
            // cbxProducto
            // 
            this.cbxProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Items.AddRange(new object[] {
            "",
            "CRUDO",
            "GAS NATURAL",
            "GLP",
            "PROPANO",
            "BASE  RyP",
            "Certificaciones Producción",
            "Inversiones y Costosl"});
            this.cbxProducto.Location = new System.Drawing.Point(180, 102);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(304, 21);
            this.cbxProducto.TabIndex = 4;
            this.cbxProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxProducto_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(61, 105);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 17;
            this.lblProducto.Text = "Producto:";
            // 
            // frmParExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(532, 309);
            this.Controls.Add(this.cbxProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cbxTipoCalculo);
            this.Controls.Add(this.lblTca_nombre);
            this.Controls.Add(this.cbxPex_Tipo);
            this.Controls.Add(this.lblPex_Tipo);
            this.Controls.Add(this.txtPex_Hoja);
            this.Controls.Add(this.lblHoja);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPex_Nombre);
            this.Controls.Add(this.txtPex_Codigo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmParExcel";
            this.Text = "Parametricas Excel";
            this.Load += new System.EventHandler(this.frmParExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPex_Codigo;
        private System.Windows.Forms.TextBox txtPex_Nombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblHoja;
        private System.Windows.Forms.TextBox txtPex_Hoja;
        private System.Windows.Forms.Label lblPex_Tipo;
        private System.Windows.Forms.ComboBox cbxPex_Tipo;
        private System.Windows.Forms.ComboBox cbxTipoCalculo;
        private System.Windows.Forms.Label lblTca_nombre;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.Label lblProducto;
    }
}