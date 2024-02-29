using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface ISpoolBoxMapping
    {
        Task<List<SpoolBoxMapping>> GetAllSpoolBoxMappingDetails();
        Task<SpoolBoxMapping> InsertSpoolBoxMappingDetails(SpoolBoxMapping reqModel);
        Task<SpoolBoxMapping> GetSpoolCaseMappingById(SpoolBoxMapping reqModel);
        Task<SpoolBoxMapping> GetSpoolCaseMappingByBoxNumber(SpoolBoxMapping reqModel);
    }
}
