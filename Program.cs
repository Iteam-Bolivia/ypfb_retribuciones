using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ypfbApplication.View;
using ypfbApplication.Model;
using View;
using System.Globalization;
using System.Threading;

namespace SGPApplication
{
  static class Program
  {
    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // Formato de Fecha
      CultureInfo en = new CultureInfo("en-US");
      Thread.CurrentThread.CurrentCulture = en;
      //TimeZone localZone = TimeZone.CurrentTimeZone;
      en.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
      en.DateTimeFormat.LongDatePattern = "yyyy-MM-dd HH:mm:ss";
      Thread.CurrentThread.CurrentCulture = en;


      //
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new frmLog());
      //Application.Run(new frmCalculoProyeccion());
    }
  }
}
