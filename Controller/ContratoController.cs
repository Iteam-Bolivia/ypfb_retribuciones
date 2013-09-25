using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class ContratoController
    {
        /// <summary>
        /// Recupera Contratos por Sucursal Formulario frmContratoLista
        /// </summary>
        /// <param name="suc_id"></param>
        /// <returns>Lista de Contratos</returns>
        public static List<Contrato> GetListContratosBySucursal(long suc_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoPorSucursal(suc_id);
        }

        public static List<Contrato> GetListContratosBySucursalAndUsuario(long suc_id, int usu_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoPorSucursalUsuario(suc_id, usu_id);
        }
        /// <summary>
        /// Recupera Contratos por Sucursal Formulario frmContratoLista
        /// </summary>
        /// <param name="suc_id"></param>
        /// <param name="ctt_codigo"></param>
        /// <param name="ctt_nombre"></param>
        /// <param name="ctt_periodo"></param>
        /// <param name="ctt_fecini"></param>
        /// <param name="ctt_fecfin"></param>
        /// <returns>Lista de Contratos</returns>
        public static List<Contrato> GetListContratosByCriterio(long suc_id, string ctt_codigo, string ctt_nombre, string ctt_periodo, string ctt_fecini, string ctt_fecfin)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoSegunCriterio(suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin);
        }

        public static List<Contrato> GetListContratosByCriterioAndUsuario(long suc_id, string ctt_codigo, string ctt_nombre, string ctt_periodo, string ctt_fecini, string ctt_fecfin, int usu_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoSegunCriterioUsuario(suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin, usu_id);
        }

        public static List<Contrato> GetListContrato(long ctt_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContrato(ctt_id);
        }

        public static Contrato GetContratoByCamp_idAndTit_Id(long tit_id, long cam_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoPorTit_idAndCam_Id(tit_id, cam_id);
        }
        public static Contrato GetDatosContrato(long ctt_id)
        {
            ContratoObject objContrato = new ContratoObject();
            return objContrato.ContratoPorCodigo(ctt_id);
        }

        public static List<Contrato> FindContratoByCtt_Name(string ctt_nombre)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.FindContratoByCtt_Name(ctt_nombre);
        }


        public static List<Contrato> GetListContratoAndUsu(long ctt_id)
        {
            ContratoObject objetoContrato = new ContratoObject();
            return objetoContrato.listContratoandUsu_id(ctt_id);
        }
    }
}