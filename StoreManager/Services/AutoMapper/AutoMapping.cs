using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreManager.DAL.Entities;
using StoreManager.ViewModels.Products;
using StoreManager.ViewModels.Salaries;
using StoreManager.ViewModels.Store;
using StoreManager.ViewModels.Suppliers;
using StoreManager.ViewModels.UserRoles;

namespace StoreManager.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateProductViewModel, Product>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, AllProductsViewModel>();
            CreateMap<EditProductViewModel, Product>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, EditProductViewModel>();
            CreateMap<Supplier, AllSuppliersViewModel>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Supplier, SupplierEditViewModel>();
            CreateMap<SupplierEditViewModel, Supplier>();
            CreateMap<StoreInputModel, Store>();
            CreateMap<IdentityRole, AllRolesViewModel>()
                .ForMember(x => x.RoleId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(x => x.Name));
            CreateMap<Store, AllStoresViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
            CreateMap<Store, EditStoreViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Users, opt => opt.Ignore());
            CreateMap<EmployeeSalaryInputModel, Salary>()
                .ForMember(x => x.EmployeeSalary, opt => opt.MapFrom(x => x.Salary));
            CreateMap<Salary, EmployeeSalaryInputModel>()
                .ForMember(x => x.Salary, opt => opt.MapFrom(x => x.EmployeeSalary))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId));
                
            

        }
    }
}
