using HappyPlants.Common.Interfaces.Services;
using HappyPlants.Common.POCO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyPlants.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        // GET: api/<PlantController>
        [HttpGet]
        public Task<Plant[]> Get(CancellationToken token)
        {
            return _plantService.Find(token);
        }

        // GET api/<PlantController>/5
        [HttpGet("{id}")]
        public Task<Plant> Get(string id, CancellationToken token)
        {
            return _plantService.Find(id, token);
        }

        // POST api/<PlantController>
        [HttpPost]
        public void Post([FromBody] Plant value, CancellationToken token)
        {
            _plantService.Create(value, token);
        }

        // PUT api/<PlantController>/5
        [HttpPut]
        public void Put([FromBody] Plant value, CancellationToken token)
        {
            _plantService.Update(value, token);
        }

        // DELETE api/<PlantController>/5
        [HttpDelete]
        public void Delete(Plant plant, CancellationToken token)
        {
            _plantService.Remove(plant, token);
        }
    }
}
