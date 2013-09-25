using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UsuarioPass:Bd
    {
        private long usp_id;
        private int usu_id;

        private string usp_login;
        private string usp_pass;
        private int usp_estado;

        /// <summary>
        /// Constructor UserPass
        /// </summary>
        public UsuarioPass()
        {
        }


        /// <summary>
        /// Constructor Usuario password
        /// </summary>
        /// <param name="usp_id">Usuariopass id</param>
        /// <param name="usu_id">Usuario id</param>
        /// <param name="usp_login">Usuario login</param>
        /// <param name="usp_pass">Usuario password</param>
        /// <param name="usp_estado">Usuario estado</param>
        public UsuarioPass(long usp_id,int usu_id, string usu_login,
            string usu_pass,int usp_estado)
        {
            Usp_id = usp_id;
            Usu_id = usu_id;
            Usp_login = usu_login;
            Usp_pass = usu_pass;
            Usp_estado = usp_estado;
        }



        public int Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }


        /// <summary>
        /// Method usp_estado
        /// </summary>
        public int Usp_estado
        {
            get { return usp_estado; }
            set { usp_estado = value; }
        }

        /// <summary>
        /// Method usp_pass
        /// </summary>
        public string Usp_pass
        {
            get { return usp_pass; }
            set { usp_pass = value; }
        }

        /// <summary>
        /// Method usp_login
        /// </summary>
        public string Usp_login
        {
            get { return usp_login; }
            set { usp_login = value; }
        }

        /// <summary>
        /// Method usp_id
        /// </summary>
        public long Usp_id
        {
            get { return usp_id; }
            set { usp_id = value; }
        }

    }
}
