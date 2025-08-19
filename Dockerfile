# Stage 1 - Build w/ SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Dotnet restore
COPY ["CentralAPI.sln", "."]
COPY ["Application/Application.csproj", "Application/"]
COPY ["CentralAPI/CentralAPI.csproj", "CentralAPI/"]
COPY ["Core/Domain.csproj", "Core/"]
COPY ["Crypto/Crypto.csproj", "Crypto/"]
COPY ["DeployAutomatico/DeployAutomatico.csproj", "DeployAutomatico/"]
COPY ["Libs/Libs.csproj", "Libs/"]
COPY ["Repository/Infrastructure.csproj", "Repository/"]
COPY ["Service/Service.csproj", "Service/"]
RUN dotnet restore "CentralAPI.sln"

# Font code
COPY . .
WORKDIR "/src/Unifertil_API_Central"

# Publish api
RUN dotnet publish "Unifertil_API_Central.csproj" -c Release -o /app/publish --no-restore

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Expose API port
EXPOSE 5010

# Copy published files for the final image
COPY --from=build /app/publish .

# Define the command that will be executed when the container starts.
ENTRYPOINT ["dotnet", "CentralAPI.dll"]
