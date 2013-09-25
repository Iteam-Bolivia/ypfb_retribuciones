using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SistemaLog:Bd
    {
        private long isl_id;
        private Sistema sis_id;
        private Usuario usu_id;
        private string usu_login;
        private string isl_fecha;
        private string isl_hora;
        private string isl_accion;
        private int isl_estado;

        

        /// <summary>
        /// constructor sistema_log
        /// </summary>
        public SistemaLog()
        {
        }

        /// <summary>
        /// Constructor clase sistem_log
        /// </summary>
        /// <param name="sis_id">sis_id</param>
        /// <param name="usu_id">usu_id</param>
        /// <param name="usu_login">usu_login</param>
        /// <param name="isl_fecha">isl_fecha</param>
        /// <param name="isl_hora">isl_hora</param>
        /// <param name="isl_accion">isl_accion</param>
        public SistemaLog(long isl_id,Sistema sis_id, Usuario usu_id, string usu_login, string
            isl_fecha, string isl_hora, string isl_accion, int isl_estado)
        {
            Isl_id = isl_id;
            Sis_id = sis_id;
            Usu_id = usu_id;
            Usu_login = usu_login;
            Isl_fecha = isl_fecha;
            Isl_hora = Isl_hora;
            Isl_accion = isl_accion;
            Isl_estado = isl_estado;
        }


        public int Isl_estado
        {
            get { return isl_estado; }
            set { isl_estado = value; }
        }


        /// <summary>
        /// method isl_accion
        /// </summary>
        public string Isl_accion
        {
            get { return isl_accion; }
            set { isl_accion = value; }
        }


        /// <summary>
        /// method isl_hora
        /// </summary>
        public string Isl_hora
        {
            get { return isl_hora; }
            set { isl_hora = value; }
        }

        /// <summary>
        /// method Isl_fecha
        /// </summary>
        public string Isl_fecha
        {
            get { return isl_fecha; }
            set { isl_fecha = value; }
        }

        /// <summary>
        /// method usu_login
        /// </summary>
        public string Usu_login
        {
            get { return usu_login; }
            set { usu_login = value; }
        }

        /// <summary>
        /// method usu_id
        /// </summary>
        public Usuario Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }

        /// <summary>
        /// method sis_id
        /// </summary>
        public Sistema Sis_id
        {
            get { return sis_id; }
            set { sis_id = value; }
        }

        /// <summary>
        /// method isl_id
        /// </summary>
        public long Isl_id
        {
            get { return isl_id; }
            set { isl_id = value; }
        }
    }
}
