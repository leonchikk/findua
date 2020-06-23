using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Linq;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstPublishDateParser : IPublishDateParser
    {
        public DateTime ParseForDetailed(HtmlNode htmlNode)
        {
            var publishDateBlock = htmlNode.Descendants()
                 .Where(n => n.InnerText.Contains("размещено") || n.InnerText.Contains("обновлено"))
                 .ToList();

            var isTableRepresentation = publishDateBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var publishDateString = publishDateBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().InnerText;

            if (publishDateString.Contains("Сегодня", StringComparison.OrdinalIgnoreCase))
                return DateTime.UtcNow;

            if (publishDateString.Contains("Вчера", StringComparison.OrdinalIgnoreCase))
                return DateTime.UtcNow.AddDays(-1);

            return DateTime.ParseExact(publishDateString, "dd.mm.yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
