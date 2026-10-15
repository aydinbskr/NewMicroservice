# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/order/NewMicroservice.Order.Api/NewMicroservice.Order.Api.csproj", "src/services/order/NewMicroservice.Order.Api/"]
COPY ["src/services/order/NewMicroservice.Order.Application/NewMicroservice.Order.Application.csproj", "src/services/order/NewMicroservice.Order.Application/"]
COPY ["src/services/shared/NewMicroservice.Bus/NewMicroservice.Bus.csproj", "src/services/shared/NewMicroservice.Bus/"]
COPY ["src/services/order/NewMicroservice.Order.Domain/NewMicroservice.Order.Domain.csproj", "src/services/order/NewMicroservice.Order.Domain/"]
COPY ["src/services/shared/NewMicroservice.Shared/NewMicroservice.Shared.csproj", "src/services/shared/NewMicroservice.Shared/"]
COPY ["src/services/order/NewMicroservice.Order.Persistence/NewMicroservice.Order.Persistence.csproj", "src/services/order/NewMicroservice.Order.Persistence/"]
RUN dotnet restore "./src/services/order/NewMicroservice.Order.Api/NewMicroservice.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/services/order/NewMicroservice.Order.Api"
RUN dotnet build "./NewMicroservice.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewMicroservice.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewMicroservice.Order.Api.dll"]