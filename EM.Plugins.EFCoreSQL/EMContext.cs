 

using Microsoft.EntityFrameworkCore;
using EM.CoreBusiness;

namespace EM.Plugins.EFCoreSQL
{
    public class EMContext : DbContext
    {
        public EMContext(DbContextOptions<EMContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(e => e.UserEvents)
                .HasForeignKey(ue => ue.EventId);


            modelBuilder.Entity<Review>()
           .HasOne(r => r.Event)
           .WithMany(e => e.Reviews)
           .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Review>()
           .Property(r => r.Rating)
           .IsRequired()
           .HasDefaultValue(0);


            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Title).IsRequired().HasMaxLength(100);
                entity.Property(n => n.Message).IsRequired();
                entity.Property(n => n.RecipientId).IsRequired();
                entity.Property(n => n.IsRead).HasDefaultValue(false);
                entity.Property(n => n.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });



        }
    }
}
