using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IPrintingRequest
    {
        Task<PrintingRequestResponse> GetAllPrintingRequestListDetails();
        Task<PrintResponse> SavePrintRequestDetails(PrintingRequest printRequest);
        Task<PrintingRequest> PrintingRequestById(int HologramPrintingRequestId);
        Task<PrintingRequest> GetRequestedBalance(int hologramPurchaseOrderId);
    }
}
