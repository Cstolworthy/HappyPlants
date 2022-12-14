using HappyPlants.Common.POCO;

namespace HappyPlants.Common.Interfaces.Services
{
    public interface IPlantService
    {
        Task<Plant[]> Find(CancellationToken token);
        Task<Plant> Find(string id, CancellationToken token);
        Task Create(Plant plant, CancellationToken token);
        Task Update(Plant plant, CancellationToken token);
        Task Remove(Plant plant, CancellationToken token);
    }
}
