using IEMS_WEB.Areas.Hologram.Models.RequestModel;


namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IIssueDetails
    {
        Task<List<IssueLabelResponseDetails>> GetAllIssueDetails();
        Task<IssueLabel> InsertIssueLabelDetails(IssueLabel reqModel);
        Task<IssueLabel> GetIssueDetailsById(int Id);

    }
}
