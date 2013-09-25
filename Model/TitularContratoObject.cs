using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class TitularContratoObject : Titular_Contrato
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
        /// <param name="ttc_id">Contrato id</param>
        /// <returns>Lista de Contratos mas titulares</returns>
        public List<Titular_Contrato> listTitularContrato(long ttc_id)
        {
            String where = (ttc_id != 0 ? ("AND ttc_id=" + ttc_id + "") : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();

            try
            {
                Connection_On();
                //SQL = "SELECT ttc_id, ctt_id, A.tit_id, tit_nombre, ttc_tipo, ttc_porcentaje, ttc_estado " +
                SQL = "SELECT ttc_id, ctt_id, A.tit_id, tit_nombre, (CASE WHEN ttc_tipo = 'T' THEN 'TITULAR' ELSE 'OPERADOR' END) AS ttc_tipo, ttc_porcentaje, ttc_estado " +
                    "FROM tab_titular_contrato AS A " +
                    "INNER JOIN tab_titular AS B ON A.tit_id = B.tit_id " +
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
                    titularContrato.Ttc_tipo = (string)rs.Fields["ttc_tipo"].Value;
                    titularContrato.Ttc_porcentaje = Convert.ToString(rs.Fields["ttc_porcentaje"].Value);
                    titularContrato.Ttc_estado = System.Convert.ToInt32(rs.Fields["ttc_estado"].Value);
                    titularContrato.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titularContrato.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titularContrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);


                    /////Creo la clase contrato para que se carge con datos.
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
        /// <summary>
        /// Recupera Nombres Empresas asociados al contrato
        /// </summary>
        /// <param name="ctt_id">Código contrato</param>
        /// <returns>ListaTitularesContrato</returns>
        public List<Titular_Contrato> listaTitularesContratoNombrePorContrato(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id) : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT tit_nombre " +
                    "FROM tab_titular_contrato A " +
                    "INNER JOIN tab_titular B ON A.tit_id = B.tit_id " +
                    "WHERE ttc_estado = 1 " +
                    "AND tit_estado = 1 " +
                    Where +
                    " ORDER BY 1";

                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs2.EOF)
                {
                    Titular_Contrato titular = new Titular_Contrato();
                    titular.Tit_nombre = Convert.ToString(rs2.Fields["tit_nombre"].Value);
                    lstTitularContrato.Add(titular);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstTitularContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstTitularContrato;
            }
        }

        public List<Titular_Contrato> listaTitularesContratoPorContrato(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND A.ctt_id = " + ctt_id) : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            try
            {
                Connection_On();
                //SQL = "SELECT ttc_id,ctt_id, A.tit_id, ttc_tipo, ttc_porcentaje, ttc_estado " + //"SELECT ttc_id, B.tit_id, tit_nombre " +
                SQL = "SELECT A.ttc_id, A.ctt_id, A.tit_id, tit_nombre, (CASE WHEN ttc_tipo = 'T' THEN 'TITULAR' ELSE 'OPERADOR' END) AS ttc_tipo, ttc_porcentaje, ttc_estado " +
                    "FROM tab_titular_contrato A " +
                    "INNER JOIN tab_titular B ON A.tit_id = B.tit_id " +
                    "INNER JOIN tab_contrato C ON C.ctt_id = A.ctt_id " +
                    "WHERE ttc_estado = 1 " +
                    //"AND tit_estado = 1 " +
                    Where +
                    " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs.EOF)
                {
                    Titular_Contrato titularContrato = new Titular_Contrato();
                    titularContrato.Ttc_id = Convert.ToInt64(rs.Fields["ttc_id"].Value);
                    titularContrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    titularContrato.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titularContrato.Tit_nombre = Convert.ToString(rs.Fields["tit_nombre"].Value);
                    titularContrato.Ttc_tipo = Convert.ToString(rs.Fields["ttc_tipo"].Value);
                    titularContrato.Ttc_porcentaje = Convert.ToString(rs.Fields["ttc_porcentaje"].Value);
                    titularContrato.Ttc_estado = Convert.ToInt32(rs.Fields["ttc_estado"].Value);
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


        public List<Titular_Contrato> listaTitularesPorNombreTitular(string nombre)
        {
            string tit_nombre = operacionCadena(nombre);
            string Where = (tit_nombre != "" ? ("AND tit_nombre = '" + tit_nombre + "'") : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                        "tab_titular.tit_id, " +
                        "tab_titular_contrato.ttc_id, " +
                        "tab_titular_contrato.ctt_id, " +
                        "tab_titular.tit_nombre " +
                        "FROM " +
                        "tab_titular " +
                        "Inner Join tab_titular_contrato ON tab_titular_contrato.tit_id = tab_titular.tit_id " +
                        "WHERE ttc_estado = 1 " +
                        "AND tit_estado = 1 " +
                        "AND ttc_tipo = 'O' " +
                        Where;

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
        public Titular_Contrato DatosTitularesContrato(long ttc_id)
        {
            string Where = (ttc_id != 0 ? ("AND ttc_id = " + ttc_id) : "");
            Titular_Contrato titularContrato = null;
            try
            {
                Connection_On();
                SQL = "SELECT ttc_id, ctt_id, tit_id, ttc_tipo, ttc_porcentaje, ttc_estado ";
                SQL += "FROM tab_titular_contrato ";
                SQL += "WHERE ttc_estado = 1 ";
                SQL += Where;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                if (!rs.EOF)
                {
                    titularContrato = new Titular_Contrato();
                    titularContrato.Ttc_id = Convert.ToInt64(rs.Fields["ttc_id"].Value);
                    titularContrato.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    titularContrato.Tit_id = Convert.ToInt64(rs.Fields["tit_id"].Value);
                    titularContrato.Ttc_tipo = Convert.ToString(rs.Fields["ttc_tipo"].Value);
                    titularContrato.Ttc_porcentaje = Convert.ToString(rs.Fields["ttc_porcentaje"].Value);
                    titularContrato.Ttc_estado = Convert.ToInt32(rs.Fields["ttc_estado"].Value);
                }
                Connection_Off(1);
                return titularContrato;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Connection_Off(1);
                return titularContrato;
            }
        }

        public int VerificaTitularContratoOperador(long ctt_id, string ttc_tipo)
        {
            int accion = 0;
            string Where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id) : "");
            try
            {
                Connection_On();
                SQL = "SELECT COUNT(ttc_id) AS ttc_id ";
                SQL += "FROM tab_titular_contrato ";
                SQL += "WHERE ttc_tipo = 'O' ";
                SQL += Where;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                if (rs.RecordCount > 0)
                {
                    if (Convert.ToInt32(rs.Fields[0].Value) > 0)
                        accion = 1;
                    else
                        accion = 0;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                accion = -1;
                return accion;
            }
            Connection_Off(1);
            return accion;
        }

        public decimal VerificaTitularContratoPorcentaje(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id) : "");
            decimal porcentaje = 0;
            try
            {
                Connection_On();
                SQL = "SELECT SUM(ttc_porcentaje) AS ttc_porcentaje ";
                SQL += "FROM tab_titular_contrato ";
                SQL += "WHERE ttc_estado = 1 ";
                SQL += Where;
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                if (rs.RecordCount > 0)
                {
                    if (!rs.EOF)
                    {
                        porcentaje = Convert.ToDecimal(rs.Fields["ttc_porcentaje"].Value);
                        Connection_Off(1);
                        return porcentaje;
                    }
                    else
                    {
                        Connection_Off(1);
                        return 0;
                    }
                }
                else
                {
                    Connection_Off(1);
                    return 0;
                }
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(0);
                return -1;
            }
        }
        private string operacionCadena(string nombre)
        {
            string returnNombre = "";
            returnNombre = nombre.Replace("\n", " ");
            if (returnNombre != "")
            {
                return returnNombre;
            }
            else
                return nombre;
        }


        public List<Titular_Contrato> listaTitularesPorContratoSoloOperador(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND ctt_id = " + ctt_id) : "");
            List<Titular_Contrato> lstTitularContrato = new List<Titular_Contrato>();
            try
            {
                Connection_On();
                SQL = "SELECT ttc_id, B.tit_id, tit_nombre, ctt_id " +
                    "FROM tab_titular_contrato A " +
                    "INNER JOIN tab_titular B ON A.tit_id = B.tit_id " +
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