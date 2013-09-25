using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Tipo_Proyeccion:Bd
    {
        private long tpy_id;
        private string tpy_codigo;
        private string tpy_nombre;
        private int tpy_estado;

        public Tipo_Proyeccion()
        {
        }

        /// <summary>
        /// Constructor de titular
        /// </summary>
        /// <param name="tpy_id">tpy_id</param>
        /// <param name="suc_id">suc_id</param>
        /// <param name="tpy_codigo">tpy_codigo</param>
        /// <param name="tpy_nombre">tpy_nombre</param>
        /// <param name="tpy_estado">tpy_estado</param>
        public Tipo_Proyeccion(long tpy_id, string tpy_codigo, string
            tpy_nombre, int tpy_estado)
        {
            this.tpy_id = tpy_id;
            this.tpy_codigo = tpy_codigo;
            this.tpy_nombre = tpy_nombre;
            this.tpy_estado = tpy_estado;
        }

        
        public long Tpy_id
        {
            get { return tpy_id; }
            set { tpy_id = value; }
        }




        public string Tpy_codigo
        {
            get { return tpy_codigo; }
            set { tpy_codigo = value; }
        }




        public string Tpy_nombre
        {
            get { return tpy_nombre; }
            set { tpy_nombre = value; }
        }



        public int Tpy_estado
        {
            get { return tpy_estado; }
            set { tpy_estado = value; }
        }
    }
}
