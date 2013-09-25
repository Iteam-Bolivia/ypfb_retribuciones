using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Mercado : Bd
    {
        private long mer_id;
        private string mer_codigo;
        private string mer_nombre;
        private long mer_estado;
        
        private string mer_tipo;
        private long mer_orden;
        private string mer_ordenletra;
        private int mer_var;
        private int pro_mer;

        #region Propiedades Auxiliares

        private string blo_nombre;

        #endregion

        public Mercado()
        { }

        /// <summary>
        /// Constructor Mercado
        /// </summary>
        /// <param name="mer_id">Mer_id</param>
        /// <param name="mer_codigo">Mer_codigo</param>
        /// <param name="mer_nombre">Mer_nombre</param>
        /// <param name="mer_estado">Mer_estado</param>
        public Mercado(long mer_id, string mer_codigo, string mer_nombre, long mer_estado, string mer_tipo, long mer_orden, string mer_ordenletra, int mer_var, int pro_mer)
        {
            this.mer_id = mer_id;
            this.mer_codigo = mer_codigo;
            this.mer_nombre = mer_nombre;
            this.mer_estado = mer_estado;

            this.mer_tipo = mer_tipo;
            this.mer_orden = mer_orden;
            this.mer_ordenletra = mer_ordenletra;
            this.mer_var = mer_var;
            this.pro_mer = pro_mer;
        }



        public long Mer_id
        {
            get { return mer_id; }
            set { mer_id = value; }
        }



        public string Mer_codigo
        {
            get { return mer_codigo; }
            set { mer_codigo = value; }
        }



        public string Mer_nombre
        {
            get { return mer_nombre; }
            set { mer_nombre = value; }
        }



        public long Mer_estado
        {
            get { return mer_estado; }
            set { mer_estado = value; }
        }


        public string Mer_tipo
        {
            get { return mer_tipo; }
            set { mer_tipo = value; }
        }

        public long Mer_orden
        {
            get { return mer_orden; }
            set { mer_orden = value; }
        }

        public string Mer_ordenletra
        {
            get { return mer_ordenletra; }
            set { mer_ordenletra = value; }
        }

        public int Mer_var
        {
            get { return mer_var; }
            set { mer_var = value; }
        }

        public int Pro_mer
        {
            get { return pro_mer; }
            set { pro_mer = value; }
        }

        public string Blo_nombre
        {
            get { return blo_nombre; }
            set { blo_nombre = value; }
        }

    }
}
