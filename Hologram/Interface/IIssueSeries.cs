using IEMS_WEB.Areas.Hologram.Models.RequestModel;

namespace IEMS_WEB.Areas.Hologram.Interface
{
    public interface IIssueSeries
    {
        Task<IssueSeriesResponse> GetAllIssueSeriesListDetails();
        Task<IssueSeriesResponse> SaveIssueSeriesDetails(IssueSeries issueSeries);
        Task<IssueSeries> IssueSeriesById(int SeriesId);
        Task<IssueSeries> IssueSeriesFromNo();
    }
}
