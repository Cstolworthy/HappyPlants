using HappyPlants.Common.Interfaces.Services;
using HappyPlants.Common.POCO;

namespace HappyPlants.Services
{
    public class PlantService : IPlantService
    {
        private IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public Task Create(Plant plant, CancellationToken token)
        {
            return _plantRepository.Create(plant, token);
        }

        public Task<Plant[]> Find(CancellationToken token)
        {
            return _plantRepository.Find(token);
        }

        public Task<Plant> Find(string id, CancellationToken token)
        {
            return _plantRepository.Find(id, token);
        }

        public Task Remove(Plant plant, CancellationToken token)
        {
            return _plantRepository.Remove(plant, token);            
        }

        public Task Update(Plant plant, CancellationToken token)
        {
            return _plantRepository.Update(plant, token);
        }
    }
}
