using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class ProductionDispatchReceiveController : Controller
    {
        private readonly IProductionDispatch _productionDispatch;
        public ProductionDispatchReceiveController(IProductionDispatch productionDispatch)
        {
            _productionDispatch = productionDispatch;
        }
        // GET: ProductionDispatchReceive

        public async Task<ActionResult> ProductionDispatchReceive()
        {
            ProductionDispatchReceiveModel productionDispatchReceiveModel = new ProductionDispatchReceiveModel();            
            if (TempData["id"] != null)
            {
                if (TempData.Peek("Viewstatus") == "E") {
                    productionDispatchReceiveModel.DispatchDetails.Add(new ProductionDispatchReceive());
                    productionDispatchReceiveModel.DispatchId = Convert.ToUInt32(TempData.Peek("id"));
                    productionDispatchReceiveModel = await _productionDispatch.ProductionDispatchReceiveDetailsGetByViewById(productionDispatchReceiveModel);
                    productionDispatchReceiveModel.ViewStatus = Convert.ToString(TempData.Peek("Viewstatus"));
                }
                else
                {
                    
                    productionDispatchReceiveModel.DispatchDetails.Add(new ProductionDispatchReceive());
                    productionDispatchReceiveModel.DispatchId = Convert.ToUInt32(TempData.Peek("id"));
                    productionDispatchReceiveModel = await _productionDispatch.ProductionDispatchReceiveDetailsGetByViewById(productionDispatchReceiveModel);
                    productionDispatchReceiveModel.ReceivedBy = productionDispatchReceiveModel.DispatchDetails[0].ReceivedBy;
                    productionDispatchReceiveModel.ViewStatus = Convert.ToString(TempData.Peek("Viewstatus"));
                }
                   
            }
            return View(productionDispatchReceiveModel);
        }
        public ActionResult ProductionDispatchReceiveView()
        {
            ProductionDispatch productionDispatch = new ProductionDispatch();

            return View();
        }
        public async Task<ActionResult> GetAllProductionDispatchReceiveDetails()
        {
            ProductionDispatchReceiveResponse obj = new ProductionDispatchReceiveResponse();
            ////dynamic jsonResult = "";
            obj.List = await _productionDispatch.GetAllProductionDispatchReceiveDetails();
            //jsonResult = Json(new { data = obj.List });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return Json(new { data = obj.List }); ;
        }


        public ActionResult ProductionDispatchReceiveDetailsEditById(string dispatchId,string status)
        {
            ProductionDispatchReceiveModel obj = new ProductionDispatchReceiveModel();
            TempData["id"] = dispatchId;
            TempData["Viewstatus"] = status;
            return Json(new { data = obj });
        }


        public ActionResult ProductionDispatchReceiveDetailsViewById(string dispatchId, string status)
        {
            ProductionDispatchReceiveModel obj = new ProductionDispatchReceiveModel();
            TempData["id"] = dispatchId;
            TempData["Viewstatus"] = status;
            return Json(new { data = obj });
        }

        [HttpPost]
        public async Task<ActionResult> ProductionDispatchReceive(ProductionDispatchReceiveModel productionDispatchReceiveModel)
        {
            ProductionDispatchReceiveModel obj = new ProductionDispatchReceiveModel();
            productionDispatchReceiveModel.userId = User.Identity.GetUserId();
            productionDispatchReceiveModel.userName = User.Identity.GetUserName();
            obj = await _productionDispatch.InsertProductionDispatchReceive(productionDispatchReceiveModel);

            return View(obj);
        }
    }
}
