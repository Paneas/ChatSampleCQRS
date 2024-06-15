# CQRS Playground and more
This project was created so I can experiment with the CQRS pattern.

Essentially what I wanted to create was the following:

- A simple API
- A SQL Database with Read and Write Context (Separation between reads and writes)
- CQRS pattern
- Mediator Pattern
- Raise Events into a queue
- SignalR for notifications
- Put everything on a docker container

# Technologies / Libraries
- .NET 8
- MediatR
- SignalR
- SQL Server 2019
- RabbitMQ

# How to run

From Root folder
```sh
docker compose up --wait
```
⚠️ You migh need to restart the api container, in order to connect properly with the DB