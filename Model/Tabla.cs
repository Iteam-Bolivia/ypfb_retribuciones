
namespace Model
{
    public class Tabla : Bd
    {
        private long tab_id;
        private string tab_codigo;
        private string tab_nombre;
        private int tab_estado;

        public Tabla() { }

        public Tabla(long tab_id, string tab_codigo, string tab_nombre, int tab_estado)
        {
            this.tab_id = tab_id;
            this.tab_codigo = tab_codigo;
            this.tab_nombre = tab_nombre;
            this.tab_estado = tab_estado;
        }

        public long Tab_id
        {
            get { return tab_id; }
            set { tab_id = value; }
        }
        public string Tab_codigo
        {
            get { return tab_codigo; }
            set { tab_codigo = value; }
        }
        public string Tab_nombre
        {
            get { return tab_nombre; }
            set { tab_nombre = value; }
        }
        public int Tab_estado
        {
            get { return tab_estado; }
            set { tab_estado = value; }
        }
    }
}