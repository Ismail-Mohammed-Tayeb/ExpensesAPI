using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExpensesAPI.Models;

namespace ExpensesAPI.DataManagers
{
    public abstract class OutlayTypeDataManager
    {
        #region DataMapper
        private static OutlayType OutlayTypeMapper(IDataReader dataReader)
        {
            return new OutlayType()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Description = dataReader["Description"].ToString(),
                Name = dataReader["Name"].ToString()
            };
        }
        #endregion

        public static List<OutlayType> GetOutlayTypes()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [dbo].[OutlayType];";
            command.CommandType = CommandType.Text;

            return BaseDataManager.GetSPItems(command, OutlayTypeMapper);
        }

        public static long InsertOutlayType(OutlayType outlayType)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [dbo].[OutlayType](Description,Name)" +
                                  "VALUES(@description,@name);";
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@description", outlayType.Description);
            command.Parameters.AddWithValue("@name", outlayType.Name);

            return BaseDataManager.ExecuteNonQuery(command);
        }

        public static long UpdateOutlayType(OutlayType outlayType)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [dbo].[OutlayType] SET Description = @description,Name = @name " +
                "WHERE ID = @id;";
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@description", outlayType.Description);
            command.Parameters.AddWithValue("@name", outlayType.Name);
            command.Parameters.AddWithValue("@id", outlayType.ID);

            return BaseDataManager.ExecuteNonQuery(command);
        }
    }
}

