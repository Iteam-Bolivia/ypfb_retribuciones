using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Bloque : Bd
    {
        private long blo_id;
        private string blo_codigo;
        private string blo_nombre;
        private long blo_estado;

        public Bloque()
        { }

        /// <summary>
        /// Constructor Bloque
        /// </summary>
        /// <param name="blo_id">Blo_id</param>
        /// <param name="blo_codigo">Blo_Codigo</param>
        /// <param name="blo_nombre">Blo_nombre</param>
        /// <param name="blo_estado">Blo_estado</param>
        public Bloque(long blo_id, string blo_codigo, string blo_nombre,
            long blo_estado)
        {
            this.Blo_id = blo_id;
            this.Blo_codigo = blo_codigo;
            this.Blo_nombre = blo_nombre;
            this.Blo_estado = blo_estado;
        }



        public long Blo_id
        {
            get { return blo_id; }
            set { blo_id = value; }
        }



        public string Blo_codigo
        {
            get { return blo_codigo; }
            set { blo_codigo = value; }
        }



        public string Blo_nombre
        {
            get { return blo_nombre; }
            set { blo_nombre = value; }
        }



        public long Blo_estado
        {
            get { return blo_estado; }
            set { blo_estado = value; }
        }

    }
}
