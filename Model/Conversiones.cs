
namespace Model
{
    public class Conversiones : Bd
    {
        private long con_id;
        private long umd_id;
        private long umdc_id;
        private string con_valor;
        private int con_estado;
        private long var_id;

        public Conversiones() { }

        public Conversiones(long con_id, long umd_id, long umdc_id, string con_valor, int con_estado, long var_id)
        {
            this.con_id = con_id;
            this.umd_id = umd_id;
            this.umdc_id = umdc_id;
            this.con_valor = con_valor;
            this.con_estado = con_estado;
            this.var_id = var_id;
        }

        public long Con_id
        {
            get { return con_id; }
            set { con_id = value; }
        }
        public long Umd_id
        {
            get { return umd_id; }
            set { umd_id = value; }
        }
        public long Umdc_id
        {
            get { return umdc_id; }
            set { umdc_id = value; }
        }
        public string Con_valor
        {
            get { return con_valor; }
            set { con_valor = value; }
        }
        public int Con_estado
        {
            get { return con_estado; }
            set { con_estado = value; }
        }

        public long Var_id
        {
          get { return var_id; }
          set { var_id = value; }
        }

        private string umd_nombre;
        public string Umd_nombre
        {
            get { return umd_nombre; }
            set { umd_nombre = value; }
        }
        private string umdc_nombre;
        public string Umdc_nombre
        {
            get { return umdc_nombre; }
            set { umdc_nombre = value; }
        }

        private string var_codigo;
        public string Var_codigo
        {
          get { return var_codigo; }
          set { var_codigo = value; }
        }

    }
}