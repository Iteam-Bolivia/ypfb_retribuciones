using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class CampoProductoMercadoObject : Campo_Producto_Mercado
    {
        public bool existCampoProductoMercado(long cpm_id)
        {
            bool flag = false;
            try
            {
                cnn = Connection_On();
                SQL = "SELECT cpm_id FROM tab_campo_producto_mercado WHERE cpm_id='" + cpm_id + "'";

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
        //public List<Campo_Producto_Mercado> listCampoProductoMercado(long cpm_id)
        //{
        //    String where = (cpm_id != 0 ? ("AND cpm_id=" + cpm_id + "") : "");
        //    List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();

        //    try
        //    {
        //        Connection_On();
        //        SQL = "SELECT cpm_id, cam_id, pro_id, mer_id, cpm_preciocom " +
        //                  "FROM tab_campo_producto_mercado " +
        //                  WHERE //blo_estado = 1 " +
        //                  where;

        //        // Execute the query specifying static sursor, batch optimistic locking
        //        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        //        while (!rs.EOF)
        //        {
        //            // Fill data List
        //            lstCampoProductoMercado.Add(new Bloque(System.Convert.ToInt64(rs.Fields["blo_id"].Value),
        //                (string)rs.Fields["blo_codigo"].Value,
        //                (string)rs.Fields["blo_nombre"].Value,
        //                System.Convert.ToInt32(rs.Fields["blo_estado"].Value)));
        //            rs.MoveNext();
        //        }
        //        Connection_Off(1);
        //        return lstCampoProductoMercado;
        //    }
        //    catch (COMException err)
        //    {
        //        Console.WriteLine("Error: " + err.Message);
        //        Connection_Off(1);
        //        return lstCampoProductoMercado;
        //    }
        //}
        public List<Campo_Producto_Mercado> listCampoProductoMercado(long cpm_id)
        {
            string where = (cpm_id != 0 ? ("AND tab_campo_producto_mercado.cpm_id = " + cpm_id + "") : "");
            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            try
            {
                SQL = "SELECT tab_campo_producto_mercado.cpm_id, tab_campo_producto_mercado.cam_id, tab_campo.cam_nombre, tab_campo_producto_mercado.pro_id, tab_producto.pro_nombre, tab_mercado.mer_id, tab_mercado.mer_nombre, tab_campo_producto_mercado.cpm_preciocom ";
                SQL += "FROM tab_campo_producto_mercado ";
                SQL += "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id ";
                SQL += "INNER JOIN tab_mercado ON tab_campo_producto_mercado.mer_id = tab_mercado.mer_id ";
                SQL += "INNER JOIN tab_campo ON tab_campo_producto_mercado.cam_id = tab_campo.cam_id ";
                //SQL += "WHERE pro_estado = 1 ";
                //SQL += " AND mer_estado = 1 ";
                SQL += "WHERE " + where.Replace("AND", "");

                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Producto_Mercado campo = new Campo_Producto_Mercado();
                    campo.Cpm_id = Convert.ToInt64(rs.Fields["cpm_id"].Value);
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    campo.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    campo.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    campo.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    campo.Cpm_preciocom = Convert.ToString(rs.Fields["cpm_preciocom"].Value);
                    lstCampoProductoMercado.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
        }
        public List<Campo_Producto_Mercado> listCampoProductoMercadoPorCampo(long cam_id)
        {
            string where = (cam_id != 0 ? ("AND tab_campo_producto_mercado.cam_id=" + cam_id + "") : "");
            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            try
            {
                SQL = "SELECT tab_campo_producto_mercado.cpm_id, tab_campo_producto_mercado.cam_id, tab_campo.cam_nombre, tab_campo_producto_mercado.pro_id, tab_producto.pro_nombre, tab_mercado.mer_id, tab_mercado.mer_nombre, tab_campo_producto_mercado.cpm_preciocom, cpm_estado ";
                SQL += "FROM tab_campo_producto_mercado ";
                SQL += "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id ";
                SQL += "INNER JOIN tab_mercado ON tab_campo_producto_mercado.mer_id = tab_mercado.mer_id ";
                SQL += "INNER JOIN tab_campo ON tab_campo_producto_mercado.cam_id = tab_campo.cam_id ";
                SQL += "WHERE pro_estado = 1 ";
                SQL += " AND mer_estado = 1 ";
                SQL += " AND cpm_estado = 1 ";
                SQL += where;

                SQL += " ORDER BY 1";
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Producto_Mercado campo = new Campo_Producto_Mercado();
                    campo.Cpm_id = Convert.ToInt64(rs.Fields["cpm_id"].Value);
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    campo.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    campo.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    campo.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    campo.Cpm_preciocom = Convert.ToString(rs.Fields["cpm_preciocom"].Value);
                    campo.Cpm_estado = Convert.ToInt32(rs.Fields["cpm_estado"].Value);
                    lstCampoProductoMercado.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
        }

        public List<Campo_Producto_Mercado> listCampoProductoMercadoPorCampoProducto(long cam_id, long pro_id)
        {
            string where = (cam_id != 0 ? ("AND tab_campo_producto_mercado.cam_id = " + cam_id + " ") : " ");
            where += (pro_id != 0 ? ("AND tab_campo_producto_mercado.pro_id = " + pro_id + " ") : " ");
            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            try
            {
                SQL = "SELECT tab_campo_producto_mercado.cpm_id, tab_campo_producto_mercado.cam_id, tab_campo.cam_nombre, tab_campo_producto_mercado.pro_id, tab_producto.pro_nombre, tab_mercado.mer_id, tab_mercado.mer_nombre, tab_campo_producto_mercado.cpm_preciocom, cpm_estado ";
                SQL += "FROM tab_campo_producto_mercado ";
                SQL += "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id ";
                SQL += "INNER JOIN tab_mercado ON tab_campo_producto_mercado.mer_id = tab_mercado.mer_id ";
                SQL += "INNER JOIN tab_campo ON tab_campo_producto_mercado.cam_id = tab_campo.cam_id ";
                SQL += "WHERE pro_estado = 1 ";
                SQL += " AND mer_estado = 1 ";
                SQL += " AND cpm_estado = 1 ";
                SQL += where;

                SQL += " ORDER BY 1";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Producto_Mercado campo = new Campo_Producto_Mercado();
                    campo.Cpm_id = Convert.ToInt64(rs.Fields["cpm_id"].Value);
                    campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    campo.Pro_id = Convert.ToInt64(rs.Fields["pro_id"].Value);
                    campo.Pro_nombre = Convert.ToString(rs.Fields["pro_nombre"].Value);
                    campo.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    campo.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    campo.Cpm_preciocom = Convert.ToString(rs.Fields["cpm_preciocom"].Value);
                    campo.Cpm_estado = Convert.ToInt32(rs.Fields["cpm_estado"].Value);
                    lstCampoProductoMercado.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
        }


        public List<Campo_Producto_Mercado> ListaMercadosAsociadosPorCampoProducto(long cam_id, long pro_id)
        {
            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            try
            {
                SQL = "SELECT mer_id, mer_nombre, (CASE WHEN (SELECT B.mer_id FROM tab_campo_producto_mercado B WHERE A.mer_id = B.mer_id AND cpm_estado = 1 AND cam_id = " + cam_id + " AND pro_id = " + pro_id + ")> 0 THEN 1 ELSE 0 END) AS cpm_asociacion, ";
                SQL += "COALESCE((SELECT D.cpm_preciocom FROM tab_campo_producto_mercado D WHERE A.mer_id = D.mer_id AND cpm_estado = 1 AND cam_id = " + cam_id + " AND pro_id = " + pro_id + "), 0) AS cpm_preciocom ";
                SQL += "FROM tab_mercado A ";
                SQL += "WHERE mer_estado = 1 ";
                SQL += "ORDER BY 1 ";
                Connection_On();
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    Campo_Producto_Mercado campo = new Campo_Producto_Mercado();
                    campo.Mer_id = Convert.ToInt64(rs.Fields["mer_id"].Value);
                    campo.Mer_nombre = Convert.ToString(rs.Fields["mer_nombre"].Value);
                    campo.Cpm_asociacion = Convert.ToInt64(rs.Fields["cpm_asociacion"].Value);
                    campo.Cpm_preciocom = Convert.ToString(rs.Fields["cpm_preciocom"].Value);
                    lstCampoProductoMercado.Add(campo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstCampoProductoMercado;
            }
        }

        public List<Campo_Producto_Mercado> listCampoProductoMercadoNombresPorCampo(long cam_id)
        {
            string where = (cam_id != 0 ? ("AND tab_campo_producto_mercado.cam_id=" + cam_id + "") : "");
            List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
            try
            {
                SQL = "SELECT pro_nombre, mer_nombre ";
                SQL += "FROM tab_campo_producto_mercado ";
                SQL += "INNER JOIN tab_producto ON tab_producto.pro_id = tab_campo_producto_mercado.pro_id ";
                SQL += "INNER JOIN tab_mercado ON tab_campo_producto_mercado.mer_id = tab_mercado.mer_id ";
                SQL += "WHERE pro_estado = 1 ";
                SQL += " AND mer_estado = 1 ";
                SQL += " AND cpm_estado = 1";
                SQL += where;
                SQL += " ORDER BY 1";
                Connection_On();
                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs2.EOF)
                {
                    Campo_Producto_Mercado campo = new Campo_Producto_Mercado();
                    campo.Mer_nombre = Convert.ToString(rs2.Fields["mer_nombre"].Value);
                    campo.Pro_nombre = Convert.ToString(rs2.Fields["pro_nombre"].Value);
                    lstCampoProductoMercado.Add(campo);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstCampoProductoMercado;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstCampoProductoMercado;
            }
        }
    }
}