using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpensesAPI.Models;

namespace ExpensesAPI.DataManagers
{
    public abstract class UserDataManager
    {
        #region DataMappers
        private static User UserMapper(IDataReader dataReader)
        {
            return new User()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Password = dataReader["Password"].ToString()
            };
        }
        #endregion

        #region Public Methods
        public static List<User> GetUsers()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [dbo].[User]";

            List<User> users = BaseDataManager.GetSPItems(command, UserMapper);
            return users;
        }

        public static long InsertUser(User user)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "INSERT INTO [dbo].[User] (Password) VALUES (@password)";
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            return BaseDataManager.ExecuteNonQuery(sqlCommand);
        }

        public static long UpdateUser(User user)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "UPDATE [dbo].[User] SET Password = @password WHERE ID =@id";
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            sqlCommand.Parameters.AddWithValue("@id", user.ID);
            return BaseDataManager.ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}

