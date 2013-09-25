using System;
using System.Windows.Forms;
using ypfbApplication.Controller;
using System.Collections.Generic;
using Model;

namespace ypfbApplication.View
{
    public partial class frmContratoCampo : Form
    {
        bool flagValidacion;
        public static long ctc_id = 0;
        public frmContratoCampo()
        {
            InitializeComponent();
            lblContrato.Text = (frmContratoLista.ctt_nombre1 != "" ? "Contrato: " + frmContratoLista.ctt_nombre1 : "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void cboCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #region Metodos Controller
        public void Buscar()
        {
            cbofields1.Items.Clear();
            cbofields1.DataSource = CampoController.GetListCampos(0);
            cbofields1.DisplayMember = "cam_nombre";
            cbofields1.ValueMember = "cam_id";            
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
            lstContratoCampo = ContratoCampoController.GetListContratoCampos(frmContratoCampoLista.ctc_id1);
            if (lstContratoCampo.Count != 0)
            {

                foreach (Contrato_Campo item in lstContratoCampo)
                {
                    cbofields1.Text = item.Cam_nombre;
                    ctc_id = item.Ctc_id;
                }
                flagValidacion = true;
            }

            else
            {
                ctc_id = 0;
                flagValidacion = false;
            }
        }
        protected void Guardar()
        {
            long accion = 0;
            if (flagValidacion == true)//Actualizar
            {
                switch (MessageBox.Show("Actualizar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                        lstContratoCampo.Add(new Contrato_Campo(ctc_id, frmContratoLista.ctt_id1, Convert.ToInt64(cbofields1.SelectedValue), 1));
                        Contrato_Campo contratoCampo = new Contrato_Campo();
                        accion = contratoCampo.update(lstContratoCampo);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en la actualización", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se actualizó registro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else//Registrar
            {
                switch (MessageBox.Show("Grabar registro?", "Validación del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
                        lstContratoCampo.Add(new Contrato_Campo(0, frmContratoLista.ctt_id1, Convert.ToInt64(cbofields1.SelectedValue), 1));
                        Contrato_Campo contratoCampo = new Contrato_Campo();
                        accion = contratoCampo.insert(lstContratoCampo);
                        if (accion == 0)
                        {
                            MessageBox.Show(this, "Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Se registró con éxito", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        flagValidacion = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        protected void Cargar()
        {
            cbofields1.DataSource = CampoController.GetListCampos(0);
            cbofields1.DisplayMember = "cam_nombre";
            cbofields1.ValueMember = "cam_id";
        }
        #endregion
        private void frmContratoCampo_Load(object sender, EventArgs e)
        {
            if (flagValidacion == false)
                Cargar();
        }
    }
}