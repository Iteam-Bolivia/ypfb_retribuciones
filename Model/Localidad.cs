using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Localidad:Bd
    {
        private long loc_id;
        private long pro_id;
        private string loc_codigo;
        private string loc_nombre;
        private long loc_estado;

        private string pro_nombre;


        public Localidad()
        { }

        /// <summary>
        /// constructor Localidad
        /// </summary>
        /// <param name="loc_id">Loc_id</param>
        /// <param name="pro_id">Pro_id</param>
        /// <param name="loc_codigo">Loc_codigo</param>
        /// <param name="loc_nombre">loc_nombre</param>
        /// <param name="loc_estado">Loc_estado</param>
        public Localidad(long loc_id, long pro_id, string loc_codigo,string loc_nombre, long loc_estado)
        {
          this.loc_id = loc_id;
          this.pro_id = pro_id;
          this.loc_codigo = loc_codigo;
          this.loc_nombre = loc_nombre;
          this.loc_estado = loc_estado;
            
            
        }

        public long Loc_id
        {
          get { return loc_id; }
          set { loc_id = value; }
        }
        
        public long Pro_id
        {
          get { return pro_id; }
          set { pro_id = value; }
        }

        public string Loc_codigo
        {
          get { return loc_codigo; }
          set { loc_codigo = value; }
        }

        public string Loc_nombre
        {
          get { return loc_nombre; }
          set { loc_nombre = value; }
        }

      public long Loc_estado
        {
            get { return loc_estado; }
            set { loc_estado = value; }
        }

      public string Pro_nombre
      {
        get { return pro_nombre; }
        set { pro_nombre = value; }
      }
    }
}
