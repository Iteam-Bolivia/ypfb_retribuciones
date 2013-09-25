using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;

namespace Model
{
    public class BloqueObject : Bloque
    {
        /// <summary>
        /// existBloque Method
        /// </summary>
        public bool existBloque(long blo_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT blo_id FROM tab_bloque WHERE blo_id='" + blo_id + "'";

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
            catch (DBConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia:" + ex.Message);
            }
            catch (COMException err)
            {
                Connection_Off(1);
                Console.WriteLine("Error: " + err.Message);
                flag = false;
                return flag;
            }
        }/* Method existUser */

        /// <summary>
        /// listBloque Method
        /// </summary>
        public List<Bloque> listBloque(long blo_id)
        {
            String where = (blo_id != 0 ? ("AND blo_id=" + blo_id + "") : "");
            List<Bloque> lstBloque = new List<Bloque>();

            try
            {
                Connection_On();
                SQL = "SELECT blo_id, blo_codigo, blo_nombre, blo_estado " +
                          "FROM tab_bloque " +
                          "WHERE blo_estado = 1 " +
                          where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List
                    lstBloque.Add(new Bloque(System.Convert.ToInt64(rs.Fields["blo_id"].Value),
                        (string)rs.Fields["blo_codigo"].Value,
                        (string)rs.Fields["blo_nombre"].Value,
                        System.Convert.ToInt32(rs.Fields["blo_estado"].Value)));
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstBloque;
            }
            catch (DBConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia:" + ex.Message);
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstBloque;
            }
        }/* Method listMenu */
        public List<Bloque> listBloqueSegunCriterio(string blo_codigo, string blo_nombre)
        {
            List<Bloque> lstBloque = new List<Bloque>();
            try
            {
                Connection_On();
                SQL = "SELECT blo_id, blo_codigo, blo_nombre, blo_estado ";
                SQL += "FROM tab_bloque ";
                SQL += "WHERE blo_codigo LIKE '%" + blo_codigo + "%' ";
                SQL += "AND blo_nombre LIKE '%" + blo_nombre + "%' ";
                SQL += " ORDER BY 1";

                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

                while (!rs.EOF)
                {
                    Bloque bloque = new Bloque();
                    bloque.Blo_id = Convert.ToInt64(rs.Fields["blo_id"].Value);
                    bloque.Blo_codigo = Convert.ToString(rs.Fields["blo_codigo"].Value);
                    bloque.Blo_nombre = Convert.ToString(rs.Fields["blo_nombre"].Value);
                    bloque.Blo_estado = Convert.ToInt32(rs.Fields["blo_estado"].Value);
                    lstBloque.Add(bloque);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstBloque;
            }
            catch (DBConcurrencyException ex)
            {
                throw new Exception("Error de concurrencia:" + ex.Message);
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstBloque;
            }
        }
    }
}