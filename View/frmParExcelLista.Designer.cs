namespace ypfbApplication.View
{
    partial class frmParExcelLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParExcelLista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pex_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pex_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pex_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tca_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pxt_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pex_hoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.cmdNew = new System.Windows.Forms.ToolBarButton();
            this.cmdEdit = new System.Windows.Forms.ToolBarButton();
            this.cmdDelete = new System.Windows.Forms.ToolBarButton();
            this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
            this.cmdFind = new System.Windows.Forms.ToolBarButton();
            this.cmdPrint = new System.Windows.Forms.ToolBarButton();
            this.cmdClose = new System.Windows.Forms.ToolBarButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolBar2 = new System.Windows.Forms.ToolBar();
            this.cmdNewColumn = new System.Windows.Forms.ToolBarButton();
            this.cmdEditColumn = new System.Windows.Forms.ToolBarButton();
            this.cmdDeleteColumn = new System.Windows.Forms.ToolBarButton();
            this.cmdRefreshColumn = new System.Windows.Forms.ToolBarButton();
            this.cmdFindColumn = new System.Windows.Forms.ToolBarButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pec_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pec_fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pec_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tco_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umd_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pec_Convercion_string = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mer_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pec_iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.toolBar2);
            this.splitContainer1.Size = new System.Drawing.Size(492, 566);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pex_id1,
            this.Pex_codigo,
            this.pex_nombre,
            this.tca_nombre,
            this.pxt_codigo,
            this.pex_hoja,
            this.pro_nombre});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(492, 148);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // pex_id1
            // 
            this.pex_id1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pex_id1.DataPropertyName = "pex_id";
            this.pex_id1.HeaderText = "#";
            this.pex_id1.Name = "pex_id1";
            this.pex_id1.ReadOnly = true;
            // 
            // Pex_codigo
            // 
            this.Pex_codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pex_codigo.DataPropertyName = "Pex_codigo";
            this.Pex_codigo.HeaderText = "Código de página ";
            this.Pex_codigo.Name = "Pex_codigo";
            this.Pex_codigo.ReadOnly = true;
            this.Pex_codigo.Visible = false;
            // 
            // pex_nombre
            // 
            this.pex_nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pex_nombre.DataPropertyName = "Pex_nombre";
            this.pex_nombre.HeaderText = "Nombre de hoja";
            this.pex_nombre.Name = "pex_nombre";
            this.pex_nombre.ReadOnly = true;
            // 
            // tca_nombre
            // 
            this.tca_nombre.DataPropertyName = "tcl_nombre";
            this.tca_nombre.HeaderText = "Tipo Calculo";
            this.tca_nombre.Name = "tca_nombre";
            this.tca_nombre.ReadOnly = true;
            // 
            // pxt_codigo
            // 
            this.pxt_codigo.DataPropertyName = "pxt_codigo";
            this.pxt_codigo.HeaderText = "Tipo de Carga";
            this.pxt_codigo.Name = "pxt_codigo";
            this.pxt_codigo.ReadOnly = true;
            // 
            // pex_hoja
            // 
            this.pex_hoja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pex_hoja.DataPropertyName = "pex_hoja";
            this.pex_hoja.HeaderText = "Nombre Hoja de Excel";
            this.pex_hoja.Name = "pex_hoja";
            this.pex_hoja.ReadOnly = true;
            this.pex_hoja.Visible = false;
            // 
            // pro_nombre
            // 
            this.pro_nombre.DataPropertyName = "pro_nombre";
            this.pro_nombre.HeaderText = "Producto";
            this.pro_nombre.Name = "pro_nombre";
            this.pro_nombre.ReadOnly = true;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdNew,
            this.cmdEdit,
            this.cmdDelete,
            this.cmdRefresh,
            this.cmdFind,
            this.cmdPrint,
            this.cmdClose});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imgButtons;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(492, 50);
            this.toolBar1.TabIndex = 16;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // cmdNew
            // 
            this.cmdNew.ImageIndex = 0;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Text = "&Nuevo";
            this.cmdNew.ToolTipText = "Nuevo registro";
            // 
            // cmdEdit
            // 
            this.cmdEdit.ImageIndex = 14;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "&Editar";
            this.cmdEdit.ToolTipText = "Editar";
            // 
            // cmdDelete
            // 
            this.cmdDelete.ImageIndex = 1;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "&Eliminar";
            this.cmdDelete.ToolTipText = "Borrar Seleccionado";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.ImageIndex = 3;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Text = "A&ctualizar";
            // 
            // cmdFind
            // 
            this.cmdFind.ImageIndex = 12;
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
            // 
            // cmdClose
            // 
            this.cmdClose.ImageIndex = 7;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Text = "&Cerrar";
            this.cmdClose.ToolTipText = "Cerrar ventana";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pec_id,
            this.pec_fila,
            this.pec_columna,
            this.tco_nombre,
            this.var_codigo,
            this.val_descripcion,
            this.umd_nombre,
            this.pec_Convercion_string,
            this.mer_nombre,
            this.pec_iva});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(492, 336);
            this.dataGridView2.TabIndex = 19;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // toolBar2
            // 
            this.toolBar2.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdNewColumn,
            this.cmdEditColumn,
            this.cmdDeleteColumn,
            this.cmdRefreshColumn,
            this.cmdFindColumn});
            this.toolBar2.DropDownArrows = true;
            this.toolBar2.ImageList = this.imgButtons;
            this.toolBar2.Location = new System.Drawing.Point(0, 0);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.ShowToolTips = true;
            this.toolBar2.Size = new System.Drawing.Size(492, 28);
            this.toolBar2.TabIndex = 18;
            this.toolBar2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar2_ButtonClick);
            // 
            // cmdNewColumn
            // 
            this.cmdNewColumn.ImageIndex = 0;
            this.cmdNewColumn.Name = "cmdNewColumn";
            this.cmdNewColumn.Text = "&Nuevo";
            this.cmdNewColumn.ToolTipText = "Nuevo registro";
            // 
            // cmdEditColumn
            // 
            this.cmdEditColumn.ImageIndex = 14;
            this.cmdEditColumn.Name = "cmdEditColumn";
            this.cmdEditColumn.Text = "&Editar";
            this.cmdEditColumn.ToolTipText = "Editar";
            // 
            // cmdDeleteColumn
            // 
            this.cmdDeleteColumn.ImageIndex = 1;
            this.cmdDeleteColumn.Name = "cmdDeleteColumn";
            this.cmdDeleteColumn.Text = "&Eliminar";
            this.cmdDeleteColumn.ToolTipText = "Borrar Seleccionado";
            // 
            // cmdRefreshColumn
            // 
            this.cmdRefreshColumn.ImageIndex = 3;
            this.cmdRefreshColumn.Name = "cmdRefreshColumn";
            this.cmdRefreshColumn.Text = "A&ctualizar";
            // 
            // cmdFindColumn
            // 
            this.cmdFindColumn.ImageIndex = 12;
            this.cmdFindColumn.Name = "cmdFindColumn";
            this.cmdFindColumn.Text = "&Buscar";
            this.cmdFindColumn.ToolTipText = "Buscar Proyecto";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pec_id
            // 
            this.pec_id.DataPropertyName = "pec_id";
            this.pec_id.HeaderText = "#";
            this.pec_id.Name = "pec_id";
            this.pec_id.ReadOnly = true;
            // 
            // pec_fila
            // 
            this.pec_fila.DataPropertyName = "pec_fila";
            this.pec_fila.HeaderText = "Fila";
            this.pec_fila.Name = "pec_fila";
            this.pec_fila.ReadOnly = true;
            // 
            // pec_columna
            // 
            this.pec_columna.DataPropertyName = "pec_columna";
            this.pec_columna.HeaderText = "Columna";
            this.pec_columna.Name = "pec_columna";
            this.pec_columna.ReadOnly = true;
            // 
            // tco_nombre
            // 
            this.tco_nombre.DataPropertyName = "tco_nombre";
            this.tco_nombre.HeaderText = "Tipo columna";
            this.tco_nombre.Name = "tco_nombre";
            this.tco_nombre.ReadOnly = true;
            this.tco_nombre.Visible = false;
            // 
            // var_codigo
            // 
            this.var_codigo.DataPropertyName = "var_codigo";
            this.var_codigo.HeaderText = "Variable";
            this.var_codigo.Name = "var_codigo";
            this.var_codigo.ReadOnly = true;
            // 
            // val_descripcion
            // 
            this.val_descripcion.DataPropertyName = "var_descripcion";
            this.val_descripcion.HeaderText = "Descripción Variable";
            this.val_descripcion.Name = "val_descripcion";
            this.val_descripcion.ReadOnly = true;
            // 
            // umd_nombre
            // 
            this.umd_nombre.DataPropertyName = "Umd_nombre";
            this.umd_nombre.HeaderText = "Unidad";
            this.umd_nombre.Name = "umd_nombre";
            this.umd_nombre.ReadOnly = true;
            // 
            // pec_Convercion_string
            // 
            this.pec_Convercion_string.DataPropertyName = "pec_Convercion_string";
            this.pec_Convercion_string.HeaderText = "Convercion";
            this.pec_Convercion_string.Name = "pec_Convercion_string";
            this.pec_Convercion_string.ReadOnly = true;
            // 
            // mer_nombre
            // 
            this.mer_nombre.DataPropertyName = "Mer_nombre";
            this.mer_nombre.HeaderText = "Mercado";
            this.mer_nombre.Name = "mer_nombre";
            this.mer_nombre.ReadOnly = true;
            // 
            // pec_iva
            // 
            this.pec_iva.DataPropertyName = "pec_iva";
            this.pec_iva.HeaderText = "Iva";
            this.pec_iva.Name = "pec_iva";
            this.pec_iva.ReadOnly = true;
            // 
            // frmParExcelLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmParExcelLista";
            this.Text = "Parametricas Excel";
            this.Load += new System.EventHandler(this.frmParExcelLista_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList imgButtons;

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        private System.Windows.Forms.DataGridView dataGridView2;
        internal System.Windows.Forms.ToolBar toolBar2;
        internal System.Windows.Forms.ToolBarButton cmdNewColumn;
        private System.Windows.Forms.ToolBarButton cmdEditColumn;
        private System.Windows.Forms.ToolBarButton cmdDeleteColumn;
        private System.Windows.Forms.ToolBarButton cmdRefreshColumn;
        internal System.Windows.Forms.ToolBarButton cmdFindColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pex_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pex_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pex_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tca_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn pxt_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pex_hoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_nombre;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pec_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pec_fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn pec_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn tco_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn val_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn umd_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn pec_Convercion_string;
        private System.Windows.Forms.DataGridViewTextBoxColumn mer_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn pec_iva;
    }
}