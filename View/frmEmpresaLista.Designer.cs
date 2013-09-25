namespace ypfbApplication.View
{
  partial class frmEmpresaLista
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresaLista));
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
        this.emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_propietario = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.emp_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
        this.cmdNew.Visible = false;
        // 
        // cmdDelete
        // 
        this.cmdDelete.ImageIndex = 1;
        this.cmdDelete.Name = "cmdDelete";
        this.cmdDelete.Text = "&Eliminar";
        this.cmdDelete.ToolTipText = "Borrar Seleccionado";
        this.cmdDelete.Visible = false;
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
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emp,
            this.emp_nit,
            this.emp_nombre,
            this.emp_propietario,
            this.emp_dir,
            this.emp_telefono,
            this.emp_email,
            this.emp_estado});
        this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dataGridView1.Location = new System.Drawing.Point(0, 28);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.Size = new System.Drawing.Size(492, 538);
        this.dataGridView1.TabIndex = 11;
        this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
        this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
        this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
        // 
        // emp
        // 
        this.emp.DataPropertyName = "Emp_id";
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
        this.emp.DefaultCellStyle = dataGridViewCellStyle2;
        this.emp.HeaderText = "#";
        this.emp.Name = "emp";
        this.emp.Width = 50;
        // 
        // emp_nit
        // 
        this.emp_nit.DataPropertyName = "Emp_nit";
        this.emp_nit.HeaderText = "NIT";
        this.emp_nit.Name = "emp_nit";
        // 
        // emp_nombre
        // 
        this.emp_nombre.DataPropertyName = "Emp_nombre";
        this.emp_nombre.HeaderText = "Nombre";
        this.emp_nombre.Name = "emp_nombre";
        this.emp_nombre.Width = 120;
        // 
        // emp_propietario
        // 
        this.emp_propietario.DataPropertyName = "Emp_propietario";
        this.emp_propietario.HeaderText = "Propietario";
        this.emp_propietario.Name = "emp_propietario";
        this.emp_propietario.Width = 120;
        // 
        // emp_dir
        // 
        this.emp_dir.DataPropertyName = "Emp_dir";
        this.emp_dir.HeaderText = "Dirección";
        this.emp_dir.Name = "emp_dir";
        // 
        // emp_telefono
        // 
        this.emp_telefono.DataPropertyName = "Emp_telefono";
        this.emp_telefono.HeaderText = "Teléfono";
        this.emp_telefono.Name = "emp_telefono";
        this.emp_telefono.Width = 120;
        // 
        // emp_email
        // 
        this.emp_email.DataPropertyName = "Emp_email";
        this.emp_email.HeaderText = "Email";
        this.emp_email.Name = "emp_email";
        // 
        // emp_estado
        // 
        this.emp_estado.DataPropertyName = "Emp_estado";
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
        this.emp_estado.DefaultCellStyle = dataGridViewCellStyle3;
        this.emp_estado.HeaderText = "Estado";
        this.emp_estado.Name = "emp_estado";
        // 
        // frmEmpresaLista
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(492, 566);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.toolBar1);
        this.Name = "frmEmpresaLista";
        this.Text = "EMPRESA";
        this.Load += new System.EventHandler(this.frmEmpresaLista_Load);
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
    private System.Windows.Forms.DataGridViewTextBoxColumn emp;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_nit;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_propietario;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_dir;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_telefono;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_email;
    private System.Windows.Forms.DataGridViewTextBoxColumn emp_estado;
  }
}