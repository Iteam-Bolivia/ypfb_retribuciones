using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TitularContratoController
    {
        /// <summary>
        /// Recupera TitularesContrato por Contrato
        /// </summary>
        /// <param name="ctt_id"></param>
        /// <returns>Lista TitularesContrato por Contrato</returns>
        public static List<Titular_Contrato> GetListTitularesContratoPorContrato(long ctt_id)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.listaTitularesContratoPorContrato(ctt_id);
        }
        public static List<Titular_Contrato> GetListTitularContratos(long ttc_id)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.listTitularContrato(ttc_id);
        }

        public static int GetVerificaTitularContratoOperador(long ctt_id, string ttc_tipo)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.VerificaTitularContratoOperador(ctt_id, ttc_tipo);
        }

        public static decimal GetVerificaTitularContratoPorcentaje(long ctt_id)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.VerificaTitularContratoPorcentaje(ctt_id);
        }
        public static Titular_Contrato GetDatosTitularContrato(long ttc_id)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.DatosTitularesContrato(ttc_id);
        }

        public static List<Titular_Contrato> SerchByName(string tit_nombre)
        {
          TitularContratoObject objTitularContrato = new TitularContratoObject();
          return objTitularContrato.listaTitularesPorNombreTitular(tit_nombre);
        }


        public static List<Titular_Contrato> listaTitularesPorContratoSoloOperador(long ctt_id)
        {
          TitularContratoObject objTitularContrato = new TitularContratoObject();
          return objTitularContrato.listaTitularesPorContratoSoloOperador(ctt_id);
        }


        public static List<Titular_Contrato> listaTitularesPorNombreContrato(string ctt_nombre)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.listaTitularesPorNombreContrato(ctt_nombre);
        }

        public static List<Titular_Contrato> listaTitularesPorNombreTitular(string tit_nombre)
        {
            TitularContratoObject objTitularContrato = new TitularContratoObject();
            return objTitularContrato.listaTitularesPorNombreTitular(tit_nombre);
        }

        //public static List<Titular_Contrato> SerchBySinonimo(string tis_nombre)
        //{
        //    TitularContratoObject objTitularContrato = new TitularContratoObject();
        //    return objTitularContrato.bus.SerchBySinonimo(tis_nombre);
        //}
    }
}


