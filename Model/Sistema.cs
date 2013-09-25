using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Sistema:Bd
    {
        private long sis_id;
        private string sis_nombre;
        private string sis_bd;
        private int sis_estado;

        public Sistema()
        {
        }

        /// <summary>
        /// Constructor Sistema
        /// </summary>
        /// <param name="sis_id"></param>
        /// <param name="sis_nombre"></param>
        /// <param name="sis_bd"></param>
        /// <param name="sis_estado"></param>
        public Sistema(long sis_id, string sis_nombre, string sis_bd, int sis_estado)
        {
            Sis_id = sis_id;
            Sis_nombre = sis_nombre;
            Sis_bd = sis_bd;
            Sis_estado = sis_estado;
        }

        /// <summary>
        /// method Sis_estado
        /// </summary>
        public int Sis_estado
        {
            get { return sis_estado; }
            set { sis_estado = value; }
        }

        /// <summary>
        /// method sis_bd
        /// </summary>
        public string Sis_bd
        {
            get { return sis_bd; }
            set { sis_bd = value; }
        }

        /// <summary>
        /// method sis_nombre
        /// </summary>
        public string Sis_nombre
        {
            get { return sis_nombre; }
            set { sis_nombre = value; }
        }

        /// <summary>
        /// method sis_id
        /// </summary>
        public long Sis_id
        {
            get { return sis_id; }
            set { sis_id = value; }
        }

    }
}
