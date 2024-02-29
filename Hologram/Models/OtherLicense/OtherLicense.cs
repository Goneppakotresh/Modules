using Microsoft.AspNetCore.Mvc.Rendering;

namespace IEMS_WEB.Areas.Hologram.Models.OtherLicense
{
    public class OtherLicense
    {
        public string OtherLicenseeFormCode = "OTHER_LIC";
        public int LicenseeTypeId { set; get; }
        public string LicenseeTypeName { set; get; }
        public string LicenseeTypeCode { set; get; }
        public string Action { set; get; }

        public string LicenseeNumber { set; get; }
        public string IssueDate { set; get; }
        public string LicenseeName { set; get; }
        public string CurrentAddress { set; get; }
        public string RegistrationAddress { set; get; }
        public string StateName { set; get; }
        public string DistrictName { set; get; }
        public string CityName { set; get; }
        public int StateId { set; get; }
        public int DistrictId { set; get; }
        public int CityId { set; get; }
        public string ContactNumber { set; get; }
        public string EmailId { set; get; }
        public int DEOId { set; get; }
        public string DEOName { set; get; }
        public int CircleId { set; get; }
        public string CircleName { set; get; }
        public string ValidFromDate { set; get; }
        public string ValidToDate { set; get; }
        public int PkId { set; get; }

        public string ContractType { set; get; }
        public string LicenseeGroup { set; get; }
        public string ContractValue { set; get; }
        public string Remarks { set; get; }
        public string DropDownType { set; get; }
        public int UnitId { set; get; }
        public string DutyFreeQuota { set; get; }
        public int Responsecode { set; get; }
        public string LicenseeFee { set; get; }
        public string LicTypename { get; set; }
        public string RuleUnderGenerated { set; get; }
        public List<SelectListItem> lstState = new List<SelectListItem>();
        public List<SelectListItemOverRide> lstLicenseType = new List<SelectListItemOverRide>();
        public List<SelectListItem> lstContractValue = new List<SelectListItem>();
        public List<SelectListItem> lstLicenseefor = new List<SelectListItem>();
        public List<SelectListItem> lstContractType = new List<SelectListItem>();
        public List<SelectListItem> lstDistrict = new List<SelectListItem>();
        public List<SelectListItem> lstCity = new List<SelectListItem>();
        public List<SelectListItem> lstUnit = new List<SelectListItem>();
        public List<SelectListItem> lstRuleUnderGenerated = new List<SelectListItem>();
        public List<SelectListItem> lstDeo = new List<SelectListItem>();
        public List<SelectListItem> lstCircle = new List<SelectListItem>();


  
    }


    public class LicenseeTypeDropDownListResponse
    {
        public LicenseeTypeDropDownListResponse()
        {
            ListLicenseeType = new List<SelectListItemOverRide>();
        }
        public List<SelectListItemOverRide> ListLicenseeType { get; set; }
    }
    public class SelectListItemOverRide : SelectListItem
    {

        public string ActionType { set; get; }


    }
}
