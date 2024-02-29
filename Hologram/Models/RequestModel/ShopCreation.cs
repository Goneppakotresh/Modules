using IEMS_WEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class ShopCreation : shopCreationRequest
    {
        public List<SelectListItem> lstCircle = new List<SelectListItem>();
        public List<SelectListItem> lstDeo = new List<SelectListItem>();
        public List<SelectListItem> lstArea = new List<SelectListItem>();
    }
    public class shopCreationRequest : BaseModel
    {
        public int ShopId { get; set; }
        public string ShopCode { get; set; } = string.Empty;
        public string ShopName { get; set; } = string.Empty;
        public int DeoId { get; set; }
        public int CircleOfficeId { get; set; }
        public int AreaTypeId { get; set; }
        public int CreatedBy { get; set; } = 1;
        public string Remarks { get; set; } = string.Empty;
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public int ResponseCode { get; set; }
    }
}
