using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class ReceivedIndexService : IReceivedIndex
    {
        public async Task<ReceivedIndexResponse> GetAllReceiverIndextListDetails()
        {
            ReceivedIndex obj = new ReceivedIndex();
            ReceivedIndexResponse resModel = new ReceivedIndexResponse();
            List<ReceivedIndexResponse> responseModel = new List<ReceivedIndexResponse>();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string url = URLPORTServices.GetURL(URLPORT.TNT);
                    var response = await HttpClientHelper.GetAPI(url + "v1/receivingboxdetail", string.Empty, "");
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceivedIndexResponse>(data);
                    }
                }
                catch (Exception ex)
                {
                    obj.Status = "0";
                    obj.Message = "Something Went Wrong";
                }
                return resModel;
            }
        }
    }
}
