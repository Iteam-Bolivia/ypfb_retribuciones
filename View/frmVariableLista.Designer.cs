namespace ypfbApplication.View
{
  partial class frmVariableLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVariableLista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.cmdNew = new System.Windows.Forms.ToolBarButton();
            this.cmdEdit = new System.Windows.Forms.ToolBarButton();
            this.cmdDelete = new System.Windows.Forms.ToolBarButton();
            this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
            this.cmdFind = new System.Windows.Forms.ToolBarButton();
            this.cmdPrint = new System.Windows.Forms.ToolBarButton();
            this.cmdClose = new System.Windows.Forms.ToolBarButton();
            this.cmdOrden = new System.Windows.Forms.ToolBarButton();
            this.cmdFormula = new System.Windows.Forms.ToolBarButton();
            this.cmdTotales = new System.Windows.Forms.ToolBarButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcl_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umd_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vard_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mercado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cam_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_imprime_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Var_impresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_codigod = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmdEdit,
            this.cmdDelete,
            this.cmdRefresh,
            this.cmdFind,
            this.cmdPrint,
            this.cmdClose,
            this.cmdOrden,
            this.cmdFormula,
            this.cmdTotales});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imgButtons;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(845, 28);
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
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.ImageIndex = 14;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "&Editar";
            this.cmdEdit.ToolTipText = "Editar";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
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
            this.cmdClose.ImageIndex = 6;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Text = "&Cerrar";
            this.cmdClose.ToolTipText = "Cerrar ventana";
            // 
            // cmdOrden
            // 
            this.cmdOrden.ImageIndex = 15;
            this.cmdOrden.Name = "cmdOrden";
            this.cmdOrden.Text = "Ordenar";
            // 
            // cmdFormula
            // 
            this.cmdFormula.ImageIndex = 7;
            this.cmdFormula.Name = "cmdFormula";
            this.cmdFormula.Text = "Fórmula";
            // 
            // cmdTotales
            // 
            this.cmdTotales.ImageIndex = 16;
            this.cmdTotales.Name = "cmdTotales";
            this.cmdTotales.Text = "Variables Totales";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variable,
            this.tcl_codigo,
            this.var_orden,
            this.var_nombre,
            this.var_codigo,
            this.umd_codigo,
            this.formula,
            this.var_total,
            this.vard_codigo,
            this.producto,
            this.mercado,
            this.cam_nombre,
            this.var_imprime_text,
            this.Var_impresion,
            this.var_codigod});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(845, 538);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // variable
            // 
            this.variable.DataPropertyName = "Var_id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.variable.DefaultCellStyle = dataGridViewCellStyle2;
            this.variable.HeaderText = "#";
            this.variable.Name = "variable";
            this.variable.ReadOnly = true;
            // 
            // tcl_codigo
            // 
            this.tcl_codigo.DataPropertyName = "Tcl_codigo";
            this.tcl_codigo.HeaderText = "Tipo de Proceso";
            this.tcl_codigo.Name = "tcl_codigo";
            this.tcl_codigo.ReadOnly = true;
            // 
            // var_orden
            // 
            this.var_orden.DataPropertyName = "Var_orden";
            this.var_orden.HeaderText = "Orden de Proceso";
            this.var_orden.Name = "var_orden";
            this.var_orden.ReadOnly = true;
            // 
            // var_nombre
            // 
            this.var_nombre.DataPropertyName = "Var_descripcion";
            this.var_nombre.HeaderText = "Variable Descripción";
            this.var_nombre.Name = "var_nombre";
            this.var_nombre.ReadOnly = true;
            // 
            // var_codigo
            // 
            this.var_codigo.DataPropertyName = "Var_codigo";
            this.var_codigo.HeaderText = "Variable";
            this.var_codigo.Name = "var_codigo";
            this.var_codigo.ReadOnly = true;
            // 
            // umd_codigo
            // 
            this.umd_codigo.DataPropertyName = "Umd_codigo";
            this.umd_codigo.HeaderText = "Unidad";
            this.umd_codigo.Name = "umd_codigo";
            this.umd_codigo.ReadOnly = true;
            // 
            // formula
            // 
            this.formula.DataPropertyName = "Formula";
            this.formula.HeaderText = "Fórmula";
            this.formula.Name = "formula";
            this.formula.ReadOnly = true;
            // 
            // var_total
            // 
            this.var_total.DataPropertyName = "Var_total";
            this.var_total.HeaderText = "Tipo de Variable";
            this.var_total.Name = "var_total";
            this.var_total.ReadOnly = true;
            // 
            // vard_codigo
            // 
            this.vard_codigo.DataPropertyName = "Vard_codigo";
            this.vard_codigo.HeaderText = "Dependencia";
            this.vard_codigo.Name = "vard_codigo";
            this.vard_codigo.ReadOnly = true;
            // 
            // producto
            // 
            this.producto.DataPropertyName = "Producto";
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // mercado
            // 
            this.mercado.DataPropertyName = "Mercado";
            this.mercado.HeaderText = "Mercado";
            this.mercado.Name = "mercado";
            this.mercado.ReadOnly = true;
            // 
            // cam_nombre
            // 
            this.cam_nombre.DataPropertyName = "Cam_nombre";
            this.cam_nombre.HeaderText = "Campo";
            this.cam_nombre.Name = "cam_nombre";
            this.cam_nombre.ReadOnly = true;
            // 
            // var_imprime_text
            // 
            this.var_imprime_text.DataPropertyName = "Var_imprime_text";
            this.var_imprime_text.HeaderText = "Imprime";
            this.var_imprime_text.Name = "var_imprime_text";
            this.var_imprime_text.ReadOnly = true;
            // 
            // Var_impresion
            // 
            this.Var_impresion.DataPropertyName = "Impresionaux";
            this.Var_impresion.HeaderText = "Orden Impresión";
            this.Var_impresion.Name = "Var_impresion";
            this.Var_impresion.ReadOnly = true;
            // 
            // var_codigod
            // 
            this.var_codigod.DataPropertyName = "Var_codigod";
            this.var_codigod.HeaderText = "Línea Impresión";
            this.var_codigod.Name = "var_codigod";
            this.var_codigod.ReadOnly = true;
            // 
            // frmVariableLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 566);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmVariableLista";
            this.Text = "VARIABLE - LISTA";
            this.Load += new System.EventHandler(this.frmVariableLista_Load);
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
    private System.Windows.Forms.ToolBarButton cmdFormula;
    private System.Windows.Forms.ToolBarButton cmdOrden;
    private System.Windows.Forms.ToolBarButton cmdTotales;
    private System.Windows.Forms.DataGridViewTextBoxColumn variable;
    private System.Windows.Forms.DataGridViewTextBoxColumn tcl_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_orden;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn umd_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn formula;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_total;
    private System.Windows.Forms.DataGridViewTextBoxColumn vard_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn producto;
    private System.Windows.Forms.DataGridViewTextBoxColumn mercado;
    private System.Windows.Forms.DataGridViewTextBoxColumn cam_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_imprime_text;
    private System.Windows.Forms.DataGridViewTextBoxColumn Var_impresion;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_codigod;
  }
}