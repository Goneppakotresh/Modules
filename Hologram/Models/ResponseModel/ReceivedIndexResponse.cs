using IEMS_WEB.Areas.Hologram.Models.RequestModel;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class ReceivedIndexResponse
    {
        public ReceivedIndexResponse()
        {
            List = new List<ReceivedIndex>();
        }
        public List<ReceivedIndex> List { get; set; }
    }
}
