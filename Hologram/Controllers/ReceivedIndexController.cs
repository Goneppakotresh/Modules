using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class ReceiveIndexController : Controller
    {
        private readonly IReceiveHologramDispatch _receiveHologramDispatch;
        public ReceiveIndexController(IReceiveHologramDispatch receiveHologramDispatch)
        {
            _receiveHologramDispatch = receiveHologramDispatch;
        }

        /// <summary>
        /// Get method for hologram dispatch .
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ReceiveHologramDispatch()
        {
            ReceiveHologramDispatch objReceivedHolo = new ReceiveHologramDispatch();

            return View(objReceivedHolo);
        }

        /// <summary>
        /// Fetch all Hologram dispatch details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllHologramDispatchDetails()
        {
            ReceiveHologramDispatchResponse obj = new ReceiveHologramDispatchResponse();
            dynamic jsonResult = "";
            obj.List = await _receiveHologramDispatch.GetAllHologramDispatchDetails();
            jsonResult = Json(new { data = obj.List });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        /// <summary>
        /// Get method for Hologram dispatch creation.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ReceiveHologramDispatchCreation()
        {
            ReceiveHologramDispatch obj = new ReceiveHologramDispatch();
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            ViewBag.IssueLabeList = await _receiveHologramDispatch.GetIssuedHologramList();

            if (TempData["id"] != null)
            {
                obj.ReferenceId = (int)TempData["id"];
                obj = await _receiveHologramDispatch.ReceiveHologramDispatchById(obj.ReferenceId);
                return View(obj);

            }
            return View(obj);
        }

        public async Task<JsonResult> GetPurchaseOrderDetails(int purchaseOrderId)
        {

            PurchaseOrderDetails purchaseOrderDetails = new PurchaseOrderDetails();
            purchaseOrderDetails = await _receiveHologramDispatch.GetPurchaseOrderDetails(Convert.ToInt16(purchaseOrderId));
            var date = DateTime.Parse(purchaseOrderDetails.PurchaseOrderDate).ToString("dd-MMM-yyyy");
            //var date1 = DateTime.Parse(purchaseOrderDetails.PurchaseOrderDate.ToString("dd-MMM-yyyy"));
            purchaseOrderDetails.PurchaseOrderDate = date;
            return Json(purchaseOrderDetails);
        }

        /// <summary>
        /// Save Receive Hologram dispatch details.
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ReceiveHologramDispatchCreation(ReceiveHologramDispatch purchaseOrder)
        {
            ReceiveHologramDispatchResponse receiveHologramDispatchResponse = new ReceiveHologramDispatchResponse();
            purchaseOrder.userId = User.Identity.GetUserId();
            purchaseOrder.userName = User.Identity.GetUserName();
            receiveHologramDispatchResponse = await _receiveHologramDispatch.SavereceiveHologramDispatchDetails(purchaseOrder);
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            ViewBag.IssueLabeList = await _receiveHologramDispatch.GetIssuedHologramList();

            purchaseOrder.ResponseCode = receiveHologramDispatchResponse.Status;
            return View(purchaseOrder);
        }

        [HttpGet]
        public async Task<ActionResult> ReceiveHologramDispatchById(string id)
        {
            ReceiveHologramDispatch obj = new ReceiveHologramDispatch();

            obj.ReferenceId = Convert.ToInt32(id);
            TempData["id"] = obj.ReferenceId;
            //obj = await _receiveHologramDispatch.ReceiveHologramDispatchById(obj) ;

            return Json(new { data = obj });
        }


    }
}
