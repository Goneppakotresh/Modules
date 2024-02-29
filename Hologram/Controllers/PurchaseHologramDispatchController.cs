using IEMS_WEB.Areas.DepotSale.Models;
using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class PurchaseHologramDispatchController : Controller
    {
        private readonly IReceiveHologramDispatch _receiveHologramDispatch;
        private readonly IPurchaseHologramDispatch _PurchaseHologramDispatch;

        public PurchaseHologramDispatchController(IReceiveHologramDispatch receiveHologramDispatch, IPurchaseHologramDispatch PurchaseHologramDispatch)
        {
            _receiveHologramDispatch = receiveHologramDispatch;
            _PurchaseHologramDispatch = PurchaseHologramDispatch;
        }
        // GET: PurchaseHologram
        public async Task<ActionResult> PurchaseHologramDispatch()
        {
            PurchaseHologramDispatch objPurchaseHologram = new PurchaseHologramDispatch();
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            ViewBag.IssueLabeList = await _receiveHologramDispatch.GetIssuedHologramList();
            if (HttpContext.Session.GetComplexData<Int32>("id") != null)
            {
                objPurchaseHologram.ReferenceId = HttpContext.Session.GetComplexData<Int32>("id");
                objPurchaseHologram = await _PurchaseHologramDispatch.PurchaseHologramDispatchById(objPurchaseHologram.ReferenceId);
                objPurchaseHologram.ReferenceId = objPurchaseHologram.ReferenceId;
                objPurchaseHologram.issueLabelDetails.Add(new TableDetails
                {
                    Slno = 1,
                    CaseNumber = ""
                });
                HttpContext.Session.Remove("id");
            }
            return View(objPurchaseHologram);
        }
        public ActionResult PurchaseHologramDispatchView()
        {
            HttpContext.Session.Remove("id");
            return View();
        }
        public async Task<ActionResult> GetAllHologramDispatchDetails()
        {
            PurchaseHologramResponse obj = new PurchaseHologramResponse();
            dynamic jsonResult = "";
            obj.List = await _PurchaseHologramDispatch.GetAllPurchaseDispatchDetails();
            return Json(new { data = obj.List }); 
        }
        [HttpPost]
        public async Task<ActionResult> PurchaseHologramDispatch(PurchaseHologramDispatch purchaseOrder)
        {
            PurchaseHologramResponse purchaseHologramDispatchResponse = new PurchaseHologramResponse();
            ReceiveHologramDispatch obj = new ReceiveHologramDispatch();
            purchaseOrder.userId = User.Identity.GetUserId();
            purchaseOrder.userName = User.Identity.GetUserName();
            purchaseHologramDispatchResponse = await _PurchaseHologramDispatch.SavePurchaseHologramDispatchDetails(purchaseOrder);
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            ViewBag.IssueLabeList = await _receiveHologramDispatch.GetIssuedHologramList();
            purchaseOrder.ResponseCode = purchaseHologramDispatchResponse.Status;
            purchaseOrder.DispatchNumber = purchaseHologramDispatchResponse.DispatchNumber;
            return View(purchaseOrder);
        }

        [HttpGet]
        public async Task<ActionResult> PurchaseHologramDispatchById(string id)
        {
            PurchaseHologramDispatch obj = new PurchaseHologramDispatch();

            obj.ReferenceId = Convert.ToInt32(id);
            HttpContext.Session.SetComplexData("id", obj.ReferenceId);
            return Json(new { data = obj });
        }
    }
}
