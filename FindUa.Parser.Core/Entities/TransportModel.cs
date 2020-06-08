using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class TransportModel : BaseEntity
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }

        public TransportBrand Brand { get; set; }
    }
}
