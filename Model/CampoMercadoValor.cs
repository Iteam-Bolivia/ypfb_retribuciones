using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ypfbApplication.Model
{
    public class CampoMercadoValor
    {
        private long cmv_id;
        private long cae_id;
        private long umd_id;
        private decimal cmv_valor;

        public CampoMercadoValor()
        { }

        /// <summary>
        /// Constructor Campo mercado valor
        /// </summary>
        /// <param name="cmv_id">Cmv id</param>
        /// <param name="cae_id">Cae_id</param>
        /// <param name="umd_id">Umd_id</param>
        /// <param name="cmv_valor">cmv_valor</param>
        public CampoMercadoValor(long cmv_id, long cae_id, long umd_id,
            decimal cmv_valor)
        {
            this.Cmv_id = cmv_id;
            this.Cae_id = cae_id;
            this.Umd_id = umd_id;
            this.Cmv_valor = cmv_valor;
        }

        public decimal Cmv_valor
        {
            get { return cmv_valor; }
            set { cmv_valor = value; }
        }



        public long Umd_id
        {
            get { return umd_id; }
            set { umd_id = value; }
        }


        public long Cae_id
        {
            get { return cae_id; }
            set { cae_id = value; }
        }


        public long Cmv_id
        {
            get { return cmv_id; }
            set { cmv_id = value; }
        }

    }
}
