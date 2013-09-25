using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TipoColumna:Bd
    {
        private long tco_id;
        private string tco_codigo;
        private string tco_nombre;
        private long tco_estado;


        public TipoColumna() { }


        /// <summary>
        /// Constructor Tipo costo con paso de parametrso
        /// </summary>
        /// <param name="tco_id">Id</param>
        /// <param name="tco_codigo">Codigo </param>
        /// <param name="tco_nombre">Nombre</param>
        /// <param name="tco_estado">Estado</param>
        public TipoColumna(long tco_id, string tco_codigo, string tco_nombre,
            long tco_estado)
        {
            this.tco_id = tco_id;
            this.tco_codigo = tco_codigo;
            this.tco_nombre = tco_nombre;
            this.tco_estado = tco_estado;
        }



        public long Tco_id
        {
            get { return tco_id; }
            set { tco_id = value; }
        }


        public string Tco_codigo
        {
            get { return tco_codigo; }
            set { tco_codigo = value; }
        }


        public string Tco_nombre
        {
            get { return tco_nombre; }
            set { tco_nombre = value; }
        }


        public long Tco_estado
        {
            get { return tco_estado; }
            set { tco_estado = value; }
        }

        
    }
}
