using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataEF
{
    public class AirbnbModel : DbContext
    {
        public AirbnbModel(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HostLanguage> HostLanguages { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyReview> PropertyReviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HostLanguage>()
                .HasKey(c => new { c.HostID, c.Language });
            modelBuilder.Entity<PropertyImage>()
                .HasKey(c => new { c.PropertyID, c.Image });
            modelBuilder.Entity<PropertyReview>()
                .HasKey(c => new { c.PropertyID, c.UserId });
        }

    }
}
