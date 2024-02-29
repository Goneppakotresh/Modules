using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IPurchaseOrder
    {
        Task<PurchaseOrderResponse> GetAllPurchaseOrderDetails();

        Task<PurchaseOrder> SavePurchaseOrderDetails(PurchaseOrder purchaseOrder);

        Task<PurchaseOrder> GetAllPurchaseOrderDetailsById(int PoId);

        Task<PurchaseOrder> GetTotalAvlAndLastMonthConsumption();

    }
}
