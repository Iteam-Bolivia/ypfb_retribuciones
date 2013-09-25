using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ParExcel:Bd
    {
        private long pex_id;
        private string pex_codigo;
        private string pex_nombre;
        private string pex_hoja;
        private long pex_estado;
        private string pex_tipo;
        private long tcl_id;
        private string tcl_nombre;
        private long pro_id;
        private long pxt_id;
        private string pxt_nombre;

                private string pxt_codigo;  

        public ParExcel() { }

        /// <summary>
        /// Constructor ParExce
        /// </summary>
        /// <param name="pex_id">Id</param>
        /// <param name="pex_codigo">Codigo</param>
        /// <param name="pex_estado">Estado</param>
        public ParExcel(long pex_id, string pex_codigo, string pex_nombre,
           string pex_hoja, long pex_estado, long tca_id, long pro_id, long pxt_id)
        {
            this.pex_id = pex_id;
            this.pex_codigo = pex_codigo;
            this.pex_nombre = pex_nombre;
            this.pex_hoja = pex_hoja;
            this.pex_estado = pex_estado;           
            this.tcl_id = tca_id;
            this.pro_id = pro_id;
            this.pxt_id = pxt_id;
        }

        public ParExcel(long pex_id, string pex_codigo, string pex_nombre,
           string pex_hoja, long pex_estado, long tca_id, long pro_id, long pxt_id, string pxt_codigo)
        {
          this.pex_id = pex_id;
          this.pex_codigo = pex_codigo;
          this.pex_nombre = pex_nombre;
          this.pex_hoja = pex_hoja;
          this.pex_estado = pex_estado;
          this.tcl_id = tca_id;
          this.pro_id = pro_id;
          this.pxt_id = pxt_id;
          this.pxt_codigo = pxt_codigo;
        }



      public long Pex_id
        {
            get { return pex_id; }
            set { pex_id = value; }
        }

        public string Pex_codigo
        {
            get { return pex_codigo; }
            set { pex_codigo = value; }
        }

        public string Pex_nombre
        {
            get { return pex_nombre; }
            set { pex_nombre = value; }
        }

        public string Pex_hoja
        {
            get { return pex_hoja; }
            set { pex_hoja = value; }
        }

        public long Pex_estado
        {
            get { return pex_estado; }
            set { pex_estado = value; }
        }

        public long Tcl_id
        {
            get { return tcl_id; }
            set { tcl_id = value; }
        }

        public long Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }

        public long Pxt_id
        {
            get { return pxt_id; }
            set { pxt_id = value; }
        }

       

       

        #region
        private string pro_nombre;
        public string Pro_nombre
        {
            get { return pro_nombre; }
            set { pro_nombre = value; }
        }

        
        public string Pxt_codigo
        {
          get { return pxt_codigo; }
          set { pxt_codigo = value; }
        }

        public string Tcl_nombre
        {
            get { return tcl_nombre; }
            set { tcl_nombre = value; }
        }

        public string Pxt_nombre
        {
            get { return pxt_nombre; }
            set { pxt_nombre = value; }
        }
        #endregion


    }
}
