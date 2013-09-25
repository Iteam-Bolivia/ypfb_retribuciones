using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Usurolmenu:Bd
    {
        private long urm_id;
        private long rol_id;
        private long men_id;
        private string urm_privilegios;
        private long urm_estado;
   
        private Rol rol_id1;
        private Menus men_id1;

        public Usurolmenu()
        {
        }


        ///// <summary>
        ///// Constructor UsurolMenu
        ///// </summary>
        ///// <param name="urm_id">Urm_id</param>
        ///// <param name="urm_privilegios">urm_provolegios</param>
        ///// <param name="urm_estado">urm_estado</param>
        //public Usurolmenu(long urm_id,
        //    string urm_privilegios, long urm_estado)
        //{
        //    this.Urm_estado = urm_id;
        //    this.Urm_privilegios = urm_privilegios;
        //    this.Urm_estado = urm_estado;
        //}


        ///// <summary>
        ///// Constructor UsurolMenu Rol
        ///// </summary>
        ///// <param name="urm_id">Urm_id</param>
        ///// <param name="rol_id">rol_id</param>
        ///// <param name="urm_privilegios">urm_provolegios</param>
        ///// <param name="urm_estado">urm_estado</param>
        //public Usurolmenu(long urm_id, Rol rol_id, 
        //    string urm_privilegios, long urm_estado)
        //{
        //    this.Urm_estado = urm_id;
        //    this.Rol_id = rol_id;
        //    this.Urm_privilegios = urm_privilegios;
        //    this.Urm_estado = urm_estado;
        //}

        ///// <summary>
        ///// Constructor UsurolMenu Menu
        ///// </summary>
        ///// <param name="urm_id">Urm_id</param>
        ///// <param name="men_id">men_id</param>
        ///// <param name="urm_privilegios">urm_provolegios</param>
        ///// <param name="urm_estado">urm_estado</param>
        //public Usurolmenu(long urm_id, Menu men_id,
        //    string urm_privilegios, long urm_estado)
        //{
        //    this.Urm_estado = urm_id;
        //    this.Men_id = men_id;
        //    this.Urm_privilegios = urm_privilegios;
        //    this.Urm_estado = urm_estado;
        //}


        /// <summary>
        /// Constructor UsurolMenu Rol Menu
        /// </summary>
        /// <param name="urm_id">Urm_id</param>
        /// <param name="rol_id">Rol_id</param>
        /// <param name="men_id">men_id</param>
        /// <param name="urm_privilegios">urm_provolegios</param>
        /// <param name="urm_estado">urm_estado</param>
        public Usurolmenu(long urm_id, Rol rol_id, Menus men_id,
            string urm_privilegios, long urm_estado)
        {
            this.Urm_estado = urm_id;
            this.Rol_id1 = rol_id;
            this.Men_id1 = men_id;
            this.Urm_privilegios = urm_privilegios;
            this.Urm_estado = urm_estado;
        }
        public long Urm_id
        {
            get { return urm_id; }
            set { urm_id = value; }
        }
        public long Rol_id
        {
            get { return rol_id; }
            set { rol_id = value; }
        }
        public long Men_id
        {
            get { return men_id; }
            set { men_id = value; }
        }        
        public string Urm_privilegios
        {
            get { return urm_privilegios; }
            set { urm_privilegios = value; }
        }               
        public long Urm_estado
        {
            get { return urm_estado; }
            set { urm_estado = value; }
        }
        public Menus Men_id1
        {
            get { return men_id1; }
            set { men_id1 = value; }
        }
        public Rol Rol_id1
        {
            get { return rol_id1; }
            set { rol_id1 = value; }
        }
    }
}
