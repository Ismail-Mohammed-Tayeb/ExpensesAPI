using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesAPI.Managers;
using ExpensesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesAPI.Controllers
{
    public class MaterialController : Controller
    {
        private const string baseURL = "material/";

        [Route(baseURL + "getmaterials")]
        [HttpGet]
        public IEnumerable<Material> GetMaterials()
        {
            return MaterialManager.GetMaterials();
        }

        [Route(baseURL + "getmaterialbyid")]
        [HttpGet]
        public Material GetMaterialByID([FromQuery] int materialId)
        {
            return MaterialManager.GetMaterialByID(materialId);
        }

        [Route(baseURL + "insertmaterial")]
        [HttpPost]
        public long InsertMaterial([FromBody] Material material)
        {
            return MaterialManager.InsertMaterial(material);
        }

        [Route(baseURL + "updatematerial")]
        [HttpPost]
        public long UpdateMaterial([FromBody] Material material)
        {
            return MaterialManager.UpdateMaterial(material);
        }
    }
}

