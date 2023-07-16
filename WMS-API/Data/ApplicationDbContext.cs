using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using WMS_API.Models.Domain;

namespace WMS_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Bin> bins { get; set; }

        public DbSet<WCollector> wCollectors { get; set; }

        public DbSet<BinStatus> binStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
            //Seed Data For Bin Status
            var binStatuses = new List<BinStatus>()
            {
                new BinStatus()
                {
                    Id = Guid.Parse("d6de91d5-d9c3-4f8a-bc16-8d844779a715"),
                    WasteStatus = "Bin Is Empty"
                },
                new BinStatus()
                {
                    Id = Guid.Parse("9d8c0470-1143-4a7d-b793-2ff85ad3d6df"),
                    WasteStatus = "Bin is Half-filled"
                },
                new BinStatus()
                {
                    Id = Guid.Parse("ae6638f6-2a49-44ee-8dee-a906c99e5f0c"),
                    WasteStatus = "Bin if Full"
                }
            };
            modelBuilder.Entity<BinStatus>().HasData(binStatuses);
            
        }
    }
}
