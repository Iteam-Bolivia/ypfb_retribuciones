using System;
using System.Collections.Generic;

namespace LibFormula
{
    public class Functions : List<Function>  
    {
        string _nameSearch;

        public void AddIfNotExist(string sName, string sParams, string sFormula)
        {
            sName = sName.Trim();
            sParams = sParams.Trim();
            sFormula = sFormula.Trim();

            int i = IsFunction(sName);

            if (i >= 0)
            {
                this[i].Param = sParams;
                this[i].Formula = sFormula;
            }
            else
                this.Add(new Function(sName, sParams, sFormula));   
        
        }

        public int IsFunction(string name)
        {
            _nameSearch = name; 
            return FindIndex(IsFunction);
        }

        private bool IsFunction(Function function)
        {
            return function.IsFunction(_nameSearch);
        }
    }
}
