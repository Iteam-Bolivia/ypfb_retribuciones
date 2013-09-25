using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class SimboloObject : Simbolo
    {
        /// <summary>
        /// listSimbolo Method
        /// </summary>
        public List<Simbolo> listSimbolo(long sim_id)
        {
            String where = (sim_id != 0 ? ("AND tab_simbolo.sim_id=" + sim_id + " ") : " ");
            List<Simbolo> lstSimbolo = new List<Simbolo>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_simbolo.sim_id, " +
                    "tab_simbolo.sim_simbolo " +
                      "FROM " +
                      "tab_simbolo " +
                      "WHERE tab_simbolo.sim_estado = 1 " +
                      where +
                      " ORDER BY tab_simbolo.sim_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Simbolo Simbolo = new Simbolo();

                    Simbolo.Sim_id = System.Convert.ToInt64(rs.Fields["sim_id"].Value);
                    Simbolo.Sim_simbolo = System.Convert.ToString(rs.Fields["sim_simbolo"].Value);

                    lstSimbolo.Add(Simbolo);
                    rs.MoveNext();
                }
                rs.Close();
                Connection_Off(1);
                return lstSimbolo;
            }
            catch (COMException err)
            {
                rs.Close();
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstSimbolo;
            }
            finally
            {
                Connection_Off(1);
            }
        }
    }
}
