set Amazon:Credentials:ServiceUrl=http://localhost:4566
dotnet ef migrations add %1 --context CustomersContext
dotnet ef migrations add %1 --context RestaurantContext
