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
                .WithMany() // Se non c'è una collection in RoomType, altrimenti specifica il nome della proprietà di navigazione
                .HasForeignKey("RoomTypeBaseId") // Assicurati che la FK esista nel modello
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminazioni a cascata indesiderate
            modelBuilder.Entity<RoomHierarchy>()
                .HasOne(rh => rh.RoomTypeRelated)
                .WithMany() 
                .HasForeignKey("RoomTypeRelatedId") 
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
