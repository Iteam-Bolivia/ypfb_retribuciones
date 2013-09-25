using System;
using System.IO;

namespace Model
{
  public class Log
  {
    public StreamWriter w = File.AppendText("logs.txt");

    //public static void Main(String[] args)
    //{
    //  using (StreamWriter w = File.AppendText("log.txt"))
    //  {
    //    Log("Test1", w);
    //    Log("Test2", w);
    //    // Close the writer and underlying file.
    //    w.Close();
    //  }
    //  // Open and read the file.
    //  using (StreamReader r = File.OpenText("log.txt"))
    //  {
    //    DumpLog(r);
    //  }
    //}


    public void InsertLog(String logMessage, TextWriter w)
    {
      w.WriteLine("{0} {1} ", DateTime.Now, logMessage);
      // Update the underlying file.
      w.Flush();
      w.Close();
    }

    public static void DumpLog(StreamReader r)
    {
      // While not at the end of the file, read and write lines.
      String line;
      while ((line = r.ReadLine()) != null)
      {
        Console.WriteLine(line);
      }
      r.Close();
    }

  }
}