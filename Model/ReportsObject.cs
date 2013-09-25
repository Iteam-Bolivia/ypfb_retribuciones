using System;
using System.Text;
using System.Data;
using System.Configuration;
using Model;

// 
using Npgsql;
using NpgsqlTypes;
//

namespace ypfbApplication.Model
{

    public class ReportsObject
    {

        // Con conexión ODBC
        Bd bd = new Bd();

        ADODB.Connection cnn = new ADODB.Connection();

        ADODB.Recordset rs = new ADODB.Recordset();
        /// <summary>
        /// Method fillDataSet
        /// </summary>
        public DataSet fillDataSet(string nameFunction, string nameDataTable, int ctt_id)
        {
            try
            {

                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();
                DataSet toReturn = new DataSet(nameDataTable);
                // Ejecuta Procedimiento Almacenado
                string SQL = "SELECT ctt_id, tit_codigo, tit_nombre, ttc_tipo, ttc_porcentaje FROM fnc_gettitulares(" + ctt_id + ")";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                // Convierte RecordSet a DataSet
                toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                bd.Connection_Off(1);
                // Devuelve el dataset rellenado
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }



        // Primer Reporte
        public DataSet fillDataSetRepRecalculo(string nameFunction, string nameDataTable, long ctt_id, long tcl_id, int mes_id, int ani_id)
        {
            try
            {
                DataSet toReturn = new DataSet(nameDataTable);
                string SQL = "";
                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();

                switch (tcl_id)
                {
                    case 4:
                        // Ejecuta Procedimiento Almacenado
                        SQL = "SELECT * FROM " + nameFunction + " (" + ctt_id + "," + tcl_id + "," + 0 + "," + mes_id + "," + ani_id + ")";
                        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                        // Convierte Recordset a DataSet
                        toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                        break;
                    case 2:
                        // Ejecuta Procedimiento Almacenado
                        SQL = "SELECT * FROM " + nameFunction + " (" + ctt_id + "," + tcl_id + "," + 3 + "," + mes_id + "," + ani_id + ")";
                        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                        // Convierte Recordset a DataSet
                        toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                        break;
                    default:
                        // Ejecuta Procedimiento Almacenado
                        SQL = "SELECT * FROM fnc_recalculo(" + ctt_id + "," + tcl_id + "," + 3 + "," + mes_id + "," + ani_id + ")";
                        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                        // Convierte Recordset a DataSet
                        toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                        break;
                }
                //devuelve el dataset rellenado
                bd.Connection_Off(1);
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }



        /// <summary>
        /// reporte participacion
        /// </summary>
        /// <param name="nameFunction"></param>
        /// <param name="nameDataTable"></param>
        /// <param name="ctt_id"></param>
        /// <param name="tcl_id"></param>
        /// <param name="mes_id"></param>
        /// <param name="ani_id"></param>
        /// <returns></returns>
        public DataSet fillDataSetRepParticipacion(string nameFunction, string nameDataTable, long mes_id, long anio_id, long tcl_id)
        {
            try
            {
                DataSet toReturn = new DataSet(nameDataTable);
                string SQL = "";
                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();
                if (nameFunction == "fnc_participacion_titular_campos")
                {
                    SQL = "SELECT * FROM " + nameFunction + " (" + mes_id + "," + anio_id + "," + tcl_id + ")";
                    rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                    // Convierte Recordset a DataSet
                    toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                }
                else
                {
                    SQL = "SELECT * FROM " + nameFunction + "(" + mes_id + "," + anio_id + "," + tcl_id + ")";
                    rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                    toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                }
                bd.Connection_Off(1);
                //devuelve el dataset rellenado
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }

        /////////////////////AUMENTADO DIEGO 16/10

        /// <summary>
        /// reporte participacion
        /// </summary>
        /// <param name="nameFunction"></param>
        /// <param name="nameDataTable"></param>
        /// <param name="ctt_id"></param>
        /// <param name="tcl_id"></param>
        /// <param name="mes_id"></param>
        /// <param name="ani_id"></param>
        /// <returns></returns>
        public DataSet fillDataSetRepRecalculoTit(string nameFunction, string nameDataTable, long ctt_id, long mes_id, long anio_id)
        {
            try
            {
                DataSet toReturn = new DataSet(nameDataTable);
                string SQL = "";
                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();

                SQL = "SELECT * FROM " + nameFunction + " (" + ctt_id + "," + mes_id + "," + anio_id + ")";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                // Convierte Recordset a DataSet
                toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);

                bd.Connection_Off(1);
                //devuelve el dataset rellenado
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }

        //////////////////////////


        /// <summary>
        /// reporte participacion
        /// </summary>
        /// <param name="nameFunction"></param>
        /// <param name="nameDataTable"></param>
        /// <param name="ctt_id"></param>
        /// <param name="tcl_id"></param>
        /// <param name="mes_id"></param>
        /// <param name="ani_id"></param>
        /// <returns></returns>
        public DataSet fillDataSetRepParticipacion(string nameFunction, string nameDataTable, long mes_id, long anio_id, string var_id, long tcl_id)
        {
            try
            {
                DataSet toReturn = new DataSet(nameDataTable);
                string SQL = "";
                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();
                if (nameFunction == "fnc_participacion_titular_campos")
                {
                    SQL = "SELECT * FROM " + nameFunction + " (" + mes_id + "," + anio_id + ",'" + var_id + "%'," + tcl_id + ")";
                    rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                    // Convierte Recordset a DataSet
                    toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                }
                else
                {
                    SQL = "SELECT * FROM " + nameFunction + "(" + mes_id + "," + anio_id + "," + tcl_id + ",'" + var_id + "%')";
                    rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                    toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);
                }
                bd.Connection_Off(1);
                //devuelve el dataset rellenado
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }
        /// <summary>
        /// reporte participacion
        /// </summary>
        /// <param name="nameFunction"></param>
        /// <param name="nameDataTable"></param>
        /// <param name="ctt_id"></param>
        /// <param name="tcl_id"></param>
        /// <param name="mes_id"></param>
        /// <param name="ani_id"></param>
        /// <returns></returns>
        public DataSet fillDataSetResumenEjec(string nameFunction, string nameDataTable, long mes_id, long anio_id)
        {
            try
            {
                DataSet toReturn = new DataSet(nameDataTable);
                string SQL = "";
                //declara objeto del tipo daset que contiene los datatables con los campos de las consultas
                bd_ypfb_retribucionesDataSet dsReports = new bd_ypfb_retribucionesDataSet();

                //crea la caneda de conexion y la abre
                //crearCadenaConexion();
                cnn = bd.Connection_On();
                SQL = "SELECT * FROM " + nameFunction + "(" + mes_id + "," + anio_id + ")";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                toReturn = bd.RstoDataSet(rs, nameDataTable, dsReports);

                bd.Connection_Off(1);
                //devuelve el dataset rellenado
                return toReturn;
            }
            catch (Exception ex)
            {
                bd.Connection_Off(1);
                throw ex;
            }
            finally
            {
                //cerrar y destruir la conexion
                bd.Connection_Off(1);
            }
        }
    }
}