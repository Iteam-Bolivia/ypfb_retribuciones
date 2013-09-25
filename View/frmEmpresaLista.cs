using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Controller;

namespace ypfbApplication.View
{
    public partial class frmEmpresaLista : Form
    {
        long emp_id;

        /// <summary>
        /// Method frmEmpresaLista
        /// </summary>
        public frmEmpresaLista()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmEmpresaLista_Load
        /// </summary>
        private void frmEmpresaLista_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /// <summary>
        /// Method dataGridView1_Click
        /// </summary>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            emp_id = (long)celda.Value;
        }

        /// <summary>
        /// Method dataGridView1_DoubleClick
        /// </summary>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            emp_id = (long)celda.Value;

            // Edit
            Session objSession = new Session();
            objSession.ID = emp_id;
            frmEmpresa objEmpresa = new frmEmpresa();
            objEmpresa.buscar();
            objEmpresa.ShowDialog();

        }


        /// <summary>
        /// Method dataGridView1_CellFormatting
        /// </summary>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[6].Value == "En revisión")
                {
                    foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
                    {
                        celda.Style.BackColor = System.Drawing.Color.NavajoWhite;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Un ArgumentOutOfRangeException ocurrió");
            }
        }

        /// <summary>
        /// Method formatDataGridView
        /// </summary>
        private void formatDataGridView()
        {
            this.dataGridView1.Columns[8].Visible = false; // field
            this.dataGridView1.Columns[9].Visible = false; // field
            this.dataGridView1.Columns[10].Visible = false; // field
            this.dataGridView1.Columns[11].Visible = false; // field
            this.dataGridView1.Columns[12].Visible = false; // field
            //this.dataGridView1.Columns[13].Visible = false; // field
            //this.dataGridView1.Columns[14].Visible = false; // field
            //this.dataGridView1.Columns[15].Visible = false; // field
            //this.dataGridView1.Columns[16].Visible = false; // field
            //// this.dataGridView1.Columns[18].Visible = false; // field
            // this.dataGridView1.Columns[19].Visible = false; // field

        }

        /// <summary>
        /// Method toolBar1_ButtonClick
        /// </summary>
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    objSession.ID = 0;
                    frmEmpresa childForm2 = new frmEmpresa();
                    childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    childForm2.Show();
                    break;

                case "cmdEdit":
                    objSession.ID = emp_id;
                    // Edit Empresa
                    frmEmpresa objEmpresa = new frmEmpresa();
                    objEmpresa.buscar();
                    objEmpresa.ShowDialog();

                    //EmpresaController objEmpresaController = new EmpresaController();
                    //objEmpresaController.edit();
                    break;

                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + emp_id + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            emp_id = objSession.ID;
                            List<Empresa> lstEmpresa = new List<Empresa>();
                            List<Empresa> lstempresa2 = new List<Empresa>();
                            EmpresaObject objEmpresaObject = new EmpresaObject();
                            lstEmpresa = objEmpresaObject.listEmpresa(emp_id);
                            if (lstEmpresa.Count != 0)
                            {
                                lstEmpresa.ForEach(delegate(Empresa u)
                                {
                                    lstempresa2.Add(new Empresa(0, u.Emp_nit, u.Emp_nombre, u.Emp_propietario, u.Emp_dir, u.Emp_telefono, u.Emp_email, u.Emp_estado));
                                });
                                //EmpresaController objEmpresaController2 = new EmpresaController();
                                //objEmpresaController2.update(lstempresa2);

                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.cargar();
                            }
                            break;

                        case DialogResult.No:
                            // "No" processing
                            break;
                        case DialogResult.Cancel:
                            // "Cancel" processing
                            break;
                    }
                    break;

                case "cmdRefresh":
                    cargar();
                    break;

                case "cmdFind":
                    //frmEmpresaBusqueda childForm = new frmEmpresaBusqueda();
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





        /// <summary>
        /// Method childForm_FormClosed
        /// </summary>
        private void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Refresh the DataGridView goes here           
            //EmpresaSerialization objEmpresaSerialization = new EmpresaSerialization();
            //int emp_id = objEmpresaSerialization.emp_id;
            //string codigoEmpresa = objEmpresaSerialization.CodigoEmpresa;
            //string nombreEmpresa = objEmpresaSerialization.NombreEmpresa;
            //string institucion = objEmpresaSerialization.Institucion;
            //string grupoEmpresa = objEmpresaSerialization.GrupoEmpresa;
            //string remitente = objEmpresaSerialization.Remitente;
            //string cite = objEmpresaSerialization.Cite;

            Session objSession = new Session();
            emp_id = objSession.ID;

            // Fill data
            List<Empresa> lstEmpresa = new List<Empresa>();
            EmpresaObject objEmpresaObject = new EmpresaObject();
            //lstEmpresa = objEmpresaObject.findEmpresaFields(codigoEmpresa, nombreEmpresa, institucion, grupoEmpresa, remitente, cite, idempresa);
            buscar(lstEmpresa);
        }

        /// <summary>
        /// Method childForm2_FormClosed
        /// </summary>
        private void childForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            cargar();
        }



        /// <summary>
        /// Method cargar
        /// </summary>
        private void cargar()
        {
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            List<Empresa> lstEmpresa = new List<Empresa>();

            //EmpresaController objEmpresaController = new EmpresaController();
            //lstEmpresa = objEmpresaController.load();
            EmpresaObject objEmpresaObjet = new EmpresaObject();
            lstEmpresa = objEmpresaObjet.listEmpresa(0);
            if (lstEmpresa.Count == 0)
            {
                //MessageBox.Show("¡NO EXISTEN EmpresaS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // DataTable
                DataTable table = new DataTable();
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(lstEmpresa);
                dataGridView1.DataSource = table;
                dataGridView1.Update();
                dataGridView1.Refresh();

                // Ocultar algunos campos
                formatDataGridView();
            }
        }

        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscar(List<Empresa> lstEmpresa)
        {
            if (lstEmpresa.Count == 0)
            {
                MessageBox.Show("¡NO EXISTEN EmpresaS!", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                Misc objMisc = new Misc();
                dt = objMisc.GenericListToDataTable(lstEmpresa);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
