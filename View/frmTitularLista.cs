using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTitularLista : Form
    {
        public static long tit_id1 = 0;
        public static string tit_nombre1;
        List<Titular> listaTitular;

        public frmTitularLista()
        {
            InitializeComponent();
        }
        private void frmTitularLista_Load(object sender, EventArgs e)
        {
            Cargar(listaTitular);
        }
        private void frmTitularLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cargar(listaTitular);
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (CampoController.GetDatosCampo(tit_id1) != null)
                tit_nombre1 = CampoController.GetDatosCampo(tit_id1).Cam_nombre;
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmTitular frmTitularNew = new frmTitular();
                    frmTitularNew.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    listaTitular = null;
                    frmTitularBusqueda.flagBusqueda = 0;
                    frmTitularNew.ShowDialog();
                    break;
                case "cmdEdit":
                    frmTitular frmTitularEdit = new frmTitular();
                    frmTitularEdit.Buscar();
                    listaTitular = null;
                    frmTitularBusqueda.flagBusqueda = 0;
                    frmTitularEdit.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    frmTitularEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaTitular = null;
                    frmTitularBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show(this, "Eliminar registro " + tit_id1 + "?", "Validación GEdS Desktop", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            List<Titular> lstTitular = new List<Titular>();
                            List<Titular> lstTitular2 = new List<Titular>();
                            TitularObject objTitularObject = new TitularObject();
                            lstTitular = objTitularObject.listTitular(tit_id1);
                            if (lstTitular.Count != 0)
                            {
                                lstTitular.ForEach(delegate(Titular t)
                                {
                                    lstTitular2.Add(new Titular(t.Tit_id, t.Tit_codigo, t.Tit_nombre, 0, t.Tit_orden));
                                });
                            }
                            if (objTitularObject.update(lstTitular2) != 0)
                            {
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar(listaTitular);
                            }
                            else
                                MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case DialogResult.No:
                            break;
                    }
                    break;
                case "cmdRefresh":
                    frmTitularLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmTitularBusqueda frmTitularBusquedaFind = new frmTitularBusqueda();
                    frmTitularBusquedaFind.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    frmTitularBusqueda.listaTitulares = null;
                    frmTitularBusqueda.flagBusqueda = 0;
                    frmTitularBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdTitularSinonimo":
                    frmTitular_SinonimoLista objTitular_SinonimoLista = new frmTitular_SinonimoLista();
                    objTitular_SinonimoLista.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
                    objTitular_SinonimoLista.Text = (tit_nombre1 != "" ? "Sinonimos asociados al titular: " + tit_nombre1 : " Titular sinonimo");
                    objTitular_SinonimoLista.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
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

                    tit_id1 = Convert.ToInt64(celda.Value);
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                    //sinonimos
                    toolBar1.Buttons[7].Enabled = true;
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = true;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Sinonimos
                    toolBar1.Buttons[7].Enabled = true;
                    tit_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTitular frmTitularEdit = new frmTitular();
            frmTitularEdit.Buscar();
            listaTitular = null;
            frmTitularBusqueda.flagBusqueda = 0;
            frmTitularEdit.FormClosed += new FormClosedEventHandler(frmTitularLista_FormClosed);
            frmTitularEdit.ShowDialog();
        }
        #region Metodos Controller
        protected void Cargar(List<Titular> listaTitulares)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            if (listaTitulares == null)
            {
                listaTitulares = new List<Titular>();
                listaTitulares = TitularController.GetListTitulares(0);
            }
            DataTable table = null;

            if (listaTitulares.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaTitulares);                
            }
            toolBar1.Buttons[0].Enabled = true;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[7].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        #endregion
    }
}