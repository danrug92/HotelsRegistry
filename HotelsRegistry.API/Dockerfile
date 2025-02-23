FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia i file di progetto e ripristina le dipendenze
COPY ["HotelsRegistry.API/HotelsRegistry.API.csproj", "HotelsRegistry.API/"]
COPY ["HotelsRegistry.Application/HotelsRegistry.Application.csproj", "HotelsRegistry.Application/"]
COPY ["HotelsRegistry.Domain/HotelsRegistry.Domain.csproj", "HotelsRegistry.Domain/"]
COPY ["HotelsRegistry.Infrastructure/HotelsRegistry.Infrastructure.csproj", "HotelsRegistry.Infrastructure/"]

RUN dotnet restore "HotelsRegistry.API/HotelsRegistry.API.csproj"

# Copia tutto e costruisci l'applicazione
COPY . .
WORKDIR "/src/HotelsRegistry.API"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]