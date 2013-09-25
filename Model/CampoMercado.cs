using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ypfbApplication.Model
{
    public class CampoMercado
    {
        private long cae_id;
        private long cam_id;
        private long mer_id;
        private long mon_id;
        private decimal cae_valor;
        private decimal cae_volumen;
        private decimal cae_volumen_fact;

        public CampoMercado()
        { }


        /// <summary>
        /// Constructor Campo mercado
        /// </summary>
        /// <param name="cae_id">cae_id</param>
        /// <param name="cam_id">Cam_id</param>
        /// <param name="mer_id">Mer_id</param>
        /// <param name="mon_id">Mon_id</param>
        /// <param name="cae_valor">Cae_valor</param>
        /// <param name="cae_volumen">cae_volumen</param>
        /// <param name="cae_volumen_fact">Cae_volumen_fact</param>
        public CampoMercado(long cae_id, long cam_id, long mer_id,
            long mon_id, decimal cae_valor, decimal cae_volumen,
                decimal cae_volumen_fact)
        {
            this.Cae_id = cae_id;
            this.Cam_id = cam_id;
            this.Mer_id = mer_id;
            this.Mon_id = mon_id;
            this.Cae_valor = Cae_valor;
            this.cae_volumen = cae_volumen;
            this.Cae_volumen_fact = cae_volumen_fact;
        }


        public decimal Cae_volumen_fact
        {
            get { return cae_volumen_fact; }
            set { cae_volumen_fact = value; }
        }


        public decimal Cae_volumen
        {
            get { return cae_volumen; }
            set { cae_volumen = value; }
        }


        public decimal Cae_valor
        {
            get { return cae_valor; }
            set { cae_valor = value; }
        }


        public long Mon_id
        {
            get { return mon_id; }
            set { mon_id = value; }
        }


        public long Mer_id
        {
            get { return mer_id; }
            set { mer_id = value; }
        }


        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }


        public long Cae_id
        {
            get { return cae_id; }
            set { cae_id = value; }
        }

    }
}
