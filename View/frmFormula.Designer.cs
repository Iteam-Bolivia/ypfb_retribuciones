namespace ypfbApplication.View
{
  partial class frmFormula
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormula));
        this.btnGuardar = new System.Windows.Forms.Button();
        this.txtfields3 = new System.Windows.Forms.TextBox();
        this.txtfields2 = new System.Windows.Forms.TextBox();
        this.txtfields1 = new System.Windows.Forms.TextBox();
        this.lbltxtfields2 = new System.Windows.Forms.Label();
        this.lbltxtfields1 = new System.Windows.Forms.Label();
        this.txtfields4 = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.imgButtons = new System.Windows.Forms.ImageList(this.components);
        this.toolBar1 = new System.Windows.Forms.ToolBar();
        this.cmdNew = new System.Windows.Forms.ToolBarButton();
        this.cmdDelete = new System.Windows.Forms.ToolBarButton();
        this.cmdEdit = new System.Windows.Forms.ToolBarButton();
        this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
        this.cmdFind = new System.Windows.Forms.ToolBarButton();
        this.cmdPrint = new System.Windows.Forms.ToolBarButton();
        this.cmdClose = new System.Windows.Forms.ToolBarButton();
        this.txtDescripcionVariable = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.lstCalculos = new System.Windows.Forms.ListBox();
        this.label4 = new System.Windows.Forms.Label();
        this.cmdCancelar = new System.Windows.Forms.Button();
        this.lstFunciones = new System.Windows.Forms.ListBox();
        this.label2 = new System.Windows.Forms.Label();
        this.checkBox1 = new System.Windows.Forms.CheckBox();
        this.txtForTipo = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnGuardar
        // 
        this.btnGuardar.Location = new System.Drawing.Point(328, 183);
        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Size = new System.Drawing.Size(89, 27);
        this.btnGuardar.TabIndex = 4;
        this.btnGuardar.Text = "&Guardar";
        this.btnGuardar.UseVisualStyleBackColor = true;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        // 
        // txtfields3
        // 
        this.txtfields3.BackColor = System.Drawing.Color.AliceBlue;
        this.txtfields3.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtfields3.Enabled = false;
        this.txtfields3.Location = new System.Drawing.Point(263, 32);
        this.txtfields3.Multiline = true;
        this.txtfields3.Name = "txtfields3";
        this.txtfields3.Size = new System.Drawing.Size(367, 30);
        this.txtfields3.TabIndex = 3;
        this.txtfields3.Text = "Ninguna";
        this.txtfields3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields3_KeyPress);
        // 
        // txtfields2
        // 
        this.txtfields2.Location = new System.Drawing.Point(328, 69);
        this.txtfields2.Multiline = true;
        this.txtfields2.Name = "txtfields2";
        this.txtfields2.Size = new System.Drawing.Size(302, 56);
        this.txtfields2.TabIndex = 1;
        this.txtfields2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields2_KeyPress);
        // 
        // txtfields1
        // 
        this.txtfields1.Enabled = false;
        this.txtfields1.Location = new System.Drawing.Point(90, 32);
        this.txtfields1.Name = "txtfields1";
        this.txtfields1.Size = new System.Drawing.Size(149, 20);
        this.txtfields1.TabIndex = 6;
        this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
        // 
        // lbltxtfields2
        // 
        this.lbltxtfields2.AutoSize = true;
        this.lbltxtfields2.Location = new System.Drawing.Point(260, 69);
        this.lbltxtfields2.Name = "lbltxtfields2";
        this.lbltxtfields2.Size = new System.Drawing.Size(47, 13);
        this.lbltxtfields2.TabIndex = 3;
        this.lbltxtfields2.Text = "Formula:";
        // 
        // lbltxtfields1
        // 
        this.lbltxtfields1.AutoSize = true;
        this.lbltxtfields1.Location = new System.Drawing.Point(20, 32);
        this.lbltxtfields1.Name = "lbltxtfields1";
        this.lbltxtfields1.Size = new System.Drawing.Size(48, 13);
        this.lbltxtfields1.TabIndex = 0;
        this.lbltxtfields1.Text = "Variable:";
        // 
        // txtfields4
        // 
        this.txtfields4.Location = new System.Drawing.Point(328, 128);
        this.txtfields4.Name = "txtfields4";
        this.txtfields4.Size = new System.Drawing.Size(302, 20);
        this.txtfields4.TabIndex = 2;
        this.txtfields4.Text = "0";
        this.txtfields4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields4_KeyPress);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(259, 131);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(63, 13);
        this.label1.TabIndex = 13;
        this.label1.Text = "Valor inicial:";
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
        this.toolBar1.Size = new System.Drawing.Size(659, 28);
        this.toolBar1.TabIndex = 14;
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
        // 
        // cmdEdit
        // 
        this.cmdEdit.ImageIndex = 14;
        this.cmdEdit.Name = "cmdEdit";
        this.cmdEdit.Text = "&Editar";
        this.cmdEdit.ToolTipText = "Editar";
        this.cmdEdit.Visible = false;
        // 
        // cmdRefresh
        // 
        this.cmdRefresh.ImageIndex = 3;
        this.cmdRefresh.Name = "cmdRefresh";
        this.cmdRefresh.Text = "A&ctualizar";
        this.cmdRefresh.Visible = false;
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
        this.cmdClose.ImageIndex = 6;
        this.cmdClose.Name = "cmdClose";
        this.cmdClose.Text = "&Cerrar";
        this.cmdClose.ToolTipText = "Cerrar ventana";
        // 
        // txtDescripcionVariable
        // 
        this.txtDescripcionVariable.AcceptsReturn = true;
        this.txtDescripcionVariable.BackColor = System.Drawing.SystemColors.Window;
        this.txtDescripcionVariable.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtDescripcionVariable.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtDescripcionVariable.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtDescripcionVariable.Location = new System.Drawing.Point(90, 131);
        this.txtDescripcionVariable.MaxLength = 0;
        this.txtDescripcionVariable.Multiline = true;
        this.txtDescripcionVariable.Name = "txtDescripcionVariable";
        this.txtDescripcionVariable.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtDescripcionVariable.Size = new System.Drawing.Size(149, 30);
        this.txtDescripcionVariable.TabIndex = 8;
        // 
        // label3
        // 
        this.label3.BackColor = System.Drawing.Color.AliceBlue;
        this.label3.Cursor = System.Windows.Forms.Cursors.Default;
        this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
        this.label3.Location = new System.Drawing.Point(20, 133);
        this.label3.Name = "label3";
        this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label3.Size = new System.Drawing.Size(65, 17);
        this.label3.TabIndex = 18;
        this.label3.Text = "Descripción:";
        // 
        // lstCalculos
        // 
        this.lstCalculos.BackColor = System.Drawing.SystemColors.Window;
        this.lstCalculos.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstCalculos.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstCalculos.Location = new System.Drawing.Point(90, 69);
        this.lstCalculos.Name = "lstCalculos";
        this.lstCalculos.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstCalculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.lstCalculos.Size = new System.Drawing.Size(149, 56);
        this.lstCalculos.TabIndex = 7;
        this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(20, 70);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(53, 13);
        this.label4.TabIndex = 19;
        this.label4.Text = "Variables:";
        // 
        // cmdCancelar
        // 
        this.cmdCancelar.Location = new System.Drawing.Point(545, 183);
        this.cmdCancelar.Name = "cmdCancelar";
        this.cmdCancelar.Size = new System.Drawing.Size(89, 27);
        this.cmdCancelar.TabIndex = 5;
        this.cmdCancelar.Text = "&Cancelar";
        this.cmdCancelar.UseVisualStyleBackColor = true;
        this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
        // 
        // lstFunciones
        // 
        this.lstFunciones.BackColor = System.Drawing.SystemColors.Window;
        this.lstFunciones.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstFunciones.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstFunciones.Location = new System.Drawing.Point(90, 167);
        this.lstFunciones.Name = "lstFunciones";
        this.lstFunciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstFunciones.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.lstFunciones.Size = new System.Drawing.Size(149, 43);
        this.lstFunciones.TabIndex = 9;
        this.lstFunciones.SelectedIndexChanged += new System.EventHandler(this.lstFunciones_SelectedIndexChanged);
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.AliceBlue;
        this.label2.Cursor = System.Windows.Forms.Cursors.Default;
        this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.label2.Location = new System.Drawing.Point(20, 167);
        this.label2.Name = "label2";
        this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.label2.Size = new System.Drawing.Size(65, 17);
        this.label2.TabIndex = 22;
        this.label2.Text = "Funciones:";
        // 
        // checkBox1
        // 
        this.checkBox1.AutoSize = true;
        this.checkBox1.Location = new System.Drawing.Point(328, 154);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.Size = new System.Drawing.Size(151, 17);
        this.checkBox1.TabIndex = 3;
        this.checkBox1.Text = "Calcular valores Mercados";
        this.checkBox1.UseVisualStyleBackColor = true;
        // 
        // txtForTipo
        // 
        this.txtForTipo.Location = new System.Drawing.Point(448, 0);
        this.txtForTipo.Name = "txtForTipo";
        this.txtForTipo.Size = new System.Drawing.Size(100, 20);
        this.txtForTipo.TabIndex = 23;
        this.txtForTipo.Visible = false;
        // 
        // frmFormula
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.AliceBlue;
        this.ClientSize = new System.Drawing.Size(659, 227);
        this.Controls.Add(this.txtForTipo);
        this.Controls.Add(this.checkBox1);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.lstFunciones);
        this.Controls.Add(this.cmdCancelar);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.txtDescripcionVariable);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.lstCalculos);
        this.Controls.Add(this.txtfields2);
        this.Controls.Add(this.toolBar1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.txtfields4);
        this.Controls.Add(this.btnGuardar);
        this.Controls.Add(this.txtfields3);
        this.Controls.Add(this.txtfields1);
        this.Controls.Add(this.lbltxtfields1);
        this.Controls.Add(this.lbltxtfields2);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmFormula";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FORMULA - AGREGAR - EDITAR";
        this.Load += new System.EventHandler(this.frmFormula_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtfields3;
    private System.Windows.Forms.TextBox txtfields2;
    private System.Windows.Forms.TextBox txtfields1;
    private System.Windows.Forms.Label lbltxtfields2;
    private System.Windows.Forms.Label lbltxtfields1;
    private System.Windows.Forms.TextBox txtfields4;
    private System.Windows.Forms.Label label1;
    internal System.Windows.Forms.ImageList imgButtons;
    internal System.Windows.Forms.ToolBar toolBar1;
    internal System.Windows.Forms.ToolBarButton cmdNew;
    private System.Windows.Forms.ToolBarButton cmdDelete;
    private System.Windows.Forms.ToolBarButton cmdEdit;
    private System.Windows.Forms.ToolBarButton cmdRefresh;
    internal System.Windows.Forms.ToolBarButton cmdFind;
    internal System.Windows.Forms.ToolBarButton cmdPrint;
    internal System.Windows.Forms.ToolBarButton cmdClose;
    public System.Windows.Forms.TextBox txtDescripcionVariable;
    public System.Windows.Forms.Label label3;
    public System.Windows.Forms.ListBox lstCalculos;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button cmdCancelar;
    public System.Windows.Forms.ListBox lstFunciones;
    public System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.TextBox txtForTipo;
  }
}