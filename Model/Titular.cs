using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Titular:Bd
    {
        private long tit_id;
        private string tit_codigo;
        private string tit_nombre;
        private int tit_estado;
        private int tit_orden;


        public Titular()
        {
        }

        /// <summary>
        /// Constructor de titular
        /// </summary>
        /// <param name="tit_id">tit_id</param>
        /// <param name="suc_id">suc_id</param>
        /// <param name="tit_codigo">tit_codigo</param>
        /// <param name="tit_nombre">tit_nombre</param>
        /// <param name="tit_estado">tit_estado</param>
        public Titular(long tit_id, string tit_codigo, string tit_nombre, int tit_estado, int tit_orden)
        {
            this.tit_id = tit_id;
            this.tit_codigo = tit_codigo;
            this.tit_nombre = tit_nombre;
            this.tit_estado = tit_estado;
            this.tit_orden = tit_orden;
        }

        
        public long Tit_id
        {
            get { return tit_id; }
            set { tit_id = value; }
        }




        public string Tit_codigo
        {
            get { return tit_codigo; }
            set { tit_codigo = value; }
        }




        public string Tit_nombre
        {
            get { return tit_nombre; }
            set { tit_nombre = value; }
        }



        public int Tit_estado
        {
            get { return tit_estado; }
            set { tit_estado = value; }
        }

        public int Tit_orden
        {
          get { return tit_orden; }
          set { tit_orden = value; }
        }


    }
}
