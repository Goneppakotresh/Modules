using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class IssueSeriesController : Controller
    {
        // GET: IssueSeries
        private readonly IIssueSeries _IIssueSeries;
        private readonly IReceiveHologramDispatch _receiveHologramDispatch;
        private readonly IPrintingRequest _printingRequest;


        public IssueSeriesController(IIssueSeries issueSeries, IReceiveHologramDispatch receiveHologramDispatch, IPrintingRequest printingRequest)
        {
            _IIssueSeries = issueSeries;
            _receiveHologramDispatch = receiveHologramDispatch;
            _printingRequest = printingRequest;
        }

        /// <summary>
        /// Get method for IssueSeries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IssueSeries()
        {
            return View();
        }

        /// <summary>
        /// Get all Issue Series details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllIssueSeriesListDetails()
        {
            IssueSeriesResponse obj = new IssueSeriesResponse();
            dynamic jsonResult = "";
            obj = await _IIssueSeries.GetAllIssueSeriesListDetails();
            return Json(new { data = obj.List }); ;
        }

        public async Task<ActionResult> GetFromSeriesNo()
        {
            IssueSeries obj =new IssueSeries();
            obj = await _IIssueSeries.IssueSeriesFromNo();

            return Json(new {data=obj});
        }

        public async Task<ActionResult> IssueSeriesCreation()
        {
            PrintingRequest printReq = new PrintingRequest();
            IssueSeries issueSeries = new IssueSeries();
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            if (TempData["PrintRequestId"]!=null)
            {
                int printRequestId = Convert.ToInt32(TempData["PrintRequestId"]);
                printReq = await _printingRequest.PrintingRequestById(printRequestId);
            }
            issueSeries.PrintRequestNumber = printReq.RequestNumber;
            issueSeries.PrintingRequestId = printReq.HologramPrintingRequestId;
            issueSeries.PrintRequestDate = printReq.RequestDate;
            issueSeries.PurchaseOrderId = printReq.HologramPurchaseOrderId;
            issueSeries.PrintingRequestQuantity = Convert.ToInt32(printReq.RequestQuantity);
            if (TempData["id"] != null)
            {
                issueSeries.SeriesId = Convert.ToInt32(TempData["id"]);
                issueSeries = await _IIssueSeries.IssueSeriesById(issueSeries.SeriesId);
                return View(issueSeries);
            }
            return View(issueSeries);
        }

        [HttpPost]
        public async Task<ActionResult> IssueSeriesCreation(IssueSeries issueSeries)
        {
            IssueSeries printResponse = new IssueSeries();
            issueSeries.userId = User.Identity.GetUserId();
            issueSeries.userName = User.Identity.GetUserName();
            issueSeries.responses = await _IIssueSeries.SaveIssueSeriesDetails(issueSeries);
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            return View(issueSeries);
        }

        [HttpGet]
        public ActionResult IssueSeriesById(string id)
        {
            TempData["PrintRequestId"] = Convert.ToInt32(id);
            return RedirectToAction("IssueSeriesCreation");
        }
    }
}