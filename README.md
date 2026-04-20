# 🚗 MORENT - Backend (.NET 8)

A RESTful API for the MORENT car rental platform.

## 🛠️ Tech Stack
- .NET 8 Web API
- Entity Framework Core
- SQL Server
- Stripe.NET
- JWT Authentication
- BCrypt Password Hashing

## 🏗️ Architecture
Onion Architecture with:
- **Controllers** — Handle HTTP requests
- **Services** — Business logic
- **Interfaces** — Contracts between layers
- **Models** — Database entities
- **DTOs** — Data transfer objects

## 📡 API Endpoints

### Auth
```
POST /api/auth/register
POST /api/auth/login
```

### Cars
```
GET  /api/cars
GET  /api/cars/popular
GET  /api/cars/recommended
GET  /api/cars/{id}
GET  /api/cars/{id}/reviews
GET  /api/cars/{id}/related
GET  /api/cars/types
```

### Bookings
```
GET    /api/bookings
GET    /api/bookings/{id}
POST   /api/bookings
PATCH  /api/bookings/{id}/status
```

### Payment
```
POST /api/payment/create-intent
POST /api/payment/confirm-booking
```

### Admin
```
GET /api/admin/dashboard
GET /api/admin/car-types-stats
```

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server
- Stripe Account

### Installation

```bash
git clone https://github.com/ayaashour2002/Morent.API.git
```

### Configuration

```bash
cp appsettings.example.json appsettings.json
```

عدّل `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION_STRING"
  },
  "Stripe": {
    "SecretKey": "sk_test_YOUR_KEY",
    "PublishableKey": "pk_test_YOUR_KEY"
  },
  "Jwt": {
    "Key": "YourSuperSecretKey12345678901234",
    "Issuer": "MorentAPI",
    "Audience": "MorentClient"
  }
}
```

### Run

```bash
dotnet ef database update
dotnet run
```

API will run on `http://localhost:7072`

## 🔐 Default Admin Account

| Email | Password |
|-------|----------|
| admin@morent.com | Admin@123 |

## 💳 Stripe Test Card

| Field | Value |
|-------|-------|
| Card | `4242 4242 4242 4242` |
| Expiry | `12/34` |
| CVC | `123` |

## 🔗 Frontend Repo
[morent-angular](https://github.com/ayaashour2002/morent-app)
