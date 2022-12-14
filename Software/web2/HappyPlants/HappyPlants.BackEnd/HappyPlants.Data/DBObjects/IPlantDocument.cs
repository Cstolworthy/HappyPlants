using CouchDB.Driver;
using CouchDB.Driver.Types;
using System.Collections;

namespace HappyPlants.Data.DBObjects
{
    public interface IPlantDocument
    {
        string? FriendlyName { get; set; }
        int PlantId { get; set; }
    }
}