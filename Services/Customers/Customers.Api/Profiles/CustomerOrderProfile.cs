namespace PratoFeito_Customers.Api.Profiles;

public class CustomerOrderProfile : Profile
{
    public CustomerOrderProfile()
    {
        CreateMap<CreateCustomerOrderInputModel, CreateCustomerOrderCommand>()
            .ForMember(dest => dest.OrderTotal, opt => opt.MapFrom(src => new Money(src.OrderTotal)));

        CreateMap<CreateCustomerOrderCommand, CustomerOrder>();

        CreateMap<CustomerOrder, CustomerOrderViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId.Id))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.OrderTotal, opt => opt.MapFrom(src => src.OrderTotal.Amount));

        CreateMap<CustomerOrderDeliveredInputModel, DeliveredCustomerOrderCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<CustomerOrderCanceledInputModel, CanceledCustomerOrderCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
    }
}
