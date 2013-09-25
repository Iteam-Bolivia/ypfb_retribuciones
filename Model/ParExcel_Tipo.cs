using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ParExcel_Tipo:Bd
    {
        private long pxt_id;
        private string pxt_codigo;
        private string pxt_nombre;
        private long pxt_tipo;
        private long pxt_recorrido;
        private long pxt_contratos;
        private long pxt_estado;
        
        public ParExcel_Tipo() { }

        public long Pxt_id
        {
          get { return pxt_id; }
          set { pxt_id = value; }
        }

        public string Pxt_codigo
        {
          get { return pxt_codigo; }
          set { pxt_codigo = value; }
        }

        public string Pxt_nombre
        {
          get { return pxt_nombre; }
          set { pxt_nombre = value; }
        }

        public long Pxt_tipo
        {
          get { return pxt_tipo; }
          set { pxt_tipo = value; }
        }

        public long Pxt_recorrido
        {
          get { return pxt_recorrido; }
          set { pxt_recorrido = value; }
        }

        public long Pxt_contratos
        {
          get { return pxt_contratos; }
          set { pxt_contratos = value; }
        }


        public long Pxt_estado
        {
          get { return pxt_estado; }
          set { pxt_estado = value; }
        }


    }
}
