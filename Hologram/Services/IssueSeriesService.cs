using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Comman;
using Newtonsoft.Json;


namespace IEMS_WEB.Areas.Hologram.Services
{
    public class IssueSeriesService : IIssueSeries
    {

        public async Task<IssueSeriesResponse> GetAllIssueSeriesListDetails()
        {
            IssueSeries obj = new IssueSeries();
            IssueSeriesResponse resModel = new IssueSeriesResponse();
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
                        resModel.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IssueSeriesGrid>>(data);
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

        public async Task<IssueSeries> IssueSeriesById(int IssueSeriesId)
        {
            IssueSeries issueSeries = new IssueSeries();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/issueSeriesId/" + IssueSeriesId, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        issueSeries = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueSeries>(data);
                    }
                }
                catch (Exception ex)
                {
                    issueSeries.Status = 0;
                    issueSeries.Message = "Something Went Wrong";
                }
                return issueSeries;
            }
        }

        public async Task<IssueSeries> IssueSeriesFromNo()
        {
            IssueSeries obj = new IssueSeries();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/v1/issueSeriesFromSeries", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueSeries>(data);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return obj;
            }
        }

        public async Task<IssueSeriesResponse> SaveIssueSeriesDetails(IssueSeries issueSeries)
        {
            IssueSeriesResponse resModel = new IssueSeriesResponse();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = JsonConvert.SerializeObject(issueSeries, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var response = await HttpClientHelper.CallHologramPostAPI("api/v1/issueSeries", json, 
                                                            issueSeries.userId, issueSeries.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueSeriesResponse>(data);
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