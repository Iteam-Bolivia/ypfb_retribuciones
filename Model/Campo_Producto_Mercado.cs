using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class Campo_Producto_Mercado: Bd
    {
        private long cpm_id;
        private long cam_id;
        private long pro_id;
        private long mer_id;
        private string cpm_preciocom;
        private int cpm_estado;
        public Campo_Producto_Mercado() { }

        public Campo_Producto_Mercado(long cpm_id, long cam_id, long pro_id, long mer_id, string cpm_preciocom, int cpm_estado)
        {
            this.cpm_id = cpm_id;
            this.cam_id = cam_id;
            this.pro_id = pro_id;
            this.mer_id = mer_id;
            this.cpm_preciocom = cpm_preciocom;
            this.cpm_estado = cpm_estado;
        }
        public long Cpm_id
        {
            get { return cpm_id; }
            set { cpm_id = value; }
        }
        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }
        public long Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }
        public long Mer_id
        {
            get { return mer_id; }
            set { mer_id = value; }
        }
        public string Cpm_preciocom
        {
            get { return cpm_preciocom; }
            set { cpm_preciocom = value; }
        }
        public int Cpm_estado
        {
            get { return cpm_estado; }
            set { cpm_estado = value; }
        }

        private string cam_nombre;
        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }
        private string mer_nombre;
        public string Mer_nombre
        {
            get { return mer_nombre; }
            set { mer_nombre = value; }
        }
        private string pro_nombre;
        public string Pro_nombre
        {
            get { return pro_nombre; }
            set { pro_nombre = value; }
        }
        private long cpm_asociacion;
        public long Cpm_asociacion
        {
            get { return cpm_asociacion; }
            set { cpm_asociacion = value; }
        }
    }
}