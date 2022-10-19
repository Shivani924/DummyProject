using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyProject.Models
{
    public class UserLoan
    {
        [Key]
        public int UserLoanId { get; set; }
        public int Phone_No { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public Customer? Customer { get; set; }
        public int? LoanNo { get; set; }
        [ForeignKey("LoanNo")]
        public LoanDetail loanDetail { get; set; }
        public string LoanStatus { get; set; }

    }
}
