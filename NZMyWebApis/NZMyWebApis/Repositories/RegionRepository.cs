using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
             return await nZApiDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZApiDbContext.Regions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id=new Guid();
            await nZApiDbContext.AddAsync(region);
            await nZApiDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region= await nZApiDbContext.Regions.FirstOrDefaultAsync(x => x.Id==id);
            if (region==null)
            {
                return null;
            };
            nZApiDbContext.Remove(region);
            await nZApiDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region>UpdateAsync(Guid id, Region region)
        {
            var regioninDb = await this.nZApiDbContext.Regions.SingleOrDefaultAsync(x => x.Id == id);
            if (regioninDb==null)
            {
                return null;
            }
            regioninDb.Code=region.Code;
            regioninDb.Area = region.Area;
            regioninDb.Name= region.Name;  
            regioninDb.Lat= region.Lat; 
            regioninDb.Long=region.Long;
            regioninDb.population = region.population;
            await nZApiDbContext.SaveChangesAsync();

            return regioninDb;



        }
    }
}
