using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class PurchaseOrderGrid
    {
        public int HologramPurchaseOrderId { get; set; }
        public string TotalAvailableQuantity { get; set; }
        public int Status { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string Supplier { get; set; }
        public int RequestQuantity { get; set; }
    }
    public class PurchaseOrderResponse : BaseModel
    {
        public PurchaseOrderResponse()
        {
            List = new List<PurchaseOrderGrid>();
        }
        public List<PurchaseOrderGrid> List { get; set; }
    }
}
