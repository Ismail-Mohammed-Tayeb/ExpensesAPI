using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ExpensesAPI.Models;

namespace ExpensesAPI.DataManagers
{
    public abstract class OutlayDataManager
    {
        #region DataMappers
        private static Outlay OutlayMapper(IDataReader dataReader)
        {
            return new Outlay()
            {
                UserID = Convert.ToInt32(dataReader["UserID"].ToString()),
                Date = DateTime.Parse(dataReader["Date"].ToString()),
                Description = dataReader["Description"].ToString(),
                MaterialID = Convert.ToInt32(dataReader["MaterialID"].ToString()),
                OutlayTypeID = Convert.ToInt32(dataReader["OutlayTypeID"].ToString()),
                Price = double.Parse(dataReader["Price"].ToString()),
                OutlayID = int.Parse(dataReader["OutlayID"].ToString()),
            };
        }
        #endregion

        #region Public Methods
        public static List<Outlay> GetOutlays()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [dbo].[Outlay];";
            List<Outlay> outlays = BaseDataManager.GetSPItems<Outlay>(command, OutlayMapper);
            Debug.WriteLine($"The value returned by the query was: {outlays.Count}");
            return outlays;
        }


        public static long InsertOuylay(Outlay outlay)
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [dbo].[Outlay](UserID,Date,Description,MaterialID,OutlayTypeID,Price)VALUES"
                                  + "(@userID,@date,@description,@materialID,@outlayTypeID,@price)";

            command.Parameters.AddWithValue("@userID", outlay.UserID);
            command.Parameters.AddWithValue("@date", outlay.Date);
            command.Parameters.AddWithValue("@description", outlay.Description);
            command.Parameters.AddWithValue("@materialID", outlay.MaterialID);
            command.Parameters.AddWithValue("@outlayTypeID", outlay.OutlayTypeID);
            command.Parameters.AddWithValue("@price", outlay.Price);

            return BaseDataManager.ExecuteNonQuery(command);
        }

        public static long UpdateOutlay(Outlay outlay)
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [dbo].[Outlay] SET " +
                                  "(Date =@date,Description =@description,MaterialID=@materialID,OutlayTypeID=@outlayTypeID,Price =@price) " +
                                  "WHERE OutlayID = @outlayID";

            command.Parameters.AddWithValue("@outlayID", outlay.OutlayID);
            command.Parameters.AddWithValue("@date", outlay.Date);
            command.Parameters.AddWithValue("@description", outlay.Description);
            command.Parameters.AddWithValue("@materialID", outlay.MaterialID);
            command.Parameters.AddWithValue("@outlayTypeID", outlay.OutlayTypeID);
            command.Parameters.AddWithValue("@price", outlay.Price);

            return BaseDataManager.ExecuteNonQuery(command);
        }


        public static long DeleteOutlay(int outlayID)
        {

            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM [dbo].[Outlay] WHERE OutlayID = @ID";
            command.Parameters.AddWithValue("@ID", outlayID);
            return BaseDataManager.ExecuteNonQuery(command);
        }


        #endregion
    }
}
