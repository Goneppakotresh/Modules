using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class ReceiveHologramDispatchResponse : BaseModel
    {
        public ReceiveHologramDispatchResponse()
        {
            List = new List<ReceiveHologramDispatch>();
        }

        public List<ReceiveHologramDispatch> List { get; set; }
    }
}
