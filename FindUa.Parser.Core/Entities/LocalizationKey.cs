using Common.Core.Models;
using System.Collections.Generic;

namespace FindUa.Parser.Core.Entities
{
    public class LocalizationKey : BaseEntity<int>
    {
        public LocalizationKey()
        {
            Localizations = new HashSet<Localization>();
        }

        public string KeyName { get; set; }

        public ICollection<Localization> Localizations { get; set; }
    }
}