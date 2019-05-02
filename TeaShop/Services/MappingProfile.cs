using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;
using TeaShop.Data.ViewModels.AccountViewModels;
using TeaShop.Data.ViewModels.AdminViewModels;
using TeaShop.Data.ViewModels.CartViewModels;
using TeaShop.Data.ViewModels.ManageViewModels;
using TeaShop.Data.ViewModels.OrderViewModels;
using TeaShop.Data.ViewModels.TeaViewModels;

namespace TeaShop.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tea, TeaViewModel>();
            CreateMap<Tea, DetailsViewModel>().ReverseMap();
            CreateMap<OrderViewModel, Order>();
            CreateMap<Customer, OrderViewModel>().ReverseMap();
            CreateMap<Order, CustomerOrdersViewModel>();
            CreateMap<Order, CustomerOrderDetailsViewModel>();
            CreateMap<Order, OrderListViewModel>();
            CreateMap<Order, OrderDetailsViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, Customer>();
            CreateMap<Customer, ChangeDataViewModel>().ReverseMap();
            CreateMap<OrderTea, CartLineViewModel>()
                .ForMember(dest => dest.CartLineSum, opt => opt.MapFrom(x => x.Tea.Price * x.Quantity));
        }
    }
}
