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
    }
}
