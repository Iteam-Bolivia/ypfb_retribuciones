namespace ypfbApplication.View
{
    partial class frmCampoProductoMercado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCampoProductoMercado));
            this.lblcbofields1 = new System.Windows.Forms.Label();
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCampo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mer_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpm_asociacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cpm_preciocom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mer_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mer_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
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
            // lblcbofields1
            // 
            this.lblcbofields1.AutoSize = true;
            this.lblcbofields1.Location = new System.Drawing.Point(239, 75);
            this.lblcbofields1.Name = "lblcbofields1";
            this.lblcbofields1.Size = new System.Drawing.Size(53, 13);
            this.lblcbofields1.TabIndex = 4;
            this.lblcbofields1.Text = "Producto:";
            // 
            // cbofields1
            // 
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(298, 72);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.Size = new System.Drawing.Size(242, 21);
            this.cbofields1.TabIndex = 0;
            this.cbofields1.SelectedIndexChanged += new System.EventHandler(this.cbofields1_SelectedIndexChanged);
            this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboProducto_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(400, 481);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(284, 481);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampo.Location = new System.Drawing.Point(239, 49);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(0, 13);
            this.lblCampo.TabIndex = 13;
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
            this.mer_id,
            this.mer_nombre,
            this.cpm_asociacion,
            this.cpm_preciocom,
            this.mer_codigo,
            this.mer_estado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(10, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(731, 376);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // mer_id
            // 
            this.mer_id.DataPropertyName = "mer_id";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.mer_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.mer_id.HeaderText = "#";
            this.mer_id.Name = "mer_id";
            this.mer_id.Visible = false;
            // 
            // mer_nombre
            // 
            this.mer_nombre.DataPropertyName = "mer_nombre";
            this.mer_nombre.HeaderText = "Nombre(s)";
            this.mer_nombre.Name = "mer_nombre";
            this.mer_nombre.ReadOnly = true;
            // 
            // cpm_asociacion
            // 
            this.cpm_asociacion.DataPropertyName = "cpm_asociacion";
            this.cpm_asociacion.HeaderText = "Asociado";
            this.cpm_asociacion.Name = "cpm_asociacion";
            // 
            // cpm_preciocom
            // 
            this.cpm_preciocom.DataPropertyName = "cpm_preciocom";
            this.cpm_preciocom.HeaderText = "Precio Comercialización";
            this.cpm_preciocom.Name = "cpm_preciocom";
            // 
            // mer_codigo
            // 
            this.mer_codigo.DataPropertyName = "mer_codigo";
            this.mer_codigo.HeaderText = "Código";
            this.mer_codigo.Name = "mer_codigo";
            this.mer_codigo.ReadOnly = true;
            this.mer_codigo.Visible = false;
            // 
            // mer_estado
            // 
            this.mer_estado.DataPropertyName = "mer_estado";
            this.mer_estado.HeaderText = "Estado";
            this.mer_estado.Name = "mer_estado";
            this.mer_estado.Visible = false;
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
            this.toolBar1.Size = new System.Drawing.Size(772, 28);
            this.toolBar1.TabIndex = 25;
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
            // frmCampoProductoMercado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(772, 516);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblcbofields1);
            this.Controls.Add(this.cbofields1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCampoProductoMercado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Campo Producto Mercado";
            this.Load += new System.EventHandler(this.frmCampoProductoMercado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mer_nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cpm_asociacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpm_preciocom;
        private System.Windows.Forms.DataGridViewTextBoxColumn mer_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mer_estado;
        internal System.Windows.Forms.ImageList imgButtons;
        internal System.Windows.Forms.ToolBar toolBar1;
        internal System.Windows.Forms.ToolBarButton cmdNew;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ToolBarButton cmdEdit;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        internal System.Windows.Forms.ToolBarButton cmdFind;
        internal System.Windows.Forms.ToolBarButton cmdPrint;
        internal System.Windows.Forms.ToolBarButton cmdClose;
    }
}