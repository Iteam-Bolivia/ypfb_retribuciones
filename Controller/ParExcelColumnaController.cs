using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Controller
{
    public sealed class ParExcel_ColumnaController
    {
        public void index()
        {
            //// Open List Usuario Form
            //frm objUsuarioLista = new frmUsuarioLista();
            //objUsuarioLista.Show();
        }

        public List<ParExcel_Columna> load()
        {
            Session objSession = new Session();
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcel_ColumnaObject objParExcelColumnaObject = new ParExcel_ColumnaObject();
            lstParExcelColumna = objParExcelColumnaObject.listParExcelColumna(0);
            return lstParExcelColumna;
        }


        public List<ParExcel_Columna> loadBypex_id(long pex_id)
        {
            Session objSession = new Session();
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcel_ColumnaObject objParExcelColumnaObject = new ParExcel_ColumnaObject();
            lstParExcelColumna = objParExcelColumnaObject.listParExcelColumnaByPex_id(pex_id);
            return lstParExcelColumna;
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

        public long save(List<ParExcel_Columna> lstParExcelColumna)
        {
          long inserted=0;
            // Save data from Usuario
            ParExcel_Columna objParExcelColumna = new ParExcel_Columna();
            inserted = objParExcelColumna.insert(lstParExcelColumna);
            return inserted;
        }

        public long update(List<ParExcel_Columna> lstParExcelColumna)
        {
          long updated = 0;
            //// Update data from Usuario
            ParExcel_Columna objParExcelColumna = new ParExcel_Columna();
            updated = objParExcelColumna.update(lstParExcelColumna);
            return updated;
        }



        public List<ParExcel_Columna> find()
        {
            long pec_id = 0;
            Session objSession = new Session();
            pec_id = objSession.ID;
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcel_ColumnaObject objParExcelColumnaObject = new ParExcel_ColumnaObject();
            lstParExcelColumna = objParExcelColumnaObject.listParExcelColumna(pec_id);
            return lstParExcelColumna;
        }


        public List<ParExcel_Columna> findOrderByColumna()
        {
            long pex_id = 0;
            Session objSession = new Session();
            pex_id = objSession.ID;
            List<ParExcel_Columna> lstParExcelColumna = new List<ParExcel_Columna>();
            ParExcel_ColumnaObject objParExcelColumnaObject = new ParExcel_ColumnaObject();
            lstParExcelColumna = objParExcelColumnaObject.listParExcelColumnaByPex_idOrderByColumna(pex_id);
            return lstParExcelColumna;
        }
    }
}

