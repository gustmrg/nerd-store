FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/NSE.ShoppingCart.API/NSE.ShoppingCart.API.csproj", "src/services/NSE.ShoppingCart.API/"]
RUN dotnet restore "src/services/NSE.ShoppingCart.API/NSE.ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/src/services/NSE.ShoppingCart.API"
RUN dotnet build "NSE.ShoppingCart.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NSE.ShoppingCart.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.ShoppingCart.API.dll"]
