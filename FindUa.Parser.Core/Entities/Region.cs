using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class Region : BaseEntity
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}
