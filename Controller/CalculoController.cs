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
  public sealed class CalculoController
  {
      public void index()
      {
          // Open List Calculo Form
          frmCalculoLista objCalculoLista = new frmCalculoLista();
          objCalculoLista.Show();
      }

      public List<Calculo> load(long tcl_id)
      {
          Session objSession = new Session();
          List<Calculo> lstCalculo = new List<Calculo>();
          CalculoObject objCalculoObject = new CalculoObject();
          lstCalculo = objCalculoObject.listCalculo(tcl_id);
          return lstCalculo;
      }

      public List<Calculo> listbytcl(long tcl_id)
      {
        Session objSession = new Session();
        List<Calculo> lstCalculo = new List<Calculo>();
        CalculoObject objCalculoObject = new CalculoObject();
        lstCalculo = objCalculoObject.listCalculobyTcl(tcl_id);
        return lstCalculo;
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

      public long save(List<Calculo> lstCalculo)
      {
          // Save data from Calculo
          long cal_id = 0;
          Calculo objCalculo = new Calculo();
          cal_id = objCalculo.insert(lstCalculo);
          return cal_id;
      }

      public void update(List<Calculo> lstCalculo)
      {
          string condition = "";
          // Update data from Calculo
          Calculo objCalculo = new Calculo();
          if (lstCalculo.Count == 0)
          {
          }
          else
          {
              lstCalculo.ForEach(delegate(Calculo c)
              {
                  condition = "cal_id=" + c.Cal_id;
              });
          }
          objCalculo.update(lstCalculo);
      }



      public List<Calculo> find()
      {
          long cal_id = 0;
          Session objSession = new Session();
          cal_id = objSession.ID;
          List<Calculo> lstCalculo = new List<Calculo>();
          CalculoObject objCalculoObject = new CalculoObject();
          lstCalculo = objCalculoObject.listCalculo(cal_id);
          return lstCalculo;
      }

      public List<Calculo> GetListCalculosSegunCriterio(string var_tcl_codigo, long var_anio, long var_mes, string var_ctt_nombre)
      {
          CalculoObject objCalculoObjeto = new CalculoObject();
          return objCalculoObjeto.listCalculoSegunCriterio(var_tcl_codigo, var_anio, var_mes, var_ctt_nombre);

      }

      public List<Calculo> findByCtt_Id(long ctt_id)
      {
          List<Calculo> lstCalculo = new List<Calculo>();
          CalculoObject objCalculoObject = new CalculoObject();
          lstCalculo = objCalculoObject.listCalculoByCtt_id(ctt_id);
          return lstCalculo;
      }


      public List<Calculo> Validar(long ctt_id, long mes_id, long anio_id, long tcl_id)
      {
          List<Calculo> lstCalculo = new List<Calculo>();
          CalculoObject objCalculoObject = new CalculoObject();
          lstCalculo = objCalculoObject.ValidarCalculo(ctt_id, mes_id, anio_id,tcl_id);
          return lstCalculo;
      }
  }
}
