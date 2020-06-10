using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
