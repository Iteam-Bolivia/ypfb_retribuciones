using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Titular_Contrato : Bd
    {
        private long ttc_id;
        private long ctt_id;       
        private long tit_id;        
        private string ttc_tipo;
        private string ttc_porcentaje;
        private int ttc_estado;
        private string tis_nombre;
        private long titd_id;

        public Titular_Contrato() { }        
        //public Titular_Contrato(long ttc_id, Contrato ctt, Titular tit,
        //    string ttc_tipo, string ttc_porcentaje, long ttc_estado)
        //{
        //    this.ttc_id = ttc_id;
        //    this.ctt = ctt;
        //    this.tit = tit;
        //    this.ttc_tipo = ttc_tipo;
        //    this.ttc_porcentaje = ttc_porcentaje;
        //    this.ttc_estado = ttc_estado;
        //}
        public Titular_Contrato(long ttc_id, long ctt_id, long tit_id, string ttc_tipo, string ttc_porcentaje, int ttc_estado)
        {
            this.ttc_id = ttc_id;
            this.ctt_id = ctt_id;
            this.tit_id = tit_id;
            this.ttc_tipo = ttc_tipo;
            this.ttc_porcentaje = ttc_porcentaje;
            this.ttc_estado = ttc_estado;
        }


        public long Ttc_id
        {
            get { return ttc_id; }
            set { ttc_id = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }
        public long Tit_id
        {
            get { return tit_id; }
            set { tit_id = value; }
        }
        public string Ttc_tipo
        {
            get { return ttc_tipo; }
            set { ttc_tipo = value; }
        }
        public string Ttc_porcentaje
        {
            get { return ttc_porcentaje; }
            set { ttc_porcentaje = value; }
        }
        public int Ttc_estado
        {
            get { return ttc_estado; }
            set { ttc_estado = value; }
        }
        public long Titd_id
        {
            get { return titd_id; }
            set { titd_id = value; }
        }


        private string tit_nombre;

        public string Tit_nombre
        {
            get { return tit_nombre; }
            set { tit_nombre = value; }
        }


        private Contrato ctt;
        private Titular tit;
        private List<Titular> listTitular;
        public Contrato Ctt
        {
            get { return ctt; }
            set { ctt = value; }
        }
        public Titular Tit
        {
            get { return tit; }
            set { tit = value; }
        }
        public List<Titular> ListTitular
        {
            get { return listTitular; }
            set { listTitular = value; }
        }

        public string Tis_nombre
        {
            get { return tis_nombre; }
            set { tis_nombre = value; }
        }

    }
}