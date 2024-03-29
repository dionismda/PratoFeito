﻿namespace Customers.Api.Customers;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerInputModel, CreateCustomerCommand>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new PersonName(src.FirstName, src.LastName)))
            .ForMember(dest => dest.OrderLimit, opt => opt.MapFrom(src => new Money(src.Amount)));

        CreateMap<CreateCustomerCommand, CreateCustomerInputModel>()
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<CustomerInputModel, UpdateCustomerCommand>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new PersonName(src.FirstName, src.LastName)))
            .ForMember(dest => dest.OrderLimit, opt => opt.MapFrom(src => new Money(src.Amount)));

        CreateMap<UpdateCustomerCommand, UpdateCustomerInputModel>()
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<DeleteCustomerInputModel, DeleteCustomerOrderCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<Customer, CustomerViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.OrderLimit.Amount));

        CreateMap<GetCustomersInputModel, GetCustomersQuery>()
            .ReverseMap();

        CreateMap<GetCustomerByIdInputModel, GetCustomerByIdQuery>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<GetCustomerOrdersByCustomerIdInputModel, GetCustomerOrdersByCustomerIdQuery>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<GetCustomerOrdersByCustomerIdQueryModel, GetCustomerOrdersByCustomerIdViewModel>()
            .ForMember(dest => dest.OrderTotal, opt => opt.MapFrom(src => src.Order_Total));

        CreateMap<GetCustomerByIdQueryModel, CustomerViewModel>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Order_limit));

        CreateMap<GetCustomersQueryModel, CustomerViewModel>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Order_limit));
    }
}