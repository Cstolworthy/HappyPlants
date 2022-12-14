using AutoMapper;
using HappyPlants.Common.POCO;
using HappyPlants.Data.DBObjects;

namespace HappyPlants.Data
{
    public class DataMappings : Profile
    {
        public DataMappings()
        {
            CreateMap<PlantDocument, Plant>()
                .AfterMap((p, pd) => { p.Id = pd.Id; });
            CreateMap<Plant, PlantDocument>();
        }
    }
}
