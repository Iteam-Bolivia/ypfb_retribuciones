/*
 * @author acastellon
 * CriteriaSerialization Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;

/* namespace Model*/
namespace Model
{
    /* Class CriteriaSerialization */
    class CriteriaSerialization
    {
        // Data of Login
        static int idcriteriotipoproyecto;
        static string numerofila;
        static string nombrecriterio;
        static string descripcionvariablecriterio;

        /*
        static string unidad;
        static string tipovariable;
        static string operadorvariable; 
        */

        /* Constructor CriteriaSerialization */
        public CriteriaSerialization()
        {
        }/* End Constructor CriteriaSerialization */


        /* Method IdCriterioTipoProyecto */
        public int IdCriterioTipoProyecto
        {
            get { return idcriteriotipoproyecto; }
            set { idcriteriotipoproyecto = value; }
        }/* Method IdCriterioTipoProyecto */

        /* Method NumeroFila */
        public string NumeroFila
        {
            get { return numerofila; }
            set { numerofila = value; }
        }/* Method NumeroFila */

        /* Method NombreCriterio */
        public string NombreCriterio
        {
            get { return nombrecriterio; }
            set { nombrecriterio = value; }
        }/* End Method NombreCriterio */


        /* Method DescripcionVariableCriterio */
        public string DescripcionVariableCriterio
        {
            get { return descripcionvariablecriterio; }
            set { descripcionvariablecriterio = value; }
        }/* End Method DescripcionVariableCriterio */


    }/* End Class CriteriaSerialization */
}/* End namespace Model */