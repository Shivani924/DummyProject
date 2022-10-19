using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyProject.Models
{
    public class LoanDetail
    {
        [Key]
        public int LoanId { get; set; }
        public float Amount { get; set; }
        //public DateOnly IssueDate { get; set; }
       // public DateOnly ApprovalDate { get; set; }
        public string Admin_UserName { get; set; }
        [ForeignKey("Admin_UserName")]
        public Login login { get; set; }
        public string LoanType { get; set; }
       // public int? User_Id { get; set; }
        
    }
}
