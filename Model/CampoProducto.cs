using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CampoProducto:Bd
    {
        private long cap_id;
        private Producto pro;
        private List<Producto> listPro;
        private Campo cam;


        public CampoProducto()
        { }

        /// <summary>
        /// construcor campo producto
        /// </summary>
        /// <param name="cap_id">cap_id</param>
        /// <param name="pro">producto</param>
        /// <param name="cam">campo</param>
        public CampoProducto(long cap_id, Producto pro, Campo cam)
        {
            this.cap_id = cap_id;
            this.pro = pro;
            this.cam = cam;
        }




        public long Cap_id
        {
            get { return cap_id; }
            set { cap_id = value; }
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



        public Campo Cam
        {
            get { return cam; }
            set { cam = value; }
        }
    }
}
