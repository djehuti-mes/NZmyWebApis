using Microsoft.EntityFrameworkCore;
using NZMyWebApis.Models.Domain;

namespace NZMyWebApis.Data
{
    public class NZApiDbContext : DbContext
    {
        public NZApiDbContext(DbContextOptions<NZApiDbContext>options):base(options)
        {

        }
        public DbSet<Region>Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
    }
}
