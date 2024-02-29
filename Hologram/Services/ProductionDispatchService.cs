using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using System.Security.Policy;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class ProductionDispatchService : IProductionDispatch
    {
        public async Task<List<ProductionDispatchResponseDetails>> GetAllProductionDispatchDetails()
        {
            ProductionDispatchResponse resModel = new ProductionDispatchResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/indent", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionDispatchResponseDetails>>(data);
                    }
                }
                catch (Exception ex)
                {

                }
                return resModel.List;
            }
        }

        public async Task<ProductionDispatchResponseDetails> GetProductionDispatchDetailsById(int ReqId)
        {
            ProductionDispatchResponseDetails objDetails = new ProductionDispatchResponseDetails();

            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/indent/" + ReqId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        objDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchResponseDetails>(data);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }
                return objDetails;
            }

        }

        public async Task<ProductionDispatchResponse> InsertProductionDispatchDetails(ProductionDispatch reqModel)
        {
            ProductionDispatchResponse resModel = new ProductionDispatchResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPostAPI("api/V1/hologramdispatchsavedetails", json,
                        reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchResponse>(data);
                    }
                    resModel.Status = Convert.ToInt32(response.StatusCode);
                    return resModel;
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                    resModel.Message = "Something Went Wrong";
                    return resModel;
                }
            }
        }

        public async Task<ProductionDispatchResponse> SubmitProductionDispatchDetails(ProductionDispatch reqModel)
        {
            ProductionDispatchResponse resModel = new ProductionDispatchResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPostAPI("ProductionDispatch/SubmitProductionDispatchDetails",
                                    json, reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchResponse>(data);
                    }
                    return resModel;
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                    resModel.Message = "Something Went Wrong";
                    return resModel;
                }
            }
        }



        public async Task<ProductionDispatchReceiveModel> ProductionDispatchReceiveDetailsGetByViewById(ProductionDispatchReceiveModel reqModel)
        {
            ProductionDispatchReceiveModel obj = new ProductionDispatchReceiveModel();

            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/V1/dispatchReceive/" + reqModel.DispatchId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchReceiveModel>(data);

                    }
                }
                catch (Exception ex)
                {

                }
                return obj;
            }
        }

        public async Task<List<ProductionDispatchReceiveModel>> GetAllProductionDispatchReceiveDetails()
        {
            ProductionDispatchReceiveResponse obj = new ProductionDispatchReceiveResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/dispatch", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionDispatchReceiveModel>>(data);
                    }
                }
                catch (Exception ex)
                {

                }
                return obj.List;
            }

        }

        public async Task<ProductionDispatchReceiveModel> InsertProductionDispatchReceive(ProductionDispatchReceiveModel reqModel)
        {
            ProductionDispatchReceiveModel obj = new ProductionDispatchReceiveModel();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPutAPI("api/V1/dispatchReceiveUpdate", json,
                                                        reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchReceiveModel>(data);
                    }
                    obj.ResponseCode = Convert.ToInt32(response.StatusCode);
                    return obj;
                }
                catch (Exception ex)
                {
                    obj.Message = "Something Went Wrong";
                    return obj;
                }
            }
        }

        public async Task<ProductionDispatch> InsertProductionDispatchFormDetails(ProductionDispatch reqModel)
        {
            ProductionDispatch obj = new ProductionDispatch();
            using (var client = new HttpClient())
            {

                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPutAPI("api/V1/dispatchReceiveUpdate", json,
                                                    reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatch>(data);
                    }
                    obj.ResponseCode = Convert.ToInt32(response.StatusCode);
                    return obj;
                }
                catch (Exception ex)
                {
                    obj.Message = "Something Went Wrong";
                    return obj;
                }
            }
        }

        public async Task<ProductionDispatchModelbinding> GetProductionDispatchViewById(int ReqId)
        {
            ProductionDispatchModelbinding obj = new ProductionDispatchModelbinding();
            using (var client = new HttpClient())
            {

                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(ReqId);
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/IndentDispatchDetail?indentId=" + ReqId, json);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductionDispatchModelbinding>(data);
                    }
                    //obj.ResponseCode = Convert.ToInt32(response.StatusCode);
                    return obj;
                }
                catch (Exception ex)
                {
                    return obj;
                }
            }
        }
    }
}
