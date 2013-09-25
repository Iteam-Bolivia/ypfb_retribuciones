using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmBloqueLista : Form
    {
        public static long blo_id1 = 0;
        List<Bloque> listaBloque;
        public frmBloqueLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmBloqueLista_Load(object sender, EventArgs e)
        {
            Cargar(listaBloque);
        }
        private void frmBloqueLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmBloqueBusqueda.flagBusqueda == 0)
            {
                Cargar(listaBloque);
                frmBloqueBusqueda.flagBusqueda = 0;
                frmBloqueBusqueda.listaBloques = null;
            }
            else
            {
                Cargar(frmBloqueBusqueda.listaBloques);
                frmBloqueBusqueda.flagBusqueda = 0;
                frmBloqueBusqueda.listaBloques = null;
            }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmBloque frmBloqueNew = new frmBloque();
                    frmBloqueNew.FormClosed += new FormClosedEventHandler(frmBloqueLista_FormClosed);
                    listaBloque = null;
                    frmBloqueBusqueda.flagBusqueda = 0;
                    frmBloqueNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmBloque frmBloqueEdit = new frmBloque();
                    frmBloqueEdit.Buscar();
                    listaBloque = null;
                    frmBloqueBusqueda.flagBusqueda = 0;
                    frmBloqueEdit.FormClosed += new FormClosedEventHandler(frmBloqueLista_FormClosed);
                    frmBloqueEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaBloque = null;
                    frmBloqueBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + blo_id1 + "?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Bloque> lstBloque = new List<Bloque>();
                            List<Bloque> lstBloque2 = new List<Bloque>();
                            BloqueObject objBloqueObject = new BloqueObject();
                            lstBloque = objBloqueObject.listBloque(blo_id1);
                            if (lstBloque.Count != 0)
                            {
                                lstBloque.ForEach(delegate(Bloque b)
                                {
                                    lstBloque2.Add(new Bloque(b.Blo_id, b.Blo_codigo, b.Blo_nombre, 0));
                                });
                            }
                            if (objBloqueObject.update(lstBloque2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(this.listaBloque);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmBloqueLista_Load(sender, e);
                    break;

                case "cmdFind":
                    frmBloqueBusqueda frmBloqueBusquedaFind = new frmBloqueBusqueda();
                    frmBloqueBusquedaFind.FormClosed += new FormClosedEventHandler(frmBloqueLista_FormClosed);
                    frmBloqueBusqueda.listaBloques = null;
                    frmBloqueBusqueda.flagBusqueda = 0;
                    frmBloqueBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of Titular
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];

            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {

                    blo_id1 = Convert.ToInt64(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    blo_id1 = 0;
                }
            }
            catch { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }
        #endregion
        #region Metodos Controller
        protected void Cargar(List<Bloque> listaBloques)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaBloques == null)
            {
                listaBloques = new List<Bloque>();
                listaBloques = BloqueController.GetListBloques(0);
            }
            DataTable table = null;

            if (listaBloques.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaBloques);
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}