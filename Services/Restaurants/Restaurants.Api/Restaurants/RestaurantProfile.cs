namespace Restaurants.Api.Restaurants;

public sealed class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantInputModel, CreateRestaurantCommand>();

        CreateMap<CreateRestaurantCommand, CreateRestaurantInputModel>()
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<Restaurant, RestaurantViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
    }
}
