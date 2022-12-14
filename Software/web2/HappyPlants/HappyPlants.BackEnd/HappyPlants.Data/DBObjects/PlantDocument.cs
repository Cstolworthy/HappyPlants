using CouchDB.Driver.Types;
using HappyPlants.Common.POCO.Interfaces;

namespace HappyPlants.Data.DBObjects
{
    public class PlantDocument : CouchDocument
    {
        public string? FriendlyName { get; set; }
        public int PlantId { get; set; }


    }
}
