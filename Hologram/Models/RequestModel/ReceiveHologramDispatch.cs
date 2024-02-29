using IEMS_WEB.Areas.Hologram.Models.OtherLicense;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class ReceiveHologramDispatch
    {
        public int ResponseCode { get; set; }
        public int Id { get; set; } = 0;
        public int ReferenceId { get; set; } = 0;
        public int DispatchQuantity { get; set; } = 0;
        public DateTime DispatchDate { get; set; }
        public int CreatedBy { get; set; } = 0;
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; } = 0;
        public DateTime ModifiedOn { get; set; }
        public string Supplier { get; set; } = "";
        public int InvoiceNumber { get; set; } = 0;
        public int InvoiceAmount { get; set; } = 0;
        public DateTime InvoiceDate { get; set; }
        public int RequestQuantity { get; set; } = 0;
        public DateTime RequestDate { get; set; }
        public int ReceivedQuantity { get; set; } = 0;
        public DateTime? ReceivedDate { get; set; }
        public int BalanceQuantity { get; set; } = 0;
        public int PendingQuantity { get; set; } = 0;
        public int FinancialYear { get; set; } = 0;
        public int Status { get; set; } = 0;
        public int PendingQuantityDigit { get; set; } = 0;
        public int DispatchQuantityDigit { get; set; } = 0;
        public int ReceivedQuantityDigit { get; set; } = 0;
        public int BalanceQuantityDigit { get; set; } = 0;
        public string? DispatchNumber { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }

        public List<SelectListItemOverRide> lstPurchasenum = new List<SelectListItemOverRide>();
    }
    public class PurchaseOrderDetails
    {
        public string Supplier { get; set; } = "";
        public string PurchaseOrderDate { get; set; }
        public string PurchaseOrderNumber { get; set; } = "";
        public ulong RequestQuantity { get; set; } = 0;
        public ulong DispatchQuantty { get; set; } = 0;

    }
}
