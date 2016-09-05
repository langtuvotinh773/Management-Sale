using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;

namespace Management.Commons.SQL
{
  public  class QryParam
    {
      private ArrayList ParamList;

      public QryParam()
      {
          this.ParamList = new ArrayList();
      }
      public void Add(string ParamName, SqlDbType ParamType, object ParamValue)
      {
          SqlParameter parameter = new SqlParameter(ParamName, ParamType)
          {
              Value = RuntimeHelpers.GetObjectValue(ParamValue)
          };
          this.ParamList.Add(parameter);
      }
      public void Add(string ParamName, SqlDbType ParamType, int Size, object ParamValue)
      {
          SqlParameter parameter = new SqlParameter(ParamName, ParamType, Size)
          {
              Value = RuntimeHelpers.GetObjectValue(ParamValue)
          };
          this.ParamList.Add(parameter);
      }

      public void AddOutput(string ParamName, SqlDbType ParamType, object ParamValue)
      {
          SqlParameter parameter = new SqlParameter(ParamName, ParamType)
          {
              Direction = ParameterDirection.Output,
              Value = RuntimeHelpers.GetObjectValue(ParamValue)
          };
          this.ParamList.Add(parameter);
      }


      public void AddOutput(string ParamName, SqlDbType ParamType, int Size, object ParamValue)
      {
          SqlParameter parameter = new SqlParameter(ParamName, ParamType, Size)
          {
              Direction = ParameterDirection.Output,
              Value = RuntimeHelpers.GetObjectValue(ParamValue)
          };
          this.ParamList.Add(parameter);
      }

      public void AddToCommand(SqlCommand cmCommand)
      {
          IEnumerator enumerator = null;
          try
          {
              enumerator = this.ParamList.GetEnumerator();
              while (enumerator.MoveNext())
              {
                  SqlParameter objectValue = (SqlParameter)RuntimeHelpers.GetObjectValue(enumerator.Current);
                  cmCommand.Parameters.Add(objectValue);
              }
          }
          finally
          {
              if (enumerator is IDisposable)
              {
                  (enumerator as IDisposable).Dispose();
              }
          }
      }

      public void Clear()
      {
          this.ParamList.Clear();
      }

      public QryParam Copy()
      {
          QryParam param;
         
              IEnumerator enumerator = null;
              QryParam param2 = new QryParam();
              try
              {
                  enumerator = this.ParamList.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                      SqlParameter objectValue = (SqlParameter)RuntimeHelpers.GetObjectValue(enumerator.Current);
                      if (objectValue.Direction == ParameterDirection.Output)
                      {
                          param2.AddOutput(objectValue.ParameterName, objectValue.SqlDbType, objectValue.Size, RuntimeHelpers.GetObjectValue(objectValue.Value));
                      }
                      else
                      {
                          param2.Add(objectValue.ParameterName, objectValue.SqlDbType, RuntimeHelpers.GetObjectValue(objectValue.Value));
                      }
                  }
              }
              finally
              {
                  if (enumerator is IDisposable)
                  {
                      (enumerator as IDisposable).Dispose();
                  }
              }
              param = param2;
              return param;

      }


      public int getLength()
      {
          return this.ParamList.Count;
      }

      public object GetValue(string ParamName)
      {
          IEnumerator enumerator = null;
          try
          {
              enumerator = this.ParamList.GetEnumerator();
              while (enumerator.MoveNext())
              {
                  SqlParameter objectValue = (SqlParameter)RuntimeHelpers.GetObjectValue(enumerator.Current);
                  if (objectValue.ParameterName == ParamName)
                  {
                      return objectValue.Value;
                  }
              }
          }
          finally
          {
              if (enumerator is IDisposable)
              {
                  (enumerator as IDisposable).Dispose();
              }
          }
          return null;
      }

      public void Remove(string ParamName)
      {
          object objectValue = null;
          IEnumerator enumerator = null;
          try
          {
              enumerator = this.ParamList.GetEnumerator();
              while (enumerator.MoveNext())
              {
                  objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                  SqlParameter parameter = (SqlParameter)objectValue;
                  if (parameter.ParameterName == ParamName)
                  {
                     // goto Label_0069;
                  }
              }
          }
          finally
          {
              if (enumerator is IDisposable)
              {
                  (enumerator as IDisposable).Dispose();
              }
          }
          if (objectValue != null)
          {
              this.ParamList.Remove(RuntimeHelpers.GetObjectValue(objectValue));
          }
      }
      public void SetValue(string ParamName, object ParamValue)
      {
          IEnumerator enumerator = null;
          try
          {
              enumerator = this.ParamList.GetEnumerator();
              while (enumerator.MoveNext())
              {
                  SqlParameter objectValue = (SqlParameter)RuntimeHelpers.GetObjectValue(enumerator.Current);
                  if (objectValue.ParameterName == ParamName)
                  {
                      objectValue.Value = RuntimeHelpers.GetObjectValue(ParamValue);
                      return;
                  }
              }
          }
          finally
          {
              if (enumerator is IDisposable)
              {
                  (enumerator as IDisposable).Dispose();
              }
          }
      }


 



    }
}
