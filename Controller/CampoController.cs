using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class CampoController
    {
        //public static List<Campo> GetListCamposPorContrato(long ctt_id)
        //{
        //    CampoObject campo = new CampoObject();
        //    return campo.listCamposPorContrato(ctt_id);
        //}
        public static List<Campo> GetListCampos(long cam_id)
        {
            CampoObject campo = new CampoObject();
            return campo.listCampo(cam_id);
        }

        public static List<Campo> GetListCamposContrato(long ctt_id)
        {
          CampoObject campo = new CampoObject();
          return campo.ListaCampoContrato(ctt_id);
        }


        public static List<Campo> GetListCamposSegunCriterio( string cam_codigo, string cam_nombre)
        {
            CampoObject campo = new CampoObject();
            return campo.listCampoSegunCriterio( cam_codigo, cam_nombre);
        }


        public static bool SerchCampoByName(string name, long ctt_id)
        {
          CampoObject campoObject = new CampoObject();
          return campoObject.SerchCampoByName(name, ctt_id);
        }


        public static Campo SerchCampoByName(string name)
        {
            CampoObject campoObject = new CampoObject();
            return campoObject.SerchCampoByName(name);
        }
        public static Campo GetDatosCampo(long cam_id)
        {
            CampoObject objCampo = new CampoObject();
            return objCampo.CampoPorCodigo(cam_id);
        }

        internal static Campo SerchCampoBySinonimo(string cas_nombre)
        {
            CampoObject objCampo = new CampoObject();
            return objCampo.SerchCampoBySinonimo(cas_nombre);
        }
    }
}