using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Newtonsoft.Json;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class PurchaseOrderService : IPurchaseOrder
    {
        public async Task<PurchaseOrderResponse> GetAllPurchaseOrderDetails()
        {
            PurchaseOrder obj = new PurchaseOrder();
            PurchaseOrderResponse resModel = new PurchaseOrderResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/purchaseorder", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PurchaseOrderGrid>>(data);
                    }
                }
                catch (Exception ex)
                {
                    obj.Status = 0;
                    obj.Message = "Something Went Wrong";
                }
                return resModel;
            }
        }

        public async Task<PurchaseOrder> GetAllPurchaseOrderDetailsById(int PoId)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/purchaseorder/" + PoId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        purchaseOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseOrder>(data);
                    }
                }
                catch (Exception ex)
                {
                    purchaseOrder.Status = 0;
                    purchaseOrder.Message = "Something Went Wrong";
                }
                return purchaseOrder;
            }
        }

        public async Task<PurchaseOrder> GetTotalAvlAndLastMonthConsumption()
        {
            PurchaseOrder obj = new PurchaseOrder();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/GetTotalAvailableAndLastMonthConsumptionQuantity", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseOrder>(data);
                    }
                }
                catch (Exception ex)
                {
                    obj.Status = 0;
                    obj.Message = "Something Went Wrong";
                }
                return obj;
            }
        }

        public async Task<PurchaseOrder> SavePurchaseOrderDetails(PurchaseOrder purchaseOrder)
        {
            PurchaseOrder resModel = new PurchaseOrder();
            purchaseOrder.Status = 1;
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(purchaseOrder, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPostAPI("api/v1/purchaseorder", json,
                        purchaseOrder.userId, purchaseOrder.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseOrder>(data);
                        resModel.ResponseCode = Convert.ToInt32(response.StatusCode);
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
    }
}
