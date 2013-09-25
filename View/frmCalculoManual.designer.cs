namespace View
{
  partial class frmCalculoManual
    {
        /// <summary>
        /// Required designer Calculo.
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
            this.lstFormulas = new System.Windows.Forms.ListBox();
            this._Frame1_0 = new System.Windows.Forms.GroupBox();
            this.cmdAddVar = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.txtDescripcionVariable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lstCalculos = new System.Windows.Forms.ListBox();
            this._Label1_0 = new System.Windows.Forms.Label();
            this._Label1_1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFormulaDescripcion = new System.Windows.Forms.TextBox();
            this._Frame1_1 = new System.Windows.Forms.GroupBox();
            this.cmdCalcular = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.cbTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Text1_5 = new System.Windows.Forms.TextBox();
            this._Label1_2 = new System.Windows.Forms.Label();
            this._Label1_3 = new System.Windows.Forms.Label();
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdEscoger = new System.Windows.Forms.Button();
            this.cbofields2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCtt_nombre = new System.Windows.Forms.Label();
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblProcesando = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cmdProcesar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.btnReprosesar = new System.Windows.Forms.Button();
            this.btnReprosesarMesActual = new System.Windows.Forms.Button();
            this.radbttnNoEs = new System.Windows.Forms.RadioButton();
            this.rbttnSiEs = new System.Windows.Forms.RadioButton();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this._Frame1_0.SuspendLayout();
            this._Frame1_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFormulas
            // 
            this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
            this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstFormulas.Location = new System.Drawing.Point(17, 22);
            this.lstFormulas.Name = "lstFormulas";
            this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFormulas.Size = new System.Drawing.Size(545, 225);
            this.lstFormulas.TabIndex = 10;
            this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);
            // 
            // _Frame1_0
            // 
            this._Frame1_0.BackColor = System.Drawing.Color.AliceBlue;
            this._Frame1_0.Controls.Add(this.cmdAddVar);
            this._Frame1_0.Controls.Add(this.cmdImprimir);
            this._Frame1_0.Controls.Add(this.txtDescripcionVariable);
            this._Frame1_0.Controls.Add(this.label2);
            this._Frame1_0.Controls.Add(this.txtName);
            this._Frame1_0.Controls.Add(this.txtValue);
            this._Frame1_0.Controls.Add(this.lstCalculos);
            this._Frame1_0.Controls.Add(this._Label1_0);
            this._Frame1_0.Controls.Add(this._Label1_1);
            this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Frame1_0.Location = new System.Drawing.Point(17, 189);
            this._Frame1_0.Name = "_Frame1_0";
            this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Frame1_0.Size = new System.Drawing.Size(314, 430);
            this._Frame1_0.TabIndex = 47;
            this._Frame1_0.TabStop = false;
            this._Frame1_0.Text = "VARIABLES";
            // 
            // cmdAddVar
            // 
            this.cmdAddVar.Location = new System.Drawing.Point(197, 391);
            this.cmdAddVar.Name = "cmdAddVar";
            this.cmdAddVar.Size = new System.Drawing.Size(101, 27);
            this.cmdAddVar.TabIndex = 87;
            this.cmdAddVar.Text = "&Añadir/Modificar";
            this.cmdAddVar.UseVisualStyleBackColor = true;
            this.cmdAddVar.Click += new System.EventHandler(this.cmdAddVar_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Location = new System.Drawing.Point(77, 391);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(101, 27);
            this.cmdImprimir.TabIndex = 86;
            this.cmdImprimir.Text = "&Imprimir Listado";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // txtDescripcionVariable
            // 
            this.txtDescripcionVariable.AcceptsReturn = true;
            this.txtDescripcionVariable.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcionVariable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcionVariable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescripcionVariable.Location = new System.Drawing.Point(77, 321);
            this.txtDescripcionVariable.MaxLength = 0;
            this.txtDescripcionVariable.Multiline = true;
            this.txtDescripcionVariable.Name = "txtDescripcionVariable";
            this.txtDescripcionVariable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescripcionVariable.Size = new System.Drawing.Size(221, 45);
            this.txtDescripcionVariable.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 320);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción:";
            // 
            // txtName
            // 
            this.txtName.AcceptsReturn = true;
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(77, 368);
            this.txtName.MaxLength = 0;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(86, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValue.Location = new System.Drawing.Point(196, 368);
            this.txtValue.MaxLength = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValue.Size = new System.Drawing.Size(101, 20);
            this.txtValue.TabIndex = 9;
            // 
            // lstCalculos
            // 
            this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
            this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstCalculos.Location = new System.Drawing.Point(17, 22);
            this.lstCalculos.Name = "lstCalculos";
            this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCalculos.Size = new System.Drawing.Size(281, 290);
            this.lstCalculos.TabIndex = 6;
            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            // 
            // _Label1_0
            // 
            this._Label1_0.BackColor = System.Drawing.Color.AliceBlue;
            this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_0.Location = new System.Drawing.Point(14, 368);
            this._Label1_0.Name = "_Label1_0";
            this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_0.Size = new System.Drawing.Size(65, 17);
            this._Label1_0.TabIndex = 2;
            this._Label1_0.Text = "Variable:";
            // 
            // _Label1_1
            // 
            this._Label1_1.BackColor = System.Drawing.Color.AliceBlue;
            this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_1.Location = new System.Drawing.Point(165, 371);
            this._Label1_1.Name = "_Label1_1";
            this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_1.Size = new System.Drawing.Size(43, 17);
            this._Label1_1.TabIndex = 4;
            this._Label1_1.Text = "Valor:";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(401, 61);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 89;
            this.label8.Text = "Campos:";
            // 
            // txtFormulaDescripcion
            // 
            this.txtFormulaDescripcion.AcceptsReturn = true;
            this.txtFormulaDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtFormulaDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormulaDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFormulaDescripcion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFormulaDescripcion.Location = new System.Drawing.Point(84, 304);
            this.txtFormulaDescripcion.MaxLength = 0;
            this.txtFormulaDescripcion.Multiline = true;
            this.txtFormulaDescripcion.Name = "txtFormulaDescripcion";
            this.txtFormulaDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFormulaDescripcion.Size = new System.Drawing.Size(478, 45);
            this.txtFormulaDescripcion.TabIndex = 11;
            // 
            // _Frame1_1
            // 
            this._Frame1_1.BackColor = System.Drawing.Color.AliceBlue;
            this._Frame1_1.Controls.Add(this.cmdCalcular);
            this._Frame1_1.Controls.Add(this.lblResultado);
            this._Frame1_1.Controls.Add(this.txtFormulaDescripcion);
            this._Frame1_1.Controls.Add(this.cbTest);
            this._Frame1_1.Controls.Add(this.label1);
            this._Frame1_1.Controls.Add(this._Text1_5);
            this._Frame1_1.Controls.Add(this._Label1_2);
            this._Frame1_1.Controls.Add(this._Label1_3);
            this._Frame1_1.Controls.Add(this.lstFormulas);
            this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Frame1_1.Location = new System.Drawing.Point(340, 189);
            this._Frame1_1.Name = "_Frame1_1";
            this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Frame1_1.Size = new System.Drawing.Size(568, 432);
            this._Frame1_1.TabIndex = 49;
            this._Frame1_1.TabStop = false;
            this._Frame1_1.Text = "FÓRMULAS";
            // 
            // cmdCalcular
            // 
            this.cmdCalcular.Location = new System.Drawing.Point(461, 399);
            this.cmdCalcular.Name = "cmdCalcular";
            this.cmdCalcular.Size = new System.Drawing.Size(101, 27);
            this.cmdCalcular.TabIndex = 85;
            this.cmdCalcular.Text = "&Probar Fórmula";
            this.cmdCalcular.UseVisualStyleBackColor = true;
            this.cmdCalcular.Click += new System.EventHandler(this.cmdCalcular_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.Color.AliceBlue;
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultado.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResultado.Location = new System.Drawing.Point(84, 376);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblResultado.Size = new System.Drawing.Size(478, 22);
            this.lblResultado.TabIndex = 57;
            this.lblResultado.Text = "(resultado)";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbTest
            // 
            this.cbTest.BackColor = System.Drawing.SystemColors.Window;
            this.cbTest.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbTest.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTest.Location = new System.Drawing.Point(84, 352);
            this.cbTest.Name = "cbTest";
            this.cbTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTest.Size = new System.Drawing.Size(478, 21);
            this.cbTest.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 304);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Descripción:";
            // 
            // _Text1_5
            // 
            this._Text1_5.AcceptsReturn = true;
            this._Text1_5.BackColor = System.Drawing.SystemColors.Window;
            this._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._Text1_5.Location = new System.Drawing.Point(249, 353);
            this._Text1_5.MaxLength = 0;
            this._Text1_5.Name = "_Text1_5";
            this._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Text1_5.Size = new System.Drawing.Size(313, 20);
            this._Text1_5.TabIndex = 53;
            this._Text1_5.Text = "Text1";
            // 
            // _Label1_2
            // 
            this._Label1_2.BackColor = System.Drawing.Color.AliceBlue;
            this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_2.Location = new System.Drawing.Point(14, 352);
            this._Label1_2.Name = "_Label1_2";
            this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_2.Size = new System.Drawing.Size(97, 17);
            this._Label1_2.TabIndex = 52;
            this._Label1_2.Text = "Fórmulas:";
            // 
            // _Label1_3
            // 
            this._Label1_3.BackColor = System.Drawing.Color.AliceBlue;
            this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label1_3.Location = new System.Drawing.Point(14, 374);
            this._Label1_3.Name = "_Label1_3";
            this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_3.Size = new System.Drawing.Size(79, 36);
            this._Label1_3.TabIndex = 55;
            this._Label1_3.Text = "&Resultado Proceso:";
            // 
            // cbxMes
            // 
            this.cbxMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Location = new System.Drawing.Point(122, 104);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxMes.Size = new System.Drawing.Size(209, 21);
            this.cbxMes.TabIndex = 4;
            this.cbxMes.SelectedIndexChanged += new System.EventHandler(this.cbxMes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Año:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Periodo:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(17, 32);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 68;
            this.label5.Text = "Proceso de cálculo:";
            // 
            // cmdEscoger
            // 
            this.cmdEscoger.Location = new System.Drawing.Point(739, 13);
            this.cmdEscoger.Name = "cmdEscoger";
            this.cmdEscoger.Size = new System.Drawing.Size(145, 27);
            this.cmdEscoger.TabIndex = 5;
            this.cmdEscoger.Text = "&Buscar";
            this.cmdEscoger.UseVisualStyleBackColor = true;
            this.cmdEscoger.Click += new System.EventHandler(this.cmdEscoger_Click);
            // 
            // cbofields2
            // 
            this.cbofields2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbofields2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbofields2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofields2.FormattingEnabled = true;
            this.cbofields2.Location = new System.Drawing.Point(122, 55);
            this.cbofields2.Name = "cbofields2";
            this.cbofields2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbofields2.Size = new System.Drawing.Size(209, 21);
            this.cbofields2.TabIndex = 2;
            this.cbofields2.SelectedIndexChanged += new System.EventHandler(this.cbofields2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(17, 55);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 71;
            this.label6.Text = "Contrato:";
            // 
            // lblCtt_nombre
            // 
            this.lblCtt_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCtt_nombre.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCtt_nombre.Location = new System.Drawing.Point(459, 35);
            this.lblCtt_nombre.Name = "lblCtt_nombre";
            this.lblCtt_nombre.Size = new System.Drawing.Size(209, 22);
            this.lblCtt_nombre.TabIndex = 72;
            // 
            // cbofields1
            // 
            this.cbofields1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbofields1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(122, 32);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbofields1.Size = new System.Drawing.Size(209, 21);
            this.cbofields1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(401, 35);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "Código:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(122, 131);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // lblProcesando
            // 
            this.lblProcesando.BackColor = System.Drawing.Color.AliceBlue;
            this.lblProcesando.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProcesando.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcesando.Location = new System.Drawing.Point(17, 131);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProcesando.Size = new System.Drawing.Size(79, 17);
            this.lblProcesando.TabIndex = 84;
            this.lblProcesando.Text = "Procesando ...";
            this.lblProcesando.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cmdProcesar
            // 
            this.cmdProcesar.Location = new System.Drawing.Point(739, 46);
            this.cmdProcesar.Name = "cmdProcesar";
            this.cmdProcesar.Size = new System.Drawing.Size(145, 27);
            this.cmdProcesar.TabIndex = 85;
            this.cmdProcesar.Text = "&Procesar y Guardar";
            this.cmdProcesar.UseVisualStyleBackColor = true;
            this.cmdProcesar.Click += new System.EventHandler(this.cmdProcesar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(739, 79);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(145, 27);
            this.cmdCancelar.TabIndex = 87;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click_1);
            // 
            // lstCampos
            // 
            this.lstCampos.BackColor = System.Drawing.SystemColors.Window;
            this.lstCampos.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstCampos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstCampos.Location = new System.Drawing.Point(459, 61);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstCampos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCampos.Size = new System.Drawing.Size(209, 69);
            this.lstCampos.TabIndex = 90;
            this.lstCampos.SelectedIndexChanged += new System.EventHandler(this.lstCampos_SelectedIndexChanged);
            // 
            // btnReprosesar
            // 
            this.btnReprosesar.Enabled = false;
            this.btnReprosesar.Location = new System.Drawing.Point(739, 112);
            this.btnReprosesar.Name = "btnReprosesar";
            this.btnReprosesar.Size = new System.Drawing.Size(145, 27);
            this.btnReprosesar.TabIndex = 91;
            this.btnReprosesar.Text = "Re-Procesar y guardar";
            this.btnReprosesar.UseVisualStyleBackColor = false;
            this.btnReprosesar.Click += new System.EventHandler(this.btnReprosesar_Click);
            // 
            // btnReprosesarMesActual
            // 
            this.btnReprosesarMesActual.Enabled = false;
            this.btnReprosesarMesActual.Location = new System.Drawing.Point(739, 145);
            this.btnReprosesarMesActual.Name = "btnReprosesarMesActual";
            this.btnReprosesarMesActual.Size = new System.Drawing.Size(145, 34);
            this.btnReprosesarMesActual.TabIndex = 92;
            this.btnReprosesarMesActual.Text = "Re-Procesar hasta mes actual";
            this.btnReprosesarMesActual.UseVisualStyleBackColor = false;
            // 
            // radbttnNoEs
            // 
            this.radbttnNoEs.AutoSize = true;
            this.radbttnNoEs.Checked = true;
            this.radbttnNoEs.Location = new System.Drawing.Point(404, 145);
            this.radbttnNoEs.Name = "radbttnNoEs";
            this.radbttnNoEs.Size = new System.Drawing.Size(132, 17);
            this.radbttnNoEs.TabIndex = 0;
            this.radbttnNoEs.TabStop = true;
            this.radbttnNoEs.Text = "No es Campo Marginal";
            this.radbttnNoEs.UseVisualStyleBackColor = true;
            this.radbttnNoEs.CheckedChanged += new System.EventHandler(this.radbttnNoEs_CheckedChanged);
            // 
            // rbttnSiEs
            // 
            this.rbttnSiEs.AutoSize = true;
            this.rbttnSiEs.Location = new System.Drawing.Point(547, 145);
            this.rbttnSiEs.Name = "rbttnSiEs";
            this.rbttnSiEs.Size = new System.Drawing.Size(116, 17);
            this.rbttnSiEs.TabIndex = 1;
            this.rbttnSiEs.Text = "Es Campo Marginal";
            this.rbttnSiEs.UseVisualStyleBackColor = true;
            this.rbttnSiEs.CheckedChanged += new System.EventHandler(this.rbttnSiEs_CheckedChanged);
            // 
            // cbxAnio
            // 
            this.cbxAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(122, 79);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(209, 21);
            this.cbxAnio.TabIndex = 93;
            this.cbxAnio.SelectedIndexChanged += new System.EventHandler(this.cbxAnio_SelectedIndexChanged);
            // 
            // frmCalculoManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(914, 184);
            this.Controls.Add(this.cbxAnio);
            this.Controls.Add(this.rbttnSiEs);
            this.Controls.Add(this.radbttnNoEs);
            this.Controls.Add(this.btnReprosesarMesActual);
            this.Controls.Add(this.btnReprosesar);
            this.Controls.Add(this.lstCampos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdProcesar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxMes);
            this.Controls.Add(this.cbofields1);
            this.Controls.Add(this.lblCtt_nombre);
            this.Controls.Add(this.cbofields2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdEscoger);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._Frame1_0);
            this.Controls.Add(this._Frame1_1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalculoManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROCESOS DE CÁLCULO";
            this.Load += new System.EventHandler(this.frmCalculoManual_Load);
            this._Frame1_0.ResumeLayout(false);
            this._Frame1_0.PerformLayout();
            this._Frame1_1.ResumeLayout(false);
            this._Frame1_1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lstFormulas;
        public System.Windows.Forms.GroupBox _Frame1_0;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.Label _Label1_0;
        public System.Windows.Forms.Label _Label1_1;
        public System.Windows.Forms.TextBox txtFormulaDescripcion;
        public System.Windows.Forms.GroupBox _Frame1_1;
        public System.Windows.Forms.ComboBox cbTest;
        public System.Windows.Forms.TextBox _Text1_5;
        public System.Windows.Forms.Label lblResultado;
        public System.Windows.Forms.Label _Label1_3;
        public System.Windows.Forms.Label _Label1_2;
        public System.Windows.Forms.TextBox txtDescripcionVariable;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMes;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdEscoger;
        private System.Windows.Forms.ComboBox cbofields2;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCtt_nombre;
        private System.Windows.Forms.ComboBox cbofields1;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblProcesando;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button cmdCalcular;
        private System.Windows.Forms.Button cmdProcesar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdAddVar;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ListBox lstCampos;
        private System.Windows.Forms.ListBox lstCalculos;
        private System.Windows.Forms.Button btnReprosesar;
        private System.Windows.Forms.Button btnReprosesarMesActual;
        private System.Windows.Forms.RadioButton radbttnNoEs;
        private System.Windows.Forms.RadioButton rbttnSiEs;
        private System.Windows.Forms.ComboBox cbxAnio;
    }
}

