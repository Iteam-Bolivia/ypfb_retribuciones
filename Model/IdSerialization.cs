/*
 * @author acastellon
 * IdSerialization Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;

/* namespace Model*/
namespace Model
{
    /* Class IdSerialization */
    class IdSerialization
    {
        // Data of Login

        static int id;

        /* Constructor IdSerialization */
        public IdSerialization()
        {
        }/* End Constructor IdSerialization */

        /* Method Id */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }/* Method IdUnidad */

    }/* End Class IdSerialization */
}/* End namespace View*/