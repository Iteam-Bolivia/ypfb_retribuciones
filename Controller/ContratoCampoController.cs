using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class ContratoCampoController
    {
        public static List<Contrato_Campo> GetListContratoCampos(long ctc_id)
        {
            ContratoCampoObject objContratoCampo = new ContratoCampoObject();
            return objContratoCampo.listContratoCampo(ctc_id);
        }


        public static List<Contrato_Campo> GetListCamposPorContrato(long ctt_id)
        {
            ContratoCampoObject objContratoCampo = new ContratoCampoObject();
            return objContratoCampo.listaCamposPorContrato(ctt_id);
        }
        public static List<Contrato_Campo> GetListContratoCamposPorContrato(long ctt_id)
        {
            ContratoCampoObject objContratoCampo = new ContratoCampoObject();
            return objContratoCampo.listContratoCamposPorContrato(ctt_id);
        }
    }
}