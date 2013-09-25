namespace ypfbApplication.View
{
    partial class frmImportacion
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
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacion));
          this.LblPeriodo = new System.Windows.Forms.Label();
          this.LblHoja = new System.Windows.Forms.Label();
          this.LblExplorar = new System.Windows.Forms.Label();
          this.cbxPex_hoja = new System.Windows.Forms.ComboBox();
          this.btnLoad = new System.Windows.Forms.Button();
          this.btnAceptar = new System.Windows.Forms.Button();
          this.btnCancelar = new System.Windows.Forms.Button();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.cbxMes = new System.Windows.Forms.ComboBox();
          this.cbxAnio = new System.Windows.Forms.ComboBox();
          this.lblDireccion = new System.Windows.Forms.Label();
          this.lblNombreHoja = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.toolBar1 = new System.Windows.Forms.ToolBar();
          this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
          this.cmdClose = new System.Windows.Forms.ToolBarButton();
          this.imgButtons = new System.Windows.Forms.ImageList(this.components);
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.timer1 = new System.Windows.Forms.Timer(this.components);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          this.SuspendLayout();
          // 
          // LblPeriodo
          // 
          this.LblPeriodo.AutoSize = true;
          this.LblPeriodo.Location = new System.Drawing.Point(70, 43);
          this.LblPeriodo.Name = "LblPeriodo";
          this.LblPeriodo.Size = new System.Drawing.Size(46, 13);
          this.LblPeriodo.TabIndex = 1;
          this.LblPeriodo.Text = "Periodo:";
          // 
          // LblHoja
          // 
          this.LblHoja.AutoSize = true;
          this.LblHoja.Location = new System.Drawing.Point(70, 70);
          this.LblHoja.Name = "LblHoja";
          this.LblHoja.Size = new System.Drawing.Size(136, 13);
          this.LblHoja.TabIndex = 2;
          this.LblHoja.Text = "Nombre Documento  excel:";
          // 
          // LblExplorar
          // 
          this.LblExplorar.AutoSize = true;
          this.LblExplorar.Location = new System.Drawing.Point(70, 132);
          this.LblExplorar.Name = "LblExplorar";
          this.LblExplorar.Size = new System.Drawing.Size(48, 13);
          this.LblExplorar.TabIndex = 3;
          this.LblExplorar.Text = "Explorar:";
          // 
          // cbxPex_hoja
          // 
          this.cbxPex_hoja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.cbxPex_hoja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
          this.cbxPex_hoja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxPex_hoja.FormattingEnabled = true;
          this.cbxPex_hoja.Location = new System.Drawing.Point(212, 67);
          this.cbxPex_hoja.Name = "cbxPex_hoja";
          this.cbxPex_hoja.Size = new System.Drawing.Size(395, 21);
          this.cbxPex_hoja.TabIndex = 2;
          this.cbxPex_hoja.SelectedIndexChanged += new System.EventHandler(this.cbxPex_hoja_SelectedIndexChanged);
          // 
          // btnLoad
          // 
          this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.btnLoad.Location = new System.Drawing.Point(615, 127);
          this.btnLoad.Name = "btnLoad";
          this.btnLoad.Size = new System.Drawing.Size(75, 23);
          this.btnLoad.TabIndex = 4;
          this.btnLoad.Text = "Cargar";
          this.btnLoad.UseVisualStyleBackColor = true;
          this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
          // 
          // btnAceptar
          // 
          this.btnAceptar.Location = new System.Drawing.Point(93, 187);
          this.btnAceptar.Name = "btnAceptar";
          this.btnAceptar.Size = new System.Drawing.Size(75, 23);
          this.btnAceptar.TabIndex = 5;
          this.btnAceptar.Text = "Aceptar";
          this.btnAceptar.UseVisualStyleBackColor = true;
          this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
          // 
          // btnCancelar
          // 
          this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancelar.Location = new System.Drawing.Point(615, 187);
          this.btnCancelar.Name = "btnCancelar";
          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
          this.btnCancelar.TabIndex = 6;
          this.btnCancelar.Text = "Cancelar";
          this.btnCancelar.UseVisualStyleBackColor = true;
          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // cbxMes
          // 
          this.cbxMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.cbxMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
          this.cbxMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxMes.FormattingEnabled = true;
          this.cbxMes.Location = new System.Drawing.Point(212, 40);
          this.cbxMes.Name = "cbxMes";
          this.cbxMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.cbxMes.Size = new System.Drawing.Size(268, 21);
          this.cbxMes.TabIndex = 0;
          // 
          // cbxAnio
          // 
          this.cbxAnio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.cbxAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
          this.cbxAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cbxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbxAnio.FormattingEnabled = true;
          this.cbxAnio.Location = new System.Drawing.Point(486, 40);
          this.cbxAnio.Name = "cbxAnio";
          this.cbxAnio.Size = new System.Drawing.Size(121, 21);
          this.cbxAnio.TabIndex = 1;
          // 
          // lblDireccion
          // 
          this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.lblDireccion.BackColor = System.Drawing.Color.White;
          this.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.lblDireccion.Location = new System.Drawing.Point(212, 131);
          this.lblDireccion.Name = "lblDireccion";
          this.lblDireccion.Size = new System.Drawing.Size(395, 19);
          this.lblDireccion.TabIndex = 3;
          // 
          // lblNombreHoja
          // 
          this.lblNombreHoja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.lblNombreHoja.BackColor = System.Drawing.Color.White;
          this.lblNombreHoja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.lblNombreHoja.Location = new System.Drawing.Point(212, 100);
          this.lblNombreHoja.Name = "lblNombreHoja";
          this.lblNombreHoja.Size = new System.Drawing.Size(395, 19);
          this.lblNombreHoja.TabIndex = 17;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(70, 101);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(136, 13);
          this.label2.TabIndex = 16;
          this.label2.Text = "Nombre de la hoja de excel";
          // 
          // dataGridView1
          // 
          dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
          this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
          this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView1.Location = new System.Drawing.Point(61, 225);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.Size = new System.Drawing.Size(629, 216);
          this.dataGridView1.TabIndex = 18;
          // 
          // toolBar1
          // 
          this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
          this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdRefresh,
            this.cmdClose});
          this.toolBar1.DropDownArrows = true;
          this.toolBar1.ImageList = this.imgButtons;
          this.toolBar1.Location = new System.Drawing.Point(0, 0);
          this.toolBar1.Name = "toolBar1";
          this.toolBar1.ShowToolTips = true;
          this.toolBar1.Size = new System.Drawing.Size(727, 28);
          this.toolBar1.TabIndex = 19;
          this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
          this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
          // 
          // cmdRefresh
          // 
          this.cmdRefresh.ImageIndex = 3;
          this.cmdRefresh.Name = "cmdRefresh";
          this.cmdRefresh.Text = "A&ctualizar";
          // 
          // cmdClose
          // 
          this.cmdClose.ImageIndex = 7;
          this.cmdClose.Name = "cmdClose";
          this.cmdClose.Text = "&Cerrar";
          this.cmdClose.ToolTipText = "Cerrar ventana";
          // 
          // imgButtons
          // 
          this.imgButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgButtons.ImageStream")));
          this.imgButtons.TransparentColor = System.Drawing.Color.Transparent;
          this.imgButtons.Images.SetKeyName(0, "add.gif");
          this.imgButtons.Images.SetKeyName(1, "delete.gif");
          this.imgButtons.Images.SetKeyName(2, "doc.gif");
          this.imgButtons.Images.SetKeyName(3, "table_refresh.png");
          this.imgButtons.Images.SetKeyName(4, "search.png");
          this.imgButtons.Images.SetKeyName(5, "print.png");
          this.imgButtons.Images.SetKeyName(6, "salir.png");
          this.imgButtons.Images.SetKeyName(7, "edit.gif");
          this.imgButtons.Images.SetKeyName(8, "user_add.png");
          this.imgButtons.Images.SetKeyName(9, "user_delete.png");
          this.imgButtons.Images.SetKeyName(10, "coins_add.png");
          this.imgButtons.Images.SetKeyName(11, "coins_delete.png");
          this.imgButtons.Images.SetKeyName(12, "b_view.png");
          this.imgButtons.Images.SetKeyName(13, "pdf.png");
          this.imgButtons.Images.SetKeyName(14, "b_edit.png");
          this.imgButtons.Images.SetKeyName(15, "load.png");
          this.imgButtons.Images.SetKeyName(16, "table_refresh.png");
          this.imgButtons.Images.SetKeyName(17, "derivar.png");
          // 
          // progressBar1
          // 
          this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.progressBar1.Location = new System.Drawing.Point(176, 186);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(431, 23);
          this.progressBar1.TabIndex = 20;
          // 
          // frmImportacion
          // 
          this.AcceptButton = this.btnAceptar;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.CancelButton = this.btnCancelar;
          this.ClientSize = new System.Drawing.Size(727, 451);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.toolBar1);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.lblNombreHoja);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.lblDireccion);
          this.Controls.Add(this.cbxAnio);
          this.Controls.Add(this.cbxMes);
          this.Controls.Add(this.btnCancelar);
          this.Controls.Add(this.btnAceptar);
          this.Controls.Add(this.btnLoad);
          this.Controls.Add(this.cbxPex_hoja);
          this.Controls.Add(this.LblExplorar);
          this.Controls.Add(this.LblHoja);
          this.Controls.Add(this.LblPeriodo);
          this.Name = "frmImportacion";
          this.Text = "Importación";
          this.Load += new System.EventHandler(this.frmImportacion_Load);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPeriodo;
        private System.Windows.Forms.Label LblHoja;
        private System.Windows.Forms.Label LblExplorar;
        private System.Windows.Forms.ComboBox cbxPex_hoja;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbxMes;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNombreHoja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        internal System.Windows.Forms.ImageList imgButtons;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}