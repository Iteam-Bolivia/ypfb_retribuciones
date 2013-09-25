using System;
using System.IO;

namespace Model
{
    class Csv
    {
        /* Constructor Boot */
        public Csv()
        {
        }/* End Constructor Boot */


        /* Method validateUser */
        public int validateUser(String username, String password)
        {
            string strLine;
            string[] strArray;
            char[] charArray = new char[] { ',' };
            string path = "c:\\users.csv";
            FileStream aFile = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(aFile);

            strLine = sr.ReadLine();
            while (strLine != null)
            {
                strArray = strLine.Split(charArray);
                for (int i = 0; i <= strArray.GetUpperBound(0); i++)
                {
                  if (strArray[1].Trim() == username && strArray[2].Trim() == password)
                    {
                      sr.Close();
                      return System.Convert.ToInt32(strArray[0].Trim());
                    }
                }
                strLine = sr.ReadLine();
            }
            sr.Close();
            return 0;
        }/* End Method validateUser */
    }
}