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
    public partial class frmParExcelLista : Form
    {
        long pex_id = 0;
        long pec_id1 = 0;
        bool grid1 = false;
        bool grid2 = false;
        public frmParExcelLista()
        {
            InitializeComponent();
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    objSession.ID = 0;
                    frmParExcel childForm2 = new frmParExcel();
                    childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    grid1 = true;
                    childForm2.Show();
                    break;

                case "cmdEdit":
                    objSession.ID = pex_id;
                    // Edit Empresa
                    frmParExcel objParExcel = new frmParExcel();
                    objParExcel.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    objParExcel.buscar();
                    grid1 = true;
                    objParExcel.ShowDialog();
                    //EmpresaController objEmpresaController = new EmpresaController();
                    //objEmpresaController.edit();
                    break;

                case "cmdDelete":
                    switch (MessageBox.Show("Eliminar registro " + pex_id + " ?",
                                            "Validación GEdS Desktop",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            objSession.ID = pex_id;
                            List<ParExcel> lstParExcel = new List<ParExcel>();
                            List<ParExcel> lstParExcel2 = new List<ParExcel>();
                            ParExcelController objParExcelController = new ParExcelController();
                            lstParExcel = objParExcelController.find();
                            if (lstParExcel.Count != 0)
                            {
                                lstParExcel.ForEach(delegate(ParExcel u)
                                {
                                    lstParExcel2.Add(new ParExcel(u.Pex_id, u.Pex_codigo, u.Pex_nombre, u.Pex_hoja, 0, u.Tcl_id,u.Pro_id, 0, u.Pxt_codigo));
                                });
                                objParExcelController.update(lstParExcel2);

                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.cargar();
                            }
                            grid1 = true;
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
                    grid1 = true;
                    cargar();
                    break;

                case "cmdFind":
                    break;

                case "cmdPrint":
                    try
                    {
                      printDocument1.Print();
                    }
                    catch { 
                    }
                    break;


                case "cmdClose":
                    this.Close();
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Method printDocument1_PrintPage
        /// </summary>
        private void printDocument1_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
          long i = 0;
          List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
          ParExcel_ColumnaObject objParExcelColumna = new ParExcel_ColumnaObject();
          lstParExcelColumna = objParExcelColumna.listParExcelColumnas(pex_id);
          foreach (ParExcel_Columna item in lstParExcelColumna)
          {
            e.Graphics.DrawString(System.Convert.ToString(item.Pex_id), new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            e.Graphics.DrawString(item.Pxt_codigo, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            e.Graphics.DrawString(System.Convert.ToString(item.Pec_fila), new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            e.Graphics.DrawString(item.Pec_Columna, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            e.Graphics.DrawString(item.Var_codigo, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            e.Graphics.DrawString(item.Umd_nombre, new Font("Times New", 8, FontStyle.Regular), Brushes.Black, 10, i * 12);
            i++;
          }
        }




        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            pex_id = (long)celda.Value;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            pex_id = (long)celda.Value;

            // Edit
            Session objSession = new Session();
            objSession.ID = pex_id;
            frmParExcel objParExcel = new frmParExcel();
            objParExcel.buscar();
            objParExcel.ShowDialog();
            grid1 = true;
            cargar();
        }



        private void frmParExcelLista_Load(object sender, EventArgs e)
        {
            cargar();
        }





        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            row = dataGridView2.CurrentRow.Index;
            cell = dataGridView2.CurrentCell.ColumnIndex;
            celda = dataGridView2.Rows[row].Cells[0];
            pec_id1 = (long)celda.Value;

            // Edit
            Session objSession = new Session();
            objSession.ID = pec_id1;
            frmParExcelColumna objParExcelColumna = new frmParExcelColumna();
            objParExcelColumna.buscar();
            objParExcelColumna.ShowDialog();
            grid2 = true;
            cargar();
        }



        private void cargar()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            List<ParExcel> lstParExcel = new List<ParExcel>();
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcelController objParaExcelController = new ParExcelController();
            ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();   
            if (grid1)
            {
                //Cargo grila 1
                if (pex_id != 0)
                {
                    lstParExcel = objParaExcelController.load();
                    if (lstParExcel.Count != 0)
                    {
                        // DataTable
                        DataTable table = new DataTable();
                        Misc objMisc = new Misc();
                        table = objMisc.GenericListToDataTable(lstParExcel);
                        dataGridView1.DataSource = table;
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                    }
                    grid1 = false;
                }
            }
            else if (grid2)
            {
                //cargo grid 2
                lstParExcelColumna = objParExcelColumnaController.loadBypex_id(pex_id);
                if (lstParExcelColumna.Count == 0)
                {
                    //MessageBox.Show("¡NO EXISTEN UsuarioS!", "Validación GEdS Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //limpiando al datagrid
                    dataGridView2.DataSource = lstParExcelColumna;
                }
                else
                {
                    // DataTable
                    DataTable table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(lstParExcelColumna);
                    dataGridView2.DataSource = table;
                    dataGridView2.Update();
                    dataGridView2.Refresh();
                }
                grid2 = false;
            }
            else if (!grid1 && !grid2)
            {
                //cargo los dos
                lstParExcel = objParaExcelController.load();
                if (lstParExcel.Count != 0)
                {
                    // DataTable
                    DataTable table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(lstParExcel);
                    dataGridView1.DataSource = table;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
                else if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //UsuarioController objUsuarioController = new UsuarioController();
                //lstUsuario = objUsuarioController.load();
                //Cargado grid 2
                lstParExcelColumna = objParExcelColumnaController.loadBypex_id(lstParExcel[0].Pex_id);
                //if (lstParExcelColumna.Count == 0)
                //{
                //    //MessageBox.Show("¡NO EXISTEN UsuarioS!", "Validación GEdS Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //limpiando al datagrid
                //    dataGridView2.Rows.Clear();
                //}
                if (lstParExcelColumna.Count != 0)
                {
                    // DataTable
                    DataTable table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(lstParExcelColumna);
                    dataGridView2.DataSource = table;
                    dataGridView2.Update();
                    dataGridView2.Refresh();
                }
                else if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Rows.Clear();
                }
            }
        }



        private void childForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            cargar();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            if (dataGridView1.CurrentCell != null)
            {
                // Find Name of material
                row = dataGridView1.CurrentRow.Index;
                cell = dataGridView1.CurrentCell.ColumnIndex;
                celda = dataGridView1.Rows[row].Cells[0];
                pex_id = (long)celda.Value;


                List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();

                //UsuarioController objUsuarioController = new UsuarioController();
                //lstUsuario = objUsuarioController.load();
                ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();
                lstParExcelColumna = objParExcelColumnaController.loadBypex_id(pex_id);
                if (lstParExcelColumna.Count == 0)
                {
                    //MessageBox.Show("¡NO EXISTEN UsuarioS!", "Validación GEdS Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dataGridView2.Rows.Count != 0)
                    {
                        List<ParExcel_Columna> listParExcelColumnaNull = new List<ParExcel_Columna>();
                        //listParExcelColumnaNull.Add(new ParExcelColumna());
                        dataGridView2.DataSource = listParExcelColumnaNull;
                        //limpiando el data grid.
                        //dataGridView2.DataSource = null;
                    }
                }
                else
                {
                    // DataTable
                    DataTable table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(lstParExcelColumna);
                    dataGridView2.DataSource = table;
                    dataGridView2.Update();
                    dataGridView2.Refresh();


                }
            }
        }



        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Session objSession = new Session();
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNewColumn":
                    objSession.ID = pex_id;
                    frmParExcelColumna childForm2 = new frmParExcelColumna();
                    childForm2.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    grid2 = true;
                    childForm2.Show();
                    break;

                case "cmdEditColumn":
                    grid2 = true;
                    objSession.ID = pec_id1;
                    // Edit Empresa
                    frmParExcelColumna objParExcelColumna = new frmParExcelColumna();
                    objParExcelColumna.FormClosed += new FormClosedEventHandler(childForm2_FormClosed);
                    objParExcelColumna.buscar();
                    objParExcelColumna.ShowDialog();
                    //EmpresaController objEmpresaController = new EmpresaController();
                    //objEmpresaController.edit();
                    break;

                case "cmdDeleteColumn":
                    if (pec_id1 == 0)
                    {
                        int row = 0;
                        int cell = 0;
                        DataGridViewCell celda;
                        // Find Name of material
                        row = dataGridView2.CurrentRow.Index;
                        cell = dataGridView2.CurrentCell.ColumnIndex;
                        celda = dataGridView2.Rows[0].Cells[0];
                        pec_id1 = (long)celda.Value;
                    }
                    switch (MessageBox.Show("Eliminar registro " + pec_id1 + " ?",
                                            "Validación GEdS Desktop",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            objSession.ID = pec_id1;
                            pec_id1 = objSession.ID;
                            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
                            List<ParExcel_Columna> lstempresa2 = new List<ParExcel_Columna>();
                            ParExcel_ColumnaController objParExcelColumnaController = new ParExcel_ColumnaController();
                            lstParExcelColumna = objParExcelColumnaController.find();
                            if (lstParExcelColumna.Count != 0)
                            {
                                lstParExcelColumna.ForEach(delegate(ParExcel_Columna u)
                                {
                                    lstempresa2.Add(new ParExcel_Columna(pec_id1, u.Pex_id, u.Pec_Columna, u.Pec_fila, u.Tco_id, u.Mer_id, u.Umd_id, u.Pec_iva, 0, u.Var_id,u.Pec_Convercion));
                                });
                                objParExcelColumnaController.update(lstempresa2);
                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                grid2 = true;
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

                case "cmdRefreshColumn":
                    grid2 = true;
                    cargar();
                    break;

                case "cmdFindColumn":
                    //frmEmpresaBusqueda childForm = new frmEmpresaBusqueda();
                    //childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    //childForm.Show();
                    //buscar();
                    break;

                case "cmdPrintColumn":
                    break;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            // Find Name of material
            if (dataGridView2.CurrentRow != null)
            {
                row = dataGridView2.CurrentRow.Index;
                cell = dataGridView2.CurrentCell.ColumnIndex;
                celda = dataGridView2.Rows[row].Cells[0];
                pec_id1 = (long)celda.Value;
            }
        }

    }
}
