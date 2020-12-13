using Microsoft.AspNetCore.Mvc;
using StoreManager.ViewModels.Products;
using StoreManager.Services.Products;
using Microsoft.AspNetCore.Authorization;

namespace StoreManager.Controllers
{
    [Authorize]
    [Authorize(Roles = "Owner,Employee")]
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

        
        public IActionResult All()
        {
            return this.View(productsServise.AllProducts());
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var Product = this.productsServise.GetById(id);
            return this.View(Product);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel product)
        {

            this.productsServise.Edit(product);
            return this.Redirect("/Products/All");
            
        }
        
        public IActionResult Details(int id)
        {
            return this.View(this.productsServise.Details(id));
        }

        public IActionResult Delete(int id)
        {
            this.productsServise.DeleteProduct(id);
            return this.Redirect("/Products/All");
        }
    }
}
