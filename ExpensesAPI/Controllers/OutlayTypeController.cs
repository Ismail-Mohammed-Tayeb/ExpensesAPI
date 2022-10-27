using System.Collections.Generic;
using ExpensesAPI.Managers;
using ExpensesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesAPI.Controllers
{

    public class OutlayTypeController : Controller
    {
        private const string baseURL = "outlaytype/";

        [Route(baseURL + "getoutlaytypes")]
        [HttpGet]
        public IEnumerable<OutlayType> GetOutlayTypes()
        {
            return OutlayTypeManager.GetOutlayTypes();
        }
        [Route(baseURL + "getoutlaytypebyid")]
        [HttpGet]
        public OutlayType GetOutlayTypeByID([FromQuery] int outlayTypeID)
        {
            return OutlayTypeManager.GetOutlayTypeByID(outlayTypeID);
        }

        [Route(baseURL + "insertoutlaytype")]
        [HttpPost]
        public long InsertOutlayType([FromBody] OutlayType outlayType)
        {
            return OutlayTypeManager.InsertOutlayType(outlayType);
        }

        [Route(baseURL + "updateoutlaytype")]
        [HttpPost]
        public long UpdateOutlayType([FromBody] OutlayType outlayType)
        {
            return OutlayTypeManager.UpdateOutlayType(outlayType);
        }

    }
}

