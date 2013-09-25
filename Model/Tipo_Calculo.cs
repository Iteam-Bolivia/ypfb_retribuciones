
namespace Model
{
    public class Tipo_Calculo : Bd
    {
        private long tcl_id;
        private string tcl_codigo;
        private string tcl_nombre;
        private int tcl_estado;

        public Tipo_Calculo() { }

        public Tipo_Calculo(long tcl_id, string tcl_codigo, string tcl_nombre, int tcl_estado)
        {
            this.tcl_id = tcl_id;
            this.tcl_codigo = tcl_codigo;
            this.tcl_nombre = tcl_nombre;
            this.tcl_estado = tcl_estado;
        }

        public long Tcl_id
        {
            get { return tcl_id; }
            set { tcl_id = value; }
        }
        public string Tcl_codigo
        {
            get { return tcl_codigo; }
            set { tcl_codigo = value; }
        }
        public string Tcl_nombre
        {
            get { return tcl_nombre; }
            set { tcl_nombre = value; }
        }
        public int Tcl_estado
        {
            get { return tcl_estado; }
            set { tcl_estado = value; }
        }
    }
}