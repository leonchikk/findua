using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;
using System.Linq;
using UnidecodeSharpCore;

namespace FindUa.RstParser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstRegionParser : IRegionParser
    {
        private readonly IMemoryStore _memoryStore;

        public RstRegionParser(IMemoryStore memoryStore)
        {
            _memoryStore = memoryStore;
        }

        public City ParseForDetailed(HtmlNode htmlNode)
        {
            var regionBlock = htmlNode.Descendants()
                .Where(n => n.InnerText.Contains("Область"))
                .ToList();

            var containsCity = regionBlock.Any(n => n.InnerText.Contains("город"));
            var isTableRepresentation = regionBlock.Any(n => n.Name == "tr");
            var targetTag = isTableRepresentation ? "tr" : "li";
         
            var regionInfoBlock = regionBlock.FirstOrDefault(x => x.Name == targetTag);

            if (containsCity)
                return GetTargetCity(regionInfoBlock);
            else
                return GetRegionCenter(regionInfoBlock);
        }

        private City GetTargetCity(HtmlNode regionInfoBlock)
        {
            var cyrillicCityName = regionInfoBlock.Descendants().Where(x => x.Name == "a").Last().InnerText;
            var latinCityName = cyrillicCityName.Unidecode();

            var parsedCity = _memoryStore.Cities.FirstOrDefault(x => x.Title.Contains(latinCityName, StringComparison.OrdinalIgnoreCase));

            if (parsedCity == null)
                return GetRegionCenter(regionInfoBlock);

            return parsedCity;
        }

        private City GetRegionCenter(HtmlNode regionInfoBlock)
        {
            var cyrillicRegionName = regionInfoBlock.Descendants().Where(x => x.Name == "a").First().InnerText;
            var latinRegionName = cyrillicRegionName.Unidecode();

            var parsedCity = _memoryStore.Cities.FirstOrDefault(x => 
                (
                    x.Region.Title.Contains(latinRegionName, StringComparison.OrdinalIgnoreCase) || 
                    x.Region.ShortTitle.Contains(latinRegionName, StringComparison.OrdinalIgnoreCase)
                ) 
                && x.IsRegionalCenter);

            return parsedCity;
        }

        public City ParseForPreview(HtmlNode htmlNode)
        {
            throw new System.NotImplementedException();
        }
    }
}
