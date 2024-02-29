using IEMS_WEB.Areas.Hologram.Models.OtherLicense;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class PurchaseHologramDispatch
    {
        public int Status { get; set; }
        public string PoNumber { get; set; } = string.Empty;
        public int ReferenceId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int RequestQuantity { get; set; }
        public int PendingQuantity { get; set; }
        public int DispatchQuantity { get; set; }
        public DateTime? DispatchDate { get; set; }
        public int Success { get; set; }
        public int IssueId { get; set; }
        public int IssueNumber { get; set; }
        public int ResponseCode { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public List<SelectListItemOverRide> lstPurchasenum = new List<SelectListItemOverRide>();
        public List<TableDetails> issueLabelDetails { get; set; }
        public PurchaseHologramDispatch()
        {
            issueLabelDetails = new List<TableDetails>();
        }
        public string? DispatchNumber { get; set; }

    }
}
