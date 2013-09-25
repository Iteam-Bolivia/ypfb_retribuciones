using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Departamento:Bd
    {
        private long dep_id;
        private string dep_codigo;
        private string dep_nombre;
        private long dep_estado;


        public Departamento() { }

        /// <summary>
        /// Constructor Departamente
        /// </summary>
        /// <param name="dep_id">Dep_id</param>
        /// <param name="dep_codigo">Dep_codigo</param>
        /// <param name="dep_nombre">Dep_nombre</param>
        /// <param name="dep_estado">Dep_estado</param>
        public Departamento(long dep_id, string dep_codigo, string dep_nombre,long dep_estado)
        {
            this.dep_id = dep_id;
            this.dep_codigo = dep_codigo;
            this.dep_nombre = dep_nombre;
            this.dep_estado = dep_estado;
        }

        public long Dep_id
        {
            get { return dep_id; }
            set { dep_id = value; }
        }
        public string Dep_codigo
        {
          get { return dep_codigo; }
          set { dep_codigo = value; }
        }
        public string Dep_nombre
        {
          get { return dep_nombre; }
          set { dep_nombre = value; }
        }
        public long Dep_estado
        {
          get { return dep_estado; }
          set { dep_estado = value; }
        }

    }
}
