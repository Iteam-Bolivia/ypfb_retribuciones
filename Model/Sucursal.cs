using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Sucursal:Bd
    {
        
        private long suc_id;
        private string suc_codigo;
        private long emp_id;
        private long loc_id;
        private string suc_nosucursal;
        private string suc_nombre;
        private string suc_direccion;
        private string suc_telefono;
        private string suc_responsable;
        private int suc_estado;

        
        public Sucursal()
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="suc_id">suc_id</param>
        /// <param name="suc_codigo">suc_codigo</param>
        /// <param name="emp_id">emp_id</param>
        /// <param name="loc_id">loc_id</param>
        /// <param name="suc_nosucursal">suc_nosucursal</param>
        /// <param name="suc_nombre">suc_nombre</param>
        /// <param name="suc_direccion">suc_direccion</param>
        /// <param name="suc_telefono">suc_telefono</param>
        /// <param name="suc_responsable">suc_responsable</param>
        /// <param name="suc_estado">suc_estado</param>
        public Sucursal(long suc_id, string suc_codigo, long emp_id, long loc_id,
            string suc_nosucursal, string suc_nombre, string suc_direccion,
            string suc_telefono, string suc_responsable, int suc_estado)
        {
            this.suc_id = suc_id;
            this.suc_codigo = suc_codigo;
            this.emp_id = emp_id;
            this.loc_id = loc_id;
            this.suc_nosucursal = suc_nosucursal;
            this.suc_nombre = suc_nombre;
            this.suc_direccion = suc_direccion;
            this.suc_telefono = suc_telefono;
            this.suc_responsable = suc_responsable;
            this.suc_estado = suc_estado;

        }




        public int Suc_estado
        {
            get { return suc_estado; }
            set { suc_estado = value; }
        }


        public string Suc_responsable
        {
            get { return suc_responsable; }
            set { suc_responsable = value; }
        }


        public string Suc_telefono
        {
            get { return suc_telefono; }
            set { suc_telefono = value; }
        }


        public string Suc_direccion
        {
            get { return suc_direccion; }
            set { suc_direccion = value; }
        }
        

        public string Suc_nombre
        {
            get { return suc_nombre; }
            set { suc_nombre = value; }
        }


        public string Suc_nosucursal
        {
            get { return suc_nosucursal; }
            set { suc_nosucursal = value; }
        }
        

        public long Loc_id
        {
            get { return loc_id; }
            set { loc_id = value; }
        }


        public long Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }



        public string Suc_codigo
        {
            get { return suc_codigo; }
            set { suc_codigo = value; }
        }


        public long Suc_id
        {
            get { return suc_id; }
            set { suc_id = value; }
        }

    }
}
