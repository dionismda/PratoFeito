#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Services/Monolith/Monolith.csproj", "Services/Monolith/"]
COPY ["Services/Customers/Customers.Api/Customers.Api.csproj", "Services/Customers/Customers.Api/"]
COPY ["Services/_Architecture/_Architecture.Api/_Architecture.Api.csproj", "Services/_Architecture/_Architecture.Api/"]
COPY ["Services/_Architecture/_Architecture.Application/_Architecture.Application.csproj", "Services/_Architecture/_Architecture.Application/"]
COPY ["BuildingBlocks/EventBus/EventBus/EventBus.csproj", "BuildingBlocks/EventBus/EventBus/"]
COPY ["Services/_Architecture/_Architecture.Domain/_Architecture.Domain.csproj", "Services/_Architecture/_Architecture.Domain/"]
COPY ["BuildingBlocks/Loggings/SerilogServices/SerilogServices.csproj", "BuildingBlocks/Loggings/SerilogServices/"]
COPY ["Services/_Architecture/_Architecture.Infrastructure/_Architecture.Infrastructure.csproj", "Services/_Architecture/_Architecture.Infrastructure/"]
COPY ["BuildingBlocks/AwsServices/EventBusAws/EventBusAws.csproj", "BuildingBlocks/AwsServices/EventBusAws/"]
COPY ["BuildingBlocks/AwsServices/AwsConfiguration/AwsConfiguration.csproj", "BuildingBlocks/AwsServices/AwsConfiguration/"]
COPY ["Services/Customers/Customers.Application/Customers.Application.csproj", "Services/Customers/Customers.Application/"]
COPY ["Services/Customers/Customers.Infrastructure/Customers.Infrastructure.csproj", "Services/Customers/Customers.Infrastructure/"]
COPY ["Services/Customers/Customers.Domain/Customers.Domain.csproj", "Services/Customers/Customers.Domain/"]
COPY ["Services/Ordering/Ordering.Api/Ordering.Api.csproj", "Services/Ordering/Ordering.Api/"]
COPY ["Services/Ordering/Ordering.Application/Ordering.Application.csproj", "Services/Ordering/Ordering.Application/"]
COPY ["Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Services/Ordering/Ordering.Infrastructure/"]
COPY ["Services/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Services/Ordering/Ordering.Domain/"]
COPY ["Services/Restaurants/Restaurants.Api/Restaurants.Api.csproj", "Services/Restaurants/Restaurants.Api/"]
COPY ["Services/Restaurants/Restaurants.Application/Restaurants.Application.csproj", "Services/Restaurants/Restaurants.Application/"]
COPY ["Services/Restaurants/Restaurants.Infrastructure/Restaurants.Infrastructure.csproj", "Services/Restaurants/Restaurants.Infrastructure/"]
COPY ["Services/Restaurants/Restaurants.Domain/Restaurants.Domain.csproj", "Services/Restaurants/Restaurants.Domain/"]
RUN dotnet restore "Services/Monolith/Monolith.csproj"
COPY . .
WORKDIR "/src/Services/Monolith"
RUN dotnet build "Monolith.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monolith.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monolith.dll"]