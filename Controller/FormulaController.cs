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
  public sealed class FormulaController
  {
    public void index()
    {
    }

    public List<Formula> load(long tcl_id)
    {
      List<Formula> lstFormula = new List<Formula>();
      FormulaObject objFormulaObject = new FormulaObject();
      lstFormula = objFormulaObject.listFormula(tcl_id);
      return lstFormula;
    }

    public List<Formula> list(long tcl_id, long for_id)
    {
      List<Formula> lstFormula = new List<Formula>();
      FormulaObject objFormulaObject = new FormulaObject();
      lstFormula = objFormulaObject.listFormula(tcl_id);
      return lstFormula;
    }


    public void create()
    {
    }

    public void view()
    {
    }

    public long save(List<Formula> lstFormula)
    {
      long inserted = 0;
      // Save data from Formula
      Formula objFormula = new Formula();
      inserted = objFormula.insert(lstFormula);

      bool updatedVariable = false;
      FormulaObject formObj = new FormulaObject();
      updatedVariable = formObj.cambiarEstadoVariableTipo(inserted, "S");    

      return inserted;
    }

    public long edit(List<Formula> lstFormula)
    {
      long updated = 0;
      // Save data from Formula
      Formula objFormula = new Formula();
      updated = objFormula.update(lstFormula);
      return updated;
    }

    public long delete(long for_id)
    {
        bool updatedVariable = false;
        FormulaObject formObj = new FormulaObject();
        updatedVariable = formObj.cambiarEstadoVariableTipo(for_id, "N");    


      long deleted = 0;
      string condition = "";
      // Update data from Formula
      Formula objFormula = new Formula();
      condition = "for_id=" + for_id;
      deleted = objFormula.delete(condition);
    
      
      return deleted;
    }

  }
}
