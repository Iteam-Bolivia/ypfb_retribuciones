using System.Collections.Generic;
using Model;
using ypfbApplication.View;

namespace ypfbApplication.Controller
{
    public sealed class RegaliaController
    {
        public List<Regalia> find()
        {
            long reg_id = 0;
            Session objSession = new Session();
            reg_id = objSession.ID;
            List<Regalia> lstRegalia = new List<Regalia>();
            RegaliaObject objRegaliaObject = new RegaliaObject();
            lstRegalia = objRegaliaObject.listRegalia(reg_id);
            return lstRegalia;
        }
        public static List<Regalia> GetListaRegaliaPorContrato(long ctt_id)
        {
            RegaliaObject objRegalia = new RegaliaObject();
            return objRegalia.listRegaliaPorContrato(ctt_id);
        }
        public static List<Regalia> GetListaRegalia(long reg_id)
        {
            RegaliaObject objRegalia = new RegaliaObject();
            return objRegalia.listRegalia(reg_id);
        }


        public static void EliminarRegaliazIDH(long mes_id, long ani_id,char reg_tipo)
        {
            RegaliaObject objRegalia = new RegaliaObject();
            objRegalia.EliminarRegaliazIDH(ani_id,mes_id,reg_tipo);
        }

        public static long save(List<Regalia> lstRegalia)
        {
            // Save data from Calculo
            long reg_id = 0;
            Regalia objRegalia = new Regalia();
            reg_id = objRegalia.insert(lstRegalia);
            return reg_id;
        }

        public static List<Regalia> listRegaliaByAnioAndMes(long ani_id, long mes_id, string reg_tipo, string reg_tipo2)
        {
            RegaliaObject objRegalia = new RegaliaObject();
            return objRegalia.listRegaliaByAnioAndMes(ani_id, mes_id,reg_tipo,reg_tipo2);
        }
    }
}