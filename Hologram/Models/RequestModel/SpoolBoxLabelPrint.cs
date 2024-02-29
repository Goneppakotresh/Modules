using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class SpoolBoxLabelPrint : BaseModel
    {
        public string requestDate { get; set; }
        public string requestNumber { get; set; }
        public string boxes { get; set; }
        public string spool { get; set; }
        public string status { get; set; }
    }
}
