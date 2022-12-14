using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPlants.Common.POCO.Interfaces;

namespace HappyPlants.Common.POCO
{
    public class Plant : IPlant
    {
        public int PlantId { get; set; }
        public string FriendlyName { get; set; }
        public string Id { get; set; }
        public string Rev { get; set; }
    }
}
