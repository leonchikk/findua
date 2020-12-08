using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class Country : BaseEntity<int>
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public string Title { get; set; }

        public int LocalizationKeyId { get; set; }
        public LocalizationKey LocalizationKey { get; set; }

        public ICollection<Region> Regions { get; set; }
    }
}
