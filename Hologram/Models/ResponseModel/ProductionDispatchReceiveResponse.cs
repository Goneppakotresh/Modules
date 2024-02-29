using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class ProductionDispatchReceiveResponse : ProductionDispatch
    {
        public ProductionDispatchReceiveResponse()
        {
            List = new List<ProductionDispatchReceiveModel>();
        }

        public List<ProductionDispatchReceiveModel> List { get; set; }
    }
}
