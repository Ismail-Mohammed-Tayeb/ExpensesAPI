using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ExpensesAPI.Models;

namespace ExpensesAPI.DataManagers
{
    public abstract class MaterialDataManager
    {
        #region DataMappers
        private static Material MaterialMapper(IDataReader dataReader)
        {
            return new Material()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Description = dataReader["Description"].ToString(),
                IsService = bool.Parse(dataReader["IsService"].ToString()),
                Name = dataReader["Name"].ToString()
            };
        }
        #endregion

        #region Public Methods
        public static List<Material> GetMaterials()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM [dbo].[Material]";
            sqlCommand.CommandType = CommandType.Text;

            List<Material> materials = BaseDataManager.GetSPItems<Material>(sqlCommand, MaterialMapper);
            return materials;
        }

        public static long InsertMaterial(Material material)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO [dbo].[Material](Description,IsService,Name)VALUES(@description,@isService,@name)";
            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.Parameters.AddWithValue("@description", material.Description);
            sqlCommand.Parameters.AddWithValue("@isService", material.IsService ? "1" : "0");
            sqlCommand.Parameters.AddWithValue("@name", material.Name);

            return BaseDataManager.ExecuteNonQuery(sqlCommand);
        }

        public static long UpdateMaterial(Material material)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE [dbo].[Material] SET Description=@description,IsService=@isService,Name=@name WHERE ID =@id";
            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.Parameters.AddWithValue("@description", material.Description);
            sqlCommand.Parameters.AddWithValue("@isService", material.IsService ? "1" : "0");
            sqlCommand.Parameters.AddWithValue("@name", material.Name);
            sqlCommand.Parameters.AddWithValue("@id", material.ID);

            return BaseDataManager.ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}

