using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Mes:Bd
    {
        private long mes_id;
        private string mes_codigo;
        private string mes_nombre;
        private long mes_estado;


        public Mes() { }

        /// <summary>
        /// Constructor Mesartamente
        /// </summary>
        /// <param name="mes_id">Mes_id</param>
        /// <param name="mes_codigo">Mes_codigo</param>
        /// <param name="mes_nombre">Mes_nombre</param>
        /// <param name="mes_estado">Mes_estado</param>
        public Mes(long mes_id, string mes_codigo, string mes_nombre,long mes_estado)
        {
            this.mes_id = mes_id;
            this.mes_codigo = mes_codigo;
            this.mes_nombre = mes_nombre;
            this.mes_estado = mes_estado;
        }

        public long Mes_id
        {
            get { return mes_id; }
            set { mes_id = value; }
        }
        public string Mes_codigo
        {
          get { return mes_codigo; }
          set { mes_codigo = value; }
        }
        public string Mes_nombre
        {
          get { return mes_nombre; }
          set { mes_nombre = value; }
        }
        public long Mes_estado
        {
          get { return mes_estado; }
          set { mes_estado = value; }
        }

    }
}
