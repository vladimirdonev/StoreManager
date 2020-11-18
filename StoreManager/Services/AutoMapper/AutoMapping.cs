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
            CreateMap<Product, AllProductsViewModel>();
            CreateMap<EditProductViewModel, Product>();
                //.ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, EditProductViewModel>();
        }
    }
}
