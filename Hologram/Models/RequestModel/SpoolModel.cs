namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class SpoolModel
    {
        public int SpoolCaseMappingDetailsId { get; set; }
        public int SpoolCaseMappingId { get; set; }
        public string SpoolFirstNumber { get; set; }
        public string SpoolNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string Remark { get; set; } = "";
    }
}
