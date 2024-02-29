using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class ProductionDispatchDetails : BaseModel
    {
        public string CaseNumber { get; set; }
  
        public int RecievedStatus { get; set; }
        public DateTime RecievedDate { get; set; }
        public int RecievedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
    public class ProductionDispatch : BaseModel
    {
        public ulong DispatchId { get; set; }

        public ProductionDispatch()
        {
            SpoolCaseMappingandDetails = new List<SpoolModel>();
            DispatchTransactionDetails = new List<ProductionDispatchDetails>();
        }
        public List<SpoolModel> SpoolCaseMappingandDetails { get; set; }
        public ulong IndentId { get; set; }
        public int FinancialYear { get; set; }
        public int Status { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int DispatchQuantity { get; set; } = 0;
        public DateTime DispatchDate { get; set; }
        public string DispatchNumber { get; set; }
        public string DispatchedBy { get; set; } = String.Empty;
        public string HandoverTo { get; set; }
        public int ApprovedQty { get; set; }
        public int LabelStart { get; set; }
        public int LabelEnd { get; set; }
        public string VechileNumber { get; set; }
        public int ManufactureUnitId { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string Remark { get; set; } = String.Empty;
        public string File { get; set; }
        public int ResponseCode { get; set; }
        public string CaseNumber { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public List<ProductionDispatchDetails> DispatchTransactionDetails { get; set; }

        public string ViewStatus { get; set; }
    }

}
