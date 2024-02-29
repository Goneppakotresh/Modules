using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class PrintingRequest
    {
        public int HologramPrintingRequestId { get; set; }
        public int HologramPurchaseOrderId { get; set; }
        public string PurchaseOrderRequestQuantity { get; set; }
        public string PurchaseRequestDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestNumber { get; set; }
        public string BoxQuantity { get; set; }
        public string RequestQuantity { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public int? Balance { get; set; }
        public int IsActive { get; set; }
        public int FinalcialYear { get; set; }
        public int UVDownloaded { get; set; }
        public int CreatedBy { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public PrintResponse responses = new PrintResponse();
    }

    public class PrintingRequestGrid
    {

        public string PurchaseOrderRequestQuantity { get; set; }
        public int HologramPrintingRequestId { get; set; }

        public string RequestDate { get; set; }
        public string RequestNumber { get; set; }
        public string BoxQuantity { get; set; }
        public string RequestQuantity { get; set; }
        public int Status { get; set; }
    }
}
