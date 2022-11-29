using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZMyWebApis.Data;
using NZMyWebApis.Models.Domain;
using NZMyWebApis.Repositories;
using System.Collections.Generic;

namespace NZMyWebApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {       
        private readonly IRegionRepository regionRepository;
        private readonly IMapper imapper;

        public RegionsController(IRegionRepository regionRepository,IMapper imapper)
        {           
            this.regionRepository = regionRepository;
            this.imapper = imapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetallRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(Region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = Region.Id,
            //        Area= Region.Area,
            //        Code= Region.Code,
            //        Lat= Region.Lat,
            //        Long= Region.Long,
            //        Name= Region.Name,
            //        population=Region.population
            //    };

            //});
            var regionDTO=imapper.Map<List<Models.DTO.Region>> (regions);
            return Ok(regionDTO);            
        }

    }
}
