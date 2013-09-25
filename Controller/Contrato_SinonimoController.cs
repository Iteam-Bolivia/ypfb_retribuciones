using System.Collections.Generic;
using Model;
using ypfbApplication.View;

namespace ypfbApplication.Controller
{
    public sealed class Contrato_SinonimoController
    {

      public static Contrato ExisteSinonimoContrato(string ctt_nombre)
      {
        Contrato_SinonimoObject obj = new Contrato_SinonimoObject();
        return obj.buscarSinonimoContrato(ctt_nombre);
      }


        public List<Contrato_Sinonimo> find()
        {
            long reg_id = 0;
            Session objSession = new Session();
            reg_id = objSession.ID;
            List<Contrato_Sinonimo> lstContrato_Sinonimo = new List<Contrato_Sinonimo>();
            Contrato_SinonimoObject objContrato_SinonimoObject = new Contrato_SinonimoObject();
            lstContrato_Sinonimo = objContrato_SinonimoObject.listContrato_Sinonimo(reg_id);
            return lstContrato_Sinonimo;
        }
        public static List<Contrato_Sinonimo> GetListaContrato_SinonimoPorContrato(long ctt_id)
        {
            Contrato_SinonimoObject objContrato_Sinonimo = new Contrato_SinonimoObject();
            return objContrato_Sinonimo.listContrato_SinonimoPorContrato(ctt_id);
        }
        public static List<Contrato_Sinonimo> GetListaContrato_Sinonimo(long reg_id)
        {
            Contrato_SinonimoObject objContrato_Sinonimo = new Contrato_SinonimoObject();
            return objContrato_Sinonimo.listContrato_Sinonimo(reg_id);
        }
    }
}