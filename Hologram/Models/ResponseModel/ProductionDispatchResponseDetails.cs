using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class ProductionDispatchResponseDetails
    {
        public int HologramIndentId { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public int ManufactureUnitId { get; set; }
        public ulong RequestLabelQuantity { get; set; }
        public int FinancialYear { get; set; }
        public int Status { get; set; }
        public int Labelprice { get; set; }
        public int CaseQuantity { get; set; }
        public int TotalAmount { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string Remark { get; set; }
        public ulong TotalAvailableQuantity { get; set; }
        public ulong LastMonthConsumption { get; set; }
    }

    public class ProductionDispatchResponse : BaseModel
    {
        public ProductionDispatchResponse()
        {
            List = new List<ProductionDispatchResponseDetails>();
        }
        public List<ProductionDispatchResponseDetails> List { get; set; }

    }
}
