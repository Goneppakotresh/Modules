using IEMS_WEB.Areas.Hologram.Models.RequestModel;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class ProductionDispatchModelbinding
    {
        public int HologramIndentId { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public int ManufactureUnitId { get; set; }
        public int RequestLabelQuantity { get; set; }
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
        public string? Remark { get; set; }
        public ulong TotalAvailableQuantity { get; set; }
        public ulong LastMonthConsumption { get; set; }
        public DateTime? GoodReceivedNoteDate { get; set; }
        public string GoodReceivedNoteNumber { get; set; }
        public List<ProductionDispatchbinding> DispatchTransactionDetails { get; set; }
       
    }

    public class ProductionDispatchbinding
    {

        public ulong DispatchId { get; set; }
        public ulong IndentId { get; set; }
        public int FinancialYear { get; set; }
        public int Status { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int DispatchQuantity { get; set; }
        public DateTime DispatchDate { get; set; }
        public string DispatchNumber { get; set; }
        public string DispatchedBy { get; set; }
        public string HandoverTo { get; set; }
        public int ApprovedQty { get; set; }
        public int LabelStart { get; set; }
        public int LabelEnd { get; set; }
        public string VechileNumber { get; set; }
        public int ManufactureUnitId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int IsActive { get; set; }
        public string Remark { get; set; }
        public List<ProductionDispatchDetail> DispatchDetails { get; set; }
    }

    public class ProductionDispatchDetail
    {
        public ulong DispatchDetailId { get; set; }
        public ulong DispatchId { get; set; }
        public string CaseNumber { get; set; }
        public long RecievedStatus { get; set; }
        public DateTime RecievedDate { get; set; }
        public int RecievedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
