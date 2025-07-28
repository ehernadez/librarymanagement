FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copia los archivos de proyecto y la solución principal
COPY ["LibraryManagement.API/LibraryManagement.API.csproj", "LibraryManagement.API/"]
COPY ["LibraryManagement.Application/LibraryManagement.Application.csproj", "LibraryManagement.Application/"]
COPY ["LibraryManagement.Infraestructure/LibraryManagement.Infraestructure.csproj", "LibraryManagement.Infraestructure/"]
COPY ["LibraryManagement.Main/LibraryManagement.Main.csproj", "LibraryManagement.Main/"]
COPY ["LibraryManagement.Gateway/LibraryManagement.Gateway.csproj", "LibraryManagement.Gateway/"]

RUN dotnet restore "LibraryManagement.API/LibraryManagement.API.csproj"

# Copia el resto del código fuente
COPY . .

WORKDIR "/src/LibraryManagement.API"
RUN dotnet build "./LibraryManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LibraryManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryManagement.API.dll"]