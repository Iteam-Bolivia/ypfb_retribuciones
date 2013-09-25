/*
 * @author Diego Calderon
 * User Class
 * Created on 28 de Septiembre de 2012
 */



namespace Model
{
   public class Condicion : Bd
    {
        private long con_id;
        private string con_nombre;


        /// <summary>
        /// Method ccn_id
        /// </summary>
        public Condicion()
        {
        }

        /// <summary>
        /// Method ccnario
        /// </summary>
        public Condicion(long con_id, string con_nombre)
        {
            this.con_id = con_id;
            this.con_nombre = con_nombre;
        }

        /// <summary>
        /// Method con_id
        /// </summary>
        public long Con_id
        {
            get { return con_id; }
            set { con_id = value; }
        }

        /// <summary>
        /// Method con_nombre
        /// </summary>
        public string Con_nombre
        {
            get { return con_nombre; }
            set { con_nombre = value; }
        }

 
    }
}
