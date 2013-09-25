using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class TitutalContratoObject : Titular_Contrato
    {
        /// <summary>
        /// Existe Titular Contrato
        /// </summary>
        /// <param name="ctt_id">Id Contrato</param>
        /// <returns></returns>
        public bool existTitularContrato(long ctt_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id FROM tab_titular_contrato WHERE ctt_id='" + ctt_id + "'";

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
        }/* Method existTitular */


        /// <summary>
        /// Lista de Titular Contrato por Contrato
        /// </summary>
        /// <param name="ctt_id">Contrato id</param>
        /// <returns>Lista de Contratos mas titulares</returns>
        public List<Titular_Contrato> listTitularContrato(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND ctt_id=" + ctt_id + "") : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();

            try
            {
                Connection_On();
                SQL = "SELECT ttc_id,ctt_id, tit_id, ttc_tipo, ttc_porcentaje, ttc_estado " +
                          "FROM tab_titular_contrato " +
                          "WHERE ttc_estado = 1 " +
                          where;

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    //Declaro las clases auxiliares para esta parte
                    //Titular
                    List<Titular> titular = new List<Titular>();
                    //Contrato
                    List<Contrato> contrato = new List<Contrato>();

                    //cargado del los object para el respectivo cargado de los datos
                    //Contrato Object
                    ContratoObject contratoObject = new ContratoObject();
                    //Titular object
                    TitularObject titutalObject = new TitularObject();


                    titular = titutalObject.listTitular(System.Convert.ToInt64(rs.Fields["ctt_id"].Value));



                    // Creo una clase titular para cargar los datos.
                    Titular_Contrato titularContrato = new Titular_Contrato();


                    titularContrato.Ttc_id = System.Convert.ToInt64(rs.Fields["ttc_id"].Value);
                    titularContrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    titularContrato.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titularContrato.Ttc_tipo = Convert.ToString(rs.Fields["ttc_tipo"].Value);
                    titularContrato.Ttc_porcentaje = Convert.ToDecimal(rs.Fields["ttc_porcentaje"].Value);
                    titularContrato.Ttc_estado = System.Convert.ToInt32(rs.Fields["ttc_estado"].Value);

                    ///Creo la clase contrato para que se carge con datos.
                    //titularContrato.Ctt = new Contrato();
                    ////cargo los datos del contrato para ser enviados a la vista.
                    //titularContrato.Ctt.Ctt_id = contrato[0].Ctt_id;
                    //titularContrato.Ctt.Ctt_codigo = contrato[0].Ctt_codigo;
                    //titularContrato.Ctt.Ctt_estado = contrato[0].Ctt_estado;
                    //titularContrato.Ctt.Ctt_nombre = contrato[0].Ctt_nombre;
                    //titularContrato.Ctt.Ctt_periodo = contrato[0].Ctt_periodo;

                    //if (titular.Count == 0)
                    //{
                    //    //Creo la clase titular para que se cargen los datos.
                    //    titularContrato.Tit = new Titular();
                    //    //Cargo los datos directamete 
                    //    titularContrato.Tit.Tit_id = titular[0].Tit_id;
                    //    titularContrato.Tit.Tit_codigo = titular[0].Tit_codigo;
                    //    titularContrato.Tit.Tit_nombre = titular[0].Tit_nombre;
                    //    titularContrato.Tit.Tit_estado = titular[0].Tit_estado;
                    //}
                    //else
                    //{
                    //    //Creo la clase titular para que se cargen los datos.
                    //    titularContrato.Tit = new Titular();
                    //    foreach (Titular item in titular)
                    //    {
                    //        Titular aux = new Titular();
                    //        //Cargo los datos directamete 
                    //        aux.Tit_id = item.Tit_id;
                    //        aux.Tit_codigo = item.Tit_codigo;
                    //        aux.Tit_nombre = item.Tit_nombre;
                    //        aux.Tit_estado = item.Tit_estado;
                    //        titularContrato.ListTitular.Add(aux);
                    //    }

                    //}
                    lstTitularContrato.Add(titularContrato);


                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitularContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitularContrato;
            }
        }



        public List<Titular_Contrato> listaTitularesPorNombreContrato(string ctt_name)
        {
            string Where = (ctt_name != "" ? ("AND ctt_nombre = '" + ctt_name + "'") : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_contrato.ctt_nombre, " +
                        "tab_titular_contrato.ttc_id, " +
                        "tab_titular.tit_id, " +
                        "tab_titular.tit_nombre, " +
                        "tab_titular_contrato.ctt_id " +
                        "FROM " +
                        "tab_contrato " +
                        "INNER JOIN tab_titular_contrato ON tab_titular_contrato.ctt_id = tab_contrato.ctt_id " +
                        "INNER JOIN tab_titular ON tab_titular.tit_id = tab_titular_contrato.tit_id " +
                        "WHERE ttc_estado = 1 " +
                        "AND tit_estado = 1 " +
                        "AND ttc_tipo = 'O' " +
                        Where +
                        " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    Titular_Contrato titular = new Titular_Contrato();
                    titular.Ttc_id = Convert.ToInt64(rs.Fields["ttc_id"].Value);
                    titular.Ctt = new Contrato();
                    titular.Ctt.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    titular.Tit = new Titular();
                    titular.Tit.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titular.Tit.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    lstTitularContrato.Add(titular);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstTitularContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstTitularContrato;
            }
        }
    }
}
