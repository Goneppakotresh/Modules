using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class PrintingRequestResponse
    {
        public PrintingRequestResponse()
        {
            List = new List<PrintingRequestGrid>();
        }
        public List<PrintingRequestGrid> List { get; set; }
    }
    public class PrintResponse : BaseModel
    {
        public string RequestNumber { get; set; }
    }
}
