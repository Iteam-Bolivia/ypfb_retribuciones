using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Pagina:Bd
    {
        private long pag_id;
        private Menus men_id;
        private string pag_nombre;
        private int pag_estado;

        public Pagina()
        {
        }

        /// <summary>
        /// Constructor Pagina Menu
        /// </summary>
        /// <param name="page_id">page_id</param>
        /// <param name="men_id">menu</param>
        /// <param name="pag_nombre">pag_nombre</param>
        /// <param name="pag_estado">pag_estado</param>
        public Pagina(long page_id, Menus men_id, string pag_nombre,
            int pag_estado)
        {
            this.Pag_id = pag_id;
            this.Men_id = men_id;
            this.Pag_nombre = pag_nombre;
            this.Pag_estado = pag_estado;
        }


        /// <summary>
        /// Constructor Pagina
        /// </summary>
        /// <param name="page_id">page_id</param>
        /// <param name="men_id">menu</param>
        /// <param name="pag_nombre">pag_nombre</param>
        /// <param name="pag_estado">pag_estado</param>
        public Pagina(long page_id, string pag_nombre, int pag_estado)
        {
            this.Pag_id = pag_id;
            this.Pag_nombre = pag_nombre;
            this.Pag_estado = pag_estado;
        }


        public int Pag_estado
        {
            get { return pag_estado; }
            set { pag_estado = value; }
        }


        public string Pag_nombre
        {
            get { return pag_nombre; }
            set { pag_nombre = value; }
        }


        public Menus Men_id
        {
            get { return men_id; }
            set { men_id = value; }
        }


        public long Pag_id
        {
            get { return pag_id; }
            set { pag_id = value; }
        }

    }
}
