using Microsoft.AspNetCore.Identity;

namespace StoreManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImg { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
