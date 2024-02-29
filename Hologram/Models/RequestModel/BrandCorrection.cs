using IEMS_WEB.Areas.Hologram.Models.ResponseModel;

namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class BrandCorrection : BrandCorrectionViewDetails
    {
        public string RequestNumber { get; set; }
        public string RequestDate { get; set; }
        public string OldBrand { get; set; }
        public string NewBrand { get; set; }
        public string OldPack { get; set; }
        public string NewPack { get; set; }
        public int Status { get; set; }

    }
}
