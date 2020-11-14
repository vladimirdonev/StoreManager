using StoreManager.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace StoreManager.Services.Products
{
    public interface IProductsService
    {
        void CreateProduct(CreateProductViewModel createProduct);

        void DeleteProduct(int id);

        void Edit(EditProductViewModel product);

        ProductViewModel Details(int id);  

        ICollection<AllProductsViewModel> AllProducts();
    }
}
