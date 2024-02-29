using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class SpoolBoxMappingController : Controller
    {
        private readonly ISpoolBoxMapping _ISpoolBoxMapping;

        public SpoolBoxMappingController(ISpoolBoxMapping spoolBoxMapping)
        {
            _ISpoolBoxMapping = spoolBoxMapping;
        }

        /// <summary>
        /// get method for SpoolBoxMapping.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SpoolBoxMapping()
        {
            return View();
        }

        /// <summary>
        /// Fetch all spool box mapping details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllSpoolBoxMappingDetails()
        {
            List<SpoolBoxMapping> obj = new List<SpoolBoxMapping>();
            dynamic jsonResult = "";
            obj = await _ISpoolBoxMapping.GetAllSpoolBoxMappingDetails();
            //jsonResult = Json(new { data = obj });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return Json(new { data = obj }); ;
        }

        /// <summary>
        /// Get method for spool box mapping creation .
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SpoolBoxMappingCreation()
        {
            SpoolBoxMapping objRes = new SpoolBoxMapping();

            if (TempData["id"] != null)
            {
                objRes.SpoolCaseMappingId = Convert.ToInt32(TempData.Peek("id"));

                objRes = await _ISpoolBoxMapping.GetSpoolCaseMappingById(objRes);
                if (objRes.SpoolCaseMappingandDetails.Count != 3)
                {
                    objRes.SpoolCaseMappingandDetails.RemoveRange(0, 3);

                }
                else
                {
                    objRes.ViewStatus = Convert.ToString(TempData.Peek("status"));
                    return View(objRes);
                }
                objRes.ViewStatus = Convert.ToString(TempData.Peek("status"));
            }
            else
            {
                objRes.SpoolCaseMappingandDetails.Add(new SpoolModel());
                objRes.SpoolCaseMappingandDetails.Add(new SpoolModel());
                objRes.SpoolCaseMappingandDetails.Add(new SpoolModel());
            }

            return View(objRes);
        }

        /// <summary>
        /// Save spool box mapping details.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SpoolBoxMappingCreation(SpoolBoxMapping obj)
        {
            SpoolBoxMapping spoolBoxMapping = new SpoolBoxMapping();
            obj.userId = User.Identity.GetUserId();
            obj.userName = User.Identity.GetUserName();
            obj = await _ISpoolBoxMapping.InsertSpoolBoxMappingDetails(obj);
            spoolBoxMapping.ResponseCode = obj.ResponseCode;
            return View(spoolBoxMapping);
        }

        [HttpGet]
        public async Task<ActionResult> SpoolCaseMappingGetById(string spoolCaseMappingId, string status)
        {
            SpoolBoxMapping obj = new SpoolBoxMapping();


            TempData["id"] = spoolCaseMappingId;
            TempData["status"] = status;
            /*obj = await _ISpoolBoxMapping.GetSpoolCaseMappingById(obj)*/
            ;

            return Json(new { data = obj });
        }

        [HttpGet]
        public async Task<ActionResult> SpoolCaseMappingGetByBoxNumber(string boxNumber)
        {
            SpoolBoxMapping obj = new SpoolBoxMapping();
            obj.CaseNumber = boxNumber;

            obj = await _ISpoolBoxMapping.GetSpoolCaseMappingByBoxNumber(obj);
            return Json(new { data = obj });
        }
    }
}
