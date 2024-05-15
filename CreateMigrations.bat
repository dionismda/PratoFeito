set Amazon:Credentials:ServiceUrl=http://localhost:4566
dotnet ef migrations add %1 -p Services\Monolith -s Services\Monolith --context CustomersContext
dotnet ef migrations add %1 -p Services\Monolith -s Services\Monolith --context RestaurantContext
