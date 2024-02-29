using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class PurchaseOrderController : Controller
    {

        private readonly IPurchaseOrder _IPurchaseOrder;
        public PurchaseOrderController(IPurchaseOrder iPurchaseOrder)
        {
            _IPurchaseOrder = iPurchaseOrder;
        }

        /// <summary>
        /// Get method for purchase order.
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public ActionResult PurchaseOrder()
        {
            TempData.Remove("PurchaseOrderId");
            return View();
        }

        /// <summary>
        /// Fetch all purchase order details.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllPurchaseOrderDetails()
        {
            PurchaseOrderResponse obj = new PurchaseOrderResponse();
            dynamic jsonResult = "";
            obj = await _IPurchaseOrder.GetAllPurchaseOrderDetails();
            //jsonResult = Json(new { data = obj.List });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return Json(new { data = obj.List }); 
        }

        /// <summary>
        /// Get method for purchase order creation.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> PurchaseOrderCreation()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            if (TempData["PurchaseOrderId"] != null)
            {
                purchaseOrder.HologramPurchaseOrderId = Convert.ToInt32(TempData["PurchaseOrderId"]);
                purchaseOrder = await _IPurchaseOrder.GetAllPurchaseOrderDetailsById(purchaseOrder.HologramPurchaseOrderId);

            }
            return View(purchaseOrder);
        }
        [HttpPost]
        public async Task<ActionResult> PurchaseOrderCreation(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.userId = User.Identity.GetUserId();
            purchaseOrder.userName = User.Identity.GetUserName();
            purchaseOrder = await _IPurchaseOrder.SavePurchaseOrderDetails(purchaseOrder);
            return View(purchaseOrder);
        }

        [HttpGet]
        public ActionResult EditViewPurchaseOrder(int PurchaseOrderId)
        {
            TempData["PurchaseOrderId"] = Convert.ToInt32(PurchaseOrderId);
            return RedirectToAction("PurchaseOrderCreation");

        }

        public async Task<ActionResult> GetTotalAvailAndLastMonthConsumpQnty()
        {
            PurchaseOrder obj = new PurchaseOrder();
            obj = await _IPurchaseOrder.GetTotalAvlAndLastMonthConsumption();
            return Json(new { data = obj });
        }
    }
}
