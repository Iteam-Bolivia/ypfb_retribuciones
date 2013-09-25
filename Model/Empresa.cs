
namespace Model
{ /* Class Empresa*/
  public class Empresa : Bd
  {
    private long emp_id;
    private string emp_nit;
    private string emp_nombre;
    private string emp_propietario;
    private string emp_dir;
    private string emp_telefono;
    private string emp_email;
    private long emp_estado;
    

    //Method Empresa
    public Empresa() 
    { 
    }

    // Method Empresa
    public Empresa(long emp_id, string emp_nit, string emp_nombre, string emp_propietario, string emp_dir, string emp_telefono, string emp_email, long emp_estado)
    {
      this.emp_id = emp_id;
      this.emp_nit = emp_nit;
      this.emp_nombre = emp_nombre;
      this.emp_propietario = emp_propietario;
      this.emp_dir = emp_dir;
      this.emp_telefono = emp_telefono;
      this.emp_email = emp_email;
      this.emp_estado = emp_estado;
    }

   
    // method set get

    public long Emp_id
    {
      get { return emp_id; }
      set { emp_id = value; }
    }

    public string Emp_nit 
    {
      get { return emp_nit; }
      set { emp_nit = value; }
    }

    public string Emp_nombre
    {
      get { return emp_nombre; }
      set { emp_nombre = value; }
    }

    public string Emp_propietario
    {
      get { return emp_propietario; }
      set { emp_propietario = value; }
    }

    public string Emp_dir
    {
      get { return emp_dir; }
      set { emp_dir = value; }
    }

    public string Emp_telefono
    {
      get { return emp_telefono; }
      set { emp_telefono = value; }
    }

    public string Emp_email
    {
      get { return emp_email; }
      set { emp_email = value; }
    }

    public long Emp_estado
    {
      get { return emp_estado; }
      set { emp_estado = value; }
    }

  }
}