using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Controller;

namespace Model
{
  public class VariableObject : Variable
  {
    string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

    /// <summary>
    /// existVariable Method
    /// </summary>
    public bool existVariable(long var_id)
    {
      bool flag = false;
      try
      {
        Connection_On();
        SQL = "SELECT var_id FROM tab_variable WHERE var_id='" + var_id + "'";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        if (!rs.EOF)
        {
          Connection_Off(1);
          flag = true;
        }
        else
        {
          Connection_Off(1);
          flag = false;
        }
        Connection_Off(1);
        return flag;
      }
      catch (COMException err)
      {
        Connection_Off(1);
        Console.WriteLine("Error: " + err.Message);
        flag = false;
        return flag;
      }
    }/* Method existUser */


    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariablePorCondicion(string condicion)
    {
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "tab_variable.var_tipo_cal, " +
                "tab_variable.var_posicion, " +
                "tab_variable.var_impresion_a, " +
                "tab_variable.cam_id, " +
                "tab_variable.var_m, " +
                "tab_variable.var_cam, " +
                "tab_variable.for_m " +
                "FROM " +
                "tab_variable " +
                "WHERE tab_variable.var_estado = 1 " +
                condicion +
              " ORDER BY var_id";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          variable.Var_tipo_cal = System.Convert.ToInt64(rs.Fields["var_tipo_cal"].Value);
          variable.Var_posicion = System.Convert.ToInt64(rs.Fields["var_posicion"].Value);
          variable.Var_impresion_a = System.Convert.ToInt64(rs.Fields["var_impresion_a"].Value);
          variable.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
          variable.Var_m = System.Convert.ToInt32(rs.Fields["var_m"].Value);
          variable.Var_cam = System.Convert.ToInt32(rs.Fields["var_cam"].Value);
          variable.For_m = System.Convert.ToInt32(rs.Fields["for_m"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */


    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariablePorCondicionyOrden(string condicion, string orden)
    {
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "tab_variable.var_tipo_cal, " +
                "tab_variable.var_posicion, " +
                "tab_variable.var_impresion_a, " +
                "tab_variable.cam_id, " +
                "tab_variable.var_m, " +
                "tab_variable.var_cam, " +
                "tab_variable.for_m " +
                "FROM " +
                "tab_variable " +
                "WHERE tab_variable.var_estado = 1 " +
                condicion +
                orden ;

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          variable.Var_tipo_cal = System.Convert.ToInt64(rs.Fields["var_tipo_cal"].Value);
          variable.Var_posicion = System.Convert.ToInt64(rs.Fields["var_posicion"].Value);
          variable.Var_impresion_a = System.Convert.ToInt64(rs.Fields["var_impresion_a"].Value);
          variable.Cam_id = System.Convert.ToInt64(rs.Fields["cam_id"].Value);
          variable.Var_m = System.Convert.ToInt32(rs.Fields["var_m"].Value);
          variable.Var_cam = System.Convert.ToInt32(rs.Fields["var_cam"].Value);
          variable.For_m = System.Convert.ToInt32(rs.Fields["for_m"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */



    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariable(long var_id)
    {
      String where = (var_id != 0 ? ("AND var_id=" + var_id + "") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "(CASE tab_variable.var_imprime WHEN 0 THEN 'No' WHEN 1 THEN 'Si' END) as var_imprime_text, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "tab_variable.var_tipo_cal, " +
                "tab_variable.var_posicion, " +
                "tab_variable.var_impresion_a, " +
                "tab_variable.cam_id, " +
                "tab_campo.cam_nombre, " +
                "(SELECT vr.var_codigo FROM tab_variable vr WHERE vr.var_id = tab_variable.vard_id) AS vard_codigo, " +
                "(SELECT tab_mercado.mer_codigo FROM tab_mercado WHERE tab_mercado.mer_id = tab_variable.mer_id and tab_mercado.mer_estado = 1) as mercado, " +
                "(SELECT tab_producto.pro_codigo FROM tab_producto WHERE tab_producto.pro_id = tab_variable.pro_id) as producto, " +
                "(SELECT tab_tipo_proyeccion.tpy_nombre FROM tab_tipo_proyeccion WHERE tab_tipo_proyeccion.tpy_id = tab_variable.tpy_id) as tipoproyeccion, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula, " +
            ////aumentado diego 10-10-2012
                "tab_variable.var_m, " +
                "tab_variable.var_cam, " +
                "tab_variable.for_m " +
                //////////////////////
                "FROM " +
                "tab_variable " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "INNER JOIN tab_campo on tab_campo.cam_id = tab_variable.cam_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
                " AND tab_campo.cam_estado = 1 " +
                where +
                " ORDER BY var_orden, cam_id";


        // Execute the query specifying static sursor, batch optimistic locking
        rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs2.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs2.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs2.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs2.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs2.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs2.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs2.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs2.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs2.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs2.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs2.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs2.Fields["var_impresion"].Value);
          if (variable.Tcl_id != 2)
          {
            variable.Impresionaux = System.Convert.ToInt64(rs2.Fields["var_impresion"].Value);
          }
          else
          {
            variable.Impresionaux = System.Convert.ToInt64(rs2.Fields["var_impresion_a"].Value);
          }

          variable.Var_imprime = System.Convert.ToInt64(rs2.Fields["var_imprime"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs2.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs2.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs2.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs2.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs2.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs2.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs2.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs2.Fields["formula"].Value);
          variable.Mercado = System.Convert.ToString(rs2.Fields["mercado"].Value);
          variable.Producto = System.Convert.ToString(rs2.Fields["producto"].Value);
          variable.Var_imprime_text = System.Convert.ToString(rs2.Fields["var_imprime_text"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs2.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs2.Fields["tcl_codigo"].Value);
          variable.Tpy_nombre = System.Convert.ToString(rs2.Fields["tipoproyeccion"].Value);
          variable.Vard_codigo = System.Convert.ToString(rs2.Fields["vard_codigo"].Value);
          variable.Var_tipo_cal = Convert.ToInt64(rs2.Fields["var_tipo_cal"].Value);
          variable.Var_posicion = Convert.ToInt64(rs2.Fields["var_posicion"].Value);
          variable.Var_impresion_a = System.Convert.ToInt64(rs2.Fields["var_impresion_a"].Value);
          variable.Cam_id = System.Convert.ToInt64(rs2.Fields["cam_id"].Value);
          variable.Cam_nombre = System.Convert.ToString(rs2.Fields["cam_nombre"].Value);
          ////aumentado diego 10-10-2012
          variable.Var_m = System.Convert.ToInt32(rs2.Fields["var_m"].Value);
          variable.Var_cam = System.Convert.ToInt32(rs2.Fields["var_cam"].Value);
          variable.For_m = System.Convert.ToInt32(rs2.Fields["for_m"].Value);
            /////////////////////
          lstVariable.Add(variable);
          rs2.MoveNext();
        }
        Connection_Off(2);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(2);
        return lstVariable;
      }
    }/* Method listMenu */





    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariablePorCodigo(string var_codigo)
    {
      String where = (!var_codigo.Equals("") ? ("AND var_codigo='" + var_codigo + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_variable.var_impresion, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula, " +
                "tab_variable.tcl_id " +
                "FROM " +
                "tab_variable INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
              where +
              " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */












    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariablePorCodigoTipoCálculo(string var_codigo, long tcl_id)
    {
      String where = (!var_codigo.Equals("") ? ("AND tab_variable.var_codigo='" + var_codigo + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_variable.var_impresion, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "tab_variable.umd_id, " +
                "var_tipo_cal, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
              where +
              " AND (tab_variable.tcl_id=" + tcl_id + " OR tab_variable.tcl_id = 3) " +
              " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Var_tipo_cal = System.Convert.ToInt64(rs.Fields["var_tipo_cal"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */



    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariablePorCodigoTipoCálculoUnico(string var_codigo, long tcl_id)
    {
      String where = (!var_codigo.Equals("") ? ("AND tab_variable.var_codigo='" + var_codigo + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_variable.var_impresion, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1" +
              where +
              " AND (tab_variable.tcl_id=" + tcl_id + ") " +
              " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */


    /// <summary>
    /// findBloque Method
    /// </summary>
    public List<Bloque> findBloque(long blo_id)
    {
      List<Bloque> lstBloque = new List<Bloque>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_bloque.blo_id, " +
                "tab_bloque.blo_codigo, " +
                "tab_bloque.blo_nombre, " +
                "tab_bloque.blo_estado " +
                "FROM tab_bloque " +
                "WHERE blo_id='" + blo_id + "'";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        if (!rs.EOF)
        {
          Bloque bloque = new Bloque();
          bloque.Blo_id = System.Convert.ToInt64(rs.Fields["blo_id"].Value);
          bloque.Blo_codigo = System.Convert.ToInt64(rs.Fields["blo_codigo"].Value);
          bloque.Blo_nombre = System.Convert.ToString(rs.Fields["blo_nombre"].Value);
          bloque.Blo_estado = System.Convert.ToString(rs.Fields["blo_estado"].Value);
          lstBloque.Add(bloque);
          rs.MoveNext();
          return lstBloque;
        }
        else
        {
          Connection_Off(1);
          return lstBloque;
        }
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstBloque;
      }
    }




    public Variable listVariableByVar_Nombre(string var_nombre)
    {
      String where = (var_nombre != "" ? ("var_nombre='" + var_nombre + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id " +
                "FROM " +
                "tab_variable INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "WHERE " +
              where +
              " ORDER BY var_id";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);

      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
      }
      if (lstVariable.Count != 0)
        return lstVariable[0];
      else
        return null;
    }



    public List<Variable> listVariableSegunCriterio(string var_codigo, string var_nombre)
    {
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();

        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1" +
                "AND var_codigo LIKE '%" + var_codigo + "%'" +
                "AND var_nombre LIKE '%" + var_nombre + "%' " +
              " ORDER BY var_id";

        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          //
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }



    public List<Variable> findByTcl_id(long tcl_id)
    {
      String where = "";
      //if (tcl_id == 1)
      //{
        where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id='" + tcl_id + "' OR tab_variable.tcl_id= '3') ") : "");
      //}
      //else
      //{
      //  where = (tcl_id != 0 ? ("AND tab_variable.tcl_id=" + tcl_id + "") : "");
      //}
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
              "tab_variable.var_id, " +
              "tab_variable.var_codigo, " +
              "tab_variable.var_nombre, " +
              "tab_variable.var_descripcion, " +
              "tab_variable.var_tipo, " +
              "tab_variable.var_valini, " +
              "tab_variable.var_estado, " +
              "tab_variable.var_orden, " +
              "tab_variable.umd_id, " +
              "tab_variable.tcl_id, " +
              "tab_variable.var_impresion, " +
              "tab_variable.var_descripcion, " +
              "tab_variable.tpy_id, " +
              "tab_variable.mer_id, " +
              "tab_variable.pro_id, " +
              "tab_variable.var_codigod, " +
              "tab_variable.var_total, " +
              "tab_variable.vard_id " +
              "FROM " +
              "tab_variable " +
              "INNER JOIN tab_tipo_calculo ON tab_variable.tcl_id = tab_tipo_calculo.tcl_id " +
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "where tab_mercado.mer_estado = 1  " + where +
              " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }


    public List<Variable> findByTcl_idNoFormula(long tcl_id)
    {
      String where = (tcl_id != 0 ? ("tab_variable.tcl_id='" + tcl_id + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
              "tab_variable.var_id, " +
              "tab_variable.var_codigo, " +
              "tab_variable.var_nombre, " +
              "tab_variable.var_tipo, " +
              "tab_variable.var_valini, " +
              "tab_variable.var_estado, " +
              "tab_variable.var_orden, " +
              "tab_variable.umd_id, " +
              "tab_variable.tcl_id, " +
              "tab_variable.var_impresion, " +
              "tab_variable.var_descripcion, " +
              "tab_variable.tpy_id, " +
              "tab_variable.mer_id, " +
              "tab_variable.pro_id, " +
              "tab_variable.var_codigod, " +
              "tab_variable.var_total, " +
              "tab_variable.vard_id " +
              "FROM " +
              "tab_variable " +
              "INNER JOIN tab_tipo_calculo ON tab_variable.tcl_id = tab_tipo_calculo.tcl_id " +
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "WHERE tab_variable.var_tipo = 'N' and tab_mercado.mer_estado = 1 " +
              " AND ( " + where + " or tab_variable.tcl_id= '3') ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }





    public List<Variable> findByTcl_idNoFormulaP(long tcl_id)
    {
      String where = (tcl_id != 0 ? ("tab_variable.tcl_id='" + tcl_id + "'") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
              "tab_variable.var_id, " +
              "tab_variable.var_codigo, " +
              "tab_variable.var_nombre, " +
              "tab_variable.var_tipo, " +
              "tab_variable.var_valini, " +
              "tab_variable.var_estado, " +
              "tab_variable.var_orden, " +
              "tab_variable.umd_id, " +
              "tab_variable.tcl_id, " +
              "tab_variable.var_impresion, " +
              "tab_variable.var_descripcion, " +
              "tab_variable.tpy_id, " +
              "tab_variable.mer_id, " +
              "tab_variable.pro_id, " +
              "tab_variable.var_codigod, " +
              "tab_variable.var_total, " +
              "tab_variable.vard_id " +
              "FROM " +
              "tab_variable " +
              "INNER JOIN tab_tipo_calculo ON tab_variable.tcl_id = tab_tipo_calculo.tcl_id " +
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "WHERE tab_variable.var_tipo = 'N' AND tab_variable.tpy_id <> 3 and tab_mercado.mer_estado = 1 " +
              " AND ( " + where + " ) ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }



    public bool existVariableNombre(string var_codigo, long tcl_id)
    {
      bool flag9 = false;
      try
      {
        Connection_On();
        SQL = "SELECT var_codigo FROM tab_variable where var_codigo ='" + var_codigo + "' AND tcl_id ==" + tcl_id + " ";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        if (!rs.EOF)
        {
          Connection_Off(1);
          flag9 = true;
        }
        else
        {
          Connection_Off(1);
          flag9 = false;
        }
        Connection_Off(1);
        return flag9;
      }
      catch (COMException err)
      {
        Connection_Off(1);
        Console.WriteLine("Error: " + err.Message);
        flag9 = false;
        return flag9;
      }
    }/* Method existUser */





    // Proyección de Variables
    /// <summary>
    /// valorVariableProyectada Method
    /// </summary>
    public decimal valorVariableProyectada(long ctt_id, long tcl_id, long ani_idi, long ani_idf, long mesi_id, long mesf_id, long var_id, string var_codigo, long tpy_id)
    {
      decimal pi = 0;
      decimal notasas = 0;

      List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
      List<Calculo_Variable> lstCvProcesar = new List<Calculo_Variable>();

      decimal[] tci = new decimal[100];
      int i = 1;

      decimal primerValor = 0;
      decimal ultimoValor = 0;
      decimal tcma = 0;
      decimal VHPVSI = 0;
      int cont = 0;

      // Inicializar variable de sesión
      Session objSession5 = new Session();
      objSession5.PI = 0;

      try
      {
        Connection_On();

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
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
              "AND (tab_tipo_calculo.tcl_id = " + tcl_id + " OR tab_tipo_calculo.tcl_id = 3 ) " +
              "AND tab_calculo.ani_id BETWEEN " + ani_idi + " AND " + ani_idf + " " +
              "AND tab_calculo.mes_id BETWEEN " + mesi_id + " AND " + mesf_id + " " +
              "AND tab_variable.var_codigo = '" + var_codigo + "' " +
              "AND tab_mercado.mer_estado = 1 " +
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
              "ORDER by tab_variable.var_orden, tab_calculo.ani_id, tab_calculo.mes_id ";
        rs = new ADODB.Recordset();
        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {

          Calculo_Variable cv = new Calculo_Variable();
          cv.Ani_id = System.Convert.ToInt64(rs.Fields["ani_id"].Value);
          cv.Mes_id = System.Convert.ToInt64(rs.Fields["mes_id"].Value);
          cv.Cav_valor = System.Convert.ToDecimal(rs.Fields["valor"].Value);
          lstCv.Add(cv);


          switch (tpy_id)
          {
            case 1:
              // Sumas
              if (primerValor == 0)
              {
                primerValor = cv.Cav_valor;

              }
              else
              {
                // Calcular Tasa de Crecimiento - tci
                tci[i] = (cv.Cav_valor - primerValor) / primerValor;
                cont++;
                notasas++;
                if (mesf_id != cv.Mes_id || ani_idf != cv.Ani_id)
                {
                  primerValor = cv.Cav_valor;
                  ultimoValor = cv.Cav_valor;
                }
                else
                {
                  ultimoValor = cv.Cav_valor;
                  // Hallar la tasa de crecimiento media aritmética - tcma
                  for (int v = 1; v <= cont; v++)
                  {
                    tcma = tcma + tci[v];
                  }
                  tcma = tcma / notasas;
                }
                i++;
              }

              Session objSession = new Session();
              objSession.PI = ultimoValor;

              break;



            case 2:
              // Divisiones
              // Calcular Tasa de Crecimiento - tci
              VHPVSI = this.valorVHPVSI(ctt_id, tcl_id, System.Convert.ToInt64(rs.Fields["ani_id"].Value), System.Convert.ToInt64(rs.Fields["mes_id"].Value), "VHPVSI");
              if (VHPVSI == 0)
              {
                tci[i] = 0;
                //notasas++;
                cont++;
              }
              else
              {
                tci[i] = (cv.Cav_valor) / VHPVSI;
                notasas++;
                cont++;
              }

              //
              if (mesf_id != cv.Mes_id || ani_idf != cv.Ani_id)
              {
                ultimoValor = cv.Cav_valor;
              }
              else
              {
                ultimoValor = cv.Cav_valor;
                // Hallar la tasa de crecimiento media aritmética - tcma
                for (int v = 1; v <= cont; v++)
                {
                  tcma = tcma + tci[v];
                }
                tcma = tcma / notasas;
              }
              i++;

              Session objSession2 = new Session();
              objSession2.PI = ultimoValor;
              break;

            case 3:
              tcma = 0;
              ultimoValor = 0;
              Session objSession3 = new Session();
              objSession3.PI = ultimoValor;

              break;


            default:
              break;


          }


          rs.MoveNext();
        }
        Connection_Off(1);

        return tcma;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return pi;
      }

    }
    /* Method valorVariableProyectada */



    public decimal calcularProyeccion(decimal tcma)
    {
      decimal pi = 0;
      decimal ultimoValor = 0;

      Session objSession = new Session();
      ultimoValor = objSession.PI;
      // Procesar la proyección pi
      pi = ultimoValor * (1 + tcma);
      // Session
      Session objSession2 = new Session();
      objSession2.PI = pi;
      return pi;
    }



    // Proyección de Variables
    /// <summary>
    /// valorVariableProyectada Method
    /// </summary>
    public decimal valorVHPVSI(long ctt_id, long tcl_id, long anii_id, long mesi_id, string var_codigo)
    {

      List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
      List<Calculo_Variable> lstCvProcesar = new List<Calculo_Variable>();

      decimal VHPVSI = 0;
      try
      {
        Connection_On();
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
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
              "AND (tab_tipo_calculo.tcl_id = " + tcl_id + " OR tab_tipo_calculo.tcl_id = 3 ) " +
              "AND tab_calculo.ani_id = " + anii_id + " " +
              "AND tab_calculo.mes_id = " + mesi_id + " " +
              "AND tab_variable.var_codigo = '" + var_codigo + "' " +
              "AND tab_mercado.mer_estado = 1 " +
              "GROUP BY " +
              "tab_contrato.ctt_id,  " +
              "tab_contrato.ctt_nombre,  " +
              "tab_calculo.ani_id, " +
              "tab_calculo.mes_id, " +
              "tab_variable.var_orden, " +
              "tab_variable.var_codigo, " +
              "tab_variable.var_nombre, " +
              "tab_unidad_medida.umd_codigo, " +
              "tab_variable.var_total, " +
              "tab_variable.tcl_id " +
              "ORDER by tab_variable.var_orden, tab_calculo.ani_id, tab_calculo.mes_id ";
        rs2 = new ADODB.Recordset();
        // Execute the query specifying static sursor, batch optimistic locking
        rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs2.EOF)
        {
          VHPVSI = System.Convert.ToDecimal(rs2.Fields["valor"].Value); ;
          rs2.MoveNext();
        }
        Connection_Off(1);
        return VHPVSI;
      }
      catch (COMException err)
      {
        Connection_Off(1);
        Console.WriteLine("Error: " + err.Message);
        return VHPVSI;
      }

    }
    /* Method valorVariableProyectada */














    // Proyección de Variables
    /// <summary>
    /// listvariable Method
    /// </summary>
    public decimal valorVariableProyectadaBACK(long ctt_id, long tcl_id, long ani_id, string var_codigo, long var_id, long tpy_id, long mesi_id, long mesf_id, decimal val_valori)
    {
      decimal pi = 0;

      List<Calculo_Variable> lstCv = new List<Calculo_Variable>();
      try
      {
        Connection_On();



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
              "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
              "WHERE tab_calculo.ctt_id = " + ctt_id + " " +
              "AND (tab_tipo_calculo.tcl_id = " + tcl_id + " OR tab_tipo_calculo.tcl_id = 3 ) " +
              "AND tab_calculo.ani_id = " + ani_id + " " +
              "AND tab_calculo.mes_id BETWEEN " + mesi_id + " AND " + mesf_id + " " +
              "AND tab_mercado.mer_estado = 1 " +
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
              "ORDER by tab_variable.var_orden, tab_calculo.ani_id, tab_calculo.mes_id ";
        rs = new ADODB.Recordset();
        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {

          Calculo_Variable cv = new Calculo_Variable();
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

          switch (tpy_id)
          {
            case 1:
              // Sumas

              break;

            case 2:
              // Divisiones

              break;
          }


          rs.MoveNext();
        }
        Connection_Off(1);

        return pi;
      }
      catch (COMException err)
      {

        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return pi;
      }

    }
    /* Method listMenu */



    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariableTotal(long var_id)
    {
      String where = (var_id != 0 ? ("AND var_id=" + var_id + "") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "(CASE tab_variable.var_imprime WHEN 0 THEN 'No' WHEN 1 THEN 'Si' END) as var_imprime_text, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT vr.var_codigo FROM tab_variable vr WHERE vr.var_id = tab_variable.vard_id) AS vard_codigo, " +
                "(SELECT tab_mercado.mer_codigo FROM tab_mercado WHERE tab_mercado.mer_id = tab_variable.mer_id) as mercado, " +
                "(SELECT tab_producto.pro_codigo FROM tab_producto WHERE tab_producto.pro_id = tab_variable.pro_id) as producto, " +
                "(SELECT tab_tipo_proyeccion.tpy_nombre FROM tab_tipo_proyeccion WHERE tab_tipo_proyeccion.tpy_id = tab_variable.tpy_id) as tipoproyeccion, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
                where +
                " AND var_total = 'T' AND var_total = 'S'" +
                " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_imprime = System.Convert.ToInt64(rs.Fields["var_imprime"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          variable.Mercado = System.Convert.ToString(rs.Fields["mercado"].Value);
          variable.Producto = System.Convert.ToString(rs.Fields["producto"].Value);
          variable.Var_imprime_text = System.Convert.ToString(rs.Fields["var_imprime_text"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Tpy_nombre = System.Convert.ToString(rs.Fields["tipoproyeccion"].Value);
          variable.Vard_codigo = System.Convert.ToString(rs.Fields["vard_codigo"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */


    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariableTotales(long var_id)
    {
      String where = (var_id != 0 ? ("AND var_id=" + var_id + "") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "(CASE tab_variable.var_imprime WHEN 0 THEN 'No' WHEN 1 THEN 'Si' END) as var_imprime_text, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT vr.var_codigo FROM tab_variable vr WHERE vr.var_id = tab_variable.vard_id) AS vard_codigo, " +
                "(SELECT tab_mercado.mer_codigo FROM tab_mercado WHERE tab_mercado.mer_id = tab_variable.mer_id) as mercado, " +
                "(SELECT tab_producto.pro_codigo FROM tab_producto WHERE tab_producto.pro_id = tab_variable.pro_id) as producto, " +
                "(SELECT tab_tipo_proyeccion.tpy_nombre FROM tab_tipo_proyeccion WHERE tab_tipo_proyeccion.tpy_id = tab_variable.tpy_id) as tipoproyeccion, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
                where +
                " AND var_total = 'T' " +
                "and tab_variable.cam_id = 1 " +
                "and (tab_variable.tcl_id = 1 or tab_variable.tcl_id = 3) " +
                "and tab_variable.var_imprime = 1 "+
                " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_imprime = System.Convert.ToInt64(rs.Fields["var_imprime"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          variable.Mercado = System.Convert.ToString(rs.Fields["mercado"].Value);
          variable.Producto = System.Convert.ToString(rs.Fields["producto"].Value);
          variable.Var_imprime_text = System.Convert.ToString(rs.Fields["var_imprime_text"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Tpy_nombre = System.Convert.ToString(rs.Fields["tipoproyeccion"].Value);
          variable.Vard_codigo = System.Convert.ToString(rs.Fields["vard_codigo"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */


    /// <summary>
    /// listvariable Method
    /// </summary>
    public List<Variable> listVariableByTcl(long tcl_id)
    {
      String where = (tcl_id != 0 ? ("AND (tab_variable.tcl_id=" + tcl_id + " or tab_variable.tcl_id = 3)") : "");
      List<Variable> lstVariable = new List<Variable>();
      try
      {
        Connection_On();
        SQL = "SELECT " +
                "tab_variable.var_id, " +
                "tab_variable.var_orden, " +
                "tab_variable.var_tipo, " +
                "tab_variable.var_codigo, " +
                "tab_variable.var_nombre, " +
                "tab_variable.var_valini, " +
                "tab_variable.var_estado, " +
                "tab_variable.var_orden, " +
                "tab_variable.umd_id, " +
                "tab_variable.tcl_id, " +
                "tab_variable.var_impresion, " +
                "tab_variable.var_imprime, " +
                "(CASE tab_variable.var_imprime WHEN 0 THEN 'No' WHEN 1 THEN 'Si' END) as var_imprime_text, " +
                "tab_unidad_medida.umd_codigo, " +
                "tab_tipo_calculo.tcl_codigo, " +
                "tab_variable.var_descripcion, " +
                "tab_variable.tpy_id, " +
                "tab_variable.mer_id, " +
                "tab_variable.pro_id, " +
                "tab_variable.var_codigod, " +
                "tab_variable.var_total, " +
                "tab_variable.vard_id, " +
                "(SELECT vr.var_codigo FROM tab_variable vr WHERE vr.var_id = tab_variable.vard_id) AS vard_codigo, " +
                "(SELECT tab_mercado.mer_codigo FROM tab_mercado WHERE tab_mercado.mer_id = tab_variable.mer_id) as mercado, " +
                "(SELECT tab_producto.pro_codigo FROM tab_producto WHERE tab_producto.pro_id = tab_variable.pro_id) as producto, " +
                "(SELECT tab_tipo_proyeccion.tpy_nombre FROM tab_tipo_proyeccion WHERE tab_tipo_proyeccion.tpy_id = tab_variable.tpy_id) as tipoproyeccion, " +
                "(SELECT tab_formula.for_codigo FROM tab_formula WHERE tab_formula.var_id = tab_variable.var_id) as formula " +
                "FROM " +
                "tab_variable " +
                "INNER JOIN tab_unidad_medida ON tab_unidad_medida.umd_id = tab_variable.umd_id " +
                "INNER JOIN tab_tipo_calculo ON tab_tipo_calculo.tcl_id = tab_variable.tcl_id " +
                "INNER JOIN tab_mercado on tab_mercado.mer_id = tab_variable.mer_id " +
                "WHERE tab_variable.var_estado = 1 and tab_mercado.mer_estado = 1 " +
                where +
                " AND var_total = 'T' " +
                " and tab_variable.cam_id = 1 " +
                " ORDER BY var_orden";

        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        while (!rs.EOF)
        {
          Variable variable = new Variable();
          variable.Var_id = System.Convert.ToInt64(rs.Fields["var_id"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Var_tipo = System.Convert.ToString(rs.Fields["var_tipo"].Value);
          variable.Var_codigo = System.Convert.ToString(rs.Fields["var_codigo"].Value);
          variable.Var_nombre = System.Convert.ToString(rs.Fields["var_nombre"].Value);
          variable.Var_valini = System.Convert.ToDecimal(rs.Fields["var_valini"].Value);
          variable.Var_estado = System.Convert.ToInt64(rs.Fields["var_estado"].Value);
          variable.Var_orden = System.Convert.ToInt64(rs.Fields["var_orden"].Value);
          variable.Umd_id = System.Convert.ToInt64(rs.Fields["umd_id"].Value);
          variable.Tcl_id = System.Convert.ToInt64(rs.Fields["tcl_id"].Value);
          variable.Var_impresion = System.Convert.ToInt64(rs.Fields["var_impresion"].Value);
          variable.Var_imprime = System.Convert.ToInt64(rs.Fields["var_imprime"].Value);
          variable.Var_descripcion = System.Convert.ToString(rs.Fields["var_descripcion"].Value);
          variable.Tpy_id = System.Convert.ToInt64(rs.Fields["tpy_id"].Value);
          variable.Mer_id = System.Convert.ToInt64(rs.Fields["mer_id"].Value);
          variable.Pro_id = System.Convert.ToInt64(rs.Fields["pro_id"].Value);
          variable.Var_codigod = System.Convert.ToString(rs.Fields["var_codigod"].Value);
          variable.Var_total = System.Convert.ToString(rs.Fields["var_total"].Value);
          variable.Vard_id = System.Convert.ToInt64(rs.Fields["vard_id"].Value);
          // Others
          variable.Formula = System.Convert.ToString(rs.Fields["formula"].Value);
          variable.Mercado = System.Convert.ToString(rs.Fields["mercado"].Value);
          variable.Producto = System.Convert.ToString(rs.Fields["producto"].Value);
          variable.Var_imprime_text = System.Convert.ToString(rs.Fields["var_imprime_text"].Value);
          variable.Umd_codigo = System.Convert.ToString(rs.Fields["umd_codigo"].Value);
          variable.Tcl_codigo = System.Convert.ToString(rs.Fields["tcl_codigo"].Value);
          variable.Tpy_nombre = System.Convert.ToString(rs.Fields["tipoproyeccion"].Value);
          variable.Vard_codigo = System.Convert.ToString(rs.Fields["vard_codigo"].Value);
          lstVariable.Add(variable);
          rs.MoveNext();
        }
        Connection_Off(1);
        return lstVariable;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }
    }/* Method listMenu */











    //
    // Method generarVariableGeneric
    //
    public bool generarVariableGeneric()
    {

      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      long i = 0;
      long var_id = 0;
      long cam_id = 0;
      int var_cam = 0;
      String var_tipo = "";
      long pro_id = 0;

      // Formulas
      String for_codigo = "";
      int for_tipo = 0;
      long for_id = 0;
      String for_nombre = "";

      // 
      long inserted = 0;
      long insertedf = 0;
      int contador = 0;

      // 
      bool flag = false;

      // Selección de variables maestras
      VariableObject objVariableObject = new VariableObject();
      List<Variable> lstVariable = new List<Variable>();

      VariableController objVariableController = new VariableController();

      lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 ");
      if (lstVariable.Count != 0)
      {
        //label1.Text = "Procesando ...";
        // Recorrer las variables maestras
        lstVariable.ForEach(delegate(Variable v)
        {
          vm = v.Var_codigo;
          var_cam = v.Var_cam;
          var_tipo = v.Var_tipo;
          var_id = v.Var_id;
          cam_id = v.Cam_id;




          // ****************************************
          // SI LA VARIABLE TIENE RECORRIDO POR CAMPO
          // ****************************************
          if (cam_id != 0)
          {
            // ****************************************
            // GENERAR COMBINACIONES VARIABLE CAMPO
            // ****************************************
            // Seleccionar campos
            CampoObject objCampoObject = new CampoObject();
            List<Campo> lstCampo = new List<Campo>();
            lstCampo = objCampoObject.listCampoPorCondicion("");
            if (lstCampo.Count != 0)
            {
              String var = "";
              // Recorrer CAMPOS
              lstCampo.ForEach(delegate(Campo c)
              {
                i++;
                // Generar variable 
                // Variable Maestra = Variable Maestra + Codigo Campo
                cam = c.Cam_codigo;
                var = vm + cam;

                // INSERTAR VARIABLE A LA BASE DE DATOS
                //textBox1.Text = textBox1.Text + var;
                Console.WriteLine("{1} Variable {0}", var, i);

                // INSERTAR VARIABLE A LA BASE DE DATOS  
                List<Variable> lstVariable3 = new List<Variable>();
                Variable variable3 = new Variable();
                variable3.Var_id = System.Convert.ToInt64(0);
                variable3.Var_codigo = System.Convert.ToString(var);
                variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
                variable3.Var_tipo = System.Convert.ToString(var_tipo);
                variable3.Var_valini = System.Convert.ToDecimal(0);
                variable3.Var_estado = System.Convert.ToInt64(1);
                variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
                variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
                variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                variable3.Mer_id = System.Convert.ToInt64(v.Mer_id);
                variable3.Pro_id = System.Convert.ToInt64(v.Pro_id);
                variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
                variable3.Var_total = System.Convert.ToString(v.Var_total);
                variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
                variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
                variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
                variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                variable3.Cam_id = Convert.ToInt64(v.Cam_id);
                variable3.Var_m = Convert.ToInt32(0);
                lstVariable3.Add(variable3);
                // Save data from Variable                  
                inserted = objVariableController.save(lstVariable3);
                if (inserted == 0)
                {
                  //MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  Console.WriteLine("Hubo error en el registro: Combinaciones Variable Campo");
                  flag = false;
                }


                // Limpiar variable
                var = "";
              }); // Fin recorrer campos
            }

          }




          // **********************************************
          // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
          // **********************************************
          // 1er. Nivel
          // Selección de productos
          ProductoObject objProductoObject = new ProductoObject();
          List<Producto> lstProducto = new List<Producto>();
          lstProducto = objProductoObject.listProductoPorCondicion("");
          if (lstProducto.Count != 0)
          {
            // Recorrer PRODUCTOS
            lstProducto.ForEach(delegate(Producto p)
            {
              i++;
              // Generar variable
              // Variable Maestra = Variable Maestra + Codigo Producto
              pro_id = p.Pro_id;
              prd = p.Pro_codigo;
              vmp = vm + prd;

              // Insertar variable tab_variable
              //textBox1.Text = textBox1.Text + vmp;
              Console.WriteLine("{1} Variable {0}", vmp, i);

              // INSERTAR VARIABLE A LA BASE DE DATOS              
              List<Variable> lstVariable1 = new List<Variable>();
              Variable variable1 = new Variable();
              variable1.Var_id = System.Convert.ToInt64(0);
              variable1.Var_codigo = System.Convert.ToString(vmp);
              variable1.Var_nombre = System.Convert.ToString(v.Var_nombre);
              variable1.Var_tipo = System.Convert.ToString(var_tipo);
              variable1.Var_valini = System.Convert.ToDecimal(0);
              variable1.Var_estado = System.Convert.ToInt64(1);
              variable1.Var_orden = System.Convert.ToInt64(v.Var_orden);
              variable1.Umd_id = System.Convert.ToInt64(v.Umd_id);
              variable1.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
              variable1.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
              variable1.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
              variable1.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
              variable1.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
              variable1.Mer_id = System.Convert.ToInt64(v.Mer_id);
              variable1.Pro_id = System.Convert.ToInt64(v.Pro_id);
              variable1.Var_codigod = System.Convert.ToString(v.Var_codigod);
              variable1.Var_total = System.Convert.ToString(v.Var_total);
              variable1.Vard_id = System.Convert.ToInt64(v.Vard_id);
              variable1.Var_posicion = Convert.ToInt64(v.Var_posicion);
              variable1.Var_impresion = Convert.ToInt64(v.Var_impresion);
              variable1.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
              variable1.Cam_id = Convert.ToInt64(v.Cam_id);
              variable1.Var_m = Convert.ToInt32(0);
              lstVariable1.Add(variable1);
              // Save data from Variable
              inserted = objVariableController.save(lstVariable1);
              if (inserted == 0)
              {
                //MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine("Hubo error en el registro: Combinaciones Variable Producto");
                flag = false;
              }

              // ANTES AQUI LA GENERACIÓN DE FORMULAS
              // 2do Nivel
              // Seleccionar mercados
              MercadoObject objMercadoObject = new MercadoObject();
              List<Mercado> lstMercado = new List<Mercado>();
              lstMercado = objMercadoObject.listMercadoPorCondicion("");
              if (lstMercado.Count != 0)
              {
                // Recorrer MERCADOS
                lstMercado.ForEach(delegate(Mercado m)
                {
                  i++;
                  // Generar variable 
                  // Variable Maestra = Variable Maestra + Codigo Mercado
                  mer = m.Mer_codigo;
                  vmpm = vm + prd + mer;
                  // Mostrar variable en la consola
                  //textBox1.Text = textBox1.Text + vmpm;
                  Console.WriteLine("{1} Variable {0}", vmpm, i);

                  // INSERTAR VARIABLE A LA BASE DE DATOS  
                  List<Variable> lstVariable2 = new List<Variable>();
                  Variable variable2 = new Variable();
                  variable2.Var_id = System.Convert.ToInt64(0);
                  variable2.Var_codigo = System.Convert.ToString(vmpm);
                  variable2.Var_nombre = System.Convert.ToString(v.Var_nombre);
                  variable2.Var_tipo = System.Convert.ToString(var_tipo);
                  variable2.Var_valini = System.Convert.ToDecimal(0);
                  variable2.Var_estado = System.Convert.ToInt64(1);
                  variable2.Var_orden = System.Convert.ToInt64(v.Var_orden);
                  variable2.Umd_id = System.Convert.ToInt64(v.Umd_id);
                  variable2.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                  variable2.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                  variable2.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                  variable2.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                  variable2.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                  variable2.Mer_id = System.Convert.ToInt64(v.Mer_id);
                  variable2.Pro_id = System.Convert.ToInt64(v.Pro_id);
                  variable2.Var_codigod = System.Convert.ToString(v.Var_codigod);
                  variable2.Var_total = System.Convert.ToString(v.Var_total);
                  variable2.Vard_id = System.Convert.ToInt64(v.Vard_id);
                  variable2.Var_posicion = Convert.ToInt64(v.Var_posicion);
                  variable2.Var_impresion = Convert.ToInt64(v.Var_impresion);
                  variable2.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                  variable2.Cam_id = Convert.ToInt64(v.Cam_id);
                  variable2.Var_m = Convert.ToInt32(0);
                  lstVariable2.Add(variable2);
                  // Save data from Variable                  
                  inserted = objVariableController.save(lstVariable2);
                  if (inserted == 0)
                  {
                    //MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Console.WriteLine("Hubo error en el registro: Combinaciones Variable Producto Mercado");
                    flag = false;
                  }


                  // Verificar si se va a recorrer campos
                  if (var_cam == 1)
                  {
                    // 3er. Nivel
                    // Seleccionar campos
                    CampoObject objCampoObject = new CampoObject();
                    List<Campo> lstCampo = new List<Campo>();
                    lstCampo = objCampoObject.listCampoPorCondicion("");
                    if (lstCampo.Count != 0)
                    {
                      String var = "";
                      // Recorrer CAMPOS
                      lstCampo.ForEach(delegate(Campo c)
                      {
                        i++;
                        // Generar variable 
                        // Variable Maestra = Variable Maestra + Codigo Campo
                        cam = c.Cam_codigo;
                        var = vm + prd + mer + cam;

                        // INSERTAR VARIABLE A LA BASE DE DATOS
                        //textBox1.Text = textBox1.Text + var;
                        Console.WriteLine("{1} Variable {0}", var, i);

                        // INSERTAR VARIABLE A LA BASE DE DATOS  
                        List<Variable> lstVariable3 = new List<Variable>();
                        Variable variable3 = new Variable();
                        variable3.Var_id = System.Convert.ToInt64(0);
                        variable3.Var_codigo = System.Convert.ToString(var);
                        variable3.Var_nombre = System.Convert.ToString(v.Var_nombre);
                        variable3.Var_tipo = System.Convert.ToString(var_tipo);
                        variable3.Var_valini = System.Convert.ToDecimal(0);
                        variable3.Var_estado = System.Convert.ToInt64(1);
                        variable3.Var_orden = System.Convert.ToInt64(v.Var_orden);
                        variable3.Umd_id = System.Convert.ToInt64(v.Umd_id);
                        variable3.Tcl_id = System.Convert.ToInt64(v.Tcl_id);
                        variable3.Var_impresion_a = System.Convert.ToInt64(v.Var_impresion_a);
                        variable3.Var_imprime = System.Convert.ToInt64(v.Var_imprime);
                        variable3.Var_descripcion = System.Convert.ToString(v.Var_descripcion);
                        variable3.Tpy_id = System.Convert.ToInt64(v.Tpy_id);
                        variable3.Mer_id = System.Convert.ToInt64(v.Mer_id);
                        variable3.Pro_id = System.Convert.ToInt64(v.Pro_id);
                        variable3.Var_codigod = System.Convert.ToString(v.Var_codigod);
                        variable3.Var_total = System.Convert.ToString(v.Var_total);
                        variable3.Vard_id = System.Convert.ToInt64(v.Vard_id);
                        variable3.Var_posicion = Convert.ToInt64(v.Var_posicion);
                        variable3.Var_impresion = Convert.ToInt64(v.Var_impresion);
                        variable3.Var_tipo_cal = Convert.ToInt64(v.Var_tipo_cal);
                        variable3.Cam_id = Convert.ToInt64(v.Cam_id);
                        variable3.Var_m = Convert.ToInt32(0);
                        lstVariable3.Add(variable3);
                        // Save data from Variable                  
                        inserted = objVariableController.save(lstVariable3);
                        if (inserted == 0)
                        {
                          //MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          Console.WriteLine("Hubo error en el registro: Combinaciones Variable Producto Mercado Campo");
                          flag = false;
                        }


                        // Limpiar variable
                        var = "";
                      }); // Fin recorrer campos
                    }
                  } // Fin verificar campos

                }); // Fin recorrer mercados
              }

            }); // Fin recorrer productos

          }



          // *********************************
          // GENERAR FORMULAS PARA LA VARIABLE
          // *********************************
          if (var_tipo.Equals("S"))
          {
            // Buscar formula
            FormulaObject objFormulaObject = new FormulaObject();
            List<Formula> lstformula = new List<Formula>();
            lstformula = objFormulaObject.listFormulaPorVariableId(var_id);
            if (lstformula.Count != 0)
            {
              lstformula.ForEach(delegate(Formula f)
              {
                for_id = f.For_id;
                var_id = f.Var_id;
                for_codigo = f.For_codigo;
                for_tipo = f.For_tipo;
                for_nombre = f.For_nombre;
                for_tipo = f.For_tipo;
              });
            }



            List<Variable> lstVariableFinal = new List<Variable>();
            VariableObject objVariableObject1 = new VariableObject();
            char[] delimiter = { ' ', '\t' };


            //MessageBox.Show(var_id + " FORMULA: " + for_codigo, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            string[] tokens = for_codigo.Split(delimiter);

            // GENERAR FORMULA EN BASE A TOKENS
            foreach (string token in tokens)
            {
              Console.WriteLine("VARIABLE DE FORMULA {0}", token);
              //textBox1.Text = textBox1.Text + "VARIABLE DE FORMULA" + token;
              lstVariableFinal = objVariableObject1.generarFormulaGeneric(lstVariableFinal, pro_id, token, contador);
              if (lstVariableFinal.Count != 0)
              {
                contador = lstVariableFinal.Count;
              }
            }

            // Guardar formula
            if (lstVariableFinal.Count != 0)
            {
              lstVariableFinal.ForEach(delegate(Variable vf)
              {
                // INSERTAR FÓRMULAS A LA BASE DE DATOS
                List<Formula> lstFormula = new List<Formula>();
                Formula Formula = new Formula();
                Formula.For_id = System.Convert.ToInt64(0);
                Formula.Var_id = System.Convert.ToInt64(inserted);
                Formula.For_codigo = System.Convert.ToString(vf.Var_codigo);
                Formula.For_nombre = System.Convert.ToString(for_nombre);
                Formula.For_valini = System.Convert.ToDecimal(0);
                Formula.For_estado = System.Convert.ToInt64(0);
                Formula.For_tipo = System.Convert.ToInt32(for_tipo);
                lstFormula.Add(Formula);

                // Save data from Formula
                FormulaController objFormulaController = new FormulaController();
                insertedf = objFormulaController.save(lstFormula);
                if (insertedf == 0)
                {
                  //MessageBox.Show("Hubo error en el registro", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  Console.WriteLine("Hubo error en el registro: Generación de Formula");
                  flag = false;
                }
              });
            }
          }

        }); // Fin recorrer variables maestras

      }

      Console.WriteLine("FIN");
      return true;
    }





    public String sumaProducto(string token)
    {
      int i = 0;
      String prd = "";
      String vmp = "";
      // **********************************************
      // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
      // **********************************************
      // 1er. Nivel
      // Selección de productos
      ProductoObject objProductoObject = new ProductoObject();
      List<Producto> lstProducto = new List<Producto>();
      lstProducto = objProductoObject.listProductoPorCondicion("");
      if (lstProducto.Count != 0)
      {
        vmp = "";
        // Recorrer PRODUCTOS
        lstProducto.ForEach(delegate(Producto p)
        {
          // Generar variable
          // Variable Maestra = Variable Maestra + Codigo Producto
          prd = p.Pro_codigo;
          vmp = vmp + token + prd + "+";
        }); // Fin recorrer productos

      }
      vmp = vmp.Substring(0, vmp.Length - 1);
      return vmp;
    }

    public String sumaProductoMercado(string token, long pro_id)
    {
      int i = 0;
      String prd = "";
      String mer = "";
      String vmpm = "";

      // **********************************************
      // GENERAR COMBINACIONES DE VARIABLES LA VARIABLE
      // **********************************************
      // 1er. Nivel
      // Selección de productos
      ProductoObject objProductoObject = new ProductoObject();
      List<Producto> lstProducto = new List<Producto>();
      lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
      if (lstProducto.Count != 0)
      {
        // Recorrer PRODUCTOS
        lstProducto.ForEach(delegate(Producto p)
        {
          // Generar variable
          // Variable Maestra = Variable Maestra + Codigo Producto
          prd = p.Pro_codigo;

          // 2do Nivel
          // Seleccionar mercados
          MercadoObject objMercadoObject = new MercadoObject();
          List<Mercado> lstMercado = new List<Mercado>();
          lstMercado = objMercadoObject.listMercadoPorCondicion("");
          if (lstMercado.Count != 0)
          {
            // Recorrer MERCADOS
            lstMercado.ForEach(delegate(Mercado m)
            {
              // Generar variable 
              // Variable Maestra = Variable Maestra + Codigo Mercado
              mer = m.Mer_codigo;
              vmpm = vmpm + token + prd + mer + "+";
            }); // Fin recorrer mercados
          }

        }); // Fin recorrer productos

      }
      vmpm = vmpm.Substring(0, vmpm.Length - 1);
      return vmpm;
    }





    //
    // Method generarFormulaGeneric
    //
    public List<Variable> generarFormulaGeneric(List<Variable> lstVariableFinal, long pro_id, string token, int contador)
    {
      // Variable maestra
      String prd = "";
      String vmp = "";
      int i = 0;




      List<Variable> lstVariable = new List<Variable>();
      try
      {
        // Concatenar vars1 operador vars2
        if (lstVariableFinal.Count != 0)
        {
          for (int k = 0; k < lstVariableFinal.Count; k++)
          {




            // NUEVO VALOR
            // Selección de variables maestras
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
            if (lstVariable.Count != 0)
            {
              // Validar variables duplicadas
              if (lstVariable.Count > 1)
              {
                Console.WriteLine("ERROR EXISTEN CÓDIGOS DE VARIABLES DUPLICADAS: {0}", token);
                return null;
              }


              Variable variable = new Variable();
              // Recorrer variables maestras
              // 1er. Nivel
              // Selección de productos
              ProductoObject objProductoObject = new ProductoObject();
              List<Producto> lstProducto = new List<Producto>();
              lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
              if (lstProducto.Count != 0)
              {

                // RECORRER PRODUCTOS
                lstProducto.ForEach(delegate(Producto p)
                {
                  i++;
                  // Generar variable
                  // Variable Maestra = Variable Maestra + Codigo Producto
                  prd = p.Pro_codigo;
                  vmp = token + prd;

                  // Insertar variable tab_variable
                  Console.WriteLine("{1} Variable {0}", vmp, i);
                  lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmp;
                  Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                }); // Fin recorrer productos
              }




            }
            else
            {

              Console.WriteLine("================================", token);
              Console.WriteLine("ES OPERADOR, FUNCIÓN O AGRUPADOR", token);
              Console.WriteLine("================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              if (lstVariableFinal.Count != 0)
              {
                // Buscar variables
                lstVariableFinal.ForEach(delegate(Variable v)
                {
                  v.Var_codigo = v.Var_codigo + token;
                  Console.WriteLine("FORMULA {0}", v.Var_codigo);
                });
                // Forzar salir
                k = lstVariableFinal.Count;
              }




            }
          }
        }
        else
        {
          // LISTA NUEVA
          // Selección de variables maestras
          VariableObject objVariableObject = new VariableObject();
          lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
          if (lstVariable.Count != 0)
          {

            Console.WriteLine("===========", token);
            Console.WriteLine("LISTA NUEVA", token);
            Console.WriteLine("===========", token);
            // Buscar variables
              Variable variable = new Variable();
              // Recorrer variables maestras
              // 1er. Nivel
              // Selección de productos
              ProductoObject objProductoObject = new ProductoObject();
              List<Producto> lstProducto = new List<Producto>();
              lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
              if (lstProducto.Count != 0)
              {

                // Save Sesion
                lstProducto.ForEach(delegate(Producto p)
                {
                  i++;
                  // Recorrer productos
                  // Generar variable
                  // Variable Maestra = Variable Maestra + Codigo Producto
                  prd = p.Pro_codigo;
                  vmp = token + prd;

                  // Insertar variable tab_variable
                  Console.WriteLine("{1} Variable {0}", vmp, i);

                  Variable variable2 = new Variable();
                  variable2.Var_codigo = System.Convert.ToString(vmp);
                  lstVariableFinal.Add(variable2);

                }); // Fin recorrer productos
              }

          }
          else
          {
            // ES OPERADOR O AGRUPADOR O FUNCION
            if (lstVariableFinal.Count == 0)
            {
              Console.WriteLine("====================================", token);
              Console.WriteLine("FORMULA CON INICIO DE FUNCION U OTRO", token);
              Console.WriteLine("====================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              for (int l = 0; l < contador; l++)
              {
                Variable variable3 = new Variable();
                variable3.Var_codigo = System.Convert.ToString(token);
                lstVariableFinal.Add(variable3);
                Console.WriteLine("FORMULA {0}", token);
              }




            }
          }
        }

        Console.WriteLine("FIN INTERMEDIO");
        return lstVariableFinal;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }

    }













    //
    // Method generarFormulaGeneric
    //
    public List<Variable> generarFormulaProductoMercadoGeneric(List<Variable> lstVariableFinal, long pro_id, long mer_id, string token, int contador)
    {
      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      int i = 0;
      long var_id = 0;
      int var_cam = 0;
      String var_tipo = "";



      List<Variable> lstVariable = new List<Variable>();
      try
      {
        // Concatenar vars1 operador vars2
        if (lstVariableFinal.Count != 0)
        {
          for (int k = 0; k < lstVariableFinal.Count; k++)
          {




            // NUEVO VALOR
            // Selección de variables maestras
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
            if (lstVariable.Count != 0)
            {
              // Validar variables duplicadas
              if (lstVariable.Count > 1)
              {
                Console.WriteLine("ERROR EXISTEN CÓDIGOS DE VARIABLES DUPLICADAS: {0}", token);
                return null;
              }



              Console.WriteLine("================================", token);
              Console.WriteLine("GENERACIÓN REGULAR DE VARIABLES", token);
              Console.WriteLine("================================", token);
              // LISTA CON VALORES
              lstVariable.ForEach(delegate(Variable v)
              {
                vm = v.Var_codigo;
                var_cam = v.Var_cam;
                var_tipo = v.Var_tipo;
                var_id = v.Var_id;


                Variable variable = new Variable();
                // Recorrer variables maestras
                // 1er. Nivel
                // Selección de productos
                ProductoObject objProductoObject = new ProductoObject();
                List<Producto> lstProducto = new List<Producto>();
                lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
                if (lstProducto.Count != 0)
                {

                  // RECORRER PRODUCTOS
                  lstProducto.ForEach(delegate(Producto p)
                  {
                    i++;
                    // Generar variable
                    // Variable Maestra = Variable Maestra + Codigo Producto
                    prd = p.Pro_codigo;
                    vmp = vm + prd;

                    //// Insertar variable tab_variable
                    //Console.WriteLine("{1} Variable {0}", vmp, i);
                    //lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmp;
                    //Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                    // 2do Nivel
                    // Seleccionar mercados
                    MercadoObject objMercadoObject = new MercadoObject();
                    List<Mercado> lstMercado = new List<Mercado>();
                    lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                    if (lstMercado.Count != 0)
                    {
                      // RECORRER MERCADOS
                      lstMercado.ForEach(delegate(Mercado m)
                      {
                        i++;
                        // Generar variable 
                        // Variable Maestra = Variable Maestra + Codigo Mercado
                        mer = m.Mer_codigo;
                        vmpm = vm + prd + mer;
                        // Insertar variable tab_variable
                        Console.WriteLine("{1} Variable {0}", vmpm, i);

                        //k++;
                        lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmpm;
                        Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                        //Variable variable3 = new Variable();
                        //variable3.Var_codigo = System.Convert.ToString(vmpm);
                        //lstVariableFinal.Add(variable3);

                        if (var_cam == 1)
                        {
                          // 3er. Nivel
                          // Seleccionar campos
                          CampoObject objCampoObject = new CampoObject();
                          List<Campo> lstCampo = new List<Campo>();
                          lstCampo = objCampoObject.listCampoPorCondicion("");
                          if (lstCampo.Count != 0)
                          {
                            String var = "";

                            // RECORRER CAMPOS
                            lstCampo.ForEach(delegate(Campo c)
                            {
                              i = k;
                              // Generar variable 
                              // Variable Maestra = Variable Maestra + Codigo Campo
                              cam = c.Cam_codigo;
                              var = vm + prd + mer + cam;
                              // Insertar variable tab_variable
                              Console.WriteLine("{1} Variable {0}", var, i);
                              i++;
                              lstVariableFinal[i].Var_codigo = lstVariableFinal[i].Var_codigo + var;
                              Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[i].Var_codigo, i);
                              //Variable variable4 = new Variable();
                              //variable4.Var_codigo = System.Convert.ToString(var);
                              //lstVariableFinal.Add(variable4);

                              // Limpiar variable
                              var = "";
                            }); // Fin recorrer campos
                          }
                        }


                      }); // Fin recorrer mercados
                      // FORZAR RECORRER LA LISTA
                      k++;
                    }
                  }); // Fin recorrer productos
                }
              }); // Fin recorrer variables maestras



            }
            else
            {

              Console.WriteLine("================================", token);
              Console.WriteLine("ES OPERADOR, FUNCIÓN O AGRUPADOR", token);
              Console.WriteLine("================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              if (lstVariableFinal.Count != 0)
              {
                // Buscar variables
                lstVariableFinal.ForEach(delegate(Variable v)
                {
                  v.Var_codigo = v.Var_codigo + token;
                  Console.WriteLine("FORMULA {0}", v.Var_codigo);
                });
                // Forzar salir
                k = lstVariableFinal.Count;
              }




            }
          }
        }
        else
        {
          // LISTA NUEVA
          // Selección de variables maestras
          VariableObject objVariableObject = new VariableObject();
          lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
          if (lstVariable.Count != 0)
          {
            Console.WriteLine("===========", token);
            Console.WriteLine("LISTA NUEVA", token);
            Console.WriteLine("===========", token);
            // Buscar variables
            lstVariable.ForEach(delegate(Variable v)
            {
              vm = v.Var_codigo;
              var_cam = v.Var_cam;
              var_tipo = v.Var_tipo;
              var_id = v.Var_id;


              Variable variable = new Variable();
              // Recorrer variables maestras
              // 1er. Nivel
              // Selección de productos
              ProductoObject objProductoObject = new ProductoObject();
              List<Producto> lstProducto = new List<Producto>();
              lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
              if (lstProducto.Count != 0)
              {

                // Save Sesion
                lstProducto.ForEach(delegate(Producto p)
                {
                  i++;
                  // Recorrer productos
                  // Generar variable
                  // Variable Maestra = Variable Maestra + Codigo Producto
                  prd = p.Pro_codigo;
                  vmp = vm + prd;

                  // Insertar variable tab_variable
                  Console.WriteLine("{1} Variable {0}", vmp, i);

                  //Variable variable2 = new Variable();
                  //variable2.Var_codigo = System.Convert.ToString(vmp);
                  //lstVariableFinal.Add(variable2);

                  // 2do Nivel
                  // Seleccionar mercados
                  MercadoObject objMercadoObject = new MercadoObject();
                  List<Mercado> lstMercado = new List<Mercado>();
                  lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                  if (lstMercado.Count != 0)
                  {
                    // Save Sesion
                    lstMercado.ForEach(delegate(Mercado m)
                    {
                      i++;
                      // Recorrer mercados
                      // Generar variable 
                      // Variable Maestra = Variable Maestra + Codigo Mercado
                      mer = m.Mer_codigo;
                      vmpm = vm + prd + mer;
                      // Insertar variable tab_variable
                      Console.WriteLine("{1} Variable {0}", vmpm, i);

                      Variable variable3 = new Variable();
                      variable3.Var_codigo = System.Convert.ToString(vmpm);
                      lstVariableFinal.Add(variable3);

                      if (var_cam == 1)
                      {
                        // 3er. Nivel
                        // Seleccionar campos
                        CampoObject objCampoObject = new CampoObject();
                        List<Campo> lstCampo = new List<Campo>();
                        lstCampo = objCampoObject.listCampoPorCondicion("");
                        if (lstCampo.Count != 0)
                        {
                          String var = "";
                          // Save Sesion
                          lstCampo.ForEach(delegate(Campo c)
                          {
                            i++;
                            // Recorrer campos
                            // Generar variable 
                            // Variable Maestra = Variable Maestra + Codigo Campo
                            cam = c.Cam_codigo;
                            var = vm + prd + mer + cam;
                            // Insertar variable tab_variable
                            Console.WriteLine("{1} Variable {0}", var, i);

                            Variable variable4 = new Variable();
                            variable4.Var_codigo = System.Convert.ToString(var);
                            lstVariableFinal.Add(variable4);

                            // Limpiar variable
                            var = "";
                          }); // Fin recorrer campos
                        }
                      }


                    }); // Fin recorrer mercados
                  }
                }); // Fin recorrer productos
              }
            }); // Fin recorrer variables maestras
          }
          else
          {
            // ES OPERADOR O AGRUPADOR O FUNCION
            if (lstVariableFinal.Count == 0)
            {
              Console.WriteLine("====================================", token);
              Console.WriteLine("FORMULA CON INICIO DE FUNCION U OTRO", token);
              Console.WriteLine("====================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              for (int l = 0; l < contador; l++)
              {
                Variable variable3 = new Variable();
                variable3.Var_codigo = System.Convert.ToString(token);
                lstVariableFinal.Add(variable3);
                Console.WriteLine("FORMULA {0}", token);
              }




            }
          }
        }

        Console.WriteLine("FIN INTERMEDIO");
        return lstVariableFinal;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }

    }

















    //
    // Method generarFormulaGeneric
    //
    public List<Variable> generarFormulaProductoMercadoCampoGeneric(List<Variable> lstVariableFinal, long pro_id, long mer_id, long cam_id, string token, int contador)
    {
      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      int i = 0;
      long var_id = 0;
      int var_cam = 0;
      String var_tipo = "";



      List<Variable> lstVariable = new List<Variable>();
      try
      {
        // Concatenar vars1 operador vars2
        if (lstVariableFinal.Count != 0)
        {
          for (int k = 0; k < lstVariableFinal.Count; k++)
          {
            // NUEVO VALOR
            // Selección de variables maestras
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
            if (lstVariable.Count != 0)
            {
              // Validar variables duplicadas
              if (lstVariable.Count > 1)
              {
                Console.WriteLine("ERROR EXISTEN CÓDIGOS DE VARIABLES DUPLICADAS: {0}", token);
                return null;
              }



              Console.WriteLine("================================", token);
              Console.WriteLine("GENERACIÓN REGULAR DE VARIABLES", token);
              Console.WriteLine("================================", token);
              // LISTA CON VALORES
              lstVariable.ForEach(delegate(Variable v)
              {
                vm = v.Var_codigo;
                var_cam = v.Var_cam;
                var_tipo = v.Var_tipo;
                var_id = v.Var_id;


                Variable variable = new Variable();
                // Recorrer variables maestras
                // 1er. Nivel
                // Selección de productos
                ProductoObject objProductoObject = new ProductoObject();
                List<Producto> lstProducto = new List<Producto>();
                lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
                if (lstProducto.Count != 0)
                {

                  // RECORRER PRODUCTOS
                  lstProducto.ForEach(delegate(Producto p)
                  {
                    i++;
                    // Generar variable
                    // Variable Maestra = Variable Maestra + Codigo Producto
                    prd = p.Pro_codigo;
                    vmp = vm + prd;

                    //// Insertar variable tab_variable
                    //Console.WriteLine("{1} Variable {0}", vmp, i);
                    //lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmp;
                    //Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                    // 2do Nivel
                    // Seleccionar mercados
                    MercadoObject objMercadoObject = new MercadoObject();
                    List<Mercado> lstMercado = new List<Mercado>();
                    lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                    if (lstMercado.Count != 0)
                    {
                      // RECORRER MERCADOS
                      lstMercado.ForEach(delegate(Mercado m)
                      {
                        i++;
                        // Generar variable 
                        // Variable Maestra = Variable Maestra + Codigo Mercado
                        mer = m.Mer_codigo;
                        vmpm = vm + prd + mer;
                        // Insertar variable tab_variable
                        Console.WriteLine("{1} Variable {0}", vmpm, i);

                        //k++;
                        lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmpm;
                        Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                        //Variable variable3 = new Variable();
                        //variable3.Var_codigo = System.Convert.ToString(vmpm);
                        //lstVariableFinal.Add(variable3);

                        // 3er. Nivel
                        // Seleccionar campos
                        CampoObject objCampoObject = new CampoObject();
                        List<Campo> lstCampo = new List<Campo>();
                        lstCampo = objCampoObject.listCampoPorCondicion(" AND cam_id = " + cam_id);
                        if (lstCampo.Count != 0)
                        {
                          String var = "";

                          // RECORRER CAMPOS
                          lstCampo.ForEach(delegate(Campo c)
                          {
                            i = k;
                            // Generar variable 
                            // Variable Maestra = Variable Maestra + Codigo Campo
                            cam = c.Cam_codigo;
                            //var = vm + prd + mer + cam;
                            // Insertar variable tab_variable
                            Console.WriteLine("{1} Variable {0}", var, i);
                            lstVariableFinal[i].Var_codigo = lstVariableFinal[i].Var_codigo + cam;
                            Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[i].Var_codigo, i);
                            //Variable variable4 = new Variable();
                            //variable4.Var_codigo = System.Convert.ToString(var);
                            //lstVariableFinal.Add(variable4);

                            // Limpiar variable
                            var = "";
                          }); // Fin recorrer campos
                        }
                      }); // Fin recorrer mercados
                      // FORZAR RECORRER LA LISTA
                      k++;
                    }
                  }); // Fin recorrer productos
                }
              }); // Fin recorrer variables maestras



            }
            else
            {

              Console.WriteLine("================================", token);
              Console.WriteLine("ES OPERADOR, FUNCIÓN O AGRUPADOR", token);
              Console.WriteLine("================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              if (lstVariableFinal.Count != 0)
              {
                // Buscar variables
                lstVariableFinal.ForEach(delegate(Variable v)
                {
                  v.Var_codigo = v.Var_codigo + token;
                  Console.WriteLine("FORMULA {0}", v.Var_codigo);
                });
                // Forzar salir
                k = lstVariableFinal.Count;
              }




            }
          }
        }
        else
        {
          // LISTA NUEVA
          // Selección de variables maestras
          VariableObject objVariableObject = new VariableObject();
          lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
          if (lstVariable.Count != 0)
          {
            Console.WriteLine("===========", token);
            Console.WriteLine("LISTA NUEVA", token);
            Console.WriteLine("===========", token);
            // Buscar variables
            lstVariable.ForEach(delegate(Variable v)
            {
              vm = v.Var_codigo;
              var_cam = v.Var_cam;
              var_tipo = v.Var_tipo;
              var_id = v.Var_id;


              Variable variable = new Variable();
              // Recorrer variables maestras
              // 1er. Nivel
              // Selección de productos
              ProductoObject objProductoObject = new ProductoObject();
              List<Producto> lstProducto = new List<Producto>();
              lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
              if (lstProducto.Count != 0)
              {

                // Save Sesion
                lstProducto.ForEach(delegate(Producto p)
                {
                  i++;
                  // Recorrer productos
                  // Generar variable
                  // Variable Maestra = Variable Maestra + Codigo Producto
                  prd = p.Pro_codigo;
                  vmp = vm + prd;

                  // Insertar variable tab_variable
                  Console.WriteLine("{1} Variable {0}", vmp, i);

                  //Variable variable2 = new Variable();
                  //variable2.Var_codigo = System.Convert.ToString(vmp);
                  //lstVariableFinal.Add(variable2);

                  // 2do Nivel
                  // Seleccionar mercados
                  MercadoObject objMercadoObject = new MercadoObject();
                  List<Mercado> lstMercado = new List<Mercado>();
                  lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                  if (lstMercado.Count != 0)
                  {
                    // Save Sesion
                    lstMercado.ForEach(delegate(Mercado m)
                    {
                      i++;
                      // Recorrer mercados
                      // Generar variable 
                      // Variable Maestra = Variable Maestra + Codigo Mercado
                      mer = m.Mer_codigo;
                      vmpm = vm + prd + mer;
                      // Insertar variable tab_variable
                      Console.WriteLine("{1} Variable {0}", vmpm, i);

                      Variable variable3 = new Variable();
                      variable3.Var_codigo = System.Convert.ToString(vmpm);
                      lstVariableFinal.Add(variable3);

                      //if (var_cam == 1)
                      //{
                        // 3er. Nivel
                        // Seleccionar campos
                        CampoObject objCampoObject = new CampoObject();
                        List<Campo> lstCampo = new List<Campo>();
                        lstCampo = objCampoObject.listCampoPorCondicion("");
                        if (lstCampo.Count != 0)
                        {
                          String var = "";
                          // Save Sesion
                          lstCampo.ForEach(delegate(Campo c)
                          {
                            i++;
                            // Recorrer campos
                            // Generar variable 
                            // Variable Maestra = Variable Maestra + Codigo Campo
                            cam = c.Cam_codigo;
                            var = vm + prd + mer + cam;
                            // Insertar variable tab_variable
                            Console.WriteLine("{1} Variable {0}", var, i);

                            Variable variable4 = new Variable();
                            variable4.Var_codigo = System.Convert.ToString(var);
                            lstVariableFinal.Add(variable4);

                            // Limpiar variable
                            var = "";
                          }); // Fin recorrer campos
                        }
                      //}


                    }); // Fin recorrer mercados
                  }
                }); // Fin recorrer productos
              }
            }); // Fin recorrer variables maestras
          }
          else
          {
            // ES OPERADOR O AGRUPADOR O FUNCION
            if (lstVariableFinal.Count == 0)
            {
              Console.WriteLine("====================================", token);
              Console.WriteLine("FORMULA CON INICIO DE FUNCION U OTRO", token);
              Console.WriteLine("====================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              for (int l = 0; l < contador; l++)
              {
                Variable variable3 = new Variable();
                variable3.Var_codigo = System.Convert.ToString(token);
                lstVariableFinal.Add(variable3);
                Console.WriteLine("FORMULA {0}", token);
              }




            }
          }
        }

        Console.WriteLine("FIN INTERMEDIO");
        return lstVariableFinal;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }

    }















    // Nuevo
    //
    // Method generarFormulaGeneric
    //
    public List<Variable> generarFormulaProductoMercadoCampoPersonalizado(List<Variable> lstVariableFinal, long pro_id, long mer_id, long cam_id, string token, int contador)
    {
      // Variable maestra
      String vm = "";
      String prd = "";
      String mer = "";
      String cam = "";
      String vmp = "";
      String vmpm = "";
      int i = 0;
      long var_id = 0;
      int var_cam = 0;
      String var_tipo = "";
      int pro_mer = 0;
      int pro_mer2 = 0;


      List<Variable> lstVariable = new List<Variable>();
      try
      {
        // Concatenar vars1 operador vars2
        if (lstVariableFinal.Count != 0)
        {
          for (int k = 0; k < lstVariableFinal.Count; k++)
          {
            // NUEVO VALOR
            // Selección de variables maestras
            VariableObject objVariableObject = new VariableObject();
            lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
            if (lstVariable.Count != 0)
            {
              // Validar variables duplicadas
              if (lstVariable.Count > 1)
              {
                Console.WriteLine("ERROR EXISTEN CÓDIGOS DE VARIABLES DUPLICADAS: {0}", token);
                return null;
              }



              Console.WriteLine("================================", token);
              Console.WriteLine("GENERACIÓN REGULAR DE VARIABLES", token);
              Console.WriteLine("================================", token);
              // LISTA CON VALORES
              lstVariable.ForEach(delegate(Variable v)
              {
                vm = v.Var_codigo;
                var_cam = v.Var_cam;
                var_tipo = v.Var_tipo;
                var_id = v.Var_id;


                Variable variable = new Variable();
                // Recorrer variables maestras
                // 1er. Nivel
                // Selección de productos
                ProductoObject objProductoObject = new ProductoObject();
                List<Producto> lstProducto = new List<Producto>();
                lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
                if (lstProducto.Count != 0)
                {

                  // RECORRER PRODUCTOS
                  lstProducto.ForEach(delegate(Producto p)
                  {
                    i++;
                    // Generar variable
                    // Variable Maestra = Variable Maestra + Codigo Producto
                    prd = p.Pro_codigo;
                    vmp = vm + prd;
                    pro_mer = p.Pro_mer;

                    //// Insertar variable tab_variable
                    //Console.WriteLine("{1} Variable {0}", vmp, i);
                    //lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmp;
                    //Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);


                    // 2do Nivel
                    // Seleccionar mercados
                    MercadoObject objMercadoObject = new MercadoObject();
                    List<Mercado> lstMercado = new List<Mercado>();
                    lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                    if (lstMercado.Count != 0)
                    {
                      // RECORRER MERCADOS
                      lstMercado.ForEach(delegate(Mercado m)
                      {

                        i++;
                        // Generar variable 
                        // Variable Maestra = Variable Maestra + Codigo Mercado
                        mer = m.Mer_codigo;
                        vmpm = vm + prd + mer;
                        pro_mer2 = m.Pro_mer;

                        //  CONDICION 
                        if (pro_mer == 1)
                        {
                          // TODOS LOS MERCADOS
                          // Insertar variable tab_variable
                          Console.WriteLine("{1} Variable {0}", vmpm, i);

                          //k++;
                          lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmpm;
                          Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                          //Variable variable3 = new Variable();
                          //variable3.Var_codigo = System.Convert.ToString(vmpm);
                          //lstVariableFinal.Add(variable3);

                          // 3er. Nivel
                          // Seleccionar campos
                          CampoObject objCampoObject = new CampoObject();
                          List<Campo> lstCampo = new List<Campo>();
                          lstCampo = objCampoObject.listCampoPorCondicion(" AND cam_id = " + cam_id);
                          if (lstCampo.Count != 0)
                          {
                            String var = "";

                            // RECORRER CAMPOS
                            lstCampo.ForEach(delegate(Campo c)
                            {
                              i = k;
                              // Generar variable 
                              // Variable Maestra = Variable Maestra + Codigo Campo
                              cam = c.Cam_codigo;
                              //var = vm + prd + mer + cam;
                              // Insertar variable tab_variable
                              Console.WriteLine("{1} Variable {0}", var, i);
                              lstVariableFinal[i].Var_codigo = lstVariableFinal[i].Var_codigo + cam;
                              Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[i].Var_codigo, i);
                              //Variable variable4 = new Variable();
                              //variable4.Var_codigo = System.Convert.ToString(var);
                              //lstVariableFinal.Add(variable4);

                              // Limpiar variable
                              var = "";
                            }); // Fin recorrer campos
                          } 
                         
                        }
                        else
                        {
                          // MERCADOS ESCOGIDOS
                          if (pro_mer2 == 2)
                          {
                            // Insertar variable tab_variable
                            Console.WriteLine("{1} Variable {0}", vmpm, i);

                            //k++;
                            lstVariableFinal[k].Var_codigo = lstVariableFinal[k].Var_codigo + vmpm;
                            Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[k].Var_codigo, i);

                            //Variable variable3 = new Variable();
                            //variable3.Var_codigo = System.Convert.ToString(vmpm);
                            //lstVariableFinal.Add(variable3);

                            // 3er. Nivel
                            // Seleccionar campos
                            CampoObject objCampoObject = new CampoObject();
                            List<Campo> lstCampo = new List<Campo>();
                            lstCampo = objCampoObject.listCampoPorCondicion(" AND cam_id = " + cam_id);
                            if (lstCampo.Count != 0)
                            {
                              String var = "";

                              // RECORRER CAMPOS
                              lstCampo.ForEach(delegate(Campo c)
                              {
                                i = k;
                                // Generar variable 
                                // Variable Maestra = Variable Maestra + Codigo Campo
                                cam = c.Cam_codigo;
                                //var = vm + prd + mer + cam;
                                // Insertar variable tab_variable
                                Console.WriteLine("{1} Variable {0}", var, i);
                                lstVariableFinal[i].Var_codigo = lstVariableFinal[i].Var_codigo + cam;
                                Console.WriteLine("{1} FORMULA {0}", lstVariableFinal[i].Var_codigo, i);
                                //Variable variable4 = new Variable();
                                //variable4.Var_codigo = System.Convert.ToString(var);
                                //lstVariableFinal.Add(variable4);

                                // Limpiar variable
                                var = "";
                              }); // Fin recorrer campos
                            }

                          }

                        }

                      }); // Fin recorrer mercados
                      // FORZAR RECORRER LA LISTA
                      k++;
                    }
                  }); // Fin recorrer productos
                }
              }); // Fin recorrer variables maestras



            }
            else
            {

              Console.WriteLine("================================", token);
              Console.WriteLine("ES OPERADOR, FUNCIÓN O AGRUPADOR", token);
              Console.WriteLine("================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              if (lstVariableFinal.Count != 0)
              {
                // Buscar variables
                lstVariableFinal.ForEach(delegate(Variable v)
                {
                  v.Var_codigo = v.Var_codigo + token;
                  Console.WriteLine("FORMULA {0}", v.Var_codigo);
                });
                // Forzar salir
                k = lstVariableFinal.Count;
              }




            }
          }
        }
        else
        {
          // LISTA NUEVA
          // Selección de variables maestras
          VariableObject objVariableObject = new VariableObject();
          lstVariable = objVariableObject.listVariablePorCondicion(" AND var_m = 1 AND var_codigo = '" + token + "'");
          if (lstVariable.Count != 0)
          {
            Console.WriteLine("===========", token);
            Console.WriteLine("LISTA NUEVA", token);
            Console.WriteLine("===========", token);
            // Buscar variables
            lstVariable.ForEach(delegate(Variable v)
            {
              vm = v.Var_codigo;
              var_cam = v.Var_cam;
              var_tipo = v.Var_tipo;
              var_id = v.Var_id;


              Variable variable = new Variable();
              // Recorrer variables maestras
              // 1er. Nivel
              // Selección de productos
              ProductoObject objProductoObject = new ProductoObject();
              List<Producto> lstProducto = new List<Producto>();
              lstProducto = objProductoObject.listProductoPorCondicion(" AND pro_id=" + pro_id);
              if (lstProducto.Count != 0)
              {

                // Save Sesion
                lstProducto.ForEach(delegate(Producto p)
                {
                  i++;
                  // Recorrer productos
                  // Generar variable
                  // Variable Maestra = Variable Maestra + Codigo Producto
                  prd = p.Pro_codigo;
                  vmp = vm + prd;

                  // Insertar variable tab_variable
                  Console.WriteLine("{1} Variable {0}", vmp, i);

                  //Variable variable2 = new Variable();
                  //variable2.Var_codigo = System.Convert.ToString(vmp);
                  //lstVariableFinal.Add(variable2);

                  // 2do Nivel
                  // Seleccionar mercados
                  MercadoObject objMercadoObject = new MercadoObject();
                  List<Mercado> lstMercado = new List<Mercado>();
                  lstMercado = objMercadoObject.listMercadoPorCondicion(" AND mer_id =" + mer_id);
                  if (lstMercado.Count != 0)
                  {
                    // Save Sesion
                    lstMercado.ForEach(delegate(Mercado m)
                    {
                      i++;
                      // Recorrer mercados
                      // Generar variable 
                      // Variable Maestra = Variable Maestra + Codigo Mercado
                      mer = m.Mer_codigo;
                      vmpm = vm + prd + mer;
                      // Insertar variable tab_variable
                      Console.WriteLine("{1} Variable {0}", vmpm, i);

                      Variable variable3 = new Variable();
                      variable3.Var_codigo = System.Convert.ToString(vmpm);
                      lstVariableFinal.Add(variable3);

                      //if (var_cam == 1)
                      //{
                      // 3er. Nivel
                      // Seleccionar campos
                      CampoObject objCampoObject = new CampoObject();
                      List<Campo> lstCampo = new List<Campo>();
                      lstCampo = objCampoObject.listCampoPorCondicion("");
                      if (lstCampo.Count != 0)
                      {
                        String var = "";
                        // Save Sesion
                        lstCampo.ForEach(delegate(Campo c)
                        {
                          i++;
                          // Recorrer campos
                          // Generar variable 
                          // Variable Maestra = Variable Maestra + Codigo Campo
                          cam = c.Cam_codigo;
                          var = vm + prd + mer + cam;
                          // Insertar variable tab_variable
                          Console.WriteLine("{1} Variable {0}", var, i);

                          Variable variable4 = new Variable();
                          variable4.Var_codigo = System.Convert.ToString(var);
                          lstVariableFinal.Add(variable4);

                          // Limpiar variable
                          var = "";
                        }); // Fin recorrer campos
                      }
                      //}


                    }); // Fin recorrer mercados
                  }
                }); // Fin recorrer productos
              }
            }); // Fin recorrer variables maestras
          }
          else
          {
            // ES OPERADOR O AGRUPADOR O FUNCION
            if (lstVariableFinal.Count == 0)
            {
              Console.WriteLine("====================================", token);
              Console.WriteLine("FORMULA CON INICIO DE FUNCION U OTRO", token);
              Console.WriteLine("====================================", token);

              // ES OPERADOR O AGRUPADOR O FUNCION
              for (int l = 0; l < contador; l++)
              {
                Variable variable3 = new Variable();
                variable3.Var_codigo = System.Convert.ToString(token);
                lstVariableFinal.Add(variable3);
                Console.WriteLine("FORMULA {0}", token);
              }




            }
          }
        }

        Console.WriteLine("FIN INTERMEDIO");
        return lstVariableFinal;
      }
      catch (COMException err)
      {
        Console.WriteLine("Error: " + err.Message);
        Connection_Off(1);
        return lstVariable;
      }

    }








  }
}
