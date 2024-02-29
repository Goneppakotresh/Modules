using IEMS_WEB.Areas.Hologram.Models.RequestModel;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class SpoolBoxLabelPrintResponse
    {
        public SpoolBoxLabelPrintResponse()
        {
            List = new List<SpoolBoxLabelPrint>();
        }
        public List<SpoolBoxLabelPrint> List { get; set; }
    }
}
