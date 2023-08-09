namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public sealed class GetRestaurantByIdQuery : IQuery<GetRestaurantByIdQueryModel>
{
    public Identifier Id { get; private set; } = null!;

    private GetRestaurantByIdQuery() { }

    public GetRestaurantByIdQuery(Identifier id) : this()
    {
        Id = id;
    }
}