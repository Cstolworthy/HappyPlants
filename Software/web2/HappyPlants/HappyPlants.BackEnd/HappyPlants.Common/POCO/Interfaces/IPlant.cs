namespace HappyPlants.Common.POCO.Interfaces
{
    public interface IPlant
    {
        string Id { get; set; }
        string FriendlyName { get; set; }
        int PlantId { get; set; }
    }
}