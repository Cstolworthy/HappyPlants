using HappyPlants.Common.POCO;

namespace HappyPlants.Common.Interfaces.Services
{
    public interface IPlantRepository
    {

        Task<Plant[]> Find(CancellationToken token);
        Task<Plant> Find(string id, CancellationToken token);
        Task<Plant> Create(Plant plant, CancellationToken token);
        Task<Plant> Update( Plant plant, CancellationToken token);
        Task Remove(Plant plant, CancellationToken token);
    }
}
