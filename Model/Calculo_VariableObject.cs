using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class Calculo_VariableObject : Calculo_Variable
    {
      string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

      /// <summary>
      /// listCampoMercadoValor Method
      /// </summary>
      public List<Calculo_Variable> listCalculoVariableTotal(long ctt_id, long tcl_id, long ani_id, long mes_id)
      {
        long usu_id = 0;
        long i = 1;
        Session objSession = new Session();
        usu_id = objSession.USU_ID;
        //String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
        List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
        try
        {
          Connection_On();

          // Variables Titular
          SQL = "SELECT " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                "AND (tab_variable.tcl_id = " + tcl_id + " OR tab_variable.tcl_id = 3 ) " +
                "AND tab_calculo.ani_id = " + ani_id + " " +
                "AND tab_calculo.mes_id = " + mes_id + " " +
                "AND tab_variable.var_tipo = 'N' " +
                "AND tab_calculo_variable.pex_id <> 0 " +
                "GROUP BY " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login, " +
                "tab_variable.var_orden " +
                "ORDER BY " +
                "tab_variable.var_orden, "+
                "tab_variable.var_id ASC ";



          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo_Variable cv = new Calculo_Variable();
            cv.Cav_nro = System.Convert.ToInt64(i);
            cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
            cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

            cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            cv.Cav_mes = MESES[cv.Mes_id - 1];

            cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
            cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
            cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
            cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
            cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
            lstCv.Add(cv);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);
          return lstCv;
        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return lstCv;
        }
        finally
        {
          Connection_Off(1);
        }
      }



      /// <summary>
      /// listCalculoVariableTotalPorCampo Method
      /// </summary>
      public List<Calculo_Variable> listCalculoVariableTotalPorCampo(long ctt_id, long tcl_id, long ani_id, long mes_id, long cam_id)
      {
        long usu_id = 0;
        long i = 1;
        Session objSession = new Session();
        usu_id = objSession.USU_ID;
        String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");

        //
        List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
        try
        {

          // Cargar Variables Recálculo
          Connection_On();
          SQL = "SELECT " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                "AND (tab_variable.tcl_id = 3 or tab_variable.tcl_id = "+ tcl_id +" ) " +
                "AND tab_calculo.ani_id = " + ani_id + " " +
                "AND tab_calculo.mes_id = " + mes_id + " " +
                "AND tab_calculo_variable.cam_id = " + cam_id + " " +
                "AND tab_variable.var_tipo = 'N' " +
                "AND tab_calculo_variable.pex_id <> 0 " +
                "GROUP BY " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login, " +
                "tab_variable.var_orden " +
                "ORDER BY " +
                "tab_variable.var_orden, " +
                "tab_variable.var_id ASC ";

          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo_Variable cv = new Calculo_Variable();
            cv.Cav_nro = System.Convert.ToInt64(i);
            cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
            cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

            cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            cv.Cav_mes = MESES[cv.Mes_id - 1];

            cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
            cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
            cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
            cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
            cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
            lstCv.Add(cv);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);


          // Cargar Variables a Cuenta
          Connection_On();
          // Variables Titular
          SQL = "SELECT " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                "AND tab_variable.tcl_id = " + tcl_id + " " +
                "AND tab_calculo.ani_id = " + ani_id + " " +
                "AND tab_calculo.mes_id = " + mes_id + " " +
                "AND tab_variable.var_tipo = 'N' " +
                "AND tab_calculo_variable.pex_id <> 0 " +
                "GROUP BY " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login, " +
                "tab_variable.var_orden " +
                "ORDER BY " +
                "tab_variable.var_orden, " +
                "tab_variable.var_id ASC ";
          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo_Variable cv = new Calculo_Variable();
            cv.Cav_nro = System.Convert.ToInt64(i);
            cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
            cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

            cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            cv.Cav_mes = MESES[cv.Mes_id - 1];

            cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
            cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
            cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
            cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
            cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
            lstCv.Add(cv);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);
          return lstCv;

        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return lstCv;
        }
        finally
        {
          Connection_Off(1);
        }
      }








      /// <summary>
      /// listCampoMercadoValor Method
      /// </summary>
      public List<Calculo_Variable> listCalculoVariableDetalle(long ctt_id, long tcl_id, long ani_id, long mes_id, long cam_id)
      {
        long usu_id = 0;
        long i = 1;
        Session objSession = new Session();
        usu_id = objSession.USU_ID;
        String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
        List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
        try
        {
          Connection_On();

          // Variables Titular
          SQL = "SELECT " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_calculo_variable.cav_valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                "AND (tab_variable.tcl_id = " + tcl_id + " OR tab_variable.tcl_id = 3 ) " +
                "AND tab_calculo.ani_id = " + ani_id + " " +
                "AND tab_calculo.mes_id = " + mes_id + " " +
                "AND tab_calculo_variable.cam_id = " + cam_id + " " +
                "AND tab_variable.var_tipo = 'N' " +
                "AND tab_calculo_variable.pex_id <> 0 " +
                "ORDER BY " +
                "tab_variable.var_orden, " +
                "tab_variable.var_id ASC ";



          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo_Variable cv = new Calculo_Variable();
            cv.Cav_nro = System.Convert.ToInt64(i);
            cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
            cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

            cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            cv.Cav_mes = MESES[cv.Mes_id - 1];

            cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
            cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
            cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
            cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
            cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["cav_valor"].Value);
            lstCv.Add(cv);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);
          return lstCv;
        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return lstCv;
        }
        finally
        {
          Connection_Off(1);
        }
      }



      /// <summary>
      /// listCampoMercadoValor Method
      /// </summary>
      public List<Calculo_Variable> listCalculoVariable(long ctt_id, long tcl_id, long ani_id, long mes_id)
      {
        long usu_id = 0;
        long i = 1;
        Session objSession = new Session();
        usu_id = objSession.USU_ID;
        String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
        List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
        try
        {
          Connection_On();

          // Variables Titular
          SQL = "SELECT " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_calculo_variable.cav_valor AS valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login " +
                "FROM " +
                "tab_contrato " +
                "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                "AND tab_variable.tcl_id = " + tcl_id + " " +
                "AND tab_calculo.ani_id = " + ani_id + " " +
                "AND tab_calculo.mes_id = " + mes_id + " " +
                "GROUP BY " +
                "tab_calculo.ctt_id, " +
                "tab_contrato.ctt_codigo, " +
                "tab_contrato.ctt_nombre, " +
                "tab_calculo_variable.cav_tipo, " +
                "tab_calculo.ani_id, " +
                "tab_calculo.mes_id, " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_calculo_variable.cav_valor, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_usuario.usu_login, " +
                "tab_variable.var_orden " +
                "ORDER BY " +
                "tab_variable.var_orden, " +
                "tab_variable.var_id ASC ";



          // Execute the query specifying static sursor, batch optimistic locking
          rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
          while (!rs.EOF)
          {
            Calculo_Variable cv = new Calculo_Variable();
            cv.Cav_nro = System.Convert.ToInt64(i);
            cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
            cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
            cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
            cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
            cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

            cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
            cv.Cav_mes = MESES[cv.Mes_id - 1];

            cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
            cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
            cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
            cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
            cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
            lstCv.Add(cv);
            rs.MoveNext();
            i++;
          }
          Connection_Off(1);
          return lstCv;
        }
        catch (COMException err)
        {
          Console.WriteLine("Error: " + err.Message);
          Connection_Off(1);
          return lstCv;
        }
        finally
        {
          Connection_Off(1);
        }
      }



        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariable(long cal_id, long var_id, long cam_id)
        {
          long usu_id = 0;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (cal_id != 0 ? ("AND tab_calculo_variable.cal_id =" + cal_id + " ") : " ");
          where += (var_id != 0 ? (" AND tab_calculo_variable.var_id =" + var_id + "") : " ");
          where += (cam_id != 0 ? (" AND tab_calculo_variable.cam_id =" + cam_id + "" + " ") : " ");
          List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_calculo_variable.cav_id, " +
                  "tab_calculo_variable.cal_id, " +
                  "tab_calculo_variable.var_id, " +
                  "tab_calculo_variable.mon_id, " +
                  "tab_calculo_variable.cav_valor, " +
                  "tab_calculo_variable.cav_estado, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_calculo_variable.umd_id, " +
                  "tab_calculo_variable.cav_tipo, " +
                  "tab_calculo_variable.pex_id " +
                  "FROM " +
                  "tab_calculo_variable " +
                  "WHERE tab_calculo_variable.cav_estado = 1 " +
                  where +
                  " ORDER BY " +
                  " tab_calculo_variable.cav_id ASC " ;

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!rs.EOF)
            {
              Calculo_Variable cv = new Calculo_Variable();
              cv.Cav_id = System.Convert.ToInt64(rs.Fields["cav_id"].Value);
              cv.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
              cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
              cv.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
              cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["cav_valor"].Value);
              cv.Cav_estado = System.Convert.ToInt64(rs.Fields["cav_estado"].Value);
              cv.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
              cv.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
              cv.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
              cv.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
              cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
              cv.Pex_id = System.Convert.ToInt64(rs.Fields["pex_id"].Value);
              lstCv.Add(cv);
              rs.MoveNext();
            }
            return lstCv;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstCv;
          }
          finally
          {
            Connection_Off(1);
          }
        }



        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariable(long cal_id, long var_id)
        {
          long usu_id = 0;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (cal_id != 0 ? ("AND tab_calculo_variable.cal_id =" + cal_id + "") : "");
          where += (var_id != 0 ? ("AND tab_calculo_variable.var_id =" + var_id + "") : "");

          List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_calculo_variable.cav_id, " +
                  "tab_calculo_variable.cal_id, " +
                  "tab_calculo_variable.var_id, " +
                  "tab_calculo_variable.mon_id, " +
                  "tab_calculo_variable.cav_valor, " +
                  "tab_calculo_variable.cav_estado, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_calculo_variable.umd_id, " +
                  "tab_calculo_variable.cav_tipo " +
                  "FROM " +
                  "tab_calculo_variable " +
                  "WHERE tab_calculo_variable.cav_estado = 1 " +
                  where +
                  " ORDER BY " +
                  " tab_calculo_variable.cav_id ASC ";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!rs.EOF)
            {
              Calculo_Variable cv = new Calculo_Variable();
              cv.Cav_id = System.Convert.ToInt64(rs.Fields["cav_id"].Value);
              cv.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
              cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
              cv.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
              cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["cav_valor"].Value);
              cv.Cav_estado = System.Convert.ToInt64(rs.Fields["cav_estado"].Value);
              cv.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
              cv.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
              cv.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
              cv.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
              cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
              lstCv.Add(cv);
              rs.MoveNext();
            }
            return lstCv;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstCv;
          }
          finally
          {
            Connection_Off(1);
          }
        }




        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariable(long ctt_id)
        {
          long usu_id = 0;
          Session objSession = new Session();
          usu_id = objSession.USU_ID;
          String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
          List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_calculo.ctt_id, " +
                  "tab_contrato.ctt_codigo, " +
                  "tab_contrato.ctt_nombre, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_campo.cam_nombre, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_producto.pro_codigo, " +
                  "tab_unidad_medida.umd_codigo, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_mercado.mer_codigo, " +
                  "tab_calculo.ani_id, " +
                  "tab_calculo.mes_id, " +
                  "tab_variable.var_id, " +
                  "tab_variable.var_codigo, " +
                  "tab_variable.var_nombre, " +
                  "tab_moneda.mon_codigo, " +
                  "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                  "tab_usuario.usu_login " +
                  "FROM " +
                  "tab_contrato " +
                  "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                  "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                  "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                  "INNER JOIN tab_campo ON tab_campo.cam_id = tab_calculo_variable.cam_id " +
                  "INNER JOIN tab_producto ON tab_producto.pro_id = tab_calculo_variable.pro_id " +
                  "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_calculo_variable.mer_id " +
                  "INNER JOIN tab_moneda ON tab_moneda.mon_id = tab_calculo.mon_id " +
                  "INNER JOIN tab_unidad_medida ON tab_producto.pro_id = tab_unidad_medida.pro_id " +
                  "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                  "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                  "AND tab_usuario.usu_id = " + usu_id + " " +
                  "GROUP BY " +
                  "tab_calculo.ctt_id, " +
                  "tab_contrato.ctt_codigo, " +
                  "tab_contrato.ctt_nombre, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_campo.cam_nombre, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_producto.pro_codigo, " +
                  "tab_unidad_medida.umd_codigo, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_mercado.mer_codigo, " +
                  "tab_calculo.ani_id, " +
                  "tab_calculo.mes_id, " +
                  "tab_variable.var_id, " +
                  "tab_variable.var_codigo, " +
                  "tab_variable.var_nombre, " +
                  "tab_moneda.mon_codigo, " +
                  "tab_usuario.usu_login " +
                  "ORDER BY " +
                  "tab_calculo.ctt_id ASC, " +
                  "tab_calculo.ani_id ASC, " +
                  "tab_calculo.mes_id ASC, " +
                  "tab_variable.var_id ASC ";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!rs.EOF)
            {
              Calculo_Variable cv = new Calculo_Variable();
              cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
              cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
              cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
              cv.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
              cv.Cam_nombre = System.Convert.ToString(rs.Fields["cam_nombre"].Value);
              cv.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
              cv.Pro_codigo = System.Convert.ToString(rs.Fields["pro_codigo"].Value);
              cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
              cv.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
              cv.Mer_codigo = System.Convert.ToString(rs.Fields["mer_codigo"].Value);
              cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
              cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
              cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
              cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
              cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
              cv.Mon_codigo = System.Convert.ToString(rs.Fields["mon_codigo"].Value);
              cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
              lstCv.Add(cv);
              rs.MoveNext();
            }


            // Variables Titular
            SQL = "SELECT " +
                  "tab_calculo.ctt_id, " +
                  "tab_contrato.ctt_codigo, " +
                  "tab_contrato.ctt_nombre, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_campo.cam_nombre, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_producto.pro_codigo, " +
                  "tab_unidad_medida.umd_codigo, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_mercado.mer_codigo, " +
                  "tab_calculo.ani_id, " +
                  "tab_calculo.mes_id, " +
                  "tab_variable.var_id, " +
                  "tab_variable.var_codigo, " +
                  "tab_variable.var_nombre, " +
                  "tab_moneda.mon_codigo, " +
                  "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                  "tab_usuario.usu_login " +
                  "FROM " +
                  "tab_contrato " +
                  "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                  "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                  "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                  "INNER JOIN tab_campo ON tab_campo.cam_id = tab_calculo_variable.cam_id " +
                  "INNER JOIN tab_producto ON tab_producto.pro_id = tab_calculo_variable.pro_id " +
                  "INNER JOIN tab_mercado ON tab_mercado.mer_id = tab_calculo_variable.mer_id " +
                  "INNER JOIN tab_moneda ON tab_moneda.mon_id = tab_calculo.mon_id " +
                  "INNER JOIN tab_unidad_medida ON tab_producto.pro_id = tab_unidad_medida.pro_id " +
                  "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                  "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                  "AND tab_usuario.usu_id = " + usu_id + " " +
                  "GROUP BY " +
                  "tab_calculo.ctt_id, " +
                  "tab_contrato.ctt_codigo, " +
                  "tab_contrato.ctt_nombre, " +
                  "tab_calculo_variable.cam_id, " +
                  "tab_campo.cam_nombre, " +
                  "tab_calculo_variable.pro_id, " +
                  "tab_producto.pro_codigo, " +
                  "tab_unidad_medida.umd_codigo, " +
                  "tab_calculo_variable.mer_id, " +
                  "tab_mercado.mer_codigo, " +
                  "tab_calculo.ani_id, " +
                  "tab_calculo.mes_id, " +
                  "tab_variable.var_id, " +
                  "tab_variable.var_codigo, " +
                  "tab_variable.var_nombre, " +
                  "tab_moneda.mon_codigo, " +
                  "tab_usuario.usu_login " +
                  "ORDER BY " +
                  "tab_calculo.ctt_id ASC, " +
                  "tab_calculo.ani_id ASC, " +
                  "tab_calculo.mes_id ASC, " +
                  "tab_variable.var_id ASC ";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Calculo_Variable cv = new Calculo_Variable();
              cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
              cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
              cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
              cv.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
              cv.Cam_nombre = System.Convert.ToString(rs.Fields["cam_nombre"].Value);
              cv.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
              cv.Pro_codigo = System.Convert.ToString(rs.Fields["pro_codigo"].Value);
              cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
              cv.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
              cv.Mer_codigo = System.Convert.ToString(rs.Fields["mer_codigo"].Value);
              cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
              cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
              cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
              cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
              cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
              cv.Mon_codigo = System.Convert.ToString(rs.Fields["mon_codigo"].Value);
              cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
              lstCv.Add(cv);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstCv;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstCv;
          }
          finally
          {
            Connection_Off(1);
          }
        }

        public bool validarCalculo(long anio_id, long mes_id, long pex_id, long ctt_id, long tcl_id)
        {
            long usu_id = 0;
            bool flag;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id ='" + ctt_id + "'") : " ");
            where += (pex_id != 0 ? ("AND tab_calculo_variable.pex_id ='" + pex_id + "'") : " ");
            where += (tcl_id != 0 ? ("AND tab_calculo.tcl_id ='" + tcl_id + "'") : " ");
            where += (anio_id != 0 ? ("AND tab_calculo.ani_id ='" + anio_id + "'") : " ");
            where += (mes_id != 0 ? ("AND tab_calculo.mes_id ='" + mes_id + "'") : " ");
            try
            {
                Connection_On();
                string SQL = "SELECT " +
                            "tab_calculo_variable.pex_id, " +
                            "tab_calculo_variable.cav_id, " +
                            "tab_calculo_variable.cal_id, " +
                            "tab_calculo_variable.var_id, " +
                            "tab_calculo_variable.mon_id, " +
                            "tab_calculo_variable.cav_valor, " +
                            "tab_calculo_variable.cav_estado, " +
                            "tab_calculo_variable.cam_id, " +
                            "tab_calculo_variable.pro_id, " +
                            "tab_calculo_variable.mer_id, " +
                            "tab_calculo_variable.umd_id, " +
                            "tab_calculo_variable.cav_tipo, " +
                            "tab_calculo.ctt_id, "+
                            "tab_calculo.ani_id, " +
                            "tab_calculo.mes_id " +
                            "FROM " +
                            "tab_calculo " +
                            "INNER JOIN tab_calculo_variable ON tab_calculo_variable.cal_id = tab_calculo.cal_id " +
                            "INNER JOIN tab_parexcel ON tab_parexcel.pex_id = tab_calculo_variable.pex_id " +
                            "INNER JOIN tab_contrato ON tab_calculo.ctt_id = tab_contrato.ctt_id " +
                            "WHERE " +
                            "tab_calculo.cal_estado = 1 AND tab_calculo_variable.cav_estado = 1 " +
                            where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Calculo_Variable cv = new Calculo_Variable();
                    cv.Pex_id = System.Convert.ToInt64(rs.Fields["pex_id"].Value);
                    cv.Cav_id = System.Convert.ToInt64(rs.Fields["cav_id"].Value);
                    cv.Cal_id = System.Convert.ToInt64(rs.Fields["cal_id"].Value);
                    cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    cv.Mon_id = System.Convert.ToInt64(rs.Fields["mon_id"].Value);
                    cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["cav_valor"].Value);
                    cv.Cav_estado = System.Convert.ToInt64(rs.Fields["cav_estado"].Value);
                    cv.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
                    cv.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
                    cv.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
                    cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
                    cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                    cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    lstCalculoVariable.Add(cv);
                    rs.MoveNext();
                }
                Connection_Off(1);
                if (lstCalculoVariable.Count > 0)
                    flag = true;
                else
                    flag = false;
                return flag;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                if (lstCalculoVariable.Count > 0)
                    flag = true;
                else
                    flag = false;
                return flag;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public void Eliminar(long anio_id, long mes_id, long pex_id, long tcl_id, long ctt_id)
        {
            long usu_id = 0;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            String where = (pex_id != 0 ? ("AND tab_calculo_variable.pex_id ='" + pex_id + "'") : " ");
            where += (tcl_id != 0 ? (" AND tab_calculo.tcl_id ='" + tcl_id + "'") : " ");
            where += (anio_id != 0 ? (" AND tab_calculo.ani_id ='" + anio_id + "'") : " ");
            where += (mes_id != 0 ? (" AND tab_calculo.mes_id ='" + mes_id + "'") : " ");
            where += (ctt_id != 0 ? (" AND tab_calculo.ctt_id ='" + ctt_id + "'") : " ");
            try
            {
                Connection_On();
                SQL = "DELETE FROM tab_calculo_variable WHERE tab_calculo_variable.cav_id IN " +
                      "(SELECT tab_calculo_variable.cav_id "+
                      "FROM tab_calculo_variable, tab_calculo " +
                      "WHERE tab_calculo_variable.cal_id = tab_calculo.cal_id " +
                      where + " )";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                Connection_Off(1);

            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public void EliminacionMasiva(long pex_id)
        {
            long usu_id = 0;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            string where;
            where = (pex_id != 0 ? (" tab_calculo_variable.pex_id ='" + pex_id + "'") : "");
            try
            {
                Connection_On();
                SQL = "DELETE " +
                      "FROM tab_calculo_variable " +
                      "WHERE " +
                      where;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                Connection_Off(1);

            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
            }
            finally
            {
                Connection_Off(1);
            }
        }






        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariableTotalProyecciones(long ctt_id, long tcl_id, long ani_id, long mes_id)
        {
            long usu_id = 0;
            long i = 1;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
            List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
            try
            {
                Connection_On();

                //// Variables Titular
                //SQL = "SELECT " +
                //      "tab_calculo.ctt_id, " +
                //      "tab_contrato.ctt_codigo, " +
                //      "tab_contrato.ctt_nombre, " +
                //      "tab_calculo_variable.cav_tipo, " +
                //      "tab_calculo.ani_id, " +
                //      "tab_calculo.mes_id, " +
                //      "tab_variable.var_id, " +
                //      "tab_variable.var_codigo, " +
                //      "tab_variable.var_nombre, " +
                //      "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                //      "tab_unidad_medida.umd_codigo " +
                //      "FROM " +
                //      "tab_contrato " +
                //      "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                //      "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                //      "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                //      "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                //      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " + 
                //      "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                //      "AND (tab_variable.tcl_id = " + tcl_id + " OR tab_variable.tcl_id = 3 ) " +
                //      "AND tab_calculo.ani_id = " + ani_id + " " +
                //      "AND tab_calculo.mes_id = " + mes_id + " " +
                //      "GROUP BY " +
                //      "tab_calculo.ctt_id, " +
                //      "tab_contrato.ctt_codigo, " +
                //      "tab_contrato.ctt_nombre, " +
                //      "tab_calculo_variable.cav_tipo, " +
                //      "tab_calculo.ani_id, " +
                //      "tab_calculo.mes_id, " +
                //      "tab_variable.var_id, " +
                //      "tab_variable.var_codigo, " +
                //      "tab_variable.var_nombre, " +
                //      "tab_unidad_medida.umd_codigo, " +
                //      "tab_variable.var_orden " +
                //      "ORDER BY " +
                //      "tab_variable.var_orden, " +
                //      "tab_variable.var_id ASC ";

                SQL = "SELECT " +
                      "tab_contrato.ctt_id, " +
                      "tab_contrato.ctt_nombre, " +
                      "tab_calculo.ani_id, " +
                      "tab_calculo.mes_id, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "sum(tab_calculo_variable.cav_valor) as valor, " +
                      "tab_variable.tcl_id " +
                      "FROM " +
                      "tab_contrato " +
                      "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                      "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                      "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                      "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_calculo.tcl_id " +
                      "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                      "AND (tab_tipo_calculo.tcl_id = " + tcl_id + " OR tab_tipo_calculo.tcl_id = 3 ) " +
                      "AND tab_calculo.ani_id = " + ani_id + " " +
                      "AND tab_calculo.mes_id = " + mes_id + " " +
                      "GROUP BY " +
                      "tab_contrato.ctt_id,  " +
                      "tab_contrato.ctt_nombre,  " +
                      "tab_calculo.ani_id, " +
                      "tab_calculo.mes_id, " +
                      "tab_variable.var_orden, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "tab_variable.tcl_id " +                      
                      "ORDER by tab_variable.var_orden ";
  
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Calculo_Variable cv = new Calculo_Variable();
                    cv.Cav_nro = System.Convert.ToInt64(i);
                    cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
                    cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    cv.Cav_mes = MESES[cv.Mes_id - 1];
                    cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
                    cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
                    cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
                    lstCv.Add(cv);
                    rs.MoveNext();
                    i++;
                }
                Connection_Off(1);
                return lstCv;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCv;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public decimal ValidarSumaCampo(long ctt_id, long cam_id, long mes_id, long anio_id)
        {
            long usu_id = 0;
            bool flag;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_Variable cv = new Calculo_Variable();
            String where = (ctt_id != 0 ? ("AND tab_calculo.ctt_id ='" + ctt_id + "'") : " ");
            where += (anio_id != 0 ? ("AND tab_calculo.ani_id ='" + anio_id + "'") : " ");
            where += (mes_id != 0 ? ("AND tab_calculo.mes_id ='" + mes_id + "'") : " ");
            where += (cam_id != 0 ? ("AND tab_calculo_variable.cam_id ='" + cam_id + "'") : " ");
            try
            {
                Connection_On();
                string SQL = "SELECT " +
                            "sum(tab_calculo_variable.cav_valor) as cav_valor " +
                            "FROM " +
                            "tab_calculo, tab_calculo_variable, tab_variable " +
                            "WHERE " +
                            "tab_calculo.cal_id = tab_calculo_variable.cal_id and " +
                            "tab_calculo.cal_estado = 1 AND tab_calculo_variable.cav_estado = 1 and " +
                            "tab_variable.var_id = tab_calculo_variable.var_id and " +
                            "tab_calculo_variable.pex_id <> 0 " +
                            "and tab_variable.var_codigo <> 'Dt' " +
                            "and tab_variable.var_codigo <> 'Ot' " +
                            "and tab_variable.var_codigo <> 'At' " +
                            "and tab_variable.var_codigo <> 'ITFt'" +
                            "and tab_variable.var_codigo <> 'It' " +
                            "and tab_variable.var_codigo <> 'ITt'" +
                            where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    if (Convert.IsDBNull(rs.Fields["cav_valor"].Value))
                        cv.Cav_valor = 0;
                    else
                        cv.Cav_valor = System.Convert.ToInt64(rs.Fields["cav_valor"].Value);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return cv.Cav_valor;
                
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return cv.Cav_valor;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public bool validarValorVariabvle(long cal_id, long var_id)
        {
            long usu_id = 0;
            bool flag = false;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            List<Calculo_Variable> lstCalculoVariable = new List<Calculo_Variable>();
            Calculo_Variable cv = new Calculo_Variable();
            String where = (cal_id != 0 ? ("AND tab_variable.var_id ='" +var_id + "'") : " ");
            where += (var_id != 0 ? ("AND tab_calculo_variable.cal_id ='" + cal_id + "'") : " ");        
            try
            {
                Connection_On();
                string SQL = "SELECT " +
                            "tab_calculo_variable.cav_valor " +
                            "FROM " +
                            "tab_calculo, tab_calculo_variable, tab_variable " +
                            "WHERE " +
                            "tab_calculo.cal_id = tab_calculo_variable.cal_id and tab_variable.var_id = tab_calculo_variable.var_id and " +
                            "tab_calculo.cal_estado = 1 AND tab_calculo_variable.cav_estado = 1  " +
                            where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    if (Convert.IsDBNull(rs.Fields["cav_valor"].Value))
                        flag = false;
                    else
                    {
                        cv.Cav_valor = System.Convert.ToInt64(rs.Fields["cav_valor"].Value);
                        if (cv.Cav_valor == 0)
                            flag = false;
                        else
                            flag = true;
                    }
                    rs.MoveNext();
                }
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


        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariableDetalleTotales(long ctt_id, long tcl_id, long ani_id, long mes_id)
        {
            long usu_id = 0;
            long i = 1;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
            List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
            try
            {
                Connection_On();

                // Variables Titular
                SQL = "SELECT " +
                    "tab_calculo.ctt_id, " +
                    "tab_contrato.ctt_codigo, " +
                    "tab_contrato.ctt_nombre,  " +
                    "tab_calculo_variable.cav_tipo,  " +
                    "tab_calculo.ani_id, " +
                    "tab_calculo.mes_id, " +
                    "tab_variable.var_id, " +
                    "tab_variable.var_codigo, " +
                    "tab_variable.var_nombre, " +
                    "sum(tab_calculo_variable.cav_valor) as cav_valor, " +
                    "tab_unidad_medida.umd_codigo,  " +
                    "tab_usuario.usu_login , " +
                    "tab_variable.var_tipo_cal " +
                    "FROM " +
                    "tab_contrato  " +
                    "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id  " +
                    "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                    "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                    "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                    "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                    "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                    "WHERE tab_calculo.ctt_id =  " + ctt_id + " " +
                    "AND (tab_variable.tcl_id = " + tcl_id + " OR tab_variable.tcl_id = 3 )  " +
                    "AND tab_calculo.ani_id = " + ani_id + " " +
                    "AND tab_calculo.mes_id = " + mes_id + " " +
                    "and (tab_variable.var_tipo_cal = 1 " +
                    "or tab_variable.var_tipo_cal = 4) " +
                    "GROUP BY  " +
                    "tab_calculo.ctt_id, " +
                    "tab_contrato.ctt_codigo,  " +
                    "tab_contrato.ctt_nombre, " +
                    "tab_calculo_variable.cav_tipo,  " +
                    "tab_calculo.ani_id,  " +
                    "tab_calculo.mes_id, " +
                    "tab_variable.var_id, " +
                    "tab_variable.var_codigo,  " +
                    "tab_variable.var_nombre, " +
                    "tab_unidad_medida.umd_codigo, " +
                    "tab_usuario.usu_login , " +
                    "tab_variable.var_tipo_cal, " +
                    "tab_variable.var_orden " +
                    "ORDER BY " +
                    "tab_variable.var_orden,  " +
                    "tab_variable.var_id ASC ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Calculo_Variable cv = new Calculo_Variable();
                    cv.Cav_nro = System.Convert.ToInt64(i);
                    cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
                    cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

                    cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    cv.Cav_mes = MESES[cv.Mes_id - 1];

                    cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
                    cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
                    cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["cav_valor"].Value);
                    lstCv.Add(cv);
                    rs.MoveNext();
                    i++;
                }
                Connection_Off(1);
                return lstCv;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCv;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        /// <summary>
        /// listCampoMercadoValor Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariableTotales(long anio_idF, long tcl_id, long ani_id, long mes_id,long mes_idF, long var_id)
        {
            long usu_id = 0;
            long i = 1;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
            try
            {
                Connection_On();

                // Variables Titular
                SQL = "SELECT " +
                      "tab_calculo.ctt_id, " +
                      "tab_contrato.ctt_codigo, " +
                      "tab_contrato.ctt_nombre, " +
                      "tab_calculo_variable.cav_tipo, " +
                      "tab_variable.var_id, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "sum(tab_calculo_variable.cav_valor) AS valor, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "tab_usuario.usu_login " +
                      "FROM " +
                      "tab_contrato " +
                      "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                      "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                      "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                      "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                      "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                      "WHERE tab_calculo_variable.var_id = " + var_id + " " +
                      "AND (tab_variable.tcl_id = " + tcl_id + " or tab_variable.tcl_id = 3) " +
                      "AND tab_calculo.ani_id BETWEEN " + ani_id + " and " + anio_idF + " " +
                      "AND tab_calculo.mes_id BETWEEN " + mes_id + " and " + mes_idF + " " +
                      "GROUP BY " +
                      "tab_calculo.ctt_id, " +
                      "tab_contrato.ctt_codigo, " +
                      "tab_contrato.ctt_nombre, " +
                      "tab_calculo_variable.cav_tipo, " +
                      "tab_variable.var_id, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "tab_usuario.usu_login, " +
                      "tab_variable.var_orden " +
                      "ORDER BY " +
                      "tab_variable.var_orden, " +
                      "tab_variable.var_id ASC ";



                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Calculo_Variable cv = new Calculo_Variable();
                    cv.Cav_nro = System.Convert.ToInt64(i);
                    cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
                    cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
                    cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
                    cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
                    lstCv.Add(cv);
                    rs.MoveNext();
                    i++;
                }
                Connection_Off(1);
                return lstCv;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCv;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public  void updateCav_Valor(long id, decimal volumenSeca_60)
        {
            long updated = 0;
            try
            {
                string SQL = "UPDATE tab_calculo_variable SET  cav_valor = " + volumenSeca_60 + " WHERE  cav_id = " + id + ";";

                object ab;
                Connection_On();
                cnn.Execute(SQL, out ab, 0);
                Connection_Off(1);
                updated = 1;
                //return updated;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                updated = 0;
                //return updated;
            }
        }


        /// <summary>
        /// Consulta para recuper los totales ya procesados Method
        /// </summary>
        public List<Calculo_Variable> listCalculoVariableTotalProcesado(long ctt_id, long tcl_id, long ani_id, long mes_id)
        {
            long usu_id = 0;
            long i = 1;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            String where = (ctt_id != 0 ? ("AND tab_contrato.ctt_id =" + ctt_id + "") : "");
            List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
            try
            {
                Connection_On();

                // Variables Titular
                SQL = "SELECT " +
                      "tab_calculo.ctt_id, " +
                      "tab_contrato.ctt_codigo, " +
                      "tab_contrato.ctt_nombre, " +
                      "tab_calculo_variable.cav_tipo, " +
                      "tab_calculo.ani_id, " +
                      "tab_calculo.mes_id, " +
                      "tab_variable.var_id, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "Sum(tab_calculo_variable.cav_valor) AS valor, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "tab_usuario.usu_login " +
                      "FROM " +
                      "tab_contrato " +
                      "INNER JOIN tab_calculo ON tab_contrato.ctt_id = tab_calculo.ctt_id " +
                      "INNER JOIN tab_calculo_variable ON tab_calculo.cal_id = tab_calculo_variable.cal_id " +
                      "INNER JOIN tab_variable ON tab_variable.var_id = tab_calculo_variable.var_id " +
                      "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                      "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                      "INNER JOIN tab_usuario ON tab_usuario.usu_id = tab_contrato.usu_id " +
                      "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
                      "AND (tab_variable.tcl_id = " + tcl_id + " OR tab_variable.tcl_id = 3 ) " +
                      "AND tab_calculo.ani_id = " + ani_id + " " +
                      "AND tab_calculo.mes_id = " + mes_id + " " +
                      "AND tab_variable.var_tipo_cal = 1 " +
                      "AND tab_calculo_variable.pex_id = 0 " +
                      "GROUP BY " +
                      "tab_calculo.ctt_id, " +
                      "tab_contrato.ctt_codigo, " +
                      "tab_contrato.ctt_nombre, " +
                      "tab_calculo_variable.cav_tipo, " +
                      "tab_calculo.ani_id, " +
                      "tab_calculo.mes_id, " +
                      "tab_variable.var_id, " +
                      "tab_variable.var_codigo, " +
                      "tab_variable.var_nombre, " +
                      "tab_unidad_medida.umd_codigo, " +
                      "tab_usuario.usu_login, " +
                      "tab_variable.var_orden " +
                      "ORDER BY " +
                      "tab_variable.var_orden, " +
                      "tab_variable.var_id ASC ";



                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Calculo_Variable cv = new Calculo_Variable();
                    cv.Cav_nro = System.Convert.ToInt64(i);
                    cv.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    cv.Ctt_codigo = System.Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    cv.Ctt_nombre = System.Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    cv.Cav_tipo = System.Convert.ToString(rs.Fields["cav_tipo"].Value);
                    cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);

                    cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
                    cv.Cav_mes = MESES[cv.Mes_id - 1];

                    cv.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
                    cv.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
                    cv.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
                    cv.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
                    cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
                    lstCv.Add(cv);
                    rs.MoveNext();
                    i++;
                }
                Connection_Off(1);
                return lstCv;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCv;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
