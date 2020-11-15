using AutoMapper;
using StoreManager.Models;
using StoreManager.ViewModels.Products;
using System.Collections.Generic;

namespace StoreManager.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<List<Product>, List<AllProductsViewModel>>();
        }
    }
}
