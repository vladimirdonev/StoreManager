using StoreManager.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace StoreManager.Services.Products
{
    public interface IProductsService
    {
        void CreateProduct(CreateProductViewModel createProduct);

        void DeleteProduct(int id);

        EditProductViewModel GetById(int Id);

        void Edit(EditProductViewModel product);

        ProductViewModel Details(int id);  

        ICollection<AllProductsViewModel> AllProducts();
    }
}
