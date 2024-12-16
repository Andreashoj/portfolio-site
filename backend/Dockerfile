# Development stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

# Production stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /app
COPY --from=build /app .
# Replace 'backend.dll' with your actual DLL name
ENTRYPOINT ["dotnet", "backend.dll"]