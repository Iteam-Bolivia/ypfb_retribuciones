using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using Controller;
using View;

namespace ypfbApplication.View
{
    public partial class frmCalculoListaSimulacion : Form
    {
        long cal2_id;
        long ctt_id;
        long tcl_id;
        string tcl_codigo2;
        long mes_id;
        string mes_codigo2;
        long ani_id;
        bool estadoDataGridView = true;
        List<Calculo> listaCalculo;
        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

        public frmCalculoListaSimulacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method frmCalculoListaSimulacion_Load
        /// </summary>
        private void frmCalculoListaSimulacion_Load(object sender, EventArgs e)
        {
            Cargar(listaCalculo);
            dataGridView1.ClearSelection();
        }



        /// <summary>
        /// Method dataGridView1_Click
        /// </summary>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int cell = 0;
            DataGridViewCell celda;
            Session objSession = new Session();

            // Find Name of material
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            cal2_id = (long)celda.Value;
            objSession.CAL_ID = cal2_id;

            celda = dataGridView1.Rows[row].Cells[1];
            ctt_id = (long)celda.Value;
            objSession.CTT_ID = ctt_id;

            celda = dataGridView1.Rows[row].Cells[3];
            tcl_codigo2 = (string)celda.Value;

            List<Tipo_Calculo> lstTipoCalculo = new List<Tipo_Calculo>();
            // Buscar id tipo calculo
            Tipo_CalculoObject objTipoCalculoObject = new Tipo_CalculoObject();
            lstTipoCalculo = objTipoCalculoObject.listTipoCalculo(tcl_codigo2);
            lstTipoCalculo.ForEach(delegate(Tipo_Calculo tc)
            {
                tcl_id = tc.Tcl_id;
                objSession.TCL_ID = tcl_id;
            });

            celda = dataGridView1.Rows[row].Cells[4];
            ani_id = (long)celda.Value;
            objSession.ANI_ID = ani_id;

            celda = dataGridView1.Rows[row].Cells[5];
            mes_codigo2 = (string)celda.Value;
            // Buscar id mes
            for (int i = 0; i < MESES.Length; i++)
            {
                if (MESES[i] == mes_codigo2)
                {
                    mes_id = i + 1;
                    objSession.MES_ID = mes_id;
                    break;
                }
            }


            //Adicionar
            toolBar1.Buttons[0].Enabled = true;
            //Eliminar
            toolBar1.Buttons[1].Enabled = true;
            //Editar
            toolBar1.Buttons[2].Enabled = true;
            toolBar1.Buttons[5].Enabled = true;

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
            ctt_id = (long)celda.Value;

            // Edit
            Session objSession = new Session();
            objSession.ID = ctt_id;

            // Edit Calculo
            frmCalculoSimulacion childForm = new frmCalculoSimulacion();
            childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            childForm.ShowDialog();


        }


        /// <summary>
        /// Method dataGridView1_CellFormatting
        /// </summary>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          try
          {

            if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[3].Value == "RETRIBUCIÓN RECÁLCULO")
            {
              foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
              {
                if (celda.ColumnIndex == 3)
                {
                  celda.Style.BackColor = System.Drawing.Color.AliceBlue;
                }
              }
            }

            if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[3].Value == "RETRIBUCIÓN A CUENTA")
            {
              foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
              {
                if (celda.ColumnIndex == 3)
                {
                  celda.Style.BackColor = System.Drawing.Color.LightCyan;
                }
              }
            }

            if ((String)this.dataGridView1.Rows[e.RowIndex].Cells[3].Value == "PROYECCIONES")
            {
                foreach (DataGridViewCell celda in this.dataGridView1.Rows[e.RowIndex].Cells)
                {
                    if (celda.ColumnIndex == 3)
                    {
                        celda.Style.BackColor = System.Drawing.Color.AliceBlue;
                    }
                }
            }

          }
          catch (ArgumentOutOfRangeException)
          {
            Console.WriteLine("Un ArgumentOutOfRangeException ocurrió");
          }
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (estadoDataGridView)
            {
                estadoDataGridView = false;
                this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            }
        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }



        /// <summary>
        /// Method formatDataGridView
        /// </summary>
        private void formatDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
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
                    frmCalculoBusquedaSimulacion.listaCalculos = null;
                    frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                    frmCalculoSimulacion childForm = new frmCalculoSimulacion();
                    childForm.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    childForm.ShowDialog(); ;
                    break;

                case "cmdEdit":
                    objSession.ID = ctt_id;
                    // Edit Calculo
                    frmCalculoBusquedaSimulacion.listaCalculos = null;
                    frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                    frmCalculoSimulacion childForm2 = new frmCalculoSimulacion();
                    childForm2.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    childForm2.Show();
                    break;

                case "cmdDelete":
                    frmCalculoBusquedaSimulacion.listaCalculos = null;
                    frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                    switch (MessageBox.Show("Eliminar registro " + ctt_id + " ?",
                                            "Validación GEdS Desktop",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            ctt_id = objSession.ID;
                            List<Calculo> lstCalculo = new List<Calculo>();
                            List<Calculo> lstCalculo2 = new List<Calculo>();
                            CalculoObject objCalculoObject = new CalculoObject();
                            lstCalculo = objCalculoObject.listCalculo(ctt_id);
                            if (lstCalculo.Count != 0)
                            {
                                lstCalculo.ForEach(delegate(Calculo u)
                                {
                                    //lstCalculo2.Add(new Calculo(0, u.Suc_id, u.Rol_id, u.Usu_nombres, u.Usu_apellidos, u.Usu_iniciales, u.Usu_fono, u.Usu_email, u.Usu_login, u.Usu_pass, u.Usu_intento, 0));
                                });
                                CalculoController objCalculoController2 = new CalculoController();
                                objCalculoController2.update(lstCalculo2);

                                MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Cargar(listaCalculo);
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
                    frmCalculoListaSimulacion_Load(sender, e);
                    break;

                case "cmdFind":
                    frmCalculoBusquedaSimulacion.listaCalculos = null;
                    frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                    frmCalculoBusquedaSimulacion childForm6 = new frmCalculoBusquedaSimulacion();

                    childForm6.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
                    childForm6.ShowDialog();
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
            //cargar();
            if (frmCalculoBusquedaSimulacion.flagBusqueda == 0)
            {
                Cargar(listaCalculo);
                frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                frmCalculoBusquedaSimulacion.listaCalculos = null;
            }
            else
            {
                Cargar(frmCalculoBusquedaSimulacion.listaCalculos);
                frmCalculoBusquedaSimulacion.flagBusqueda = 0;
                frmCalculoBusquedaSimulacion.listaCalculos = null;
            }
        }



        /// <summary>
        /// Method childForm2_FormClosed
        /// </summary>
        //private void childForm2_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //  cargar();
        //}


        ///// <summary>
        ///// Method childForm3_FormClosed
        ///// </summary>
        //private void childForm3_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //  cargar();
        //}


        ///// <summary>
        ///// Method childForm4_FormClosed
        ///// </summary>
        //private void childForm4_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //  cargar();
        //}










        /// <summary>
        /// Method cargar
        /// </summary>
        private void Cargar(List<Calculo> lstCalculos)
        {
            formatDataGridView();
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;

            dataGridView1.AutoGenerateColumns = false;
            //List<Calculo> lstCalculo = new List<Calculo>();

            CalculoController objCalculoController = new CalculoController();


            // DataTable
            DataTable table = new DataTable();

            if (lstCalculos == null)
            {
                lstCalculos = new List<Calculo>();
                lstCalculos = objCalculoController.load(0);
            }

            if (lstCalculos.Count == 0)
            {
                //MessageBox.Show("¡NO EXISTEN CalculoS!", "Validación GEdS Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Misc objMisc = new Misc();
                table = objMisc.GenericListToDataTable(lstCalculos);

            }
            //toolBar1.Buttons[0].Enabled = false;
            toolBar1.Buttons[1].Enabled = false;
            toolBar1.Buttons[2].Enabled = false;
            toolBar1.Buttons[5].Enabled = false;
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            dataGridView1.Refresh();

            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            dataGridView1.ClearSelection();

        }

        /// <summary>
        /// Method buscar
        /// </summary>
        private void buscar(List<Calculo> lstCalculo)
        {
            if (lstCalculo.Count == 0)
            {
                MessageBox.Show("¡NO EXISTEN CalculoS!", "Validación GEdS Desktop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                Misc objMisc = new Misc();
                dt = objMisc.GenericListToDataTable(lstCalculo);
                dataGridView1.DataSource = dt;
            }
        }





    }
}