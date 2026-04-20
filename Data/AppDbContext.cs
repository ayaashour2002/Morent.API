using Microsoft.EntityFrameworkCore;
using Morent.API.Models;

namespace Morent.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().Property(c => c.PricePerDay).HasPrecision(10, 2);
        modelBuilder.Entity<Car>().Property(c => c.DiscountedPrice).HasPrecision(10, 2);
        modelBuilder.Entity<Booking>().Property(b => b.TotalPrice).HasPrecision(10, 2);

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Name = "Koenigsegg", Type = "Sport", PricePerDay = 99, DiscountedPrice = 80, Capacity = 2, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 90, Rating = 4.8, ReviewCount = 440, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&auto=format&fit=crop" },
            new Car { Id = 2, Name = "Nissan GT-R", Type = "Sport", PricePerDay = 80, DiscountedPrice = 80, Capacity = 2, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 80, Rating = 4.9, ReviewCount = 440, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=600&auto=format&fit=crop" },
            new Car { Id = 3, Name = "Rolls-Royce", Type = "Sport", PricePerDay = 96, DiscountedPrice = 96, Capacity = 4, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 70, Rating = 4.7, ReviewCount = 440, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1563720223185-11003d516935?w=600&auto=format&fit=crop" },
            new Car { Id = 4, Name = "All New Rush", Type = "SUV", PricePerDay = 100, DiscountedPrice = 72, Capacity = 6, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 70, Rating = 4.6, ReviewCount = 300, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&auto=format&fit=crop" },
            new Car { Id = 5, Name = "CR-V", Type = "SUV", PricePerDay = 80, DiscountedPrice = 80, Capacity = 6, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 80, Rating = 4.5, ReviewCount = 200, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1533473359331-0135ef1b58bf?w=600&auto=format&fit=crop" },
            new Car { Id = 6, Name = "All New Terios", Type = "SUV", PricePerDay = 74, DiscountedPrice = 74, Capacity = 6, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 90, Rating = 4.4, ReviewCount = 150, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1502877338535-766e1452684a?w=600&auto=format&fit=crop" },
            new Car { Id = 7, Name = "MG ZX Excite", Type = "Hatchback", PricePerDay = 100, DiscountedPrice = 76, Capacity = 4, Transmission = "Manual", FuelType = "Electric", FuelCapacity = 80, Rating = 4.3, ReviewCount = 100, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1580273916550-e323be2ae537?w=600&auto=format&fit=crop" },
            new Car { Id = 8, Name = "New MG ZS", Type = "SUV", PricePerDay = 80, DiscountedPrice = 80, Capacity = 6, Transmission = "Manual", FuelType = "Gasoline", FuelCapacity = 80, Rating = 4.5, ReviewCount = 180, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=600&auto=format&fit=crop" },
            new Car { Id = 9, Name = "MG ZX Exclusive", Type = "Hatchback", PricePerDay = 80, DiscountedPrice = 80, Capacity = 4, Transmission = "Automatic", FuelType = "Electric", FuelCapacity = 70, Rating = 4.2, ReviewCount = 90, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1541899481282-d53bffe3c35d?w=600&auto=format&fit=crop" },
            new Car { Id = 10, Name = "BMW M4", Type = "Sport", PricePerDay = 120, DiscountedPrice = 99, Capacity = 4, Transmission = "Automatic", FuelType = "Gasoline", FuelCapacity = 60, Rating = 4.9, ReviewCount = 520, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&auto=format&fit=crop" },
            new Car { Id = 11, Name = "Mercedes C-Class", Type = "Sedan", PricePerDay = 95, DiscountedPrice = 95, Capacity = 5, Transmission = "Automatic", FuelType = "Gasoline", FuelCapacity = 65, Rating = 4.6, ReviewCount = 380, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=600&auto=format&fit=crop" },
            new Car { Id = 12, Name = "Tesla Model S", Type = "Sedan", PricePerDay = 180, DiscountedPrice = 150, Capacity = 5, Transmission = "Automatic", FuelType = "Electric", FuelCapacity = 100, Rating = 5.0, ReviewCount = 600, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1617788138017-80ad40651399?w=600&auto=format&fit=crop" }
        );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, CarId = 2, ReviewerName = "Alex Stanton", ReviewerTitle = "CEO at Bukalapak", Comment = "We are very happy with the service from the MORENT App. Morent has a low price and also a large variety of cars with good and comfortable facilities. In addition, the service provided by the officers is also very friendly and very polite.", Rating = 4, CreatedAt = new DateTime(2022, 7, 21) },
            new Review { Id = 2, CarId = 2, ReviewerName = "Skylar Dias", ReviewerTitle = "CEO at Amazon", Comment = "We are greatly helped by the services of the MORENT Application. Morent has low prices and also a wide variety of cars with good and comfortable facilities. In addition, the service provided by the officers is also very friendly and very polite.", Rating = 4, CreatedAt = new DateTime(2022, 7, 20) },
            new Review { Id = 3, CarId = 1, ReviewerName = "John Smith", ReviewerTitle = "CTO at Google", Comment = "Amazing car! The Koenigsegg exceeded all my expectations. Smooth ride and incredible acceleration. Highly recommend MORENT for luxury car rentals.", Rating = 5, CreatedAt = new DateTime(2022, 8, 1) },
            new Review { Id = 4, CarId = 3, ReviewerName = "Emma Wilson", ReviewerTitle = "CEO at Tesla", Comment = "The Rolls-Royce was absolutely stunning. Pure luxury from the moment I sat in it. MORENT made the whole process seamless and easy.", Rating = 5, CreatedAt = new DateTime(2022, 7, 15) },
            new Review { Id = 5, CarId = 4, ReviewerName = "Mike Johnson", ReviewerTitle = "Manager at Ford", Comment = "Great family SUV! The All New Rush was perfect for our road trip. Spacious, comfortable and fuel efficient. Great value for money.", Rating = 4, CreatedAt = new DateTime(2022, 8, 5) },
            new Review { Id = 6, CarId = 10, ReviewerName = "Sarah Lee", ReviewerTitle = "Designer at Apple", Comment = "The BMW M4 is an absolute beast! Perfect handling and stunning looks. MORENT service was top notch from booking to return.", Rating = 5, CreatedAt = new DateTime(2022, 8, 10) },
            new Review { Id = 7, CarId = 12, ReviewerName = "David Chen", ReviewerTitle = "Engineer at SpaceX", Comment = "Tesla Model S is the future! Silent, fast and incredibly comfortable. MORENT had it ready on time and in perfect condition.", Rating = 5, CreatedAt = new DateTime(2022, 8, 12) },
            new Review { Id = 8, CarId = 5, ReviewerName = "Lisa Park", ReviewerTitle = "Director at Samsung", Comment = "CR-V was perfect for our family vacation. Reliable, comfortable and great on fuel. MORENT's pricing is very competitive.", Rating = 4, CreatedAt = new DateTime(2022, 7, 28) }
        );
       modelBuilder.Entity<User>().HasData(new User
{
    Id           = 1,
    Name         = "Admin",
    Email        = "admin@morent.com",
    PasswordHash = "$2a$11$3h6TF.117HuW0vcvm7/Id./yZXIwJp41u8wKKszZC.7bLbaKoBI4C", // ← hash ثابت
    Role         = "Admin",
    CreatedAt    = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
});
    }
}