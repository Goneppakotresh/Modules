using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Newtonsoft.Json;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class PurchaseHologramDispatchService : IPurchaseHologramDispatch
    {
        public async Task<PurchaseHologramResponse> SavePurchaseHologramDispatchDetails(PurchaseHologramDispatch purchaseHologramDispatch)
        {
            PurchaseHologramResponse resModel = new PurchaseHologramResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(purchaseHologramDispatch, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPostAPI("api/v1/purchaseOrderDispatchService", json,
                        purchaseHologramDispatch.userId, purchaseHologramDispatch.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseHologramResponse>(data);
                        resModel.Status = Convert.ToInt32(response.StatusCode);
                        resModel.DispatchNumber = Convert.ToString(resModel.DispatchNumber);
                    }
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                    resModel.Message = "Something Went Wrong";
                }
                return resModel;
            }

        }
        public async Task<List<PurchaseHologramDispatchGrid>> GetAllPurchaseDispatchDetails()
        {
            PurchaseHologramResponse resModel = new PurchaseHologramResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 

                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/purchaseOrderDispatch", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PurchaseHologramDispatchGrid>>(data);
                    }
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                    resModel.Message = "Something Went Wrong";
                }
                return resModel.List;
            }
        }

        public async Task<PurchaseHologramDispatch> PurchaseHologramDispatchById(int ReferenceId)
        {
            PurchaseHologramDispatch obj = new PurchaseHologramDispatch();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/purchaseOrderDispatchId/" + ReferenceId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseHologramDispatch>(data);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
            return obj;
        }
    }
}
