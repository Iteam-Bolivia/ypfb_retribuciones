using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Campo_Mercado_Valor : Bd
    {
        private long cmv_id;
        private long mer_id;
        private DateTime cmv_fecha;
        private string cmv_tipo;
        private long ani_id;
        private long mes_id;
        private long umd_id;
        private Decimal cmv_volumen;
        private Decimal cmv_monto;
        private Decimal cmv_transporte;
        private Decimal cmv_volene;       
        private long cmv_estado;

        private long ctt_id;
        private long cam_id;
        private long pro_id;

        
        public Campo_Mercado_Valor()
        { 
        }

        public long Cmv_id
        {
            get { return cmv_id; }
            set { cmv_id = value; }
        }

        public long Mer_id
        {
          get { return mer_id; }
          set { mer_id = value; }
        }

        public DateTime Cmv_fecha
        {
          get { return cmv_fecha; }
          set { cmv_fecha = value; }
        }

        public string Cmv_tipo
        {
          get { return cmv_tipo; }
          set { cmv_tipo = value; }
        }

        public long Ani_id
        {
          get { return ani_id; }
          set { ani_id = value; }
        }

        public long Mes_id
        {
          get { return mes_id; }
          set { mes_id = value; }
        }


        public long Umd_id
        {
          get { return umd_id; }
          set { umd_id = value; }
        }

        public Decimal Cmv_volumen
        {
          get { return cmv_volumen; }
          set { cmv_volumen = value; }
        }

        public Decimal Cmv_monto
        {
          get { return cmv_monto; }
          set { cmv_monto = value; }
        }

        public Decimal Cmv_transporte
        {
          get { return cmv_transporte; }
          set { cmv_transporte = value; }
        }

        public Decimal Cmv_volene
        {
          get { return cmv_volene; }
          set { cmv_volene = value; }
        }

        public long Cmv_estado
        {
          get { return cmv_estado; }
          set { cmv_estado = value; }
        }

        public long Ctt_id
        {
          get { return ctt_id; }
          set { ctt_id = value; }
        }
        public long Cam_id
        {
          get { return cam_id; }
          set { cam_id = value; }
        }
        public long Pro_id
        {
          get { return pro_id; }
          set { pro_id = value; }
        }

    }
}
