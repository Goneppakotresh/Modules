using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
     public class BrandCorrectionViewDetails : BaseModel
    {
        public string BrandName { get; set; }
        public string BatchNumber { get; set; }
        public string OldPacking { get; set; }
        public string Date { get; set; }
        public string MannufactureDate { get; set; }
        public string NewPacking { get; set; }
        public string NewBrandName { get; set; }

        public List<SelectListItem> lstBrandName = new List<SelectListItem>();
        public List<SelectListItem> lstOldPacking = new List<SelectListItem>();
        public List<SelectListItem> lstBatchNumber = new List<SelectListItem>();
        public List<SelectListItem> lstNewBrandName = new List<SelectListItem>();
        public List<SelectListItem> lstNewPacking = new List<SelectListItem>();
    }



    public class BrandCorrectionResponse
    {
        public BrandCorrectionResponse()
        {
            List = new List<BrandCorrection>();
        }
        public List<BrandCorrection> List { get; set; }
    }
}
