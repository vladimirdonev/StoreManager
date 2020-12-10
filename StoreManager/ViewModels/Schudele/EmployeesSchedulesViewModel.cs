using StoreManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Schudele
{
    public class EmployeesSchedulesViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string EmployeeFullName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
