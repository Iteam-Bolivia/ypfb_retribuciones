
namespace ypfbApplication.View
{
  partial class frmCalculoVariableLista
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculoVariableLista));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.imgButtons = new System.Windows.Forms.ImageList(this.components);
      this.toolBar1 = new System.Windows.Forms.ToolBar();
      this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
      this.cmdFind = new System.Windows.Forms.ToolBarButton();
      this.cmdClose = new System.Windows.Forms.ToolBarButton();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.Cav_nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ctt_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cav_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ani_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cav_mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.var_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.var_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cav_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.umd_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmdRefresh,
            this.cmdFind,
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
            this.Cav_nro,
            this.ctt_nombre,
            this.cav_tipo,
            this.ani_id,
            this.cav_mes,
            this.var_codigo,
            this.var_nombre,
            this.cav_valor,
            this.umd_codigo});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 28);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(492, 538);
      this.dataGridView1.TabIndex = 15;
      this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
      this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
      // 
      // Cav_nro
      // 
      this.Cav_nro.DataPropertyName = "Cav_nro";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
      this.Cav_nro.DefaultCellStyle = dataGridViewCellStyle2;
      this.Cav_nro.HeaderText = "Nro.";
      this.Cav_nro.Name = "Cav_nro";
      this.Cav_nro.ReadOnly = true;
      // 
      // ctt_nombre
      // 
      this.ctt_nombre.DataPropertyName = "Ctt_nombre";
      this.ctt_nombre.HeaderText = "Nombre Contrato";
      this.ctt_nombre.Name = "ctt_nombre";
      this.ctt_nombre.ReadOnly = true;
      // 
      // cav_tipo
      // 
      this.cav_tipo.DataPropertyName = "Cav_tipo";
      this.cav_tipo.HeaderText = "Tipo";
      this.cav_tipo.Name = "cav_tipo";
      this.cav_tipo.ReadOnly = true;
      // 
      // ani_id
      // 
      this.ani_id.DataPropertyName = "Ani_id";
      this.ani_id.HeaderText = "Año";
      this.ani_id.Name = "ani_id";
      this.ani_id.ReadOnly = true;
      // 
      // cav_mes
      // 
      this.cav_mes.DataPropertyName = "Cav_mes";
      this.cav_mes.HeaderText = "Mes";
      this.cav_mes.Name = "cav_mes";
      this.cav_mes.ReadOnly = true;
      // 
      // var_codigo
      // 
      this.var_codigo.DataPropertyName = "Var_codigo";
      this.var_codigo.HeaderText = "Variable";
      this.var_codigo.Name = "var_codigo";
      this.var_codigo.ReadOnly = true;
      // 
      // var_nombre
      // 
      this.var_nombre.DataPropertyName = "Var_nombre";
      this.var_nombre.HeaderText = "Nombre Variable";
      this.var_nombre.Name = "var_nombre";
      this.var_nombre.ReadOnly = true;
      // 
      // cav_valor
      // 
      this.cav_valor.DataPropertyName = "Cav_valor";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.cav_valor.DefaultCellStyle = dataGridViewCellStyle3;
      this.cav_valor.HeaderText = "Valor";
      this.cav_valor.Name = "cav_valor";
      this.cav_valor.ReadOnly = true;
      // 
      // umd_codigo
      // 
      this.umd_codigo.DataPropertyName = "Umd_codigo";
      this.umd_codigo.HeaderText = "Unidad";
      this.umd_codigo.Name = "umd_codigo";
      this.umd_codigo.ReadOnly = true;
      // 
      // frmCalculoVariableLista
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 566);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.toolBar1);
      this.Name = "frmCalculoVariableLista";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "LISTA - CALCULO VARIABLES RETRIBUCIÓN";
      this.Load += new System.EventHandler(this.frmCalculoVariableLista_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.ImageList imgButtons;
    internal System.Windows.Forms.ToolBar toolBar1;
    private System.Windows.Forms.ToolBarButton cmdRefresh;
    internal System.Windows.Forms.ToolBarButton cmdFind;
    internal System.Windows.Forms.ToolBarButton cmdClose;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cav_nro;
    private System.Windows.Forms.DataGridViewTextBoxColumn ctt_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn cav_tipo;
    private System.Windows.Forms.DataGridViewTextBoxColumn ani_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn cav_mes;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_codigo;
    private System.Windows.Forms.DataGridViewTextBoxColumn var_nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn cav_valor;
    private System.Windows.Forms.DataGridViewTextBoxColumn umd_codigo;
  }
}