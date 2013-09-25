using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Model
{
    public class ContratoCampoObject:Contrato_Campo
    {
        /// <summary>
        /// Verifico si existe el contrato campo
        /// </summary>
        /// <param name="ctt_id">Contrato Id</param>
        /// <returns>Retorna true si existe y falso si no existe</returns>
        public bool existContratoCampo(long ctt_id)
        {
            bool flag = false;
            try
            {
                Connection_On();
                SQL = "SELECT ctt_id FROM tab_contrato WHERE ctt_id='" + ctt_id + "'";

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
        }/* Method existContratoCampo */



        /// <summary>
        /// Lista de Contratos mas campos por contrato id
        /// </summary>
        /// <param name="ctc_id">Contrato Id</param>
        /// <returns>Lista de contratos mas campos</returns>
        public List<Contrato_Campo> listContratoCampo(long ctc_id)
        {
            String where = (ctc_id != 0 ? ("AND ctc_id = " + ctc_id + "") : "");
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();

            try
            {
                Connection_On();
                SQL = "SELECT ctc_id, ctt_id, A.cam_id, cam_nombre, " +
                    "ctc_estado " +
                    "FROM tab_contrato_campo A " +
                    "INNER JOIN tab_campo B "+
                    "ON A.cam_id = B.cam_id "+
                    "WHERE ctc_estado = 1 " +
                    where;
                SQL += " ORDER BY 1";

                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    // Fill data List

                    Contrato_Campo contratoCampo = new Contrato_Campo();
                    contratoCampo.Ctc_id = System.Convert.ToInt64(rs.Fields["ctc_id"].Value);
                    contratoCampo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratoCampo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    contratoCampo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    contratoCampo.Ctc_estado = System.Convert.ToInt64(rs.Fields["ctc_estado"].Value);

                    //ContratoObject contratoObject = new ContratoObject();
                    //List<Contrato> contrato = new List<Contrato>();
                    //contrato = contratoObject.listContrato(System.Convert.ToInt64(rs.Fields["ctt_id"].Value));
                    //List<Campo> campo= new List<Campo>();
                    //CampoObject campoObject = new CampoObject();
                    //campo = campoObject.listCampo(System.Convert.ToInt64(rs.Fields["cam_id"].Value));

                    //Cargo datos del campo
                    //contratoCampo.Cam = new Campo();
                    ////contratoCampo.Cam.Ctt_id = campo[0].Ctt_id;
                    //contratoCampo.Cam.Cam_id = campo[0].Cam_id;
                    //contratoCampo.Cam.Cam_codigo = campo[0].Cam_codigo;
                    //contratoCampo.Cam.Cam_nombre = campo[0].Cam_codigo;
                    //contratoCampo.Cam.Cam_estado = campo[0].Cam_estado;


                    ///cargo campos del contrato
                    //contratoCampo.Ctt = new Contrato();
                    //contratoCampo.Ctt.Ctt_id = contrato[0].Ctt_id;
                    //contratoCampo.Ctt.Ctt_codigo = contrato[0].Ctt_codigo;
                    //contratoCampo.Ctt.Ctt_estado = contrato[0].Ctt_estado;
                    //contratoCampo.Ctt.Ctt_nombre = contrato[0].Ctt_nombre;
                    //contratoCampo.Ctt.Ctt_periodo = contrato[0].Ctt_periodo;

                    //cargo a la lista e envio los datos
                    lstContratoCampo.Add(contratoCampo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContratoCampo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContratoCampo;
            }
        }/* Method listMenu */


        public List<Contrato_Campo> listaCamposPorContrato(long ctt_id)
        {
            string Where = (ctt_id != 0 ? ("AND tab_contrato_campo.ctt_id = " + ctt_id) : "");
            List<Contrato_Campo> lstCampoContrato = new List<Contrato_Campo>();
            try
            {
                Connection_On();
                SQL = "SELECT tab_campo.cam_nombre, tab_contrato_campo.ctc_id, tab_campo.cam_id " +
                    "FROM tab_campo " +
                    "Inner Join tab_contrato_campo ON tab_campo.cam_id = tab_contrato_campo.cam_id " +
                    "WHERE ctc_estado = 1 " +
                    "AND cam_estado = 1 " +
                    Where +
                    " ORDER BY 2";

                rs2.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic);
                while (!rs2.EOF)
                {
                    Contrato_Campo campo = new Contrato_Campo();
                    campo.Ctc_id = Convert.ToInt64(rs2.Fields["ctc_id"].Value);
                    //campo.Cam = new Campo();
                    campo.Cam_id = Convert.ToInt64(rs2.Fields["cam_id"].Value);
                    campo.Cam_nombre = Convert.ToString(rs2.Fields["cam_nombre"].Value);
                    lstCampoContrato.Add(campo);
                    rs2.MoveNext();
                }
                Connection_Off(2);
                return lstCampoContrato;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(2);
                return lstCampoContrato;
            }
        }


        public List<Contrato_Campo> listContratoCamposPorContrato(long ctt_id)
        {
            List<Contrato_Campo> lstContratoCampo = new List<Contrato_Campo>();
            String where = (ctt_id != 0 ? ("AND A.ctt_id=" + ctt_id + "") : "");
            try
            {
                Connection_On();
                //SQL = "SELECT tab_campo.cam_id, tab_bloque.blo_nombre, tab_campo.cam_codigo, tab_campo.cam_nombre, tab_campo.cam_estado, tab_campo.blo_id " +
                //          "FROM tab_campo " +
                //          "Inner Join tab_contrato_campo ON tab_contrato_campo.cam_id = tab_campo.cam_id " +
                //          "Inner Join tab_bloque ON tab_campo.blo_id = tab_bloque.blo_id " +
                //          "WHERE cam_estado = 1 " +
                //          "AND blo_estado = 1 " +
                //          "AND ctc_estado = 1 " +
                //          where;


                SQL = "SELECT ctc_id, A.ctt_id, A.cam_id, B.cam_nombre, ctc_estado ";
                SQL += "FROM tab_contrato_campo A ";
                SQL += "INNER JOIN tab_campo B ON A.cam_id = B.cam_id ";
                SQL += "INNER JOIN tab_contrato C ON A.ctt_id = C.ctt_id ";
                //SQL += "WHERE cam_estado = 1 ";
                SQL += "AND ctc_estado = 1 ";
                SQL += where;
                SQL += " ORDER BY 1";
                // Execute the query specifying static sursor, batch optimistic locking
                rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
                while (!rs.EOF)
                {
                    //Campo campo = new Campo();
                    //campo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    //campo.Blo = new Bloque();
                    //campo.Blo.Blo_nombre = Convert.ToString(rs.Fields["blo_nombre"].Value);
                    //campo.Blo_nombre = Convert.ToString(rs.Fields["blo_nombre"].Value);
                    //campo.Cam_codigo = Convert.ToString(rs.Fields["cam_codigo"].Value);
                    //campo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    //campo.Cam_estado = Convert.ToInt32(rs.Fields["cam_estado"].Value);

                    //Nuevo

                    Contrato_Campo contratoCampo = new Contrato_Campo();
                    contratoCampo.Ctc_id = Convert.ToInt64(rs.Fields["ctc_id"].Value);
                    //contratoCampo.Ctt = new Contrato();
                    //contratoCampo.Ctt.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    //contratoCampo.Cam = new Campo();
                    contratoCampo.Ctt_id = Convert.ToInt64(rs.Fields["ctt_id"].Value);
                    contratoCampo.Cam_id = Convert.ToInt64(rs.Fields["cam_id"].Value);
                    contratoCampo.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"].Value);
                    //contratoCampo.Cam.Cam_id = Convert.ToInt64(rs.Fields["cam_id"]);
                    //contratoCampo.Cam.Cam_nombre = Convert.ToString(rs.Fields["cam_nombre"]);
                    contratoCampo.Ctc_estado = Convert.ToInt32(rs.Fields["ctc_estado"].Value);

                    //Adicionar Lista de Productos asociados al campo

                    //List<CampoProducto> campoProducto = new List<CampoProducto>();
                    //CampoProductoObject objCampoProducto = new CampoProductoObject();
                    //campoProducto = objCampoProducto.listaProductosPorCampo(contratoCampo.Cam_id);

                    List<Campo_Producto_Mercado> lstCampoProductoMercado = new List<Campo_Producto_Mercado>();
                    CampoProductoMercadoObject objCampoProductoMercado = new CampoProductoMercadoObject();
                    lstCampoProductoMercado = objCampoProductoMercado.listCampoProductoMercadoNombresPorCampo(contratoCampo.Cam_id);

                    foreach (Campo_Producto_Mercado item in lstCampoProductoMercado)
                    {
                        //contratoCampo.Lista_Productos += item.Pro.Pro_nombre + ", ";
                        contratoCampo.Lista_Productos += item.Pro_nombre + ", ";
                        contratoCampo.Lista_Mercados += item.Mer_nombre + ", ";
                    }

                    if (!string.IsNullOrEmpty(contratoCampo.Lista_Productos))
                    {
                        contratoCampo.Lista_Productos = contratoCampo.Lista_Productos.Substring(0, contratoCampo.Lista_Productos.Length - 2);
                    }

                    if (!string.IsNullOrEmpty(contratoCampo.Lista_Mercados))
                        contratoCampo.Lista_Mercados = contratoCampo.Lista_Mercados.Substring(0, contratoCampo.Lista_Mercados.Length - 2);


                    lstContratoCampo.Add(contratoCampo);
                    rs.MoveNext();
                }
                Connection_Off(1);
                return lstContratoCampo;
            }
            catch (COMException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Connection_Off(1);
                return lstContratoCampo;
            }
        }
    }
}
