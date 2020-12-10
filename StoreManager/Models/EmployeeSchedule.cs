using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class EmployeeSchedule
    {
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string EmployeeFullName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
