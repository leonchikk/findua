using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System.Linq;
using UnidecodeSharpCore;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
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
            City parsedCity = null;

            var charactiristicsBlock = htmlNode.ChildNodes[10];
            var charactiristicsList = charactiristicsBlock.ChildNodes[3];

            var regionBlock = charactiristicsList.ChildNodes[5];
            var regionCityBlock = regionBlock.ChildNodes[1];
            var cityBlock = regionCityBlock.ChildNodes[2];

            string latinCityName = string.Empty;

            if (cityBlock.ChildNodes.Count == 0) // We get only region, without city
            {
                var latinNameOfRegion = regionCityBlock.InnerText.Unidecode();

                parsedCity = _memoryStore.Cities.FirstOrDefault(x => x.Name.Contains(regionCityBlock.InnerText.Unidecode()));

                if (parsedCity == null) // When region and main city names on't match (for example lutsk is volynsk'a oblast) so take first city
                {
                    parsedCity = _memoryStore.Cities.FirstOrDefault(x => x.Region.Name.Contains(regionCityBlock.InnerText.Unidecode()));
                }
            }
            else
            {
                latinCityName = cityBlock.ChildNodes[1]?.InnerText.Unidecode();

                parsedCity = _memoryStore.Cities.FirstOrDefault(x => x.Name == latinCityName);
            }

            if (parsedCity == null) 
            {
                throw new System.Exception("Latin city name = " + latinCityName + " " + regionBlock.InnerHtml);
            }

            return parsedCity;
        }

        public City ParseForPreview(HtmlNode htmlNode)
        {
            throw new System.NotImplementedException();
        }
    }
}
