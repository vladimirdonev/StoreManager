using System.ComponentModel.DataAnnotations;

namespace StoreManager.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductImg { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal),"0","150000")]
        public decimal Price { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
    }
}
