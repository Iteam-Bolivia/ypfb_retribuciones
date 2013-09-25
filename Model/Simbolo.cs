using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Simbolo : Bd
    {

        private long sim_id;
        private string sim_simbolo;


        /// <summary>
        /// Method ccn_id
        /// </summary>
        public Simbolo()
        {
        }

        /// <summary>
        /// Method ccnario
        /// </summary>
        public Simbolo(long sim_id, string sim_simbolo)
        {
            this.sim_id = sim_id;
            this.sim_simbolo = sim_simbolo;
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
        /// Method sim_simbolo
        /// </summary>
        public string Sim_simbolo
        {
            get { return sim_simbolo; }
            set { sim_simbolo = value; }
        }
    }
}
