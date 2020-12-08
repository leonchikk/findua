using Common.Core.Models;
using System;

namespace FindUa.Parser.Core.Entities
{
    public class City : BaseEntity<int>
    {
        public string Title { get; set; }
        public bool IsRegionalCenter { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int LocalizationKeyId { get; set; }
        public LocalizationKey LocalizationKey { get; set; }
    }
}
