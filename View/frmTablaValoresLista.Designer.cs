namespace ypfbApplication.View
{
    partial class frmTablaValoresLista
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
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTablaValoresLista));
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.tva_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tab_valcolumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tva_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tva_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.toolBar1 = new System.Windows.Forms.ToolBar();
          this.cmdNew = new System.Windows.Forms.ToolBarButton();
          this.cmdDelete = new System.Windows.Forms.ToolBarButton();
          this.cmdEdit = new System.Windows.Forms.ToolBarButton();
          this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
          this.cmdFind = new System.Windows.Forms.ToolBarButton();
          this.cmdPrint = new System.Windows.Forms.ToolBarButton();
          this.cmdClose = new System.Windows.Forms.ToolBarButton();
          this.imgButtons = new System.Windows.Forms.ImageList(this.components);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          this.SuspendLayout();
          // 
          // dataGridView1
          // 
          this.dataGridView1.AllowUserToAddRows = false;
          this.dataGridView1.AllowUserToDeleteRows = false;
          dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
          this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
          this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.tva_id,
            this.tab_valcolumna,
            this.tva_valor,
            this.tva_estado});
          dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
          dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
          dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
          dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
          dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
          dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
          this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
          this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView1.Location = new System.Drawing.Point(0, 28);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
          dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
          dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
          dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
          dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
          dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
          this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
          this.dataGridView1.RowTemplate.ReadOnly = true;
          this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.dataGridView1.Size = new System.Drawing.Size(492, 538);
          this.dataGridView1.TabIndex = 22;
          this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          // 
          // tva_id
          // 
          this.tva_id.DataPropertyName = "tva_id";
          dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.tva_id.DefaultCellStyle = dataGridViewCellStyle3;
          this.tva_id.HeaderText = "#";
          this.tva_id.Name = "tva_id";
          this.tva_id.ReadOnly = true;
          // 
          // tab_valcolumna
          // 
          this.tab_valcolumna.DataPropertyName = "tab_valcolumna";
          this.tab_valcolumna.HeaderText = "Columna";
          this.tab_valcolumna.Name = "tab_valcolumna";
          this.tab_valcolumna.ReadOnly = true;
          // 
          // tva_valor
          // 
          this.tva_valor.DataPropertyName = "tva_valor";
          dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.tva_valor.DefaultCellStyle = dataGridViewCellStyle4;
          this.tva_valor.HeaderText = "Valor";
          this.tva_valor.Name = "tva_valor";
          this.tva_valor.ReadOnly = true;
          // 
          // tva_estado
          // 
          this.tva_estado.DataPropertyName = "tva_estado";
          this.tva_estado.HeaderText = "Estado";
          this.tva_estado.Name = "tva_estado";
          this.tva_estado.ReadOnly = true;
          // 
          // toolBar1
          // 
          this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
          this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdNew,
            this.cmdDelete,
            this.cmdEdit,
            this.cmdRefresh,
            this.cmdFind,
            this.cmdPrint,
            this.cmdClose});
          this.toolBar1.DropDownArrows = true;
          this.toolBar1.ImageList = this.imgButtons;
          this.toolBar1.Location = new System.Drawing.Point(0, 0);
          this.toolBar1.Name = "toolBar1";
          this.toolBar1.ShowToolTips = true;
          this.toolBar1.Size = new System.Drawing.Size(492, 28);
          this.toolBar1.TabIndex = 21;
          this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
          this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
          // 
          // cmdNew
          // 
          this.cmdNew.ImageIndex = 0;
          this.cmdNew.Name = "cmdNew";
          this.cmdNew.Text = "&Adicionar";
          this.cmdNew.ToolTipText = "Nuevo registro";
          // 
          // cmdDelete
          // 
          this.cmdDelete.Enabled = false;
          this.cmdDelete.ImageIndex = 1;
          this.cmdDelete.Name = "cmdDelete";
          this.cmdDelete.Text = "&Eliminar";
          this.cmdDelete.ToolTipText = "Borrar Seleccionado";
          // 
          // cmdEdit
          // 
          this.cmdEdit.Enabled = false;
          this.cmdEdit.ImageIndex = 14;
          this.cmdEdit.Name = "cmdEdit";
          this.cmdEdit.Text = "&Editar";
          this.cmdEdit.ToolTipText = "Editar";
          // 
          // cmdRefresh
          // 
          this.cmdRefresh.ImageIndex = 3;
          this.cmdRefresh.Name = "cmdRefresh";
          this.cmdRefresh.Text = "A&ctualizar";
          // 
          // cmdFind
          // 
          this.cmdFind.ImageIndex = 4;
          this.cmdFind.Name = "cmdFind";
          this.cmdFind.Text = "&Buscar";
          this.cmdFind.ToolTipText = "Buscar Proyecto";
          // 
          // cmdPrint
          // 
          this.cmdPrint.ImageIndex = 5;
          this.cmdPrint.Name = "cmdPrint";
          this.cmdPrint.Text = "&Imprimir";
          this.cmdPrint.ToolTipText = "Imprimir Proyecto";
          this.cmdPrint.Visible = false;
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
          // frmTablaValoresLista
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(492, 566);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.toolBar1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmTablaValoresLista";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Tabla Valores";
          this.Load += new System.EventHandler(this.frmTablaValoresLista_Load);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        internal System.Windows.Forms.ImageList imgButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn tva_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tab_valcolumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn tva_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tva_estado;
    }
}