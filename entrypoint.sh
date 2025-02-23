#!/bin/bash
set -e

echo "Attendo che il database sia pronto..."
sleep 20  # Attendi che SQL Server sia avviato

echo "Test di connessione al database con .NET..."
until dotnet ef dbcontext info --project HotelsRegistry.Infrastructure --startup-project HotelsRegistry.API; do
  echo "Database non ancora pronto, attendo..."
  sleep 5
done

echo "Eseguo le migrazioni..."
dotnet ef database update --project HotelsRegistry.Infrastructure --startup-project HotelsRegistry.API -- --verbose

echo "Avvio l'API..."
exec dotnet HotelsRegistry.API.dll