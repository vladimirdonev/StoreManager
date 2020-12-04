using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.Store
{
    public class StoreInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
