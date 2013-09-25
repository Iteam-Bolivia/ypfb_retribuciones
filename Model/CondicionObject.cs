using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class CondicionObject : Condicion
    {
        /// <summary>
        /// listCondicion Method
        /// </summary>
        public List<Condicion> listCondicion(long con_id)
        {
            String where = (con_id != 0 ? ("AND tab_condicion.con_id=" + con_id + " ") : " ");
            List<Condicion> lstCondicion = new List<Condicion>();
            try
            {
                Connection_On();
                SQL = "SELECT " +
                    "tab_condicion.con_id, " +
                    "tab_condicion.con_nombre " +
                      "FROM " +
                      "tab_condicion " +
                      "WHERE tab_condicion.con_estado = 1 " +
                      where +
                      " ORDER BY tab_condicion.con_id";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Condicion condicion = new Condicion();

                    condicion.Con_id = System.Convert.ToInt64(rs.Fields["con_id"].Value);
                    condicion.Con_nombre = System.Convert.ToString(rs.Fields["con_nombre"].Value);

                    lstCondicion.Add(condicion);
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
