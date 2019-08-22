FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SwaggerNSwag/SwaggerNSwag.csproj", "SwaggerNSwag/"]
RUN dotnet restore "SwaggerNSwag/SwaggerNSwag.csproj"
COPY . .
WORKDIR "/src/SwaggerNSwag"
RUN dotnet build "SwaggerNSwag.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SwaggerNSwag.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SwaggerNSwag.dll"]