using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.DAL.Entities
{
    public class Salary
    {
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal? EmployeeSalary { get; set; }
    }
}
