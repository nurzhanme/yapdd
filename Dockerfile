FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["yapdd.api.csproj", "./"]
RUN dotnet restore "./yapdd.api.csproj"
COPY . .
RUN dotnet build "./yapdd.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./yapdd.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "yapdd.api.dll"]
