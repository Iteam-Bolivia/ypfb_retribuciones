namespace ypfbApplication.View
{
  partial class frmContrato_Sinonimo
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
      this.lblContrato = new System.Windows.Forms.Label();
      this.lbllblfields1 = new System.Windows.Forms.Label();
      this.lbltxtfields2 = new System.Windows.Forms.Label();
      this.txtfields1 = new System.Windows.Forms.TextBox();
      this.cbofields1 = new System.Windows.Forms.ComboBox();
      this.lblcbofields1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancelar
      // 
      this.btnCancelar.Location = new System.Drawing.Point(254, 142);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(91, 27);
      this.btnCancelar.TabIndex = 4;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.Location = new System.Drawing.Point(117, 142);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(89, 27);
      this.btnGuardar.TabIndex = 3;
      this.btnGuardar.Text = "&Guardar";
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // lblContrato
      // 
      this.lblContrato.AutoSize = true;
      this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblContrato.Location = new System.Drawing.Point(129, 30);
      this.lblContrato.Name = "lblContrato";
      this.lblContrato.Size = new System.Drawing.Size(0, 13);
      this.lblContrato.TabIndex = 12;
      // 
      // lbllblfields1
      // 
      this.lbllblfields1.AutoSize = true;
      this.lbllblfields1.Location = new System.Drawing.Point(128, 30);
      this.lbllblfields1.Name = "lbllblfields1";
      this.lbllblfields1.Size = new System.Drawing.Size(0, 13);
      this.lbllblfields1.TabIndex = 13;
      // 
      // lbltxtfields2
      // 
      this.lbltxtfields2.AutoSize = true;
      this.lbltxtfields2.Location = new System.Drawing.Point(51, 83);
      this.lbltxtfields2.Name = "lbltxtfields2";
      this.lbltxtfields2.Size = new System.Drawing.Size(53, 13);
      this.lbltxtfields2.TabIndex = 20;
      this.lbltxtfields2.Text = "Sinonimo:";
      // 
      // txtfields1
      // 
      this.txtfields1.Location = new System.Drawing.Point(127, 83);
      this.txtfields1.Name = "txtfields1";
      this.txtfields1.Size = new System.Drawing.Size(283, 20);
      this.txtfields1.TabIndex = 2;
      this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
      // 
      // cbofields1
      // 
      this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbofields1.FormattingEnabled = true;
      this.cbofields1.Location = new System.Drawing.Point(127, 35);
      this.cbofields1.Name = "cbofields1";
      this.cbofields1.Size = new System.Drawing.Size(283, 21);
      this.cbofields1.TabIndex = 0;
      this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields1_KeyPress);
      // 
      // lblcbofields1
      // 
      this.lblcbofields1.AutoSize = true;
      this.lblcbofields1.Location = new System.Drawing.Point(51, 38);
      this.lblcbofields1.Name = "lblcbofields1";
      this.lblcbofields1.Size = new System.Drawing.Size(50, 13);
      this.lblcbofields1.TabIndex = 22;
      this.lblcbofields1.Text = "Contrato:";
      // 
      // frmContrato_Sinonimo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(461, 210);
      this.Controls.Add(this.lblcbofields1);
      this.Controls.Add(this.cbofields1);
      this.Controls.Add(this.txtfields1);
      this.Controls.Add(this.lbltxtfields2);
      this.Controls.Add(this.lbllblfields1);
      this.Controls.Add(this.lblContrato);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnGuardar);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmContrato_Sinonimo";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sinonimo";
      this.Load += new System.EventHandler(this.frmContrato_Sinonimo_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Label lblContrato;
    private System.Windows.Forms.Label lbllblfields1;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.TextBox txtfields1;
    private System.Windows.Forms.ComboBox cbofields1;
    private System.Windows.Forms.Label lblcbofields1;
  }
}