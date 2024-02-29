using IEMS_WEB.Areas.Hologram.Models.RequestModel;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class IndentDetailsResponse
    {
        public IndentDetailsResponse()
        {
            List = new List<IndentRequests>();
        }
        public List<IndentRequests> List { get; set; }
    }

    public class IndentCreate
    {
        public int HologramIndentId { get; set; }
        public int? RequestLabelQuantity { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestNumber { get; set; } = string.Empty;
        public int? CaseQuantity { get; set; }
        public int? HologramQuantity { get; set; }
        public DateTime? GoodReceivedNoteDate { get; set; }
        public string GoodReceivedNoteNumber { get; set; }
        public int Status { get; set; }
        public int? TotalAmount { get; set; }
        public decimal? CostPerHologram { get; set; }
        public decimal? AvailableBalance { get; }
        public int? FinancialYear { get; set; }
        public ulong TotalAvailableQuantity { get; set; }
        public ulong LastMonthConsumption { get; set; }
        public string GRNNumber { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public int ResponseCode { get; set; }
    }
    //public class IndentResponse : BaseModel
    //{

    //}
}
