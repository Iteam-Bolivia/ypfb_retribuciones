
namespace Model
{
    public class Contrato_Sinonimo : Bd
    {
        private long cts_id;
        private long ctt_id;
        private string cts_nombre;
        private int cts_estado;

        private string ctt_nombre;
        

        public Contrato_Sinonimo() { }

        public Contrato_Sinonimo(long cts_id, long ctt_id, string cts_nombre, int cts_estado)
        {
            this.cts_id = cts_id;
            this.ctt_id = ctt_id;
            this.cts_nombre = cts_nombre;
            this.cts_estado = cts_estado;
        }
        public long Cts_id
        {
            get { return cts_id; }
            set { cts_id = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }
        public string Cts_nombre
        {
            get { return cts_nombre; }
            set { cts_nombre = value; }
        }
        public int Cts_estado
        {
            get { return cts_estado; }
            set { cts_estado = value; }
        }
        /**********************************/
        public string Ctt_nombre
        {
            get { return ctt_nombre; }
            set { ctt_nombre = value; }
        }
        
        
    }
}