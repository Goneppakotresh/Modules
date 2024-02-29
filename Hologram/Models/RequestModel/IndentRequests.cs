using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class IndentRequests : BaseModel
    {
        public int HologramIndentId { get; set; }
        public string RequestDate { get; set; }
        public string RequestNumber { get; set; }
        public string HologramQuantity { get; set; }
        public int TotalAmount { get; set; }
        public string HologramCost { get; set; }
        public string Balance { get; set; }
        public DateTime? GoodReceivedNoteDate { get; set; }
        public string GoodReceivedNoteNumber { get; set; }
        public int RequestLabelQuantity { get; set; }
        public string BoxQuantity { get; set; }
    }
}
