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

        public virtual ICollection<UsersStore> UsersStore { get; set; }
    }
}
