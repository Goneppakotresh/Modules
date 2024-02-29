using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IIndentRequests
    {
        Task<IndentDetailsResponse> GetAllIndentRequestDetails(string userId, string userName);
        Task<IndentCreate> SaveIndentDetails(IndentCreate indentCreate);

        Task<IndentCreate> IndentRequestGetById(IndentCreate indentCreate);

    }
}
