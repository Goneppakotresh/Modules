using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IBrandCorrection
    {
        Task<BrandCorrectionResponse> GetAllBrandCorrectionListDetails();
    }
}
