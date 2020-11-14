using Microsoft.AspNetCore.Mvc;
using StoreManager.ViewModels.Products;
using StoreManager.Services.Products;

namespace StoreManager.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService productsServise;

        public ProductsController(IProductsService productsServise)
        {
            this.productsServise = productsServise;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductViewModel createProduct)
        {
            this.productsServise.CreateProduct(createProduct);
            return this.Redirect("/Products/All");
        }

        public IActionResult AllProducts()
        {
            return this.View(productsServise.AllProducts());
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var Product = this.productsServise.Details(id);
            return this.View(Product);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel product)
        {

            this.productsServise.Edit(product);
            return this.Redirect("/Products/All");
            
        }
    }
}
