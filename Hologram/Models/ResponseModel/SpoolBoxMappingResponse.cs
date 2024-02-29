using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Models;

namespace IEMS_WEB.Areas.Hologram.Models.ResponseModel
{
    public class SpoolBoxMappingResponse
    {
        public SpoolBoxMappingResponse()
        {
            List = new List<SpoolBoxMapping>();
        }
        public List<SpoolBoxMapping> List { get; set; }
    }
    public class SpoolBoxMapping : BaseModel
    {
        public SpoolBoxMapping()
        {
            SpoolCaseMappingandDetails = new List<SpoolModel>();

        }
        public List<SpoolModel> SpoolCaseMappingandDetails { get; set; }
        public int SpoolCaseMappingId { get; set; }
        public string CaseNumber { get; set; }
        public int FinalYear { get; set; }
        public int Status { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string Remark { get; set; } = "";
        public string ViewStatus { get; set; } = "";
        public int ResponseCode { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
    }

}
