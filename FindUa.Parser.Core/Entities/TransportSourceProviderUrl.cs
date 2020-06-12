using Common.Core.Models;

namespace FindUa.Parser.Core.Entities
{
    public class TransportSourceProviderUrl : BaseEntity
    {
        public string DataUrl { get; set; }

        public int VehicleTypeId { get; set; }
        public int SourceProviderId { get; set; }

        public VehicleType VehicleType { get; set; }
        public TransportSourceProvider SourceProvider { get; set; }
    }
}
