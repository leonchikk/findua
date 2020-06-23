using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.Enumerations;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;

namespace FindUa.RstParser.Domain.RST.PropertyParsers
{
    public class RstBodyTypeParser : IBodyTypeParser
    {
        private readonly IMemoryStore _memoryStore;

        public RstBodyTypeParser(IMemoryStore memoryStore)
        {
            _memoryStore = memoryStore;
        }

        public int? ParseForDetailed(HtmlNode htmlNode)
        {
            var modelBrandBlock = htmlNode.OwnerDocument
                .GetElementbyId("rst-page-oldcars-tree-block");

            var bodyTypeBlock = htmlNode.Descendants()
                   .Where(n => n.InnerText.Contains("Тип кузова"))
                   .ToList();

            var isTableRepresentation = bodyTypeBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";

            var bodyTypeString = bodyTypeBlock.FirstOrDefault(x => x.Name == targetTag).ChildNodes.Last().InnerText;

            return (int?)GetBodyType(bodyTypeString);
        }

        public int? ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private BodyTypeEnum GetBodyType(string bodyTypeString)
        {
            if (bodyTypeString.Contains("Седан", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Sedan;

            if (bodyTypeString.Contains("Хетчбэк", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Hatchback;

            if (bodyTypeString.Contains("Купе", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Coupe;

            if (bodyTypeString.Contains("Кабриолет", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Cabriolet;

            if (bodyTypeString.Contains("Родстер", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Roadster;

            if (bodyTypeString.Contains("Универсал", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.StationWagon;

            if (bodyTypeString.Contains("Минивэн", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.Minivan;

            if (bodyTypeString.Contains("Внедорожник", StringComparison.OrdinalIgnoreCase))
                return BodyTypeEnum.SUV;

            return BodyTypeEnum.NA;
        }
    }
}
