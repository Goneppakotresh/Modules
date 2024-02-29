using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class IssueSeries :BaseModel
    {
        public int SeriesId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int PrintingRequestId { get; set; }
        public int FromSeriesNumber { get; set; }
        public int ToSeriesNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public DateTime PrintRequestDate { get; set; }
        public int PurchaseOrderQuantity { get; set; }
        public int PrintingRequestQuantity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ResponseCode { get; set; }
        public int Status { get; set; }
        public string PrintRequestNumber { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public IssueSeriesResponse responses = new IssueSeriesResponse();
    }

    public class IssueSeriesGrid
    {
        public ulong PrintingRequestId { get; set; }
        public int FromSeriesNumber { get; set; }
        public int ToSeriesNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ResponseCode { get; set; }

        public string PurchaseOrderRequestQuantity { get; set; }
        public int HologramPrintingRequestId { get; set; }

        public string RequestDate { get; set; }
        public string RequestNumber { get; set; }
        public string BoxQuantity { get; set; }
        public string RequestQuantity { get; set; }
        public int Status { get; set; }


    }

    public class IssueSeriesResponse : BaseModel
    {
        public IssueSeriesResponse()
        {
            List = new List<IssueSeriesGrid>();
        }
        public List<IssueSeriesGrid> List { get; set; }
        public int Status { get; set; }
        public int ResponseCode { get; set; }
    }
   
}