using CouchDB.Driver;
using CouchDB.Driver.Options;
using HappyPlants.Common.POCO;
using HappyPlants.Data.DBObjects;

namespace HappyPlants.Data
{
    public class HappyPlantContext : CouchContext
    {
        public HappyPlantContext(CouchOptions<HappyPlantContext> options) : base(options)
        {
        }
        public CouchDatabase<PlantDocument> Plants { get; set; }

    }
}