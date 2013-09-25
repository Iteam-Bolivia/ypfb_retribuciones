using System.Collections.Generic;
using Model;

namespace Controller
{
    public sealed class ParExcel_TipoController
    {
        public void index()
        {
            // Open List Usuario Form
            //frmParExcel_TipoLista objParExcel_TipoLista = new frmParExcel_TipoLista();
            //objParExcel_TipoLista.Show();
        }

        public static List<ParExcel_Tipo> load()
        {
            Session objSession = new Session();
            List<ParExcel_Tipo> lstParExcel_Tipo = new List<ParExcel_Tipo>();
            ParExcel_TipoObject objParExcel_TipoObject = new ParExcel_TipoObject();
            lstParExcel_Tipo = objParExcel_TipoObject.listParExcel_Tipo(0);
            return lstParExcel_Tipo;
        }

        public void view()
        {
        }

        public void create()
        {
        }

        public void edit()
        {
        }

        public void save(List<ParExcel_Tipo> lstParExcel_Tipo)
        {
            // Save data from Usuario
            ParExcel_Tipo objParExcel_Tipo = new ParExcel_Tipo();
            objParExcel_Tipo.insert(lstParExcel_Tipo);
        }

        public void update(List<ParExcel_Tipo> lstParExcel_Tipo)
        {
            ParExcel_Tipo objParExcel_Tipo = new ParExcel_Tipo();
            objParExcel_Tipo.update(lstParExcel_Tipo);
        }

        public List<ParExcel_Tipo> find()
        {
            long pax_id = 0;
            Session objSession = new Session();
            pax_id = objSession.ID;
            List<ParExcel_Tipo> lstParExcel_Tipo = new List<ParExcel_Tipo>();
            ParExcel_TipoObject objParExcel_TipoObject = new ParExcel_TipoObject();
            lstParExcel_Tipo = objParExcel_TipoObject.listParExcel_Tipo(pax_id);
            return lstParExcel_Tipo;
        }
    }
}
