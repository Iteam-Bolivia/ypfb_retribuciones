
using System;
namespace Model
{
    public class Tabla_Calculo: Bd
    {
        private long tca_id;
        private long ctt_id;
        private long tab_id;
        private int tca_estado;
        private DateTime tca_fecha;
        private decimal tca_precio;
        public int tca_oplogi;
        public string tca_oplogiAux;

        public string sim_simbolo;
        
        public Tabla_Calculo()
        { }

        public Tabla_Calculo(long tca_id, long ctt_id, long tab_id, int tca_estado, DateTime tca_fecha, decimal tca_precio, int tca_oplogi)
        {
            this.tca_id = tca_id;
            this.ctt_id = ctt_id;
            this.tab_id = tab_id;
            this.tca_estado = tca_estado;
            this.tca_fecha = tca_fecha;
            this.tca_precio = tca_precio;
            this.tca_oplogi = tca_oplogi;
        }
        public long Tca_id
        {
            get { return tca_id; }
            set { tca_id = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }
        public long Tab_id
        {
            get { return tab_id; }
            set { tab_id = value; }
        }
        public int Tca_estado
        {
            get { return tca_estado; }
            set { tca_estado = value; }
        }
        public DateTime Tca_fecha
        {
          get { return tca_fecha; }
          set { tca_fecha = value; }
        }
        public decimal Tca_precio
        {
          get { return tca_precio; }
          set { tca_precio = value; }
        }

        public int Tca_oplogi
        {
            get { return tca_oplogi; }
            set { tca_oplogi = value; }
        }

        public string Tca_oplogiAux
        {
            get { return tca_oplogiAux; }
            set { tca_oplogiAux = value; }
        }

        private string ctt_nombre;
        public string Ctt_nombre
        {
            get { return ctt_nombre; }
            set { ctt_nombre = value; }
        }
        private string tab_nombre;
        public string Tab_nombre
        {
            get { return tab_nombre; }
            set { tab_nombre = value; }
        }
        public string Sim_simbolo
        {
            get { return sim_simbolo; }
            set { sim_simbolo = value; }
        }
    }
}