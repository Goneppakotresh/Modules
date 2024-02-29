using IEMS_WEB.Areas.Hologram.Models.RequestModel;
using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface ISpoolBoxLabelPrint
    {
        Task<SpoolBoxLabelPrintResponse> GetAllSpoolBoxLabelPrintDetails();
        Task<SpoolBoxLabelPrint> InsertSpoolBoxLabelPrintDetails(SpoolBoxLabelPrint reqModel);

    }
}
