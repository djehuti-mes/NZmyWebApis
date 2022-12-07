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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = imapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }
        [HttpPost]
        public async Task<IActionResult>AddRegion(Models.DTO.AddRegionRequest addreqmodel)
        {
            //Request DTO to Region Domain Model
            var region = new Models.Domain.Region()
            {               
                Name = addreqmodel.Name,
                Area = addreqmodel.Area,
                Code = addreqmodel.Code,
                population = addreqmodel.population,
                Lat = addreqmodel.Lat,
                Long = addreqmodel.Long                
            };

            //Pass details to Repository
            region = await this.regionRepository.AddAsync(region);

            //COnvert back to DTO
            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Name = region.Name,
                Area = region.Area,
                Code = region.Code,
                population = region.population,
                Lat = region.Lat,
                Long = region.Long

            };
            return CreatedAtAction(nameof(GetRegion), new {id=regionDTO.Id}, regionDTO);


        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult>DeleteRegionAsync(Guid id)
        {
            //Get Region from database
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
          
            var regionDTO = imapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult>UpdateRegionAsync(Guid id, [FromBody]Models.DTO.UpdateRegionRequest updreg)
        {
            //From DTO to Model
            var region = new Models.Domain.Region()
            {
                Code = updreg.Code,
                Area = updreg.Area,
                Name = updreg.Name,
                Lat = updreg.Lat,
                Long = updreg.Long,
                population = updreg.population
            };
            region = await regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = new Models.DTO.Region
            {
                Id= region.Id,
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                population = region.population

            };

            return Ok(regionDTO);

        }
    }
}
