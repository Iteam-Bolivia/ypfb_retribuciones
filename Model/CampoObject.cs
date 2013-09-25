using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class CampoObject : Campo
    {

        public bool existCampo(long cam_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT cam_id FROM tab_campo WHERE cam_id='" + cam_id + "'";

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
        }/* Method existCampo */

        public List<Campo> listCampoPorCondicion(string condicion)
        {
          List<Campo> lstCampo = new List<Campo>();
          try
          {
            Connection_On();
            SQL = "SELECT cam_id, cam_codigo, cam_nombre, cam_estado " +
                  "FROM tab_campo A " +
                  "WHERE cam_estado = 1 AND cam_var = 1 " +
                  condicion;
            SQL += " ORDER BY cam_id";

            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!rs.EOF)
            {
              Campo campo = new Campo();
              campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
              campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
              campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
              campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);
              lstCampo.Add(campo);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstCampo;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstCampo;
          }
        }
        /// <summary>
        /// listCampo Method
        /// </summary>
        public List<Campo> listCampo(long cam_id)
        {
            String where = (cam_id != 0 ? ("AND cam_id=" + cam_id + "") : "");
            List<Campo> lstCampo = new List<Campo>();

            try
            {
                Connection_On();
                SQL = "SELECT cam_id, cam_codigo, cam_nombre, cam_estado " +
                          "FROM tab_campo A " +
                          "WHERE cam_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List

                    Campo campo = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_codigo = (string)rs.Fields["cam_codigo"].Value;
                    campo.Cam_nombre = (string)rs.Fields["cam_nombre"].Value;
                    campo.Cam_estado = Convert.ToInt64(rs.Fields["cam_estado"].Value);


                    List<Campo_Producto_Mercado> objCPM = new List<Campo_Producto_Mercado>();
                    CampoProductoMercadoObject cpm = new CampoProductoMercadoObject();
                    objCPM = cpm.listCampoProductoMercadoNombresPorCampo(campo.Cam_id);

                    foreach (Campo_Producto_Mercado item in objCPM)
                    {
                        campo.Lista_productos_mercado += item.Pro_nombre+ ", " + item.Mer_nombre + ", ";
                    }

                    if (!string.IsNullOrEmpty(campo.Lista_productos_mercado))
                        campo.Lista_productos_mercado = campo.Lista_productos_mercado.Substring(0, campo.Lista_productos_mercado.Length - 2);
                    lstCampo.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampo;
            }
        }
        public List<Campo> listCampoSegunCriterio( string cam_codigo, string cam_nombre)
        {
            List<Campo> lstCampo = new List<Campo>();
            try
            {
                Connection_On();
                SQL = "SELECT cam_id, cam_codigo, cam_nombre, cam_estado " +
                    "FROM tab_campo A ";
                SQL += "WHERE cam_codigo LIKE '%" + cam_codigo + "%' ";
                SQL += "AND cam_nombre LIKE '%" + cam_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Campo campo = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);
                    lstCampo.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampo;
            }
        }

        public bool SerchCampoByName(string nombre, long ctt_id)
        {
          bool flag = false;
          Campo campo = new Campo();
          string cam_nombre = prosesoCadena(nombre);
          String where = (cam_nombre != "" ? (" AND tab_campo.cam_nombre='" + cam_nombre + "' ") : " ");
          string where2 = (ctt_id != 0 ? (" AND tab_contrato_campo.ctt_id='" + ctt_id + "' ") : " ");
          try
          {
            Connection_On();
            SQL = "SELECT tab_campo.cam_id,  tab_campo.cam_codigo, tab_campo.cam_nombre, tab_campo.cam_estado  " +
                      "FROM tab_campo " +
                      "Inner Join tab_contrato_campo ON tab_contrato_campo.cam_id = tab_campo.cam_id " +
                      "WHERE cam_estado = 1 " +
                      "AND ctc_estado = 1 " +
                      where + where2;
            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
              campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
              campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
              campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);

              rs.MoveNext();
            }
            Connection_Off(1);
            if (campo.Cam_nombre == cam_nombre)
              flag = true;
            else
              flag = false;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
          }
          return flag;
        }

        private string prosesoCadena(string nombre)
        {
          int count = 0;
          int posi = 0;
          string returnNombre = "";
          for (int i = 0; i < nombre.Length; i++)
          {
            if (nombre[i] == ' ')
            {
              count++;

              if (count > 1 && posi == (i - 1))
              {
                posi = i;
                returnNombre = nombre.Remove(posi, 1);
                break;
              }
              posi = i;

            }
          }
          if (returnNombre != "")
          {
            return returnNombre;
          }
          else
            return nombre;
        }


        internal Campo SerchCampoByName(string nombre)
        {
            Campo campo = null;
            string cam_nombre = prosesoCadena(nombre);
            String where = (cam_nombre != "" ? (" AND tab_campo.cam_nombre='" + cam_nombre + "' ") : " ");
            try
            {
                Connection_On();
                SQL = "SELECT tab_campo.cam_id, tab_campo.cam_codigo, tab_campo.cam_nombre, tab_campo.cam_estado,  tab_contrato_campo.ctt_id " +
                          "FROM tab_campo " +
                          "Inner Join tab_contrato_campo ON tab_contrato_campo.cam_id = tab_campo.cam_id " +
                          "WHERE cam_estado = 1 " +
                          "AND ctc_estado = 1 " +
                          where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    campo = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);
                    campo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);

                    rs.MoveNext();
                }
                Connection_Off(1);
                return campo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
            }
            return campo;
        }
        public Campo CampoPorCodigo(long cam_id)
        {
            
            String where = (cam_id != 0 ? ("AND cam_id = " + cam_id + "") : "");
            Campo campo = null;
            try
            {
                Connection_On();
                SQL = "SELECT cam_id, cam_codigo, cam_nombre, cam_estado " +
                    "FROM tab_campo " +                          
                    "WHERE cam_estado = 1 " +
                    where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (!rs.EOF)
                {
                    campo = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_codigo = (string)rs.Fields["cam_codigo"].Value;
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cam_estado = Convert.ToInt64(rs.Fields["cam_estado"].Value);
                }
                Connection_Off(1);
                return campo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return campo;
            }
        }

        internal Campo SerchCampoBySinonimo(string cas_nombre)
        {
            Campo campo = null;
            string cam_nombre = prosesoCadena(cas_nombre);
            String where = (cam_nombre != "" ? (" AND tab_campo_sinonimo.cas_nombre = '" + cam_nombre + "' ") : " ");
            try
            {
                Connection_On();
                SQL = "SELECT "+
                        "tab_campo.cam_id, "+
                        "tab_campo.cam_codigo, "+
                        "tab_campo.cam_nombre, "+
                        "tab_campo.cam_estado "+
                        "FROM " +
                        "tab_campo_sinonimo "+
                        "INNER JOIN tab_campo ON tab_campo.cam_id = tab_campo_sinonimo.cam_id "+
                        "WHERE "+
                        "tab_campo.cam_estado = 1 "+
                        where;
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    campo = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);

                    rs.MoveNext();
                }
                Connection_Off(1);
                return campo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
            }
            return campo;
        }




        public List<Campo> ListaCampoContrato(long ctt_id)
        {
          List<Campo> lstCampo = new List<Campo>();
          //Campo campo = new Campo();
          string where = (ctt_id != 0 ? (" AND tab_contrato_campo.ctt_id='" + ctt_id + "' ") : " ");
          try
          {
            Connection_On();
            SQL = "SELECT tab_campo.cam_id, tab_campo.cam_codigo, tab_campo.cam_nombre, tab_campo.cam_estado " +
                      "FROM tab_campo " +
                      "Inner Join tab_contrato_campo ON tab_contrato_campo.cam_id = tab_campo.cam_id " +
                      "WHERE cam_estado = 1 " +
                      "AND ctc_estado = 1 " +
                      where + "order by cam_nombre asc";
            // Execute the query specifying static sursor, batch optimistic locking
            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
            while (!rs.EOF)
            {
              Campo campo = new Campo();
              campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
              campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
              campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
              campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);
              lstCampo.Add(campo);
              rs.MoveNext();
            }
            Connection_Off(1);
            return lstCampo;
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            return lstCampo;
          }          
        }
    }
}