# HotelsRegistry

## Documentazione Web API per la gestione dell'anagrafica di un Hotel

### Descrizione del Progetto

Questa Web API, sviluppata in **.NET Core 8**, consente la gestione dell'anagrafica di un hotel, comprese le tipologie di stanze e il preziario. Il progetto segue i principi della **Clean Architecture** ed è suddiviso nei seguenti layer:

- **Domain**: Contiene le entità e le astrazioni.
- **Infrastructure**: Implementa i repository per l'accesso al database tramite Entity Framework Core.
- **Application**: Gestisce la logica applicativa e utilizza CQRS con MediatR per la comunicazione tra API e database.
- **API**: Espone gli endpoint per interagire con il sistema.

### Requisiti Funzionali

L'applicazione permette:

- L'ottenimento, la creazione, la modifica e la cancellazione dei dati degli hotel (**Accommodation**).
- L'ottenimento, la creazione, la modifica e la cancellazione delle tipologie di stanze (**RoomType**).
- L'ottenimento, la creazione, la modifica e la cancellazione dei prezzi delle stanze (**Pricing**).
- L'ottenimento, la creazione, la modifica e la cancellazione delle gerarchie delle stanze (**RoomHierarchy**).
- L'ottenimento, la creazione, la modifica e la cancellazione delle stanze (**Room**).
- La gestione dei prezzi delle stanze con una gerarchia che impone vincoli tra le tipologie di stanza (es. il prezzo di una **Deluxe** deve essere almeno il **30% superiore** rispetto alla stanza base).

## Struttura del Database

Il database è strutturato con cinque entità principali:

- **Accommodation**: Rappresenta gli hotel.
- **Room**: Contiene le stanze associate a un hotel.
- **RoomType**: Definisce le tipologie di stanze (es. Standard, Deluxe) con livelli gerarchici.
- **RoomHierarchy**: Definisce le relazioni gerarchiche tra le tipologie di stanze.
- **Pricing**: Assegna i prezzi alle tipologie di stanze, rispettando la gerarchia definita.

### Esempio di Gerarchia dei Prezzi

#### Hotel Roma

- **RoomType 1**: Standard
- **RoomType 2**: Deluxe
- **RoomHierarchy**: La stanza **Deluxe** deve avere un prezzo almeno del **30% superiore** rispetto alla stanza **Standard**.
- **Pricing**:
  - Standard: **100 euro**
  - Deluxe: **>= 130 euro**

## Branch del Repository

Il progetto è organizzato su quattro branch:

- `master`: Implementazione con **Minimal API**.
- `APISwagger`: Implementazione con **Swagger**.
- `MinimalApiDocker`: Implementazione Minimal API con rilascio tramite **Docker Compose**.
- `SwaggerDocker`: Implementazione con Swagger e rilascio tramite **Docker Compose**.

## Istruzioni per l'Esecuzione

### Senza Docker

Eseguire il comando:

```sh
Update-Database -Project HotelsRegistry.Infrastructure -StartupProject HotelsRegistry.API
```

per creare il database.

Avviare il progetto API.

### Con Docker Compose

La configurazione Docker gestisce automaticamente la migrazione del database tramite i comandi EF Core nel `Dockerfile`, `docker-compose.yml` e un file `entrypoint.sh`.

Eseguire:

```sh
docker-compose up --build
```

L'API sarà disponibile all'indirizzo specificato nel file `docker-compose.yml`.

## Tecnologie Utilizzate

- **.NET Core 8**
- **Entity Framework Core**
- **CQRS con MediatR**
- **SQL Server**
- **Docker & Docker Compose**
- **Swagger** (per alcuni branch)


