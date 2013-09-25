namespace ypfbApplication.View
{
  partial class frmRol
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.lbltxtfields1 = new System.Windows.Forms.Label();
      this.lbltxtfields2 = new System.Windows.Forms.Label();
      this.lbltxtfields3 = new System.Windows.Forms.Label();
      this.txtfields1 = new System.Windows.Forms.TextBox();
      this.txtfields2 = new System.Windows.Forms.TextBox();
      this.txtfields3 = new System.Windows.Forms.TextBox();
      this.btnCancelar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.men_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.men_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.chk_estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.men_par = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // lbltxtfields1
      // 
      this.lbltxtfields1.AutoSize = true;
      this.lbltxtfields1.Location = new System.Drawing.Point(129, 17);
      this.lbltxtfields1.Name = "lbltxtfields1";
      this.lbltxtfields1.Size = new System.Drawing.Size(43, 13);
      this.lbltxtfields1.TabIndex = 2;
      this.lbltxtfields1.Text = "Código:";
      // 
      // lbltxtfields2
      // 
      this.lbltxtfields2.AutoSize = true;
      this.lbltxtfields2.Location = new System.Drawing.Point(129, 45);
      this.lbltxtfields2.Name = "lbltxtfields2";
      this.lbltxtfields2.Size = new System.Drawing.Size(33, 13);
      this.lbltxtfields2.TabIndex = 3;
      this.lbltxtfields2.Text = "Titulo";
      // 
      // lbltxtfields3
      // 
      this.lbltxtfields3.AutoSize = true;
      this.lbltxtfields3.Location = new System.Drawing.Point(129, 72);
      this.lbltxtfields3.Name = "lbltxtfields3";
      this.lbltxtfields3.Size = new System.Drawing.Size(63, 13);
      this.lbltxtfields3.TabIndex = 4;
      this.lbltxtfields3.Text = "Descripción";
      // 
      // txtfields1
      // 
      this.txtfields1.Location = new System.Drawing.Point(243, 12);
      this.txtfields1.Name = "txtfields1";
      this.txtfields1.Size = new System.Drawing.Size(215, 20);
      this.txtfields1.TabIndex = 1;
      this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
      // 
      // txtfields2
      // 
      this.txtfields2.Location = new System.Drawing.Point(243, 38);
      this.txtfields2.Name = "txtfields2";
      this.txtfields2.Size = new System.Drawing.Size(215, 20);
      this.txtfields2.TabIndex = 2;
      this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
      // 
      // txtfields3
      // 
      this.txtfields3.Location = new System.Drawing.Point(243, 65);
      this.txtfields3.Name = "txtfields3";
      this.txtfields3.Size = new System.Drawing.Size(215, 20);
      this.txtfields3.TabIndex = 3;
      this.txtfields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields3_KeyPress);
      // 
      // btnCancelar
      // 
      this.btnCancelar.Location = new System.Drawing.Point(313, 462);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(91, 27);
      this.btnCancelar.TabIndex = 5;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.Location = new System.Drawing.Point(194, 462);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(89, 27);
      this.btnGuardar.TabIndex = 4;
      this.btnGuardar.Text = "&Guardar";
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
      this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.men_id,
            this.men_titulo,
            this.chk_estado,
            this.men_par});
      this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
      this.dataGridView1.Location = new System.Drawing.Point(12, 101);
      this.dataGridView1.Name = "dataGridView1";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(599, 343);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
      // 
      // men_id
      // 
      this.men_id.DataPropertyName = "men_id";
      this.men_id.HeaderText = "#";
      this.men_id.Name = "men_id";
      this.men_id.Visible = false;
      // 
      // men_titulo
      // 
      this.men_titulo.DataPropertyName = "men_titulo";
      this.men_titulo.FillWeight = 149.2386F;
      this.men_titulo.HeaderText = "Menú";
      this.men_titulo.Name = "men_titulo";
      // 
      // chk_estado
      // 
      this.chk_estado.DataPropertyName = "menu_visible";
      this.chk_estado.FillWeight = 50.76142F;
      this.chk_estado.HeaderText = "Permisos";
      this.chk_estado.MinimumWidth = 50;
      this.chk_estado.Name = "chk_estado";
      // 
      // men_par
      // 
      this.men_par.DataPropertyName = "men_par";
      this.men_par.HeaderText = "Padre";
      this.men_par.Name = "men_par";
      this.men_par.Visible = false;
      // 
      // frmRol
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(623, 501);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnGuardar);
      this.Controls.Add(this.txtfields3);
      this.Controls.Add(this.txtfields2);
      this.Controls.Add(this.txtfields1);
      this.Controls.Add(this.lbltxtfields3);
      this.Controls.Add(this.lbltxtfields2);
      this.Controls.Add(this.lbltxtfields1);
      this.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmRol";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Roles";
      this.Load += new System.EventHandler(this.frmRol_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbltxtfields1;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.Label lbltxtfields3;
    private System.Windows.Forms.TextBox txtfields1;
    private System.Windows.Forms.TextBox txtfields2;
    private System.Windows.Forms.TextBox txtfields3;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn men_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn men_titulo;
    private System.Windows.Forms.DataGridViewCheckBoxColumn chk_estado;
    private System.Windows.Forms.DataGridViewTextBoxColumn men_par;

  }
}