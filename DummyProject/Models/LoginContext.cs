using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace DummyProject.Models
{
    public class LoginContext:DbContext
    {
        public LoginContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserLoan> UserLoans { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasData(
                new Login
                {
                    Username = "user123",
                    Password = "abcd",
                    Role = "user"
                },
                new Login
                {
                Username = "Admin123",
                    Password = "abcde",
                    Role = "admin"
                }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 101,
                    First_Name = "Shivi",
                    Last_Name = "Vani",
                    Address = "India",
                    Phone_No = 999,
                    UserName = "user123"
                });
            modelBuilder.Entity<UserLoan>().HasData(
                new UserLoan
                {
                    UserLoanId = 001,
                    Phone_No = 000000,
                    UserId = 101,
                    LoanNo = 45,
                    LoanStatus = "Pending"
                });
            modelBuilder.Entity<LoanDetail>().HasData(
                new LoanDetail
                {
                    LoanId = 45,
                    Amount = 30000,
                    Admin_UserName = "Admin123",
                    LoanType = "Home Loan",
                });
        }
        }
}
