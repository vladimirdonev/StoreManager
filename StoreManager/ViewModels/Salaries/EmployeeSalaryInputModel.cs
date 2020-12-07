using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Salaries
{
    public class EmployeeSalaryInputModel
    {
        public string UserId { get; set; }

        [Required]
        [Range(typeof(decimal),"0","1000000")]
        public decimal Salary { get; set; }
    }
}
