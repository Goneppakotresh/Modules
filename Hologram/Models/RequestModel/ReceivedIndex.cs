using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class ReceivedIndex : BaseModel
    {
        public int IndexId { get; set; }
        public string RequestDate { get; set; }
        public string RequestNumber { get; set; }
        public string BoxQuantity { get; set; }
        public string LabelQuantity { get; set; }
        public string Status { get; set; }
        public string ReceivedOn { get; set; }
        public string ReceivedBy { get; set; }
        public string BoxNumber { get; set; }

    }
}
