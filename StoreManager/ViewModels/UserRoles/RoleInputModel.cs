using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.UserRoles
{
    public class RoleInputModel
    {
        [Required]
        [MinLength(5)]
        public string RoleName { get; set; }
    }
}
