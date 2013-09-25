using System;
using System.Collections.Generic;

namespace LibFormula
{
    public class Variables : List<Var>  
    {
        string _nameSearch;

        public void AddIfNotExist(string sName, string sValue)
        {
            sName = sName.Trim();
            sValue = sValue.Trim();

            int i = IsVar(sName);

            if (i >= 0)
                this[i].Value  = sValue;
            else
                this.Add(new Var(sName, sValue));   
    
        }

        public string GetValue(string name)
        {
            _nameSearch = name;
            int index = FindIndex(IsVar);
            return (index >= 0 ? this[index].Value : "");    
        }

        public int IsVar(string name)
        {
            _nameSearch = name;
            return FindIndex(IsVar);
        }

        private bool IsVar(Var Var)
        {
            return Var.IsVar(_nameSearch);
        }
    }
}
