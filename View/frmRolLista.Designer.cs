﻿namespace ypfbApplication.View
{
  partial class frmRolLista
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolLista));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.imgButtons = new System.Windows.Forms.ImageList(this.components);
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.rol_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rol_cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rol_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rol_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rol_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.toolBar1 = new System.Windows.Forms.ToolBar();
      this.cmdNew = new System.Windows.Forms.ToolBarButton();
      this.cmdDelete = new System.Windows.Forms.ToolBarButton();
      this.cmdEdit = new System.Windows.Forms.ToolBarButton();
      this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
      this.cmdFind = new System.Windows.Forms.ToolBarButton();
      this.cmdPrint = new System.Windows.Forms.ToolBarButton();
      this.cmdClose = new System.Windows.Forms.ToolBarButton();
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
            this.rol_id,
            this.rol_cod,
            this.rol_titulo,
            this.rol_descripcion,
            this.rol_estado});
      this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 28);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(492, 538);
      this.dataGridView1.TabIndex = 12;
      this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
      // 
      // rol_id
      // 
      this.rol_id.DataPropertyName = "rol_id";
      this.rol_id.HeaderText = "#";
      this.rol_id.Name = "rol_id";
      this.rol_id.ReadOnly = true;
      // 
      // rol_cod
      // 
      this.rol_cod.DataPropertyName = "rol_cod";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.rol_cod.DefaultCellStyle = dataGridViewCellStyle2;
      this.rol_cod.HeaderText = "Código";
      this.rol_cod.Name = "rol_cod";
      this.rol_cod.ReadOnly = true;
      // 
      // rol_titulo
      // 
      this.rol_titulo.DataPropertyName = "Rol_titulo";
      this.rol_titulo.HeaderText = "Titulo Rol";
      this.rol_titulo.Name = "rol_titulo";
      this.rol_titulo.ReadOnly = true;
      // 
      // rol_descripcion
      // 
      this.rol_descripcion.DataPropertyName = "Rol_descripcion";
      this.rol_descripcion.HeaderText = "Descripción";
      this.rol_descripcion.Name = "rol_descripcion";
      this.rol_descripcion.ReadOnly = true;
      // 
      // rol_estado
      // 
      this.rol_estado.DataPropertyName = "Rol_estado";
      dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
      this.rol_estado.DefaultCellStyle = dataGridViewCellStyle3;
      this.rol_estado.HeaderText = "Estado";
      this.rol_estado.Name = "rol_estado";
      this.rol_estado.ReadOnly = true;
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
      this.toolBar1.TabIndex = 21;
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
      // frmRolLista
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 566);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.toolBar1);
      this.Name = "frmRolLista";
      this.Text = "Rol";
      this.Load += new System.EventHandler(this.frmRolLista_Load);
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
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_cod;
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_titulo;
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_descripcion;
    private System.Windows.Forms.DataGridViewTextBoxColumn rol_estado;
  }
}