using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class PurchaseHologramResponse : BaseModel
    {
        public PurchaseHologramResponse()
        {
            List = new List<PurchaseHologramDispatchGrid>();
        }
        public List<PurchaseHologramDispatchGrid> List { get; set; }
        public string? DispatchNumber { get; set; }

    }
    public class PurchaseHologramDispatchGrid
    {
        public int Status { get; set; }
        public string PoNumber { get; set; }
        public int ReferenceId { get; set; }
        public string RequestDate { get; set; }
        public int RequestQuantity { get; set; }
        public int PendingQuantity { get; set; }
        public int DispatchQuantity { get; set; }
        public string DispatchDate { get; set; }
        public int Success { get; set; }
        public int IssueNumber { get; set; }
        public string? DispatchNumber { get; set; }

    }

}
