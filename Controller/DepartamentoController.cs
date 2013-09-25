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
  public sealed class DepartamentoController
  {
    public void index()
    {
      // Open List Departamento Form
      frmDepartamentoLista objDepartamentoLista = new frmDepartamentoLista();
      objDepartamentoLista.Show();
    }

    public List<Departamento> load()
    {
      Session objSession = new Session();
      List<Departamento> lstDepartamento = new List<Departamento>();
      DepartamentoObject objDepartamentoObject = new DepartamentoObject();
      lstDepartamento = objDepartamentoObject.listDepartamento(0);
      return lstDepartamento;
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

    public void save(List<Departamento> lstDepartamento)
    {
      // Save data from Departamento
      Departamento objDepartamento = new Departamento();
      objDepartamento.insert(lstDepartamento);
    }

    public void update(List<Departamento> lstDepartamento)
    {
      string condition = "";
      // Update data from Departamento
      Departamento objDepartamento = new Departamento();
      if (lstDepartamento.Count == 0)
      {
      }
      else
      {
        lstDepartamento.ForEach(delegate(Departamento u)
        {
          condition = "idDepartamento=" + u.Dep_id;
        });
      }
      objDepartamento.update(lstDepartamento);
    }



    public List<Departamento> find()
    {
      long dep_id = 0;
      Session objSession = new Session();
      dep_id = objSession.ID;
      List<Departamento> lstDepartamento = new List<Departamento>();
      DepartamentoObject objDepartamentoObject = new DepartamentoObject();
      lstDepartamento = objDepartamentoObject.listDepartamento(dep_id);
      return lstDepartamento;
    }
  }
}
