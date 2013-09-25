using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Moneda : Bd
    {
        private long mon_id;
        private string mon_codigo;
        private string mon_nombre;
        private int mon_estado;

        public Moneda()
        { }

        /// <summary>
        /// Constructor moneda
        /// </summary>
        /// <param name="mon_id">mon_id</param>
        /// <param name="mon_codigo">mon_codigo</param>
        /// <param name="mon_nombre">mon_nombre</param>
        /// <param name="mon_estado">mon_estado</param>
        public Moneda(long mon_id, string mon_codigo, string mon_nombre,
            int mon_estado)
        {
            this.mon_id = mon_id;
            this.mon_codigo = mon_codigo;
            this.mon_nombre = mon_nombre;
            this.mon_estado = mon_estado;
        }
        public long Mon_id
        {
            get { return mon_id; }
            set { mon_id = value; }
        }
        public string Mon_codigo
        {
            get { return mon_codigo; }
            set { mon_codigo = value; }
        }
        public string Mon_nombre
        {
            get { return mon_nombre; }
            set { mon_nombre = value; }
        }
        public int Mon_estado
        {
            get { return mon_estado; }
            set { mon_estado = value; }
        }
    }
}