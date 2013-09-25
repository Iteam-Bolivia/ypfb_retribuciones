using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class Campo_Sinonimo: Bd
    {
        private long cas_id;
        private long cam_id;
        private string cas_nombre;
        private int cas_estado;

        private string cam_nombre;

        public Campo_Sinonimo() { }

        public Campo_Sinonimo(long cas_id, long cam_id, string cas_nombre ,int cas_estado)
        {
            this.cas_id = cas_id;
            this.cam_id = cam_id;
            this.cas_nombre = cas_nombre;
            this.cas_estado = cas_estado;
        }
        public long Cas_id
        {
            get { return cas_id; }
            set { cas_id = value; }
        }
        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }
        public string Cas_nombre
        {
            get { return cas_nombre; }
            set { cas_nombre = value; }
        }
        
        public int Cas_estado
        {
            get { return cas_estado; }
            set { cas_estado = value; }
        }

        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }
    }
}