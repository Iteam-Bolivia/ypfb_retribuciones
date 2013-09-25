/*
 * @author acastellon
 * User Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

namespace Model
{
    /* Class User */
    public class Usuario : Bd
    {
        private long usu_id;
        private long suc_id;
        private long rol_id;
        private string usu_nombres;
        private string usu_apellidos;
        private string usu_iniciales;
        private string usu_fono;
        private string usu_email;
        private string usu_login;
        private string usu_pass;
        private long usu_intento;
        private long usu_estado;

        //
        private string suc_nombre;
        private string rol_titulo;


        /// <summary>
        /// Method Usu_id
        /// </summary>
        public Usuario()
        {
        }

        /// <summary>
        /// Method Usuario
        /// </summary>
        public Usuario(long usu_id, long suc_id, long rol_id, string usu_nombres, string usu_apellidos, string usu_iniciales, string usu_fono, string usu_email, string usu_login, string usu_pass, long usu_intento, long usu_estado)
        {
            this.usu_id = usu_id;
            this.suc_id = suc_id;
            this.rol_id = rol_id;
            this.usu_nombres = usu_nombres;
            this.usu_apellidos = usu_apellidos;
            this.usu_iniciales = usu_iniciales;
            this.usu_fono = usu_fono;
            this.usu_email = usu_email;
            this.usu_login = usu_login;
            this.usu_pass = usu_pass;
            this.usu_intento = usu_intento;
            this.usu_estado = usu_estado;
        }


        /// <summary>
        /// Method Usuario
        /// </summary>
        public Usuario(long usu_id, string suc_nombre, string usu_nombres, string usu_apellidos, string usu_fono, string usu_email, string usu_login, string rol_titulo, long usu_estado)
        {
            this.usu_id = usu_id;
            this.suc_nombre = suc_nombre;
            this.usu_nombres = usu_nombres;
            this.usu_apellidos = usu_apellidos;
            this.usu_fono = usu_fono;
            this.usu_email = usu_email;
            this.usu_login = usu_login;
            this.rol_titulo = rol_titulo;
            this.usu_estado = usu_estado;
        }


        /// <summary>
        /// Method Usu_id
        /// </summary>
        public long Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }

        /// <summary>
        /// Method Suc_id
        /// </summary>
        public long Suc_id
        {
            get { return suc_id; }
            set { suc_id = value; }
        }

        /// <summary>
        /// Method Rol_id
        /// </summary>
        public long Rol_id
        {
            get { return rol_id; }
            set { rol_id = value; }
        }

        /// <summary>
        /// Method Usu_nombres
        /// </summary>
        public string Usu_nombres
        {
            get { return usu_nombres; }
            set { usu_nombres = value; }
        }

        /// <summary>
        /// Method Usu_apellidos
        /// </summary>
        public string Usu_apellidos
        {
            get { return usu_apellidos; }
            set { usu_apellidos = value; }
        }

        /// <summary>
        /// Method Usu_iniciales
        /// </summary>
        public string Usu_iniciales
        {
            get { return usu_iniciales; }
            set { usu_iniciales = value; }
        }

        /// <summary>
        /// Method Usu_fono
        /// </summary>
        public string Usu_fono
        {
            get { return usu_fono; }
            set { usu_fono = value; }
        }


        /// <summary>
        /// Method Usu_email
        /// </summary>
        public string Usu_email
        {
            get { return usu_email; }
            set { usu_email = value; }
        }

        /// <summary>
        /// Method Usu_login
        /// </summary>
        public string Usu_login
        {
            get { return usu_login; }
            set { usu_login = value; }
        }

        /// <summary>
        /// Method Usu_pass
        /// </summary>
        public string Usu_pass
        {
            get { return usu_pass; }
            set { usu_pass = value; }
        }


        /// <summary>
        /// Method Usu_pass
        /// </summary>
        public long Usu_intento
        {
            get { return usu_intento; }
            set { usu_intento = value; }
        }


        /// <summary>
        /// Method Usu_estado
        /// </summary>
        public long Usu_estado
        {
            get { return usu_estado; }
            set { usu_estado = value; }
        }



        /// <summary>
        /// Method Suc_nombre
        /// </summary>
        public string Suc_nombre
        {
            get { return suc_nombre; }
            set { suc_nombre = value; }
        }

        /// <summary>
        /// Method Rol_titulo
        /// </summary>
        public string Rol_Titulo
        {
            get { return rol_titulo; }
            set { rol_titulo = value; }
        }


        private string nombre_completo;
        public string Nombre_Completo
        {
            get { return nombre_completo; }
            set { nombre_completo = value; }
        }
    }/* End Class User */
} /*End namespace Model */