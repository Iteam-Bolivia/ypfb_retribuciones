
using System;

namespace LibFormula
{
    public interface IFunctionProcessor
    {
        Functions Functions{ get;}
        int IsFunction(string sNameFun);
        string Process(string sNameFun, string[] parameters);
        string GetParametros(int index);
        string GetFormula(int index);
    }
}
