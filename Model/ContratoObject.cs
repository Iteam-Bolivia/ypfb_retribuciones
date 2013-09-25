using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ypfbApplication.Controller;

namespace Model
{
    public class ContratoObject : Contrato
    {
        /// <summary>
        /// Verifica si existe un contrato por contrato Id
        /// </summary>
        /// <param name="ctt_id">contrato id</param>
        /// <returns>True si existe el contrato, false si no existe.</returns>
        public bool existContrato(long ctt_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id FROM tab_contrato WHERE ctt_id='" + ctt_id + "'";

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
                return flag;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }/* Method existContrato */

        /// <summary>
        /// listContrato Method
        /// </summary>
        public List<Contrato> listContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id=" + ctt_id + "") : "");
            List<Contrato> lstContrato = new List<Contrato>();
            long usu_id = 0;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, " +
                          "suc_id, " +
                          "ctt_codigo, " +
                          "ctt_nombre, " +
                          "ctt_periodo, " +
                          "ctt_fecini, " +
                          "ctt_fecfin, " +
                          "ctt_estado, " +
                          "usu_id, " +
                          "ctt_depacu, " +
                          "ctt_depacuma, " +
                          "ctt_acugantit, " +
                          "ctt_invacu, " +
                          "ctt_invacuma, " +
                          "ctt_acuimptit, " +
                          "ctt_lrc, " +
                          "ctt_vhiena, " +
                          "ctt_cmp, " +
                          "ctt_icpmp, " +
                          "ctt_pppvgnpf, " +
                          "ctt_pppvhlpf, " +
                          "ctt_invneta, " +
                          "ctt_produccion, " +
                          "ctt_costrecuacu, " +
                          "ctt_orden " +
                          "FROM tab_contrato " +
                          "WHERE ctt_estado = 1 " +
                          //" AND tab_contrato.usu_id = " + usu_id + " " +
                          where +
                          " order by ctt_nombre";


                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato contrato = new Contrato();

                    contrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contrato.Suc_id = Convert.ToInt64(rs.Fields["suc_id"].Value);
                    contrato.Ctt_codigo = Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    contrato.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    contrato.Ctt_periodo = Convert.ToString(rs.Fields["ctt_periodo"].Value);
                    contrato.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                    {
                        contrato.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    }
                    contrato.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    contrato.Ctt_estado = Convert.ToInt32(rs.Fields["ctt_estado"].Value);
                    contrato.Usu_id = Convert.ToInt32(rs.Fields["usu_id"].Value);
                    contrato.Ctt_depacu = Convert.ToDecimal(rs.Fields["ctt_depacu"].Value);
                    contrato.Ctt_depacuma = Convert.ToDecimal(rs.Fields["ctt_depacuma"].Value);
                    contrato.Ctt_acugantit = Convert.ToDecimal(rs.Fields["ctt_acugantit"].Value);
                    contrato.Ctt_invacu = Convert.ToDecimal(rs.Fields["ctt_invacu"].Value);
                    contrato.Ctt_invacuma = Convert.ToDecimal(rs.Fields["ctt_invacuma"].Value);
                    contrato.Ctt_acuimptit = Convert.ToDecimal(rs.Fields["ctt_acuimptit"].Value);
                    contrato.Ctt_invneta = Convert.ToDecimal(rs.Fields["ctt_invneta"].Value);

                    contrato.Ctt_lrc = Convert.ToDecimal(rs.Fields["ctt_lrc"].Value);
                    contrato.Ctt_vhiena = Convert.ToDecimal(rs.Fields["ctt_vhiena"].Value);
                    contrato.Ctt_cmp = Convert.ToInt64(rs.Fields["ctt_cmp"].Value);
                    contrato.Ctt_icpmp = Convert.ToDecimal(rs.Fields["ctt_icpmp"].Value);
                    contrato.Ctt_pppvgnpf = Convert.ToDecimal(rs.Fields["ctt_pppvgnpf"].Value);
                    contrato.Ctt_pppvhlpf = Convert.ToDecimal(rs.Fields["ctt_pppvhlpf"].Value);
                    contrato.Ctt_produccion = Convert.ToInt64(rs.Fields["ctt_produccion"].Value);
                    contrato.Ctt_costrecuacu = Convert.ToDecimal(rs.Fields["ctt_costrecuacu"].Value);
                    contrato.Ctt_orden = Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    lstContrato.Add(contrato);
                    rs.MoveNext();

                }
                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }
        /// <summary>
        /// Recupera contratos por sucursal
        /// </summary>
        /// <param name="suc_id"></param>
        /// <returns>Lista de Contratos</returns>
        public List<Contrato> listContratoPorSucursal(long suc_id)
        {
            List<Contrato> lstContrato = null;
            String where = (suc_id != 0 ? ("AND A.suc_id = " + suc_id + "") : "");
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, A.suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin, ctt_estado, ctt_orden, '' AS tit_asociados, '' AS cam_asociados, A.usu_id, (B.usu_nombres || ' ' || b.usu_apellidos) AS nombre_completo " +
                    "FROM tab_contrato AS A " +
                    "INNER JOIN tab_usuario AS B ON A.usu_id = B.usu_id " +
                    "WHERE ctt_estado = 1 " +
                    " AND usu_estado = 1 " +
                    where;
                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                lstContrato = new List<Contrato>();
                while (!rs.EOF)
                {

                    Contrato obj = new Contrato();
                    obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    obj.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
                    obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
                    obj.Ctt_periodo = (string)rs.Fields["ctt_periodo"].Value;
                    obj.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                    {
                        obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    }
                    //else
                    //{
                    //    object z_varocioDateTime = new DateTime();
                    //    z_varocioDateTime = null;
                    //    obj.Ctt_fecfin = (DateTime)z_varocioDateTime;
                    //}
                    //obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                    obj.Ctt_orden = System.Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    obj.Nombre_Completo = Convert.ToString(rs.Fields["nombre_completo"].Value);
                    List<Titular_Contrato> titularContrato = new List<Titular_Contrato>();
                    TitularContratoObject obj1 = new TitularContratoObject();

                    //titularContrato = obj1.listaTitularesPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    titularContrato = obj1.listaTitularesContratoNombrePorContrato(obj.Ctt_id);

                    foreach (Titular_Contrato item in titularContrato)
                    {
                        obj.Lista_Titulares += item.Tit_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Titulares))
                        obj.Lista_Titulares = obj.Lista_Titulares.Substring(0, obj.Lista_Titulares.Length - 2);

                    List<Contrato_Campo> campoContrato = new List<Contrato_Campo>();
                    ContratoCampoObject obj2 = new ContratoCampoObject();
                    campoContrato = obj2.listaCamposPorContrato(obj.Ctt_id);
                    foreach (Contrato_Campo item in campoContrato)
                    {
                        obj.Lista_Campos += item.Cam_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Campos))
                        obj.Lista_Campos = obj.Lista_Campos.Substring(0, obj.Lista_Campos.Length - 2);

                    List<Tabla_Calculo> tablaCalculo = new List<Tabla_Calculo>();
                    TablaCalculoObject obj3 = new TablaCalculoObject();
                    tablaCalculo = obj3.listaTablaCalculoNombrePorContrato(obj.Ctt_id);
                    foreach (Tabla_Calculo item in tablaCalculo)
                    {
                        obj.Lista_Tablas += item.Tab_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Tablas))
                        obj.Lista_Tablas = obj.Lista_Tablas.Substring(0, obj.Lista_Tablas.Length - 2);

                    lstContrato.Add(obj);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }
        /// <summary>
        /// Metodo utilizado para las busquedas
        /// </summary>
        /// <param name="suc_id"></param>
        /// <param name="ctt_codigo"></param>
        /// <param name="ctt_nombre"></param>
        /// <param name="ctt_periodo"></param>
        /// <param name="ctt_fecini"></param>
        /// <param name="ctt_fecfin"></param>
        /// <returns>Lista de Contratos segun criterio de busqueda</returns>
        public List<Contrato> listContratoSegunCriterio(long suc_id, string ctt_codigo, string ctt_nombre, string ctt_periodo, string ctt_fecini, string ctt_fecfin)
        {
            List<Contrato> lstContrato = new List<Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin, ctt_estado, ctt_orden, '' AS tit_asociados, '' AS cam_asociados " +
                    "FROM tab_contrato " +
                    "WHERE ctt_estado = 1 ";
                SQL += " AND suc_id" + (suc_id == 0 ? " <> " : " = ") + suc_id;
                SQL += " AND ctt_codigo" + (ctt_codigo == "" ? " <> '" : " like '%") + ctt_codigo + "%'";
                SQL += " AND ctt_nombre" + (ctt_nombre == "" ? " <> '" : " like '%") + ctt_nombre + "%'";
                SQL += " AND ctt_periodo" + (ctt_periodo == "" ? " <> '" : " = '") + ctt_periodo + "'";
                if (ctt_fecini != "")
                    SQL += " AND ctt_fecini >= '" + ctt_fecini + "'";
                if (ctt_fecfin != "")
                    SQL += " AND ctt_fecfin <= '" + ctt_fecfin + "'";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {

                    Contrato obj = new Contrato();
                    obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    obj.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
                    obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
                    obj.Ctt_periodo = (string)rs.Fields["ctt_periodo"].Value;
                    obj.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                        obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                    obj.Ctt_orden = System.Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    List<Titular_Contrato> titularContrato = new List<Titular_Contrato>();
                    TitularContratoObject obj1 = new TitularContratoObject();
                    //titularContrato = obj1.listaTitularesPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    titularContrato = obj1.listaTitularesContratoNombrePorContrato(obj.Ctt_id);

                    foreach (Titular_Contrato item in titularContrato)
                    {
                        obj.Lista_Titulares += item.Tit_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Titulares))
                        obj.Lista_Titulares = obj.Lista_Titulares.Substring(0, obj.Lista_Titulares.Length - 2);

                    List<Contrato_Campo> campoContrato = new List<Contrato_Campo>();
                    ContratoCampoObject obj2 = new ContratoCampoObject();
                    campoContrato = obj2.listaCamposPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    foreach (Contrato_Campo item in campoContrato)
                    {
                        obj.Lista_Campos += item.Cam_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Campos))
                        obj.Lista_Campos = obj.Lista_Campos.Substring(0, obj.Lista_Campos.Length - 2);

                    lstContrato.Add(obj);
                    rs.MoveNext();
                }

                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }

        public Contrato listContratoPorTit_idAndCam_Id(long tit_id, long cam_id)
        {
            List<Contrato> lstContrato = null;
            String where = (tit_id != 0 ? ("AND tit_id = " + tit_id + "") : "");
            string where2 = (cam_id != 0 ? (" AND cam_id = " + cam_id + "") : "");
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_contrato.ctt_codigo, " +
                        "tab_contrato.ctt_nombre, " +
                        "tab_contrato.ctt_id, " +
                        "tab_contrato.ctt_estado " +
                        "FROM " +
                        "tab_titular_contrato " +
                        "INNER JOIN tab_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
                        "INNER JOIN tab_contrato_campo ON tab_contrato_campo.ctt_id = tab_contrato.ctt_id " +
                          "WHERE ctt_estado = 1 " +
                          where + where2;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                lstContrato = new List<Contrato>();
                while (!rs.EOF)
                {

                    Contrato obj = new Contrato();
                    obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
                    obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
                    obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);

                    lstContrato.Add(obj);
                    rs.MoveNext();
                }
                Connection_Off(1);

            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
            }
            if (lstContrato.Count > 0)
                return lstContrato[0];
            else
                return lstContrato[0] = null;

        }

        //public Contrato listContratoPorTit_idAndCam_Id(long tit_id, long cam_id)
        //{
        //  List<Contrato> lstContrato = null;
        //  String where = (tit_id != 0 ? ("AND tit_id = " + tit_id + "") : "");
        //  string where2 = (cam_id != 0 ? (" AND cam_id = " + cam_id + "") : "");
        //  try
        //  {
        //    Connection_On();
        //    SQL = "SELECT " +
        //            "tab_contrato.ctt_codigo, " +
        //            "tab_contrato.ctt_nombre, " +
        //            "tab_contrato.ctt_id, " +
        //            "tab_contrato.ctt_estado " +
        //            "FROM " +
        //            "tab_titular_contrato " +
        //            "INNER JOIN tab_contrato ON tab_contrato.ctt_id = tab_titular_contrato.ctt_id " +
        //            "INNER JOIN tab_contrato_campo ON tab_contrato_campo.ctt_id = tab_contrato.ctt_id " +
        //              "WHERE ctt_estado = 1 " +
        //              where + where2;
        //    rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //    lstContrato = new List<Contrato>();
        //    while (!rs.EOF)
        //    {

        //      Contrato obj = new Contrato();
        //      obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
        //      obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
        //      obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
        //      obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);

        //      lstContrato.Add(obj);
        //      rs.MoveNext();
        //    }
        //    Connection_Off(1);

        //  }
        //  catch (COMException err)
        //  {
        //    Console.WriteLine("Error: " + err.Message);
        //    Connection_Off(1);
        //  }
        //  return lstContrato[0];
        //}



        public List<Contrato> listContratoPorSucursalUsuario(long suc_id, int usu_id)
        {
            List<Contrato> lstContrato = null;
            String where = (suc_id != 0 ? ("AND suc_id = " + suc_id + "") : "");
            where += (usu_id != 0 ? (" AND usu_id = " + usu_id + "") : "");
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin, ctt_estado, ctt_orden, '' AS tit_asociados, '' AS cam_asociados " +
                          "FROM tab_contrato " +
                          "WHERE ctt_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                lstContrato = new List<Contrato>();
                while (!rs.EOF)
                {
                    Contrato obj = new Contrato();
                    obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    obj.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
                    obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
                    obj.Ctt_periodo = (string)rs.Fields["ctt_periodo"].Value;
                    obj.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                    {
                        obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    }
                    //obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                    obj.Ctt_orden = System.Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    List<Titular_Contrato> titularContrato = new List<Titular_Contrato>();
                    TitularContratoObject obj1 = new TitularContratoObject();
                    titularContrato = obj1.listaTitularesContratoNombrePorContrato(obj.Ctt_id);

                    foreach (Titular_Contrato item in titularContrato)
                    {
                        obj.Lista_Titulares += item.Tit_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Titulares))
                        obj.Lista_Titulares = obj.Lista_Titulares.Substring(0, obj.Lista_Titulares.Length - 2);

                    List<Contrato_Campo> campoContrato = new List<Contrato_Campo>();
                    ContratoCampoObject obj2 = new ContratoCampoObject();
                    campoContrato = obj2.listaCamposPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    foreach (Contrato_Campo item in campoContrato)
                    {
                        obj.Lista_Campos += item.Cam_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Campos))
                        obj.Lista_Campos = obj.Lista_Campos.Substring(0, obj.Lista_Campos.Length - 2);


                    /**/
                    List<Tabla_Calculo> tablaCalculo = new List<Tabla_Calculo>();
                    TablaCalculoObject obj3 = new TablaCalculoObject();
                    tablaCalculo = obj3.listaTablaCalculoNombrePorContrato(obj.Ctt_id);
                    foreach (Tabla_Calculo item in tablaCalculo)
                    {
                        obj.Lista_Tablas += item.Tab_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Tablas))
                        obj.Lista_Tablas = obj.Lista_Tablas.Substring(0, obj.Lista_Tablas.Length - 2);
                    /**/


                    lstContrato.Add(obj);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }

        public List<Contrato> listContratoSegunCriterioUsuario(long suc_id, string ctt_codigo, string ctt_nombre, string ctt_periodo, string ctt_fecini, string ctt_fecfin, int usu_id)
        {
            List<Contrato> lstContrato = new List<Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, suc_id, ctt_codigo, ctt_nombre, ctt_periodo, ctt_fecini, ctt_fecfin, ctt_estado, ctt_orden, '' AS tit_asociados, '' AS cam_asociados " +
                    "FROM tab_contrato " +
                    "WHERE ctt_estado = 1 ";
                SQL += " AND suc_id" + (suc_id == 0 ? " <> " : " = ") + suc_id;
                SQL += " AND ctt_codigo" + (ctt_codigo == "" ? " <> '" : " like '%") + ctt_codigo + "%'";
                SQL += " AND ctt_nombre" + (ctt_nombre == "" ? " <> '" : " like '%") + ctt_nombre + "%'";
                SQL += " AND ctt_periodo" + (ctt_periodo == "" ? " <> '" : " = '") + ctt_periodo + "'";
                if (ctt_fecini != "")
                    SQL += " AND ctt_fecini >= '" + ctt_fecini + "'";
                if (ctt_fecfin != "")
                    SQL += " AND ctt_fecfin <= '" + ctt_fecfin + "'";

                SQL += " AND usu_id = " + usu_id;
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {

                    Contrato obj = new Contrato();
                    obj.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    obj.Suc_id = System.Convert.ToInt64(rs.Fields["suc_id"].Value);
                    obj.Ctt_codigo = (string)rs.Fields["ctt_codigo"].Value;
                    obj.Ctt_nombre = (string)rs.Fields["ctt_nombre"].Value;
                    obj.Ctt_periodo = (string)rs.Fields["ctt_periodo"].Value;
                    obj.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                    obj.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    obj.Ctt_estado = System.Convert.ToInt64(rs.Fields["ctt_estado"].Value);
                    obj.Ctt_orden = System.Convert.ToInt32(rs.Fields["ctt_orden"].Value);

                    List<Titular_Contrato> titularContrato = new List<Titular_Contrato>();
                    TitularContratoObject obj1 = new TitularContratoObject();
                    //titularContrato = obj1.listaTitularesPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    titularContrato = obj1.listaTitularesContratoNombrePorContrato(obj.Ctt_id);

                    foreach (Titular_Contrato item in titularContrato)
                    {
                        obj.Lista_Titulares += item.Tit_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Titulares))
                        obj.Lista_Titulares = obj.Lista_Titulares.Substring(0, obj.Lista_Titulares.Length - 2);

                    List<Contrato_Campo> campoContrato = new List<Contrato_Campo>();
                    ContratoCampoObject obj2 = new ContratoCampoObject();
                    campoContrato = obj2.listaCamposPorContrato(Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    foreach (Contrato_Campo item in campoContrato)
                    {
                        obj.Lista_Campos += item.Cam_nombre + ", ";
                    }
                    if (!string.IsNullOrEmpty(obj.Lista_Campos))
                        obj.Lista_Campos = obj.Lista_Campos.Substring(0, obj.Lista_Campos.Length - 2);

                    lstContrato.Add(obj);
                    rs.MoveNext();
                }

                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }




        /// <summary>
        /// listContrato Method for combobox
        /// </summary>
        public List<Contrato> listContratoCbo(long _tit_id)
        {
            String where = (_tit_id != 0 ? ("AND ti.tit_id=" + _tit_id + "") : "");

            List<Contrato> lstContrato = new List<Contrato>();

            try
            {
                Connection_On();
                SQL = "SELECT ct.ctt_id,ct.ctt_nombre " +
                          "FROM tab_contrato ct INNER JOIN " +
                          "tab_titular_contrato tc ON  ct.ctt_id = tc.ctt_id INNER JOIN " +
                          "tab_titular ti ON tc.tit_id = ti.tit_id " +
                          "WHERE ct.ctt_estado = 1 and tc.ttc_tipo = 'O'" +
                           where +
                           " order by ct.ctt_nombre ";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato contra = new Contrato();
                    contra.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contra.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);

                    // Fill data List
                    lstContrato.Add(contra);
                    rs.MoveNext();
                }

                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                return lstContrato;
            }
            finally
            {
                Connection_Off(1);
            }
        }/* Method listMenu */

        public Contrato ContratoPorCodigo(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id + "") : "");
            Contrato contrato = null;
            try
            {
                SQL = "SELECT ctt_id,suc_id,ctt_codigo,ctt_nombre,ctt_periodo,ctt_fecini,ctt_fecfin,ctt_estado,usu_id,ctt_depacu,ctt_depacuma,ctt_acugantit,ctt_invacu,ctt_invacuma,ctt_acuimptit,ctt_costrecuacu, ctt_orden ";
                SQL += "FROM tab_contrato ";
                SQL += "WHERE ctt_estado = 1 ";
                SQL += where;
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    contrato = new Contrato();
                    contrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contrato.Suc_id = Convert.ToInt64(rs.Fields["suc_id"].Value);
                    contrato.Ctt_codigo = Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    contrato.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    contrato.Ctt_periodo = Convert.ToString(rs.Fields["ctt_periodo"].Value);
                    contrato.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if(!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                        contrato.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    contrato.Ctt_estado = Convert.ToInt32(rs.Fields["ctt_estado"].Value);
                    contrato.Usu_id = Convert.ToInt32(rs.Fields["usu_id"].Value);
                    contrato.Ctt_depacu = Convert.ToDecimal(rs.Fields["ctt_depacu"].Value);
                    contrato.Ctt_depacuma = Convert.ToDecimal(rs.Fields["ctt_depacuma"].Value);
                    contrato.Ctt_acugantit = Convert.ToDecimal(rs.Fields["ctt_acugantit"].Value);
                    contrato.Ctt_invacu = Convert.ToDecimal(rs.Fields["ctt_invacu"].Value);
                    contrato.Ctt_invacuma = Convert.ToDecimal(rs.Fields["ctt_invacuma"].Value);
                    contrato.Ctt_acuimptit = Convert.ToDecimal(rs.Fields["ctt_acuimptit"].Value);
                    contrato.Ctt_costrecuacu = Convert.ToDecimal(rs.Fields["ctt_costrecuacu"].Value);
                    contrato.Ctt_orden = Convert.ToInt32(rs.Fields["ctt_orden"].Value);

                }
                return contrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return contrato;
            }
            finally
            {
                Connection_Off(1);
            }
        }


        public decimal buscarIndice(long ctt_id, decimal mpcdia, decimal indiceb, decimal preT)
        {
            decimal indice = 0;
            decimal indiceaux = 0;
            long tab_id = 0;
            int operadorLogico = 0;
            long tab_id1 = 0;
            long tablaaux = 0;
            long taf_id = 0;
            long taf_id_anterior = 0;
            decimal taf_valfila = 0;
            decimal taf_columna_anterior = 0;
            decimal tac_valcolumna = 0;
            var sw = 0;
            var sw1 = 0;
            var sw2 = 0;


            // Formatear a dos dígitos
            //indiceaux = System.Convert.ToDecimal(String.Format("{0:0,0.00}", System.Convert.ToDouble(indiceb)));
            //indiceb = indiceaux;

            tablaaux = 1;
            int n = 1;
            int m = 1;
            // Instanciar Objeto TablaCalculo
            List<Tabla_Calculo> lstTablaCalculo = new List<Tabla_Calculo>();
            lstTablaCalculo = TablaCalculoController.GetListaTablaCalculoPorContrato(ctt_id);
            if (lstTablaCalculo.Count > 0)
            {
                for (int i = 0; i < lstTablaCalculo.Count; i++)
                {
                    switch (lstTablaCalculo[i].Tca_oplogi)
                    {
                        case 1:
                            if (preT == lstTablaCalculo[0].Tca_precio)
                            {
                                tab_id1 = lstTablaCalculo[i].Tab_id;
                            }
                            break;
                        case 2:
                            if (preT > lstTablaCalculo[0].Tca_precio)
                            {
                                tab_id1 = lstTablaCalculo[i].Tab_id;
                            }
                            break;
                        case 3:
                            if (preT < lstTablaCalculo[0].Tca_precio)
                            {
                                tab_id1 = lstTablaCalculo[i].Tab_id;
                            }
                            break;
                        case 4:
                            if (preT >= lstTablaCalculo[0].Tca_precio)
                            {
                                tab_id1 = lstTablaCalculo[i].Tab_id;
                            }
                            break;
                        case 5:
                            if (preT <= lstTablaCalculo[0].Tca_precio)
                            {
                                tab_id1 = lstTablaCalculo[i].Tab_id;
                            }
                            break;
                    }
                }


                List<Tabla_Fila> lstTablaFila = new List<Tabla_Fila>();
                lstTablaFila = TablaFilaController.GetDatosTablaFilaValor(ctt_id, tab_id1);
                lstTablaFila.ForEach(delegate(Tabla_Fila tf)
                {
                    tab_id = tf.Tab_id;
                    List<Tabla_Columna> lstTablaColumna = new List<Tabla_Columna>();
                    lstTablaColumna = TablaColumnaController.GetDatosTablaColumnaValor(tf.Taf_id);

                    lstTablaColumna.ForEach(delegate(Tabla_Columna tc)
                    {
                        // Fila de valores
                        if (tf.Taf_valfila == 0)
                        {
                            if (tc.Tac_valor >= indiceb && sw == 0)
                            {
                                sw = 1;
                                if (tc.Tac_valor == indiceb)
                                {
                                    tac_valcolumna = tc.Tac_valcolumna;
                                }
                                else
                                {
                                    tac_valcolumna = taf_columna_anterior;
                                }
                            }
                            //Código nuevo
                            else
                            {
                                if (indiceb >= tc.Tac_valor && m == lstTablaColumna.Count)
                                {
                                    tac_valcolumna = tc.Tac_valcolumna;
                                }
                                m++;
                            }
                        }

                        // Columna de valores
                        if (tc.Tac_valcolumna == 0)
                        {
                            if (tc.Tac_valor >= mpcdia && sw1 == 0)
                            {
                                sw1 = 1;
                                if (tc.Tac_valor == mpcdia)
                                {
                                    taf_valfila = tf.Taf_valfila;
                                    taf_id = tf.Taf_id;
                                }
                                else
                                {
                                    taf_valfila = tf.Taf_valfila;
                                    taf_id = taf_id_anterior;
                                }
                                n++;
                            }
                            // Código nuevo
                            else
                            {
                                if (mpcdia >= tc.Tac_valor && n == lstTablaFila.Count)
                                {
                                    taf_valfila = tf.Taf_valfila;
                                    taf_id = tf.Taf_id;
                                }
                                n++;
                            }
                            //
                        }
                        taf_columna_anterior = tc.Tac_valcolumna;
                        taf_id_anterior = tf.Taf_id;
                    });
                });



                indice = 0;
                // Instanciar Objeto TablaCalculo
                List<Tabla_Columna> lstTablaColumna2 = new List<Tabla_Columna>();
                lstTablaColumna2 = TablaColumnaController.GetDatosTablaColumnaValor(taf_id);
                lstTablaColumna2.ForEach(delegate(Tabla_Columna tc2)
                {
                    if (tc2.Tac_valcolumna == tac_valcolumna && sw2 == 0)
                    {
                        indice = tc2.Tac_valor;
                        sw2 = 1;
                    }
                });
            }
            else
            {
                throw new Exception("No se tiene una tabla asociada al contrato para hallar el \"qbt\"");
            }
            return indice;
        }

        public List<Contrato> FindContratoByCtt_Name(string ctt_nombre)
        {
            String where = (ctt_nombre != "" ? ("AND ctt_nombre='" + ctt_nombre + "' ") : "");
            List<Contrato> lstContrato = new List<Contrato>();

            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, " +
                          "suc_id, " +
                          "ctt_codigo, " +
                          "ctt_nombre, " +
                          "ctt_periodo, " +
                          "ctt_fecini, " +
                          "ctt_fecfin, " +
                          "ctt_estado, " +
                          "usu_id, " +
                          "ctt_depacu, " +
                          "ctt_depacuma, " +
                          "ctt_acugantit, " +
                          "ctt_invacu, " +
                          "ctt_invacuma, " +
                          "ctt_acuimptit, " +
                          "ctt_lrc, " +
                          "ctt_vhiena, " +
                          "ctt_cmp, " +
                          "ctt_icpmp, " +
                          "ctt_pppvgnpf, " +
                          "ctt_pppvhlpf, " +
                          "ctt_costrecuacu, " +
                          "ctt_orden " +
                          "FROM tab_contrato, " +                          
                          "WHERE ctt_estado = 1 " +
                          where;


                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato contrato = new Contrato();

                    contrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contrato.Suc_id = Convert.ToInt64(rs.Fields["suc_id"].Value);
                    contrato.Ctt_codigo = Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    contrato.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    contrato.Ctt_periodo = Convert.ToString(rs.Fields["ctt_periodo"].Value);
                    contrato.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                        contrato.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    contrato.Ctt_estado = Convert.ToInt32(rs.Fields["ctt_estado"].Value);
                    contrato.Usu_id = Convert.ToInt32(rs.Fields["usu_id"].Value);
                    contrato.Ctt_depacu = Convert.ToDecimal(rs.Fields["ctt_depacu"].Value);
                    contrato.Ctt_depacuma = Convert.ToDecimal(rs.Fields["ctt_depacuma"].Value);
                    contrato.Ctt_acugantit = Convert.ToDecimal(rs.Fields["ctt_acugantit"].Value);
                    contrato.Ctt_invacu = Convert.ToDecimal(rs.Fields["ctt_invacu"].Value);
                    contrato.Ctt_invacuma = Convert.ToDecimal(rs.Fields["ctt_invacuma"].Value);
                    contrato.Ctt_acuimptit = Convert.ToDecimal(rs.Fields["ctt_acuimptit"].Value);

                    contrato.Ctt_lrc = Convert.ToDecimal(rs.Fields["ctt_lrc"].Value);
                    contrato.Ctt_vhiena = Convert.ToDecimal(rs.Fields["ctt_vhiena"].Value);
                    contrato.Ctt_cmp = Convert.ToInt64(rs.Fields["ctt_cmp"].Value);
                    contrato.Ctt_icpmp = Convert.ToDecimal(rs.Fields["ctt_icpmp"].Value);
                    contrato.Ctt_pppvgnpf = Convert.ToDecimal(rs.Fields["ctt_pppvgnpf"].Value);
                    contrato.Ctt_pppvhlpf = Convert.ToDecimal(rs.Fields["ctt_pppvhlpf"].Value);
                    contrato.Ctt_costrecuacu = Convert.ToDecimal(rs.Fields["ctt_costrecuacu"].Value);
                    contrato.Ctt_orden = Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    lstContrato.Add(contrato);
                    rs.MoveNext();

                }
                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }


        public List<Contrato> listContratoandUsu_id(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id=" + ctt_id + "") : "");
            List<Contrato> lstContrato = new List<Contrato>();
            long usu_id = 0;
            Session objSession = new Session();
            usu_id = objSession.USU_ID;
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id, " +
                          "suc_id, " +
                          "ctt_codigo, " +
                          "ctt_nombre, " +
                          "ctt_periodo, " +
                          "ctt_fecini, " +
                          "ctt_fecfin, " +
                          "ctt_estado, " +
                          "usu_id, " +
                          "ctt_depacu, " +
                          "ctt_depacuma, " +
                          "ctt_acugantit, " +
                          "ctt_invacu, " +
                          "ctt_invacuma, " +
                          "ctt_acuimptit, " +
                          "ctt_lrc, " +
                          "ctt_vhiena, " +
                          "ctt_cmp, " +
                          "ctt_icpmp, " +
                          "ctt_pppvgnpf, " +
                          "ctt_pppvhlpf, " +
                          "ctt_invneta, " +
                          "ctt_costrecuacu, " +
                          "ctt_orden " +
                          "FROM tab_contrato " +
                          "WHERE ctt_estado = 1 " +
                          " AND tab_contrato.usu_id = " + usu_id + " " +
                          where +
                          " order by ctt_nombre";


                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Contrato contrato = new Contrato();

                    contrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contrato.Suc_id = Convert.ToInt64(rs.Fields["suc_id"].Value);
                    contrato.Ctt_codigo = Convert.ToString(rs.Fields["ctt_codigo"].Value);
                    contrato.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    contrato.Ctt_periodo = Convert.ToString(rs.Fields["ctt_periodo"].Value);
                    contrato.Ctt_fecini = Convert.ToDateTime(rs.Fields["ctt_fecini"].Value);
                    if (!Convert.IsDBNull(rs.Fields["ctt_fecfin"].Value))
                        contrato.Ctt_fecfin = Convert.ToDateTime(rs.Fields["ctt_fecfin"].Value);
                    contrato.Ctt_estado = Convert.ToInt32(rs.Fields["ctt_estado"].Value);
                    contrato.Usu_id = Convert.ToInt32(rs.Fields["usu_id"].Value);
                    contrato.Ctt_depacu = Convert.ToDecimal(rs.Fields["ctt_depacu"].Value);
                    contrato.Ctt_depacuma = Convert.ToDecimal(rs.Fields["ctt_depacuma"].Value);
                    contrato.Ctt_acugantit = Convert.ToDecimal(rs.Fields["ctt_acugantit"].Value);
                    contrato.Ctt_invacu = Convert.ToDecimal(rs.Fields["ctt_invacu"].Value);
                    contrato.Ctt_invacuma = Convert.ToDecimal(rs.Fields["ctt_invacuma"].Value);
                    contrato.Ctt_acuimptit = Convert.ToDecimal(rs.Fields["ctt_acuimptit"].Value);
                    contrato.Ctt_invneta = Convert.ToDecimal(rs.Fields["ctt_invneta"].Value);

                    contrato.Ctt_lrc = Convert.ToDecimal(rs.Fields["ctt_lrc"].Value);
                    contrato.Ctt_vhiena = Convert.ToDecimal(rs.Fields["ctt_vhiena"].Value);
                    contrato.Ctt_cmp = Convert.ToInt64(rs.Fields["ctt_cmp"].Value);
                    contrato.Ctt_icpmp = Convert.ToDecimal(rs.Fields["ctt_icpmp"].Value);
                    contrato.Ctt_pppvgnpf = Convert.ToDecimal(rs.Fields["ctt_pppvgnpf"].Value);
                    contrato.Ctt_pppvhlpf = Convert.ToDecimal(rs.Fields["ctt_pppvhlpf"].Value);
                    contrato.Ctt_costrecuacu = Convert.ToDecimal(rs.Fields["ctt_costrecuacu"].Value);
                    contrato.Ctt_orden = Convert.ToInt32(rs.Fields["ctt_orden"].Value);
                    lstContrato.Add(contrato);
                    rs.MoveNext();

                }
                Connection_Off(1);
                return lstContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContrato;
            }
        }
    }
}