using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public interface ICalculoRepository
  {

    List<Calculo> listCalculo(long cal_id);
    //Calculo GetRoles(int cal_id);
    //int InsertCalculo(Calculo calculo);
    //int UpdateCalculo(Calculo calculo);
    //int DeleteCalculo(int cal_id);
    //int GetCodigoCalculo();
  }
}
