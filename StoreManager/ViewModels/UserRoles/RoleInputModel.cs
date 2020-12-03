using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.UserRoles
{
    public class RoleInputModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
