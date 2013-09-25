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
  public sealed class VariableController
  {
    public void index()
    {
    }

    public List<Variable> load(long var_id)
    {
      List<Variable> lstVariable = new List<Variable>();
      VariableObject objVariableObject = new VariableObject();
      lstVariable = objVariableObject.listVariable(var_id);
      return lstVariable;
    }

    public static List<Variable> GetListaVariable(long var_id)
    {
      VariableObject objVariableObject = new VariableObject();
      return objVariableObject.listVariable(var_id);
    }

    public List<Variable> list(long var_id)
    {
      List<Variable> lstVariable = new List<Variable>();
      VariableObject objVariableObject = new VariableObject();
      lstVariable = objVariableObject.listVariable(var_id);
      return lstVariable;
    }

    public List<Variable> listTotal(long var_id)
    {
      List<Variable> lstVariable = new List<Variable>();
      VariableObject objVariableObject = new VariableObject();
      lstVariable = objVariableObject.listVariableTotal(var_id);
      return lstVariable;
    }

    public void view()
    {
    }

    public void create()
    {
    }


    public long save(List<Variable> lstVariable)
    {
      long inserted = 0;
      Variable objVariable = new Variable();
      inserted = objVariable.insert(lstVariable);
      return inserted;
    }

    public long edit(List<Variable> lstVariable)
    {
      long updated = 0;
      Variable objVariable = new Variable();
      updated = objVariable.update(lstVariable);
      return updated;
    }

    public Variable findByVar_Nombre(string var_nombre)
    {
        Variable Variable = new Variable();
        VariableObject objVariableObject = new VariableObject();
        Variable = objVariableObject.listVariableByVar_Nombre(var_nombre);
        return Variable;
    }

    public List<Variable> findByVar_CodigoTcl(string var_codigo, long tcl_id)
    {
        List<Variable> Variable = new List<Variable>();
        VariableObject objVariableObject = new VariableObject();
        Variable = objVariableObject.listVariablePorCodigoTipoCálculo(var_codigo, tcl_id);
        return Variable;
    }

    public List<Variable> findByVar_CodigoTclUnico(string var_codigo, long tcl_id)
    {
      List<Variable> Variable = new List<Variable>();
      VariableObject objVariableObject = new VariableObject();
      Variable = objVariableObject.listVariablePorCodigoTipoCálculoUnico(var_codigo, tcl_id);
      return Variable;
    }

    public List<Variable> GetListVariablesSegunCriterio(string var_codigo, string var_nombre)
    {
      VariableObject objVariableObject = new VariableObject();
      return objVariableObject.listVariableSegunCriterio(var_codigo, var_nombre);
    }

    public List<Variable> findByTcl_id(long tcl_id)
    {
        List<Variable> Variable = new List<Variable>();
        VariableObject objVariableObject = new VariableObject();
        Variable = objVariableObject.findByTcl_id(tcl_id);
        return Variable;
    }
  }
}
