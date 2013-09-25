using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContratoCampo:Bd
    {
        private long ctc_id;
        private Contrato ctt;
        private Campo cam;
        private long ctc_estado;


        public ContratoCampo() { }




        public ContratoCampo(long ctc_id, Contrato ctt, Campo cam, long ctc_estado)
        {
            this.ctc_id = ctc_id;
            this.ctt = ctt;
            this.cam = cam;
            this.ctc_estado = ctc_estado;
        }

        
        
        public long Ctc_id
        {
            get { return ctc_id; }
            set { ctc_id = value; }
        }



        public Contrato Ctt
        {
            get { return ctt; }
            set { ctt = value; }
        }



        public Campo Cam
        {
            get { return cam; }
            set { cam = value; }
        }



        public long Ctc_estado
        {
            get { return ctc_estado; }
            set { ctc_estado = value; }
        }
    }
}
