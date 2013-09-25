
namespace ypfbApplication.View
{
  partial class frmCalculoListaProyeccion
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculoListaProyeccion));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.imgButtons = new System.Windows.Forms.ImageList(this.components);
      this.toolBar1 = new System.Windows.Forms.ToolBar();
      this.cmdNew = new System.Windows.Forms.ToolBarButton();
      this.cmdEdit = new System.Windows.Forms.ToolBarButton();
      this.cmdDelete = new System.Windows.Forms.ToolBarButton();
      this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
      this.cmdFind = new System.Windows.Forms.ToolBarButton();
      this.cmdPrint = new System.Windows.Forms.ToolBarButton();
      this.cmdClose = new System.Windows.Forms.ToolBarButton();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.Cal_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ct_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cal_nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tcl_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.an_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cal_mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ctt_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ctt_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cal_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cal_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cal_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmdClose});
      this.toolBar1.DropDownArrows = true;
      this.toolBar1.ImageList = this.imgButtons;
      this.toolBar1.Location = new System.Drawing.Point(0, 0);
      this.toolBar1.Name = "toolBar1";
      this.toolBar1.ShowToolTips = true;
      this.toolBar1.Size = new System.Drawing.Size(492, 50);
      this.toolBar1.TabIndex = 11;
      this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
      // 
      // cmdNew
      // 
      this.cmdNew.ImageIndex = 0;
      this.cmdNew.Name = "cmdNew";
      this.cmdNew.Text = "&Nueva Proyección Cálculo";
      this.cmdNew.ToolTipText = "Nuevo registro";
      // 
      // cmdEdit
      // 
      this.cmdEdit.Enabled = false;
      this.cmdEdit.ImageIndex = 14;
      this.cmdEdit.Name = "cmdEdit";
      this.cmdEdit.Text = "&Recalcular";
      this.cmdEdit.ToolTipText = "Realizar el Recalculo";
      this.cmdEdit.Visible = false;
      // 
      // cmdDelete
      // 
      this.cmdDelete.Enabled = false;
      this.cmdDelete.ImageIndex = 1;
      this.cmdDelete.Name = "cmdDelete";
      this.cmdDelete.Text = "&Eliminar";
      this.cmdDelete.ToolTipText = "Borrar Seleccionado";
      this.cmdDelete.Visible = false;
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
      this.cmdFind.Text = "&Buscar Cálculo";
      this.cmdFind.ToolTipText = "Buscar Proyecto";
      // 
      // cmdPrint
      // 
      this.cmdPrint.Enabled = false;
      this.cmdPrint.ImageIndex = 13;
      this.cmdPrint.Name = "cmdPrint";
      this.cmdPrint.Text = "&Imprimir";
      this.cmdPrint.ToolTipText = "Imprimir Proyecto";
      // 
      // cmdClose
      // 
      this.cmdClose.ImageIndex = 6;
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
            this.Cal_id,
            this.ct_id,
            this.Cal_nro,
            this.tcl_codigo,
            this.an_id,
            this.Cal_mes,
            this.ctt_codigo,
            this.ctt_nombre,
            this.cal_fecha,
            this.cal_valor,
            this.cal_estado});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 50);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(492, 516);
      this.dataGridView1.TabIndex = 15;
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
      this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
      this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
      this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
      this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
      // 
      // Cal_id
      // 
      this.Cal_id.DataPropertyName = "Cal_id";
      this.Cal_id.HeaderText = "#";
      this.Cal_id.Name = "Cal_id";
      this.Cal_id.ReadOnly = true;
      // 
      // ct_id
      // 
      this.ct_id.DataPropertyName = "Ctt_id";
      this.ct_id.HeaderText = "Contrato Id.";
      this.ct_id.Name = "ct_id";
      this.ct_id.ReadOnly = true;
      this.ct_id.Visible = false;
      // 
      // Cal_nro
      // 
      this.Cal_nro.DataPropertyName = "Cal_nro";
      this.Cal_nro.HeaderText = "Nro.";
      this.Cal_nro.Name = "Cal_nro";
      this.Cal_nro.ReadOnly = true;
      // 
      // tcl_codigo
      // 
      this.tcl_codigo.DataPropertyName = "Tcl_codigo";
      this.tcl_codigo.HeaderText = "Tipo Proceso";
      this.tcl_codigo.Name = "tcl_codigo";
      this.tcl_codigo.ReadOnly = true;
      // 
      // an_id
      // 
      this.an_id.DataPropertyName = "Ani_id";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.an_id.DefaultCellStyle = dataGridViewCellStyle2;
      this.an_id.HeaderText = "Año";
      this.an_id.Name = "an_id";
      this.an_id.ReadOnly = true;
      // 
      // Cal_mes
      // 
      this.Cal_mes.DataPropertyName = "Cal_mes";
      this.Cal_mes.HeaderText = "Mes";
      this.Cal_mes.Name = "Cal_mes";
      this.Cal_mes.ReadOnly = true;
      // 
      // ctt_codigo
      // 
      this.ctt_codigo.DataPropertyName = "Ctt_codigo";
      this.ctt_codigo.HeaderText = "Código";
      this.ctt_codigo.Name = "ctt_codigo";
      this.ctt_codigo.ReadOnly = true;
      this.ctt_codigo.Visible = false;
      // 
      // ctt_nombre
      // 
      this.ctt_nombre.DataPropertyName = "Ctt_nombre";
      this.ctt_nombre.HeaderText = "Nombre Contrato";
      this.ctt_nombre.Name = "ctt_nombre";
      this.ctt_nombre.ReadOnly = true;
      // 
      // cal_fecha
      // 
      this.cal_fecha.DataPropertyName = "Cal_fecha";
      this.cal_fecha.HeaderText = "Fecha";
      this.cal_fecha.Name = "cal_fecha";
      this.cal_fecha.ReadOnly = true;
      // 
      // cal_valor
      // 
      this.cal_valor.DataPropertyName = "cal_valor";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.cal_valor.DefaultCellStyle = dataGridViewCellStyle3;
      this.cal_valor.HeaderText = "Valor";
      this.cal_valor.Name = "cal_valor";
      this.cal_valor.ReadOnly = true;
      // 
      // cal_estado
      // 
      this.cal_estado.DataPropertyName = "Cal_estado";
      this.cal_estado.HeaderText = "Estado";
      this.cal_estado.Name = "cal_estado";
      this.cal_estado.ReadOnly = true;
      // 
      // frmCalculoListaProyeccion
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 566);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.toolBar1);
      this.Name = "frmCalculoListaProyeccion";
      this.Text = "LISTA - PROYECCIONES";
      this.Load += new System.EventHandler(this.frmCalculoListaProyeccion_Load);
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
    private System.Windows.Forms.DataGridViewTextBoxColumn Cal_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn ct_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cal_nro;
    private System.Windows.Forms.DataGridViewTextBoxColumn tcl_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn an_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cal_mes;
    private System.Windows.Forms.DataGridViewTextBoxColumn ctt_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn ctt_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn cal_fecha;
    private System.Windows.Forms.DataGridViewTextBoxColumn cal_valor;
    private System.Windows.Forms.DataGridViewTextBoxColumn cal_estado;
  }
}