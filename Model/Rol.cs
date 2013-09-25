using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class Rol: Bd
    {
        private int rol_id;
        private string rol_cod;
        private string rol_titulo;
        private string rol_descripcion;
        private int rol_estado;

        /// <summary>
        /// Constructor del rol
        /// </summary>
        public Rol()
        {
        }

        /// <summary>
        /// Constuctor con paso de parametros
        /// </summary>
        /// <param name="rol_id">Id del rol</param>
        /// <param name="rol_cod">Codigo del rol</param>
        /// <param name="rol_titulo">Titulo del rol</param>
        /// <param name="rol_descripcion">Descripcion del rol</param>
        /// <param name="rol_estado">Estado del rol</param>
        public Rol(int rol_id, string rol_cod, string rol_titulo, string rol_descripcion,int rol_estado)
        {
            this.rol_id = rol_id;
            this.rol_cod = rol_cod;
            this.rol_titulo = rol_titulo;
            this.rol_descripcion = rol_descripcion;
            this.rol_estado = rol_estado;
        }

        /// <summary>
        /// method rol_id
        /// </summary>
        public int Rol_id
        {
            get { return rol_id; }
            set { rol_id = value; }
        }
        /// <summary>
        /// Method rol_cod
        /// </summary>
        public string Rol_cod
        {
            get { return rol_cod; }
            set { rol_cod = value; }
        }
        /// <summary>
        /// Method rol
        /// </summary>
        public string Rol_titulo
        {
            get { return rol_titulo; }
            set { rol_titulo = value; }
        }
        /// <summary>
        /// Method rol_descripcion
        /// </summary>
        public string Rol_descripcion
        {
            get { return rol_descripcion; }
            set { rol_descripcion = value; }
        }
        /// <summary>
        /// Method rol_estado
        /// </summary>
        public int Rol_estado
        {
            get { return rol_estado; }
            set { rol_estado = value; }
        }
    }
}
