using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstEngineVolumetricParser : IEngineVolumetricParser
    {
        public int ParseForDetailed(HtmlNode htmlNode)
        {
            var engineBlock = htmlNode.Descendants()
                .Where(n => n.InnerText.Contains("Двигатель"))
                .ToList();

            var isTableRepresentation = engineBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var engineVolumetricNode = engineBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last();
            var numberString = Regex.Replace(engineVolumetricNode.InnerText, "[^0-9.]", "");
            var engineVolumetric = double.Parse(numberString);

            return (int)Math.Ceiling(engineVolumetric * 1000);
        }

        public int ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
