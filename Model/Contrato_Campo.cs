using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Contrato_Campo : Bd
    {
        private long ctc_id;        
        private long ctt_id;
        private long cam_id;        
        private long ctc_estado;

        public Contrato_Campo() { }


        public Contrato_Campo(long ctc_id, long ctt_id, long cam_id, int ctc_estado)
        {
            this.ctc_id = ctc_id;
            this.ctt_id = ctt_id;
            this.cam_id = cam_id;
            this.ctc_estado = ctc_estado;
        }

        //public ContratoCampo(long ctc_id, Contrato ctt, Campo cam, long ctc_estado)
        //{
        //    this.ctc_id = ctc_id;
        //    this.ctt = ctt;
        //    this.cam = cam;
        //    this.ctc_estado = ctc_estado;
        //}



        public long Ctc_id
        {
            get { return ctc_id; }
            set { ctc_id = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }
        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }

        public long Ctc_estado
        {
            get { return ctc_estado; }
            set { ctc_estado = value; }
        }

        //private Contrato ctt;
        //private Campo cam;
        //public Contrato Ctt
        //{
        //    get { return ctt; }
        //    set { ctt = value; }
        //}
        //public Campo Cam
        //{
        //    get { return cam; }
        //    set { cam = value; }
        //}        
        private string cam_nombre;

        public string Cam_nombre
        {
            get { return cam_nombre; }
            set { cam_nombre = value; }
        }

        private string lista_productos;
        public string Lista_Productos
        {
            get { return lista_productos; }
            set { lista_productos = value; }
        }
        private string lista_mercados;

        public string Lista_Mercados
        {
            get { return lista_mercados; }
            set { lista_mercados = value; }
        }        
    }
}