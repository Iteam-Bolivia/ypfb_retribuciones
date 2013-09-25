using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ParExcel_Columna:Bd
    {

        
        private long pec_id;
        private long pex_id;
        private string pec_columna;
        private long pec_fila;


        private long tco_id;
        private long mer_id;
        private long umd_id;
        private bool pec_iva;
        private long pec_estado;
        private long var_id;
        private long pec_Convercion;

        private string pec_Convercion_string;

        private string pex_hoja;
        private string pex_codigo;
        private string umd_nombre;
        private string mer_nombre;
        private string var_nombre;
        private string var_codigo;


        
        //Datos del tipo de valor
        private string tco_nombre;
        private string var_descripcion;
        private string pxt_codigo;
        private long vard_id;

        public ParExcel_Columna() { }


        /// <summary>
        /// Constructor ParExcelColumna simple
        /// </summary>
        /// <param name="pec_id">Id</param>
        /// <param name="pex_id">Pex id</param>
        /// <param name="pec_columna">nombre</param>
        /// <param name="tco_id"></param>
        /// <param name="pec_estado"></param>
        public ParExcel_Columna(long pec_id, long pex_id, string pec_columna, long pec_fila,
            long tco_id, long mer_id, long umd_id, bool pec_iva, long pec_estado, long var_id, long pec_Convercion)
        {
            this.pec_id = pec_id;
            this.pex_id = pex_id;
            this.pec_columna = pec_columna;
            this.pec_fila = pec_fila;
            this.tco_id = tco_id;
            this.pec_estado = pec_estado;
            this.mer_id = mer_id;
            this.umd_id = umd_id;
            this.pec_iva = pec_iva;
            this.var_id = var_id;
            this.pec_Convercion = pec_Convercion;
        }


        public ParExcel_Columna(string tco_nombre, string pec_columna,
            long pec_id, long pex_id, long tco_id, long pec_fila,
            long pec_estado, string pex_hoja, string pex_codigo, string mer_nombre,
            string umd_nombre, long mer_id, long umd_id, bool pec_iva, long var_id, long pec_Convercion)
        {
            this.pec_id = pec_id;
            this.pex_id = pex_id;
            this.pec_columna = pec_columna;
            this.pec_fila = pec_fila;
            this.tco_id = tco_id;
            this.pec_estado = pec_estado;
            this.var_id = var_id;
            this.tco_nombre = tco_nombre;
            this.pex_hoja = pex_hoja;
            this.pex_codigo = pex_codigo;
            this.umd_nombre = umd_nombre;
            this.mer_nombre = mer_nombre;
            this.mer_id = mer_id;
            this.umd_id = umd_id;
            this.pec_iva = pec_iva;
            this.pec_Convercion = pec_Convercion;
        }


        public long Pec_id //0
        {
            get { return pec_id; }
            set { pec_id = value; }
        }



        public long Pex_id //1
        {
            get { return pex_id; }
            set { pex_id = value; }
        }


        public long Tco_id //3
        {
            get { return tco_id; }
            set { tco_id = value; }
        }



        public string Pec_Columna //4
        {
            get { return pec_columna; }
            set { pec_columna = value; }
        }


        public long Pec_fila //5
        {
            get { return pec_fila; }
            set { pec_fila = value; }
        }

        public long Mer_id //6
        {
            get { return mer_id; }
            set { mer_id = value; }
        }


        public long Umd_id //7
        {
            get { return umd_id; }
            set { umd_id = value; }
        }


        public bool Pec_iva //8 
        {
            get { return pec_iva; }
            set { pec_iva = value; }
        }


        public long Pec_Estado //9
        {
            get { return pec_estado; }
            set { pec_estado = value; }
        }


        public long Var_id //10
        {
            get { return var_id; }
            set { var_id = value; }
        }


        public long Pec_Convercion
        {
            get { return pec_Convercion; }
            set { pec_Convercion = value; }
        }




        public string Pec_Convercion_String
        {
            get { return pec_Convercion_string; }
            set { pec_Convercion_string = value; }
        }



        public string Tco_nombre 
        {
            get { return tco_nombre; }
            set { tco_nombre = value; }
        }
        
        public string Pex_hoja
        {
            get { return pex_hoja; }
            set { pex_hoja = value; }
        }

        public string Pex_codigo
        {
            get { return pex_codigo; }
            set { pex_codigo = value; }
        }

        public string Umd_nombre
        {
            get { return umd_nombre; }
            set { umd_nombre = value; }
        }

        public string Mer_nombre
        {
            get { return mer_nombre; }
            set { mer_nombre = value; }
        }


        public string Var_nombre
        {
            get { return var_nombre; }
            set { var_nombre = value; }
        }

        public string Var_codigo
        {
            get { return var_codigo; }
            set { var_codigo = value; }
        }

        public string Var_descripcion
        {
          get { return var_descripcion; }
          set { var_descripcion = value; }
        }
        public string Pxt_codigo
        {
          get { return pxt_codigo; }
          set { pxt_codigo = value; }
        }

        public long Vard_id
        {
            get { return vard_id; }
            set { vard_id = value; }
        }
    }
}
