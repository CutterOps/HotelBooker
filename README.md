# HotelBooker

Hotel Booking Project

## Hotel Migrations

### Add new migration

> dotnet ef migrations add migrationname --project HotelBooker.Infrastructure --startup-project HotelBooker.Api

### Update database to latest schema migrations

> dotnet ef database update --project HotelBooker.Infrastructure --startup-project HotelBooker.Api

### remove last migration

> dotnet ef migrations remove --project HotelBooker.Infrastructure --startup-project HotelBooker.Api

# Notes

There was a lot to cover when creating this Application. I did actually really enjoy creating this so I appreciate the challenge.

## The Approach

I took the approach of Clean Architecture design. This is a good standard practice when it comes to an application of this scale.
This will allow a testing application to be created that can make use of the SeederService and test the data locally without the need of using the controllers, however some dummy controllers could be implemented.

## What would need to be taken into consideration

There is quite a vast number of features variables I haven't really explored yet when it comes to making this booking System.

### Pricing (Currency Conversion)

Currency conversion would need to be taken into account when implementing a system like this.

### Timezones

When it comes to the creation times of bookings we have to be weary of the timezones for example when it comes to cancelling a booking before 48 hours etc.

# Sample Booking

Hotel Id

> 13ab1a14-801b-419c-a388-0032ebb7adbb
> Body

```json
{
    "startDate": "2025-10-25",
    "endDate": "2025-10-26",
    "roomAndGuests": [
        {
            "roomId": 3,
            "guests": [
                {
                    "firstName": "Ethan",
                    "lastName": "Cutter"
                },
                {
                    "firstName": "RoomId3",
                    "lastName": "Guest"
                }
            ]
        },
        {
            "roomId": 5,
            "guests": [
                {
                    "firstName": "Guest1",
                    "lastName": "Room5a"
                },
                {
                    "firstName": "Guest2",
                    "lastName": "Room5b"
                },
                {
                    "firstName": "Guest3",
                    "lastName": "Room5c"
                }
            ]
        }
    ]
}
```
