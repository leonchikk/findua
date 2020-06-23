using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstYearParser : IYearParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var yearBlock = htmlNode.Descendants()
               .Where(n => n.InnerText.Contains("Год выпуска", StringComparison.OrdinalIgnoreCase))
               .ToList();

            var isTableRepresentation = yearBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var yearInfo = yearBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().ChildNodes["a"];

            var numberString = yearInfo.InnerText;
            return int.Parse(numberString);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
