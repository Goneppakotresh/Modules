using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;

namespace IEMS_WEB.Areas.Hologram.Services
{
    public class SpoolBoxLabelPrintService : ISpoolBoxLabelPrint
    {
        public async Task<SpoolBoxLabelPrintResponse> GetAllSpoolBoxLabelPrintDetails()
        {
            SpoolBoxLabelPrint obj = new SpoolBoxLabelPrint();
            SpoolBoxLabelPrintResponse resModel = new SpoolBoxLabelPrintResponse();
            List<SpoolBoxLabelPrintResponse> responseModel = new List<SpoolBoxLabelPrintResponse>();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string url = URLPORTServices.GetURL(URLPORT.TNT);
                    var response = await HttpClientHelper.GetAPI(url + "V1/GetAllSpoolBoxLabelPrintDetails", string.Empty, "");
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SpoolBoxLabelPrintResponse>(data);
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

        public async Task<SpoolBoxLabelPrint> InsertSpoolBoxLabelPrintDetails(SpoolBoxLabelPrint reqModel)
        {
            SpoolBoxLabelPrint resModel = new SpoolBoxLabelPrint();
            using (var client = new HttpClient())
            {
                try
                {
                    #region Call API 
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqModel);
                    string url = URLPORTServices.GetURL(URLPORT.TNT);
                    var response = await HttpClientHelper.GetAPI(url+"V1/InsertSpoolBoxLabelPrintDetails", json, "");
                    #endregion
                    if (response != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        resModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SpoolBoxLabelPrint>(data);
                    }
                    return resModel;
                }
                catch (Exception ex)
                {
                    resModel.status = "0";
                    resModel.Message = "Something Went Wrong";
                    return resModel;
                }
            }
        }

    }
}
