/*
 * @author Diego Calderon
 * User Class
 * Created on 28 de Septiembre de 2012
 */

using System;

namespace Model
{
    public class ContratoCondicion : Bd
    {

        private long ccn_id;
        private long ctt_id;
        private long con_id;
        private long sim_id;
        //private DateTime ccn_iniexp;
        private int ccn_mesiniexp;
        private int ccn_anioiniexp;
        private int ccn_mesfin;
        private int ccn_aniofin;
        //private DateTime ccn_tiempodur;
        private int ccn_diasdifer;
        private decimal ccn_valorb;
        private int ccn_estado;
        //
        private string con_nombre;
        private string sim_simbolo;

        /// <summary>
        /// Method ccn_id
        /// </summary>
        public ContratoCondicion()
        {
        }

        /// <summary>
        /// Method 
        /// </summary>
        public ContratoCondicion(long ccn_id, long ctt_id, long con_id, long sim_id, int ccn_mesiniexp, int ccn_anioiniexp, int ccn_mesfin, int ccn_aniofin, int ccn_diasdifer, decimal ccn_valorb, int ccn_estado, string con_nombre, string sim_simbolo)
        {
            this.ccn_id = ccn_id;
            this.ctt_id = ctt_id;
            this.con_id = con_id;
            this.sim_id = sim_id;
            this.ccn_mesiniexp = ccn_mesiniexp;
            this.ccn_anioiniexp = ccn_anioiniexp;
            //this.ccn_iniexp = ccn_iniexp;
            this.ccn_mesfin = ccn_mesfin;
            this.ccn_aniofin = ccn_aniofin;
            //this.ccn_tiempodur = ccn_tiempodur;
            this.ccn_diasdifer = ccn_diasdifer;
            this.ccn_valorb = ccn_valorb;
            this.ccn_estado = ccn_estado;
            this.con_nombre = con_nombre;
            this.sim_simbolo = sim_simbolo;
        }

        /// <summary>
        /// Method 
        /// </summary>
        public ContratoCondicion(long ccn_id, long ctt_id, long con_id, long sim_id, int ccn_mesiniexp, int ccn_anioiniexp, int ccn_mesfin, int ccn_aniofin, int ccn_diasdifer, decimal ccn_valorb, int ccn_estado)
        {
            this.ccn_id = ccn_id;
            this.ctt_id = ctt_id;
            this.con_id = con_id;
            this.sim_id = sim_id;
            //this.ccn_iniexp = ccn_iniexp;
            this.ccn_mesiniexp = ccn_mesiniexp;
            this.ccn_anioiniexp = ccn_anioiniexp;
            this.ccn_mesfin = ccn_mesfin;
            this.ccn_aniofin = ccn_aniofin;
            //this.ccn_tiempodur = ccn_tiempodur;
            this.ccn_diasdifer = ccn_diasdifer;
            this.ccn_valorb = ccn_valorb;
            this.ccn_estado = ccn_estado;

        }

        /// <summary>
        /// Method ccn_id
        /// </summary>
        public long Ccn_id
        {
            get { return ccn_id; }
            set { ccn_id = value; }
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
        public long Con_id
        {
            get { return con_id; }
            set { con_id = value; }
        }

        /// <summary>
        /// Method sim_id
        /// </summary>
        public long Sim_id
        {
            get { return sim_id; }
            set { sim_id = value; }
        }

        /// <summary>
        /// Method con_iniexp
        /// </summary>
        //public DateTime Ccn_iniexp
        //{
        //    get { return ccn_iniexp; }
        //    set { ccn_iniexp = value; }
        //}
        /// <summary>
        /// Method ccn_mesiniexp
        /// </summary>
        public int Ccn_mesiniexp
        {
            get { return ccn_mesiniexp; }
            set { ccn_mesiniexp = value; }
        }
        /// <summary>
        /// Method ccn_anioiniexp
        /// </summary>
        public int Ccn_anioiniexp
        {
            get { return ccn_anioiniexp; }
            set { ccn_anioiniexp = value; }
        }

        /// <summary>
        /// Method ccn_diasdifer
        /// </summary>
        public int Ccn_mesfin
        {
            get { return ccn_mesfin; }
            set { ccn_mesfin = value; }
        }

        /// <summary>
        /// Method ccn_diasdifer
        /// </summary>
        public int Ccn_aniofin
        {
            get { return ccn_aniofin; }
            set { ccn_aniofin = value; }
        }
        /// <summary>
        /// Method ccn_tiempodur
        /// </summary>
        //public DateTime Ccn_tiempodur
        //{
        //    get { return ccn_tiempodur; }
        //    set { ccn_tiempodur = value; }
        //}

        /// <summary>
        /// Method ccn_diasdifer
        /// </summary>
        public int Ccn_diasdifer
        {
            get { return ccn_diasdifer; }
            set { ccn_diasdifer = value; }
        }

        /// <summary>
        /// Method ccn_diasdifer
        /// </summary>
        public decimal Ccn_valorb
        {
            get { return ccn_valorb; }
            set { ccn_valorb = value; }
        }

        /// <summary>
        /// Method ccn_estado
        /// </summary>
        public int Ccn_estado
        {
            get { return ccn_estado; }
            set { ccn_estado = value; }
        }

        /// <summary>
        /// Method con_nombre
        /// </summary>
        public string Con_nombre
        {
            get { return con_nombre; }
            set { con_nombre = value; }
        }

        /// <summary>
        /// Method sim_nombre
        /// </summary>
        public string Sim_simbolo
        {
            get { return sim_simbolo; }
            set { sim_simbolo = value; }
        }

    }
}
