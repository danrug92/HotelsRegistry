#!/bin/bash
set -e

echo "Attendo che il database sia pronto..."
sleep 20  # Aumentato per maggiore affidabilit�

echo "Test di connessione al database con .NET..."
until dotnet ef dbcontext info --project /app/HotelsRegistry.Infrastructure/HotelsRegistry.Infrastructure.csproj --startup-project /app/HotelsRegistry.API/HotelsRegistry.API.csproj; do
  echo "Database non ancora pronto, attendo..."
  sleep 10  # Pi� attese se necessario
done

echo "Eseguo le migrazioni..."
dotnet ef database update --project /app/HotelsRegistry.Infrastructure/HotelsRegistry.Infrastructure.csproj --startup-project /app/HotelsRegistry.API/HotelsRegistry.API.csproj -- --verbose

echo "Avvio l'API..."
exec dotnet HotelsRegistry.API.dll
