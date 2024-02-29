using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IProductionDispatch
    {
        Task<List<ProductionDispatchResponseDetails>> GetAllProductionDispatchDetails();
        Task<ProductionDispatchResponseDetails> GetProductionDispatchDetailsById(int ReqId);
        //new 
        Task<ProductionDispatchModelbinding> GetProductionDispatchViewById(int ReqId);
        Task<ProductionDispatchResponse> InsertProductionDispatchDetails(ProductionDispatch reqModel);
        //new Insert Method 

        Task<ProductionDispatch> InsertProductionDispatchFormDetails(ProductionDispatch reqModel);
        //
        Task<ProductionDispatchResponse> SubmitProductionDispatchDetails(ProductionDispatch reqModel);
        // new 

        Task<List<ProductionDispatchReceiveModel>> GetAllProductionDispatchReceiveDetails();
        Task<ProductionDispatchReceiveModel> ProductionDispatchReceiveDetailsGetByViewById(ProductionDispatchReceiveModel reqModel);
        Task<ProductionDispatchReceiveModel> InsertProductionDispatchReceive(ProductionDispatchReceiveModel reqModel);



    }
}
