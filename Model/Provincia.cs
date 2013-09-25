using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Provincia:Bd
    {
        private long pro_id;
        private long dep_id;
        private string pro_codigo;
        private string pro_nombre;
        private long pro_estado;

      //
        private string dep_nombre;
      //

        public Provincia() { }


        /// <summary>
        /// Constructor Provincia
        /// </summary>
        /// <param name="pro_id">Pro_id</param>
        /// <param name="dep_id">Dep_id</param>
        /// <param name="pro_codigo">Pro_Codigo</param>
        /// <param name="pro_nombre">pro_nombre</param>
        /// <param name="pro_estado">Pro_estado</param>
        public Provincia(long pro_id, long dep_id, string pro_codigo,
            string pro_nombre, long pro_estado)
        {
            this.pro_id = pro_id;
            this.dep_id = dep_id;
            this.pro_codigo = pro_codigo;
            this.pro_nombre = pro_nombre;
            this.pro_estado = pro_estado;
        }
        public long Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }

        public long Dep_id
        {
          get { return dep_id; }
          set { dep_id = value; }
        }

        public string Pro_codigo
        {
          get { return pro_codigo; }
          set { pro_codigo = value; }
        }

        public string Pro_nombre
        {
          get { return pro_nombre; }
          set { pro_nombre = value; }
        }

        public long Pro_estado
        {
          get { return pro_estado; }
          set { pro_estado = value; }
        }

        public string Dep_nombre
        {
          get { return dep_nombre; }
          set { dep_nombre = value; }
        }

    }
}
