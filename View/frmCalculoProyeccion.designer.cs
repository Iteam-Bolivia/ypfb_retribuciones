namespace View
{
  partial class frmCalculoProyeccion
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
          this.lstVariables = new System.Windows.Forms.ListBox();
          this.label11 = new System.Windows.Forms.Label();
          this.cmdAddVar = new System.Windows.Forms.Button();
          this.txtDescripcionVariable = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.txtName = new System.Windows.Forms.TextBox();
          this.txtValue = new System.Windows.Forms.TextBox();
          this.lstCalculos = new System.Windows.Forms.ListBox();
          this._Label1_0 = new System.Windows.Forms.Label();
          this._Label1_1 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.cbxMesf = new System.Windows.Forms.ComboBox();
          this.cbxMesi = new System.Windows.Forms.ComboBox();
          this.label9 = new System.Windows.Forms.Label();
          this.txtFormulaDescripcion = new System.Windows.Forms.TextBox();
          this._Frame1_1 = new System.Windows.Forms.GroupBox();
          this.cmdCalcular = new System.Windows.Forms.Button();
          this.lblResultado = new System.Windows.Forms.Label();
          this.cbTest = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this._Text1_5 = new System.Windows.Forms.TextBox();
          this._Label1_2 = new System.Windows.Forms.Label();
          this._Label1_3 = new System.Windows.Forms.Label();
          this.cbxAnioi = new System.Windows.Forms.ComboBox();
          this.label3 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
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
          this.label8 = new System.Windows.Forms.Label();
          this.cbxAniof = new System.Windows.Forms.ComboBox();
          this.label10 = new System.Windows.Forms.Label();
          this.cbxAniofP = new System.Windows.Forms.ComboBox();
          this.cbxMesfP = new System.Windows.Forms.ComboBox();
          this.label13 = new System.Windows.Forms.Label();
          this.label14 = new System.Windows.Forms.Label();
          this.cbxMesiP = new System.Windows.Forms.ComboBox();
          this.label15 = new System.Windows.Forms.Label();
          this.cbxAnioiP = new System.Windows.Forms.ComboBox();
          this.label16 = new System.Windows.Forms.Label();
          this._Frame1_0.SuspendLayout();
          this._Frame1_1.SuspendLayout();
          this.SuspendLayout();
          // 
          // lstFormulas
          // 
          this.lstFormulas.BackColor = System.Drawing.SystemColors.Window;
          this.lstFormulas.Cursor = System.Windows.Forms.Cursors.Default;
          this.lstFormulas.ForeColor = System.Drawing.SystemColors.WindowText;
          this.lstFormulas.Location = new System.Drawing.Point(19, 36);
          this.lstFormulas.Name = "lstFormulas";
          this.lstFormulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.lstFormulas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
          this.lstFormulas.Size = new System.Drawing.Size(263, 173);
          this.lstFormulas.TabIndex = 10;
          this.lstFormulas.SelectedIndexChanged += new System.EventHandler(this.lstFormulas_SelectedIndexChanged);
          // 
          // _Frame1_0
          // 
          this._Frame1_0.BackColor = System.Drawing.Color.AliceBlue;
          this._Frame1_0.Controls.Add(this.lstVariables);
          this._Frame1_0.Controls.Add(this.label11);
          this._Frame1_0.Controls.Add(this.cmdAddVar);
          this._Frame1_0.Controls.Add(this.txtDescripcionVariable);
          this._Frame1_0.Controls.Add(this.label2);
          this._Frame1_0.Controls.Add(this.txtName);
          this._Frame1_0.Controls.Add(this.txtValue);
          this._Frame1_0.Controls.Add(this.lstCalculos);
          this._Frame1_0.Controls.Add(this._Label1_0);
          this._Frame1_0.Controls.Add(this._Label1_1);
          this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
          this._Frame1_0.Location = new System.Drawing.Point(17, 220);
          this._Frame1_0.Name = "_Frame1_0";
          this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this._Frame1_0.Size = new System.Drawing.Size(442, 358);
          this._Frame1_0.TabIndex = 47;
          this._Frame1_0.TabStop = false;
          this._Frame1_0.Text = "VARIABLES";
          // 
          // lstVariables
          // 
          this.lstVariables.BackColor = System.Drawing.SystemColors.Window;
          this.lstVariables.Cursor = System.Windows.Forms.Cursors.Default;
          this.lstVariables.ForeColor = System.Drawing.SystemColors.WindowText;
          this.lstVariables.Location = new System.Drawing.Point(17, 36);
          this.lstVariables.Name = "lstVariables";
          this.lstVariables.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.lstVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
          this.lstVariables.Size = new System.Drawing.Size(105, 277);
          this.lstVariables.TabIndex = 92;
          this.lstVariables.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
          // 
          // label11
          // 
          this.label11.BackColor = System.Drawing.Color.AliceBlue;
          this.label11.Cursor = System.Windows.Forms.Cursors.Default;
          this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label11.Location = new System.Drawing.Point(14, 16);
          this.label11.Name = "label11";
          this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label11.Size = new System.Drawing.Size(65, 17);
          this.label11.TabIndex = 90;
          this.label11.Text = "De cálculo:";
          // 
          // cmdAddVar
          // 
          this.cmdAddVar.Location = new System.Drawing.Point(325, 325);
          this.cmdAddVar.Name = "cmdAddVar";
          this.cmdAddVar.Size = new System.Drawing.Size(101, 27);
          this.cmdAddVar.TabIndex = 87;
          this.cmdAddVar.Text = "&Añadir/Modificar";
          this.cmdAddVar.UseVisualStyleBackColor = true;
          this.cmdAddVar.Click += new System.EventHandler(this.cmdAddVar_Click);
          // 
          // txtDescripcionVariable
          // 
          this.txtDescripcionVariable.AcceptsReturn = true;
          this.txtDescripcionVariable.BackColor = System.Drawing.SystemColors.Window;
          this.txtDescripcionVariable.Cursor = System.Windows.Forms.Cursors.IBeam;
          this.txtDescripcionVariable.ForeColor = System.Drawing.SystemColors.WindowText;
          this.txtDescripcionVariable.Location = new System.Drawing.Point(209, 228);
          this.txtDescripcionVariable.MaxLength = 0;
          this.txtDescripcionVariable.Multiline = true;
          this.txtDescripcionVariable.Name = "txtDescripcionVariable";
          this.txtDescripcionVariable.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.txtDescripcionVariable.Size = new System.Drawing.Size(217, 37);
          this.txtDescripcionVariable.TabIndex = 7;
          // 
          // label2
          // 
          this.label2.BackColor = System.Drawing.Color.AliceBlue;
          this.label2.Cursor = System.Windows.Forms.Cursors.Default;
          this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label2.Location = new System.Drawing.Point(125, 231);
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
          this.txtName.Location = new System.Drawing.Point(209, 271);
          this.txtName.MaxLength = 0;
          this.txtName.Name = "txtName";
          this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.txtName.Size = new System.Drawing.Size(217, 20);
          this.txtName.TabIndex = 8;
          // 
          // txtValue
          // 
          this.txtValue.AcceptsReturn = true;
          this.txtValue.BackColor = System.Drawing.SystemColors.Window;
          this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
          this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
          this.txtValue.Location = new System.Drawing.Point(209, 297);
          this.txtValue.MaxLength = 0;
          this.txtValue.Name = "txtValue";
          this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.txtValue.Size = new System.Drawing.Size(217, 20);
          this.txtValue.TabIndex = 9;
          // 
          // lstCalculos
          // 
          this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
          this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
          this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
          this.lstCalculos.Location = new System.Drawing.Point(128, 36);
          this.lstCalculos.Name = "lstCalculos";
          this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
          this.lstCalculos.Size = new System.Drawing.Size(298, 186);
          this.lstCalculos.TabIndex = 6;
          this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
          // 
          // _Label1_0
          // 
          this._Label1_0.BackColor = System.Drawing.Color.AliceBlue;
          this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
          this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
          this._Label1_0.Location = new System.Drawing.Point(125, 274);
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
          this._Label1_1.Location = new System.Drawing.Point(125, 300);
          this._Label1_1.Name = "_Label1_1";
          this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this._Label1_1.Size = new System.Drawing.Size(43, 17);
          this._Label1_1.TabIndex = 4;
          this._Label1_1.Text = "Valor:";
          // 
          // label4
          // 
          this.label4.BackColor = System.Drawing.Color.AliceBlue;
          this.label4.Cursor = System.Windows.Forms.Cursors.Default;
          this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label4.Location = new System.Drawing.Point(363, 104);
          this.label4.Name = "label4";
          this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label4.Size = new System.Drawing.Size(103, 18);
          this.label4.TabIndex = 65;
          this.label4.Text = "Periodo Final Ratio:";
          // 
          // cbxMesf
          // 
          this.cbxMesf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxMesf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxMesf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxMesf.FormattingEnabled = true;
          this.cbxMesf.Location = new System.Drawing.Point(527, 101);
          this.cbxMesf.Name = "cbxMesf";
          this.cbxMesf.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbxMesf.Size = new System.Drawing.Size(209, 21);
          this.cbxMesf.TabIndex = 4;
          // 
          // cbxMesi
          // 
          this.cbxMesi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxMesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxMesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxMesi.FormattingEnabled = true;
          this.cbxMesi.Location = new System.Drawing.Point(527, 77);
          this.cbxMesi.Name = "cbxMesi";
          this.cbxMesi.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbxMesi.Size = new System.Drawing.Size(209, 21);
          this.cbxMesi.TabIndex = 90;
          // 
          // label9
          // 
          this.label9.BackColor = System.Drawing.Color.AliceBlue;
          this.label9.Cursor = System.Windows.Forms.Cursors.Default;
          this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label9.Location = new System.Drawing.Point(363, 77);
          this.label9.Name = "label9";
          this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label9.Size = new System.Drawing.Size(106, 17);
          this.label9.TabIndex = 91;
          this.label9.Text = "Periodo Inicial Ratio:";
          // 
          // txtFormulaDescripcion
          // 
          this.txtFormulaDescripcion.AcceptsReturn = true;
          this.txtFormulaDescripcion.BackColor = System.Drawing.SystemColors.Window;
          this.txtFormulaDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
          this.txtFormulaDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
          this.txtFormulaDescripcion.ForeColor = System.Drawing.SystemColors.WindowText;
          this.txtFormulaDescripcion.Location = new System.Drawing.Point(88, 220);
          this.txtFormulaDescripcion.MaxLength = 0;
          this.txtFormulaDescripcion.Multiline = true;
          this.txtFormulaDescripcion.Name = "txtFormulaDescripcion";
          this.txtFormulaDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.txtFormulaDescripcion.Size = new System.Drawing.Size(194, 45);
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
          this._Frame1_1.Location = new System.Drawing.Point(465, 220);
          this._Frame1_1.Name = "_Frame1_1";
          this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this._Frame1_1.Size = new System.Drawing.Size(304, 358);
          this._Frame1_1.TabIndex = 49;
          this._Frame1_1.TabStop = false;
          this._Frame1_1.Text = "FÓRMULAS";
          // 
          // cmdCalcular
          // 
          this.cmdCalcular.Location = new System.Drawing.Point(189, 320);
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
          this.lblResultado.Location = new System.Drawing.Point(88, 295);
          this.lblResultado.Name = "lblResultado";
          this.lblResultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.lblResultado.Size = new System.Drawing.Size(202, 22);
          this.lblResultado.TabIndex = 57;
          this.lblResultado.Text = "(resultado)";
          this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
          // 
          // cbTest
          // 
          this.cbTest.BackColor = System.Drawing.SystemColors.Window;
          this.cbTest.Cursor = System.Windows.Forms.Cursors.Default;
          this.cbTest.ForeColor = System.Drawing.SystemColors.WindowText;
          this.cbTest.Location = new System.Drawing.Point(88, 271);
          this.cbTest.Name = "cbTest";
          this.cbTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbTest.Size = new System.Drawing.Size(202, 21);
          this.cbTest.TabIndex = 12;
          // 
          // label1
          // 
          this.label1.BackColor = System.Drawing.Color.AliceBlue;
          this.label1.Cursor = System.Windows.Forms.Cursors.Default;
          this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label1.Location = new System.Drawing.Point(16, 223);
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
          this._Text1_5.Location = new System.Drawing.Point(88, 271);
          this._Text1_5.MaxLength = 0;
          this._Text1_5.Name = "_Text1_5";
          this._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this._Text1_5.Size = new System.Drawing.Size(194, 20);
          this._Text1_5.TabIndex = 53;
          this._Text1_5.Text = "Text1";
          // 
          // _Label1_2
          // 
          this._Label1_2.BackColor = System.Drawing.Color.AliceBlue;
          this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
          this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
          this._Label1_2.Location = new System.Drawing.Point(16, 271);
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
          this._Label1_3.Location = new System.Drawing.Point(16, 289);
          this._Label1_3.Name = "_Label1_3";
          this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this._Label1_3.Size = new System.Drawing.Size(79, 36);
          this._Label1_3.TabIndex = 55;
          this._Label1_3.Text = "&Resultado Proceso:";
          // 
          // cbxAnioi
          // 
          this.cbxAnioi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxAnioi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxAnioi.FormattingEnabled = true;
          this.cbxAnioi.Location = new System.Drawing.Point(132, 77);
          this.cbxAnioi.Name = "cbxAnioi";
          this.cbxAnioi.Size = new System.Drawing.Size(209, 21);
          this.cbxAnioi.TabIndex = 3;
          // 
          // label3
          // 
          this.label3.BackColor = System.Drawing.Color.AliceBlue;
          this.label3.Cursor = System.Windows.Forms.Cursors.Default;
          this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label3.Location = new System.Drawing.Point(17, 77);
          this.label3.Name = "label3";
          this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label3.Size = new System.Drawing.Size(97, 17);
          this.label3.TabIndex = 64;
          this.label3.Text = "Año inicial Ratio:";
          // 
          // label5
          // 
          this.label5.BackColor = System.Drawing.Color.AliceBlue;
          this.label5.Cursor = System.Windows.Forms.Cursors.Default;
          this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label5.Location = new System.Drawing.Point(17, 17);
          this.label5.Name = "label5";
          this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label5.Size = new System.Drawing.Size(107, 17);
          this.label5.TabIndex = 68;
          this.label5.Text = "Proceso de cálculo:";
          // 
          // cbofields2
          // 
          this.cbofields2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
          this.cbofields2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbofields2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbofields2.FormattingEnabled = true;
          this.cbofields2.Location = new System.Drawing.Point(132, 40);
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
          this.label6.Location = new System.Drawing.Point(17, 40);
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
          this.lblCtt_nombre.Location = new System.Drawing.Point(527, 35);
          this.lblCtt_nombre.Name = "lblCtt_nombre";
          this.lblCtt_nombre.Size = new System.Drawing.Size(13, 22);
          this.lblCtt_nombre.TabIndex = 72;
          // 
          // cbofields1
          // 
          this.cbofields1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
          this.cbofields1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields1.Enabled = false;
          this.cbofields1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbofields1.FormattingEnabled = true;
          this.cbofields1.Location = new System.Drawing.Point(132, 17);
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
          this.label7.Location = new System.Drawing.Point(363, 43);
          this.label7.Name = "label7";
          this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label7.Size = new System.Drawing.Size(47, 17);
          this.label7.TabIndex = 80;
          this.label7.Text = "Código:";
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(132, 191);
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
          this.lblProcesando.Location = new System.Drawing.Point(17, 191);
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
          this.cmdProcesar.Location = new System.Drawing.Point(505, 588);
          this.cmdProcesar.Name = "cmdProcesar";
          this.cmdProcesar.Size = new System.Drawing.Size(123, 27);
          this.cmdProcesar.TabIndex = 85;
          this.cmdProcesar.Text = "&Procesar y Guardar";
          this.cmdProcesar.UseVisualStyleBackColor = true;
          this.cmdProcesar.Click += new System.EventHandler(this.cmdProcesar_Click);
          // 
          // cmdCancelar
          // 
          this.cmdCancelar.Location = new System.Drawing.Point(654, 588);
          this.cmdCancelar.Name = "cmdCancelar";
          this.cmdCancelar.Size = new System.Drawing.Size(101, 27);
          this.cmdCancelar.TabIndex = 87;
          this.cmdCancelar.Text = "&Cancelar";
          this.cmdCancelar.UseVisualStyleBackColor = true;
          this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click_1);
          // 
          // label8
          // 
          this.label8.BackColor = System.Drawing.Color.AliceBlue;
          this.label8.Cursor = System.Windows.Forms.Cursors.Default;
          this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label8.Location = new System.Drawing.Point(363, 20);
          this.label8.Name = "label8";
          this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label8.Size = new System.Drawing.Size(132, 17);
          this.label8.TabIndex = 88;
          this.label8.Text = "PROYECCIONES";
          // 
          // cbxAniof
          // 
          this.cbxAniof.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxAniof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxAniof.FormattingEnabled = true;
          this.cbxAniof.Location = new System.Drawing.Point(132, 101);
          this.cbxAniof.Name = "cbxAniof";
          this.cbxAniof.Size = new System.Drawing.Size(209, 21);
          this.cbxAniof.TabIndex = 92;
          // 
          // label10
          // 
          this.label10.BackColor = System.Drawing.Color.AliceBlue;
          this.label10.Cursor = System.Windows.Forms.Cursors.Default;
          this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label10.Location = new System.Drawing.Point(17, 104);
          this.label10.Name = "label10";
          this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label10.Size = new System.Drawing.Size(97, 17);
          this.label10.TabIndex = 93;
          this.label10.Text = "Año final Ratio:";
          // 
          // cbxAniofP
          // 
          this.cbxAniofP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxAniofP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxAniofP.FormattingEnabled = true;
          this.cbxAniofP.Location = new System.Drawing.Point(132, 159);
          this.cbxAniofP.Name = "cbxAniofP";
          this.cbxAniofP.Size = new System.Drawing.Size(209, 21);
          this.cbxAniofP.TabIndex = 96;
          // 
          // cbxMesfP
          // 
          this.cbxMesfP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxMesfP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxMesfP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxMesfP.FormattingEnabled = true;
          this.cbxMesfP.Location = new System.Drawing.Point(527, 159);
          this.cbxMesfP.Name = "cbxMesfP";
          this.cbxMesfP.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbxMesfP.Size = new System.Drawing.Size(209, 21);
          this.cbxMesfP.TabIndex = 94;
          // 
          // label13
          // 
          this.label13.BackColor = System.Drawing.Color.AliceBlue;
          this.label13.Cursor = System.Windows.Forms.Cursors.Default;
          this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label13.Location = new System.Drawing.Point(17, 159);
          this.label13.Name = "label13";
          this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label13.Size = new System.Drawing.Size(112, 18);
          this.label13.TabIndex = 97;
          this.label13.Text = "Año final Proyección:";
          // 
          // label14
          // 
          this.label14.BackColor = System.Drawing.Color.AliceBlue;
          this.label14.Cursor = System.Windows.Forms.Cursors.Default;
          this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label14.Location = new System.Drawing.Point(363, 159);
          this.label14.Name = "label14";
          this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label14.Size = new System.Drawing.Size(130, 18);
          this.label14.TabIndex = 95;
          this.label14.Text = "Periodo Final Proyección:";
          // 
          // cbxMesiP
          // 
          this.cbxMesiP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxMesiP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxMesiP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxMesiP.FormattingEnabled = true;
          this.cbxMesiP.Location = new System.Drawing.Point(527, 135);
          this.cbxMesiP.Name = "cbxMesiP";
          this.cbxMesiP.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbxMesiP.Size = new System.Drawing.Size(209, 21);
          this.cbxMesiP.TabIndex = 100;
          // 
          // label15
          // 
          this.label15.BackColor = System.Drawing.Color.AliceBlue;
          this.label15.Cursor = System.Windows.Forms.Cursors.Default;
          this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label15.Location = new System.Drawing.Point(363, 135);
          this.label15.Name = "label15";
          this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label15.Size = new System.Drawing.Size(133, 17);
          this.label15.TabIndex = 101;
          this.label15.Text = "Periodo Inicial Proyección:";
          // 
          // cbxAnioiP
          // 
          this.cbxAnioiP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxAnioiP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.cbxAnioiP.FormattingEnabled = true;
          this.cbxAnioiP.Location = new System.Drawing.Point(132, 135);
          this.cbxAnioiP.Name = "cbxAnioiP";
          this.cbxAnioiP.Size = new System.Drawing.Size(209, 21);
          this.cbxAnioiP.TabIndex = 98;
          // 
          // label16
          // 
          this.label16.BackColor = System.Drawing.Color.AliceBlue;
          this.label16.Cursor = System.Windows.Forms.Cursors.Default;
          this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
          this.label16.Location = new System.Drawing.Point(17, 135);
          this.label16.Name = "label16";
          this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.label16.Size = new System.Drawing.Size(122, 17);
          this.label16.TabIndex = 99;
          this.label16.Text = "Año inicial Proyección:";
          // 
          // frmCalculoProyeccion
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(782, 627);
          this.Controls.Add(this.cbxMesiP);
          this.Controls.Add(this.label15);
          this.Controls.Add(this.cbxAnioiP);
          this.Controls.Add(this.label16);
          this.Controls.Add(this.cbxAniofP);
          this.Controls.Add(this.cbxMesfP);
          this.Controls.Add(this.label13);
          this.Controls.Add(this.label14);
          this.Controls.Add(this.cbxAniof);
          this.Controls.Add(this.cbxMesf);
          this.Controls.Add(this.cbxMesi);
          this.Controls.Add(this.label10);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.label8);
          this.Controls.Add(this.label9);
          this.Controls.Add(this.cmdCancelar);
          this.Controls.Add(this.cmdProcesar);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.lblProcesando);
          this.Controls.Add(this.label7);
          this.Controls.Add(this.cbxAnioi);
          this.Controls.Add(this.cbofields1);
          this.Controls.Add(this.lblCtt_nombre);
          this.Controls.Add(this.cbofields2);
          this.Controls.Add(this.label6);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.label3);
          this.Controls.Add(this._Frame1_0);
          this.Controls.Add(this._Frame1_1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmCalculoProyeccion";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "PROYECCIONES DE CÁLCULOS";
          this.Load += new System.EventHandler(this.frmCalculoProyeccion_Load);
          this._Frame1_0.ResumeLayout(false);
          this._Frame1_0.PerformLayout();
          this._Frame1_1.ResumeLayout(false);
          this._Frame1_1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lstFormulas;
        public System.Windows.Forms.GroupBox _Frame1_0;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.ListBox lstCalculos;
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
        private System.Windows.Forms.ComboBox cbxAnioi;
        private System.Windows.Forms.ComboBox cbxMesf;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button cmdAddVar;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxMesi;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxAniof;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.ComboBox cbxAniofP;
        private System.Windows.Forms.ComboBox cbxMesfP;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxMesiP;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxAnioiP;
        public System.Windows.Forms.Label label16;
    }
}

