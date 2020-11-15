namespace StoreManager.ViewModels.Products
{
    public class CreateProductViewModel
    {
        public string ProductImg { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
