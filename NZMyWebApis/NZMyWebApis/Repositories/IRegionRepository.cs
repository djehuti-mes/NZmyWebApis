using NZMyWebApis.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZMyWebApis.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>>GetAllAsync();
       Task<Region>GetAsync(Guid id);
       Task<Region> AddAsync(Region region);
       Task<Region> DeleteAsync(Guid id);
       Task<Region> UpdateAsync(Guid id,Region region);
    }
}
