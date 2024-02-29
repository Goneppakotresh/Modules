using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using IEMS_WEB.Areas.DepotSale.Models;
using IEMS_FrontApplications.Models.SupplierManagement;
using NReco.PdfGenerator;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class ReceiveHologramDispatchController : Controller
    {
        private readonly IReceiveHologramDispatch _receiveHologramDispatch;
        public ReceiveHologramDispatchController(IReceiveHologramDispatch receiveHologramDispatch)
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
            return Json(new { data = obj.List }); ;

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
            //var date = purchaseOrderDetails.PurchaseOrderDate.ToString("dd-MMM-yyyy");
            //var date1 = DateTime.Parse(purchaseOrderDetails.PurchaseOrderDate.ToString("dd-MMM-yyyy"));
            //purchaseOrderDetails.PurchaseOrderDate = date1;
            return Json(purchaseOrderDetails);
        }
        /// <summary>
        /// Gets the <see cref="ClaimsPrincipal"/> for user associated with the executing action.
        /// </summary>
        public ClaimsPrincipal User => HttpContext?.User!;
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

            return Json(new { data = obj } );
        }

        public async Task<ActionResult> PrintReceiveHologramDetails(int purchaseOrderId)
        {
            PurchaseOrderDetails purchaseOrderDetails = new PurchaseOrderDetails();
            purchaseOrderDetails = await _receiveHologramDispatch.GetPurchaseOrderDetails(purchaseOrderId);
            try
            {
                byte[] PdfPaySlip = new byte[2048];
                HtmlToPdfConverter html = new HtmlToPdfConverter();
                html.Size = NReco.PdfGenerator.PageSize.Letter;

                string strHTML = string.Empty;

                strHTML += "<!DOCTYPE html>";
                strHTML += "<html lang='en'>";
                strHTML += "<head>";
                strHTML += "<meta charset='UTF-8'>";
                strHTML += "<meta name='viewport' content='width=device-width, initial-scale=1.0'>";
                strHTML += "<title>Document</title>";
                strHTML += "</head>";
                strHTML += "<body>";

                strHTML += "<div style='text-align: center;'><h3>Government of Rajasthan</h3></div>";
                strHTML += "<div style='text-align: center;'><h3>Excise Department, Udaipur</h3></div>";
                strHTML += "<div style='text-align: center;'><h2 style='font-weight: bold; padding: 1px 0;'>Indent for QR Coded Holograms</h2></div>";

                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Purchase Date: " + purchaseOrderDetails.PurchaseOrderDate + "</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Indent No.: 20232024/2242/RFS/733</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Indented by: UNITED BREWERIES LTD. SHAHJAHAPUR ALWAR</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>GRN No.: 82123184</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>GRN Date: 27-Oct-2023</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'> </td>";
                strHTML += "</tr>";
                strHTML += "</table>";

                strHTML += "<br>";

                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>SL.No</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Purchase Order Name</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Supplier</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Request Hologram Quantity</th>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>1.</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p>"+ purchaseOrderDetails.PurchaseOrderNumber +"</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>" + purchaseOrderDetails.Supplier + "</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>" + purchaseOrderDetails.RequestQuantity + "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";

                strHTML += "<br>";

                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Name & Mobile No. of Authorized Person<br> to take delivery of Holograms</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'> </td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Vehicle No.</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'> </td>";
                strHTML += "</tr>";
                strHTML += "</table>";

                //< !-- Signature Text -->
                strHTML += "<div style='margin-top: 10px; text-align: right; padding: 50px;'><h5>(Name of Signature of OIC of M/s UNITED BREWERIES LTD. SHAHJAHAPUR ALWAR)</h5></div>";

                strHTML += "</body>";
                strHTML += "</html>";

                var htmlContent = String.Format(strHTML, DateTime.Now);
                var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(htmlContent);
                return File(pdfBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Receive Hologram Dispatch.pdf");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

