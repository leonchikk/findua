using FindUa.Parser.Core.ParserProvider.PropertyParsers;
using HtmlAgilityPack;
using System;

namespace FindUa.Parser.Domain.ParserProviders.RST.PropertyParsers
{
    public class RstOfferNumberParser : IOfferNumberParser
    {
        public long ParseForDetailed(HtmlNode htmlNode)
        {
            var content = htmlNode.SelectNodes("//*[@id=\"rst-page-oldcars-item-id\"]/p/strong");
            var numberString = content["strong"].InnerText;

            return long.Parse(numberString);
        }

        public long ParseForPreview(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}
