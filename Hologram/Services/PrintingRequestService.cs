using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Newtonsoft.Json;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class PrintingRequestService : IPrintingRequest
    {
        public async Task<PrintingRequestResponse> GetAllPrintingRequestListDetails()
        {
            BrandCorrection obj = new BrandCorrection();
            PrintingRequestResponse resModel = new PrintingRequestResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/printrequest", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PrintingRequestGrid>>(data);
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

        public async Task<PrintResponse> SavePrintRequestDetails(PrintingRequest printRequest)
        {
            PrintResponse resModel = new PrintResponse();
            printRequest.Status = 1;
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(printRequest, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPostAPI("api/v1/printrequest", json,
                                                        printRequest.userId,printRequest.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PrintResponse>(data);
                        resModel.Status = Convert.ToInt32(response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                }
                return resModel;
            }
        }

        public async Task<PrintingRequest> PrintingRequestById(int HologramPrintingRequestId)
        {
            PrintingRequest obj = new PrintingRequest();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/printrequest/" + HologramPrintingRequestId, string.Empty);

                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<PrintingRequest>(data);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
            return obj;
        }


        public async Task<PrintingRequest> GetRequestedBalance(int hologramPurchaseOrderId)
        {
            PrintingRequest obj = new PrintingRequest();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/GetRequestedBalance/" + hologramPurchaseOrderId, string.Empty);

                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<PrintingRequest>(data);
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
