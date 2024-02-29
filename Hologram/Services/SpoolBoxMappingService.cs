using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class SpoolBoxMappingService : ISpoolBoxMapping
    {
        public async Task<List<SpoolBoxMapping>> GetAllSpoolBoxMappingDetails()
        {
            List<SpoolBoxMapping> obj = new List<SpoolBoxMapping>();
            SpoolBoxMappingResponse resModel = new SpoolBoxMappingResponse();
            List<SpoolBoxMappingResponse> responseModel = new List<SpoolBoxMappingResponse>();

            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/get", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SpoolBoxMapping>>(data);
                    }
                }
                catch (Exception ex)
                {
                    //obj.Status = 0;
                    //obj.Message = "Something Went Wrong";
                }
                return obj;
            }
        }

        public async Task<SpoolBoxMapping> GetSpoolCaseMappingByBoxNumber(SpoolBoxMapping reqModel)
        {
            SpoolBoxMapping obj = new SpoolBoxMapping();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/get/box/" + reqModel.CaseNumber, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SpoolBoxMapping>(data);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
            return obj;
        }

        public async Task<SpoolBoxMapping> GetSpoolCaseMappingById(SpoolBoxMapping reqModel)
        {
            SpoolBoxMapping obj = new SpoolBoxMapping();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/get/" + reqModel.SpoolCaseMappingId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SpoolBoxMapping>(data);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
            return obj;
        }

        public async Task<SpoolBoxMapping> InsertSpoolBoxMappingDetails(SpoolBoxMapping reqModel)
        {
            SpoolBoxMapping resModel = new SpoolBoxMapping();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPostAPI("api/add", json,
                                    reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SpoolBoxMapping>(data);
                        resModel.ResponseCode = Convert.ToInt32(response.StatusCode);
                    }

                    return resModel;
                }
                catch (Exception ex)
                {
                    resModel.ResponseCode = 0;
                    resModel.Message = "Something Went Wrong";
                    return resModel;
                }
            }
        }
    }
}
