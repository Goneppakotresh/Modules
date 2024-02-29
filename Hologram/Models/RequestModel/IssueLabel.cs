using IEMS_WEB.Models;


namespace IEMS_WEB.Areas.Hologram.Models.RequestModel
{
    public class IssueLabel:BaseModel
    {
        public int IssueId { get; set; }
        public DateTime issueDate { get; set; }
        public string issueNumber { get; set; }
        public string BoxDetails { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }
        public IssueLabel()
        {
            //List = new List<TableDetails>();
            issueLabelDetails = new List<TableDetails>();
        }
        //public List<TableDetails> List { get; set; }
        //public List<IssueLabelResponseDetails> ListDetails { get; set; }
        public List<TableDetails> IssueLabelList { get; set; }
        public int ResponseCode { get; set; }
        public List<TableDetails> issueLabelDetails { get; set; }

    }

    //public class IssueLabelResponse
    //{
    //    public IssueLabelResponse()
    //    {
    //        List=new List<IssueLabel>();
    //    }
    //    public List<IssueLabel> List { get; set; }
    //}

    //public class IssueLabelTableResponse
    //{
    //    public IssueLabelTableResponse()
    //    {
    //        TableList = new List<TableDetails>();
    //    }
    //    public List<TableDetails> TableList { get; set; }
    //}

    public class TableDetails
    {
        public int Slno { get; set; }
        public string CaseNumber { get; set; }
    }


    public class IssueLabelResponseDetails
    {
        public int IssueId { get; set; }
        public string IssueNumber { get; set; }
        public string IssueDate { get; set; }
    }

}