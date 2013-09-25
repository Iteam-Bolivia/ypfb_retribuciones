
namespace Model
{
    public class Unidad_Medida : Bd
    {
        private long umd_id;
        //private long pro_id;
        private string umd_codigo;
        private string umd_nombre;
        private long umd_estado;
        

        public Unidad_Medida() { }

        /// <summary>
        /// Constructor Unidad medida
        /// </summary>
        /// <param name="umd_id">Umd_id</param>
        /// <param name="umd_codigo">Umd_codigo</param>
        /// <param name="umd_nombre">Umd_nombre</param>
        /// <param name="umd_estado">Umd_estado</param>
        public Unidad_Medida(long umd_id, string umd_codigo, string umd_nombre,
            long umd_estado)
        {
            this.Umd_id = umd_id;
            this.Umd_codigo = umd_codigo;
            this.Umd_nombre = umd_nombre;
            this.Umd_estado = umd_estado;
        }
        //public Unidad_Medida(long umd_id, long pro_id, string umd_codigo, string umd_nombre, long umd_estado)
        //{
        //    this.Umd_id = umd_id;
        //    //this.pro_id = pro_id;
        //    this.Umd_codigo = umd_codigo;
        //    this.Umd_nombre = umd_nombre;
        //    this.Umd_estado = umd_estado;
        //}
        public long Umd_id
        {
            get { return umd_id; }
            set { umd_id = value; }
        }
        //public long Pro_id
        //{
        //    get { return pro_id; }
        //    set { pro_id = value; }
        //}
        public string Umd_codigo
        {
            get { return umd_codigo; }
            set { umd_codigo = value; }
        }
        public string Umd_nombre
        {
            get { return umd_nombre; }
            set { umd_nombre = value; }
        }
        public long Umd_estado
        {
            get { return umd_estado; }
            set { umd_estado = value; }
        }




        private string pro_nombre;
        public string Pro_nombre
        {
            get { return pro_nombre; }
            set { pro_nombre = value; }
        }

        private string lista_conversiones;
        public string Lista_Conversiones
        {
            get { return lista_conversiones; }
            set { lista_conversiones = value; }
        }


        
    }
}