using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class TransportBrand : BaseEntity
    {
        public TransportBrand()
        {
            Models = new HashSet<TransportModel>();
        }

        public string Name { get; set; }
        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
        public ICollection<TransportModel> Models { get; set; }
    }
}
