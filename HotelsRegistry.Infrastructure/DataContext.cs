using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<RoomHierarchy> RoomHierarchys { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomHierarchy>()
                .HasOne(rh => rh.RoomTypeBase)
                .WithMany()
                .HasForeignKey("RoomTypeBaseId")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RoomHierarchy>()
                .HasOne(rh => rh.RoomTypeRelated)
                .WithMany()
                .HasForeignKey("RoomTypeRelatedId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Accommodation>()
                .Property(a => a.Type)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
