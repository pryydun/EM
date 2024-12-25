using EM.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EM.Plugins.EFCoreSQL
{
    public class EMContext : DbContext
    {
        public EMContext(DbContextOptions<EMContext> options)
        : base(options)
        {
        }

        // Визначення таблиць
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Визначення композитного ключа для UserEvents
            modelBuilder.Entity<UserEvents>()
                .HasKey(ue => new { ue.UserId, ue.EventId }); // Композитний ключ

            // Налаштування зв’язків
            modelBuilder.Entity<UserEvents>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserEvents>()
                .HasOne(ue => ue.Event)
                .WithMany(e => e.UserEvents)
                .HasForeignKey(ue => ue.EventId);

            // Початкові дані (seeding)
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Tech Conference", Description = "Tech trends 2024", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), Location = "Kyiv" },
                new Event { Id = 2, Title = "Art Expo", Description = "Modern Art", StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(6), Location = "Lviv" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            modelBuilder.Entity<UserEvents>().HasData(
                new UserEvents { UserId = 1, EventId = 1 },
                new UserEvents { UserId = 2, EventId = 1 }
            );
        }



    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}

