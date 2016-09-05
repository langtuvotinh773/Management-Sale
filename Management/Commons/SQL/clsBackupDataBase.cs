using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Management.Commons.SQL
{
   public static class clsBackupDataBase
    {
       public static bool BackupDataBase(string path)
       {
           try
           {
           SqlConnection con = new SqlConnection(Program.config.ConnectionString);
           SqlCommand command = new SqlCommand();

           command.CommandText = "backup database [" + con.Database + "]to disk =" + "'" + path + "'";
           command.CommandType = CommandType.Text;
           command.Connection = con;

           con.Open();
           command.ExecuteNonQuery();
           con.Close();
           return true;
           }
           catch (Exception)
           {
               return false;
           }
       }
    }
}
