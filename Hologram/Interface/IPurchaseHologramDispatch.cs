using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IPurchaseHologramDispatch
    {
        Task<PurchaseHologramResponse> SavePurchaseHologramDispatchDetails(PurchaseHologramDispatch purchaseHologramDispatch);
        Task<List<PurchaseHologramDispatchGrid>> GetAllPurchaseDispatchDetails();

        Task<PurchaseHologramDispatch> PurchaseHologramDispatchById(int purchaseHologramDispatchId);
    }
}
