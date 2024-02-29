using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Policy;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class ReceiveHologramDispatchService : IReceiveHologramDispatch
    {
        public async Task<List<ReceiveHologramDispatch>> GetAllHologramDispatchDetails()
        {
            BrandCorrection obj = new BrandCorrection();
            ReceiveHologramDispatchResponse resModel = new ReceiveHologramDispatchResponse();
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
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReceiveHologramDispatch>>(data);
                    }
                }
                catch (Exception ex)
                {
                    obj.Status = 0;
                    obj.Message = "Something Went Wrong";
                }
                return resModel.List;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveHologramDispatch"></param>
        /// <returns></returns>
        public async Task<ReceiveHologramDispatchResponse> SavereceiveHologramDispatchDetails(ReceiveHologramDispatch receiveHologramDispatch)
        {
            ReceiveHologramDispatchResponse resModel = new ReceiveHologramDispatchResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(receiveHologramDispatch, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPutAPI("api/v1/receive", json,
                                            receiveHologramDispatch.userId, receiveHologramDispatch.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiveHologramDispatchResponse>(data);
                        resModel.Status = Convert.ToInt32(response.StatusCode);
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
        public async Task<PurchaseOrderDetails> GetPurchaseOrderDetails(int purchaseOrderId)
        {
            PurchaseOrderDetails purchaseOrderDetails = new PurchaseOrderDetails();

            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/purchaseorder/" + purchaseOrderId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        purchaseOrderDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseOrderDetails>(data);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }
                return purchaseOrderDetails;
            }

        }

        public async Task<List<SelectListItem>> GetPurchaseOrderList()
        {
            List<SelectListItem> PurchaseOrderSelectList = new List<SelectListItem>();
            List<PurchaseOrder> listPurchaseOrder = new List<PurchaseOrder>();
            ReceiveHologramDispatchResponse obj = new ReceiveHologramDispatchResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/GetPurchaseOrderList", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        listPurchaseOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PurchaseOrder>>(data);
                    }
                    //listPurchaseOrder = listPurchaseOrder.Where(m => m.Status == 1).ToList();
                    PurchaseOrderSelectList = listPurchaseOrder
                   .Select(item => new SelectListItem
                   {
                       Value = item.HologramPurchaseOrderId.ToString(),
                       Text = item.PurchaseOrderNumber
                   }).ToList();

                }
                catch (Exception ex)
                {
                    obj.Status = 0;
                    obj.Message = "Something Went Wrong";
                }
                return PurchaseOrderSelectList;
            }
        }

        public async Task<ReceiveHologramDispatch> ReceiveHologramDispatchById(int ReferenceId)
        {
            ReceiveHologramDispatch obj = new ReceiveHologramDispatch();
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
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiveHologramDispatch>(data);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
            return obj;
        }

        public async Task<List<SelectListItem>> GetIssuedHologramList()
        {
            List<SelectListItem> issueLabelSelectList = new List<SelectListItem>();
            List<IssueLabel> listIssueLabel = new List<IssueLabel>();
            ReceiveHologramDispatchResponse obj = new ReceiveHologramDispatchResponse();
            using (var client = new HttpClient())
            {

                #region Call API 
                var response = await HttpClientHelper.CallHologramGetAPI("api/v1/issuelabel", string.Empty);
                #endregion
                if (response != null)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    listIssueLabel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IssueLabel>>(data);
                }
                //listPurchaseOrder = listPurchaseOrder.Where(m => m.Status == 1).ToList();
                issueLabelSelectList = listIssueLabel
               .Select(item => new SelectListItem
               {
                   Value = item.IssueId.ToString(),
                   Text = item.issueNumber
               }).ToList();

                return issueLabelSelectList;
            }
        }
    }
}
