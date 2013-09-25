namespace ypfbApplication.View
{
  partial class frmUsuarioLista
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioLista));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
      this.usu = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.suc_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_fono = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_login = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rol_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usu_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
      this.cmdDelete.ImageIndex = 1;
      this.cmdDelete.Name = "cmdDelete";
      this.cmdDelete.Text = "&Eliminar";
      this.cmdDelete.ToolTipText = "Borrar Seleccionado";
      // 
      // cmdEdit
      // 
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
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usu,
            this.suc_nombre,
            this.usu_nombres,
            this.usu_apellidos,
            this.usu_fono,
            this.usu_email,
            this.usu_login,
            this.rol_titulo,
            this.usu_estado});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 28);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(492, 538);
      this.dataGridView1.TabIndex = 14;
      this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
      this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
      // 
      // usu
      // 
      this.usu.DataPropertyName = "Usu_id";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
      this.usu.DefaultCellStyle = dataGridViewCellStyle2;
      this.usu.HeaderText = "#";
      this.usu.Name = "usu";
      this.usu.ReadOnly = true;
      // 
      // suc_nombre
      // 
      this.suc_nombre.DataPropertyName = "Suc_nombre";
      this.suc_nombre.HeaderText = "Sucursal";
      this.suc_nombre.Name = "suc_nombre";
      this.suc_nombre.ReadOnly = true;
      // 
      // usu_nombres
      // 
      this.usu_nombres.DataPropertyName = "Usu_nombres";
      this.usu_nombres.HeaderText = "Nombres";
      this.usu_nombres.Name = "usu_nombres";
      this.usu_nombres.ReadOnly = true;
      // 
      // usu_apellidos
      // 
      this.usu_apellidos.DataPropertyName = "Usu_apellidos";
      this.usu_apellidos.HeaderText = "Apellidos";
      this.usu_apellidos.Name = "usu_apellidos";
      this.usu_apellidos.ReadOnly = true;
      // 
      // usu_fono
      // 
      this.usu_fono.DataPropertyName = "Usu_fono";
      this.usu_fono.HeaderText = "Teléfono";
      this.usu_fono.Name = "usu_fono";
      this.usu_fono.ReadOnly = true;
      // 
      // usu_email
      // 
      this.usu_email.DataPropertyName = "Usu_email";
      this.usu_email.HeaderText = "Email";
      this.usu_email.Name = "usu_email";
      this.usu_email.ReadOnly = true;
      // 
      // usu_login
      // 
      this.usu_login.DataPropertyName = "Usu_login";
      this.usu_login.HeaderText = "Login";
      this.usu_login.Name = "usu_login";
      this.usu_login.ReadOnly = true;
      // 
      // rol_titulo
      // 
      this.rol_titulo.DataPropertyName = "Rol_titulo";
      this.rol_titulo.HeaderText = "Rol";
      this.rol_titulo.Name = "rol_titulo";
      this.rol_titulo.ReadOnly = true;
      // 
      // usu_estado
      // 
      this.usu_estado.DataPropertyName = "Usu_estado";
      this.usu_estado.HeaderText = "Estado";
      this.usu_estado.Name = "usu_estado";
      this.usu_estado.ReadOnly = true;
      // 
      // frmUsuarioLista
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 566);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.toolBar1);
      this.Name = "frmUsuarioLista";
      this.Text = "USUARIO - LISTA";
      this.Load += new System.EventHandler(this.frmUsuarioLista_Load);
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
    private System.Windows.Forms.DataGridViewTextBoxColumn usu;
    private System.Windows.Forms.DataGridViewTextBoxColumn suc_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_nombres;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_apellidos;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_fono;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_email;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_login;
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_titulo;
    private System.Windows.Forms.DataGridViewTextBoxColumn usu_estado;
  }
}