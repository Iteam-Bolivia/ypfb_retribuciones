using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ypfbApplication.Controller
{
    public sealed class UnidadMedidaController
    {
        public void index()
        {
            //// Open List Usuario Form
            //frm objUsuarioLista = new frmUsuarioLista();
            //objUsuarioLista.Show();
        }

        public List<Unidad_Medida> load()
        {
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            UnidadMedidaObject objUnidadMedidaObject = new UnidadMedidaObject();
            lstUnidadMedida = objUnidadMedidaObject.listUnidadMedida(0);
            return lstUnidadMedida;
        }


        public void view()
        {
        }

        public void create()
        {
        }

        public void edit()
        {
        }

        public void save(List<Unidad_Medida> lstUnidadMedida)
        {
            // Save data from Usuario
            Unidad_Medida objUnidadMedida = new Unidad_Medida();
            objUnidadMedida.insert(lstUnidadMedida);
        }

        public void update(List<Unidad_Medida> lstUnidadMedida)
        {
            //string condition = "";
            // Update data from Usuario
            Unidad_Medida objUnidadMedida = new Unidad_Medida();
            //if (lstUnidadMedida.Count == 0)
            //{
            //}
            //else
            //{
            //    lstUnidadMedida.ForEach(delegate(UnidadMedida u)
            //    {
            //        condition = "idUsuario=" + u.Umd_id;
            //    });
            //}
            objUnidadMedida.update(lstUnidadMedida);
        }



        public List<Unidad_Medida> find()
        {
            long umd_id = 0;
            Session objSession = new Session();
            umd_id = objSession.ID;
            List<Unidad_Medida> lstUnidadMedida = new List<Unidad_Medida>();
            UnidadMedidaObject objUnidadMedidaObject = new UnidadMedidaObject();
            lstUnidadMedida = objUnidadMedidaObject.listUnidadMedida(umd_id);
            return lstUnidadMedida;
        }
        public static List<Unidad_Medida> GetListaUnidadMedidaPorProducto(long pro_id)
        {
            UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
            return objUnidadMedida.listaUnidadMedidaPorProducto(pro_id);
        }
        public static List<Unidad_Medida> GetListaUnidadMedida(long umd_id)
        {
            UnidadMedidaObject objUnidadMedida = new UnidadMedidaObject();
            return objUnidadMedida.listUnidadMedida(umd_id);
        }
    }
}