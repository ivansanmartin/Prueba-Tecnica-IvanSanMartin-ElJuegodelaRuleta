# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY backend.sln .
COPY src/backend.csproj src/
RUN dotnet restore backend.sln --source https://api.nuget.org/v3/index.json

# copy everything else and build app
COPY src/ src/
RUN dotnet publish src/backend.csproj -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "backend.dll"]