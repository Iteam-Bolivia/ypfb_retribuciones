using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class Campo_SinonimoObject : Campo_Sinonimo
    {
        public bool existCampo_Sinonimo(long cas_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT cas_id FROM tab_campo_sinonimo WHERE cas_id='" + cas_id + "'";

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
        }
        
        public List<Campo_Sinonimo> listCampo_Sinonimo(long cas_id)
        {
            string where = (cas_id != 0 ? ("AND tab_campo_sinonimo.cas_id = " + cas_id + "") : "");
            List<Campo_Sinonimo> lstCampo_Sinonimo = new List<Campo_Sinonimo>();
            try
            {
                SQL = "SELECT tab_campo_sinonimo.cas_id, tab_campo_sinonimo.cam_id, tab_campo.cam_nombre, tab_campo_sinonimo.cas_nombre,tab_campo_sinonimo.cas_estado ";
                SQL += "FROM tab_campo_sinonimo ";
                SQL += "INNER JOIN tab_campo ON tab_campo_sinonimo.cam_id = tab_campo.cam_id ";
                SQL += "WHERE  tab_campo_sinonimo.cas_estado = 1 " + where;

                SQL += " ORDER BY tab_campo_sinonimo.cas_id";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Sinonimo campo = new Campo_Sinonimo();
                    campo.Cas_id = Convert.ToInt64(rs.Fields["cas_id"].Value);
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cas_nombre = Convert.ToString(rs.Fields["cas_nombre"].Value);
                    campo.Cas_estado = Convert.ToInt32(rs.Fields["cas_estado"].Value);
                    lstCampo_Sinonimo.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampo_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampo_Sinonimo;
            }
        }
        public List<Campo_Sinonimo> listCampo_SinonimoPorCampo(long cam_id)
        {
            string where = (cam_id != 0 ? ("AND tab_campo_sinonimo.cam_id=" + cam_id + "") : "");
            List<Campo_Sinonimo> lstCampo_Sinonimo = new List<Campo_Sinonimo>();
            try
            {
                SQL = "SELECT tab_campo_sinonimo.cas_id, tab_campo_sinonimo.cam_id, tab_campo.cam_nombre, tab_campo_sinonimo.cas_nombre,tab_campo_sinonimo.cas_estado ";
                SQL += "FROM tab_campo_sinonimo ";
                SQL += "INNER JOIN tab_campo ON tab_campo_sinonimo.cam_id = tab_campo.cam_id ";
                SQL += "WHERE tab_campo_sinonimo.cas_estado = 1 ";
                SQL += where;

                SQL += " ORDER BY 1";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Sinonimo campo = new Campo_Sinonimo();
                    campo.Cas_id = Convert.ToInt64(rs.Fields["cas_id"].Value);
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Cas_nombre = Convert.ToString(rs.Fields["cas_nombre"].Value);
                    campo.Cas_estado = Convert.ToInt32(rs.Fields["cas_estado"].Value);
                    lstCampo_Sinonimo.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampo_Sinonimo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampo_Sinonimo;
            }
        }



        public Campo buscarSinonimoCampo(string cam_nombre1)
        {
          Campo objCampo = null;
          string cam_nombre = prosesoCadena(cam_nombre1);
          string Where = (cam_nombre != "" ? ("AND tab_campo.cam_nombre = '" + cam_nombre + "'") : "");
          try
          {
            Connection_On();
            SQL = "SELECT " +
                  "tab_contrato.ctt_id, " +
                  "tab_campo.cam_id, "+
                  "tab_campo.cam_nombre " +
                  "FROM " +
                  "tab_contrato " +
                  "INNER JOIN tab_contrato_campo ON tab_contrato.ctt_id = tab_contrato_campo.ctt_id " +
                  "INNER JOIN tab_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
                  "WHERE " +
                  "tab_campo.cam_estado = 1 " +
                    Where;

            rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
            if (!rs.EOF)
            {
                objCampo = new Campo();
                objCampo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                objCampo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                objCampo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                Connection_Off(1);
              return objCampo;
            }
            else
            {
              SQL = "SELECT " +
                    "tab_contrato.ctt_id, " +
                    "tab_campo.cam_nombre, " +
                    "tab_campo.cam_id, " +
                    "tab_campo_sinonimo.cas_nombre " +
                    "FROM " +
                    "tab_contrato " +
                    "INNER JOIN tab_contrato_campo ON tab_contrato.ctt_id = tab_contrato_campo.ctt_id " +
                    "INNER JOIN tab_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
                    "INNER JOIN tab_campo_sinonimo ON tab_campo.cam_id = tab_campo_sinonimo.cam_id " +
                    "WHERE " +
                    "tab_campo_sinonimo.cas_estado = 1 " +
                    "AND tab_campo_sinonimo.cas_nombre = '" + cam_nombre + "'";
              rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
              if (!rs2.EOF)
              {
                  objCampo = new Campo();
                  objCampo.Ctt_id = Convert.ToInt64(rs2.Fields["ctt_id"].Value);
                  objCampo.Cam_nombre = Convert.ToString(rs2.Fields["cam_nombre"].Value);
                  objCampo.Cam_id = Convert.ToInt64(rs2.Fields["cam_id"].Value);
                  objCampo.Cas_nombre = Convert.ToString(rs2.Fields["cas_nombre"].Value);
              }
              Connection_Off(1);
              Connection_Off(2);
              return objCampo;
            }
          }
          catch (COMException err)
          {
            Console.WriteLine("Error: " + err.Message);
            Connection_Off(1);
            Connection_Off(2);
            return objCampo;
          }
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
    }
}