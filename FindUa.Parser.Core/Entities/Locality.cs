using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class Locality : BaseEntity
    {
        public Guid RegionId { get; set; }
        public string Name { get; set; }
        public double Latitude  { get; set; }
        public double Longtitude { get; set; }
    }
}
