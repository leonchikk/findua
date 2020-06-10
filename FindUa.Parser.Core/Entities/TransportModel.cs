using Common.Core.Models;

namespace FindUa.Parser.Core.Entities
{
    public class TransportModel : BaseEntity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        public TransportBrand Brand { get; set; }
    }
}
