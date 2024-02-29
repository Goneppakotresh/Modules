using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Newtonsoft.Json;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class IndentRequestsService : IIndentRequests
    {
        public async Task<IndentDetailsResponse> GetAllIndentRequestDetails(string userId,string userName)
        {
            IndentRequests obj = new IndentRequests();
            IndentDetailsResponse resModel = new IndentDetailsResponse();
            List<IndentDetailsResponse> responseModel = new List<IndentDetailsResponse>();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/indent", string.Empty, userId, userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IndentRequests>>(data);
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

        public async Task<IndentCreate> SaveIndentDetails(IndentCreate indentCreate)
        {
            IndentCreate resModel = new IndentCreate();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(indentCreate, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPostAPI("api/v1/indent", json,
                                                       indentCreate.userId, indentCreate.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<IndentCreate>(data);
                    }
                    resModel.ResponseCode = Convert.ToInt32(response.StatusCode);
                }
                catch (Exception ex)
                {
                    resModel.Status = 0;
                }
                return resModel;
            }
        }


        public async Task<IndentCreate> IndentRequestGetById(IndentCreate indentCreate)
        {
            IndentCreate obj = new IndentCreate();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/indent/" + indentCreate.HologramIndentId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IndentCreate>(data);
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
