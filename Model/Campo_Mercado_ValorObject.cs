using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class Campo_Mercado_ValorObject : Campo_Mercado_Valor
    {

        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
      public List<Campo_Mercado_Valor> listCampoMercadoValor(long ctt_id)
      {
        //  String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
        List<Campo_Mercado_Valor> lstCmv = new List<Campo_Mercado_Valor>();
        //  long cam_id = 0;
        //  try
        //  {
        //    cnn = Connection_On();
        //    SQL = "SELECT " +
        //            "tab_contrato.ctt_id, " +
        //            "tab_contrato_campo.cam_id, " +
        //            "tab_contrato.ctt_codigo, " +
        //            "tab_campo.cam_codigo " +
        //            "FROM " +
        //            "tab_contrato " +
        //            "Inner Join tab_contrato_campo ON tab_contrato.ctt_id = tab_contrato_campo.ctt_id " +
        //            "Inner Join tab_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
        //          "WHERE tab_contrato.ctt_estado = 1 " +
        //          where;

        //    // Execute the query specifying static sursor, batch optimistic locking
        //    rs.Open(SQL, DBConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //    while (!rs.EOF)
        //    {
        //      ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
        //      cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);

        //      // Empresas
        //      SQL = "SELECT " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.umd_id), 0) as unidad, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_volumen), 0) AS volumen, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_monto), 0) AS monto, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_transporte), 0) AS transporte, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_volene), 0) AS volene " +
        //              "FROM " +
        //              "tab_contrato " +
        //              "INNER JOIN tab_contrato_campo ON tab_contrato.ctt_id = tab_contrato_campo.ctt_id " +
        //              "INNER JOIN tab_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
        //              "INNER JOIN tab_campo_producto_mercado ON tab_campo.cam_id = tab_campo_producto_mercado.cam_id " +
        //              "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id " +
        //              "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_campo_producto_mercado.mer_id " +
        //              "INNER JOIN tab_campo_mercado_valor ON tab_mercado.mer_id = tab_campo_mercado_valor.mer_id " +
        //              "INNER JOIN tab_titular_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
        //              "INNER JOIN tab_titular ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
        //            "WHERE " +                   
        //            "tab_titular_contrato.ttc_tipo = 'O' " +
        //            "AND tab_contrato.ctt_id = " + ctt_id + " " +
        //            "AND tab_campo.cam_estado = 1 AND tab_campo.cam_id = " + cam_id + " " +
        //            "AND tab_campo_mercado_valor.cmv_tipo = 'T'"; 
        //      // Execute the query specifying static sursor, batch optimistic locking
        //      rs2 = new ADODB.Recordset();
        //      rs2.Open(SQL, DBConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //      while (!rs2.EOF)
        //      {
        //        if (rs2.Fields["unidad"].Value != 0)
        //        {
        //          Campo_Mercado_Valor cmv = new Campo_Mercado_Valor();
        //          cmv.Cmv_tipo = System.Convert.ToString("T");
        //          cmv.Umd_id = System.Convert.ToInt64(rs2.Fields["unidad"].Value);
        //          cmv.Cmv_volumen = System.Convert.ToDecimal(rs2.Fields["volumen"].Value);
        //          cmv.Cmv_monto = System.Convert.ToDecimal(rs2.Fields["monto"].Value);
        //          cmv.Cmv_transporte = System.Convert.ToDecimal(rs2.Fields["transporte"].Value);
        //          cmv.Cmv_volene = System.Convert.ToDecimal(rs2.Fields["volene"].Value);
        //          // Values 
        //          cmv.Ctt_id = System.Convert.ToInt64(ctt_id);
        //          cmv.Cam_id = System.Convert.ToInt64(cam_id);
        //          lstCmv.Add(cmv);
        //        }
        //        rs2.MoveNext();
        //      }

        //      // Yacimientos
        //      SQL = "SELECT " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.umd_id), 0) as unidad, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_volumen), 0) AS volumen, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_monto), 0) AS monto, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_transporte), 0) AS transporte, " +
        //              "COALESCE(Sum(tab_campo_mercado_valor.cmv_volene), 0) AS volene " +
        //              "FROM " +
        //              "tab_contrato " +
        //              "INNER JOIN tab_contrato_campo ON tab_contrato.ctt_id = tab_contrato_campo.ctt_id " +
        //              "INNER JOIN tab_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
        //              "INNER JOIN tab_campo_producto_mercado ON tab_campo.cam_id = tab_campo_producto_mercado.cam_id " +
        //              "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id " +
        //              "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_campo_producto_mercado.mer_id " +
        //              "INNER JOIN tab_campo_mercado_valor ON tab_mercado.mer_id = tab_campo_mercado_valor.mer_id " +
        //              "INNER JOIN tab_titular_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
        //              "INNER JOIN tab_titular ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
        //            "WHERE " +
        //            "tab_titular_contrato.ttc_tipo = 'O' " +
        //            "AND tab_contrato.ctt_id = " + ctt_id + " " +
        //            "AND tab_campo.cam_estado = 1 AND tab_campo.cam_id = " + cam_id + " " +
        //            "AND tab_campo_mercado_valor.cmv_tipo = 'Y'";
        //      // Execute the query specifying static sursor, batch optimistic locking
        //      rs2 = new ADODB.Recordset();
        //      rs2.Open(SQL, DBConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //      while (!rs2.EOF)
        //      {
        //        if (rs2.Fields["unidad"].Value != 0)
        //        {
        //          Campo_Mercado_Valor cmv = new Campo_Mercado_Valor();
        //          cmv.Cmv_tipo = System.Convert.ToString("Y");
        //          cmv.Umd_id = System.Convert.ToInt64(rs2.Fields["unidad"].Value);
        //          cmv.Cmv_volumen = System.Convert.ToDecimal(rs2.Fields["volumen"].Value);
        //          cmv.Cmv_monto = System.Convert.ToDecimal(rs2.Fields["monto"].Value);
        //          cmv.Cmv_transporte = System.Convert.ToDecimal(rs2.Fields["transporte"].Value);
        //          cmv.Cmv_volene = System.Convert.ToDecimal(rs2.Fields["volene"].Value);
        //          // Values 
        //          cmv.Ctt_id = System.Convert.ToInt64(ctt_id);
        //          cmv.Cam_id = System.Convert.ToInt64(cam_id);
        //          lstCmv.Add(cmv);
        //        }
        //        rs2.MoveNext();
        //      }



        //      rs.MoveNext();
        //    }
        //    Connection_Off(1);
        //    return lstCmv;
        //  }
        //  catch (COMException err)
        //  {
        //    Console.WriteLine("Error: " + err.Message);
        //    Connection_Off(1);
        //    return lstCmv;
        //  }
        //  finally
        //  {
        //    Connection_Off(1);
        //  }
        //}


        return lstCmv;

      }


    }
}
