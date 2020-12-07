using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImg { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("UsersStores")]
        public int UsersStores { get; set; }

        public virtual UsersStore UsersStore { get; set; }

        public virtual Salary EmployeeSalary { get; set; }
    }
}
