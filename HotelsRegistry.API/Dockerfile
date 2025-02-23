FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["HotelsRegistry.API/HotelsRegistry.API.csproj", "HotelsRegistry.API/"]
COPY ["HotelsRegistry.Application/HotelsRegistry.Application.csproj", "HotelsRegistry.Application/"]
COPY ["HotelsRegistry.Domain/HotelsRegistry.Domain.csproj", "HotelsRegistry.Domain/"]
COPY ["HotelsRegistry.Infrastructure/HotelsRegistry.Infrastructure.csproj", "HotelsRegistry.Infrastructure/"]

RUN dotnet restore "HotelsRegistry.API/HotelsRegistry.API.csproj"
COPY . .
WORKDIR "/src/HotelsRegistry.API"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src .
COPY entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh
ENTRYPOINT ["/bin/bash", "/app/entrypoint.sh"]
