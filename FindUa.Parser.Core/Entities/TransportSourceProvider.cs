using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class TransportSourceProvider : BaseEntity
    {
        public TransportSourceProvider()
        {
            DataUrls = new HashSet<TransportSourceProviderUrl>();
        }

        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public ICollection<TransportSourceProviderUrl> DataUrls { get; set; }
    }
}
