using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Comman;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class IssueLabelService : IIssueDetails
    {
        public async Task<List<IssueLabelResponseDetails>> GetAllIssueDetails()
        {
            IssueLabel obj = new IssueLabel();
            List<IssueLabelResponseDetails> List = new List<IssueLabelResponseDetails>();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/V1/issuelabel", string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IssueLabelResponseDetails>>(data);
                    }
                }
                catch (Exception ex)
                {
                    obj.Status = 0;
                    obj.Message = "Something Went Wrong";
                }
                return List;
            }
        }

        public async Task<IssueLabel> GetIssueDetailsById(int Id)
        {
            IssueLabel issueLabel = new IssueLabel();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    var response = await HttpClientHelper.CallHologramGetAPI("api/V1/issuelabel/" + Id, string.Empty);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        issueLabel = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueLabel>(data);
                    }
                }
                catch (Exception ex)
                {
                    issueLabel.Status = 0;
                    issueLabel.Message = "Something Went Wrong";
                }
                return issueLabel;
            }
        }

        public async Task<IssueLabel> InsertIssueLabelDetails(IssueLabel reqModel)
        {
            IssueLabel objRes = new IssueLabel();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    var response = await HttpClientHelper.CallHologramPostAPI("api/V1/issuelabelsavedetails", json,
                                                    reqModel.userId, reqModel.userName);
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        objRes = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueLabel>(data);
                        objRes.ResponseCode = Convert.ToInt32(response.StatusCode);
                    }
                }
                catch (Exception ex)
                {

                }
                return objRes;
            }
        }
    }
}