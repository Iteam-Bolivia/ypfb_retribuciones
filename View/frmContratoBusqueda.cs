using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ypfbApplication.Controller;
using Model;

namespace ypfbApplication.View
{
    public partial class frmContratoBusqueda : Form
    {
        public static int flagBusqueda = 0;

        public static List<Contrato> listaContratos;
        public frmContratoBusqueda()
        {
            InitializeComponent();
        }

        private void frmContratoBusqueda_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            else
                Buscar(out listaContratos);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaContratos = null;
            flagBusqueda = 0;
            this.Close();
        }
        #region Metodos Controller
        protected void Cargar()
        {
            cboSucursales.DataSource = SucursalController.GetSucursales(0);
            cboSucursales.DisplayMember = "suc_nombre";
            cboSucursales.ValueMember = "suc_id";

            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Ayuda";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;

            toolTip1.SetToolTip(this.lblSucursales, "Seleccionar la Sucursal");
            toolTip1.SetToolTip(this.lblCodigo, "Indicar el Código del Contrato");
            toolTip1.SetToolTip(this.lblNombre, "Indicar el Nombre del Contrato");
            toolTip1.SetToolTip(this.lblPeriodo, "Indicar el Periodo del Contrato");
            toolTip1.SetToolTip(this.lblFechaInicio, "Seleccionar una Fecha de Inicio de Contrato");
            toolTip1.SetToolTip(this.lblFechaFin, "Seleccionar una Fecha de Fin de Contrato");

        }

        public bool Buscar(out List<Contrato> listaContratos)
        {
            string ctt_fecini = "";
            string ctt_fecfin = "";

            if (dtpInicio.Enabled == true)
                ctt_fecini = dtpInicio.Value.ToString("dd/MM/yyyy");
            else
                ctt_fecini = "";
            if (dtpFin.Enabled == true)
                ctt_fecfin = dtpFin.Value.ToString("dd/MM/yyyy");
            else
                ctt_fecfin = "";

            Session objSesion = new Session();
            long rolUsuario = objSesion.ROL_ID;
            string rol = "";
            List<Rol> nombreRol = new List<Rol>();
            nombreRol = RolController.GetListRoles(rolUsuario);
            if (nombreRol.Count != 0)
            {
                foreach (Rol item in nombreRol)
                    rol = item.Rol_titulo;
            }
            if (rol == "Administrador")
            {
                listaContratos = ContratoController.GetListContratosByCriterio(Convert.ToInt32(cboSucursales.SelectedValue), txtCodigo.Text.ToUpper(), txtNombre.Text.ToUpper(), txtPeriodo.Text, ctt_fecini, ctt_fecfin);
                if (listaContratos.Count == 0)
                {
                    flagBusqueda = 0;
                    MessageBox.Show(this, "No se encontraron Contratos según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    flagBusqueda = 1;
                    this.Close();
                    return true;
                }
            }
            else if (rol == "Analista")
            {
                listaContratos = ContratoController.GetListContratosByCriterioAndUsuario(Convert.ToInt32(cboSucursales.SelectedValue), txtCodigo.Text.ToUpper(), txtNombre.Text.ToUpper(), txtPeriodo.Text, ctt_fecini, ctt_fecfin, Convert.ToInt32(objSesion.USU_ID));
                if (listaContratos.Count == 0)
                {
                    flagBusqueda = 0;
                    MessageBox.Show(this, "No se encontraron Contratos según el criterio de búsqueda\n Intente con otros valores", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    flagBusqueda = 1;
                    this.Close();
                    return true;
                }
            }
            else
            {
                listaContratos = null;
                return false;
            }
        }

        protected bool ValidarCampos()
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) && string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtPeriodo.Text) && chkFecIni.Enabled == false && chkFecFin.Enabled == false)
            {
                //MessageBox.Show(this, "Registre el Código del Contrato", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(this, "Introdusca valores para realizar la búsqueda", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                return flag;
            }
            return flag = true;
        }
        #endregion

        private void chkFecIni_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecIni.Checked)
                dtpInicio.Enabled = true;
            else
                dtpInicio.Enabled = false;
        }

        private void chkFec_Fin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecFin.Checked)
                dtpFin.Enabled = true;
            else
                dtpFin.Enabled = false;
        }
        private void cboSucursales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (char.IsLetterOrDigit(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 32)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void dtpFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}