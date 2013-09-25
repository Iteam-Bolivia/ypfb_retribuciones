using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmProductoMercadoLista : Form
    {
        //private long mer_id1 = 0;

        public frmProductoMercadoLista()
        {
            InitializeComponent();
        }

        private void frmMercadoLista_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    objSession.ID = 0;
                    frmRol childForm2 = new frmRol();
                    //childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    childForm2.Show();
                    break;

                case "cmdEdit":
                    //objSession.ID = rol_id;
                    // Edit Rol
                    //frmRol objRol = new frmRol();
                    //objRol.buscar();
                    //objRol.ShowDialog();

                    //RolController objRolController = new RolController();
                    //objRolController.edit();
                    break;

                case "cmdDelete":
                    //switch (MessageBox.Show("Eliminar registro " + rol_id + " ?",
                    //                        "Validación del Sistema",
                    //                        MessageBoxButtons.YesNoCancel,
                    //                        MessageBoxIcon.Question))
                    //{
                    //    case DialogResult.Yes:
                    //        rol_id = objSession.ID;
                    //        List<Rol> lstRol = new List<Rol>();
                    //        List<Rol> lstrol2 = new List<Rol>();
                    //        RolObject objRolObject = new RolObject();
                    //        lstRol = objRolObject.listRol(rol_id);
                    //        if (lstRol.Count != 0)
                    //        {
                    //            lstRol.ForEach(delegate(Rol u)
                    //            {
                    //                lstrol2.Add(new Rol(0, u.Rol_cod, u.Rol_titulo, u.Rol_descripcion, u.Rol_estado));
                    //            });
                    //            //RolController objRolController2 = new RolController();
                    //            //objRolController2.update(lstrol2);

                    //            MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //            this.cargar();
                    //        }
                    //        break;

                    //    case DialogResult.No:
                    //        // "No" processing
                    //        break;
                    //    case DialogResult.Cancel:
                    //        // "Cancel" processing
                    //        break;
                    //}
                    break;

                case "cmdRefresh":
                    Cargar();
                    break;

                case "cmdFind":
                    //frmRolBusqueda childForm = new frmRolBusqueda();
                    //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    //childForm.Show();
                    //buscar();
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
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of contrato
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];

            Session objSession = new Session();
            try
            {
                if (!string.IsNullOrEmpty(celda.Value.ToString()))
                {
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = true;
                    //Editar
                    toolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                }
            }
            catch { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1_Click(sender, e);
        }

        #region Metodos Controller
        protected void Cargar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            Session sesion = new Session();

            List<Mercado> listaMercados = MercadoController.GetListMercadosPorProducto(Convert.ToInt64(sesion.SUC_ID));

            DataTable table = null;
            if (listaMercados.Count != 0)
            {
                table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(listaMercados);
            }

            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        #endregion
    }
}