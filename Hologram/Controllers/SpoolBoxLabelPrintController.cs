using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class SpoolBoxLabelPrintController : Controller
    {
        private readonly ISpoolBoxLabelPrint _ISpoolBoxLabelPrint;
        public SpoolBoxLabelPrintController(ISpoolBoxLabelPrint SpoolBoxLabelPrint)
        {
            _ISpoolBoxLabelPrint = SpoolBoxLabelPrint;
        }

        /// <summary>
        /// Get method for Spool box print list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SpoolBoxLabelPrint()
        {
            return View();
        }

        /// <summary>
        /// Get all print request details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllSpoolBoxLabelPrintDetails()
        {
            SpoolBoxLabelPrintResponse obj = new SpoolBoxLabelPrintResponse();
            dynamic jsonResult = "";
            obj = await _ISpoolBoxLabelPrint.GetAllSpoolBoxLabelPrintDetails();
            jsonResult = Json(new { data = obj });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Get metho for spool box label creation.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SpoolBoxLabelPrintCreation()
        {
            return View();
        }

        /// <summary>
        /// Save spool box label details method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SpoolBoxLabelPrintCreation(SpoolBoxLabelPrint obj)
        {
            SpoolBoxLabelPrint objRes = new SpoolBoxLabelPrint();
            objRes = await _ISpoolBoxLabelPrint.InsertSpoolBoxLabelPrintDetails(obj);
            return View(objRes);
        }


    }
}
