using NZMyWebApis.Data;
using NZMyWebApis.Models.Domain;

namespace NZMyWebApis.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZApiDbContext nZApiDbContext;
        public RegionRepository(NZApiDbContext nZApiDbContext)
        {
            this.nZApiDbContext = nZApiDbContext;
        }
        public IEnumerable<Region> GetAll()
        {
            return nZApiDbContext.Regions.ToList();
        }

    }
}
