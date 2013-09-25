

/*
 * @author acastellon
 * Bd Class
 * Created on 18 de Agosto de 2011, 10:00 AM
 */

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace Model
{
  /// <summary>
  /// Class Bd
  /// </summary>
  public class Bd
  {



    /// <summary>
    /// Data Members
    /// </summary>
    /// ODBC
    //public string DBConnection = "DSN=dsn_ypfb_retribuciones;";
    public string DBConnection = "";
    public static string SQL;
    public static ADODB.Connection cnn = new ADODB.Connection();
    public static ADODB.Recordset rs = new ADODB.Recordset();
    public static ADODB.Recordset rs2 = new ADODB.Recordset();
    public static ADODB.Recordset rs3 = new ADODB.Recordset();
    Hashtable args = new Hashtable();
    public string tableName;
    public string fieldName;
    public string dataType;
    public List<Bd> tableStructure;
    public string primaryKey;

    /// <summary>
    /// Constructor Bd
    /// </summary>
    public Bd()
    {
      // GET CONNECTION STRING
      StreamReader objReader = new StreamReader("ypfb_retribuciones.ini");
      string strLine = "";
      ArrayList arrConnect = new ArrayList();
      while (strLine != null)
      {
        strLine = objReader.ReadLine();
        if (strLine != null)
          arrConnect.Add(strLine);
      }
      objReader.Close();
      Session objSession = new Session();
      objSession.SISTEMA = (string)arrConnect[0];
      DBConnection = "DSN=" + arrConnect[1] + ";";
      // END GET CONNECTION STRING

      //DBConnection = "DSN=dsn_ypfb_retribuciones;";

      // GET TABLE STRUCTURE
      this.tableName = getTableName(GetType().Name);

    } /* End Constructor Bd */


    /// <summary>
    /// Constructs Insert object
    /// </summary>
    /// <param name="tableName">tableName name to insert to</param>
    public Bd(string fieldName, string dataType)
    {
      this.fieldName = fieldName;
      this.dataType = dataType;
    }

    /// <summary>
    /// Constructs Insert object
    /// </summary>
    /// <param name="tableName">tableName name to insert to</param>
    public string getTableName(string name)
    {
      try
      {
        string nameTable = "";
        char[] delimiterChars = { ' ', 'O', '\t' };
        string[] words = name.Split(delimiterChars);
        foreach (string s in words)
        {
          nameTable = s;
          break;
        }
        nameTable = "tab_" + nameTable;
        return nameTable.ToLower();
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (getTableName): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
        return "";
      }
    }



    /// <summary>
    /// Connection_On Method
    /// Conexión a la BD
    /// </summary>
    public ADODB.Connection Connection_On()
    {
      try
      {
        // ADODB Connection
        if (cnn.State == 0)
        {
          cnn.Open(DBConnection);
        }
        return cnn;
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (Connection_On): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
        return null;
      }
    }


    /// <summary>
    /// Connection_Off Method
    /// Desconexión a la Bd
    /// </summary>
    public void Connection_Off(int record)
    {
      try
      {
        if (cnn != null)
        {
          switch (record)
          {
            case 1:
              if (rs.State != 0)
              {
                rs.Close();
              }
              break;
            case 2:
              if (rs2.State != 0)
              {
                rs2.Close();
              }
              break;
            case 3:
              if (rs3.State != 0)
              {
                rs3.Close();
              }
              break;
            case 0:
              if (rs3.State != 0)
              {
                rs3.Close();
              }
              if (rs2.State != 0)
              {
                rs2.Close();
              }
              if (rs.State != 0)
              {
                rs.Close();
              }
              if (cnn.State != 0)
              {
                cnn.Close();
              }
              break;
          }
        }
      }
      catch (Exception e)
      {
        if (rs.State != 0)
        {
          rs.Close();
        }
        if (rs2.State != 0)
        {
          rs2.Close();
        }
        if (rs3.State != 0)
        {
          rs3.Close();
        }
        if (cnn.State != 0)
        {
          cnn.Close();
        }
        Console.WriteLine("ERROR: Class Bd (Connection_Off): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
      }

    }
    


    



    /// <summary>
    /// Connection_Off Method
    /// Desconexión a la Bd
    /// </summary>
    public void Connection_Off(ADODB.Connection cnnoff)
    {
      try
      {
        if (cnnoff != null)
        {
          if (rs.State != 0)
          {
            rs.Close();
            rs = null;
          }
          if (rs2.State != 0)
          {
            rs2.Close();
            rs2 = null;
          }
          if (rs3.State != 0)
          {
            rs3.Close();
          }
          if (cnnoff.State != 0)
          {
            cnnoff.Close();
            cnnoff = null;
          }
        }
      }
      catch (Exception e)
      {
        if (rs.State != 0)
        {
          rs.Close();
        }
        if (rs2.State != 0)
        {
          rs2.Close();
        }
        if (rs3.State != 0)
        {
          rs3.Close();
        }
        if (cnnoff.State != 0)
        {
          cnnoff.Close();
        }
        Console.WriteLine("ERROR: Class Bd (Connection_Off): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
      }
      finally
      {
        //cnn.Close();
      }
    }

    /* Method getTableStructure */
    public List<Bd> getTableStructure()
    {
      int count = 0;
      List<Bd> lstFields = new List<Bd>();
      try
      {
        // Open Connection object
        Connection_On();
        // Fill list
        object[] arry = new object[] { null, null, this.tableName };
        rs = cnn.OpenSchema(ADODB.SchemaEnum.adSchemaColumns, arry, Missing.Value);
        while (!rs.EOF)
        {
          if (count == 0)
          {
            this.primaryKey = rs.Fields["COLUMN_NAME"].Value.ToString();
          }
          lstFields.Add(new Bd(rs.Fields["COLUMN_NAME"].Value.ToString(), rs.Fields["DATA_TYPE"].Value.ToString()));
          rs.MoveNext();
          count++;
        }
        Connection_Off(0);
        return lstFields;
      }
      catch (COMException e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (getTableStructure): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
        return lstFields;
      }
    }


    public long getPrimaryKey()
    {
      try
      {
        long valor_id = 0;
        //para devolver el siguiente valor de la secuencia
        SQL = "SELECT nextval('" + this.tableName + "_" + this.primaryKey + "_seq')";
        // Open Connection object
        Connection_On();
        // Execute the query specifying static sursor, batch optimistic locking
        rs.Open(SQL, cnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);
        if (rs.EOF)
        {
          Console.WriteLine("Error");
        }
        else
        {
          if (!rs.EOF)
          {
            valor_id = System.Convert.ToInt64(rs.Fields["nextval"].Value);
          }
        }
        Connection_Off(1);
        return valor_id;
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (getPrimaryKey): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
        return 0;
      }


    }


    /// <summary>
    /// insert
    /// </summary>
    /// <returns>System.String</returns>
    public long insert(object list)
    {
      long inserted = 0;
      StringBuilder s1 = new StringBuilder();
      StringBuilder s2 = new StringBuilder();

      // Modified
      this.tableStructure = getTableStructure();
      try
      {
        // List Values
        /* Begin */
        DataTable dt = null;

        Type listType = list.GetType();
        if (listType.IsGenericType)
        {
          //determine the underlying type the List<> contains 
          Type elementType = listType.GetGenericArguments()[0];

          //create empty table -- give it a name in case it needs to be serialized 
          dt = new DataTable(elementType.Name + "List");

          //define the table -- add a column for each public property or field 
          MemberInfo[] miArray = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
          foreach (MemberInfo mi in miArray)
          {
            if (mi.MemberType == MemberTypes.Property)
            {
              PropertyInfo pi = mi as PropertyInfo;
              dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            else if (mi.MemberType == MemberTypes.Field)
            {
              FieldInfo fi = mi as FieldInfo;
              dt.Columns.Add(fi.Name, fi.FieldType);
            }
          }

          //populate the table 
          IList il = list as IList;
          foreach (object record in il)
          {
            int i = 0;
            object[] fieldValues = new object[dt.Columns.Count];
            object[] fieldNames = new object[dt.Columns.Count];

            foreach (DataColumn c in dt.Columns)
            {
              MemberInfo mi = elementType.GetMember(c.ColumnName)[0];
              if (mi.MemberType == MemberTypes.Property)
              {
                PropertyInfo pi = mi as PropertyInfo;
                fieldValues[i] = pi.GetValue(record, null);
                fieldNames[i] = pi.Name.ToString();
              }
              else if (mi.MemberType == MemberTypes.Field)
              {
                FieldInfo fi = mi as FieldInfo;
                fieldValues[i] = fi.GetValue(record);
              }
              i++;
            }

            int k = 0;
            tableStructure.ForEach(delegate(Bd bd)
            {
              if (this.primaryKey == bd.fieldName)
              {
                inserted = this.getPrimaryKey();
                this.addField(bd.fieldName, "'" + inserted + "'");

                k++;
              }
              else
              {
                this.addField(bd.fieldName, "'" + fieldValues[k] + "'");
                k++;
              }
            });

          }
        }

        // Values
        IDictionaryEnumerator enumInterface = args.GetEnumerator();
        bool first = true;
        while (enumInterface.MoveNext())
        {
          if (first) first = false;
          else
          {
            s1.Append(", ");
            s2.Append(", ");
          }
          s1.Append(enumInterface.Key.ToString());
          s2.Append(enumInterface.Value.ToString());
        }

        SQL = "INSERT INTO " + this.tableName + " (" + s1 + ") VALUES (" + s2 + ");";
        object ab;
        this.Connection_On();
        cnn.Execute(SQL, out ab, 0);
        Connection_Off(0);
        return inserted;
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Clase Bd: {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message + " Query: " + SQL, objLog.w);
        inserted = 0;
        return inserted;
      }
    }




    /// <summary>
    /// update
    /// </summary>
    /// <returns>void</returns>
    public long update(object list)
    {
      long updated = 0;

      StringBuilder s1 = new StringBuilder();
      StringBuilder s2 = new StringBuilder();
      string condition = "";

      // Modified
      this.tableStructure = getTableStructure();

      try
      {
        // List Values
        /* Begin */
        DataTable dt = null;

        Type listType = list.GetType();
        if (listType.IsGenericType)
        {
          //determine the underlying type the List<> contains 
          Type elementType = listType.GetGenericArguments()[0];

          //create empty table -- give it a name in case it needs to be serialized 
          dt = new DataTable(elementType.Name + "List");

          //define the table -- add a column for each public property or field 
          MemberInfo[] miArray = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
          foreach (MemberInfo mi in miArray)
          {
            if (mi.MemberType == MemberTypes.Property)
            {
              PropertyInfo pi = mi as PropertyInfo;
              dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            else if (mi.MemberType == MemberTypes.Field)
            {
              FieldInfo fi = mi as FieldInfo;
              dt.Columns.Add(fi.Name, fi.FieldType);
            }
          }

          //populate the table 
          IList il = list as IList;
          foreach (object record in il)
          {
            int i = 0;
            object[] fieldValues = new object[dt.Columns.Count];
            object[] fieldNames = new object[dt.Columns.Count];

            foreach (DataColumn c in dt.Columns)
            {
              MemberInfo mi = elementType.GetMember(c.ColumnName)[0];
              if (mi.MemberType == MemberTypes.Property)
              {
                PropertyInfo pi = mi as PropertyInfo;
                fieldValues[i] = pi.GetValue(record, null);
                fieldNames[i] = pi.Name.ToString();
              }
              else if (mi.MemberType == MemberTypes.Field)
              {
                FieldInfo fi = mi as FieldInfo;
                fieldValues[i] = fi.GetValue(record);
              }
              i++;
            }

            // Values
            int k = 0;
            tableStructure.ForEach(delegate(Bd bd)
            {
              if (this.primaryKey == bd.fieldName)
              {
                condition = bd.fieldName + "=" + fieldValues[k];
                k++;
              }
              else
              {
                this.addField(bd.fieldName, "'" + fieldValues[k] + "'");
                k++;
              }

            });

          }
        }

        IDictionaryEnumerator enumInterface = args.GetEnumerator();
        bool first = true;
        while (enumInterface.MoveNext())
        {
          if (first) first = false;
          else
          {
            s1.Append(", ");
          }
          s1.Append(enumInterface.Key.ToString() + "=" + enumInterface.Value.ToString());
        }
        string SQL = "UPDATE " + this.tableName + " SET " + s1 + " WHERE " + condition + ";";

        object ab;
        Connection_On();
        cnn.Execute(SQL, out ab, 0);
        Connection_Off(0);
        updated = 1;
        return updated;
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (update): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message + " Query: " + SQL, objLog.w);
        updated = 0;
        return updated;
      }
    }
    


   


    /// <summary>
    /// delete
    /// </summary>
    /// <returns>void</returns>
    public long delete(string condition)
    {
      long deleted = 0;
      string query = "";
      if (condition == "")
      {
        query = "DELETE FROM " + this.tableName + " ;";
      }
      else
      {
        query = "DELETE FROM " + this.tableName + " WHERE " + condition + ";";
      }
      try
      {
        object ab;
        this.Connection_On();
        SQL = query;
        cnn.Execute(SQL, out ab, 0);
        Connection_Off(0);
        deleted = 1;
        return deleted;
      }
      catch (Exception e)
      {
        Connection_Off(0);
        Console.WriteLine("ERROR: Class Bd (delete): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message + " Query: " + SQL, objLog.w);
        deleted = 0;
        return deleted;
      }
    }


    /// <summary>
    /// Adds item to Insert object
    /// </summary>
    /// <param name="name">item name</param>
    /// <param name="val">item value</param>
    public void addField(string name, object val)
    {
      args.Add(name, val);
    }

    /// <summary>
    /// Gets or sets item into Insert object
    /// </summary>
    object this[string key]
    {
      get
      {
        Debug.Assert(args.Contains(key), "Key not found");
        return args[key];
      }
      set { args[key] = value; }
    }

    /// <summary>
    /// Removes item from Insert object
    /// </summary>
    /// <param name="name">item name</param>
    public void Remove(string name)
    {
      try
      {
        args.Remove(name);
      }
      catch
      {
        throw (new Exception("No such item"));
      }
    }


    public override string ToString()
    {
      StringBuilder s1 = new StringBuilder();
      StringBuilder s2 = new StringBuilder();

      IDictionaryEnumerator enumInterface = args.GetEnumerator();
      bool first = true;
      while (enumInterface.MoveNext())
      {
        if (first) first = false;
        else
        {
          s1.Append(", ");
          s2.Append(", ");
        }
        s1.Append(enumInterface.Key.ToString());
        s2.Append(enumInterface.Value.ToString());
      }

      return "INSERT INTO " + tableName + " (" + s1 + ") VALUES (" + s2 + ");";
    }




    /// <summary>
    /// function to convert recordset to datatable
    /// </summary>
    /// <param name="rs">recordset object that need to be created to datatable</param>
    /// <returns>
    /// </returns>
    private static DataTable RstoDataTable(ADODB.Recordset rs)
    {
      DataTable dt = new DataTable("Test");

      try
      {
        foreach (ADODB.Field fld in rs.Fields)
        {
          Type ttype = fld.GetType();
          DataColumn dc_column = new DataColumn("column");

          switch (fld.Type)
          {
            case ADODB.DataTypeEnum.adNumeric:
              dc_column.DataType = System.Type.GetType("System.Double");
              break;
            case ADODB.DataTypeEnum.adCurrency:
              dc_column.DataType = System.Type.GetType("System.Decimal");
              break;
            case ADODB.DataTypeEnum.adChar:
              dc_column.DataType = System.Type.GetType("System.String");
              break;
            case ADODB.DataTypeEnum.adWChar:
              dc_column.DataType = System.Type.GetType("System.String");
              break;
            case ADODB.DataTypeEnum.adVarChar:
              dc_column.DataType = System.Type.GetType("System.String");
              break;
            case ADODB.DataTypeEnum.adInteger:
              dc_column.DataType = System.Type.GetType("System.Int32");
              break;
            case ADODB.DataTypeEnum.adDBTimeStamp:
              dc_column.DataType = System.Type.GetType("System.DateTime");
              break;
            case ADODB.DataTypeEnum.adDBDate:
              dc_column.DataType = System.Type.GetType("System.DateTime");
              break;
            default:
              System.Diagnostics.Debug.Assert(false);
              break;
          }

          dt.Columns.Add(new DataColumn(fld.Name, dc_column.DataType));
        }

        object[] vals = new object[rs.Fields.Count];

        while (!rs.EOF)
        {
          int nFldCnt = 0;

          foreach (ADODB.Field fld in rs.Fields)
          {
            vals[nFldCnt] = fld.Value;
            nFldCnt += 1;
          }

          dt.Rows.Add(vals);

          rs.MoveNext();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("ERROR: Class Bd (RstoDataTable): {0} ", e);
        Log objLog = new Log();
        objLog.InsertLog(e.Message, objLog.w);
      }
      return dt;
    }


    /// <summary>
    /// function to convert recordset to dataset
    /// </summary>
    /// <param name="rs">recordset object that need to be created to datatable</param>
    /// <returns>
    /// </returns>
    public DataSet RstoDataSet(ADODB.Recordset rs, string nameDataTable, DataSet dsReports)
    {
      {
        //Create and fill the dataset from the recordset and populate grid from Dataset. 
        OleDbDataAdapter da = new OleDbDataAdapter();
        //DataSet ds = new DataSet("MyTable");
        da.Fill(dsReports, rs, nameDataTable);

        //Return DataSet
        return dsReports;
      }
    }
  } /* Constructor Connection Pool */

} /* End NameSpace */

