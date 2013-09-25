using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Variable:Bd
    {
        private long var_id;
        private string var_codigo;
        private string var_nombre;
        private string var_tipo;
        private Decimal var_valini;
        private long var_estado;
        private long var_orden;
        private long umd_id;
        private long tcl_id;
        private long var_impresion;
        private long var_imprime;
        private string var_descripcion;
        private long tpy_id;
        private long mer_id;
        private long pro_id;
        private string var_codigod;
        private string var_total;
        private long vard_id;
        private long var_tipo_cal;
        private long var_posicion;
        private long var_impresion_a;
        private long cam_id;

        private int var_m;
        private int var_cam;
        private int for_m;


        


        public Variable()
        {
        }

        /// <summary>
        /// Constructor Variable
        /// </summary>
        public Variable(long var_id, string var_codigo,
            string var_nombre, string var_tipo, int var_valini,
            int var_estado)
        {
            this.Var_id = var_id;
            this.Var_codigo = var_codigo;
            this.Var_nombre = var_nombre;
            this.Var_tipo = var_tipo;
            this.Var_valini = var_valini;
            this.Var_estado = var_estado;
        }


        public long Var_id
        {
            get { return var_id; }
            set { var_id = value; }
        }

        public string Var_codigo
        {
          get { return var_codigo; }
          set { var_codigo = value; }
        }

        public string Var_nombre
        {
          get { return var_nombre; }
          set { var_nombre = value; }
        }

        public string Var_tipo
        {
          get { return var_tipo; }
          set { var_tipo = value; }
        }

        public Decimal Var_valini
        {
          get { return var_valini; }
          set { var_valini = value; }
        }

        public long Var_estado
        {
          get { return var_estado; }
          set { var_estado = value; }
        }

        public long Var_orden
        {
          get { return var_orden; }
          set { var_orden = value; }
        }

        public long Umd_id
        {
          get { return umd_id; }
          set { umd_id = value; }
        }

        public long Tcl_id
        {
          get { return tcl_id; }
          set { tcl_id = value; }
        }

        public long Var_impresion
        {
            get { return var_impresion; }
            set { var_impresion = value; }
        }

        public long Var_imprime
        {
            get { return var_imprime; }
            set { var_imprime = value; }
        }

        public string Var_descripcion
        {
          get { return var_descripcion; }
          set { var_descripcion = value; }
        }

        public long Tpy_id
        {
          get { return tpy_id; }
          set { tpy_id = value; }
        }

        public long Mer_id
        {
          get { return mer_id; }
          set { mer_id = value; }
        }

        public long Pro_id
        {
          get { return pro_id; }
          set { pro_id = value; }
        }

        public string Var_codigod
        {
          get { return var_codigod; }
          set { var_codigod = value; }
        }

        public string Var_total
        {
          get { return var_total; }
          set { var_total = value; }
        }

        public long Vard_id
        {
          get { return vard_id; }
          set { vard_id = value; }
        }

        public long Var_tipo_cal
        { 
            get { return var_tipo_cal; }
            set { var_tipo_cal = value; }
        }

        public long Var_posicion
        {
            get { return var_posicion; }
            set { var_posicion = value; }
        }

        public long Var_impresion_a
        {
            get { return var_impresion_a; }
            set { var_impresion_a = value; }
        }

        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }

        public int Var_m
        {
          get { return var_m; }
          set { var_m = value; }
        }

        public int Var_cam
        {
          get { return var_cam; }
          set { var_cam = value; }
        }

        public int For_m
        {
          get { return for_m; }
          set { for_m = value; }
        }

        #region


        private string formula;
        public string Formula
        {
          get { return formula; }
          set { formula = value; }
        }
        private string mercado;
        public string Mercado
        {
          get { return mercado; }
          set { mercado = value; }
        }

        private string producto;
        public string Producto
        {
          get { return producto; }
          set { producto = value; }
        }

        private string umd_codigo;
        public string Umd_codigo
        {
          get { return umd_codigo; }
          set { umd_codigo = value; }
        }
        private string tcl_codigo;
        public string Tcl_codigo
        {
          get { return tcl_codigo; }
          set { tcl_codigo = value; }
        }
        private string var_imprime_text;
        public string Var_imprime_text
        {
            get { return var_imprime_text; }
            set { var_imprime_text = value; }
        }

        private string tpy_nombre;
        public string Tpy_nombre
        {
          get { return tpy_nombre; }
          set { tpy_nombre = value; }
        }
        private string vard_codigo;
        public string Vard_codigo
        {
          get { return vard_codigo; }
          set { vard_codigo = value; }
        }

        private long impresionAux;
        public long Impresionaux
        {
            get { return impresionAux; }
            set { impresionAux = value; }
        }


        private string cam_nombre;

        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }

        #endregion

    }
}
