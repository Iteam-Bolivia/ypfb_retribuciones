using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class Titular_Sinonimo: Bd
    {
        private long tis_id;
        private long tit_id;
        private string tis_nombre;
        private int tis_estado;

        private string tit_nombre;

        public Titular_Sinonimo() { }

        public Titular_Sinonimo(long tis_id, long tit_id, string tis_nombre ,int tis_estado)
        {
            this.tis_id = tis_id;
            this.tit_id = tit_id;
            this.tis_nombre = tis_nombre;
            this.tis_estado = tis_estado;
        }
        public long Tis_id
        {
            get { return tis_id; }
            set { tis_id = value; }
        }
        public long Tit_id
        {
            get { return tit_id; }
            set { tit_id = value; }
        }
        public string Tis_nombre
        {
            get { return tis_nombre; }
            set { tis_nombre = value; }
        }
        
        public int Tis_estado
        {
            get { return tis_estado; }
            set { tis_estado = value; }
        }

        public string Tit_nombre
        {
            get { return tit_nombre; }
            set { tit_nombre = value; }
        }
    }
}