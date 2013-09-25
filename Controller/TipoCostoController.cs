using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Controller
{
    public sealed class TipoCostoController
    {
        public void index()
        {
            //// Open List Usuario Form
            //frm objUsuarioLista = new frmUsuarioLista();
            //objUsuarioLista.Show();
        }

        public List<TipoColumna> load()
        {
            Session objSession = new Session();
            List<TipoColumna> lstTipoCosto = new List<TipoColumna>();
            Tipo_ColumnaObject objTipoCostoObject = new Tipo_ColumnaObject();
            lstTipoCosto = objTipoCostoObject.listTipoCosto(0);
            return lstTipoCosto;
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

        public void save(List<TipoColumna> lstTipoCosto)
        {
            // Save data from Usuario
            TipoColumna objTipoCosto = new TipoColumna();
            objTipoCosto.insert(lstTipoCosto);
        }

        public void update(List<TipoColumna> lstTipoCosto)
        {
            //string condition = "";
            // Update data from Usuario
            TipoColumna objTipoCosto = new TipoColumna();
            //if (lstTipoCosto.Count == 0)
            //{
            //}
            //else
            //{
            //    lstTipoCosto.ForEach(delegate(TipoCosto u)
            //    {
            //        condition = "idUsuario=" + u.Tco_id;
            //    });
            //}
            objTipoCosto.update(lstTipoCosto);
        }



        public List<TipoColumna> find()
        {
            long tco_id = 0;
            Session objSession = new Session();
            tco_id = objSession.ID;
            List<TipoColumna> lstTipoCosto = new List<TipoColumna>();
            Tipo_ColumnaObject TipoCostoObject = new Tipo_ColumnaObject();
            lstTipoCosto = TipoCostoObject.listTipoCosto(tco_id);
            return lstTipoCosto;
        }
    }
}
