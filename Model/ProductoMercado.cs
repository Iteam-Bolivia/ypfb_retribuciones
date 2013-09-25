using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProductoMercado:Bd
    {
        private long cae_id;
        private Producto pro;
        private List<Producto> listPro;
        private Mercado mer;
        private List<Mercado> listMer;
        private Moneda mon;


        public ProductoMercado() { }


        /// <summary>
        /// Constructor Producto Mercado
        /// </summary>
        /// <param name="cae_id">Codigo </param>
        /// <param name="pro">Productos</param>
        /// <param name="mer">Mercados</param>
        /// <param name="mon">Moneda</param>
        public ProductoMercado(long cae_id, Producto pro, Mercado mer, Moneda mon)
        {
            this.cae_id = cae_id;
            this.pro = pro;
            this.mer = mer;
            this.mon = mon;
        }



        public long Cae_id
        {
            get { return cae_id; }
            set { cae_id = value; }
        }



        public Producto Pro
        {
            get { return pro; }
            set { pro = value; }
        }



        public List<Producto> ListPro
        {
            get { return listPro; }
            set { listPro = value; }
        }



        public Mercado Mer
        {
            get { return mer; }
            set { mer = value; }
        }



        public List<Mercado> ListMer
        {
            get { return listMer; }
            set { listMer = value; }
        }



        public Moneda Mon
        {
            get { return mon; }
            set { mon = value; }
        }
    }
}
