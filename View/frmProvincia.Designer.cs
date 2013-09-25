namespace ypfbApplication.View
{
  partial class frmProvincia
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
      this.txtfields3 = new System.Windows.Forms.TextBox();
      this.txtfields2 = new System.Windows.Forms.TextBox();
      this.lbltxtfields2 = new System.Windows.Forms.Label();
      this.lblcbofields1 = new System.Windows.Forms.Label();
      this.lbltxtfields1 = new System.Windows.Forms.Label();
      this.cbofields1 = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnCancelar
      // 
      this.btnCancelar.Location = new System.Drawing.Point(217, 146);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(91, 27);
      this.btnCancelar.TabIndex = 5;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.Location = new System.Drawing.Point(91, 146);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(89, 27);
      this.btnGuardar.TabIndex = 4;
      this.btnGuardar.Text = "&Guardar";
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // txtfields3
      // 
      this.txtfields3.Location = new System.Drawing.Point(132, 87);
      this.txtfields3.Name = "txtfields3";
      this.txtfields3.Size = new System.Drawing.Size(215, 20);
      this.txtfields3.TabIndex = 3;
      this.txtfields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields3_KeyPress);
      // 
      // txtfields2
      // 
      this.txtfields2.Location = new System.Drawing.Point(132, 61);
      this.txtfields2.Name = "txtfields2";
      this.txtfields2.Size = new System.Drawing.Size(215, 20);
      this.txtfields2.TabIndex = 2;
      this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
      // 
      // lbltxtfields2
      // 
      this.lbltxtfields2.AutoSize = true;
      this.lbltxtfields2.Location = new System.Drawing.Point(24, 87);
      this.lbltxtfields2.Name = "lbltxtfields2";
      this.lbltxtfields2.Size = new System.Drawing.Size(54, 13);
      this.lbltxtfields2.TabIndex = 3;
      this.lbltxtfields2.Text = "Provincia:";
      // 
      // lblcbofields1
      // 
      this.lblcbofields1.AutoSize = true;
      this.lblcbofields1.Location = new System.Drawing.Point(24, 34);
      this.lblcbofields1.Name = "lblcbofields1";
      this.lblcbofields1.Size = new System.Drawing.Size(77, 13);
      this.lblcbofields1.TabIndex = 1;
      this.lblcbofields1.Text = "Departamento:";
      // 
      // lbltxtfields1
      // 
      this.lbltxtfields1.AutoSize = true;
      this.lbltxtfields1.Location = new System.Drawing.Point(24, 61);
      this.lbltxtfields1.Name = "lbltxtfields1";
      this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
      this.lbltxtfields1.TabIndex = 0;
      this.lbltxtfields1.Text = "Código:";
      // 
      // cbofields1
      // 
      this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbofields1.FormattingEnabled = true;
      this.cbofields1.Location = new System.Drawing.Point(132, 31);
      this.cbofields1.Name = "cbofields1";
      this.cbofields1.Size = new System.Drawing.Size(215, 21);
      this.cbofields1.TabIndex = 1;
      this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields1_KeyPress);
      // 
      // frmProvincia
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(410, 220);
      this.Controls.Add(this.cbofields1);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnGuardar);
      this.Controls.Add(this.txtfields3);
      this.Controls.Add(this.lblcbofields1);
      this.Controls.Add(this.txtfields2);
      this.Controls.Add(this.lbltxtfields1);
      this.Controls.Add(this.lbltxtfields2);
      this.Name = "frmProvincia";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "PROVINCIA - AGREGAR - EDITAR";
      this.Load += new System.EventHandler(this.frmProvincia_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtfields3;
    private System.Windows.Forms.TextBox txtfields2;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.Label lbltxtfields1;
    private System.Windows.Forms.Label lblcbofields1;
    private System.Windows.Forms.ComboBox cbofields1;
  }
}