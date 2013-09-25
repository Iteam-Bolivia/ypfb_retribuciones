/*
 * @author acastellon
 * Calculo Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
namespace Model
{
    /* Class Calculo */
    public class Calculo : Bd
    {
        private long cal_id;
        private long ctt_id;
        private long per_id;
        private DateTime cal_fecha;

        private long ani_id;
        private long mes_id;

        private long mon_id;
        private long tcl_id;

        private Decimal cal_valor;
        private Decimal cal_valorajustado;
        private long cal_estado;

        private Decimal cal_depacuma;
        private Decimal cal_acugantit;
        private Decimal cal_invacuma;
        private Decimal cal_acuimptit;
        private Decimal cal_costrecuacu;
        private int cal_cammar;



        /// <summary>
        /// Method Usu_id
        /// </summary>
        public Calculo()
        {
        }


        /// <summary>
        /// Method Calculo
        /// </summary>
        public Calculo(long cal_id, long ctt_id, long per_id, DateTime cal_fecha, long cal_estado)
        {
            this.cal_id = cal_id;
            this.ctt_id = ctt_id;
            this.per_id = per_id;
            this.cal_fecha = cal_fecha;
            this.cal_estado = cal_estado;
        }



        /// <summary>
        /// Method Calculo
        /// </summary>
        public Calculo(long cal_id, long ctt_id, string ctt_nombre, string tcc_codigo, string per_codigo, DateTime cal_fecha, long cal_estado)
        {
            this.cal_id = cal_id;
            this.ctt_id = ctt_id;
            this.ctt_nombre = ctt_nombre;
            this.cal_fecha = cal_fecha;
            this.cal_estado = cal_estado;
        }






        /// <summary>
        /// Method Cal_id
        /// </summary>
        public long Cal_id
        {
            get { return cal_id; }
            set { cal_id = value; }
        }

        /// <summary>
        /// Method Ctt_id
        /// </summary>
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }


        /// <summary>
        /// Method Cal_fecha
        /// </summary>
        public DateTime Cal_fecha
        {
            get { return cal_fecha; }
            set { cal_fecha = value; }
        }


        /// <summary>
        /// Method Ani_id
        /// </summary>
        public long Ani_id
        {
            get { return ani_id; }
            set { ani_id = value; }
        }

        /// <summary>
        /// Method Per_id
        /// </summary>
        public long Mes_id
        {
            get { return mes_id; }
            set { mes_id = value; }
        }

        /// <summary>
        /// Method Mon_id
        /// </summary>
        public long Mon_id
        {
            get { return mon_id; }
            set { mon_id = value; }
        }


        /// <summary>
        /// Method Tcl_id
        /// </summary>
        public long Tcl_id
        {
            get { return tcl_id; }
            set { tcl_id = value; }
        }

        /**/
        /// <summary>
        /// Method Cal_valcuenta
        /// </summary>
        public Decimal Cal_valor
        {
            get { return cal_valor; }
            set { cal_valor = value; }
        }

        /// <summary>
        /// Method Cal_valrecal
        /// </summary>
        public Decimal Cal_valorajustado
        {
            get { return cal_valorajustado; }
            set { cal_valorajustado = value; }
        }

        /// <summary>
        /// Method Cal_estado
        /// </summary>
        public long Cal_estado
        {
            get { return cal_estado; }
            set { cal_estado = value; }
        }



        /// <summary>
        /// Method Cal_depacuma
        /// </summary>
        public Decimal Cal_depacuma
        {
            get { return cal_depacuma; }
            set { cal_depacuma = value; }
        }

        /// <summary>
        /// Method Cal_acugantit
        /// </summary>
        public Decimal Cal_acugantit
        {
            get { return cal_acugantit; }
            set { cal_acugantit = value; }
        }

        /// <summary>
        /// Method Cal_invacuma
        /// </summary>
        public Decimal Cal_invacuma
        {
            get { return cal_invacuma; }
            set { cal_invacuma = value; }
        }

        /// <summary>
        /// Method Cal_acuimptit
        /// </summary>
        public Decimal Cal_acuimptit
        {
            get { return cal_acuimptit; }
            set { cal_acuimptit = value; }
        }

        /// <summary>
        /// Method Cal_acuimptit
        /// </summary>
        public Decimal Cal_costrecuacu
        {
            get { return cal_costrecuacu; }
            set { cal_costrecuacu = value; }
        }

        /// <summary>
        /// Method Cal_acuimptit
        /// </summary>
        public int Cal_cammar
        {
            get { return cal_cammar; }
            set { cal_cammar = value; }
        }

        #region

        private string tcl_codigo;
        private string ctt_codigo;
        private string ctt_nombre;
        private string cal_mes;
        private long ctt_estado;
        private long cal_nro;
        /// <summary>
        /// Method Tcl_codigo
        /// </summary>
        public string Tcl_codigo
        {
            get { return tcl_codigo; }
            set { tcl_codigo = value; }
        }

        /// <summary>
        /// Method Ctt_codigo
        /// </summary>
        public string Ctt_codigo
        {
            get { return ctt_codigo; }
            set { ctt_codigo = value; }
        }

        /// <summary>
        /// Method Ctt_nombre
        /// </summary>
        public string Ctt_nombre
        {
            get { return ctt_nombre; }
            set { ctt_nombre = value; }
        }

        /// <summary>
        /// Method Cal_mes
        /// </summary>
        public string Cal_mes
        {
            get { return cal_mes; }
            set { cal_mes = value; }
        }


        /// <summary>
        /// Method Ctt_estado
        /// </summary>
        public long Ctt_estado
        {
            get { return ctt_estado; }
            set { ctt_estado = value; }
        }


        /// <summary>
        /// Method Cal_id
        /// </summary>
        public long Cal_nro
        {
            get { return cal_nro; }
            set { cal_nro = value; }
        }
        #endregion


    }/* End Class Calculo */
} /*End namespace Model */