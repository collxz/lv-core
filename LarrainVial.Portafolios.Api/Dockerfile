FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["LarrainVial.Portafolios.Api/LarrainVial.Portafolios.Api.csproj", "LarrainVial.Portafolios.Api/"]
RUN dotnet restore "LarrainVial.Portafolios.Api/LarrainVial.Portafolios.Api.csproj"

COPY . .
WORKDIR "/src/LarrainVial.Portafolios.Api"
RUN dotnet build "LarrainVial.Portafolios.Api.csproj" -c Release -o /app/publish

# ETAPA 2. EJECUCION
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LarrainVial.Portafolios.Api.dll"]