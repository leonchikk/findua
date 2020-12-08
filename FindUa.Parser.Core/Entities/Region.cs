using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class Region : BaseEntity<int>
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public int LocalizationKeyId { get; set; }
        public LocalizationKey LocalizationKey { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
