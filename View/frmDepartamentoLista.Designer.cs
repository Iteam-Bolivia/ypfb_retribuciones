namespace ypfbApplication.View
{
  partial class frmDepartamentoLista
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartamentoLista));
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
      this.dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dep_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dep_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dep_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
      this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dep,
            this.dep_codigo,
            this.dep_nombre,
            this.dep_estado});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 28);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(492, 538);
      this.dataGridView1.TabIndex = 14;
      this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
      this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
      // 
      // dep
      // 
      this.dep.DataPropertyName = "Dep_id";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
      this.dep.DefaultCellStyle = dataGridViewCellStyle2;
      this.dep.FillWeight = 39.54178F;
      this.dep.HeaderText = "#";
      this.dep.Name = "dep";
      // 
      // dep_codigo
      // 
      this.dep_codigo.DataPropertyName = "Dep_codigo";
      this.dep_codigo.FillWeight = 159.9245F;
      this.dep_codigo.HeaderText = "Código";
      this.dep_codigo.Name = "dep_codigo";
      // 
      // dep_nombre
      // 
      this.dep_nombre.DataPropertyName = "Dep_nombre";
      this.dep_nombre.FillWeight = 159.9245F;
      this.dep_nombre.HeaderText = "Nombre";
      this.dep_nombre.Name = "dep_nombre";
      // 
      // dep_estado
      // 
      this.dep_estado.DataPropertyName = "Dep_estado";
      this.dep_estado.FillWeight = 40.60914F;
      this.dep_estado.HeaderText = "Estado";
      this.dep_estado.Name = "dep_estado";
      // 
      // frmDepartamentoLista
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 566);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.toolBar1);
      this.Name = "frmDepartamentoLista";
      this.Text = "DEPARTAMENTO";
      this.Load += new System.EventHandler(this.frmDepartamentoLista_Load);
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
    private System.Windows.Forms.DataGridViewTextBoxColumn dep;
    private System.Windows.Forms.DataGridViewTextBoxColumn dep_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn dep_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn dep_estado;
  }
}