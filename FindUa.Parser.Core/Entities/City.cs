using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class City : BaseEntity
    {
        public int RegionId { get; set; }
        public string Name { get; set; }

        public Region Region { get; set; }
    }
}
