

using AutoMapper;
using HappyPlants.Common.Interfaces.Services;
using HappyPlants.Common.POCO;
using HappyPlants.Data.DBObjects;
using System.Reflection.Metadata.Ecma335;

namespace HappyPlants.Data
{
    public class PlantRepository : IPlantRepository
    {
        private IMapper _mapper;
        private HappyPlantContext _context;
        public PlantRepository(HappyPlantContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Plant> Create(Plant plant, CancellationToken token)
        {
            var plantDocument = ConvertToPlantDocument(plant, token);
            var resultingPlant = await _context.Plants.AddAsync(plantDocument);
            _mapper.Map(resultingPlant, plant);
            return plant;
        }

        private PlantDocument ConvertToPlantDocument(Plant plant, CancellationToken token)
        {
            return _mapper.Map<PlantDocument>(plant);
        }

        public Task<Plant[]> Find(CancellationToken token)
        {

            var plantDocs = _context.Plants.ToArray().Select(p => _mapper.Map<Plant>(p));

            return Task.FromResult(plantDocs.ToArray());
        }

        public Task<Plant> Find(string id, CancellationToken token)
        {
            var resultingPlant = _context.Plants.FirstOrDefault(pd => pd.Id == id);

            if (resultingPlant != null)
            {
                return Task.FromResult(_mapper.Map<Plant>(resultingPlant));
            }

            throw new KeyNotFoundException($"Plant with ID {id} could not be found");
        }

        public Task Remove(Plant plant, CancellationToken token)
        {
            var plantDoc = ConvertToPlantDocument(plant, token);
            return _context.Plants.RemoveAsync(plantDoc);
        }

        public async Task<Plant> Update(Plant plant, CancellationToken token)
        {
            var plantDoc = ConvertToPlantDocument(plant, token);
            var resultingPlant = await _context.Plants.AddOrUpdateAsync(plantDoc, cancellationToken: token);
            _mapper.Map(resultingPlant, plant);
            return plant;
        }
    }
}
