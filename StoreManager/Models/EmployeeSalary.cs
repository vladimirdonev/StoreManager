using System.ComponentModel.DataAnnotations.Schema;


namespace StoreManager.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public decimal Salary { get; set; }
    }
}
