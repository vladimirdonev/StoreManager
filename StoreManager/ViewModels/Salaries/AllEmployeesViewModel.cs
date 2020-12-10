using StoreManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Salaries
{
    public class AllEmployeesViewModel
    {

        public string UserId { get; set; }

        public string FullName { get; set; }

        public string ProfileImage { get; set; }

        public decimal? Salary { get; set; }

    }
}
