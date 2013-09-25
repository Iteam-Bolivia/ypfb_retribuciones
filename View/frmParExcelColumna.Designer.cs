namespace ypfbApplication.View
{
    partial class frmParExcelColumna
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
            this.lblCodigoPagina = new System.Windows.Forms.Label();
            this.lblColumna = new System.Windows.Forms.Label();
            this.lblTipoCosto = new System.Windows.Forms.Label();
            this.txtCodigoHoja = new System.Windows.Forms.TextBox();
            this.txtNombreColumna = new System.Windows.Forms.TextBox();
            this.cbxTipoCosto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.lblMercado = new System.Windows.Forms.Label();
            this.cbxConvercion = new System.Windows.Forms.ComboBox();
            this.cbxUnidadMedida = new System.Windows.Forms.ComboBox();
            this.rbtnTrue = new System.Windows.Forms.RadioButton();
            this.rbtnFalse = new System.Windows.Forms.RadioButton();
            this.txtPec_Fila = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxVariable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreColumna = new System.Windows.Forms.Label();
            this.cbxMercado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigoPagina
            // 
            this.lblCodigoPagina.AutoSize = true;
            this.lblCodigoPagina.Location = new System.Drawing.Point(85, 36);
            this.lblCodigoPagina.Name = "lblCodigoPagina";
            this.lblCodigoPagina.Size = new System.Drawing.Size(81, 13);
            this.lblCodigoPagina.TabIndex = 0;
            this.lblCodigoPagina.Text = "Código de hoja:";
            // 
            // lblColumna
            // 
            this.lblColumna.AutoSize = true;
            this.lblColumna.Location = new System.Drawing.Point(85, 117);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(90, 13);
            this.lblColumna.TabIndex = 1;
            this.lblColumna.Text = "Nombre columna:";
            // 
            // lblTipoCosto
            // 
            this.lblTipoCosto.AutoSize = true;
            this.lblTipoCosto.Location = new System.Drawing.Point(49, 339);
            this.lblTipoCosto.Name = "lblTipoCosto";
            this.lblTipoCosto.Size = new System.Drawing.Size(74, 13);
            this.lblTipoCosto.TabIndex = 2;
            this.lblTipoCosto.Text = "Tipo columna:";
            // 
            // txtCodigoHoja
            // 
            this.txtCodigoHoja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoHoja.Enabled = false;
            this.txtCodigoHoja.Location = new System.Drawing.Point(194, 36);
            this.txtCodigoHoja.Name = "txtCodigoHoja";
            this.txtCodigoHoja.Size = new System.Drawing.Size(237, 20);
            this.txtCodigoHoja.TabIndex = 0;
            this.txtCodigoHoja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreHoja_KeyPress);
            // 
            // txtNombreColumna
            // 
            this.txtNombreColumna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreColumna.Location = new System.Drawing.Point(194, 114);
            this.txtNombreColumna.Name = "txtNombreColumna";
            this.txtNombreColumna.Size = new System.Drawing.Size(237, 20);
            this.txtNombreColumna.TabIndex = 2;
            this.txtNombreColumna.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreColumna_KeyPress);
            // 
            // cbxTipoCosto
            // 
            this.cbxTipoCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTipoCosto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxTipoCosto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipoCosto.FormattingEnabled = true;
            this.cbxTipoCosto.Location = new System.Drawing.Point(158, 336);
            this.cbxTipoCosto.Name = "cbxTipoCosto";
            this.cbxTipoCosto.Size = new System.Drawing.Size(362, 21);
            this.cbxTipoCosto.TabIndex = 10;
            this.cbxTipoCosto.SelectedIndexChanged += new System.EventHandler(this.cbxTipoCosto_SelectedIndexChanged);
            this.cbxTipoCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxTipoCosto_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(221, 261);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(326, 261);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Location = new System.Drawing.Point(49, 366);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(81, 13);
            this.lblUnidadMedida.TabIndex = 9;
            this.lblUnidadMedida.Text = "Unidad medida:";
            // 
            // lblMercado
            // 
            this.lblMercado.AutoSize = true;
            this.lblMercado.Location = new System.Drawing.Point(85, 200);
            this.lblMercado.Name = "lblMercado";
            this.lblMercado.Size = new System.Drawing.Size(64, 13);
            this.lblMercado.TabIndex = 10;
            this.lblMercado.Text = "Converción:";
            // 
            // cbxConvercion
            // 
            this.cbxConvercion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConvercion.FormattingEnabled = true;
            this.cbxConvercion.Location = new System.Drawing.Point(194, 197);
            this.cbxConvercion.Name = "cbxConvercion";
            this.cbxConvercion.Size = new System.Drawing.Size(237, 21);
            this.cbxConvercion.TabIndex = 5;
            this.cbxConvercion.SelectedIndexChanged += new System.EventHandler(this.cbxMerecado_SelectedIndexChanged);
            this.cbxConvercion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxMerecado_KeyPress);
            // 
            // cbxUnidadMedida
            // 
            this.cbxUnidadMedida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxUnidadMedida.FormattingEnabled = true;
            this.cbxUnidadMedida.Location = new System.Drawing.Point(158, 363);
            this.cbxUnidadMedida.Name = "cbxUnidadMedida";
            this.cbxUnidadMedida.Size = new System.Drawing.Size(362, 21);
            this.cbxUnidadMedida.TabIndex = 11;
            // 
            // rbtnTrue
            // 
            this.rbtnTrue.AutoSize = true;
            this.rbtnTrue.Checked = true;
            this.rbtnTrue.Location = new System.Drawing.Point(195, 237);
            this.rbtnTrue.Name = "rbtnTrue";
            this.rbtnTrue.Size = new System.Drawing.Size(64, 17);
            this.rbtnTrue.TabIndex = 6;
            this.rbtnTrue.TabStop = true;
            this.rbtnTrue.Text = "Con IVA";
            this.rbtnTrue.UseVisualStyleBackColor = true;
            // 
            // rbtnFalse
            // 
            this.rbtnFalse.AutoSize = true;
            this.rbtnFalse.Location = new System.Drawing.Point(271, 237);
            this.rbtnFalse.Name = "rbtnFalse";
            this.rbtnFalse.Size = new System.Drawing.Size(60, 17);
            this.rbtnFalse.TabIndex = 7;
            this.rbtnFalse.Text = "Sin IVA";
            this.rbtnFalse.UseVisualStyleBackColor = true;
            // 
            // txtPec_Fila
            // 
            this.txtPec_Fila.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPec_Fila.Location = new System.Drawing.Point(194, 88);
            this.txtPec_Fila.Name = "txtPec_Fila";
            this.txtPec_Fila.Size = new System.Drawing.Size(237, 20);
            this.txtPec_Fila.TabIndex = 1;
            this.txtPec_Fila.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPec_Fila_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Numero fila:";
            // 
            // cbxVariable
            // 
            this.cbxVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVariable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxVariable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxVariable.FormattingEnabled = true;
            this.cbxVariable.Location = new System.Drawing.Point(194, 140);
            this.cbxVariable.Name = "cbxVariable";
            this.cbxVariable.Size = new System.Drawing.Size(237, 21);
            this.cbxVariable.TabIndex = 3;
            this.cbxVariable.SelectedIndexChanged += new System.EventHandler(this.cbxVariable_SelectedIndexChanged);
            this.cbxVariable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxVariable_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Variable:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Descripción Variable:";
            // 
            // lblNombreColumna
            // 
            this.lblNombreColumna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreColumna.BackColor = System.Drawing.Color.White;
            this.lblNombreColumna.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombreColumna.Location = new System.Drawing.Point(194, 164);
            this.lblNombreColumna.Name = "lblNombreColumna";
            this.lblNombreColumna.Size = new System.Drawing.Size(237, 30);
            this.lblNombreColumna.TabIndex = 4;
            this.lblNombreColumna.Text = "label4";
            // 
            // cbxMercado
            // 
            this.cbxMercado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMercado.FormattingEnabled = true;
            this.cbxMercado.Location = new System.Drawing.Point(194, 62);
            this.cbxMercado.Name = "cbxMercado";
            this.cbxMercado.Size = new System.Drawing.Size(237, 21);
            this.cbxMercado.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mercado:";
            // 
            // frmParExcelColumna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(532, 314);
            this.Controls.Add(this.cbxMercado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNombreColumna);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxVariable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPec_Fila);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnFalse);
            this.Controls.Add(this.rbtnTrue);
            this.Controls.Add(this.cbxUnidadMedida);
            this.Controls.Add(this.cbxConvercion);
            this.Controls.Add(this.lblMercado);
            this.Controls.Add(this.lblUnidadMedida);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbxTipoCosto);
            this.Controls.Add(this.txtNombreColumna);
            this.Controls.Add(this.txtCodigoHoja);
            this.Controls.Add(this.lblTipoCosto);
            this.Controls.Add(this.lblColumna);
            this.Controls.Add(this.lblCodigoPagina);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParExcelColumna";
            this.Text = "Parametros Excel Columna";
            this.Load += new System.EventHandler(this.frmParExcelColumna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigoPagina;
        private System.Windows.Forms.Label lblColumna;
        private System.Windows.Forms.Label lblTipoCosto;
        private System.Windows.Forms.TextBox txtCodigoHoja;
        private System.Windows.Forms.TextBox txtNombreColumna;
        private System.Windows.Forms.ComboBox cbxTipoCosto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.Label lblMercado;
        private System.Windows.Forms.ComboBox cbxConvercion;
        private System.Windows.Forms.ComboBox cbxUnidadMedida;
        private System.Windows.Forms.RadioButton rbtnTrue;
        private System.Windows.Forms.RadioButton rbtnFalse;
        private System.Windows.Forms.TextBox txtPec_Fila;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreColumna;
        private System.Windows.Forms.ComboBox cbxMercado;
        private System.Windows.Forms.Label label4;
    }
}