using IEMS_WEB.Areas.Hologram.Interface;
using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NReco.PdfGenerator;

namespace IEMS_WEB.Areas.Hologram.Controllers
{
    [Area("Hologram")]
    public class ProductionDispatchController : Controller
    {
        private readonly IProductionDispatch _productionDispatch;
        public ProductionDispatchController(IProductionDispatch productionDispatch)
        {
            _productionDispatch = productionDispatch;
        }

        /// <summary>
        /// Get method for Production dispatch.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductionDispatchView()
        {
            return View();
        }

        /// <summary>
        /// Fetch all ProductionDispatch Details.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetAllProductionDispatchDetails()
        {
            ProductionDispatchResponse obj = new ProductionDispatchResponse();
            //dynamic jsonResult = "";
            obj.List = await _productionDispatch.GetAllProductionDispatchDetails();
            //jsonResult = Json(new { data = obj.List });
            //jsonResult.MaxJsonLength = int.MaxValue;

            return Json(new { data = obj.List });
        }

        /// <summary>
        /// Get method for Production dispatch .
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ProductionDispatch()
        {
            ProductionDispatch objDetails = new ProductionDispatch();
            objDetails.DispatchTransactionDetails.Add(new ProductionDispatchDetails());
            if (TempData["REQID"] != null)
            {
                if (TempData["Status"].ToString() == "E") 
                {
                    ProductionDispatchResponseDetails ObjRes = new ProductionDispatchResponseDetails();
                    int ReqId = Convert.ToInt32(TempData["REQID"]);                    
                    ObjRes = await _productionDispatch.GetProductionDispatchDetailsById(ReqId);
                    objDetails.InvoiceNumber = ObjRes.RequestNumber;
                    objDetails.InvoiceDate = ObjRes.RequestDate;
                    objDetails.DispatchedBy = Convert.ToString(ObjRes.CreatedBy);
                    objDetails.DispatchQuantity = ObjRes.CaseQuantity;
                    objDetails.ApprovedQty = Convert.ToInt32(ObjRes.RequestLabelQuantity);
                    objDetails.IndentId = Convert.ToUInt32(ObjRes.HologramIndentId);
                }
                else
                {
                    ProductionDispatchModelbinding obj = new ProductionDispatchModelbinding();
                    obj = await _productionDispatch.GetProductionDispatchViewById(Convert.ToInt32(TempData.Peek("REQID")));
                    objDetails.InvoiceNumber = obj.RequestNumber;
                    objDetails.InvoiceDate = obj.RequestDate;
                    objDetails.DispatchedBy = Convert.ToString(obj.CreatedBy);
                    objDetails.DispatchQuantity = obj.CaseQuantity;
                    objDetails.ApprovedQty = Convert.ToInt32(obj.RequestLabelQuantity);
                    objDetails.IndentId = Convert.ToUInt32(obj.HologramIndentId);
                    objDetails.DispatchNumber = obj.DispatchTransactionDetails[0].DispatchNumber;
                    objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
                    objDetails.CreatedBy = Convert.ToInt32((obj.DispatchTransactionDetails[0].DispatchedBy));
                    objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
                    objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
                    objDetails.HandoverTo = obj.DispatchTransactionDetails[0].HandoverTo;
                    objDetails.VechileNumber = obj.DispatchTransactionDetails[0].VechileNumber;
                    objDetails.ViewStatus = Convert.ToString(TempData.Peek("Status"));
                    // for casenumber list

                    objDetails.DispatchTransactionDetails = new List<ProductionDispatchDetails>();
                    foreach (var dispatchBinding in obj.DispatchTransactionDetails)
                    {
                        ProductionDispatchDetails details = new ProductionDispatchDetails();


                        foreach (var dispatchDetail in dispatchBinding.DispatchDetails)
                        {
                            
                            objDetails.DispatchTransactionDetails.Add(new ProductionDispatchDetails
                            {
                                CaseNumber = dispatchDetail.CaseNumber,                             
                            });
                        }
                    }

                }
                objDetails.SpoolCaseMappingandDetails.Add(new SpoolModel());
                objDetails.SpoolCaseMappingandDetails.Add(new SpoolModel());
                objDetails.SpoolCaseMappingandDetails.Add(new SpoolModel());
                TempData.Remove("Status");
                TempData.Remove("REQID");
                
            }
            return View(objDetails);
        }


        [HttpPost]
        public async Task<ActionResult> ProductionDispatch(ProductionDispatch model)
        {
            ProductionDispatchResponse obj = new ProductionDispatchResponse();
            ProductionDispatch reqmodel = new ProductionDispatch();
            model.userId = User.Identity.GetUserId();
            model.userName = User.Identity.GetUserName();
            obj = await _productionDispatch.InsertProductionDispatchDetails(model);
            reqmodel.ResponseCode = obj.Status;
            return View(reqmodel);
        }

        /// <summary>
        /// Submit method for Production dispatch details.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ProductionDispatchView(ProductionDispatch obj)
        {
            ProductionDispatchResponse objRes = new ProductionDispatchResponse();
            obj.userId = User.Identity.GetUserId();
            obj.userName = User.Identity.GetUserName();
            objRes = await _productionDispatch.SubmitProductionDispatchDetails(obj);

            return View(obj);
        }

        /// <summary>
        /// Edit method for indent details.
        /// </summary>
        /// <param name="ReqId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetProductionDispatchEditDetail(int ReqId, string StatusValue)
        {

            shopCreationRequest objShopDetails = new shopCreationRequest();
            TempData["REQID"] = ReqId;
            TempData["Status"] = StatusValue;
            return Json(objShopDetails);
        }

        public async Task<ActionResult> GetProductionDispatchViewDetail(int ReqId,string StatusValue)
        {
            ProductionDispatch objDetails = new ProductionDispatch();
            TempData["REQID"] = ReqId;
            TempData["Status"] = StatusValue;
            return Json(objDetails);
        }

        public async Task<ActionResult> ProductionDispatchInvoicePrint(int indentId)
        {
            ProductionDispatch objDetails = new ProductionDispatch();
            ProductionDispatchModelbinding obj = new ProductionDispatchModelbinding();
            obj = await _productionDispatch.GetProductionDispatchViewById(indentId);
            objDetails.InvoiceNumber = obj.RequestNumber;
            objDetails.InvoiceDate = obj.RequestDate;
            objDetails.DispatchedBy = Convert.ToString(obj.CreatedBy);
            objDetails.DispatchQuantity = obj.CaseQuantity;
            objDetails.ApprovedQty = Convert.ToInt32(obj.RequestLabelQuantity);
            objDetails.IndentId = Convert.ToUInt32(obj.HologramIndentId);
            objDetails.DispatchNumber = obj.DispatchTransactionDetails[0].DispatchNumber;
            objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
            objDetails.CreatedBy = Convert.ToInt32((obj.DispatchTransactionDetails[0].DispatchedBy));
            objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
            objDetails.CreatedOn = obj.DispatchTransactionDetails[0].DispatchDate;
            objDetails.HandoverTo = obj.DispatchTransactionDetails[0].HandoverTo;
            objDetails.VechileNumber = obj.DispatchTransactionDetails[0].VechileNumber;
            objDetails.ViewStatus = Convert.ToString(TempData.Peek("Status"));
            // for casenumber list

            objDetails.DispatchTransactionDetails = new List<ProductionDispatchDetails>();
            foreach (var dispatchBinding in obj.DispatchTransactionDetails)
            {
                ProductionDispatchDetails details = new ProductionDispatchDetails();


                foreach (var dispatchDetail in dispatchBinding.DispatchDetails)
                {

                    objDetails.DispatchTransactionDetails.Add(new ProductionDispatchDetails
                    {
                        CaseNumber = dispatchDetail.CaseNumber,
                    });
                }
            }
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

                strHTML += "<div style='text-align: center;'><h2 style='font-weight: bold; padding: 1px 0;'>Delivery Challan of QR Coded Holograms</h2></div>";
                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Delivery Date: " + string.Format("{0:dd-MMM-yyyy}", objDetails.InvoiceDate) + " </td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Delivery ChallanNo.: " + objDetails.DispatchNumber + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Delivered by: " + objDetails.DispatchedBy + "</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>Delivered to.: " + objDetails.HandoverTo + "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";

                strHTML += "<br>";

                strHTML += "<table style='width:90%; border-collapse: collapse; margin: auto;'>";
                strHTML += "<tr>";
                strHTML += "<td colspan='4' style='border: 1px solid #333; padding: 8px; text-align:center'>Details of Holograms to be Delivered</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>SL.No</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>No. of Boxes</th>";
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>No. of Spools </th>"; // Fix: Added closing tag </th>
                strHTML += "<th style='border: 1px solid #333; padding: 8px;'>Total Quantity of Holograms</th>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'>1.</td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p> " + objDetails.DispatchTransactionDetails.Count() + "</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p> 3000</p></td>";
                strHTML += "<td style='border: 1px solid #333; padding: 8px;'><p>" + (objDetails.DispatchTransactionDetails.Count()*3000 != null ? string.Format("{0:F2}", objDetails.DispatchTransactionDetails.Count() * 3000) : "N/A") + "</p></td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "<div style='text-align: center;'><h5 style='font-weight: bold; padding: 1px 0;'>Note: Detail of Boxes & Spools is enclosed herewith.\r\n</h5></div>";
                strHTML += "<br>";


                //< !-- Signature Text -->
                strHTML += "<div style='margin-top: 10px; text-align: right; padding: 50px;'><h5>(Name ofSignature of OIC of M/s UflexLTD)</h5></div>";

                strHTML += "</body>";
                strHTML += "</html>";

                var htmlContent = String.Format(strHTML, DateTime.Now);
                var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(htmlContent);
                return File(pdfBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Dispatch Invoice.pdf");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
