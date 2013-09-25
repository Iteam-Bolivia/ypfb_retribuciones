namespace ypfbApplication.View
{
  partial class frmEmpresa
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
      this.txtfields4 = new System.Windows.Forms.TextBox();
      this.txtfields3 = new System.Windows.Forms.TextBox();
      this.txtfields2 = new System.Windows.Forms.TextBox();
      this.txtfields1 = new System.Windows.Forms.TextBox();
      this.lbltxtfields5 = new System.Windows.Forms.Label();
      this.lbltxtfields4 = new System.Windows.Forms.Label();
      this.lbltxtfields3 = new System.Windows.Forms.Label();
      this.lbltxtfields6 = new System.Windows.Forms.Label();
      this.lbltxtfields1 = new System.Windows.Forms.Label();
      this.lbltxtfields2 = new System.Windows.Forms.Label();
      this.txtfields6 = new System.Windows.Forms.TextBox();
      this.txtfields5 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancelar
      // 
      this.btnCancelar.Location = new System.Drawing.Point(196, 225);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(91, 27);
      this.btnCancelar.TabIndex = 8;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.Location = new System.Drawing.Point(77, 225);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(89, 27);
      this.btnGuardar.TabIndex = 7;
      this.btnGuardar.Text = "&Guardar";
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // txtfields4
      // 
      this.txtfields4.Location = new System.Drawing.Point(132, 113);
      this.txtfields4.Name = "txtfields4";
      this.txtfields4.Size = new System.Drawing.Size(215, 20);
      this.txtfields4.TabIndex = 4;
      this.txtfields4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields4_KeyPress);
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
      // txtfields1
      // 
      this.txtfields1.Location = new System.Drawing.Point(132, 31);
      this.txtfields1.Name = "txtfields1";
      this.txtfields1.Size = new System.Drawing.Size(215, 20);
      this.txtfields1.TabIndex = 1;
      this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
      // 
      // lbltxtfields5
      // 
      this.lbltxtfields5.AutoSize = true;
      this.lbltxtfields5.Location = new System.Drawing.Point(24, 140);
      this.lbltxtfields5.Name = "lbltxtfields5";
      this.lbltxtfields5.Size = new System.Drawing.Size(52, 13);
      this.lbltxtfields5.TabIndex = 7;
      this.lbltxtfields5.Text = "Teléfono:";
      // 
      // lbltxtfields4
      // 
      this.lbltxtfields4.AutoSize = true;
      this.lbltxtfields4.Location = new System.Drawing.Point(24, 113);
      this.lbltxtfields4.Name = "lbltxtfields4";
      this.lbltxtfields4.Size = new System.Drawing.Size(55, 13);
      this.lbltxtfields4.TabIndex = 4;
      this.lbltxtfields4.Text = "Dirección:";
      // 
      // lbltxtfields3
      // 
      this.lbltxtfields3.AutoSize = true;
      this.lbltxtfields3.Location = new System.Drawing.Point(24, 87);
      this.lbltxtfields3.Name = "lbltxtfields3";
      this.lbltxtfields3.Size = new System.Drawing.Size(60, 13);
      this.lbltxtfields3.TabIndex = 3;
      this.lbltxtfields3.Text = "Propietario:";
      // 
      // lbltxtfields6
      // 
      this.lbltxtfields6.AutoSize = true;
      this.lbltxtfields6.Location = new System.Drawing.Point(24, 166);
      this.lbltxtfields6.Name = "lbltxtfields6";
      this.lbltxtfields6.Size = new System.Drawing.Size(35, 13);
      this.lbltxtfields6.TabIndex = 2;
      this.lbltxtfields6.Text = "Email:";
      // 
      // lbltxtfields1
      // 
      this.lbltxtfields1.AutoSize = true;
      this.lbltxtfields1.Location = new System.Drawing.Point(24, 34);
      this.lbltxtfields1.Name = "lbltxtfields1";
      this.lbltxtfields1.Size = new System.Drawing.Size(28, 13);
      this.lbltxtfields1.TabIndex = 1;
      this.lbltxtfields1.Text = "NIT:";
      // 
      // lbltxtfields2
      // 
      this.lbltxtfields2.AutoSize = true;
      this.lbltxtfields2.Location = new System.Drawing.Point(24, 61);
      this.lbltxtfields2.Name = "lbltxtfields2";
      this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
      this.lbltxtfields2.TabIndex = 0;
      this.lbltxtfields2.Text = "Nombre:";
      // 
      // txtfields6
      // 
      this.txtfields6.Location = new System.Drawing.Point(132, 166);
      this.txtfields6.Name = "txtfields6";
      this.txtfields6.Size = new System.Drawing.Size(215, 20);
      this.txtfields6.TabIndex = 6;
      this.txtfields6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields6_KeyPress);
      // 
      // txtfields5
      // 
      this.txtfields5.Location = new System.Drawing.Point(132, 140);
      this.txtfields5.Name = "txtfields5";
      this.txtfields5.Size = new System.Drawing.Size(215, 20);
      this.txtfields5.TabIndex = 5;
      this.txtfields5.TextChanged += new System.EventHandler(this.txtfields5_TextChanged);
      this.txtfields5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields5_KeyPress);
      // 
      // frmEmpresa
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(410, 280);
      this.Controls.Add(this.txtfields5);
      this.Controls.Add(this.txtfields6);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnGuardar);
      this.Controls.Add(this.txtfields4);
      this.Controls.Add(this.txtfields3);
      this.Controls.Add(this.txtfields2);
      this.Controls.Add(this.lbltxtfields1);
      this.Controls.Add(this.txtfields1);
      this.Controls.Add(this.lbltxtfields2);
      this.Controls.Add(this.lbltxtfields6);
      this.Controls.Add(this.lbltxtfields3);
      this.Controls.Add(this.lbltxtfields4);
      this.Controls.Add(this.lbltxtfields5);
      this.Name = "frmEmpresa";
      this.Text = "EMPRESA - AGREGAR - EDITAR";
      this.Load += new System.EventHandler(this.frmEmpresa_Load_1);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtfields4;
    private System.Windows.Forms.TextBox txtfields3;
    private System.Windows.Forms.TextBox txtfields2;
    private System.Windows.Forms.TextBox txtfields1;
    private System.Windows.Forms.Label lbltxtfields5;
    private System.Windows.Forms.Label lbltxtfields4;
    private System.Windows.Forms.Label lbltxtfields3;
    private System.Windows.Forms.Label lbltxtfields6;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.Label lbltxtfields1;
    private System.Windows.Forms.TextBox txtfields6;
    private System.Windows.Forms.TextBox txtfields5;
  }
}