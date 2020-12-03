using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels
{
    public class StoreInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
