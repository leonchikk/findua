using Common.Core.Models;

namespace FindUa.Parser.Core.Entities
{
    public class BodyType : BaseEntity<int>
    {
        public string Name { get; set; }
        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
