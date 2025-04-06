# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY backend.sln .
COPY src/backend.csproj ./
COPY src/appsettings.json ./
RUN dotnet restore --source https://api.nuget.org/v3/index.json

# copy everything else and build app
COPY src/ src/
RUN dotnet publish backend.csproj -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "backend.dll"]