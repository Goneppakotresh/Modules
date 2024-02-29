using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IReceiveHologramDispatch
    {
        Task<List<ReceiveHologramDispatch>> GetAllHologramDispatchDetails();

        Task<List<SelectListItem>> GetPurchaseOrderList();
        Task<List<SelectListItem>> GetIssuedHologramList();


        Task<PurchaseOrderDetails> GetPurchaseOrderDetails(int purchaseOrderId);

        Task<ReceiveHologramDispatchResponse> SavereceiveHologramDispatchDetails(ReceiveHologramDispatch receiveHologramDispatch);

        Task<ReceiveHologramDispatch> ReceiveHologramDispatchById(int receiveHologramDispatchId);

    }
}
