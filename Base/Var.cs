using System;
using System.Collections.Generic;

namespace LibFormula
{
    public class Var
    {
        string _name;
        string _value;

        public Var()
        {
            _name = "";
            _value = "";
        }


        public Var(string psName, string psValue)
        { 
            _name = psName;
            _value = psValue; 
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Value
        {
            set { _value = value; }
            get { return _value; }
        }

        public override string ToString()
        {
            return Name + " = " + Value ;
        }

        public bool IsVar(string name)
        {
            return (this.Name == name);
        }

    }
}
