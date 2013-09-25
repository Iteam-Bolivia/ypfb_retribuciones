using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MonedaCorte : Bd
    {
        private long mco_id;
        private Moneda mon_id;
        private int mco_tipo;
        private decimal mco_valor;
        private int mco_estado;

        public MonedaCorte()
        {
        }

        /// <summary>
        /// Constructor moneda
        /// </summary>
        /// <param name="mco_id">mco_id</param>
        /// <param name="mon_id">mon_id</param>
        /// <param name="mco_tipo">mco_tipo</param>
        /// <param name="mco_valor">mco_valor</param>
        /// <param name="mco_estado">mco_estado</param>
        public MonedaCorte(long mco_id, Moneda mon_id, int mco_tipo, decimal mco_valor,
            int mco_estado)
        {
            this.Mco_id = mco_id;
            this.Mon_id = mon_id;
            this.Mco_tipo = mco_tipo;
            this.Mco_valor = mco_valor;
            this.Mco_estado = mco_estado;
        }

        public int Mco_estado
        {
            get { return mco_estado; }
            set { mco_estado = value; }
        }


        public decimal Mco_valor
        {
            get { return mco_valor; }
            set { mco_valor = value; }
        }


        public int Mco_tipo
        {
            get { return mco_tipo; }
            set { mco_tipo = value; }
        }


        public Moneda Mon_id
        {
            get { return mon_id; }
            set { mon_id = value; }
        }


        public long Mco_id
        {
            get { return mco_id; }
            set { mco_id = value; }
        }

    }
}
