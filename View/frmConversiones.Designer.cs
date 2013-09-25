namespace ypfbApplication.View
{
    partial class frmConversiones
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
          this.lblcbofields2 = new System.Windows.Forms.Label();
          this.lbltxtfields1 = new System.Windows.Forms.Label();
          this.cbofields1 = new System.Windows.Forms.ComboBox();
          this.cbofields2 = new System.Windows.Forms.ComboBox();
          this.txtfields1 = new System.Windows.Forms.TextBox();
          this.cmdGuardar = new System.Windows.Forms.Button();
          this.cmdCancelar = new System.Windows.Forms.Button();
          this.cbofields3 = new System.Windows.Forms.ComboBox();
          this.lblcbofields3 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // lblcbofields1
          // 
          this.lblcbofields1.AutoSize = true;
          this.lblcbofields1.Location = new System.Drawing.Point(31, 28);
          this.lblcbofields1.Name = "lblcbofields1";
          this.lblcbofields1.Size = new System.Drawing.Size(109, 13);
          this.lblcbofields1.TabIndex = 0;
          this.lblcbofields1.Text = "Unidad Medida Base:";
          // 
          // lblcbofields2
          // 
          this.lblcbofields2.AutoSize = true;
          this.lblcbofields2.Location = new System.Drawing.Point(31, 55);
          this.lblcbofields2.Name = "lblcbofields2";
          this.lblcbofields2.Size = new System.Drawing.Size(121, 13);
          this.lblcbofields2.TabIndex = 1;
          this.lblcbofields2.Text = "Unidad Medida Destino:";
          // 
          // lbltxtfields1
          // 
          this.lbltxtfields1.AutoSize = true;
          this.lbltxtfields1.Location = new System.Drawing.Point(31, 109);
          this.lbltxtfields1.Name = "lbltxtfields1";
          this.lbltxtfields1.Size = new System.Drawing.Size(34, 13);
          this.lbltxtfields1.TabIndex = 2;
          this.lbltxtfields1.Text = "Valor:";
          // 
          // cbofields1
          // 
          this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields1.FormattingEnabled = true;
          this.cbofields1.Location = new System.Drawing.Point(175, 25);
          this.cbofields1.Name = "cbofields1";
          this.cbofields1.Size = new System.Drawing.Size(204, 21);
          this.cbofields1.TabIndex = 0;
          // 
          // cbofields2
          // 
          this.cbofields2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields2.FormattingEnabled = true;
          this.cbofields2.Location = new System.Drawing.Point(175, 52);
          this.cbofields2.Name = "cbofields2";
          this.cbofields2.Size = new System.Drawing.Size(204, 21);
          this.cbofields2.TabIndex = 1;
          // 
          // txtfields1
          // 
          this.txtfields1.Location = new System.Drawing.Point(175, 106);
          this.txtfields1.Name = "txtfields1";
          this.txtfields1.Size = new System.Drawing.Size(204, 20);
          this.txtfields1.TabIndex = 3;
          this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
          // 
          // cmdGuardar
          // 
          this.cmdGuardar.Location = new System.Drawing.Point(137, 149);
          this.cmdGuardar.Name = "cmdGuardar";
          this.cmdGuardar.Size = new System.Drawing.Size(75, 23);
          this.cmdGuardar.TabIndex = 4;
          this.cmdGuardar.Text = "&Guardar";
          this.cmdGuardar.UseVisualStyleBackColor = true;
          this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
          // 
          // cmdCancelar
          // 
          this.cmdCancelar.Location = new System.Drawing.Point(251, 149);
          this.cmdCancelar.Name = "cmdCancelar";
          this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
          this.cmdCancelar.TabIndex = 5;
          this.cmdCancelar.Text = "&Cancelar";
          this.cmdCancelar.UseVisualStyleBackColor = true;
          this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
          // 
          // cbofields3
          // 
          this.cbofields3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbofields3.FormattingEnabled = true;
          this.cbofields3.Location = new System.Drawing.Point(175, 79);
          this.cbofields3.Name = "cbofields3";
          this.cbofields3.Size = new System.Drawing.Size(204, 21);
          this.cbofields3.TabIndex = 2;
          // 
          // lblcbofields3
          // 
          this.lblcbofields3.AutoSize = true;
          this.lblcbofields3.Location = new System.Drawing.Point(31, 82);
          this.lblcbofields3.Name = "lblcbofields3";
          this.lblcbofields3.Size = new System.Drawing.Size(48, 13);
          this.lblcbofields3.TabIndex = 5;
          this.lblcbofields3.Text = "Variable:";
          // 
          // frmConversiones
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(447, 210);
          this.Controls.Add(this.cbofields3);
          this.Controls.Add(this.lblcbofields3);
          this.Controls.Add(this.cmdCancelar);
          this.Controls.Add(this.cmdGuardar);
          this.Controls.Add(this.txtfields1);
          this.Controls.Add(this.cbofields2);
          this.Controls.Add(this.cbofields1);
          this.Controls.Add(this.lbltxtfields1);
          this.Controls.Add(this.lblcbofields2);
          this.Controls.Add(this.lblcbofields1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmConversiones";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Conversiones";
          this.Load += new System.EventHandler(this.frmConversiones_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.Label lblcbofields2;
        private System.Windows.Forms.Label lbltxtfields1;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.ComboBox cbofields2;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.ComboBox cbofields3;
        private System.Windows.Forms.Label lblcbofields3;
    }
}