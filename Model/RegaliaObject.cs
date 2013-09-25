using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class RegaliaObject : Regalia
    {
        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

        /// <summary>
        /// existRegalia Method
        /// </summary>
        public bool existRegalia(long reg_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT reg_id " +
                      "FROM tab_regalia " +
                      "WHERE reg_id='" + reg_id + " AND reg_estado = 1";

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
        }

        /// <summary>
        /// findRegalia Method
        /// </summary>
        public List<Regalia> findRegalia(long reg_id)
        {
            //string where = 
            List<Regalia> lstRegalia = new List<Regalia>();
            try
            {
                Connection_On();
                SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                    " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                    " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_id = '" + reg_id + "' AND a.reg_estado = 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    Regalia regalia = new Regalia();
                    regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
                    regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
                    regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
                    regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
                    regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
                    regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
                    regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
                    regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
                    regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
                    regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
                    regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
                    regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
                    regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
                    lstRegalia.Add(regalia);
                    rs.MoveNext();
                    Connection_Off(1);
                    return lstRegalia;
                }
                else
                {
                    Connection_Off(1);
                    return lstRegalia;
                }
            }
            catch (COMException err)
            {

                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRegalia;
            }
        }
        public List<Regalia> listRegalia(long reg_id)
        {
            string where = (reg_id != 0 ? ("AND reg_id=" + reg_id + " ") : " ");
            List<Regalia> lstRegalia = new List<Regalia>();
            try
            {
                Connection_On();
                //SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, (CASE reg_tipo WHEN 'P' THEN 'PARTICIPACIÓN' WHEN 'R' THEN 'REGALIAS' WHEN 'I' THEN 'IDH' ELSE 'SIN ESPECIFICAR' END) AS reg_tiponombre, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre " + //"SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                    " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                    " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_estado = 1 " + 
                    where +
                    " ORDER BY a.reg_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Regalia regalia = new Regalia();
                    regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
                    regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
                    regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
                    regalia.Mes_nombre = MESES[regalia.Mes_id - 1];
                    regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
                    regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
                    regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
                    regalia.Reg_tiponombre = Convert.ToString(rs.Fields["reg_tiponombre"].Value);
                    regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
                    regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
                    regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
                    regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
                    regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
                    regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
                    regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
                    lstRegalia.Add(regalia);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstRegalia;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRegalia;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        public List<Regalia> listRegaliaPorContrato(long ctt_id)
        {
            string where = (ctt_id != 0 ? ("AND a.ctt_id=" + ctt_id + " ") : " ");
            List<Regalia> lstRegalia = new List<Regalia>();
            try
            {
                Connection_On();
                SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, (CASE reg_tipo WHEN 'P' THEN 'PARTICIPACIÓN' WHEN 'R' THEN 'REGALIAS' WHEN 'I' THEN 'IDH' ELSE 'SIN ESPECIFICAR' END) AS reg_tiponombre, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre " + //"SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                    " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                    " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_estado = 1 " +
                    where +
                    " ORDER BY a.reg_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Regalia regalia = new Regalia();
                    regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
                    regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
                    regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
                    regalia.Mes_nombre = MESES[regalia.Mes_id - 1];
                    regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
                    regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
                    regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
                    regalia.Reg_tiponombre = Convert.ToString(rs.Fields["reg_tiponombre"].Value);
                    regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
                    regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
                    regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
                    regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
                    regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
                    regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
                    regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
                    lstRegalia.Add(regalia);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstRegalia;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRegalia;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public List<Regalia> listRegaliaPorContrato(long ctt_id, long ani_id, long mes_id)
        {
          string where = (ctt_id != 0 ? ("AND a.ctt_id=" + ctt_id + " ") : " ");
          where += (ani_id != 0 ? ("AND a.ani_id=" + ani_id + " ") : " ");
          where += (mes_id != 0 ? ("AND a.mes_id=" + mes_id + " ") : " ");

          List<Regalia> lstRegalia = new List<Regalia>();
          try
          {
            Connection_On();
            SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, (CASE reg_tipo WHEN 'P' THEN 'PARTICIPACIÓN' WHEN 'R' THEN 'REGALIAS' WHEN 'I' THEN 'IDH' ELSE 'SIN ESPECIFICAR' END) AS reg_tiponombre, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre " + //"SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_estado = 1 " +
                where +
                " ORDER BY a.reg_id";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Regalia regalia = new Regalia();
              regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
              regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
              regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
              regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
              regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
              regalia.Mes_nombre = MESES[regalia.Mes_id - 1];
              regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
              regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
              regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
              regalia.Reg_tiponombre = Convert.ToString(rs.Fields["reg_tiponombre"].Value);
              regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
              regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
              regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
              regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
              regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
              regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
              regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
              lstRegalia.Add(regalia);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstRegalia;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstRegalia;
          }
          finally
          {
            Connection_Off(1);
          }
        }





        public List<Regalia> listRegaliaPorContratoCampo(long ctt_id, long ani_id, long mes_id, long cam_id)
        {
          string where = (ctt_id != 0 ? ("AND a.ctt_id=" + ctt_id + " ") : " ");
          where += (ani_id != 0 ? ("AND a.ani_id=" + ani_id + " ") : " ");
          where += (mes_id != 0 ? ("AND a.mes_id=" + mes_id + " ") : " ");
          where += (cam_id != 0 ? ("AND a.cam_id=" + cam_id + " ") : " ");

          List<Regalia> lstRegalia = new List<Regalia>();
          try
          {
            Connection_On();
            SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, (CASE reg_tipo WHEN 'P' THEN 'PARTICIPACIÓN' WHEN 'R' THEN 'REGALIAS' WHEN 'I' THEN 'IDH' ELSE 'SIN ESPECIFICAR' END) AS reg_tiponombre, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre " + //"SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_estado = 1 " +
                where +
                " ORDER BY a.reg_id";

            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Regalia regalia = new Regalia();
              regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
              regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
              regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
              regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
              regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
              regalia.Mes_nombre = MESES[regalia.Mes_id - 1];
              regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
              regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
              regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
              regalia.Reg_tiponombre = Convert.ToString(rs.Fields["reg_tiponombre"].Value);
              regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
              regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
              regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
              regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
              regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
              regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
              regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
              lstRegalia.Add(regalia);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstRegalia;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstRegalia;
          }
          finally
          {
            Connection_Off(1);
          }
        }






        public List<Regalia> listRegaliaPorContrato2(long ctt_id, long ani_id, long mes_id)
        {
            string where = (ctt_id != 0 ? ("AND tab_regalia.ctt_id=" + ctt_id + " ") : " ");
            where += (ani_id != 0 ? ("AND tab_regalia.ani_id=" + ani_id + " ") : " ");
            where += (mes_id != 0 ? ("AND tab_regalia.mes_id=" + mes_id + " ") : " ");

            List<Regalia> lstRegalia = new List<Regalia>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_contrato.ctt_id, " +
                        "tab_regalia.ani_id, " +
                        "tab_regalia.mes_id, " +
                        "tab_regalia.reg_tipo, " +
                        "tab_regalia.reg_gasmi, " +
                        "tab_regalia.reg_gasme, " +
                        "tab_regalia.reg_crudomi, " +
                        "tab_regalia.reg_crudome, " +
                        "tab_regalia.reg_glp, " +
                        "tab_regalia.reg_total " +
                        "FROM " +
                        "tab_contrato " +
                        "INNER JOIN tab_regalia ON tab_contrato.ctt_id = tab_regalia.ctt_id " +
                      " WHERE tab_regalia.reg_estado = 1 " +
                    where +
                    " ORDER BY tab_regalia.reg_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Regalia regalia = new Regalia();
                    regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
                    regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
                    regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
                    regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
                    regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
                    regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
                    regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
                    regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
                    regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
                    lstRegalia.Add(regalia);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstRegalia;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRegalia;
            }
            finally
            {
                Connection_Off(1);
            }
        }



        public void EliminarRegaliazIDH(long ani_id, long mes_id, char reg_tipo)
        {
            try
            {
                SQL = "UPDATE tab_regalia set reg_estado = 0 where mes_id = '" + mes_id + "' AND ani_id = '" + ani_id + "' AND reg_tipo ='" + reg_tipo + "'";
                Connection_On();
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


        public List<Regalia> listRegaliaByAnioAndMes(long ani_id, long mes_id, string reg_tipo, string reg_tipo2)
        {
            string where = (ani_id != 0 ? ("AND ani_id=" + ani_id + " ") : " ");
            where += (mes_id != 0 ? (" AND mes_id=" + mes_id + " ") : " ");
            where += (reg_tipo != "" ? (" AND (reg_tipo='" + reg_tipo + "' ") : " ");
            where += (reg_tipo2 != "" ? (" OR reg_tipo='" + reg_tipo2 + "') ") : ") ");
            List<Regalia> lstRegalia = new List<Regalia>();
            try
            {
                Connection_On();
                //SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                SQL = "SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, TRIM(reg_tipo) AS reg_tipo, (CASE reg_tipo WHEN 'P' THEN 'PARTICIPACIÓN' WHEN 'R' THEN 'REGALIAS' WHEN 'I' THEN 'IDH' ELSE 'SIN ESPECIFICAR' END) AS reg_tiponombre, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre " + //"SELECT a.reg_id, a.ctt_id, a.ani_id, a.mes_id, a.mon_id, reg_tipo, reg_gasmi, reg_gasme, reg_crudomi, reg_crudome, reg_glp, reg_total, a.reg_estado, b.ctt_codigo, b.ctt_nombre, d.mon_nombre" +
                    " FROM tab_regalia a, tab_contrato b, tab_moneda d " +
                    " WHERE a.mon_id = d.mon_id AND a.ctt_id = b.ctt_id AND a.reg_estado = 1 " +
                    where +
                    " ORDER BY a.reg_id";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Regalia regalia = new Regalia();
                    regalia.Reg_id = Convert.ToInt64(rs.Fields["reg_id"].Value);
                    regalia.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    regalia.Ctt_nombre = Convert.ToString(rs.Fields["ctt_nombre"].Value);
                    regalia.Ani_id = Convert.ToInt64(rs.Fields["ani_id"].Value);
                    regalia.Mes_id = Convert.ToInt64(rs.Fields["mes_id"].Value);
                    regalia.Mes_nombre = MESES[regalia.Mes_id - 1];
                    regalia.Mon_id = Convert.ToInt64(rs.Fields["mon_id"].Value);
                    regalia.Mon_nombre = Convert.ToString(rs.Fields["mon_nombre"].Value);
                    regalia.Reg_tipo = Convert.ToString(rs.Fields["reg_tipo"].Value);
                    regalia.Reg_tiponombre = Convert.ToString(rs.Fields["reg_tiponombre"].Value);
                    regalia.Reg_gasmi = Convert.ToDecimal(rs.Fields["reg_gasmi"].Value);
                    regalia.Reg_gasme = Convert.ToDecimal(rs.Fields["reg_gasme"].Value);
                    regalia.Reg_crudomi = Convert.ToDecimal(rs.Fields["reg_crudomi"].Value);
                    regalia.Reg_crudome = Convert.ToDecimal(rs.Fields["reg_crudome"].Value);
                    regalia.Reg_glp = Convert.ToDecimal(rs.Fields["reg_glp"].Value);
                    regalia.Reg_total = Convert.ToDecimal(rs.Fields["reg_total"].Value);
                    regalia.Reg_estado = Convert.ToInt32(rs.Fields["reg_estado"].Value);
                    lstRegalia.Add(regalia);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstRegalia;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstRegalia;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}