using System.Collections.Generic;
using ExpensesAPI.Managers;
using ExpensesAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace ExpensesAPI.Controllers
{
    public class OutlayController : Controller
    {
        private const string baseURL = "outlay/";

        [Route(baseURL + "getoutlays")]
        [HttpGet]
        public IEnumerable<Outlay> GetOutlays()
        {
            return OutlayManager.GetOutlays();
        }

        [Route(baseURL + "getoutlaysbymaterialid")]
        [HttpGet]
        public IEnumerable<Outlay> GetOutlaysByMaterialID(int materialId)
        {
            //Test Comment
            return OutlayManager.GetOutlaysByMaterialID(materialId);
        }

        [Route(baseURL + "getoutlaysbymonthandyear")]
        [HttpGet]
        public IEnumerable<Outlay> GetOutlaysByMonthAndYear(int? month, int? year)
        {
            return OutlayManager.GetOutlaysByMonthAndYear(month, year);
        }

        [Route(baseURL + "getoutlaysbyservices")]
        [HttpGet]
        public IEnumerable<Outlay> GetOutlaysByServices()
        {
            return OutlayManager.GetOutlaysByServices();
        }

        [Route(baseURL + "getoutlaysbyuserid")]
        [HttpGet]
        public IEnumerable<Outlay> GetOutlaysByUserID(int userID)
        {
            return OutlayManager.GetOutlaysByUserID(userID);
        }

        [Route(baseURL + "insertoutlay")]
        [HttpPost]
        public long InsertOutlay([FromBody] Outlay outlay)
        {
            return OutlayManager.InsertOutlay(outlay);
        }

        [Route(baseURL + "updateoutlay")]
        [HttpPost]
        public long UpdateOutlay([FromBody] Outlay outlay)
        {
            return OutlayManager.UpdateOutlay(outlay);
        }

        [Route(baseURL + "deleteoutlay")]
        [HttpGet]
        public long DeleteOutlay([FromQuery] int outlayID)
        {
            return OutlayManager.DeleteOutlay(outlayID);
        }

        [Route(baseURL + "getoutlaytotal")]
        [HttpGet]
        public double GetOutlayTotal(int? month, int? year)
        {
            return OutlayManager.GetOutlayTotal(month, year);
        }

        [Route(baseURL + "getoutlaystotalbyuserid")]
        [HttpGet]
        public double GetOutlaysTotalByUserID(int userID)
        {
            return OutlayManager.GetOutlaysTotalByUserID(userID);
        }

    }
}

