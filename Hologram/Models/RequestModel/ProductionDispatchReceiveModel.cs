using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class ProductionDispatchReceiveModel : BaseModel
    {
        public ulong? DispatchId { get; set; }
        //public string Supplier { get; set; }
        public string ApprovedQty { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
        public string RequestDate { get; set; } = String.Empty;
        public string CaseNumber { get; set; } = String.Empty;
        public string RequestNumber { get; set; } = String.Empty;
        public string BoxQuantity { get; set; } = String.Empty;
        public string LabelQuantty { get; set; } = String.Empty;
        public DateTime ReceivedOn { get; set; }
        public int? ReceivedBy { get; set; }
        public string BoxNumber { get; set; } = String.Empty;
        public string InvoiceNumber { get; set; } = String.Empty;
        public int? DispatchQuantity { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string ViewStatus { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public List<ProductionDispatchReceive> DispatchDetails { get; set; }
        public ProductionDispatchReceiveModel()
        {
            DispatchDetails = new List<ProductionDispatchReceive>();
            SpoolCaseMappingandDetails = new List<SpoolModel>();
        }
        public List<SpoolModel> SpoolCaseMappingandDetails { get; set; }

        public int ResponseCode { get; set; }
    }
    public class ProductionDispatchReceive
    {
        public int DispatchDetailId { get; set; }
        public int DispatchId { get; set; }
        public string CaseNumber { get; set; }
        public int RecievedStatus { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int ReceivedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
