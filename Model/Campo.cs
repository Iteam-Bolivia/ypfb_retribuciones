using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Campo : Bd
    {
        private long cam_id;
        private long ctt_id;
        private string cam_codigo;
        private string cam_nombre;
        private long cam_estado;
        private string cas_nombre;
        private long blo_id;

        public Campo() { }

        /// <summary>
        /// Constructor Campo
        /// </summary>
        /// <param name="cam_id">Cam_id</param>
        /// <param name="bol_id">Bol_id</param>
        /// <param name="ctt_id">Ctt_id</param>
        /// <param name="cam_codigo">Cam_codigo</param>
        /// <param name="cam_nombre">Cam_nombre</param>
        /// <param name="cam_estado">Cam_estado</param>
        public Campo(long cam_id/*, long ctt_id*/, string cam_codigo,
            string cam_nombre, long cam_estado, long blo_id)
        {
            this.Cam_id = cam_id;
            //this.Ctt_id = ctt_id;
            this.Cam_codigo = cam_codigo;
            this.Cam_nombre = cam_nombre;
            this.Cam_estado = cam_estado;
            this.blo_id = blo_id;
        }


        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }


        public long Blo_id
        {
            get { return blo_id; }
            set { blo_id = value; }
        }


        public string Cam_codigo
        {
            get { return cam_codigo; }
            set { cam_codigo = value; }
        }



        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }



        public long Cam_estado
        {
            get { return cam_estado; }
            set { cam_estado = value; }
        }



        #region Campos Auxiliares
        private Bloque blo;

        public Bloque Blo
        {
            get { return blo; }
            set { blo = value; }
        }

        //private string blo_nombre;

        //public string Blo_nombre
        //{
        //    get { return blo_nombre; }
        //    set { blo_nombre = value; }
        //}

        private string lista_productos_mercado;

        public string Lista_productos_mercado
        {
            get { return lista_productos_mercado; }
            set { lista_productos_mercado = value; }
        }


        public string Cas_nombre
        {
            get { return cas_nombre; }
            set { cas_nombre = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }

        #endregion
    }
}