using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.Store
{
    public class StoreInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
