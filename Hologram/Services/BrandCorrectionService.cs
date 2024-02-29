using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class BrandCorrectionService : IBrandCorrection
    {
        public async Task<BrandCorrectionResponse> GetAllBrandCorrectionListDetails()
        {
            BrandCorrection obj = new BrandCorrection();
            BrandCorrectionResponse resModel = new BrandCorrectionResponse();
            List<BrandCorrectionResponse> responseModel = new List<BrandCorrectionResponse>();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string url = URLPORTServices.GetURL(URLPORT.TNT);
                    var response = await HttpClientHelper.GetAPI(url+"BrandCorrection/GetAllBrandCorrectionListDetails", string.Empty, "");
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BrandCorrectionResponse>(data);
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
    }
}
