/*
 * @author acastellon
 * Menu Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

namespace Model
{
    /// <summary>
    /// Class Menu
    /// </summary>
    public class Menus : Bd
    {
        private long men_id;
        private long men_par;
        private string men_par_name;
        private string men_titulo;
        private string men_enlace;
        private string men_posicion;
        private string men_imagen;
        private long men_estado;

        /// <summary>
        /// Constructor Class Menu
        /// </summary>
        public Menus()
        {
        }/* End Constructor Menu */

        /// <summary>
        /// Constructor Class Menu
        /// </summary>
        public Menus(long men_id, long men_par, string men_titulo, string men_enlace, string men_posicion, string men_imagen, long men_estado)
        {
            this.men_id = men_id;
            this.men_par = men_par;
            this.men_titulo = men_titulo;
            this.men_enlace = men_enlace;
            this.men_posicion = men_posicion;
            this.men_imagen = men_imagen;
            this.men_estado = men_estado;
        }

        /// <summary>
        /// Constructor Class Menu for view in grid
        /// </summary>
        public Menus(long men_id, string men_par_name, string men_titulo, string men_enlace, string men_posicion, string men_imagen, long men_estado)
        {
            this.men_id = men_id;
            this.men_par_name = men_par_name;
            this.men_titulo = men_titulo;
            this.men_enlace = men_enlace;
            this.men_posicion = men_posicion;
            this.men_imagen = men_imagen;
            this.men_estado = men_estado;
        }        

        /// <summary>
        /// Method Men_id
        /// </summary>
        public long Men_id
        {
            get { return men_id; }
            set { men_id = value; }
        }

        /// <summary>
        /// Method Men_par
        /// </summary>
        public long Men_par
        {
            get { return men_par; }
            set { men_par = value; }
        }

        /// <summary>
        /// Method Men_titulo
        /// </summary>
        public string Men_titulo
        {
            get { return men_titulo; }
            set { men_titulo = value; }
        }

        /// <summary>
        /// Method Men_enlace
        /// </summary>
        public string Men_enlace
        {
            get { return men_enlace; }
            set { men_enlace = value; }
        }

        /// <summary>
        /// Method Men_posicion
        /// </summary>
        public string Men_posicion
        {
            get { return men_posicion; }
            set { men_posicion = value; }
        }

        /// <summary>
        /// Method Men_imagen
        /// </summary>
        public string Men_imagen
        {
            get { return men_imagen; }
            set { men_imagen = value; }
        }

        /// <summary>
        /// Method Men_estado
        /// </summary>
        public long Men_estado
        {
            get { return men_estado; }
            set { men_estado = value; }
        }

        /// <summary>
        /// Method Men_estado
        /// </summary>
        public string Men_par_name
        {
            get { return men_par_name; }
            set { men_par_name = value; }
        }


        private bool menu_visible;
        public bool Menu_visible
        {
            get { return menu_visible; }
            set { menu_visible = value; }
        }
    }
}