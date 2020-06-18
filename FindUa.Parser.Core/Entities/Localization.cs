using Common.Core.Models;

namespace FindUa.Parser.Core.Entities
{
    public class Localization : BaseEntity
    {
        public int LocalizationKeyId { get; set; }
        public LocalizationKey LocalizationKey { get; set; }

        public string Language { get; set; }
        public string Text { get; set; }
    }
}
