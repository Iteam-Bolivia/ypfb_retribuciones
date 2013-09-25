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
  public sealed class Calculo_VariableController
  {
    public void index()
    {
      // Open List Calculo_Variable Form
      //frmCalculoVariableLista objCalculoVariableLista = new frmCalculoVariableLista();
      //objCalculoVariableLista.Show();
    }

    public List<Calculo_Variable> load(long ctt_id, long tcl_id, long ani_id, long mes_id)
    {
      List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
      Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
      lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotal(ctt_id, tcl_id, ani_id, mes_id);
      return lstCalculoVariable;
    }

    public List<Calculo_Variable> loadDetalle(long ctt_id, long tcl_id, long ani_id, long mes_id)
    {
      List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
      Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
      lstCalculoVariable = objCalculoVariableObject.listCalculoVariable(ctt_id, tcl_id, ani_id, mes_id);
      return lstCalculoVariable;
    }


    public List<Calculo_Variable> listCalculoVariableTotales(long anio_idF, long tcl_id, long ani_id, long mes_id,long mes_idF, long var_id)
    {
        List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
        Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
        lstCalculoVariable = objCalculoVariableObject.listCalculoVariableTotales(anio_idF, tcl_id, ani_id, mes_id,mes_idF,var_id);
        return lstCalculoVariable;
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

    public long save(List<Calculo_Variable> lstCalculoVariable)
    {
        long id = 0;
      // Save data from Calculo_Variable
      Calculo_Variable objCalculoVariable = new Calculo_Variable();
      id = objCalculoVariable.insert(lstCalculoVariable);
      return id;
    }

    public void update(List<Calculo_Variable> lstCalculoVariable)
    {
      // Update data from Calculo_Variable
      Calculo_Variable objCalculoVariable = new Calculo_Variable();
      if (lstCalculoVariable.Count == 0)
      {
      }
      else
      {
        lstCalculoVariable.ForEach(delegate(Calculo_Variable cmv)
        {
          //condition = "idCalculoVariable=" + cmv.Cmv_id;
        });
      }
      objCalculoVariable.update(lstCalculoVariable);
    }

    public List<Calculo_Variable> find()
    {
      //long cmv_id = 0;
      //Session objSession = new Session();
      //cmv_id = objSession.ID;
      List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
      //CalculoVariableObject objCalculoVariableObject = new CalculoVariableObject();
      //lstCalculoVariable = objCalculoVariableObject.listCampoMercadoValor(cmv_id);
      return lstCalculoVariable;
    }


    public bool ValidaCalculo(long anio_id, long mes_id, long pex_id, long ctt_id, long tcl_id)
    {
        Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
        return objCalculoVariableObject.validarCalculo(anio_id, mes_id, pex_id, ctt_id, tcl_id);
    }

    public void Eliminar(long anio_id, long mes_id, long pex_id, long tcl_id, long ctt_id)
    {
        Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
        objCalculoVariableObject.Eliminar(anio_id, mes_id, pex_id, tcl_id, ctt_id);
    }


    public void EliminacionMasiva(long pex_id)
    {
        Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
        objCalculoVariableObject.EliminacionMasiva(pex_id);
    }

    public void updateCav_Valor(long id, decimal volumenSeca_60)
    {
        Calculo_VariableObject objCalculoVariableObject = new Calculo_VariableObject();
        objCalculoVariableObject.updateCav_Valor(id, volumenSeca_60);
    }
  }
}
