namespace ypfbApplication.View
{
    partial class frmContrato_MarginalLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContrato_MarginalLista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.cmdNew = new System.Windows.Forms.ToolBarButton();
            this.cmdDelete = new System.Windows.Forms.ToolBarButton();
            this.cmdEdit = new System.Windows.Forms.ToolBarButton();
            this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
            this.cmdFind = new System.Windows.Forms.ToolBarButton();
            this.cmdPrint = new System.Windows.Forms.ToolBarButton();
            this.cmdClose = new System.Windows.Forms.ToolBarButton();
            this.cma_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anio_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cma_mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cma_anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cma_id,
            this.Mes_ini,
            this.Anio_ini,
            this.Cma_mes,
            this.cma_anio});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(803, 375);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
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
            this.toolBar1.Size = new System.Drawing.Size(803, 28);
            this.toolBar1.TabIndex = 17;
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
            this.cmdFind.Visible = false;
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
            // cma_id
            // 
            this.cma_id.DataPropertyName = "Cma_id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.cma_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.cma_id.HeaderText = "#";
            this.cma_id.Name = "cma_id";
            this.cma_id.ReadOnly = true;
            // 
            // Mes_ini
            // 
            this.Mes_ini.DataPropertyName = "Cma_mes_ini";
            this.Mes_ini.HeaderText = "Mes inicial";
            this.Mes_ini.Name = "Mes_ini";
            this.Mes_ini.ReadOnly = true;
            // 
            // Anio_ini
            // 
            this.Anio_ini.DataPropertyName = "Cma_anio_ini";
            this.Anio_ini.HeaderText = "Año inicial";
            this.Anio_ini.Name = "Anio_ini";
            this.Anio_ini.ReadOnly = true;
            // 
            // Cma_mes
            // 
            this.Cma_mes.DataPropertyName = "Cma_mes";
            this.Cma_mes.HeaderText = "Mes fina";
            this.Cma_mes.Name = "Cma_mes";
            this.Cma_mes.ReadOnly = true;
            // 
            // cma_anio
            // 
            this.cma_anio.DataPropertyName = "Cma_anio";
            this.cma_anio.HeaderText = "Año final";
            this.cma_anio.Name = "cma_anio";
            this.cma_anio.ReadOnly = true;
            // 
            // frmContrato_MarginalLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 403);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmContrato_MarginalLista";
            this.Text = "frmContrato_MarginalLista";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmContrato_MarginalLista_FormClosed);
            this.Load += new System.EventHandler(this.frmContrato_MarginalLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ImageList imgButtons;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cma_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anio_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cma_mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cma_anio;

    }
}