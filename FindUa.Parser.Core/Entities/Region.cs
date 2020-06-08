using Common.Core.Models;
using System;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class Region : BaseEntity
    {
        public Region()
        {
            Localities = new HashSet<Locality>();
        }

        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<Locality> Localities { get; set; }

    }
}
