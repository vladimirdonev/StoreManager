using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.Suppliers
{
    public class SupplierViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string AgentName { get; set; }

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
