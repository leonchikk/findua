using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IOfferNumberParser
    {
        long ParseForPreview(HtmlNode htmlNode);
        long ParseForDetailed(HtmlNode htmlNode);
    }
}
