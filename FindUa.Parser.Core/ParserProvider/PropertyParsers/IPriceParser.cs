using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IPriceParser
    {
        double ParseForPreview(HtmlNode htmlNode);
        double ParseForDetailed(HtmlNode htmlNode);
    }
}
