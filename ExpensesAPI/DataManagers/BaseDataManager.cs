using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ExpensesAPI.DataManagers
{
    public abstract class BaseDataManager
    {
        private const string connectionString = "Data Source=SQL8003.site4now.net;Initial Catalog=db_a8eb24_expensesdb;User Id=db_a8eb24_expensesdb_admin;Password=remote123";

        public static int ExecuteNonQuery(SqlCommand command, params object[] parameters)
        {
            try
            {
                int affectedRowsCount = 0;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    if (parameters.Length > 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters[i + 1].Value = parameters[i];
                        }
                    }
                    affectedRowsCount = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    return affectedRowsCount;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {command}: {e.Message}");
                return 0;
            }
        }
        public static List<T> GetSPItems<T>(SqlCommand command, Func<IDataReader, T> mapper)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {

                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    IDataReader reader = command.ExecuteReader();
                    List<T> items = new List<T>();
                    while (reader.Read())
                    {
                        items.Add(mapper(reader));
                    }
                    reader.Close();
                    sqlConnection.Close();
                    return items;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {command}: {e.Message}");
                return null;
            }

        }
    }
}

