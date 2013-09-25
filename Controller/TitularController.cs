using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class TitularController
    {
        public static List<Titular> GetListTitulares(long tit_id)
        {
            TitularObject titular = new TitularObject();
            return titular.listTitular(tit_id);
        }
        public static List<Titular> GetListTitularesSegunCriterio(string tit_codigo, string tit_nombre)
        {
            TitularObject titular = new TitularObject();
            return titular.listTitularSegunCriterio(tit_codigo, tit_nombre);
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

        public static List<Titular> GetListTitular(long tit_id)
        {
            TitularObject campo = new TitularObject();
            return campo.listTitular(tit_id);
        }

        public static Titular GetDatosTitular(long tit_id)
        {
            TitularObject objCampo = new TitularObject();
            return objCampo.TitularPorCodigo(tit_id);
        }

    }
}