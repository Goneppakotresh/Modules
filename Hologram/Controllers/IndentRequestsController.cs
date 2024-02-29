using IEMS_WEB.Areas.DepotSale.Models;
using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using IEMS_WEB.Comman;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NReco.PdfGenerator;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class IndentRequestsController : Controller
    {
        private readonly IIndentRequests _IndentRequestDetails;
        public IndentRequestsController(IIndentRequests IndentRequest)
        {
            _IndentRequestDetails = IndentRequest;
        }

        /// <summary>
        /// Get method for Indent request.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IndentRequests()
        {
            HttpContext.Session.Remove("id");

            return View();
        }

        /// <summary>
        /// Fetch all indent request details.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllIndentListDetails()
        {
            IndentDetailsResponse obj = new IndentDetailsResponse();
            obj = await _IndentRequestDetails.GetAllIndentRequestDetails(User.Identity.GetUserId(), User.Identity.GetUserName());
            //jsonResult = Json(new { data = obj.List });
            //jsonResult.MaxJsonLength = int.MaxValue;
            return Json(new { data = obj.List }); ;
        }
        // GET: IndentCreate
        public async Task<ActionResult> IndentCreate()
        {
            IndentCreate indentCreate = new IndentCreate();

            if (HttpContext.Session.GetComplexData<Int32>("id") != null)
            {
                indentCreate.HologramIndentId = HttpContext.Session.GetComplexData<Int32>("id");

                indentCreate = await _IndentRequestDetails.IndentRequestGetById(indentCreate);
            }

            return View(indentCreate);
        }



        [HttpPost]
        public async Task<ActionResult> IndentCreate(IndentCreate indentCreate)
        {
            indentCreate.Status = 1;
            indentCreate.userId=User.Identity.GetUserId();
            indentCreate.userName = User.Identity.GetUserName();
            indentCreate = await _IndentRequestDetails.SaveIndentDetails(indentCreate);
            return View(indentCreate);
        }

        [HttpGet]
        public async Task<ActionResult> IndentRequestViewById(string hologramIndentId)
        {
            IndentDetailsResponse obj = new IndentDetailsResponse();
            //TempData["id"] = hologramIndentId;
            HttpContext.Session.SetComplexData("id", hologramIndentId);

            return Json(new { data = obj });

        }

        public async Task<ActionResult> IndentDetailsPdf(int indentId)
        {
            IndentCreate indentCreate = new IndentCreate();
            indentCreate.HologramIndentId = indentId;
            indentCreate = await _IndentRequestDetails.IndentRequestGetById(indentCreate);
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
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Indent Date: " + string.Format("{0:dd-MMM-yyyy}", indentCreate.RequestDate) + " </td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Indent No.: " + indentCreate.RequestNumber + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Indented by: UNITED BREWERIES LTD. SHAHJAHAPUR ALWAR</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>GRN No.: " + indentCreate.GoodReceivedNoteNumber + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>GRN Date: " + string.Format("{0:dd-MMM-yyyy}", indentCreate.GoodReceivedNoteDate) + "</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'> </td>";
                strHTML += "</tr>";
                strHTML += "</table>";

                strHTML += "<br>";

                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<td colspan='4' style='border: 1px solid #333; padding: 8px; text-align:center'>Details of Indented Holograms</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>SL.No</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>No. of Boxes</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Total Quantity of Holograms</th>"; // Fix: Added closing tag </th>
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Amount Paid</th>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>1.</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p> " + indentCreate.CaseQuantity + "</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p> " + indentCreate.RequestLabelQuantity + "</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p>" + (indentCreate.TotalAmount != null ? string.Format("{0:F2}", indentCreate.TotalAmount) : "N/A") + "</p></td>";
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
                return File(pdfBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Indent Request.pdf");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
