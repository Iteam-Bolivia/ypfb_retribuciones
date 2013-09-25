using System;

namespace LibFormula
{
    public class Function
    {
        string _name;
        string _param;
        string _formula;

        public Function(string psName, string psParam, string psFormula)
        {
            _name = psName;
            _param = psParam;
            _formula = psFormula;
        }

        public string Name
        {
            set {_name = value;}
            get { return _name; }
        }

        public string Param
        {
            set { _param = value; }
            get { return _param; }
        }


        public string Formula
        {
            set { _formula = value; }
            get { return _formula; }
        }

        public bool IsFunction(string name)
        {
            return (this.Name == name);
        }


        public override string ToString()
        {
            return Name + " = " + Formula + " | " + Param;
        }

       


    }
}
