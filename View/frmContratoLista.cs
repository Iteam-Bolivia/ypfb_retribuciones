using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Model;
using ypfbApplication.Controller;

namespace ypfbApplication.View
{
    public partial class frmContratoLista : Form
    {
        public static long ctt_id1 = 0;
        public static string ctt_nombre1;
        List<Contrato> listaContratos;
        bool estadoDataGridView = true;
        public frmContratoLista()
        {
            InitializeComponent();
        }
        #region Eventos Pagina
        private void frmContratoLista_Load(object sender, EventArgs e)
        {
            Cargar(listaContratos);
            dataGridView1.ClearSelection();
        }
        private void frmContratoLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmContratoBusqueda.flagBusqueda == 0)
            {
                Cargar(listaContratos);
                frmContratoBusqueda.flagBusqueda = 0;
                frmContratoBusqueda.listaContratos = null;
            }
            else
            {
                Cargar(frmContratoBusqueda.listaContratos);
                frmContratoBusqueda.flagBusqueda = 0;
                frmContratoBusqueda.listaContratos = null;
            }
        }
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (ContratoController.GetDatosContrato(ctt_id1) != null)
                ctt_nombre1 = ContratoController.GetDatosContrato(ctt_id1).Ctt_nombre;
            ToolBarButton button = e.Button;
            switch (button.Name)
            {
                case "cmdNew":
                    frmContrato frmContratoNew = new frmContrato();
                    frmContratoNew.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    listaContratos = null;
                    frmContratoBusqueda.flagBusqueda = 0;
                    frmContratoNew.ShowDialog();
                    break;

                case "cmdEdit":
                    frmContrato frmContratoEdit = new frmContrato();
                    frmContratoEdit.Buscar();
                    listaContratos = null;
                    frmContratoBusqueda.flagBusqueda = 0;
                    frmContratoEdit.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContratoEdit.ShowDialog();
                    break;
                case "cmdDelete":
                    listaContratos = null;
                    frmContratoBusqueda.flagBusqueda = 0;
                    switch (MessageBox.Show("Eliminar registro " + ctt_id1 + " ?",
                                            "Validación del Sistema",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:

                            List<Contrato> lstContrato = new List<Contrato>();
                            List<Contrato> lstContrato2 = new List<Contrato>();
                            ContratoObject objContrato = new ContratoObject();
                            Contrato objContrato2 = new Contrato();
                            lstContrato = objContrato.listContrato(ctt_id1);
                            if (lstContrato.Count != 0)
                            {
                                foreach (Contrato item in lstContrato)
                                {
                                    Contrato contrato = new Contrato();
                                    contrato.Ctt_id = item.Ctt_id;
                                    contrato.Suc_id = item.Suc_id;
                                    contrato.Ctt_codigo = item.Ctt_codigo;
                                    contrato.Ctt_nombre = item.Ctt_nombre;
                                    contrato.Ctt_periodo = item.Ctt_periodo;
                                    contrato.Ctt_fecini = item.Ctt_fecini;
                                    contrato.Ctt_fecfin = item.Ctt_fecfin;
                                    contrato.Ctt_depacu = item.Ctt_depacu;
                                    contrato.Ctt_depacuma = item.Ctt_depacuma;
                                    contrato.Ctt_acugantit = item.Ctt_acugantit;
                                    contrato.Ctt_invacu = item.Ctt_invacu;
                                    contrato.Ctt_invacuma = item.Ctt_invacuma;
                                    contrato.Ctt_acuimptit = item.Ctt_acuimptit;
                                    contrato.Ctt_estado = 0;
                                    lstContrato2.Add(contrato);
                                }

                                if (objContrato2.update(lstContrato2) != 0)
                                {
                                    MessageBox.Show("Se elimino registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.Cargar(listaContratos);
                                }
                                else
                                    MessageBox.Show(this, "Hubo error en la eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    frmContratoLista_Load(sender, e);
                    break;
                case "cmdFind":
                    frmContratoBusqueda frmContratoBusquedaFind = new frmContratoBusqueda();
                    frmContratoBusquedaFind.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContratoBusqueda.listaContratos = null;
                    frmContratoBusqueda.flagBusqueda = 0;
                    frmContratoBusquedaFind.ShowDialog();
                    break;
                case "cmdPrint":
                    break;
                case "cmdClose":
                    this.Close();
                    break;
                case "cmdTitulares":
                    frmTitularContratoLista frmTitularContratoList = new frmTitularContratoLista();
                    frmTitularContratoList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmTitularContratoList.Text = (ctt_nombre1 != "" ? "Empresas asociados al Contrato: " + ctt_nombre1 : "Contrato Empresas");
                    frmTitularContratoList.ShowDialog();
                    break;
                case "cmdCampos":
                    frmContratoCampoLista frmContratoCampoList = new frmContratoCampoLista();
                    frmContratoCampoList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContratoCampoList.Text = (ctt_nombre1 != "" ? "Campos asociados al Contrato: " + ctt_nombre1 : "Contrato Campos");
                    frmContratoCampoList.ShowDialog();
                    break;
                case "cmdCalculos":
                    frmTablaCalculoLista frmTablaCalculoList = new frmTablaCalculoLista();
                    frmTablaCalculoList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmTablaCalculoList.Text = (ctt_nombre1 != "" ? "Tablas asociadas al Contrato: " + ctt_nombre1 : "Tabla");
                    frmTablaCalculoList.ShowDialog();
                    break;
                case "cmdRegalias":
                    frmRegaliaLista frmRegaliaList = new frmRegaliaLista();
                    frmRegaliaList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmRegaliaList.Text = (ctt_nombre1 != "" ? "Regalías asociadas al Contrato: " + ctt_nombre1 : "Contrato Campos");
                    frmRegaliaList.ShowDialog();
                    break;
                case "cmdSinonimos":
                    frmContrato_SinonimoLista frmContrato_SinonimoList = new frmContrato_SinonimoLista();
                    frmContrato_SinonimoList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContrato_SinonimoList.Text = (ctt_nombre1 != "" ? "Sinonimos asociadas al Contrato: " + ctt_nombre1 : "");
                    frmContrato_SinonimoList.ShowDialog();
                    break;
                case "cmdCondiciones":
                    frmContrato_CondicionLista frmContrato_CondicionList = new frmContrato_CondicionLista();
                    frmContrato_CondicionList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContrato_CondicionList.Text = (ctt_nombre1 != "" ? "Condiciones del Contrato: " + ctt_nombre1 : "");
                    frmContrato_CondicionList.ShowDialog();
                    break;

                case "cmdMarginales":
                    frmContrato_MarginalLista frmContrato_MarginalList = new frmContrato_MarginalLista();
                    frmContrato_MarginalList.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
                    frmContrato_MarginalList.Text = (ctt_nombre1 != "" ? "Condiciones del Contrato: " + ctt_nombre1 : "");
                    frmContrato_MarginalList.ShowDialog();
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
            row = dataGridView1.CurrentRow.Index;
            cell = dataGridView1.CurrentCell.ColumnIndex;
            celda = dataGridView1.Rows[row].Cells[0];
            try
            {
                Session objSesion = new Session();
                long rolUsuario = objSesion.ROL_ID;
                string rol = "";
                List<Rol> nombreRol = new List<Rol>();
                nombreRol = RolController.GetListRoles(rolUsuario);
                if (nombreRol.Count != 0)
                {
                    foreach (Rol item in nombreRol)
                    {
                        rol = item.Rol_titulo;
                    }

                    if (!string.IsNullOrEmpty(celda.Value.ToString()))
                    {
                        ctt_id1 = Convert.ToInt64(celda.Value);
                        //Adicionar
                        toolBar1.Buttons[0].Enabled = false;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = true;
                        //Editar
                        toolBar1.Buttons[2].Enabled = true;
                        //Empresas
                        toolBar1.Buttons[7].Enabled = true;
                        //Campos
                        toolBar1.Buttons[8].Enabled = true;
                        //Tabla Calculos
                        toolBar1.Buttons[9].Enabled = true;
                        //Regalias
                        toolBar1.Buttons[10].Enabled = true;
                        //Sinonimos
                        toolBar1.Buttons[11].Enabled = true;
                        //Condiciones
                        toolBar1.Buttons[12].Enabled = true;

                        //Marginales
                        toolBar1.Buttons[13].Enabled = true;
                    }
                    else
                    {
                        //Adicionar
                        toolBar1.Buttons[0].Enabled = true;
                        //Eliminar
                        toolBar1.Buttons[1].Enabled = false;
                        //Editar
                        toolBar1.Buttons[2].Enabled = false;
                        //Empresas
                        toolBar1.Buttons[7].Enabled = false;
                        //Campos
                        toolBar1.Buttons[8].Enabled = false;
                        //Tabla Calculos
                        toolBar1.Buttons[9].Enabled = false;
                        //Regalias
                        toolBar1.Buttons[10].Enabled = false;
                        //Sinonimos
                        toolBar1.Buttons[11].Enabled = false;
                        //Condiciones
                        toolBar1.Buttons[12].Enabled = false;
                        //Marginales
                        toolBar1.Buttons[13].Enabled = false;
                        ctt_id1 = 0;
                    }
                }
                else
                {
                    //Adicionar
                    toolBar1.Buttons[0].Enabled = false;
                    //Eliminar
                    toolBar1.Buttons[1].Enabled = false;
                    //Editar
                    toolBar1.Buttons[2].Enabled = false;
                    //Empresas
                    toolBar1.Buttons[7].Enabled = false;
                    //Campos
                    toolBar1.Buttons[8].Enabled = false;
                    //Tabla Calculos
                    toolBar1.Buttons[9].Enabled = false;
                    //Regalias
                    toolBar1.Buttons[10].Enabled = false;
                    //Sinonimos
                    toolBar1.Buttons[11].Enabled = false;
                    //Condiciones
                    toolBar1.Buttons[12].Enabled = false;
                    //Marginales
                    toolBar1.Buttons[13].Enabled = false;

                    ctt_id1 = 0;
                }
            }
            catch { }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
            frmContrato frmContratoEdit = new frmContrato();
            frmContratoEdit.Buscar();
            listaContratos = null;
            frmContratoBusqueda.flagBusqueda = 0;
            frmContratoEdit.FormClosed += new FormClosedEventHandler(frmContratoLista_FormClosed);
            frmContratoEdit.ShowDialog();
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
        #endregion
        #region Metodos Controller
        public void Cargar(List<Contrato> listaContratos)
        {
            Session objSesion = new Session();
            long rolUsuario = objSesion.ROL_ID;
            this.Text = this.Text + " - " + objSesion.SISTEMA;  

            //string rol = "";
            int rol = 0;
            List<Rol> nombreRol = new List<Rol>();
            nombreRol = RolController.GetListRoles(rolUsuario);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 50;
            if (nombreRol.Count != 0)
            {
                foreach (Rol item in nombreRol)
                    rol = item.Rol_id;
            }
            DataTable table = null;
            if (rol == 2)//Administrador
            {
                if (listaContratos == null)
                {
                    listaContratos = new List<Contrato>();
                    listaContratos = ContratoController.GetListContratosBySucursal(Convert.ToInt64(objSesion.SUC_ID));
                }
                if (listaContratos.Count != 0)
                {
                    table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(listaContratos);
                }
                //Volver por defecto Barra de Herramientas
                toolBar1.Buttons[0].Enabled = true;
                toolBar1.Buttons[1].Enabled = false;
                toolBar1.Buttons[2].Enabled = false;
                toolBar1.Buttons[7].Enabled = false;
                toolBar1.Buttons[8].Enabled = false;
                toolBar1.Buttons[9].Enabled = false;
                toolBar1.Buttons[10].Enabled = false;
                toolBar1.Buttons[11].Enabled = false;
                dataGridView1.Columns["nombre_completo"].Visible = true;
                dataGridView1.DataSource = table;
                //dataGridView1.Update();
                //dataGridView1.Refresh();
                this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridView1.ClearSelection();
            }
            else if (rol == 2)
            {
                if (listaContratos == null)
                {
                    listaContratos = new List<Contrato>();
                    listaContratos = ContratoController.GetListContratosBySucursalAndUsuario(objSesion.SUC_ID, Convert.ToInt32(objSesion.USU_ID));
                }
                if (listaContratos.Count != 0)
                {
                    table = new DataTable();
                    Misc objMisc = new Misc();
                    table = objMisc.GenericListToDataTable(listaContratos);
                }
                toolBar1.Buttons[0].Enabled = false;
                toolBar1.Buttons[1].Enabled = false;
                toolBar1.Buttons[2].Enabled = false;
                toolBar1.Buttons[7].Enabled = false;
                toolBar1.Buttons[8].Enabled = false;
                toolBar1.Buttons[9].Enabled = false;
                toolBar1.Buttons[10].Enabled = false;
                toolBar1.Buttons[11].Enabled = false;
                dataGridView1.Columns["nombre_completo"].Visible = false;
                dataGridView1.DataSource = table;
                //dataGridView1.Update();
                //dataGridView1.Refresh();
                this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show(this, "Usted no esta autorizado para ingresar a esta opción", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolBar1.Enabled = false;
                dataGridView1.Enabled = false;
                dataGridView1.Columns["nombre_completo"].Visible = false;
            }
        }
        #endregion

        private void frmContratoLista_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            ctt_id1 = 0;
        }

    }
}