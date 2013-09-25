namespace ypfbApplication.View
{
    partial class frmTablaCalculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTablaCalculo));
            this.cbofields1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.cmdTablas = new System.Windows.Forms.ToolBarButton();
            this.lblcbofields1 = new System.Windows.Forms.Label();
            this.lblContrato = new System.Windows.Forms.Label();
            this.txtfields1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOpLog = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbofields1
            // 
            this.cbofields1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofields1.FormattingEnabled = true;
            this.cbofields1.Location = new System.Drawing.Point(172, 56);
            this.cbofields1.Name = "cbofields1";
            this.cbofields1.Size = new System.Drawing.Size(190, 21);
            this.cbofields1.TabIndex = 1;
            this.cbofields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbofields1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdTablas});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imgButtons;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(602, 28);
            this.toolBar1.TabIndex = 19;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // cmdTablas
            // 
            this.cmdTablas.ImageIndex = 12;
            this.cmdTablas.Name = "cmdTablas";
            this.cmdTablas.Text = "Ver Tablas";
            // 
            // lblcbofields1
            // 
            this.lblcbofields1.AutoSize = true;
            this.lblcbofields1.Location = new System.Drawing.Point(40, 56);
            this.lblcbofields1.Name = "lblcbofields1";
            this.lblcbofields1.Size = new System.Drawing.Size(42, 13);
            this.lblcbofields1.TabIndex = 20;
            this.lblcbofields1.Text = "Tablas:";
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrato.Location = new System.Drawing.Point(84, 31);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(0, 13);
            this.lblContrato.TabIndex = 21;
            // 
            // txtfields1
            // 
            this.txtfields1.Location = new System.Drawing.Point(172, 83);
            this.txtfields1.Name = "txtfields1";
            this.txtfields1.Size = new System.Drawing.Size(190, 20);
            this.txtfields1.TabIndex = 2;
            this.txtfields1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfields1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Precio para Tabla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Es:";
            // 
            // cbxOpLog
            // 
            this.cbxOpLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOpLog.FormattingEnabled = true;
            this.cbxOpLog.Location = new System.Drawing.Point(396, 83);
            this.cbxOpLog.Name = "cbxOpLog";
            this.cbxOpLog.Size = new System.Drawing.Size(190, 21);
            this.cbxOpLog.TabIndex = 24;
            // 
            // frmTablaCalculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(602, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxOpLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfields1);
            this.Controls.Add(this.lblContrato);
            this.Controls.Add(this.lblcbofields1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbofields1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTablaCalculo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla Cálculo";
            this.Load += new System.EventHandler(this.frmTablaCalculo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbofields1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.ImageList imgButtons;
        internal System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton cmdTablas;
        private System.Windows.Forms.Label lblcbofields1;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.TextBox txtfields1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOpLog;
    }
}