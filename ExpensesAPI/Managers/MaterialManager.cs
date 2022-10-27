using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesAPI.DataManagers;
using ExpensesAPI.Models;

namespace ExpensesAPI.Managers
{
    public abstract class MaterialManager
    {
        public static List<Material> GetMaterials()
        {
            return MaterialDataManager.GetMaterials();
        }

        public static long InsertMaterial(Material material)
        {
            return MaterialDataManager.InsertMaterial(material);
        }

        public static long UpdateMaterial(Material material)
        {
            return MaterialDataManager.UpdateMaterial(material);
        }

        public static Material GetMaterialByID(int materialID)
        {
            return GetMaterials().FirstOrDefault(item => item.ID == materialID);
        }

        public static List<Material> GetMaterialsByIsService(bool isService = true)
        {
            return GetMaterials().Where(item => item.IsService == isService).ToList();
        }
    }
}

