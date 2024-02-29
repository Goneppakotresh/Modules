using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NReco.PdfGenerator;
using System.ComponentModel;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class PrintingRequestController : Controller
    {
        private readonly IReceiveHologramDispatch _receiveHologramDispatch;

        private readonly IPrintingRequest _IPrintingRequest;

        public PrintingRequestController(IPrintingRequest PrintingRequest, IReceiveHologramDispatch receiveHologramDispatch)
        {
            _IPrintingRequest = PrintingRequest;
            _receiveHologramDispatch = receiveHologramDispatch;

        }

        /// <summary>
        /// Get method for print request.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PrintingRequest()
        {
            return View();
        }

        /// <summary>
        /// Get all print request details method.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllPrintingRequestListDetails()
        {
            PrintingRequestResponse obj = new PrintingRequestResponse();
            dynamic jsonResult = "";
            obj = await _IPrintingRequest.GetAllPrintingRequestListDetails();
            //jsonResult = Json(new { data = obj.List });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return Json(new { data = obj.List }); ;
        }

        [HttpGet]
        public async Task<ActionResult> PrintingRequestCreation()
        {
            PrintingRequest printingRequest = new PrintingRequest();
            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            if (TempData["id"] != null)
            {

                PrintingRequestGrid obj = new PrintingRequestGrid();
                obj.HologramPrintingRequestId = Convert.ToInt32(TempData["id"]);
                printingRequest = await _IPrintingRequest.PrintingRequestById(obj.HologramPrintingRequestId);
                var hologramprintbalance= await _IPrintingRequest.GetRequestedBalance(printingRequest.HologramPurchaseOrderId);
                printingRequest.Balance = hologramprintbalance?.Balance;

            }
            return View(printingRequest);
        }

        [HttpPost]
        public async Task<ActionResult> PrintingRequestCreation(PrintingRequest printingRequest)
        {
            PrintResponse printResponse = new PrintResponse();

            ViewBag.PurchaseOrderList = await _receiveHologramDispatch.GetPurchaseOrderList();
            printingRequest.userId = User.Identity.GetUserId();
            printingRequest.userName = User.Identity.GetUserName();
            printingRequest.responses = await _IPrintingRequest.SavePrintRequestDetails(printingRequest);
            return View(printingRequest);
        }

        [HttpGet]
        public async Task<ActionResult> PrintingRequestById(string id)
        {
            PrintingRequest obj = new PrintingRequest();

            obj.HologramPrintingRequestId = Convert.ToInt32(id);
            TempData["id"] = obj.HologramPrintingRequestId;

            return RedirectToAction("PrintingRequestCreation");
        }

        public async Task<ActionResult> GetRequestedBalance(int hologramPurchaseOrderId)
        {
            PrintingRequest obj = new PrintingRequest();
            obj = await _IPrintingRequest.GetRequestedBalance(hologramPurchaseOrderId);

            return Json(new { data = obj });
        }

        public async Task<ActionResult> PrintingRequestDetails(int hologramPurchaseOrderId)
        {
            PrintingRequest printingRequest = new PrintingRequest();
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            printingRequest = await _IPrintingRequest.PrintingRequestById(hologramPurchaseOrderId);
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
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Purchase Date: " + printingRequest.RequestDate + "</td>";
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
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Requested No.</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Label Quantity<th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Request Hologram Quantity</th>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>1.</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p>" + printingRequest.RequestDate + "</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>" + printingRequest.RequestQuantity + "</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'></td>";
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
                return File(pdfBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Print Request.pdf");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
