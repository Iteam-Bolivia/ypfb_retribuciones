namespace ypfbApplication.View
{
    partial class frmRegaliaLista
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegaliaLista));
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
          this.imgButtons = new System.Windows.Forms.ImageList(this.components);
          this.toolBar1 = new System.Windows.Forms.ToolBar();
          this.cmdNew = new System.Windows.Forms.ToolBarButton();
          this.cmdDelete = new System.Windows.Forms.ToolBarButton();
          this.cmdEdit = new System.Windows.Forms.ToolBarButton();
          this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
          this.cmdFind = new System.Windows.Forms.ToolBarButton();
          this.cmdPrint = new System.Windows.Forms.ToolBarButton();
          this.cmdClose = new System.Windows.Forms.ToolBarButton();
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.reg_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.ctt_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.ani_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.mes_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.mon_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_tiponombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_gasmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_gasme = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_crudomi = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_crudome = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_glp = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.reg_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
          this.toolBar1.Size = new System.Drawing.Size(692, 28);
          this.toolBar1.TabIndex = 10;
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
            this.reg_id,
            this.ctt_nombre,
            this.ani_id,
            this.mes_nombre,
            this.mon_nombre,
            this.reg_tiponombre,
            this.reg_gasmi,
            this.reg_gasme,
            this.reg_crudomi,
            this.reg_crudome,
            this.reg_glp,
            this.reg_total,
            this.reg_estado});
          dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
          dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
          dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
          dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
          dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
          dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
          this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
          this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView1.Location = new System.Drawing.Point(0, 28);
          this.dataGridView1.MultiSelect = false;
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
          this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.dataGridView1.Size = new System.Drawing.Size(692, 718);
          this.dataGridView1.TabIndex = 14;
          this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
          this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
          // 
          // reg_id
          // 
          this.reg_id.DataPropertyName = "reg_id";
          dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_id.DefaultCellStyle = dataGridViewCellStyle2;
          this.reg_id.HeaderText = "#";
          this.reg_id.Name = "reg_id";
          this.reg_id.ReadOnly = true;
          // 
          // ctt_nombre
          // 
          this.ctt_nombre.DataPropertyName = "ctt_nombre";
          this.ctt_nombre.HeaderText = "Contrato";
          this.ctt_nombre.Name = "ctt_nombre";
          this.ctt_nombre.ReadOnly = true;
          this.ctt_nombre.Visible = false;
          // 
          // ani_id
          // 
          this.ani_id.DataPropertyName = "Ani_id";
          this.ani_id.HeaderText = "Año";
          this.ani_id.Name = "ani_id";
          this.ani_id.ReadOnly = true;
          // 
          // mes_nombre
          // 
          this.mes_nombre.DataPropertyName = "Mes_nombre";
          this.mes_nombre.HeaderText = "Mes";
          this.mes_nombre.Name = "mes_nombre";
          this.mes_nombre.ReadOnly = true;
          // 
          // mon_nombre
          // 
          this.mon_nombre.DataPropertyName = "Mon_nombre";
          this.mon_nombre.HeaderText = "Moneda";
          this.mon_nombre.Name = "mon_nombre";
          this.mon_nombre.ReadOnly = true;
          // 
          // reg_tiponombre
          // 
          this.reg_tiponombre.DataPropertyName = "reg_tiponombre";
          this.reg_tiponombre.HeaderText = "Tipo";
          this.reg_tiponombre.Name = "reg_tiponombre";
          this.reg_tiponombre.ReadOnly = true;
          // 
          // reg_gasmi
          // 
          this.reg_gasmi.DataPropertyName = "reg_gasmi";
          dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_gasmi.DefaultCellStyle = dataGridViewCellStyle3;
          this.reg_gasmi.HeaderText = "Gas M.I.";
          this.reg_gasmi.Name = "reg_gasmi";
          this.reg_gasmi.ReadOnly = true;
          // 
          // reg_gasme
          // 
          this.reg_gasme.DataPropertyName = "reg_gasme";
          dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_gasme.DefaultCellStyle = dataGridViewCellStyle4;
          this.reg_gasme.HeaderText = "Gas M.E.";
          this.reg_gasme.Name = "reg_gasme";
          this.reg_gasme.ReadOnly = true;
          // 
          // reg_crudomi
          // 
          this.reg_crudomi.DataPropertyName = "reg_crudomi";
          dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_crudomi.DefaultCellStyle = dataGridViewCellStyle5;
          this.reg_crudomi.HeaderText = "Crudo M.I.";
          this.reg_crudomi.Name = "reg_crudomi";
          this.reg_crudomi.ReadOnly = true;
          // 
          // reg_crudome
          // 
          this.reg_crudome.DataPropertyName = "reg_crudome";
          dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_crudome.DefaultCellStyle = dataGridViewCellStyle6;
          this.reg_crudome.HeaderText = "Crudo M.E.";
          this.reg_crudome.Name = "reg_crudome";
          this.reg_crudome.ReadOnly = true;
          // 
          // reg_glp
          // 
          this.reg_glp.DataPropertyName = "reg_glp";
          dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_glp.DefaultCellStyle = dataGridViewCellStyle7;
          this.reg_glp.HeaderText = "GLP";
          this.reg_glp.Name = "reg_glp";
          this.reg_glp.ReadOnly = true;
          // 
          // reg_total
          // 
          this.reg_total.DataPropertyName = "reg_total";
          dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.reg_total.DefaultCellStyle = dataGridViewCellStyle8;
          this.reg_total.HeaderText = "Total";
          this.reg_total.Name = "reg_total";
          this.reg_total.ReadOnly = true;
          // 
          // reg_estado
          // 
          this.reg_estado.DataPropertyName = "Reg_estado";
          this.reg_estado.HeaderText = "Estado";
          this.reg_estado.Name = "reg_estado";
          this.reg_estado.ReadOnly = true;
          // 
          // frmRegaliaLista
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(692, 746);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.toolBar1);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmRegaliaLista";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Regalías";
          this.Load += new System.EventHandler(this.frmRegaliaLista_Load);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ImageList imgButtons;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ani_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn mon_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_tiponombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_gasmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_gasme;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_crudomi;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_crudome;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_glp;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_estado;
    }
}