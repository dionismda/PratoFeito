set Amazon:Credentials:ServiceUrl=http://localhost:4566
dotnet ef database update -p Services\Monolith -s Services\Monolith --context CustomersContext
dotnet ef database update -p Services\Monolith -s Services\Monolith --context RestaurantContext