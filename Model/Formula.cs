using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Formula:Bd
    {
        private long for_id;
        private long var_id;
        private string for_codigo;
        private string for_nombre;
        private Decimal for_valini;
        private long for_estado;
        private int for_tipo;

        #region
        private string var_codigo;
        #endregion

        public Formula()
        {
        }

        /// <summary>
        /// Constructor Formula
        /// </summary>
        /// <param name="for_id">For_id</param>
        /// <param name="var_id">Var_id</param>
        /// <param name="for_codigo">For_Codigo</param>
        /// <param name="for_nombre">For_nombre</param>
        /// <param name="for_estado">For_estado</param>
        public Formula(long for_id, long var_id, string for_codigo,
            string for_nombre, int for_estado)
        {
            this.For_id = for_id;
            this.Var_id = var_id;
            this.For_codigo = for_codigo;
            this.For_nombre = for_nombre;
            this.for_estado = for_estado;
        }

        public long For_id
        {
            get { return for_id; }
            set { for_id = value; }
        }

        public long Var_id
        {
          get { return var_id; }
          set { var_id = value; }
        }

        public string For_codigo
        {
          get { return for_codigo; }
          set { for_codigo = value; }
        }

        public string For_nombre
        {
          get { return for_nombre; }
          set { for_nombre = value; }
        }

        public Decimal For_valini
        {
          get { return for_valini; }
          set { for_valini = value; }
        }

        public long For_estado
        {
          get { return for_estado; }
          set { for_estado = value; }
        }

        public int For_tipo
        {
          get { return for_tipo; }
          set { for_tipo = value; }
        }

        public string Var_codigo
        {
          get { return var_codigo; }
          set { var_codigo = value; }
        }


    }
}
