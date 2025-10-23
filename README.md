# HotelBooker

Hotel Booking Project

## Hotel Migrations

### Add new migration

> dotnet ef migrations add migrationname --project HotelBooker.Infrastructure --startup-project HotelBooker.Api

### Update database to latest schema migrations

> dotnet ef database update --project HotelBooker.Infrastructure --startup-project HotelBooker.Api

### remove last migration

> dotnet ef migrations remove --project HotelBooker.Infrastructure --startup-project HotelBooker.Api
