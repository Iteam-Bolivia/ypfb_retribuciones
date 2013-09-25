
namespace Model
{
    public class Tabla_Valores: Bd
    {
        private long tva_id;
        private long tab_id;
        private string tab_valcolumna;
        private string tva_valor;
        private int tva_estado;
        
        public Tabla_Valores() { }

        public Tabla_Valores(long tva_id, long tab_id, string tab_valcolumna, string tva_valor, int tva_estado)
        {
            this.tva_id = tva_id;
            this.tab_id = tab_id;
            this.tab_valcolumna = tab_valcolumna;
            this.tva_valor = tva_valor;
            this.tva_estado = tva_estado;
        }

        public long Tva_id
        {
            get { return tva_id; }
            set { tva_id = value; }
        }
        public long Tab_id
        {
            get { return tab_id; }
            set { tab_id = value; }
        }
        public string Tab_valcolumna
        {
            get { return tab_valcolumna; }
            set { tab_valcolumna = value; }
        }
        public string Tva_valor
        {
            get { return tva_valor; }
            set { tva_valor = value; }
        }
        public int Tva_estado
        {
            get { return tva_estado; }
            set { tva_estado = value; }
        }
    }
}