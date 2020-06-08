using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IBrandParser
    {
        TransportBrand ParseForPreview(HtmlNode htmlNode);
        TransportBrand ParseForDetailed(HtmlNode htmlNode);
    }
}
