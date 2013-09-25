
namespace Model
{
    public class Regalia : Bd
    {
        private long reg_id;
        private long ctt_id;
        private long cam_id;
        private long ani_id;
        private long mes_id;
        private long mon_id;
        private string reg_tipo;
        private decimal reg_gasmi; //reg_monto;
        private decimal reg_gasme; //reg_participacion;
        private decimal reg_crudomi; //reg_idh;
        private decimal reg_crudome;
        private decimal reg_glp;
        private decimal reg_total;
        private int reg_estado;

        private string ctt_nombre;
        private string mes_nombre;
        private string mon_nombre;


        public Regalia() { }

        public Regalia(long reg_id, long ctt_id, long ani_id, long mes_id, long mon_id, string reg_tipo, decimal reg_gasmi, decimal reg_gasme, decimal reg_crudomi, decimal reg_crudome, decimal reg_glp, decimal reg_total, int reg_estado)
        {
            this.reg_id = reg_id;
            this.ctt_id = ctt_id;
            this.ani_id = ani_id;
            this.mes_id = mes_id;
            this.mon_id = mon_id;
            this.reg_tipo = reg_tipo;
            this.reg_gasmi = reg_gasmi;
            this.reg_gasme = reg_gasme;
            this.reg_crudomi = reg_crudomi;
            this.reg_crudome = reg_crudome;
            this.reg_glp = reg_glp;
            this.reg_total = reg_total;
            this.reg_estado = reg_estado;
        }
        public long Reg_id
        {
            get { return reg_id; }
            set { reg_id = value; }
        }
        public long Ctt_id
        {
            get { return ctt_id; }
            set { ctt_id = value; }
        }
        public long Ani_id
        {
            get { return ani_id; }
            set { ani_id = value; }
        }
        public long Mes_id
        {
            get { return mes_id; }
            set { mes_id = value; }
        }
        public long Mon_id
        {
            get { return mon_id; }
            set { mon_id = value; }
        }
        public string Reg_tipo
        {
            get { return reg_tipo; }
            set { reg_tipo = value; }
        }
        public decimal Reg_gasmi
        {
            get { return reg_gasmi; }
            set { reg_gasmi = value; }
        }
        public decimal Reg_gasme
        {
            get { return reg_gasme; }
            set { reg_gasme = value; }
        }
        public decimal Reg_crudomi
        {
            get { return reg_crudomi; }
            set { reg_crudomi = value; }
        }
        public decimal Reg_crudome
        {
            get { return reg_crudome; }
            set { reg_crudome = value; }
        }
        public decimal Reg_glp
        {
            get { return reg_glp; }
            set { reg_glp = value; }
        }
        public decimal Reg_total
        {
            get { return reg_total; }
            set { reg_total = value; }
        }
        public int Reg_estado
        {
            get { return reg_estado; }
            set { reg_estado = value; }
        }

        public long Cam_id
        {
            get { return cam_id; }
            set { cam_id = value; }
        }
        /**********************************/
        public string Ctt_nombre
        {
            get { return ctt_nombre; }
            set { ctt_nombre = value; }
        }
        public string Mes_nombre
        {
            get { return mes_nombre; }
            set { mes_nombre = value; }
        }
        public string Mon_nombre
        {
            get { return mon_nombre; }
            set { mon_nombre = value; }
        }
        private string reg_tiponombre;
        public string Reg_tiponombre
        {
            get { return reg_tiponombre; }
            set { reg_tiponombre = value; }
        }
        
    }
}