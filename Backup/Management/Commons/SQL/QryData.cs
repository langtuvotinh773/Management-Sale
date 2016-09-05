using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace Management.Commons.SQL
{
   public class QryData
    {
       private SqlDataAdapter adQuery;
       private bool bBeginTrans;
       private SqlConnection cnConnect;
       private int intTimeOut;
       private SqlTransaction tsTrans;
       public QryData(SqlConnection cnConn)
       {
           this.cnConnect = cnConn;
           this.adQuery = new SqlDataAdapter();
           this.intTimeOut = 600;
           this.bBeginTrans = false;
       }

       public QryData(string strConnect)
       {
           this.cnConnect = new SqlConnection(strConnect);
           this.adQuery = new SqlDataAdapter();
           this.intTimeOut = 600;
           this.bBeginTrans = false;
       }
       public void BeginTrans()
       {
           if (this.cnConnect.State != ConnectionState.Open)
           {
               this.cnConnect.Open();
           }
           this.tsTrans = this.cnConnect.BeginTransaction();
           this.bBeginTrans = true;
       }
       public void CloseConnect()
       {
           try
           {
               if (this.cnConnect.State != ConnectionState.Closed)
               {
                   this.cnConnect.Close();
               }
           }
           catch (Exception exception1)
           {
           }
       }
       public void CommitTrans()
       {
           this.tsTrans.Commit();
           this.bBeginTrans = false;
           this.CloseConnect();
       }

       public int Exec(SqlCommand cmExec)
       {
           cmExec.Connection = this.cnConnect;
           cmExec.CommandTimeout = this.intTimeOut;
           try
           {
               if (this.bBeginTrans)
               {
                   cmExec.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return cmExec.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }

       public int Exec(SqlCommand cmExec, QryParam Param)
       {
           cmExec.Connection = this.cnConnect;
           cmExec.CommandTimeout = this.intTimeOut;
           try
           {
               Param.AddToCommand(cmExec);
               if (this.bBeginTrans)
               {
                   cmExec.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return cmExec.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }

       public object ExecScalar(SqlCommand cmExec)
       {
           cmExec.Connection = this.cnConnect;
           cmExec.CommandTimeout = this.intTimeOut;
           try
           {
               if (this.bBeginTrans)
               {
                   cmExec.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(cmExec.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public object ExecScalar(SqlCommand cmExec, QryParam Param)
       {
           cmExec.Connection = this.cnConnect;
           cmExec.CommandTimeout = this.intTimeOut;
           try
           {
               Param.AddToCommand(cmExec);
               if (this.bBeginTrans)
               {
                   cmExec.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(cmExec.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public object ExecScalarSQL(string SqlName)
       {
           SqlCommand command = new SqlCommand(SqlName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public object ExecScalarSQL(string SqlName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(SqlName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           Param.AddToCommand(cmCommand);
           try
           {
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(cmCommand.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public object ExecScalarStore(string StoreName)
       {
           SqlCommand command = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public object ExecScalarStore(string StoreName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           Param.AddToCommand(cmCommand);
           try
           {
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return RuntimeHelpers.GetObjectValue(cmCommand.ExecuteScalar());
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public int ExecSQL(string SqlName)
       {
           SqlCommand command = new SqlCommand(SqlName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return command.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }

       public int ExecSQL(string SqlName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(SqlName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           Param.AddToCommand(cmCommand);
           try
           {
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return cmCommand.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }

       public int ExecStore(string StoreName)
       {
           SqlCommand command = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return command.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }
       public void InsertLogData(string StoreName,string TypeAction, string InsertBy, string ScreenName, string Data)
       {
           QryParam Param = new QryParam();
           Param.Clear();
           Param.Add("@InsertDate", SqlDbType.DateTime, DateTime.Now);
           Param.Add("@Type", SqlDbType.NVarChar, TypeAction);
           Param.Add("@InsertBy", SqlDbType.NVarChar, InsertBy);
           Param.Add("@ScreenName", SqlDbType.NVarChar, ScreenName);
           Param.Add("@Data", SqlDbType.NVarChar, Data);
           ExecStore(StoreName, Param);
       }
       public int ExecStore(string StoreName, QryParam Param, out string setData)
       {
           SqlCommand cmCommand = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           Param.AddToCommand(cmCommand);
           setData = string.Empty;
           try
           {
               #region Get paramater value
               for (int i = 0; i < cmCommand.Parameters.Count; i++)
               {
                   string itemParameter = "'" + Common.ParseString(cmCommand.Parameters[i].Value) + "'";
                   if (i == 0)
                   {
                       setData = StoreName + " " + itemParameter;
                   }
                   else
                   {
                       setData = setData + "," + itemParameter;
                   }
               }
               #endregion

               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return cmCommand.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }
       public int ExecStore(string StoreName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           Param.AddToCommand(cmCommand);
           try
           {
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               return cmCommand.ExecuteNonQuery();
           }
           catch (Exception exception1)
           {
               
           }
           finally
           {

               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return -1;
       }
       public DataTable GetTableSQL(string SQLName)
       {
           return this.GetTableSQL("NoTableName", SQLName);
       }

       public DataTable GetTableSQL(string SQLName, QryParam Param)
       {
           return this.GetTableSQL("NoTableName", SQLName, Param);
       }

       public DataTable GetTableSQL(string TableName, string SQLName)
       {
           SqlCommand command = new SqlCommand(SQLName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           DataSet dataSet = new DataSet();
           this.adQuery.SelectCommand = command;
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (TableName == "")
               {
                   TableName = "TableTemp";
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               this.adQuery.Fill(dataSet, TableName);
               return dataSet.Tables[TableName];
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.CloseConnect();
               }
           }
           return null;
       }

       public DataTable GetTableSQL(string TableName, string SQLName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(SQLName, this.cnConnect)
           {
               CommandType = CommandType.Text,
               CommandTimeout = this.intTimeOut
           };
           DataSet dataSet = new DataSet();
           this.adQuery.SelectCommand = cmCommand;
           if (TableName == "")
           {
               TableName = "TableTemp";
           }
           try
           {
               Param.AddToCommand(cmCommand);
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               this.adQuery.Fill(dataSet, TableName);
               return dataSet.Tables[TableName];
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public DataTable GetTableStore(string StoreName)
       {
           return this.GetTableStore("NoTableName", StoreName);
       }

       public DataTable GetTableStore(string StoreName, QryParam Param)
       {
           return this.GetTableStore("NoTableName", StoreName, Param);
       }

       public DataTable GetTableStore(string TableName, string StoreName)
       {
           SqlCommand command = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           DataSet dataSet = new DataSet();
           this.adQuery.SelectCommand = command;
           try
           {
               if (this.bBeginTrans)
               {
                   command.Transaction = this.tsTrans;
               }
               if (TableName == "")
               {
                   TableName = "TableTemp";
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               this.adQuery.Fill(dataSet, TableName);
               return dataSet.Tables[TableName];
           }
           catch (Exception exception1)
           {
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.CloseConnect();
               }
           }
           return null;
       }

       public DataTable GetTableStore(string TableName, string StoreName, QryParam Param)
       {
           SqlCommand cmCommand = new SqlCommand(StoreName, this.cnConnect)
           {
               CommandType = CommandType.StoredProcedure,
               CommandTimeout = this.intTimeOut
           };
           DataSet dataSet = new DataSet();
           this.adQuery.SelectCommand = cmCommand;
           if (TableName == "")
           {
               TableName = "TableTemp";
           }
           try
           {
               Param.AddToCommand(cmCommand);
               if (this.bBeginTrans)
               {
                   cmCommand.Transaction = this.tsTrans;
               }
               if (this.cnConnect.State != ConnectionState.Open)
               {
                   this.cnConnect.Open();
               }
               this.adQuery.Fill(dataSet, TableName);
               return dataSet.Tables[TableName];
           }
           catch (Exception exception1)
           {
              
           }
           finally
           {
               if (!this.bBeginTrans)
               {
                   this.cnConnect.Close();
               }
           }
           return null;
       }

       public void RollBackTrans()
       {
           if (this.tsTrans != null)
           {
               this.tsTrans.Rollback();
           }
           this.bBeginTrans = false;
           this.CloseConnect();
       }

       public bool IsBeginTrans
       {
           get
           {
               return this.bBeginTrans;
           }
       }
      

       public int TimeOut
       {
           get
           {
               return this.intTimeOut;
           }
           set
           {
               this.intTimeOut = value;
           }
       }
 

 

 

    }
}
