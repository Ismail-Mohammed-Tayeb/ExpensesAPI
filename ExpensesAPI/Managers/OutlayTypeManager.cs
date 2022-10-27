using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesAPI.DataManagers;
using ExpensesAPI.Models;

namespace ExpensesAPI.Managers
{
    public abstract class OutlayTypeManager
    {
        #region Public Methods
        public static List<OutlayType> GetOutlayTypes()
        {
            return OutlayTypeDataManager.GetOutlayTypes();
        }

        public static long InsertOutlayType(OutlayType outlayType)
        {
            return OutlayTypeDataManager.InsertOutlayType(outlayType);
        }

        public static long UpdateOutlayType(OutlayType outlayType)
        {
            return OutlayTypeDataManager.UpdateOutlayType(outlayType);
        }

        public static OutlayType GetOutlayTypeByID(int outlayTypeID)
        {
            return GetOutlayTypes()
                   .FirstOrDefault(item => item.ID == outlayTypeID);
        }
        #endregion
    }
}

