using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Calculo_Variable : Bd
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
        private string cav_tipo;
        private long pex_id;



        #region

        #endregion



        public Calculo_Variable()
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


        public long Var_id
        {
            get { return var_id; }
            set { var_id = value; }
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

        public long Umd_id
        {
            get { return umd_id; }
            set { umd_id = value; }
        }

        public string Cav_tipo
        {
            get { return cav_tipo; }
            set { cav_tipo = value; }
        }


        public long Pex_id
        {
            get { return pex_id; }
            set { pex_id = value; }
        }




        private long ctt_id;
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }

        private string ctt_codigo;
        public string Ctt_codigo
        {
            get { return ctt_codigo; }
            set { ctt_codigo = value; }
        }

        private string ctt_nombre;
        public string Ctt_nombre
        {
            get { return ctt_nombre; }
            set { ctt_nombre = value; }
        }

        private string cam_nombre;
        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }

        private string pro_codigo;
        public string Pro_codigo
        {
            get { return pro_codigo; }
            set { pro_codigo = value; }
        }

        private string umd_codigo;
        public string Umd_codigo
        {
            get { return umd_codigo; }
            set { umd_codigo = value; }
        }

        private string mer_codigo;
        public string Mer_codigo
        {
            get { return mer_codigo; }
            set { mer_codigo = value; }
        }

        private long ani_id;
        public long Ani_id
        {
            get { return ani_id; }
            set { ani_id = value; }
        }

        private long mes_id;
        public long Mes_id
        {
            get { return mes_id; }
            set { mes_id = value; }
        }

        private string cav_mes;
        public string Cav_mes
        {
            get { return cav_mes; }
            set { cav_mes = value; }
        }

        private string var_codigo;
        public string Var_codigo
        {
            get { return var_codigo; }
            set { var_codigo = value; }
        }

        private string var_nombre;
        public string Var_nombre
        {
            get { return var_nombre; }
            set { var_nombre = value; }
        }

        private string mon_codigo;
        public string Mon_codigo
        {
            get { return mon_codigo; }
            set { mon_codigo = value; }
        }

        private long cav_nro;
        public long Cav_nro
        {
            get { return cav_nro; }
            set { cav_nro = value; }
        }



    }
}
