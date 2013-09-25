/*
 * @author acastellon
 * CalculoObject Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Model
{
  public class CalculoObject : Calculo
  {
      string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };


      /// <summary>
      /// listCalculo Method
      /// </summary>
      public List<Calculo> listCalculo(long cal_id)
      {
          long usu_id = 0;
          long i = 1;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (cal_id != 0 ? ("AND cal_id =" + cal_id + "") : "");
          List<Calculo> lstCalculo = new List<Calculo>();
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_calculo.tcl_id, " +
                    "tab_calculo.mon_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_cammar " +
                    //"tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    "AND tab_contrato.usu_id = " + usu_id + " " +
                    where +
                    " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_calculo.tcl_id, tab_contrato.ctt_nombre ";

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  Calculo calculo = new Calculo();
                  calculo.Cal_nro = System.Convert.ToInt64(i);
                  calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  calculo.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
                  calculo.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
                  calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                  calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  calculo.Cal_mes = MESES[calculo.Mes_id - 1];
                  calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
                  calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
                  calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                  calculo.Cal_estado = System.Convert.ToInt32(rs.Fields["cal_estado"].Value);
                  // Nuevos campos
                  calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  calculo.Cal_costrecuacu = Convert.ToDecimal(rs.Fields["cal_costrecuacu"].Value);
                  calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);

                  lstCalculo.Add(calculo);
                  rs.MoveNext();
                  i++;
              }
              Connection_Off(1);
              return lstCalculo;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return lstCalculo;
          }
          finally
          {
              Connection_Off(1);
          }
      }


      /// <summary>
      /// listCalculo Method
      /// </summary>
      public List<Calculo> listCalculobyTcl(long tcl_id)
      {
        long usu_id = 0;
        long i = 1;
        Session objSession = new Session();
        usu_id = objSession.USU_ID;
        String where = (tcl_id != 0 ? ("AND tab_calculo.tcl_id =" + tcl_id + "") : "");
        List<Calculo> lstCalculo = new List<Calculo>();
        try
        {
          Connection_On();
          SQL = "SELECT " +
                "tab_calculo.cal_id, " +
                "tab_contrato.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo.cal_fecha, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_calculo.tcl_id, " +
                "tab_calculo.mon_id, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_calculo.cal_valor, " +
                "tab_calculo.cal_valorajustado, " +
                "tab_calculo.cal_costrecuacu, " +
                "tab_contrato.ctt_estado, " +
                "tab_calculo.cal_estado, " +
                "tab_calculo.cal_depacuma, " +
                "tab_calculo.cal_acugantit, " +
                "tab_calculo.cal_invacuma, " +
                "tab_calculo.cal_acuimptit, " +
                "tab_calculo.cal_cammar " +
               // "tab_calculo.cal_proces " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                "WHERE tab_calculo.cal_estado = 1 " +
                "AND tab_contrato.usu_id = " + usu_id + " " +
                where +
                " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo calculo = new Calculo();
            calculo.Cal_nro = System.Convert.ToInt64(i);
            calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
            calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            calculo.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
            calculo.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
            calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
            calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
            calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            calculo.Cal_mes = MESES[calculo.Mes_id - 1];
            calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
            calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
            calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
            calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
            calculo.Cal_estado = System.Convert.ToInt32(rs.Fields["cal_estado"].Value);
            // Nuevos campos
            calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
            calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
            calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
            calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
            calculo.Cal_costrecuacu = Convert.ToDecimal(rs.Fields["cal_costrecuacu"].Value);
            calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
            //calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);

            lstCalculo.Add(calculo);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);
          return lstCalculo;
        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return lstCalculo;
        }
        finally
        {
          Connection_Off(1);
        }
      }
    
    
    
    public List<Calculo> listCalculoSegunCriterio(string tcl_codigo, long anio, long mes, string ctt_nombre)
      {
          long usu_id = 0;
          long i = 1;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          //String where = (cal_id != 0 ? ("AND cal_id =" + cal_id + "") : "");
          String where = (anio != 0 ? (" AND tab_calculo.ani_id = " + anio + "") : "");
          where += (mes != 0 ? (" AND tab_calculo.mes_id = " + mes + "") : "");
          List<Calculo> lstCalculo = new List<Calculo>();
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_cammar " +
                    //"tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    "AND tab_contrato.usu_id = " + usu_id + " " +
                    "AND tab_tipo_calculo.tcl_codigo LIKE '%" + tcl_codigo + "%'" +
                    "AND tab_contrato.ctt_nombre LIKE '%" + ctt_nombre + "%'" +
                    where +
                    " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  Calculo calculo = new Calculo();
                  calculo.Cal_nro = System.Convert.ToInt64(i);
                  calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                  calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  calculo.Cal_mes = MESES[calculo.Mes_id - 1];
                  calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
                  calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
                  calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                  // Nuevos campos
                  calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  calculo.Cal_costrecuacu = Convert.ToDecimal(rs.Fields["cal_costrecuacu"].Value);
                  calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
                  //calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);
                  lstCalculo.Add(calculo);
                  rs.MoveNext();
                  i++;
              }
              Connection_Off(1);
              return lstCalculo;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return lstCalculo;
          }
          finally
          {
              Connection_Off(1);
          }
      }




      public List<Calculo> listCalculoByCtt_id(long ctt_id)
      {
          long usu_id = 0;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (ctt_id != 0 ? ("AND tab_calculo.ctt_id ='" + ctt_id + "'") : "");
          List<Calculo> lstCalculo = new List<Calculo>();
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_cammar " +
                    //"tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    where;

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  Calculo Calculo = new Calculo();
                  Calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  Calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  Calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                  Calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  Calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  Calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  Calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  Calculo.Cal_mes = MESES[Calculo.Mes_id - 1];
                  Calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
                  Calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
                  Calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  Calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                  // Nuevos campos
                  Calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  Calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  Calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  Calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  Calculo.Cal_costrecuacu = Convert.ToDecimal(rs.Fields["cal_costrecuacu"].Value);
                  Calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
                 // Calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);
                  lstCalculo.Add(Calculo);
                  rs.MoveNext();
              }
              Connection_Off(1);
              return lstCalculo;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return lstCalculo;
          }
          finally
          {
              Connection_Off(1);
          }
      }

      public List<Calculo> ValidarCalculo(long ctt_id, long mes_id, long anio_id, long tcl_id)
      {
          long usu_id = 0;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (ctt_id != 0 ? ("AND tab_calculo.ctt_id ='" + ctt_id + "'") : "");
          where += (anio_id != 0 ? ("AND tab_calculo.ani_id ='" + anio_id + "'") : "");
          where += (mes_id != 0 ? ("AND tab_calculo.mes_id ='" + mes_id + "'") : "");
          where += (tcl_id != 0 ? ("AND tab_calculo.tcl_id ='" + tcl_id + "'") : "");
          List<Calculo> lstCalculo = new List<Calculo>();
          try
          {
              Connection_On();
              SQL = "SELECT " +
                      "tab_calculo.cal_id, " +
                      "tab_calculo.ctt_id, " +
                      "tab_calculo.cal_fecha, " +
                      "tab_calculo.ani_id, " +
                      "tab_calculo.mes_id, " +
                      "tab_calculo.mon_id, " +
                      "tab_calculo.tcl_id, " +
                      "tab_calculo.cal_valor, " +
                      "tab_calculo.cal_valorajustado, " +
                      "tab_calculo.cal_estado, " +
                      "tab_calculo.cal_depacuma, " +
                      "tab_calculo.cal_estado, " +
                      "tab_calculo.cal_depacuma, " +
                      "tab_calculo.cal_acugantit, " +
                      "tab_calculo.cal_costrecuacu, " +
                      "tab_calculo.cal_invacuma, " +
                      "tab_calculo.cal_acuimptit, " +
                      "tab_calculo.cal_cammar " +
                      //"tab_calculo.cal_proces " +
                      "FROM " +
                      "tab_calculo " +
                      "WHERE tab_calculo.cal_estado = 1 " +
                      where;

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  Calculo Calculo = new Calculo();
                  Calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  Calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  Calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  Calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  Calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  Calculo.Cal_mes = MESES[Calculo.Mes_id - 1];
                  Calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["mon_id"].Value);
                  Calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["tcl_id"].Value);
                  Calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  Calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["cal_estado"].Value);
                  // Nuevos campos
                  Calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  Calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  Calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  Calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  Calculo.Cal_costrecuacu = Convert.ToDecimal(rs.Fields["cal_costrecuacu"].Value);
                  Calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
                  //Calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);
                  lstCalculo.Add(Calculo);
                  rs.MoveNext();
              }
              Connection_Off(1);
              return lstCalculo;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return lstCalculo;
          }
          finally
          {
              Connection_Off(1);
          }
      }








      /// <summary>
      /// listCalculo Method
      /// </summary>
      public long findCalculo(long ctt_id, long tcl_id, long ani_id, long mes_id)
      {
        long cal_id = 0;
        try
        {
          Connection_On();
          SQL = "SELECT " +
                "tab_calculo.cal_id, " +
                "tab_contrato.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo.cal_fecha, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_calculo.tcl_id, " +
                "tab_calculo.mon_id, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_calculo.cal_valor, " +
                "tab_calculo.cal_valorajustado, " +
                "tab_contrato.ctt_estado, " +
                "tab_calculo.cal_estado, " +
                "tab_calculo.cal_depacuma, " +
                "tab_calculo.cal_acugantit, " +
                "tab_calculo.cal_invacuma, " +
                "tab_calculo.cal_costrecuacu, " +
                "tab_calculo.cal_acuimptit, " +
                "tab_calculo.cal_cammar " +
                //"tab_calculo.cal_proces " +

                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                "WHERE tab_calculo.cal_estado = 1 " +
                " AND tab_calculo.ctt_id = " + ctt_id + " AND tab_calculo.tcl_id = " + tcl_id + " AND tab_calculo.ani_id = " + ani_id + " AND tab_calculo.mes_id = " + mes_id + " " +
                " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          if (!rs.EOF)
          {
              cal_id = System.Convert.ToInt64(rs.Fields["cal_proces"].Value);
          }
          Connection_Off(1);
          return cal_id;
        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return cal_id;
        }
        finally
        {
          Connection_Off(1);
        }
      }




      public bool ValidarCalculoAnterior(long ctt_id, long mes_id, long ani_id, long tcl_id)
      {
          bool flag = false;
          long cal_valor = 0;
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_calculo.tcl_id, " +
                    "tab_calculo.mon_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_cammar " +
                    //"tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    " AND tab_calculo.ctt_id = " + ctt_id + " AND tab_calculo.tcl_id = " + tcl_id + " AND tab_calculo.ani_id = " + ani_id + " AND tab_calculo.mes_id = " + (mes_id) + " " +
                    " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              if (!rs.EOF)
              {
                  if (Convert.IsDBNull(rs.Fields["cal_valor"].Value))
                      flag = true;
                  else
                  {
                      cal_valor = System.Convert.ToInt64(rs.Fields["cav_valor"].Value);
                      if (cal_valor <= 0)
                          flag = false;
                      else
                          flag = true;
                  }

              }
              else
                  flag = true;

              Connection_Off(1);
              return flag;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return flag;
          }
          finally
          {
              Connection_Off(1);
          } 
      }

      public bool listCalculoByMesAndAnio(long ctt_id, long ani_id, long mes_id,long tcl_id)
      {
          long usu_id = 0;
          long i = 1;
          bool flag = false;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (tcl_id != 0 ? ("AND tab_calculo.tcl_id =" + tcl_id + " ") : " ");
          where += (ctt_id != 0 ? ("AND tab_calculo.ctt_id =" + ctt_id + " ") : " ");
          where += (ani_id != 0 ? ("AND tab_calculo.ani_id =" + ani_id + " ") : " ");
          where += (mes_id != 0 ? ("AND tab_calculo.mes_id =" + mes_id + " ") : " ");
          List<Calculo> lstCalculo = new List<Calculo>();

          
          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_calculo.tcl_id, " +
                    "tab_calculo.mon_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_cammar " +
                    // "tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    "AND tab_contrato.usu_id = " + usu_id + " " +
                    where +
                    " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  Calculo calculo = new Calculo();
                  calculo.Cal_nro = System.Convert.ToInt64(i);
                  calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  calculo.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
                  calculo.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
                  calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                  calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  calculo.Cal_mes = MESES[calculo.Mes_id - 1];
                  calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
                  calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
                  calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                  calculo.Cal_estado = System.Convert.ToInt32(rs.Fields["cal_estado"].Value);
                  // Nuevos campos
                  calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
                 // calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);
                  lstCalculo.Add(calculo);
                  rs.MoveNext();
              }
              if (lstCalculo.Count> 0)
              {
                  //if (lstCalculo[0].Cal_proces == -1)
                  //    flag = false;
                  //else if (lstCalculo[0].Cal_proces == 0)
                  //    flag = true;
                  //else if(lstCalculo[0].Cal_proces == 1)
                      flag = false;
              }
              else
              {
                  flag = true;
              }
              Connection_Off(1);
              return flag;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return false;
          }
          finally
          {
              Connection_Off(1);
          }
      }


      public Calculo listCalculoGDT_1ByMesAndAnio(long ctt_id, long ani_id, long mes_id, long tcl_id)
      {
          long usu_id = 0;
          long i = 1;
          //bool flag = false;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (tcl_id != 0 ? ("AND tab_calculo.tcl_id =" + tcl_id + " ") : " ");
          where += (ctt_id != 0 ? ("AND tab_calculo.ctt_id =" + ctt_id + " ") : " ");
          where += (ani_id != 0 ? ("AND tab_calculo.ani_id =" + ani_id + " ") : " ");
          where += (mes_id != 0 ? ("AND tab_calculo.mes_id =" + mes_id + " ") : " ");
          Calculo calculo = new Calculo();


          try
          {
              Connection_On();
              SQL = "SELECT " +
                    "tab_calculo.cal_id, " +
                    "tab_contrato.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo.cal_fecha, " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_calculo.tcl_id, " +
                    "tab_calculo.mon_id, " +
                    "tab_tipo_calculo.tcl_codigo, " +
                    "tab_calculo.cal_valor, " +
                    "tab_calculo.cal_valorajustado, " +
                    "tab_contrato.ctt_estado, " +
                    "tab_calculo.cal_estado, " +
                    "tab_calculo.cal_depacuma, " +
                    "tab_calculo.cal_acugantit, " +
                    "tab_calculo.cal_invacuma, " +
                    "tab_calculo.cal_acuimptit, " +
                    "tab_calculo.cal_costrecuacu, " +
                    "tab_calculo.cal_cammar " +
                    // "tab_calculo.cal_proces " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                    "WHERE tab_calculo.cal_estado = 1 " +
                    "AND tab_contrato.usu_id = " + usu_id + " " +
                    where +
                    " ORDER BY tab_calculo.ani_id, tab_calculo.mes_id, tab_contrato.ctt_nombre ";

              // Execute the query specifying static sursor, batch optimistic locking
              rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
              while (!rs.EOF)
              {
                  
                  calculo.Cal_nro = System.Convert.ToInt64(i);
                  calculo.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                  calculo.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                  calculo.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
                  calculo.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
                  calculo.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                  calculo.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                  calculo.Cal_fecha = System.Convert.ToDateTime(rs.Fields["cal_fecha"].Value);
                  calculo.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                  calculo.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                  calculo.Cal_mes = MESES[calculo.Mes_id - 1];
                  calculo.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
                  calculo.Cal_valor = System.Convert.ToDecimal(rs.Fields["cal_valor"].Value);
                  calculo.Cal_valorajustado = System.Convert.ToDecimal(rs.Fields["cal_valorajustado"].Value);
                  calculo.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                  calculo.Cal_estado = System.Convert.ToInt32(rs.Fields["cal_estado"].Value);
                  // Nuevos campos
                  calculo.Cal_depacuma = System.Convert.ToDecimal(rs.Fields["cal_depacuma"].Value);
                  calculo.Cal_acugantit = System.Convert.ToDecimal(rs.Fields["cal_acugantit"].Value);
                  calculo.Cal_invacuma = System.Convert.ToDecimal(rs.Fields["cal_invacuma"].Value);
                  calculo.Cal_acuimptit = System.Convert.ToDecimal(rs.Fields["cal_acuimptit"].Value);
                  calculo.Cal_cammar = Convert.ToInt32(rs.Fields["cal_cammar"].Value);
                  //calculo.Cal_proces = Convert.ToInt32(rs.Fields["cal_proces"].Value);
                  rs.MoveNext();
              }
              
              Connection_Off(1);
              return calculo;
          }
          catch (COMException err)
          {
              Console.WriteLine("Error: " + err.Message);
              Connection_Off(1);
              return calculo;
          }
          finally
          {
              Connection_Off(1);
          }
      }
  }
}