using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmTablaFilaColumna : Form
    {
      long tab_id1 = 0;
        public frmTablaFilaColumna()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        protected void CrossTab()
        {
            DataTable table = new DataTable();
            Session objSession = new Session();
            tab_id1 = objSession.ID;
            List<Tabla_Fila> listaFilas = new List<Tabla_Fila>();
            List<Tabla_Columna> listaColumnas = new List<Tabla_Columna>();
            
            // Modified: castellon - ypfb
            //listaFilas = TablaFilaController.GetListaTablaFilaPorTabla(frmTablaVisualLista.tab_id1);
            listaFilas = TablaFilaController.GetListaTablaFilaPorTabla(tab_id1);

            int cantidadColumnas = 0;
            try
            {
                listaColumnas = TablaColumnaController.GetListaTablaColumnaPorTablaFila(listaFilas[0].Taf_id);
                cantidadColumnas = TablaColumnaController.GetCantidadColumnasPorTablaFila(listaColumnas[0].Taf_id);
            }
            catch
            {
                MessageBox.Show("La Tabla Seleccionada no se encuentra configurada de forma correcta\n Revise los datos por favor", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            table.Columns.Add("MPC/dia");

            try
            {
                for (int i = 1; i < cantidadColumnas; i++)
                {
                    table.Columns.Add("Desde " + listaColumnas[i].Tac_valor);
                }

                for (int i = 1; i < listaFilas.Count; i++)
                {

                    listaColumnas = TablaColumnaController.GetListaTablaColumnaPorTablaFila(listaFilas[i].Taf_id);

                    DataRow fila = table.NewRow();
                    for (int j = 0; j < cantidadColumnas; j++)
                    {
                        if (j == 0)
                            fila[j] = "Desde " + listaColumnas[j].Tac_valor;
                        else
                          //  fila[j] = string.Format("{0:0}", listaColumnas[j].Tac_valor) + "%";
                          fila[j] =  listaColumnas[j].Tac_valor;
                    }

                    table.Rows.Add(fila);
                }

                dataGridView1.DataSource = table;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 234, 219);
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(235, 234, 219);
                dataGridView1.ClearSelection();
            }
            catch
            {
                MessageBox.Show("La Tabla Seleccionada no se encuentra configurada de forma correcta\n Revise los datos por favor", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void frmTablaFilaColumna_Load(object sender, EventArgs e)
        {
            CrossTab();
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            //List<Tabla_Fila> fila = TablaFilaController.GetListaTablaFilaPorTabla(1);

            //string strnumber = listaColumnaHeader[0].Tac_valor; // (e.RowIndex + 1).ToString();
            //while (strnumber.Length < dataGridView1.RowCount.ToString().Length)
            //{
            //    strnumber = listaColumnaHeader[e.RowIndex].Tac_valor; // "0" + strnumber;
            //}
            //SizeF size = e.Graphics.MeasureString(strnumber, this.Font);
            //if (dataGridView1.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
            //    dataGridView1.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
            //Brush bt = SystemBrushes.ControlText;
            //e.Graphics.DrawString(strnumber, this.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
    }
}