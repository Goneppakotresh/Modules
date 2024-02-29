using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class IssueLabelController : Controller
    {
        private readonly IIssueDetails _IIssueDetails;
        public IssueLabelController(IIssueDetails issueDetails)
        {
            _IIssueDetails = issueDetails;
        }


        /// <summary>
        /// Get method for Issue label view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IssueLabelView()
        {
            TempData.Remove("IssueId");
            return View();
        }

        /// <summary>
        /// Fetch all issue details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllIssueDetails()
        {
            dynamic jsonResult = "";
            List <IssueLabelResponseDetails> List = new List<IssueLabelResponseDetails> ();
            List = await _IIssueDetails.GetAllIssueDetails();
            return Json(new { data = List }); ;
        }

        /// <summary>
        /// Get method for Issue Label departmentDetails.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> IssueLabel()
        {
            IssueLabel obj = new IssueLabel();
            if (TempData["IssueId"] != null)
            {
                obj.IssueId = Convert.ToInt32(TempData["IssueId"]);
                obj = await _IIssueDetails.GetIssueDetailsById(obj.IssueId);
            }
            else
            {
                obj.issueLabelDetails.Add(new TableDetails
                {
                    Slno = 1,
                    CaseNumber = ""
                });
            }
            var count = 1;
            foreach (var item in obj.issueLabelDetails)
                item.Slno = count++;

            return View(obj);
        }

        /// <summary>
        /// Save method for issue label details.
        /// </summary>
        /// <param name="jsondata"></param>
        /// <param name="dateval"></param>
        /// <param name="issno"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveIssueLabelDetails(string jsondata, string dateval, string issno)
        {
            IssueLabel obj = new IssueLabel();

            try
            {

                obj.BoxDetails = '[' + jsondata.Remove(jsondata.Trim().Length - 1, 1) + ']';
                string modifiedJsonString = obj.BoxDetails.Replace("\\\"", "\"");
                string modifiedString = modifiedJsonString.Remove(1, 1);
                modifiedString = modifiedString.Remove(modifiedString.Length - 2, 1);
                obj.IssueLabelList = JsonConvert.DeserializeObject<List<TableDetails>>('[' + jsondata.Remove(jsondata.Trim().Length - 1, 1) + ']').Distinct().ToList();
                obj.issueDate = Convert.ToDateTime(dateval);
                obj.issueNumber = issno;
                obj.BoxDetails = modifiedString;
                obj.userId = User.Identity.GetUserId();
                obj.userName = User.Identity.GetUserName();
                obj = await _IIssueDetails.InsertIssueLabelDetails(obj);
            }
            catch(Exception ex) { 
            
            }
            return Json(obj);

        }
        [HttpGet]
        public ActionResult GetIssueDetailsById(int IssueId)
        {
            TempData["IssueId"] = Convert.ToInt32(IssueId);
            return RedirectToAction("IssueLabel");

        }




    }
}