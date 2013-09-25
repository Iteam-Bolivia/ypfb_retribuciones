namespace ypfbApplication.View
{
    partial class frmCalculoBusquedaProyeccion
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
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.cbo_mes = new System.Windows.Forms.ComboBox();
          this.cbo_anio = new System.Windows.Forms.ComboBox();
          this.txt_nombrecontrato = new System.Windows.Forms.TextBox();
          this.txt_tipocalculo = new System.Windows.Forms.TextBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.btnBuscar = new System.Windows.Forms.Button();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.cbo_mes);
          this.groupBox1.Controls.Add(this.cbo_anio);
          this.groupBox1.Controls.Add(this.txt_nombrecontrato);
          this.groupBox1.Controls.Add(this.txt_tipocalculo);
          this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Controls.Add(this.label3);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(21, 14);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(353, 143);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Opciones de Búsqueda";
          // 
          // cbo_mes
          // 
          this.cbo_mes.FormattingEnabled = true;
          this.cbo_mes.Location = new System.Drawing.Point(130, 76);
          this.cbo_mes.Name = "cbo_mes";
          this.cbo_mes.Size = new System.Drawing.Size(201, 21);
          this.cbo_mes.TabIndex = 3;
          this.cbo_mes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_mes_KeyPress);
          // 
          // cbo_anio
          // 
          this.cbo_anio.FormattingEnabled = true;
          this.cbo_anio.Location = new System.Drawing.Point(130, 49);
          this.cbo_anio.Name = "cbo_anio";
          this.cbo_anio.Size = new System.Drawing.Size(201, 21);
          this.cbo_anio.TabIndex = 2;
          this.cbo_anio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_anio_KeyPress);
          // 
          // txt_nombrecontrato
          // 
          this.txt_nombrecontrato.Location = new System.Drawing.Point(130, 23);
          this.txt_nombrecontrato.Name = "txt_nombrecontrato";
          this.txt_nombrecontrato.Size = new System.Drawing.Size(201, 20);
          this.txt_nombrecontrato.TabIndex = 1;
          this.txt_nombrecontrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombrecontrato_KeyPress);
          // 
          // txt_tipocalculo
          // 
          this.txt_tipocalculo.Location = new System.Drawing.Point(130, 103);
          this.txt_tipocalculo.Name = "txt_tipocalculo";
          this.txt_tipocalculo.Size = new System.Drawing.Size(201, 20);
          this.txt_tipocalculo.TabIndex = 4;
          this.txt_tipocalculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tipocalculo_KeyPress);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(23, 23);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(90, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "Nombre Contrato:";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(23, 76);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(30, 13);
          this.label3.TabIndex = 2;
          this.label3.Text = "Mes:";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(23, 49);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(29, 13);
          this.label2.TabIndex = 1;
          this.label2.Text = "Año:";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(23, 103);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(73, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Tipo Proceso:";
          // 
          // btnCancelar
          // 
          this.btnCancelar.Location = new System.Drawing.Point(216, 178);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(120, 23);
          this.btnCancelar.TabIndex = 6;
          this.btnCancelar.Text = "&Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // btnBuscar
          // 
          this.btnBuscar.Location = new System.Drawing.Point(77, 178);
          this.btnBuscar.Name = "btnBuscar";
          this.btnBuscar.Size = new System.Drawing.Size(114, 23);
          this.btnBuscar.TabIndex = 5;
          this.btnBuscar.Text = "&Búsqueda";
          this.btnBuscar.UseVisualStyleBackColor = true;
          this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
          // 
          // frmCalculoBusquedaProyeccion
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(411, 223);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.btnBuscar);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmCalculoBusquedaProyeccion";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "BÚSQUEDA DE PROCESO DE CÁLCULO";
          this.Load += new System.EventHandler(this.frmCalculoBusqueda_Load);
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_mes;
        private System.Windows.Forms.ComboBox cbo_anio;
        private System.Windows.Forms.TextBox txt_nombrecontrato;
        private System.Windows.Forms.TextBox txt_tipocalculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
    }
}