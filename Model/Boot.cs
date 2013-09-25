using System;
using System.IO;

namespace Model
{
    /* Class Boot */
    class Boot
    {
        /* Constructor Boot */
        public Boot()
        {

        } /* End Constructor Boot */


        /* Method obtenerServidor */
        public String obtenerDatos(int linea)
        {
            /* Connection SQL Server */
            String texto = "";
            String ruta = obtenerRutaIni();

            if (ruta != String.Empty)
            {
                //Hago algo con la ruta, como por ejemplo llamar a nuestra 1ra función que
                //nos retorna el contenido del archivo...
                texto = leer(ruta, linea);
                // texto tiene ahora el contenido del archivo
            }
            return texto;
        }/* End Method obtenerServidor */



        /* Method obtenerRutaIni */
        private String obtenerRutaIni()
        {
            String path = String.Empty;
            //obtenemos entonces la ruta al archivo seleccionado
            path = "c:\\sgp.ini";
            return path;
        }/* End Method obtenerRutaIni */




        /* Method leer */
        private String leer(string ruta, int linea)
        {
            int contador = 1;
            String line;
            String texto = "";
            try
            {
                FileStream aFile = new FileStream(ruta, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);

                while (contador <= linea)
                {
                    // line one
                    //texto += line;
                    line = sr.ReadLine();
                    texto = line;
                    contador++;
                }
                aFile.Close();
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return texto;
            }
            return texto;
        }/* Method leer */

    }/* End Class Boot */

}/* End NameSpace Forms */
