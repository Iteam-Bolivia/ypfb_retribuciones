namespace ypfbApplication.View
{
    partial class frmContrato
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
          this.lblcbofields1 = new System.Windows.Forms.Label();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.lbltxtfields2 = new System.Windows.Forms.Label();
          this.lbltxtfields3 = new System.Windows.Forms.Label();
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.txtfields2 = new System.Windows.Forms.TextBox();
          this.txtfields3 = new System.Windows.Forms.TextBox();
          this.dtpfields1 = new System.Windows.Forms.DateTimePicker();
          this.dtpfields2 = new System.Windows.Forms.DateTimePicker();
          this.btnGuardar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.cbofields1 = new System.Windows.Forms.ComboBox();
          this.lbldtpfields1 = new System.Windows.Forms.Label();
          this.lbldtpfields2 = new System.Windows.Forms.Label();
          this.lblcbofields2 = new System.Windows.Forms.Label();
          this.cbofields2 = new System.Windows.Forms.ComboBox();
          this.lbltxtfields4 = new System.Windows.Forms.Label();
          this.lbltxtfields5 = new System.Windows.Forms.Label();
          this.lbltxtfields6 = new System.Windows.Forms.Label();
          this.lbltxtfields7 = new System.Windows.Forms.Label();
          this.lbltxtfields8 = new System.Windows.Forms.Label();
          this.lbltxtfields9 = new System.Windows.Forms.Label();
          this.txtfields4 = new System.Windows.Forms.TextBox();
          this.txtfields5 = new System.Windows.Forms.TextBox();
          this.txtfields6 = new System.Windows.Forms.TextBox();
          this.txtfields7 = new System.Windows.Forms.TextBox();
          this.txtfields8 = new System.Windows.Forms.TextBox();
          this.txtfields9 = new System.Windows.Forms.TextBox();
          this.txtfields14 = new System.Windows.Forms.TextBox();
          this.txtfields13 = new System.Windows.Forms.TextBox();
          this.txtfields12 = new System.Windows.Forms.TextBox();
          this.txtfields11 = new System.Windows.Forms.TextBox();
          this.txtfields10 = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this.txtfields15 = new System.Windows.Forms.TextBox();
          this.label6 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.cbxProduccion = new System.Windows.Forms.ComboBox();
          this.txtcostrecuacu = new System.Windows.Forms.TextBox();
          this.label8 = new System.Windows.Forms.Label();
          this.txtorden = new System.Windows.Forms.TextBox();
          this.label9 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // lblcbofields1
          // 
          this.lblcbofields1.AutoSize = true;
          this.lblcbofields1.Location = new System.Drawing.Point(44, 16);
          this.lblcbofields1.Name = "lblcbofields1";
          this.lblcbofields1.Size = new System.Drawing.Size(51, 13);
          this.lblcbofields1.TabIndex = 0;
          this.lblcbofields1.Text = "Sucursal:";
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(44, 43);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
          this.lbltxtfields1.TabIndex = 1;
          this.lbltxtfields1.Text = "Código:";
          // 
          // lbltxtfields2
          // 
          this.lbltxtfields2.AutoSize = true;
          this.lbltxtfields2.Location = new System.Drawing.Point(44, 69);
          this.lbltxtfields2.Name = "lbltxtfields2";
          this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
          this.lbltxtfields2.TabIndex = 2;
          this.lbltxtfields2.Text = "Nombre:";
          // 
          // lbltxtfields3
          // 
          this.lbltxtfields3.AutoSize = true;
          this.lbltxtfields3.Location = new System.Drawing.Point(44, 95);
          this.lbltxtfields3.Name = "lbltxtfields3";
          this.lbltxtfields3.Size = new System.Drawing.Size(46, 13);
          this.lbltxtfields3.TabIndex = 3;
          this.lbltxtfields3.Text = "Periodo:";
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(232, 40);
          this.txtfields1.MaxLength = 32;
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(237, 20);
          this.txtfields1.TabIndex = 1;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
          // 
          // txtfields2
          // 
          this.txtfields2.Location = new System.Drawing.Point(232, 66);
          this.txtfields2.MaxLength = 256;
          this.txtfields2.Name = "txtfields2";
          this.txtfields2.Size = new System.Drawing.Size(237, 20);
          this.txtfields2.TabIndex = 2;
          this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
          // 
          // txtfields3
          // 
          this.txtfields3.Location = new System.Drawing.Point(232, 92);
          this.txtfields3.MaxLength = 16;
          this.txtfields3.Name = "txtfields3";
          this.txtfields3.Size = new System.Drawing.Size(100, 20);
          this.txtfields3.TabIndex = 3;
          this.txtfields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
          // 
          // dtpfields1
          // 
          this.dtpfields1.CustomFormat = "dd/MM/yyyy";
          this.dtpfields1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpfields1.Location = new System.Drawing.Point(232, 118);
          this.dtpfields1.Name = "dtpfields1";
          this.dtpfields1.Size = new System.Drawing.Size(100, 20);
          this.dtpfields1.TabIndex = 4;
          this.dtpfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpInicio_KeyPress);
          // 
          // dtpfields2
          // 
          this.dtpfields2.CustomFormat = "dd/MM/yyyy";
          this.dtpfields2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpfields2.Location = new System.Drawing.Point(232, 144);
          this.dtpfields2.Name = "dtpfields2";
          this.dtpfields2.Size = new System.Drawing.Size(100, 20);
          this.dtpfields2.TabIndex = 5;
          this.dtpfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFin_KeyPress);
          // 
          // btnGuardar
          // 
          this.btnGuardar.Location = new System.Drawing.Point(229, 433);
          this.btnGuardar.Name = "btnGuardar";
          this.btnGuardar.Size = new System.Drawing.Size(75, 23);
          this.btnGuardar.TabIndex = 19;
          this.btnGuardar.Text = "&Guardar";
          this.btnGuardar.UseVisualStyleBackColor = true;
          this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancelar.Location = new System.Drawing.Point(385, 433);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 20;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // cbofields1
          // 
          this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields1.FormattingEnabled = true;
          this.cbofields1.Location = new System.Drawing.Point(232, 13);
          this.cbofields1.Name = "cbofields1";
          this.cbofields1.Size = new System.Drawing.Size(100, 21);
          this.cbofields1.TabIndex = 0;
          this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSucursales_KeyPress);
          // 
          // lbldtpfields1
          // 
          this.lbldtpfields1.AutoSize = true;
          this.lbldtpfields1.Location = new System.Drawing.Point(44, 122);
          this.lbldtpfields1.Name = "lbldtpfields1";
          this.lbldtpfields1.Size = new System.Drawing.Size(68, 13);
          this.lbldtpfields1.TabIndex = 13;
          this.lbldtpfields1.Text = "Fecha Inicio:";
          // 
          // lbldtpfields2
          // 
          this.lbldtpfields2.AutoSize = true;
          this.lbldtpfields2.Location = new System.Drawing.Point(44, 148);
          this.lbldtpfields2.Name = "lbldtpfields2";
          this.lbldtpfields2.Size = new System.Drawing.Size(57, 13);
          this.lbldtpfields2.TabIndex = 14;
          this.lbldtpfields2.Text = "Fecha Fin:";
          // 
          // lblcbofields2
          // 
          this.lblcbofields2.AutoSize = true;
          this.lblcbofields2.Location = new System.Drawing.Point(45, 399);
          this.lblcbofields2.Name = "lblcbofields2";
          this.lblcbofields2.Size = new System.Drawing.Size(46, 13);
          this.lblcbofields2.TabIndex = 16;
          this.lblcbofields2.Text = "Usuario:";
          // 
          // cbofields2
          // 
          this.cbofields2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields2.FormattingEnabled = true;
          this.cbofields2.Location = new System.Drawing.Point(229, 396);
          this.cbofields2.Name = "cbofields2";
          this.cbofields2.Size = new System.Drawing.Size(237, 21);
          this.cbofields2.TabIndex = 18;
          // 
          // lbltxtfields4
          // 
          this.lbltxtfields4.AutoSize = true;
          this.lbltxtfields4.Location = new System.Drawing.Point(45, 173);
          this.lbltxtfields4.Name = "lbltxtfields4";
          this.lbltxtfields4.Size = new System.Drawing.Size(128, 13);
          this.lbltxtfields4.TabIndex = 17;
          this.lbltxtfields4.Text = "Depreciación acumulada:";
          // 
          // lbltxtfields5
          // 
          this.lbltxtfields5.AutoSize = true;
          this.lbltxtfields5.Location = new System.Drawing.Point(44, 199);
          this.lbltxtfields5.Name = "lbltxtfields5";
          this.lbltxtfields5.Size = new System.Drawing.Size(188, 13);
          this.lbltxtfields5.TabIndex = 18;
          this.lbltxtfields5.Text = "Depreciación acumulada mes anterior:";
          // 
          // lbltxtfields6
          // 
          this.lbltxtfields6.AutoSize = true;
          this.lbltxtfields6.Location = new System.Drawing.Point(45, 222);
          this.lbltxtfields6.Name = "lbltxtfields6";
          this.lbltxtfields6.Size = new System.Drawing.Size(111, 13);
          this.lbltxtfields6.TabIndex = 19;
          this.lbltxtfields6.Text = "Ganancia acumulada:";
          // 
          // lbltxtfields7
          // 
          this.lbltxtfields7.AutoSize = true;
          this.lbltxtfields7.Location = new System.Drawing.Point(45, 251);
          this.lbltxtfields7.Name = "lbltxtfields7";
          this.lbltxtfields7.Size = new System.Drawing.Size(108, 13);
          this.lbltxtfields7.TabIndex = 20;
          this.lbltxtfields7.Text = "Inversión acumulada:";
          // 
          // lbltxtfields8
          // 
          this.lbltxtfields8.AutoSize = true;
          this.lbltxtfields8.Location = new System.Drawing.Point(44, 277);
          this.lbltxtfields8.Name = "lbltxtfields8";
          this.lbltxtfields8.Size = new System.Drawing.Size(168, 13);
          this.lbltxtfields8.TabIndex = 21;
          this.lbltxtfields8.Text = "Inversión acumulada mes anterior:";
          // 
          // lbltxtfields9
          // 
          this.lbltxtfields9.AutoSize = true;
          this.lbltxtfields9.Location = new System.Drawing.Point(44, 303);
          this.lbltxtfields9.Name = "lbltxtfields9";
          this.lbltxtfields9.Size = new System.Drawing.Size(108, 13);
          this.lbltxtfields9.TabIndex = 22;
          this.lbltxtfields9.Text = "Impuesto acumulado:";
          // 
          // txtfields4
          // 
          this.txtfields4.Location = new System.Drawing.Point(232, 170);
          this.txtfields4.Name = "txtfields4";
          this.txtfields4.Size = new System.Drawing.Size(100, 20);
          this.txtfields4.TabIndex = 6;
          this.txtfields4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields4_KeyPress);
          // 
          // txtfields5
          // 
          this.txtfields5.Location = new System.Drawing.Point(232, 196);
          this.txtfields5.Name = "txtfields5";
          this.txtfields5.Size = new System.Drawing.Size(100, 20);
          this.txtfields5.TabIndex = 7;
          this.txtfields5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields5_KeyPress);
          // 
          // txtfields6
          // 
          this.txtfields6.Location = new System.Drawing.Point(232, 222);
          this.txtfields6.Name = "txtfields6";
          this.txtfields6.Size = new System.Drawing.Size(100, 20);
          this.txtfields6.TabIndex = 8;
          this.txtfields6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields6_KeyPress);
          // 
          // txtfields7
          // 
          this.txtfields7.Location = new System.Drawing.Point(232, 248);
          this.txtfields7.Name = "txtfields7";
          this.txtfields7.Size = new System.Drawing.Size(100, 20);
          this.txtfields7.TabIndex = 9;
          this.txtfields7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields7_KeyPress);
          // 
          // txtfields8
          // 
          this.txtfields8.Location = new System.Drawing.Point(232, 274);
          this.txtfields8.Name = "txtfields8";
          this.txtfields8.Size = new System.Drawing.Size(100, 20);
          this.txtfields8.TabIndex = 10;
          this.txtfields8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields8_KeyPress);
          // 
          // txtfields9
          // 
          this.txtfields9.Location = new System.Drawing.Point(232, 300);
          this.txtfields9.Name = "txtfields9";
          this.txtfields9.Size = new System.Drawing.Size(100, 20);
          this.txtfields9.TabIndex = 11;
          this.txtfields9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields9_KeyPress);
          // 
          // txtfields14
          // 
          this.txtfields14.Location = new System.Drawing.Point(595, 308);
          this.txtfields14.Name = "txtfields14";
          this.txtfields14.Size = new System.Drawing.Size(143, 20);
          this.txtfields14.TabIndex = 16;
          // 
          // txtfields13
          // 
          this.txtfields13.Location = new System.Drawing.Point(595, 282);
          this.txtfields13.Name = "txtfields13";
          this.txtfields13.Size = new System.Drawing.Size(143, 20);
          this.txtfields13.TabIndex = 15;
          // 
          // txtfields12
          // 
          this.txtfields12.Location = new System.Drawing.Point(595, 256);
          this.txtfields12.Name = "txtfields12";
          this.txtfields12.Size = new System.Drawing.Size(143, 20);
          this.txtfields12.TabIndex = 14;
          // 
          // txtfields11
          // 
          this.txtfields11.Location = new System.Drawing.Point(595, 230);
          this.txtfields11.Name = "txtfields11";
          this.txtfields11.Size = new System.Drawing.Size(143, 20);
          this.txtfields11.TabIndex = 13;
          // 
          // txtfields10
          // 
          this.txtfields10.Location = new System.Drawing.Point(595, 204);
          this.txtfields10.Name = "txtfields10";
          this.txtfields10.Size = new System.Drawing.Size(143, 20);
          this.txtfields10.TabIndex = 12;
          // 
          // label1
          // 
          this.label1.Location = new System.Drawing.Point(356, 311);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(233, 26);
          this.label1.TabIndex = 32;
          this.label1.Text = "Precio Promedio ponderado de venta de Gas Natural en pto. de Fiscalización:";
          // 
          // label2
          // 
          this.label2.Location = new System.Drawing.Point(356, 280);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(233, 26);
          this.label2.TabIndex = 31;
          this.label2.Text = "Incentivo a campos petrolíferos marginales a pequeños:";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(356, 259);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(150, 13);
          this.label3.TabIndex = 30;
          this.label3.Text = "Campo marginal a/o pequeño:";
          // 
          // label4
          // 
          this.label4.Location = new System.Drawing.Point(356, 230);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(233, 29);
          this.label4.TabIndex = 29;
          this.label4.Text = "Valor de los Hidrocarburos del Insumo que exceden nivel autorizado por MHE:";
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(356, 207);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(31, 13);
          this.label5.TabIndex = 28;
          this.label5.Text = "LRC:";
          // 
          // txtfields15
          // 
          this.txtfields15.Location = new System.Drawing.Point(595, 334);
          this.txtfields15.Name = "txtfields15";
          this.txtfields15.Size = new System.Drawing.Size(143, 20);
          this.txtfields15.TabIndex = 17;
          // 
          // label6
          // 
          this.label6.Location = new System.Drawing.Point(356, 337);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(238, 32);
          this.label6.TabIndex = 34;
          this.label6.Text = "Precio Promedio ponderado de venta de Hidrocarburos Líquidos en pto. de Fiscaliza" +
              "ción:";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(356, 176);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(64, 13);
          this.label7.TabIndex = 35;
          this.label7.Text = "Producción:";
          // 
          // cbxProduccion
          // 
          this.cbxProduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxProduccion.FormattingEnabled = true;
          this.cbxProduccion.Items.AddRange(new object[] {
            "Ninguno",
            "Producción Gas",
            "Producción Crudo"});
          this.cbxProduccion.Location = new System.Drawing.Point(595, 173);
          this.cbxProduccion.Name = "cbxProduccion";
          this.cbxProduccion.Size = new System.Drawing.Size(143, 21);
          this.cbxProduccion.TabIndex = 36;
          // 
          // txtcostrecuacu
          // 
          this.txtcostrecuacu.Location = new System.Drawing.Point(232, 326);
          this.txtcostrecuacu.Name = "txtcostrecuacu";
          this.txtcostrecuacu.Size = new System.Drawing.Size(100, 20);
          this.txtcostrecuacu.TabIndex = 37;
          // 
          // label8
          // 
          this.label8.Location = new System.Drawing.Point(44, 329);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(182, 40);
          this.label8.TabIndex = 38;
          this.label8.Text = "Costo recuperable pendiente a recuperar del mes anterior:";
          // 
          // txtorden
          // 
          this.txtorden.Location = new System.Drawing.Point(232, 368);
          this.txtorden.Name = "txtorden";
          this.txtorden.Size = new System.Drawing.Size(100, 20);
          this.txtorden.TabIndex = 39;
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Location = new System.Drawing.Point(49, 375);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(39, 13);
          this.label9.TabIndex = 40;
          this.label9.Text = "Orden:";
          // 
          // frmContrato
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.CancelButton = this.btnCancelar;
          this.ClientSize = new System.Drawing.Size(750, 484);
          this.Controls.Add(this.label9);
          this.Controls.Add(this.txtorden);
          this.Controls.Add(this.txtcostrecuacu);
          this.Controls.Add(this.label8);
          this.Controls.Add(this.cbxProduccion);
          this.Controls.Add(this.label7);
          this.Controls.Add(this.txtfields15);
          this.Controls.Add(this.label6);
          this.Controls.Add(this.txtfields14);
          this.Controls.Add(this.txtfields13);
          this.Controls.Add(this.txtfields12);
          this.Controls.Add(this.txtfields11);
          this.Controls.Add(this.txtfields10);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.txtfields9);
          this.Controls.Add(this.txtfields8);
          this.Controls.Add(this.txtfields7);
          this.Controls.Add(this.txtfields6);
          this.Controls.Add(this.txtfields5);
          this.Controls.Add(this.txtfields4);
          this.Controls.Add(this.lbltxtfields9);
          this.Controls.Add(this.lbltxtfields8);
          this.Controls.Add(this.lbltxtfields7);
          this.Controls.Add(this.lbltxtfields6);
          this.Controls.Add(this.lbltxtfields5);
          this.Controls.Add(this.lbltxtfields4);
          this.Controls.Add(this.lblcbofields2);
          this.Controls.Add(this.cbofields2);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.lblcbofields1);
          this.Controls.Add(this.lbldtpfields2);
          this.Controls.Add(this.btnGuardar);
          this.Controls.Add(this.lbltxtfields1);
          this.Controls.Add(this.dtpfields1);
          this.Controls.Add(this.lbldtpfields1);
          this.Controls.Add(this.txtfields3);
          this.Controls.Add(this.lbltxtfields2);
          this.Controls.Add(this.dtpfields2);
          this.Controls.Add(this.cbofields1);
          this.Controls.Add(this.txtfields2);
          this.Controls.Add(this.lbltxtfields3);
          this.Controls.Add(this.txtfields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmContrato";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Contrato - Agregar - Editar";
          this.Load += new System.EventHandler(this.frmContrato_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.Label lbltxtfields1;
        private System.Windows.Forms.Label lbltxtfields2;
        private System.Windows.Forms.Label lbltxtfields3;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.TextBox txtfields2;
        private System.Windows.Forms.TextBox txtfields3;
        private System.Windows.Forms.DateTimePicker dtpfields1;
        private System.Windows.Forms.DateTimePicker dtpfields2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Label lbldtpfields1;
        private System.Windows.Forms.Label lbldtpfields2;
        private System.Windows.Forms.Label lblcbofields2;
        private System.Windows.Forms.ComboBox cbofields2;
        private System.Windows.Forms.Label lbltxtfields4;
        private System.Windows.Forms.Label lbltxtfields5;
        private System.Windows.Forms.Label lbltxtfields6;
        private System.Windows.Forms.Label lbltxtfields7;
        private System.Windows.Forms.Label lbltxtfields8;
        private System.Windows.Forms.Label lbltxtfields9;
        private System.Windows.Forms.TextBox txtfields4;
        private System.Windows.Forms.TextBox txtfields5;
        private System.Windows.Forms.TextBox txtfields6;
        private System.Windows.Forms.TextBox txtfields7;
        private System.Windows.Forms.TextBox txtfields8;
        private System.Windows.Forms.TextBox txtfields9;
        private System.Windows.Forms.TextBox txtfields14;
        private System.Windows.Forms.TextBox txtfields13;
        private System.Windows.Forms.TextBox txtfields12;
        private System.Windows.Forms.TextBox txtfields11;
        private System.Windows.Forms.TextBox txtfields10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfields15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxProduccion;
        private System.Windows.Forms.TextBox txtcostrecuacu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtorden;
        private System.Windows.Forms.Label label9;
    }
}