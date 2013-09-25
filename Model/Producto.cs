using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Producto : Bd
    {
        private long pro_id;
        private string pro_codigo;
        private string pro_nombre;
        private int pro_estado;
        private long umd_id;
        private int pro_var;
        private int pro_mer;

        public Producto()
        { }

        /// <summary>
        /// Constructor Producto
        /// </summary>
        /// <param name="pro_id">Pro_id</param>
        /// <param name="pro_codigo">Pro_codigo</param>
        /// <param name="pro_nombre">Pro_nombre</param>
        /// <param name="pro_estado">Pro_estado</param>
        public Producto(long pro_id, string pro_codigo, string pro_nombre,
            int pro_estado)
        {
            this.pro_id = pro_id;
            this.pro_codigo = pro_codigo;
            this.pro_nombre = pro_nombre;
            this.pro_estado = pro_estado;
        }
        public Producto(long pro_id, string pro_codigo, string pro_nombre, int pro_estado, long umd_id, int pro_var, int pro_mer)
        {
            this.pro_id = pro_id;
            this.pro_codigo = pro_codigo;
            this.pro_nombre = pro_nombre;
            this.pro_estado = pro_estado;
            this.umd_id = umd_id;
            this.pro_var = pro_var;
            this.pro_mer = pro_mer;

        }
        public long Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }
        public string Pro_codigo
        {
            get { return pro_codigo; }
            set { pro_codigo = value; }
        }
        public string Pro_nombre
        {
            get { return pro_nombre; }
            set { pro_nombre = value; }
        }
        public int Pro_estado
        {
            get { return pro_estado; }
            set { pro_estado = value; }
        }
        public long Umd_id
        {
            get { return umd_id; }
            set { umd_id = value; }
        }

        public int Pro_var
        {
            get { return pro_var; }
            set { pro_var = value; }
        }

        public int Pro_mer
        {
            get { return pro_mer; }
            set { pro_mer = value; }
        }


        #region Propiedades Auxiliares
        private string umd_nombre;
        public string Umd_nombre
        {
            get { return umd_nombre; }
            set { umd_nombre = value; }
        }
        private string lista_mercados;
        public string Lista_Mercados
        {
            get { return lista_mercados; }
            set { lista_mercados = value; }
        }
        private string lista_unidad_medida;
        public string Lista_Unidad_Medida
        {
            get { return lista_unidad_medida; }
            set { lista_unidad_medida = value; }
        }
        #endregion
    }
}