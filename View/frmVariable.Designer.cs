namespace ypfbApplication.View
{
  partial class frmVariable
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVariable));
        this.btnGuardar = new System.Windows.Forms.Button();
        this.txtfields3 = new System.Windows.Forms.TextBox();
        this.txtfields2 = new System.Windows.Forms.TextBox();
        this.txtfields1 = new System.Windows.Forms.TextBox();
        this.lbltxtfields3 = new System.Windows.Forms.Label();
        this.lbltxtfields2 = new System.Windows.Forms.Label();
        this.lbltxtfields1 = new System.Windows.Forms.Label();
        this.cbofields1 = new System.Windows.Forms.ComboBox();
        this.label1 = new System.Windows.Forms.Label();
        this.txtfields4 = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.cbofields2 = new System.Windows.Forms.ComboBox();
        this.label3 = new System.Windows.Forms.Label();
        this.cbofields3 = new System.Windows.Forms.ComboBox();
        this.imgButtons = new System.Windows.Forms.ImageList(this.components);
        this.cmdCancelar = new System.Windows.Forms.Button();
        this.txtfields5 = new System.Windows.Forms.TextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.cbofields4 = new System.Windows.Forms.ComboBox();
        this.label7 = new System.Windows.Forms.Label();
        this.txtfields6 = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.cbofields5 = new System.Windows.Forms.ComboBox();
        this.label10 = new System.Windows.Forms.Label();
        this.cbofields6 = new System.Windows.Forms.ComboBox();
        this.label11 = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.cbofields7 = new System.Windows.Forms.ComboBox();
        this.label13 = new System.Windows.Forms.Label();
        this.cbofields8 = new System.Windows.Forms.ComboBox();
        this.cbofields9 = new System.Windows.Forms.ComboBox();
        this.label14 = new System.Windows.Forms.Label();
        this.cbofields10 = new System.Windows.Forms.ComboBox();
        this.label15 = new System.Windows.Forms.Label();
        this.cbxCuadro = new System.Windows.Forms.ComboBox();
        this.label16 = new System.Windows.Forms.Label();
        this.cbxTipoCalculo = new System.Windows.Forms.ComboBox();
        this.label17 = new System.Windows.Forms.Label();
        this.cboCampo = new System.Windows.Forms.ComboBox();
        this.txtVar_m = new System.Windows.Forms.TextBox();
        this.txtVar_cam = new System.Windows.Forms.TextBox();
        this.txtFor_m = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnGuardar
        // 
        this.btnGuardar.Location = new System.Drawing.Point(244, 399);
        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Size = new System.Drawing.Size(89, 27);
        this.btnGuardar.TabIndex = 17;
        this.btnGuardar.Text = "&Guardar";
        this.btnGuardar.UseVisualStyleBackColor = true;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        // 
        // txtfields3
        // 
        this.txtfields3.Location = new System.Drawing.Point(495, 174);
        this.txtfields3.Name = "txtfields3";
        this.txtfields3.Size = new System.Drawing.Size(200, 20);
        this.txtfields3.TabIndex = 11;
        this.txtfields3.Text = "0.00";
        this.txtfields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields3_KeyPress);
        // 
        // txtfields2
        // 
        this.txtfields2.Location = new System.Drawing.Point(127, 358);
        this.txtfields2.Multiline = true;
        this.txtfields2.Name = "txtfields2";
        this.txtfields2.Size = new System.Drawing.Size(568, 20);
        this.txtfields2.TabIndex = 16;
        this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
        // 
        // txtfields1
        // 
        this.txtfields1.Location = new System.Drawing.Point(127, 64);
        this.txtfields1.Name = "txtfields1";
        this.txtfields1.Size = new System.Drawing.Size(200, 20);
        this.txtfields1.TabIndex = 3;
        this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
        // 
        // lbltxtfields3
        // 
        this.lbltxtfields3.AutoSize = true;
        this.lbltxtfields3.Location = new System.Drawing.Point(380, 174);
        this.lbltxtfields3.Name = "lbltxtfields3";
        this.lbltxtfields3.Size = new System.Drawing.Size(64, 13);
        this.lbltxtfields3.TabIndex = 4;
        this.lbltxtfields3.Text = "Valor Inicial:";
        // 
        // lbltxtfields2
        // 
        this.lbltxtfields2.AutoSize = true;
        this.lbltxtfields2.Location = new System.Drawing.Point(19, 145);
        this.lbltxtfields2.Name = "lbltxtfields2";
        this.lbltxtfields2.Size = new System.Drawing.Size(66, 13);
        this.lbltxtfields2.TabIndex = 3;
        this.lbltxtfields2.Text = "Descripción:";
        // 
        // lbltxtfields1
        // 
        this.lbltxtfields1.AutoSize = true;
        this.lbltxtfields1.Location = new System.Drawing.Point(19, 64);
        this.lbltxtfields1.Name = "lbltxtfields1";
        this.lbltxtfields1.Size = new System.Drawing.Size(48, 13);
        this.lbltxtfields1.TabIndex = 0;
        this.lbltxtfields1.Text = "Variable:";
        // 
        // cbofields1
        // 
        this.cbofields1.Enabled = false;
        this.cbofields1.FormattingEnabled = true;
        this.cbofields1.Location = new System.Drawing.Point(495, 91);
        this.cbofields1.Name = "cbofields1";
        this.cbofields1.Size = new System.Drawing.Size(200, 21);
        this.cbofields1.TabIndex = 6;
        this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields1_KeyPress);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(380, 91);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(47, 13);
        this.label1.TabIndex = 13;
        this.label1.Text = "Formula:";
        // 
        // txtfields4
        // 
        this.txtfields4.Location = new System.Drawing.Point(127, 39);
        this.txtfields4.Name = "txtfields4";
        this.txtfields4.Size = new System.Drawing.Size(200, 20);
        this.txtfields4.TabIndex = 2;
        this.txtfields4.Text = "0";
        this.txtfields4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields4_KeyPress);
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(19, 42);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(96, 13);
        this.label2.TabIndex = 15;
        this.label2.Text = "Orden de Proceso:";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(380, 64);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(97, 13);
        this.label4.TabIndex = 17;
        this.label4.Text = "Unidad de Medida:";
        // 
        // cbofields2
        // 
        this.cbofields2.FormattingEnabled = true;
        this.cbofields2.Location = new System.Drawing.Point(495, 64);
        this.cbofields2.Name = "cbofields2";
        this.cbofields2.Size = new System.Drawing.Size(200, 21);
        this.cbofields2.TabIndex = 4;
        this.cbofields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields2_KeyPress);
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(19, 14);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(102, 13);
        this.label3.TabIndex = 19;
        this.label3.Text = "Proceso de Cálculo:";
        // 
        // cbofields3
        // 
        this.cbofields3.FormattingEnabled = true;
        this.cbofields3.Location = new System.Drawing.Point(127, 12);
        this.cbofields3.Name = "cbofields3";
        this.cbofields3.Size = new System.Drawing.Size(200, 21);
        this.cbofields3.TabIndex = 1;
        this.cbofields3.SelectedIndexChanged += new System.EventHandler(this.cbofields3_SelectedIndexChanged);
        this.cbofields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields3_KeyPress);
        // 
        // imgButtons
        // 
        this.imgButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgButtons.ImageStream")));
        this.imgButtons.TransparentColor = System.Drawing.Color.Transparent;
        this.imgButtons.Images.SetKeyName(0, "add.gif");
        this.imgButtons.Images.SetKeyName(1, "delete.gif");
        this.imgButtons.Images.SetKeyName(2, "doc.gif");
        this.imgButtons.Images.SetKeyName(3, "table_refresh.png");
        this.imgButtons.Images.SetKeyName(4, "search.png");
        this.imgButtons.Images.SetKeyName(5, "print.png");
        this.imgButtons.Images.SetKeyName(6, "salir.png");
        this.imgButtons.Images.SetKeyName(7, "edit.gif");
        this.imgButtons.Images.SetKeyName(8, "user_add.png");
        this.imgButtons.Images.SetKeyName(9, "user_delete.png");
        this.imgButtons.Images.SetKeyName(10, "coins_add.png");
        this.imgButtons.Images.SetKeyName(11, "coins_delete.png");
        this.imgButtons.Images.SetKeyName(12, "b_view.png");
        this.imgButtons.Images.SetKeyName(13, "pdf.png");
        this.imgButtons.Images.SetKeyName(14, "b_edit.png");
        this.imgButtons.Images.SetKeyName(15, "load.png");
        this.imgButtons.Images.SetKeyName(16, "table_refresh.png");
        this.imgButtons.Images.SetKeyName(17, "derivar.png");
        // 
        // cmdCancelar
        // 
        this.cmdCancelar.Location = new System.Drawing.Point(403, 399);
        this.cmdCancelar.Name = "cmdCancelar";
        this.cmdCancelar.Size = new System.Drawing.Size(89, 27);
        this.cmdCancelar.TabIndex = 18;
        this.cmdCancelar.Text = "&Cancelar";
        this.cmdCancelar.UseVisualStyleBackColor = true;
        this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
        // 
        // txtfields5
        // 
        this.txtfields5.Location = new System.Drawing.Point(495, 303);
        this.txtfields5.Name = "txtfields5";
        this.txtfields5.Size = new System.Drawing.Size(200, 20);
        this.txtfields5.TabIndex = 15;
        this.txtfields5.Text = "0";
        this.txtfields5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields5_KeyPress);
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(380, 305);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(87, 13);
        this.label5.TabIndex = 23;
        this.label5.Text = "Orden Impresión:";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(19, 276);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(86, 13);
        this.label6.TabIndex = 24;
        this.label6.Text = "Imprimir Variable:";
        // 
        // cbofields4
        // 
        this.cbofields4.FormattingEnabled = true;
        this.cbofields4.Location = new System.Drawing.Point(127, 276);
        this.cbofields4.Name = "cbofields4";
        this.cbofields4.Size = new System.Drawing.Size(200, 21);
        this.cbofields4.TabIndex = 13;
        this.cbofields4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields4_KeyPress);
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(19, 358);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(85, 13);
        this.label7.TabIndex = 26;
        this.label7.Text = "Texto Impresión:";
        // 
        // txtfields6
        // 
        this.txtfields6.Location = new System.Drawing.Point(127, 145);
        this.txtfields6.Multiline = true;
        this.txtfields6.Name = "txtfields6";
        this.txtfields6.Size = new System.Drawing.Size(568, 20);
        this.txtfields6.TabIndex = 9;
        this.txtfields6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields6_KeyPress);
        // 
        // label8
        // 
        this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.label8.Location = new System.Drawing.Point(11, 257);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(700, 131);
        this.label8.TabIndex = 28;
        this.label8.Text = "Parámetros de impresión";
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(19, 118);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(53, 13);
        this.label9.TabIndex = 30;
        this.label9.Text = "Producto:";
        // 
        // cbofields5
        // 
        this.cbofields5.FormattingEnabled = true;
        this.cbofields5.Location = new System.Drawing.Point(127, 118);
        this.cbofields5.Name = "cbofields5";
        this.cbofields5.Size = new System.Drawing.Size(200, 21);
        this.cbofields5.TabIndex = 7;
        this.cbofields5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields5_KeyPress);
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(380, 118);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(52, 13);
        this.label10.TabIndex = 32;
        this.label10.Text = "Mercado:";
        // 
        // cbofields6
        // 
        this.cbofields6.FormattingEnabled = true;
        this.cbofields6.Location = new System.Drawing.Point(495, 118);
        this.cbofields6.Name = "cbofields6";
        this.cbofields6.Size = new System.Drawing.Size(200, 21);
        this.cbofields6.TabIndex = 8;
        this.cbofields6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields6_KeyPress);
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(19, 200);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(102, 13);
        this.label11.TabIndex = 34;
        this.label11.Text = "Tipo de Proyección:";
        // 
        // label12
        // 
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(19, 94);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(69, 13);
        this.label12.TabIndex = 36;
        this.label12.Text = "Depende de:";
        // 
        // cbofields7
        // 
        this.cbofields7.FormattingEnabled = true;
        this.cbofields7.Location = new System.Drawing.Point(127, 303);
        this.cbofields7.Name = "cbofields7";
        this.cbofields7.Size = new System.Drawing.Size(200, 21);
        this.cbofields7.TabIndex = 14;
        this.cbofields7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields7_KeyPress);
        // 
        // label13
        // 
        this.label13.AutoSize = true;
        this.label13.Location = new System.Drawing.Point(19, 174);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(78, 13);
        this.label13.TabIndex = 38;
        this.label13.Text = "Total/Subtotal:";
        // 
        // cbofields8
        // 
        this.cbofields8.FormattingEnabled = true;
        this.cbofields8.Location = new System.Drawing.Point(127, 171);
        this.cbofields8.Name = "cbofields8";
        this.cbofields8.Size = new System.Drawing.Size(200, 21);
        this.cbofields8.TabIndex = 10;
        this.cbofields8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields8_KeyPress);
        // 
        // cbofields9
        // 
        this.cbofields9.FormattingEnabled = true;
        this.cbofields9.Location = new System.Drawing.Point(127, 200);
        this.cbofields9.Name = "cbofields9";
        this.cbofields9.Size = new System.Drawing.Size(200, 21);
        this.cbofields9.TabIndex = 12;
        this.cbofields9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields9_KeyPress);
        // 
        // label14
        // 
        this.label14.AutoSize = true;
        this.label14.Location = new System.Drawing.Point(19, 303);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(86, 13);
        this.label14.TabIndex = 41;
        this.label14.Text = "Línea Impresión:";
        // 
        // cbofields10
        // 
        this.cbofields10.FormattingEnabled = true;
        this.cbofields10.Location = new System.Drawing.Point(127, 91);
        this.cbofields10.Name = "cbofields10";
        this.cbofields10.Size = new System.Drawing.Size(200, 21);
        this.cbofields10.TabIndex = 5;
        this.cbofields10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields10_KeyPress);
        // 
        // label15
        // 
        this.label15.AutoSize = true;
        this.label15.Location = new System.Drawing.Point(19, 330);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(107, 13);
        this.label15.TabIndex = 43;
        this.label15.Text = "Cuadro de Impresión:";
        // 
        // cbxCuadro
        // 
        this.cbxCuadro.FormattingEnabled = true;
        this.cbxCuadro.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
        this.cbxCuadro.Location = new System.Drawing.Point(127, 330);
        this.cbxCuadro.Name = "cbxCuadro";
        this.cbxCuadro.Size = new System.Drawing.Size(200, 21);
        this.cbxCuadro.TabIndex = 42;
        // 
        // label16
        // 
        this.label16.AutoSize = true;
        this.label16.Location = new System.Drawing.Point(380, 329);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(83, 13);
        this.label16.TabIndex = 45;
        this.label16.Text = "Tipo de calculo:";
        // 
        // cbxTipoCalculo
        // 
        this.cbxTipoCalculo.FormattingEnabled = true;
        this.cbxTipoCalculo.Items.AddRange(new object[] {
            "Lista la variable",
            "Lista la formula y guarda 1 vez",
            "Guarda 1 vez",
            "Lista la variabler y guarda 1 vez"});
        this.cbxTipoCalculo.Location = new System.Drawing.Point(495, 329);
        this.cbxTipoCalculo.Name = "cbxTipoCalculo";
        this.cbxTipoCalculo.Size = new System.Drawing.Size(200, 21);
        this.cbxTipoCalculo.TabIndex = 44;
        // 
        // label17
        // 
        this.label17.AutoSize = true;
        this.label17.Location = new System.Drawing.Point(387, 200);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(43, 13);
        this.label17.TabIndex = 48;
        this.label17.Text = "Campo:";
        // 
        // cboCampo
        // 
        this.cboCampo.FormattingEnabled = true;
        this.cboCampo.Location = new System.Drawing.Point(495, 200);
        this.cboCampo.Name = "cboCampo";
        this.cboCampo.Size = new System.Drawing.Size(200, 21);
        this.cboCampo.TabIndex = 47;
        // 
        // txtVar_m
        // 
        this.txtVar_m.Location = new System.Drawing.Point(358, 12);
        this.txtVar_m.Name = "txtVar_m";
        this.txtVar_m.Size = new System.Drawing.Size(100, 20);
        this.txtVar_m.TabIndex = 49;
        this.txtVar_m.Visible = false;
        // 
        // txtVar_cam
        // 
        this.txtVar_cam.Location = new System.Drawing.Point(464, 11);
        this.txtVar_cam.Name = "txtVar_cam";
        this.txtVar_cam.Size = new System.Drawing.Size(100, 20);
        this.txtVar_cam.TabIndex = 50;
        this.txtVar_cam.Visible = false;
        // 
        // txtFor_m
        // 
        this.txtFor_m.Location = new System.Drawing.Point(585, 14);
        this.txtFor_m.Name = "txtFor_m";
        this.txtFor_m.Size = new System.Drawing.Size(100, 20);
        this.txtFor_m.TabIndex = 51;
        this.txtFor_m.Visible = false;
        // 
        // frmVariable
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.AliceBlue;
        this.ClientSize = new System.Drawing.Size(729, 433);
        this.Controls.Add(this.txtFor_m);
        this.Controls.Add(this.txtVar_cam);
        this.Controls.Add(this.txtVar_m);
        this.Controls.Add(this.label17);
        this.Controls.Add(this.cboCampo);
        this.Controls.Add(this.label16);
        this.Controls.Add(this.cbxTipoCalculo);
        this.Controls.Add(this.label15);
        this.Controls.Add(this.cbxCuadro);
        this.Controls.Add(this.cbofields10);
        this.Controls.Add(this.label14);
        this.Controls.Add(this.cbofields9);
        this.Controls.Add(this.cbofields8);
        this.Controls.Add(this.label13);
        this.Controls.Add(this.cbofields7);
        this.Controls.Add(this.label12);
        this.Controls.Add(this.label11);
        this.Controls.Add(this.label10);
        this.Controls.Add(this.cbofields6);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.cbofields5);
        this.Controls.Add(this.cbofields4);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.txtfields5);
        this.Controls.Add(this.cbofields3);
        this.Controls.Add(this.txtfields6);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.cmdCancelar);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.cbofields2);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.txtfields4);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.cbofields1);
        this.Controls.Add(this.btnGuardar);
        this.Controls.Add(this.txtfields3);
        this.Controls.Add(this.txtfields2);
        this.Controls.Add(this.txtfields1);
        this.Controls.Add(this.lbltxtfields1);
        this.Controls.Add(this.lbltxtfields2);
        this.Controls.Add(this.lbltxtfields3);
        this.Controls.Add(this.label8);
        this.Name = "frmVariable";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "VARIABLE";
        this.Load += new System.EventHandler(this.frmVariable_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtfields3;
    private System.Windows.Forms.TextBox txtfields2;
    private System.Windows.Forms.TextBox txtfields1;
    private System.Windows.Forms.Label lbltxtfields3;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.Label lbltxtfields1;
    private System.Windows.Forms.ComboBox cbofields1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtfields4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbofields2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbofields3;
    internal System.Windows.Forms.ImageList imgButtons;
    private System.Windows.Forms.Button cmdCancelar;
    private System.Windows.Forms.TextBox txtfields5;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbofields4;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtfields6;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cbofields5;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.ComboBox cbofields6;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.ComboBox cbofields7;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.ComboBox cbofields8;
    private System.Windows.Forms.ComboBox cbofields9;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.ComboBox cbofields10;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.ComboBox cbxCuadro;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.ComboBox cbxTipoCalculo;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.ComboBox cboCampo;
    private System.Windows.Forms.TextBox txtVar_m;
    private System.Windows.Forms.TextBox txtVar_cam;
    private System.Windows.Forms.TextBox txtFor_m;
  }
}