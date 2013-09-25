using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ContratoCondicionObject : ContratoCondicion
    {

        /// <summary>
        /// listCondicion Method
        /// </summary>
        public List<ContratoCondicion> listContratoCondicion(long ctt_id)
        {
            String where = (ctt_id != 0 ? ("AND tab_contratocondicion.ctt_id=" + ctt_id + " ") : " ");
            List<ContratoCondicion> lstCondicion = new List<ContratoCondicion>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratocondicion.ccn_id, " +
                    "tab_contratocondicion.ctt_id, " +
                    "tab_contratocondicion.con_id, " +
                    "tab_contratocondicion.sim_id, " +
                     "tab_condicion.con_nombre, " +
                       "tab_contratocondicion.ccn_mesiniexp, " +
                      "tab_contratocondicion.ccn_anioiniexp, " +
                      "tab_contratocondicion.ccn_mesfin, " +
                      "tab_contratocondicion.ccn_aniofin, " +
                      "tab_contratocondicion.ccn_diasdifer, " +
                      "tab_contratocondicion.ccn_valorb, " +
                      "tab_simbolo.sim_simbolo " +
                      "FROM " +
                      "tab_condicion " +
                      "INNER JOIN tab_contratocondicion ON tab_condicion.con_id = tab_contratocondicion.con_id " +
                      "LEFT JOIN tab_simbolo ON tab_contratocondicion.sim_id = tab_simbolo.sim_id " +
                      "WHERE tab_contratocondicion.ccn_estado = 1 " +
                      where +
                      " ORDER BY tab_condicion.con_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoCondicion contratocondicion = new ContratoCondicion();
                    contratocondicion.Ccn_id = System.Convert.ToInt64(rs.Fields["ccn_id"].Value);
                    contratocondicion.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratocondicion.Con_id = System.Convert.ToInt64(rs.Fields["con_id"].Value);
                    contratocondicion.Sim_id = System.Convert.ToInt64(rs.Fields["sim_id"].Value);
                    contratocondicion.Con_nombre = System.Convert.ToString(rs.Fields["con_nombre"].Value);
                    //contratocondicion.Ccn_iniexp = System.Convert.ToDateTime(rs.Fields["ccn_iniexp"].Value);
                    contratocondicion.Ccn_mesiniexp = System.Convert.ToInt32(rs.Fields["ccn_mesiniexp"].Value);
                    contratocondicion.Ccn_anioiniexp = System.Convert.ToInt32(rs.Fields["ccn_anioiniexp"].Value);
                    contratocondicion.Ccn_mesfin = System.Convert.ToInt32(rs.Fields["ccn_mesfin"].Value);
                    contratocondicion.Ccn_aniofin = System.Convert.ToInt32(rs.Fields["ccn_aniofin"].Value);
                    //contratocondicion.Ccn_tiempodur = System.Convert.ToDateTime(rs.Fields["ccn_tiempodur"].Value);
                    contratocondicion.Ccn_diasdifer = System.Convert.ToInt32(rs.Fields["ccn_diasdifer"].Value);
                    contratocondicion.Ccn_valorb = System.Convert.ToDecimal(rs.Fields["ccn_valorb"].Value);
                    contratocondicion.Sim_simbolo = System.Convert.ToString(rs.Fields["sim_simbolo"].Value);
                    lstCondicion.Add(contratocondicion);
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
        public List<ContratoCondicion> listContratoCondicionById(long ccn_id)
        {
            String where = (ccn_id != 0 ? ("AND tab_contratocondicion.ccn_id=" + ccn_id + " ") : " ");
            List<ContratoCondicion> lstCondicion = new List<ContratoCondicion>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratocondicion.ccn_id, " +
                    "tab_contratocondicion.ctt_id, " +
                    "tab_contratocondicion.con_id, " +
                    "tab_contratocondicion.sim_id, " +
                      "tab_condicion.con_nombre, " +
                      "tab_contratocondicion.ccn_mesiniexp, " +
                      "tab_contratocondicion.ccn_anioiniexp, " +
                      "tab_contratocondicion.ccn_mesfin, " +
                      "tab_contratocondicion.ccn_aniofin, " +
                      "tab_contratocondicion.ccn_diasdifer, " +
                      "tab_contratocondicion.ccn_valorb, " +
                      "tab_simbolo.sim_simbolo " +
                      "FROM " +
                      "tab_condicion " +
                      "INNER JOIN tab_contratocondicion ON tab_condicion.con_id = tab_contratocondicion.con_id " +
                      "LEFT JOIN tab_simbolo ON tab_contratocondicion.sim_id = tab_simbolo.sim_id " +
                      "WHERE tab_contratocondicion.ccn_estado = 1 " +
                      where +
                      " ORDER BY tab_condicion.con_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoCondicion contratocondicion = new ContratoCondicion();
                    contratocondicion.Ccn_id = System.Convert.ToInt64(rs.Fields["ccn_id"].Value);
                    contratocondicion.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratocondicion.Con_id = System.Convert.ToInt64(rs.Fields["con_id"].Value);
                    contratocondicion.Sim_id = System.Convert.ToInt64(rs.Fields["sim_id"].Value);
                    contratocondicion.Con_nombre = System.Convert.ToString(rs.Fields["con_nombre"].Value);
                    //contratocondicion.Ccn_iniexp = System.Convert.ToDateTime(rs.Fields["ccn_iniexp"].Value);
                    contratocondicion.Ccn_mesiniexp = System.Convert.ToInt32(rs.Fields["ccn_mesiniexp"].Value);
                    contratocondicion.Ccn_anioiniexp = System.Convert.ToInt32(rs.Fields["ccn_anioiniexp"].Value);
                    contratocondicion.Ccn_mesfin = System.Convert.ToInt32(rs.Fields["ccn_mesfin"].Value);
                    contratocondicion.Ccn_aniofin = System.Convert.ToInt32(rs.Fields["ccn_aniofin"].Value);
                    //contratocondicion.Ccn_tiempodur = System.Convert.ToDateTime(rs.Fields["ccn_tiempodur"].Value);
                    contratocondicion.Ccn_diasdifer = System.Convert.ToInt32(rs.Fields["ccn_diasdifer"].Value);
                    contratocondicion.Ccn_valorb = System.Convert.ToDecimal(rs.Fields["ccn_valorb"].Value);
                    contratocondicion.Sim_simbolo = System.Convert.ToString(rs.Fields["sim_simbolo"].Value);
                    lstCondicion.Add(contratocondicion);
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
        public List<ContratoCondicion> listContratoCondicionByCon(long ctt_id, long con_id)
        {
            
            List<ContratoCondicion> lstCondicion = new List<ContratoCondicion>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratocondicion.ccn_id, " +
                    "tab_contratocondicion.ctt_id, " +
                    "tab_contratocondicion.con_id, " +
                    "tab_contratocondicion.sim_id, " +
                      "tab_condicion.con_nombre, " +
                      "tab_contratocondicion.ccn_mesiniexp, " +
                      "tab_contratocondicion.ccn_anioiniexp, " +
                      "tab_contratocondicion.ccn_mesfin, " +
                      "tab_contratocondicion.ccn_aniofin, " +
                      "tab_contratocondicion.ccn_diasdifer, " +
                      "tab_contratocondicion.ccn_valorb, " +
                      "tab_simbolo.sim_simbolo " +
                      "FROM " +
                      "tab_condicion " +
                      "INNER JOIN tab_contratocondicion ON tab_condicion.con_id = tab_contratocondicion.con_id " +
                      "LEFT JOIN tab_simbolo ON tab_contratocondicion.sim_id = tab_simbolo.sim_id " +
                      "WHERE tab_contratocondicion.ccn_estado = 1 " +
                      " AND tab_contratocondicion.ctt_id = " + ctt_id +
                      " AND tab_contratocondicion.con_id = " + con_id +
                      " ORDER BY tab_condicion.con_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    ContratoCondicion contratocondicion = new ContratoCondicion();
                    contratocondicion.Ccn_id = System.Convert.ToInt64(rs.Fields["ccn_id"].Value);
                    contratocondicion.Ctt_id = System.Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratocondicion.Con_id = System.Convert.ToInt64(rs.Fields["con_id"].Value);
                    contratocondicion.Sim_id = System.Convert.ToInt64(rs.Fields["sim_id"].Value);
                    contratocondicion.Con_nombre = System.Convert.ToString(rs.Fields["con_nombre"].Value);
                    //contratocondicion.Ccn_iniexp = System.Convert.ToDateTime(rs.Fields["ccn_iniexp"].Value);
                    contratocondicion.Ccn_mesiniexp = System.Convert.ToInt32(rs.Fields["ccn_mesiniexp"].Value);
                    contratocondicion.Ccn_anioiniexp = System.Convert.ToInt32(rs.Fields["ccn_anioiniexp"].Value);
                    contratocondicion.Ccn_mesfin = System.Convert.ToInt32(rs.Fields["ccn_mesfin"].Value);
                    contratocondicion.Ccn_aniofin = System.Convert.ToInt32(rs.Fields["ccn_aniofin"].Value);
                    //contratocondicion.Ccn_tiempodur = System.Convert.ToDateTime(rs.Fields["ccn_tiempodur"].Value);
                    contratocondicion.Ccn_diasdifer = System.Convert.ToInt32(rs.Fields["ccn_diasdifer"].Value);
                    contratocondicion.Ccn_valorb = System.Convert.ToDecimal(rs.Fields["ccn_valorb"].Value);
                    contratocondicion.Sim_simbolo = System.Convert.ToString(rs.Fields["sim_simbolo"].Value);
                    lstCondicion.Add(contratocondicion);
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
        public bool ValCondicion(long ctt_id, long con_id)
        {
            String where = (ctt_id != 0 ? ("AND tab_contratocondicion.ctt_id=" + ctt_id + " ") : " ");
            bool valida = false;
            bool valida2 = false;
            Int64 con_id_aux = 0;
            int cont = 0;
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_contratocondicion.ccn_id, " +
                    "tab_contratocondicion.con_id " +
                      "FROM " +
                      "tab_contratocondicion " +
                      "WHERE tab_contratocondicion.ccn_estado = 1 " +
                      where +
                      " ORDER BY tab_contratocondicion.con_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                if (rs.RecordCount == 0 && con_id == 1)
                {
                    valida = true;
                }
                while (!rs.EOF)
                {
                    con_id_aux = System.Convert.ToInt64(rs.Fields["con_id"].Value);
                    if (con_id == 1 && cont == 0)
                    {
                        if (con_id_aux == 1)
                        {
                            valida = false;
                        }
                        else
                        {
                            valida = true;
                        }
                    }
                    if (con_id == 2 && cont == 0)
                    {
                        if (con_id_aux == 1)
                        {
                            valida2 = true;
                            valida = true;
                        }

                    }
                    if (con_id == 2 && cont != 0)
                    {
                        if (valida2)
                        {
                            if (con_id_aux == 2)
                            {
                                valida = false;
                            }
                            else
                            {
                                valida = true;
                            }

                        }
                        else
                        {
                            valida = false;
                        }
                    }
                    rs.MoveNext();
                    cont++;
                }
                rs.Close();
                Connection_Off(1);
                return valida;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return false;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
