namespace ypfbApplication.View
{
    partial class frmContratoBusqueda
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
          this.chkFecFin = new System.Windows.Forms.CheckBox();
          this.chkFecIni = new System.Windows.Forms.CheckBox();
          this.lblSucursales = new System.Windows.Forms.Label();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.lblFechaFin = new System.Windows.Forms.Label();
          this.btnBuscar = new System.Windows.Forms.Button();
          this.lblCodigo = new System.Windows.Forms.Label();
          this.lblFechaInicio = new System.Windows.Forms.Label();
          this.lblNombre = new System.Windows.Forms.Label();
          this.cboSucursales = new System.Windows.Forms.ComboBox();
          this.lblPeriodo = new System.Windows.Forms.Label();
          this.txtCodigo = new System.Windows.Forms.TextBox();
          this.txtNombre = new System.Windows.Forms.TextBox();
          this.dtpFin = new System.Windows.Forms.DateTimePicker();
          this.txtPeriodo = new System.Windows.Forms.TextBox();
          this.dtpInicio = new System.Windows.Forms.DateTimePicker();
          this.gbCabecera.SuspendLayout();
          this.SuspendLayout();
          // 
          // gbCabecera
          // 
          this.gbCabecera.Controls.Add(this.chkFecFin);
          this.gbCabecera.Controls.Add(this.chkFecIni);
          this.gbCabecera.Controls.Add(this.lblSucursales);
          this.gbCabecera.Controls.Add(this.btnCancelar);
          this.gbCabecera.Controls.Add(this.lblFechaFin);
          this.gbCabecera.Controls.Add(this.btnBuscar);
          this.gbCabecera.Controls.Add(this.lblCodigo);
          this.gbCabecera.Controls.Add(this.lblFechaInicio);
          this.gbCabecera.Controls.Add(this.lblNombre);
          this.gbCabecera.Controls.Add(this.cboSucursales);
          this.gbCabecera.Controls.Add(this.lblPeriodo);
          this.gbCabecera.Controls.Add(this.txtCodigo);
          this.gbCabecera.Controls.Add(this.txtNombre);
          this.gbCabecera.Controls.Add(this.dtpFin);
          this.gbCabecera.Controls.Add(this.txtPeriodo);
          this.gbCabecera.Controls.Add(this.dtpInicio);
          this.gbCabecera.Location = new System.Drawing.Point(57, 12);
          this.gbCabecera.Name = "gbCabecera";
          this.gbCabecera.Size = new System.Drawing.Size(443, 225);
          this.gbCabecera.TabIndex = 0;
          this.gbCabecera.TabStop = false;
          this.gbCabecera.Text = "Opciones de Búsqueda";
          // 
          // chkFecFin
          // 
          this.chkFecFin.AutoSize = true;
          this.chkFecFin.Location = new System.Drawing.Point(218, 160);
          this.chkFecFin.Name = "chkFecFin";
          this.chkFecFin.Size = new System.Drawing.Size(115, 17);
          this.chkFecFin.TabIndex = 16;
          this.chkFecFin.Text = "Habilitar Búsqueda";
          this.chkFecFin.UseVisualStyleBackColor = true;
          this.chkFecFin.CheckedChanged += new System.EventHandler(this.chkFec_Fin_CheckedChanged);
          // 
          // chkFecIni
          // 
          this.chkFecIni.AutoSize = true;
          this.chkFecIni.Location = new System.Drawing.Point(219, 138);
          this.chkFecIni.Name = "chkFecIni";
          this.chkFecIni.Size = new System.Drawing.Size(115, 17);
          this.chkFecIni.TabIndex = 15;
          this.chkFecIni.Text = "Habilitar Búsqueda";
          this.chkFecIni.UseVisualStyleBackColor = true;
          this.chkFecIni.CheckedChanged += new System.EventHandler(this.chkFecIni_CheckedChanged);
          // 
          // lblSucursales
          // 
          this.lblSucursales.AutoSize = true;
          this.lblSucursales.Location = new System.Drawing.Point(21, 32);
          this.lblSucursales.Name = "lblSucursales";
          this.lblSucursales.Size = new System.Drawing.Size(70, 13);
          this.lblSucursales.TabIndex = 0;
          this.lblSucursales.Text = "Por Sucursal:";
          // 
          // btnCancelar
          // 
          this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancelar.Location = new System.Drawing.Point(206, 192);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 8;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // lblFechaFin
          // 
          this.lblFechaFin.AutoSize = true;
          this.lblFechaFin.Location = new System.Drawing.Point(21, 164);
          this.lblFechaFin.Name = "lblFechaFin";
          this.lblFechaFin.Size = new System.Drawing.Size(76, 13);
          this.lblFechaFin.TabIndex = 14;
          this.lblFechaFin.Text = "Por Fecha Fin:";
          // 
          // btnBuscar
          // 
          this.btnBuscar.Location = new System.Drawing.Point(90, 192);
          this.btnBuscar.Name = "btnBuscar";
          this.btnBuscar.Size = new System.Drawing.Size(75, 23);
          this.btnBuscar.TabIndex = 7;
          this.btnBuscar.Text = "&Búsqueda";
          this.btnBuscar.UseVisualStyleBackColor = true;
          this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
          // 
          // lblCodigo
          // 
          this.lblCodigo.AutoSize = true;
          this.lblCodigo.Location = new System.Drawing.Point(21, 59);
          this.lblCodigo.Name = "lblCodigo";
          this.lblCodigo.Size = new System.Drawing.Size(62, 13);
          this.lblCodigo.TabIndex = 1;
          this.lblCodigo.Text = "Por Código:";
          // 
          // lblFechaInicio
          // 
          this.lblFechaInicio.AutoSize = true;
          this.lblFechaInicio.Location = new System.Drawing.Point(21, 138);
          this.lblFechaInicio.Name = "lblFechaInicio";
          this.lblFechaInicio.Size = new System.Drawing.Size(87, 13);
          this.lblFechaInicio.TabIndex = 13;
          this.lblFechaInicio.Text = "Por Fecha Inicio:";
          // 
          // lblNombre
          // 
          this.lblNombre.AutoSize = true;
          this.lblNombre.Location = new System.Drawing.Point(21, 85);
          this.lblNombre.Name = "lblNombre";
          this.lblNombre.Size = new System.Drawing.Size(66, 13);
          this.lblNombre.TabIndex = 2;
          this.lblNombre.Text = "Por Nombre:";
          // 
          // cboSucursales
          // 
          this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cboSucursales.FormattingEnabled = true;
          this.cboSucursales.Location = new System.Drawing.Point(121, 29);
          this.cboSucursales.Name = "cboSucursales";
          this.cboSucursales.Size = new System.Drawing.Size(100, 21);
          this.cboSucursales.TabIndex = 1;
          this.cboSucursales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSucursales_KeyPress);
          // 
          // lblPeriodo
          // 
          this.lblPeriodo.AutoSize = true;
          this.lblPeriodo.Location = new System.Drawing.Point(21, 111);
          this.lblPeriodo.Name = "lblPeriodo";
          this.lblPeriodo.Size = new System.Drawing.Size(65, 13);
          this.lblPeriodo.TabIndex = 3;
          this.lblPeriodo.Text = "Por Periodo:";
          // 
          // txtCodigo
          // 
          this.txtCodigo.Location = new System.Drawing.Point(121, 56);
          this.txtCodigo.MaxLength = 32;
          this.txtCodigo.Name = "txtCodigo";
          this.txtCodigo.Size = new System.Drawing.Size(140, 20);
          this.txtCodigo.TabIndex = 2;
          this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
          // 
          // txtNombre
          // 
          this.txtNombre.Location = new System.Drawing.Point(121, 82);
          this.txtNombre.MaxLength = 256;
          this.txtNombre.Name = "txtNombre";
          this.txtNombre.Size = new System.Drawing.Size(237, 20);
          this.txtNombre.TabIndex = 3;
          this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
          // 
          // dtpFin
          // 
          this.dtpFin.CustomFormat = "dd/MM/yyyy";
          this.dtpFin.Enabled = false;
          this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpFin.Location = new System.Drawing.Point(121, 160);
          this.dtpFin.Name = "dtpFin";
          this.dtpFin.Size = new System.Drawing.Size(91, 20);
          this.dtpFin.TabIndex = 6;
          this.dtpFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFin_KeyPress);
          // 
          // txtPeriodo
          // 
          this.txtPeriodo.Location = new System.Drawing.Point(121, 108);
          this.txtPeriodo.MaxLength = 16;
          this.txtPeriodo.Name = "txtPeriodo";
          this.txtPeriodo.Size = new System.Drawing.Size(111, 20);
          this.txtPeriodo.TabIndex = 4;
          this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
          // 
          // dtpInicio
          // 
          this.dtpInicio.CustomFormat = "dd/MM/yyyy";
          this.dtpInicio.Enabled = false;
          this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpInicio.Location = new System.Drawing.Point(121, 134);
          this.dtpInicio.Name = "dtpInicio";
          this.dtpInicio.Size = new System.Drawing.Size(91, 20);
          this.dtpInicio.TabIndex = 5;
          this.dtpInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpInicio_KeyPress);
          // 
          // frmContratoBusqueda
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.CancelButton = this.btnCancelar;
          this.ClientSize = new System.Drawing.Size(558, 266);
          this.Controls.Add(this.gbCabecera);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmContratoBusqueda";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Búsqueda de Contratos";
          this.Load += new System.EventHandler(this.frmContratoBusqueda_Load);
          this.gbCabecera.ResumeLayout(false);
          this.gbCabecera.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCabecera;
        private System.Windows.Forms.Label lblSucursales;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.CheckBox chkFecIni;
        private System.Windows.Forms.CheckBox chkFecFin;

    }
}