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
  public sealed class Campo_Mercado_Valor_ValorController
  {
    public void index()
    {
      // Open List Campo_Mercado_Valor Form
      //frmCampo_Mercado_ValorLista objCampo_Mercado_ValorLista = new frmCampo_Mercado_ValorLista();
      //objCampo_Mercado_ValorLista.Show();
    }

    public List<Campo_Mercado_Valor> load(long ctt_id)
    {
      List<Campo_Mercado_Valor> lstCampo_Mercado_Valor = new List<Campo_Mercado_Valor>();
      Campo_Mercado_ValorObject objCampo_Mercado_ValorObject = new Campo_Mercado_ValorObject();
      lstCampo_Mercado_Valor = objCampo_Mercado_ValorObject.listCampoMercadoValor(ctt_id);
      // Calculate








      return lstCampo_Mercado_Valor;
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

    public void save(List<Campo_Mercado_Valor> lstCampo_Mercado_Valor)
    {
      // Save data from Campo_Mercado_Valor
      Campo_Mercado_Valor objCampo_Mercado_Valor = new Campo_Mercado_Valor();
      objCampo_Mercado_Valor.insert(lstCampo_Mercado_Valor);
    }

    public void update(List<Campo_Mercado_Valor> lstCampo_Mercado_Valor)
    {
      string condition = "";
      // Update data from Campo_Mercado_Valor
      Campo_Mercado_Valor objCampo_Mercado_Valor = new Campo_Mercado_Valor();
      if (lstCampo_Mercado_Valor.Count == 0)
      {
      }
      else
      {
        lstCampo_Mercado_Valor.ForEach(delegate(Campo_Mercado_Valor cmv)
        {
          condition = "idCampo_Mercado_Valor=" + cmv.Cmv_id;
        });
      }
      objCampo_Mercado_Valor.update(lstCampo_Mercado_Valor);
    }

    public List<Campo_Mercado_Valor> find()
    {
      long cmv_id = 0;
      Session objSession = new Session();
      cmv_id = objSession.ID;
      List<Campo_Mercado_Valor> lstCampo_Mercado_Valor = new List<Campo_Mercado_Valor>();
      Campo_Mercado_ValorObject objCampo_Mercado_ValorObject = new Campo_Mercado_ValorObject();
      lstCampo_Mercado_Valor = objCampo_Mercado_ValorObject.listCampoMercadoValor(cmv_id);
      return lstCampo_Mercado_Valor;
    }



  }
}
