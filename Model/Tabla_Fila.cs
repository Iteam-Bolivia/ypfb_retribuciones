
namespace Model
{
    public class Tabla_Fila : Bd
    {
        private long taf_id;
        private long tab_id;
        private decimal taf_valfila;
        private decimal taf_valor;
        private int taf_estado;



        #region
        private long tca_id;
        #endregion


        public Tabla_Fila() { }

        public Tabla_Fila(long taf_id, long tab_id, decimal taf_valfila, decimal taf_valor, int taf_estado)
        {
            this.taf_id = taf_id;
            this.tab_id = tab_id;
            this.taf_valfila = taf_valfila;
            this.taf_valor = taf_valor;
            this.taf_estado = taf_estado;
        }
        public long Taf_id
        {
            get { return taf_id; }
            set { taf_id = value; }
        }
        public long Tab_id
        {
            get { return tab_id; }
            set { tab_id = value; }
        }
        
        public decimal Taf_valfila
        {
            get { return taf_valfila; }
            set { taf_valfila = value; }
        }
        public decimal Taf_valor
        {
            get { return taf_valor; }
            set { taf_valor = value; }
        }
        public int Taf_estado
        {
            get { return taf_estado; }
            set { taf_estado = value; }
        }


        #region
        public long Tca_id
        {
          get { return tca_id; }
          set { tca_id = value; }
        }
        #endregion


    }
}