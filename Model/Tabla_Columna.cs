
namespace Model
{
    public class Tabla_Columna: Bd
    {
        private long tac_id;
        private long taf_id;
        private decimal tac_valcolumna;
        private decimal tac_valor;
        private int tac_estado;

        #region
        private long ctt_id;
        private long tab_id;
        #endregion

        public Tabla_Columna() { }

        public Tabla_Columna(long tac_id, long taf_id, decimal tac_valcolumna, decimal tac_valor, int tac_estado)
        {
            this.tac_id = tac_id;
            this.taf_id = taf_id;
            this.tac_valcolumna = tac_valcolumna;
            this.tac_valor = tac_valor;
            this.tac_estado = tac_estado;
        }

        public long Tac_id
        {
            get { return tac_id; }
            set { tac_id = value; }
        }
        public long Taf_id
        {
            get { return taf_id; }
            set { taf_id = value; }
        }
        public decimal Tac_valcolumna
        {
            get { return tac_valcolumna; }
            set { tac_valcolumna = value; }
        }
        public decimal Tac_valor
        {
            get { return tac_valor; }
            set { tac_valor = value; }
        }
        public int Tac_estado
        {
            get { return tac_estado; }
            set { tac_estado = value; }
        }



        #region
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
        #endregion

    }
}