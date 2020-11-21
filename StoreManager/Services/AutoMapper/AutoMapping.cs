using AutoMapper;
using StoreManager.Models;
using StoreManager.ViewModels.Products;
using StoreManager.ViewModels.Suppliers;
using System.Collections.Generic;

namespace StoreManager.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, AllProductsViewModel>();
            CreateMap<EditProductViewModel, Product>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, EditProductViewModel>();
            CreateMap<Supplier, AllSuppliersViewModel>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Supplier, SupplierEditViewModel>();
            CreateMap<SupplierEditViewModel, Supplier>();
        }
    }
}
