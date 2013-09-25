using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContratoMarginal : Bd
    {
        private long cma_id;
        private long ctt_id;
        private long cma_mes;
        private long cma_anio;
        private int cma_estado;
        private long cma_mes_ini;
        private long cma_anio_ini;
        //
        private string con_nombre;

              /// <summary>
        /// Method ccn_id
        /// </summary>
        public ContratoMarginal()
        {
        }

        /// <summary>
        /// Method 
        /// </summary>
        public ContratoMarginal(long cma_id, long ctt_id, long cma_mes, long cma_anio, int cma_estado, string con_nombre)
        {
            this.cma_id = cma_id;
            this.ctt_id = ctt_id;
            this.cma_mes = cma_mes;
            this.cma_anio = cma_anio;
            this.cma_estado = cma_estado;
            this.con_nombre = con_nombre;
            
        }

        /// <summary>
        /// Method 
        /// </summary>
        public ContratoMarginal(long cma_id, long ctt_id, long cma_mes, long cma_anio, int cma_estado, long cma_mes_ini, long cma_anio_ini)
        {
            this.cma_id = cma_id;
            this.ctt_id = ctt_id;
            this.cma_mes = cma_mes;
            this.cma_anio = cma_anio;
            this.cma_estado = cma_estado;
            this.cma_mes_ini = cma_mes_ini;
            this.cma_anio_ini = cma_anio_ini;
        }

        /// <summary>
        /// Method ccn_id
        /// </summary>
        public long Cma_id
        {
            get { return cma_id; }
            set { cma_id = value; }
        }

        /// <summary>
        /// Method ctt_id
        /// </summary>
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }

        /// <summary>
        /// Method con_id
        /// </summary>
        public long Cma_mes
        {
            get { return cma_mes; }
            set { cma_mes = value; }
        }

        /// <summary>
        /// Method sim_id
        /// </summary>
        public long Cma_anio
        {
            get { return cma_anio; }
            set { cma_anio = value; }
        }

        /// <summary>
        /// Method ccn_mesiniexp
        /// </summary>
        public int Cma_estado
        {
            get { return cma_estado; }
            set { cma_estado = value; }
        }


        /// <summary>
        /// Method con_id
        /// </summary>
        public long Cma_mes_ini
        {
            get { return cma_mes_ini; }
            set { cma_mes_ini = value; }
        }

        /// <summary>
        /// Method sim_id
        /// </summary>
        public long Cma_anio_ini
        {
            get { return cma_anio_ini; }
            set { cma_anio_ini = value; }
        }
    }
}
