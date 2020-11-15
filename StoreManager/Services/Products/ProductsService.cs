using AutoMapper;
using StoreManager.Data;
using StoreManager.Models;
using StoreManager.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Services.Products
{
    public class ProductsService : IProductsService
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public ProductsService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ICollection<AllProductsViewModel> AllProducts()
        {
            List<AllProductsViewModel> Products = this.mapper.Map<List<Product>,List<AllProductsViewModel>>(this.db.Products.ToList());
            return Products;
        }

        public void CreateProduct(CreateProductViewModel createProduct)
        {
            var Product = this.mapper.Map<CreateProductViewModel,Product>(createProduct);
            this.db.Products.Add(Product);
            this.db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var Product = this.db.Products.FirstOrDefault(x => x.Id == id);
            this.db.Products.Remove(Product);
            this.db.SaveChanges();
        }

        public ProductViewModel Details(int id)
        {
            var Product = this.db.Products.FirstOrDefault(x => x.Id == id);
            return this.mapper.Map<Product,ProductViewModel>(Product);
        }

        public void Edit(EditProductViewModel product)
        {
            var Product = this.db.Products.First(x => x.Id == product.Id);
            Product = this.mapper.Map<EditProductViewModel,Product>(product);
            this.db.Update(Product);
            this.db.SaveChanges();
        }
    }
}
