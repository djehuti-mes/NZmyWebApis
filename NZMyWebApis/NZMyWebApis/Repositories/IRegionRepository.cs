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
    }
}
