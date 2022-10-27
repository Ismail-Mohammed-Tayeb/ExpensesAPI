using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesAPI.DataManagers;
using ExpensesAPI.Models;

namespace ExpensesAPI.Managers
{
    public abstract class OutlayManager
    {
        public static List<Outlay> GetOutlays()
        {
            return OutlayDataManager.GetOutlays();
        }

        public static long InsertOutlay(Outlay outlay)
        {
            return OutlayDataManager.InsertOuylay(outlay);
        }

        public static IEnumerable<Outlay> GetOutlaysByUserID(int userID)
        {
            return GetOutlays().Where(item => item.UserID == userID).ToList();
        }

        public static IEnumerable<Outlay> GetOutlaysByMonthAndYear(int? month, int? year)
        {
            if (month == null && year == null) return new List<Outlay>();
            if (month != null && year != null)
            {
                return IntersectOutlayLists(
                       GetOutlaysByMonth(month),
                       GetOutlaysByYear(year));
            }
            if (month != null)
            {
                return GetOutlaysByMonth(month);
            }
            return GetOutlaysByYear(year);
        }

        public static List<Outlay> GetOutlaysByServices()
        {
            List<Material> serviceMaterials = MaterialManager.GetMaterialsByIsService();
            List<Outlay> outlays = GetOutlays();
            List<Outlay> result = new List<Outlay>();

            foreach (var item in outlays)
            {
                if (serviceMaterials.Where(x => x.ID == item.MaterialID).ToList().Count == 1)
                {
                    result.Add(item);
                }
            }
            return result;

        }

        public static List<Outlay> GetOutlaysByMaterialID(int materialID)
        {
            return GetOutlays().Where(item => item.MaterialID == materialID).ToList();
        }

        public static long DeleteOutlay(int outlayID)
        {
            return OutlayDataManager.DeleteOutlay(outlayID);
        }

        public static long UpdateOutlay(Outlay outlay)
        {
            return OutlayDataManager.UpdateOutlay(outlay);
        }
        public static double GetOutlayTotal(int? month, int? year)
        {
            List<Outlay> outlays = GetOutlays();
            if (year != null || month != null)
            {
                outlays = GetOutlaysByMonthAndYear(month, year).ToList();
            }

            double total = 0;
            foreach (var item in outlays)
            {
                total += item.Price;
            }
            return total;
        }

        public static Outlay GetOutlayByID(int outlayID)
        {
            return GetOutlays()
                   .FirstOrDefault(item => item.OutlayID == outlayID);
        }

        //TODO: Call this function on controller to ensure all methods have got endpoints
        public static double GetOutlaysTotalByUserID(int userID)
        {
            List<Outlay> outlays = GetOutlaysByUserID(userID).ToList();
            double total = 0;
            foreach (var item in outlays)
            {
                total += item.Price;
            }
            return total;
        }

        #region PrivateMethods
        private static List<Outlay> GetOutlaysByYear(int? year)
        {
            return GetOutlays().Where(item => item.Date.Year == year).ToList();
        }

        private static List<Outlay> GetOutlaysByMonth(int? month)
        {
            return GetOutlays().Where(item => item.Date.Month == month).ToList();
        }
        #endregion

        #region HelperFunctions
        private static IEnumerable<Outlay> IntersectOutlayLists(List<Outlay> first,
                                                                List<Outlay> second)
        {
            List<Outlay> result = new List<Outlay>();

            List<Outlay> smallest = first.Count >= second.Count ? second : first;
            List<Outlay> largest = first.Count < second.Count ? second : first;

            foreach (var item in smallest)
            {
                if (largest.Where(x => x.OutlayID == item.OutlayID).ToList().Count == 1)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        #endregion
    }
}

