using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ypfbApplication.View;
using Model;

namespace Controller
{
    public sealed class ParExcelController
    {
        public void index()
        {
            // Open List Usuario Form
            frmParExcelLista objParExcelLista = new frmParExcelLista();
            objParExcelLista.Show();
        }

        public List<ParExcel> load()
        {
            Session objSession = new Session();
            List<ParExcel> lstParExcel = new List<ParExcel>();
            ParExcelObject objParExcelObject = new ParExcelObject();
            lstParExcel = objParExcelObject.listParExcel(0);
            return lstParExcel;
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

        public void save(List<ParExcel> lstParExcel)
        {
            // Save data from Usuario
            ParExcel objParExcel = new ParExcel();
            objParExcel.insert(lstParExcel);
        }

        public void update(List<ParExcel> lstParExcel)
        {
            //string condition = "";
            // Update data from Usuario
            ParExcel objParExcel = new ParExcel();
            //if (lstParExcel.Count == 0)
            //{
            //}
            //else
            //{
            //    lstParExcel.ForEach(delegate(ParExcel u)
            //    {
            //        condition = "idUsuario=" + u.Pex_id;
            //    });
            //}
            objParExcel.update(lstParExcel);
        }



        public List<ParExcel> find()
        {
            long pax_id = 0;
            Session objSession = new Session();
            pax_id = objSession.ID;
            List<ParExcel> lstParExcel = new List<ParExcel>();
            ParExcelObject objParExcelObject = new ParExcelObject();
            lstParExcel = objParExcelObject.listParExcel(pax_id);
            return lstParExcel;
        }
    }
}
