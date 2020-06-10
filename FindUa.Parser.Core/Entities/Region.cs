using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class Region : BaseEntity
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
