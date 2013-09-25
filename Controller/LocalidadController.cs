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
  public sealed class LocalidadController
  {
    public void index()
    {
      // Open List Localidad Form
      frmLocalidadLista objLocalidadLista = new frmLocalidadLista();
      objLocalidadLista.Show();
    }

    public List<Localidad> load()
    {
      Session objSession = new Session();
      List<Localidad> lstLocalidad = new List<Localidad>();
      LocalidadObject objLocalidadObject = new LocalidadObject();
      lstLocalidad = objLocalidadObject.listLocalidad(0);
      return lstLocalidad;
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

    public void save(List<Localidad> lstLocalidad)
    {
      // Save data from Localidad
      Localidad objLocalidad = new Localidad();
      objLocalidad.insert(lstLocalidad);
    }

    public void update(List<Localidad> lstLocalidad)
    {
      string condition = "";
      // Update data from Localidad
      Localidad objLocalidad = new Localidad();
      if (lstLocalidad.Count == 0)
      {
      }
      else
      {
        lstLocalidad.ForEach(delegate(Localidad u)
        {
          condition = "idLocalidad=" + u.Loc_id;
        });
      }
      objLocalidad.update(lstLocalidad);
    }



    public List<Localidad> find()
    {
      long loc_id = 0;
      Session objSession = new Session();
      loc_id = objSession.ID;
      List<Localidad> lstLocalidad = new List<Localidad>();
      LocalidadObject objLocalidadObject = new LocalidadObject();
      lstLocalidad = objLocalidadObject.listLocalidad(loc_id);
      return lstLocalidad;
    }
  }
}
