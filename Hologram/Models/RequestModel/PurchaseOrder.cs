using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class PurchaseOrder : BaseModel
    {
        public string PurchaseOrderNumber { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string Supplier { get; set; }
        public int BoxQuantity { get; set; }
        public ulong RequestQuantity { get; set; }
        public ulong LastMonthConsumption { get; set; }
        public ulong TotalAvailableQuantity { get; set; }
        public int HologramPurchaseOrderId { get; set; }
        public int LicenseeId { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }

        public int ResponseCode { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
    }
}
