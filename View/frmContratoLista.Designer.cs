namespace ypfbApplication.View
{
    partial class frmContratoLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContratoLista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.cmdTitulares = new System.Windows.Forms.ToolBarButton();
            this.cmdCampos = new System.Windows.Forms.ToolBarButton();
            this.cmdCalculos = new System.Windows.Forms.ToolBarButton();
            this.cmdRegalias = new System.Windows.Forms.ToolBarButton();
            this.cmdSinonimos = new System.Windows.Forms.ToolBarButton();
            this.cmdCondiciones = new System.Windows.Forms.ToolBarButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ctt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lista_titulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_fecini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_fecfin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lista_campos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lista_tablas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_completo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctt_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdMarginales = new System.Windows.Forms.ToolBarButton();
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
            this.cmdClose,
            this.cmdTitulares,
            this.cmdCampos,
            this.cmdCalculos,
            this.cmdRegalias,
            this.cmdSinonimos,
            this.cmdCondiciones,
            this.cmdMarginales});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imgButtons;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(692, 50);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // cmdNew
            // 
            this.cmdNew.ImageIndex = 0;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Text = "&Adicionar";
            this.cmdNew.ToolTipText = "Nuevo Contrato";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.ImageIndex = 1;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "&Eliminar";
            this.cmdDelete.ToolTipText = "Borrar Contrato Seleccionado";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.ImageIndex = 14;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "&Editar";
            this.cmdEdit.ToolTipText = "Editar Contrato";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.ImageIndex = 3;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Text = "A&ctualizar";
            this.cmdRefresh.ToolTipText = "Actualizar Lista";
            // 
            // cmdFind
            // 
            this.cmdFind.ImageIndex = 4;
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Text = "&Buscar";
            this.cmdFind.ToolTipText = "Buscar Contratos";
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
            // cmdTitulares
            // 
            this.cmdTitulares.Enabled = false;
            this.cmdTitulares.ImageIndex = 12;
            this.cmdTitulares.Name = "cmdTitulares";
            this.cmdTitulares.Text = "Ver Empresas";
            this.cmdTitulares.ToolTipText = "Ver Empresas asociados al Contrato";
            // 
            // cmdCampos
            // 
            this.cmdCampos.Enabled = false;
            this.cmdCampos.ImageIndex = 12;
            this.cmdCampos.Name = "cmdCampos";
            this.cmdCampos.Text = "Ver Campos";
            this.cmdCampos.ToolTipText = "Ver Campos Asociados al Contrato";
            // 
            // cmdCalculos
            // 
            this.cmdCalculos.Enabled = false;
            this.cmdCalculos.ImageIndex = 12;
            this.cmdCalculos.Name = "cmdCalculos";
            this.cmdCalculos.Text = "Ver Tabla de Cálculos";
            this.cmdCalculos.ToolTipText = "Ver Tabla de Cálculos asociados al Contrato";
            // 
            // cmdRegalias
            // 
            this.cmdRegalias.Enabled = false;
            this.cmdRegalias.ImageIndex = 12;
            this.cmdRegalias.Name = "cmdRegalias";
            this.cmdRegalias.Text = "Ver Regalías";
            this.cmdRegalias.ToolTipText = "Ver Regalías asociadas al Contrato";
            // 
            // cmdSinonimos
            // 
            this.cmdSinonimos.Enabled = false;
            this.cmdSinonimos.ImageIndex = 12;
            this.cmdSinonimos.Name = "cmdSinonimos";
            this.cmdSinonimos.Text = "Ver Sinonimos";
            this.cmdSinonimos.ToolTipText = "Ver Sinonimos asociadas al contrato";
            // 
            // cmdCondiciones
            // 
            this.cmdCondiciones.Enabled = false;
            this.cmdCondiciones.ImageIndex = 12;
            this.cmdCondiciones.Name = "cmdCondiciones";
            this.cmdCondiciones.Text = "Ver Condiciones";
            this.cmdCondiciones.ToolTipText = "Ver Condiciones";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctt_id,
            this.ctt_codigo,
            this.ctt_nombre,
            this.lista_titulares,
            this.ctt_periodo,
            this.ctt_fecini,
            this.ctt_fecfin,
            this.lista_campos,
            this.lista_tablas,
            this.nombre_completo,
            this.ctt_estado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(692, 696);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // ctt_id
            // 
            this.ctt_id.DataPropertyName = "ctt_id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.ctt_id.DefaultCellStyle = dataGridViewCellStyle3;
            this.ctt_id.HeaderText = "#";
            this.ctt_id.Name = "ctt_id";
            this.ctt_id.ReadOnly = true;
            // 
            // ctt_codigo
            // 
            this.ctt_codigo.DataPropertyName = "ctt_codigo";
            this.ctt_codigo.HeaderText = "Código";
            this.ctt_codigo.Name = "ctt_codigo";
            this.ctt_codigo.ReadOnly = true;
            // 
            // ctt_nombre
            // 
            this.ctt_nombre.DataPropertyName = "ctt_nombre";
            this.ctt_nombre.HeaderText = "Nombre";
            this.ctt_nombre.Name = "ctt_nombre";
            this.ctt_nombre.ReadOnly = true;
            // 
            // lista_titulares
            // 
            this.lista_titulares.DataPropertyName = "lista_titulares";
            this.lista_titulares.HeaderText = "Operador";
            this.lista_titulares.Name = "lista_titulares";
            this.lista_titulares.ReadOnly = true;
            // 
            // ctt_periodo
            // 
            this.ctt_periodo.DataPropertyName = "ctt_periodo";
            this.ctt_periodo.HeaderText = "Periodo";
            this.ctt_periodo.Name = "ctt_periodo";
            this.ctt_periodo.ReadOnly = true;
            // 
            // ctt_fecini
            // 
            this.ctt_fecini.DataPropertyName = "ctt_fecini";
            this.ctt_fecini.HeaderText = "Fec. Inicial";
            this.ctt_fecini.Name = "ctt_fecini";
            this.ctt_fecini.ReadOnly = true;
            // 
            // ctt_fecfin
            // 
            this.ctt_fecfin.DataPropertyName = "ctt_fecfin";
            this.ctt_fecfin.HeaderText = "Fec. Fin";
            this.ctt_fecfin.Name = "ctt_fecfin";
            this.ctt_fecfin.ReadOnly = true;
            // 
            // lista_campos
            // 
            this.lista_campos.DataPropertyName = "lista_campos";
            this.lista_campos.HeaderText = "Campos";
            this.lista_campos.Name = "lista_campos";
            this.lista_campos.ReadOnly = true;
            // 
            // lista_tablas
            // 
            this.lista_tablas.DataPropertyName = "lista_tablas";
            this.lista_tablas.HeaderText = "Tablas";
            this.lista_tablas.Name = "lista_tablas";
            this.lista_tablas.ReadOnly = true;
            // 
            // nombre_completo
            // 
            this.nombre_completo.DataPropertyName = "nombre_completo";
            this.nombre_completo.HeaderText = "Usuario";
            this.nombre_completo.Name = "nombre_completo";
            this.nombre_completo.ReadOnly = true;
            // 
            // ctt_estado
            // 
            this.ctt_estado.DataPropertyName = "ctt_estado";
            this.ctt_estado.HeaderText = "Estado";
            this.ctt_estado.Name = "ctt_estado";
            this.ctt_estado.ReadOnly = true;
            // 
            // cmdMarginales
            // 
            this.cmdMarginales.Enabled = false;
            this.cmdMarginales.ImageIndex = 12;
            this.cmdMarginales.Name = "cmdMarginales";
            this.cmdMarginales.Text = "Ver meses Marginales";
            this.cmdMarginales.ToolTipText = "Ver meses Marginales";
            // 
            // frmContratoLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 746);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmContratoLista";
            this.Text = "CONTRATO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmContratoLista_FormClosed_1);
            this.Load += new System.EventHandler(this.frmContratoLista_Load);
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
        private System.Windows.Forms.ToolBarButton cmdTitulares;
        private System.Windows.Forms.ToolBarButton cmdCampos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolBarButton cmdCalculos;
        private System.Windows.Forms.ToolBarButton cmdRegalias;
        private System.Windows.Forms.ToolBarButton cmdSinonimos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn lista_titulares;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_fecini;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_fecfin;
        private System.Windows.Forms.DataGridViewTextBoxColumn lista_campos;
        private System.Windows.Forms.DataGridViewTextBoxColumn lista_tablas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_completo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctt_estado;
        private System.Windows.Forms.ToolBarButton cmdCondiciones;
        private System.Windows.Forms.ToolBarButton cmdMarginales;



    }
}