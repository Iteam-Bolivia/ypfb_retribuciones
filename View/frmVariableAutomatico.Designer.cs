namespace ypfbApplication.View
{
  partial class frmVariableAutomatico
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
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this._Frame1_0 = new System.Windows.Forms.GroupBox();
      this.txtDescripcionVariable = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.listBox2 = new System.Windows.Forms.ListBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this._Frame1_0.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(680, 83);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(323, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "&Generar variables";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(688, 116);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 1;
      // 
      // _Frame1_0
      // 
      this._Frame1_0.BackColor = System.Drawing.Color.AliceBlue;
      this._Frame1_0.Controls.Add(this.txtDescripcionVariable);
      this._Frame1_0.Controls.Add(this.label2);
      this._Frame1_0.Controls.Add(this.listBox1);
      this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
      this._Frame1_0.Location = new System.Drawing.Point(5, 12);
      this._Frame1_0.Name = "_Frame1_0";
      this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this._Frame1_0.Size = new System.Drawing.Size(251, 379);
      this._Frame1_0.TabIndex = 48;
      this._Frame1_0.TabStop = false;
      this._Frame1_0.Text = "VARIABLES MAESTRAS";
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
      this.txtDescripcionVariable.Size = new System.Drawing.Size(160, 45);
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
      // listBox1
      // 
      this.listBox1.AllowDrop = true;
      this.listBox1.BackColor = System.Drawing.SystemColors.Window;
      this.listBox1.Cursor = System.Windows.Forms.Cursors.Default;
      this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.listBox1.Location = new System.Drawing.Point(11, 19);
      this.listBox1.Name = "listBox1";
      this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.listBox1.Size = new System.Drawing.Size(220, 290);
      this.listBox1.TabIndex = 6;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
      this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
      this.listBox1.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.listBox1_QueryContinueDrag);
      this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.listBox2);
      this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
      this.groupBox1.Location = new System.Drawing.Point(403, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.groupBox1.Size = new System.Drawing.Size(251, 379);
      this.groupBox1.TabIndex = 49;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "VARIABLES A GENERAR";
      // 
      // textBox1
      // 
      this.textBox1.AcceptsReturn = true;
      this.textBox1.BackColor = System.Drawing.SystemColors.Window;
      this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.textBox1.Location = new System.Drawing.Point(77, 321);
      this.textBox1.MaxLength = 0;
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.textBox1.Size = new System.Drawing.Size(160, 45);
      this.textBox1.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.Color.AliceBlue;
      this.label3.Cursor = System.Windows.Forms.Cursors.Default;
      this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label3.Location = new System.Drawing.Point(14, 320);
      this.label3.Name = "label3";
      this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.label3.Size = new System.Drawing.Size(65, 17);
      this.label3.TabIndex = 8;
      this.label3.Text = "Descripción:";
      // 
      // listBox2
      // 
      this.listBox2.AllowDrop = true;
      this.listBox2.BackColor = System.Drawing.SystemColors.Window;
      this.listBox2.Cursor = System.Windows.Forms.Cursors.Default;
      this.listBox2.ForeColor = System.Drawing.SystemColors.WindowText;
      this.listBox2.Location = new System.Drawing.Point(17, 22);
      this.listBox2.Name = "listBox2";
      this.listBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.listBox2.Size = new System.Drawing.Size(220, 290);
      this.listBox2.TabIndex = 6;
      this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
      this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
      this.listBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox2_DragOver);
      this.listBox2.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.listBox2_QueryContinueDrag);
      this.listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDown);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(262, 116);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(128, 23);
      this.button2.TabIndex = 50;
      this.button2.Text = "SELECCIONADO";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(262, 174);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(128, 23);
      this.button3.TabIndex = 51;
      this.button3.Text = "SELECCIONAR TODO";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(262, 203);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(128, 23);
      this.button4.TabIndex = 52;
      this.button4.Text = "ELIMINAR TODO";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(262, 145);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(128, 23);
      this.button5.TabIndex = 53;
      this.button5.Text = "ELIMINAR";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(677, 56);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(326, 21);
      this.comboBox1.TabIndex = 54;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(677, 34);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(163, 13);
      this.label4.TabIndex = 55;
      this.label4.Text = "Tipo de generación de Variables:";
      // 
      // frmVariableAutomatico
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1030, 401);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this._Frame1_0);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Name = "frmVariableAutomatico";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "GENERADOR DE VARIABLES AUTOMÁTICAMENTE";
      this.Load += new System.EventHandler(this.frmVariableAutomatico_Load);
      this._Frame1_0.ResumeLayout(false);
      this._Frame1_0.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.GroupBox _Frame1_0;
    public System.Windows.Forms.TextBox txtDescripcionVariable;
    public System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox listBox1;
    public System.Windows.Forms.GroupBox groupBox1;
    public System.Windows.Forms.TextBox textBox1;
    public System.Windows.Forms.Label label3;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label4;
  }
}