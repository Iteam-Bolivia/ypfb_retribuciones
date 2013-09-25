namespace ypfbApplication.View
{
    partial class frmMenuLista
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuLista));
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
          this.men_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_par_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_enlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_posicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.men_par = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
          this.toolBar1.Size = new System.Drawing.Size(492, 28);
          this.toolBar1.TabIndex = 11;
          this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
          this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
          // 
          // cmdNew
          // 
          this.cmdNew.Enabled = false;
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
          // dataGridView1
          // 
          this.dataGridView1.AllowUserToAddRows = false;
          this.dataGridView1.AllowUserToDeleteRows = false;
          dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
          this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
          this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
          this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.men_id,
            this.men_par_name,
            this.men_titulo,
            this.men_enlace,
            this.men_posicion,
            this.men_imagen,
            this.men_estado,
            this.men_par});
          this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView1.Location = new System.Drawing.Point(0, 28);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.dataGridView1.Size = new System.Drawing.Size(492, 538);
          this.dataGridView1.TabIndex = 12;
          this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
          // 
          // men_id
          // 
          this.men_id.DataPropertyName = "Men_id";
          dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.men_id.DefaultCellStyle = dataGridViewCellStyle2;
          this.men_id.HeaderText = "#";
          this.men_id.Name = "men_id";
          this.men_id.ReadOnly = true;
          // 
          // men_par_name
          // 
          this.men_par_name.DataPropertyName = "Men_par_name";
          this.men_par_name.HeaderText = "Menu Padre";
          this.men_par_name.Name = "men_par_name";
          this.men_par_name.ReadOnly = true;
          // 
          // men_titulo
          // 
          this.men_titulo.DataPropertyName = "Men_titulo";
          this.men_titulo.HeaderText = "Nombre";
          this.men_titulo.Name = "men_titulo";
          this.men_titulo.ReadOnly = true;
          // 
          // men_enlace
          // 
          this.men_enlace.DataPropertyName = "Men_enlace";
          this.men_enlace.HeaderText = "Enlace";
          this.men_enlace.Name = "men_enlace";
          this.men_enlace.ReadOnly = true;
          this.men_enlace.Visible = false;
          // 
          // men_posicion
          // 
          this.men_posicion.DataPropertyName = "Men_posicion";
          this.men_posicion.HeaderText = "Posición";
          this.men_posicion.Name = "men_posicion";
          this.men_posicion.ReadOnly = true;
          // 
          // men_imagen
          // 
          this.men_imagen.DataPropertyName = "Men_imagen";
          this.men_imagen.HeaderText = "Imagen";
          this.men_imagen.Name = "men_imagen";
          this.men_imagen.ReadOnly = true;
          // 
          // men_estado
          // 
          this.men_estado.DataPropertyName = "Men_estado";
          dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
          this.men_estado.DefaultCellStyle = dataGridViewCellStyle3;
          this.men_estado.HeaderText = "Estado";
          this.men_estado.Name = "men_estado";
          this.men_estado.ReadOnly = true;
          // 
          // men_par
          // 
          this.men_par.DataPropertyName = "men_par";
          this.men_par.HeaderText = "men_par";
          this.men_par.Name = "men_par";
          this.men_par.ReadOnly = true;
          this.men_par.Visible = false;
          // 
          // frmMenuLista
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(492, 566);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.toolBar1);
          this.Name = "frmMenuLista";
          this.Text = "MENU";
          this.Load += new System.EventHandler(this.frmMenuLista_Load);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ImageList imgButtons;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_par_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_enlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_posicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn men_par;

    }
}