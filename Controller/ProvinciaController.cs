/*
 * @author acastellon
 * User Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */
using System.Collections.Generic;
using Model;
using View;
using ypfbApplication.View;

namespace Controller
{
  public sealed class ProvinciaController
  {
    public void index()
    {
      // Open List Provincia Form
      frmProvinciaLista objProvinciaLista = new frmProvinciaLista();
      objProvinciaLista.Show();
    }

    public List<Provincia> load()
    {
      Session objSession = new Session();
      List<Provincia> lstProvincia = new List<Provincia>();
      ProvinciaObject objProvinciaObject = new ProvinciaObject();
      lstProvincia = objProvinciaObject.listProvincia(0);
      return lstProvincia;
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

    public void save(List<Provincia> lstProvincia)
    {
      // Save data from Provincia
      Provincia objProvincia = new Provincia();
      objProvincia.insert(lstProvincia);
    }

    public void update(List<Provincia> lstProvincia)
    {
      string condition = "";
      // Update data from Provincia
      Provincia objProvincia = new Provincia();
      if (lstProvincia.Count == 0)
      {
      }
      else
      {
        lstProvincia.ForEach(delegate(Provincia u)
        {
          condition = "idProvincia=" + u.Pro_id;
        });
      }
      objProvincia.update(lstProvincia);
    }



    public List<Provincia> find()
    {
      long pro_id = 0;
      Session objSession = new Session();
      pro_id = objSession.ID;
      List<Provincia> lstProvincia = new List<Provincia>();
      ProvinciaObject objProvinciaObject = new ProvinciaObject();
      lstProvincia = objProvinciaObject.listProvincia(pro_id);
      return lstProvincia;
    }
  }
}
