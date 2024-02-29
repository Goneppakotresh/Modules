using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class BrandCorrectionController : Controller
    {
        private readonly IBrandCorrection _IBrandCorrection;

        public BrandCorrectionController(IBrandCorrection brandCorrection)
        {
            _IBrandCorrection = brandCorrection;
        }

        /// <summary>
        /// Get method for Brand Correction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BrandCorrection()
        {
            return View();
        }

        /// <summary>
        /// Fetch all brand correction details.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllBrandCorrectionListDetails()
        {
            BrandCorrectionResponse obj = new BrandCorrectionResponse();
            dynamic jsonResult = "";
            obj = await _IBrandCorrection.GetAllBrandCorrectionListDetails();
            jsonResult = Json(new { data = obj });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult BrandCorrectionView()
        {
            BrandCorrectionViewDetails obj = new BrandCorrectionViewDetails();
            return View(obj);
        }



    }
}
