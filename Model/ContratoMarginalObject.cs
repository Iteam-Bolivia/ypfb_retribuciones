using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ContratoMarginalObject : ContratoMarginal
    {

        string[] MESES = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        int[] ANIOS = new int[] { 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020 };


        /// <summary>
        /// listCondicion Method
        /// </summary>
        public List<ContratoMarginal> listContratoMarginal(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND tab_contratomarginal.ctt_id=" + ctt_id + " ") : " ");
            List<ContratoMarginal> lstCondicion = new List<ContratoMarginal>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratomarginal.cma_id, " +
                    "tab_contratomarginal.ctt_id, " +
                    "tab_contratomarginal.cma_mes, " +
                    "tab_contratomarginal.cma_anio, " +
                    "tab_contratomarginal.cma_anio_ini, " +
                    "tab_contratomarginal.cma_mes_ini, " +
                    "tab_contratomarginal.cma_estado " +
                     "FROM " +
                      "tab_contratomarginal " +
                     "WHERE tab_contratomarginal.cma_estado = 1 " +
                      where +
                      " ORDER BY tab_contratomarginal.cma_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoMarginal contratomarginal = new ContratoMarginal();
                    contratomarginal.Cma_id = System.Convert.ToInt64(rs.Fields["cma_id"].Value);
                    contratomarginal.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratomarginal.Cma_mes = System.Convert.ToInt64(rs.Fields["cma_mes"].Value);
                    contratomarginal.Cma_anio = System.Convert.ToInt64(rs.Fields["cma_anio"].Value);
                    contratomarginal.Cma_mes_ini = System.Convert.ToInt64(rs.Fields["cma_mes_ini"].Value);
                    contratomarginal.Cma_anio_ini = System.Convert.ToInt64(rs.Fields["cma_anio_ini"].Value);
                    contratomarginal.Cma_estado = System.Convert.ToInt32(rs.Fields["cma_estado"].Value);

                    lstCondicion.Add(contratomarginal);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstCondicion;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCondicion;
            }
            finally
            {
                Connection_Off(1);
            }
        }

        /// <summary>
        /// listCondicion Method
        /// </summary>
        public List<ContratoMarginal> listContratoMarginalById(long cma_id)
        {
            String where = (cma_id != 0 ? ("AND tab_contratomarginal.cma_id=" + cma_id + " ") : " ");
            List<ContratoMarginal> lstCondicion = new List<ContratoMarginal>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                      "tab_contratomarginal.cma_id, " +
                      "tab_contratomarginal.ctt_id, " +
                      "tab_contratomarginal.cma_mes, " +
                      "tab_contratomarginal.cma_anio, " +
                      "tab_contratomarginal.cma_anio_ini, " +
                      "tab_contratomarginal.cma_mes_ini, " +
                      "tab_contratomarginal.cma_estado " +
                      "FROM " +
                      "tab_contratomarginal " +
                      "WHERE tab_contratomarginal.cma_estado = 1 " +
                      where +
                      " ORDER BY tab_contratomarginal.cma_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoMarginal contratomarginal = new ContratoMarginal();
                    contratomarginal.Cma_id = System.Convert.ToInt64(rs.Fields["cma_id"].Value);
                    contratomarginal.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratomarginal.Cma_mes = System.Convert.ToInt64(rs.Fields["cma_mes"].Value);
                    contratomarginal.Cma_anio = System.Convert.ToInt64(rs.Fields["cma_anio"].Value);
                    contratomarginal.Cma_mes_ini = System.Convert.ToInt64(rs.Fields["cma_mes_ini"].Value);
                    contratomarginal.Cma_anio_ini = System.Convert.ToInt64(rs.Fields["cma_anio_ini"].Value);
                    contratomarginal.Cma_estado = System.Convert.ToInt32(rs.Fields["cma_estado"].Value);

                    lstCondicion.Add(contratomarginal);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstCondicion;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCondicion;
            }
            finally
            {
                Connection_Off(1);
            }
        }




        /// <summary>
        /// listCondicion Method
        /// </summary>
        public List<ContratoMarginal> listContratoMarginalByIdAndDate(long ctt_id, long mes_id, long anio_id)
        {

            bool flag= false;
            string where = (ctt_id != 0 ? ("AND tab_contratomarginal.ctt_id = " + ctt_id + " ") : " ");
            //where += (mes_id != 0 ? (" AND tab_contratomarginal.cma_mes = " + mes_id + " ") : " ");
            //where += (anio_id != 0 ? (" AND tab_contratomarginal.cma_anio = " + anio_id + " ") : " ");
            List<ContratoMarginal> lstCondicion = new List<ContratoMarginal>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratomarginal.cma_id, " +
                    "tab_contratomarginal.ctt_id, " +
                    "tab_contratomarginal.cma_mes, " +
                    "tab_contratomarginal.cma_anio, " +
                    "tab_contratomarginal.cma_anio_ini, " +
                    "tab_contratomarginal.cma_mes_ini, " +
                    "tab_contratomarginal.cma_estado " +
                     "FROM " +
                      "tab_contratomarginal " +
                     "WHERE tab_contratomarginal.cma_estado = 1 " +
                      where +
                      " ORDER BY tab_contratomarginal.cma_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoMarginal contratomarginal = new ContratoMarginal();
                    contratomarginal.Cma_id = System.Convert.ToInt64(rs.Fields["cma_id"].Value);
                    contratomarginal.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratomarginal.Cma_mes = System.Convert.ToInt64(rs.Fields["cma_mes"].Value);
                    contratomarginal.Cma_anio = System.Convert.ToInt64(rs.Fields["cma_anio"].Value);
                    contratomarginal.Cma_mes_ini = System.Convert.ToInt64(rs.Fields["cma_mes_ini"].Value);
                    contratomarginal.Cma_anio_ini = System.Convert.ToInt64(rs.Fields["cma_anio_ini"].Value);
                    contratomarginal.Cma_estado = System.Convert.ToInt32(rs.Fields["cma_estado"].Value);

                    lstCondicion.Add(contratomarginal);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstCondicion;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCondicion;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
