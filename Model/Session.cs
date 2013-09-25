/*
 * @author acastellon
 * Session Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Net.NetworkInformation;

namespace Model
{
  class Session
  {
    /// <summary>
    /// Member Data
    /// </summary>   
    /// 
    static long id;
    static long id1;
    static long usu_id;    
    static long suc_id;
    static string suc_nombre;
    static long rol_id;
    static string rol_titulo;
    static string usu_nombres;
    static string usu_apellidos;
    static string usu_login;
    static long usu_estado;
    static string ip;
    static string system;

    // Otras variables
    static long cal_id;
    static long ctt_id;
    static long tcl_id;
    static long ani_id;
    static long mes_id;
    static long var_id;
    static string var_codigo;
    static decimal var_valor;
    static decimal pi;

    static int funcion;

    /// <summary>
    /// Constructor
    /// </summary>    
    public Session()
    {
    }

    /// <summary>
    /// USU_ID Method
    /// </summary>    
    public long ID
    {
      get { return id; }
      set { id = value; }
    }

    /// <summary>
    /// USU_ID Method
    /// </summary>    
    public long ID1
    {
        get { return id1; }
        set { id1 = value; }
    }

    /// <summary>
    /// USU_ID Method
    /// </summary>    
    public long USU_ID
    {
      get { return usu_id; }
      set { usu_id = value; }
    }

    /// <summary>
    /// SUC_ID Method
    /// </summary>
    public long SUC_ID
    {
      get { return suc_id; }
      set { suc_id = value; }
    }

    /// <summary>
    /// SUC_NOMBRE Method
    /// </summary>
    public string SUC_NOMBRE
    {
      get { return suc_nombre; }
      set { suc_nombre = value; }
    }

    /// <summary>
    /// ROL_ID Method
    /// </summary>
    public long ROL_ID
    {
      get { return rol_id; }
      set { rol_id = value; }
    }

    /// <summary>
    /// ROL_TITULO Method
    /// </summary>
    public string ROL_TITULO
    {
      get { return rol_titulo; }
      set { rol_titulo = value; }
    }


    /// <summary>
    /// USU_NOMBRES Method
    /// </summary>
    public string USU_NOMBRES
    {
      get { return usu_nombres; }
      set { usu_nombres = value; }
    }

    /// <summary>
    /// USU_APELLIDOS Method
    /// </summary>
    public string USU_APELLIDOS
    {
      get { return usu_apellidos; }
      set { usu_apellidos = value; }
    }

    /// <summary>
    /// USU_LOGIN Method
    /// </summary>
    public string USU_LOGIN
    {
      get { return usu_login; }
      set { usu_login = value; }
    }

    /// <summary>
    /// USU_ESTADO Method
    /// </summary>
    public long USU_ESTADO
    {
      get { return usu_estado; }
      set { usu_estado = value; }
    }

    /// <summary>
    /// IP Method
    /// </summary>
    public string IP
    {
      get { return ip; }
      set { ip = value; }
    }

    /// <summary>
    /// findIP Method
    /// </summary>
    public String FINDIP()
    {
      String IP = "";
      NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
      foreach (NetworkInterface n in ni)
      {
        IP = n.GetIPProperties().UnicastAddresses[0].Address.ToString();
        break;
      }
      return IP;
    }




    /// <summary>
    /// CAL_ID Method
    /// </summary>
    public long CAL_ID
    {
      get { return cal_id; }
      set { cal_id = value; }
    }


    /// <summary>
    /// CTT_ID Method
    /// </summary>
    public long CTT_ID
    {
      get { return ctt_id; }
      set { ctt_id = value; }
    }


    /// <summary>
    /// TCL_ID Method
    /// </summary>
    public long TCL_ID
    {
      get { return tcl_id; }
      set { tcl_id = value; }
    }


    /// <summary>
    /// MES_ID Method
    /// </summary>
    public long MES_ID
    {
      get { return mes_id; }
      set { mes_id = value; }
    }

    /// <summary>
    /// ANI_ID Method
    /// </summary>
    public long ANI_ID
    {
      get { return ani_id; }
      set { ani_id = value; }
    }




    /// <summary>
    /// VAR_ID Method
    /// </summary>
    public long VAR_ID
    {
        get { return var_id; }
        set { var_id = value; }
    }
    /// <summary>
    /// VAR_CODIGO Method
    /// </summary>
    public string VAR_CODIGO
    {
        get { return var_codigo; }
        set { var_codigo = value; }
    }

    /// <summary>
    /// VAR_VALOR Method
    /// </summary>
    public decimal VAR_VALOR
    {
        get { return var_valor; }
        set { var_valor = value; }
    }


    /// <summary>
    /// PI Method
    /// </summary>
    public decimal PI
    {
      get { return pi; }
      set { pi = value; }
    }


    /// <summary>
    /// FUNCION Method
    /// </summary>
    public int FUNCION
    {
      get { return funcion; }
      set { funcion = value; }
    }

    /// <summary>
    /// SISTEMA Method
    /// </summary>
    public string SISTEMA
    {
      get { return system; }
      set { system = value; }
    }

  }/* End Class Session */
}/* End namespace View*/