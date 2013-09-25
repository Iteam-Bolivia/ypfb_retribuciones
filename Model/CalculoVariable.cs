using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CalculoVariable: Bd
    {
        private long cav_id;
        private long cal_id;
        private long cam_id;
        private long pro_id;
        private long mer_id;
        private long var_id;
        private long umd_id;
        private long mon_id;
        private decimal cav_valor;
        private long cav_estado;

        #region
        private long ctt_id;
        private string ctt_codigo;
        private string ctt_nombre;
        private string cam_codigo;
        private string pro_codigo;
        private string umd_codigo;
        private string mer_codigo;
        private long ani_id;
        private long mes_id;
        private string var_codigo;
        private string var_nombre;
        private string mon_codigo;
        #endregion



        public CalculoVariable()
        { }


        public long Cav_id
        {
            get { return cav_id; }
            set { cav_id = value; }
        }

        public long Cal_id
        {
          get { return cal_id; }
          set { cal_id = value; }
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

        public long Mer_id
        {
          get { return mer_id; }
          set { mer_id = value; }
        }

        public long Var_id
        {
          get { return var_id; }
          set { var_id = value; }
        }

        public long Umd_id
        {
          get { return umd_id; }
          set { umd_id = value; }
        }

        public long Mon_id
        {
          get { return mon_id; }
          set { mon_id = value; }
        }

        public decimal Cav_valor
        {
          get { return cav_valor; }
          set { cav_valor = value; }
        }


        public long Cav_estado
        {
          get { return cav_estado; }
          set { cav_estado = value; }
        }

        public long Ctt_id
        {
          get { return ctt_id; }
          set { ctt_id = value; }
        }

        public string Ctt_codigo
        {
          get { return ctt_codigo; }
          set { ctt_codigo = value; }
        }

        public string Ctt_nombre
        {
          get { return ctt_nombre; }
          set { ctt_nombre = value; }
        }

        public string Cam_codigo
        {
          get { return cam_codigo; }
          set { cam_codigo = value; }
        }

        public string Pro_codigo
        {
          get { return pro_codigo; }
          set { pro_codigo = value; }
        }

        public string Umd_codigo
        {
          get { return umd_codigo; }
          set { umd_codigo = value; }
        }

        public string Mer_codigo
        {
          get { return mer_codigo; }
          set { mer_codigo = value; }
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

        public string Var_codigo
        {
          get { return var_codigo; }
          set { var_codigo = value; }
        }

        public string Var_nombre
        {
          get { return var_nombre; }
          set { var_nombre = value; }
        }

        public string Mon_codigo
        {
          get { return mon_codigo; }
          set { mon_codigo = value; }
        }


    }
}
