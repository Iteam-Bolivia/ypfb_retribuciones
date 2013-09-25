using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Contrato : Bd
    {
        private long ctt_id;
        private long suc_id;
        private string ctt_codigo;
        private string ctt_nombre;
        private string ctt_periodo;
        private DateTime ctt_fecini;
        private DateTime ctt_fecfin;
        private long ctt_estado;
        private long ctt_produccion;
        private Decimal ctt_costrecuacu;
        private int ctt_orden;

        #region Campos nuevos Añadidos
        private decimal ctt_depacu;
        private decimal ctt_depacuma;
        private decimal ctt_acugantit;
        private decimal ctt_invacu;
        private decimal ctt_invacuma;
        private decimal ctt_acuimptit;
        private decimal ctt_invneta;

        private decimal ctt_lrc;
        private decimal ctt_vhiena;
        private long ctt_cmp;
        private decimal ctt_icpmp;
        private decimal ctt_pppvgnpf;
        private decimal ctt_pppvhlpf;

        private string cts_nombre;
        #endregion

        


        public Contrato()
        { }

        /// <summary>
        /// Constructor contrato
        /// </summary>
        /// <param name="ctt_id">Ctt_id</param>
        /// <param name="suc_id">Suc_id</param>
        /// <param name="ctt_codigo">Ctt_Codigo</param>
        /// <param name="ctt_nombre">Ctt_Nombre</param>
        /// <param name="ctt_estado">Ctt_Estado</param>
        /// <param name="ctt_fecini">Ctt_fecini</param>
        /// <param name="ctt_fecfin">Ctt_fecfin</param>
        public Contrato(long ctt_id, long suc_id, string ctt_codigo, string ctt_nombre,
            string ctt_periodo, DateTime ctt_fecini, DateTime ctt_fecfin, long ctt_estado)
        {
            this.ctt_id = ctt_id;
            this.suc_id = suc_id;
            this.ctt_codigo = ctt_codigo;
            this.ctt_nombre = ctt_nombre;
            this.ctt_periodo = ctt_periodo;
            this.ctt_fecini = ctt_fecini;
            this.ctt_fecfin = ctt_fecfin;
            this.ctt_estado = ctt_estado;
        }

        public Contrato(long ctt_id, long suc_id, string ctt_codigo, string ctt_nombre,
            string ctt_periodo, DateTime ctt_fecini, DateTime ctt_fecfin, long ctt_estado, int usu_id)
        {
            this.ctt_id = ctt_id;
            this.suc_id = suc_id;
            this.ctt_codigo = ctt_codigo;
            this.ctt_nombre = ctt_nombre;
            this.ctt_periodo = ctt_periodo;
            this.ctt_fecini = ctt_fecini;
            this.ctt_fecfin = ctt_fecfin;
            this.ctt_estado = ctt_estado;
            this.usu_id = usu_id;
        }


        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }



        public long Suc_id
        {
            get { return suc_id; }
            set { suc_id = value; }
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



        public string Ctt_periodo
        {
            get { return ctt_periodo; }
            set { ctt_periodo = value; }
        }

        public DateTime Ctt_fecini
        {
            get { return ctt_fecini; }
            set { ctt_fecini = value; }
        }

        public DateTime Ctt_fecfin
        {
            get { return ctt_fecfin; }
            set { ctt_fecfin = value; }
        }

        public long Ctt_estado
        {
            get { return ctt_estado; }
            set { ctt_estado = value; }
        }


        private int usu_id;
        public int Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }
        
        // 
        public decimal Ctt_depacu
        {
          get { return ctt_depacu; }
          set { ctt_depacu = value; }
        }


        public decimal Ctt_depacuma
        {
          get { return ctt_depacuma; }
          set { ctt_depacuma = value; }
        }

        public decimal Ctt_acugantit
        {
          get { return ctt_acugantit; }
          set { ctt_acugantit = value; }
        }


        public decimal Ctt_invacu
        {
          get { return ctt_invacu; }
          set { ctt_invacu = value; }
        }

        public decimal Ctt_invacuma
        {
          get { return ctt_invacuma; }
          set { ctt_invacuma = value; }
        }

        public decimal Ctt_acuimptit
        {
          get { return ctt_acuimptit; }
          set { ctt_acuimptit = value; }
        }

        public decimal Ctt_invneta
        {
          get { return ctt_invneta; }
          set { ctt_invneta = value; }
        }

        public decimal Ctt_lrc
        {
          get { return ctt_lrc; }
          set { ctt_lrc = value; }
        }

        public decimal Ctt_vhiena
        {
          get { return ctt_vhiena; }
          set { ctt_vhiena = value; }
        }

        public long Ctt_cmp
        {
          get { return ctt_cmp; }
          set { ctt_cmp = value; }
        }

        public decimal Ctt_icpmp
        {
          get { return ctt_icpmp; }
          set { ctt_icpmp = value; }
        }

        public decimal Ctt_pppvgnpf
        {
          get { return ctt_pppvgnpf; }
          set { ctt_pppvgnpf = value; }
        }

        public decimal Ctt_pppvhlpf
        {
          get { return ctt_pppvhlpf; }
          set { ctt_pppvhlpf = value; }
        }

        public long Ctt_produccion
        {
            get { return ctt_produccion; }
            set { ctt_produccion = value; }
        }

        public decimal Ctt_costrecuacu
        {
            get { return ctt_costrecuacu; }
            set { ctt_costrecuacu = value; }
        }


        public int Ctt_orden
        {
          get { return ctt_orden; }
          set { ctt_orden = value; }
        }

        #region Campos Auxiliares
        private string lista_titulares;

        public string Lista_Titulares
        {
            get { return lista_titulares; }
            set { lista_titulares = value; }
        }
        private string lista_Campos;
        public string Lista_Campos
        {
            get { return lista_Campos; }
            set { lista_Campos = value; }
        }
        private string nombre_completo;
        public string Nombre_Completo
        {
            get { return nombre_completo; }
            set { nombre_completo = value; }
        }
        private string lista_tablas;
        public string Lista_Tablas
        {
            get { return lista_tablas; }
            set { lista_tablas = value; }
        }
        public string Cts_nombre
        {
            get { return cts_nombre; }
            set { cts_nombre = value; }
        }
        
        #endregion
    }
}