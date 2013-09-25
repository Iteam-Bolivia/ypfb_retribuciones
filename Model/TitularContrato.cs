using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TitularContrato:Bd
    {
        private long ttc_id;
        private Contrato ctt;
        private Titular tit;
        private List<Titular> listTitular;
        private string ttc_tipo;
        private string ttc_porcentaje;
        private long ttc_estado;


        public TitularContrato() { }


        /// <summary>
        /// Constructor Titular Contratro 
        /// </summary>
        /// <param name="ttc_id">Ttc_id</param>
        /// <param name="ctt_id">Contrato</param>
        /// <param name="ttc_tipo">Titutal</param>
        /// <param name="ttc_porcentaje">Ttc_Porcentaje</param>
        /// <param name="ttc_estado">Ttc_estado</param>
        public TitularContrato(long ttc_id, Contrato ctt, Titular tit,
            string ttc_tipo,  string ttc_porcentaje, long ttc_estado)
        {
            this.ttc_id = ttc_id;
            this.ctt = ctt;
            this.tit = tit;
            this.ttc_tipo = ttc_tipo;
            this.ttc_porcentaje = ttc_porcentaje;
            this.ttc_estado = ttc_estado;
        }
        


        public long Ttc_id
        {
            get { return ttc_id; }
            set { ttc_id = value; }
        }



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



        public long Ttc_estado
        {
            get { return ttc_estado; }
            set { ttc_estado = value; }
        }
    }
}
