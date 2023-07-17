#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Services/Customers/Customers.Api/Customers.Api.csproj", "Services/Customers/Customers.Api/"]
COPY ["Services/_Architecture/_Architecture.Api/_Architecture.Api.csproj", "Services/_Architecture/_Architecture.Api/"]
COPY ["Services/_Architecture/_Architecture.Application/_Architecture.Application.csproj", "Services/_Architecture/_Architecture.Application/"]
COPY ["Services/_Architecture/_Architecture.Domain/_Architecture.Domain.csproj", "Services/_Architecture/_Architecture.Domain/"]
COPY ["Services/_Architecture/_Architecture.Infrastructure/_Architecture.Infrastructure.csproj", "Services/_Architecture/_Architecture.Infrastructure/"]
COPY ["Services/Customers/Customers.Application/Customers.Application.csproj", "Services/Customers/Customers.Application/"]
COPY ["Services/Customers/Customers.Infrastructure/Customers.Infrastructure.csproj", "Services/Customers/Customers.Infrastructure/"]
COPY ["Services/Customers/Customers.Domain/Customers.Domain.csproj", "Services/Customers/Customers.Domain/"]
RUN dotnet restore "Services/Customers/Customers.Api/Customers.Api.csproj"
COPY . .
WORKDIR "/src/Services/Customers/Customers.Api"
RUN dotnet build "Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Api.dll"]