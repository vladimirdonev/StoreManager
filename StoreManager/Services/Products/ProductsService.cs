using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var Products = this.db.Products.ToList();
            var ProductsToView = new List<AllProductsViewModel>();
            foreach (var product in Products)
            {

                ProductsToView.Add(this.mapper.Map<Product,AllProductsViewModel>(product));
            }
            return ProductsToView;
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
            this.db.Entry(Product).State = EntityState.Detached;
            Product = this.mapper.Map<EditProductViewModel,Product>(product);
            this.db.Update(Product);
            this.db.SaveChanges();
        }

        public EditProductViewModel GetById(int Id)
        {
            var Product = this.mapper.Map<Product,EditProductViewModel>(this.db.Products.FirstOrDefault(x => x.Id == Id));
            return Product;
        }
    }
}
