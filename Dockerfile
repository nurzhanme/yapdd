FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY netcoreapp3.1/*.csproj ./netcoreapp3.1/
RUN dotnet restore

# copy everything else and build app
COPY netcoreapp3.1/. ./netcoreapp3.1/
WORKDIR /app/netcoreapp3.1
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/netcoreapp3.1/out ./
ENTRYPOINT ["dotnet", "netcoreapp3.1.dll"]