
# Dotnet CQRS - Simple and Advanced example

This project was designed by using CQRS - Command and Query Responsibility Segregation pattern and Clean Architecture. It also help anyone to know more about some use case and application of CQRS in Real-World. This repository contain two example of CQRS, the first one (v1) is the version build everything from scratch, and the another (v2) is a version we use MediatR library.


## Installation

Create database by using migrations

```bash
cd CqrsExample
dotnet ef database update -s v1/CqrsV1.API -p v1/CqrsV1.Infrastructure --context CqrsApplicationDbContext
```
    
Run source v1

```bash
dotnet run --project v1/CqrsV1.API 
```

Run source v2

```bash

```
## Documentation

We have two type of DbContext: CqrsApplicationDbContext and CqrsReadonlyDbContext
- CqrsApplicationDbContext: this DbContext was used to execute command (create, update, delete) for our application
- CqrsReadonlyDbContext: this DbContext was used to execute query, we can use another replication database for this DbContext, we can config this setting in appsetting.json

