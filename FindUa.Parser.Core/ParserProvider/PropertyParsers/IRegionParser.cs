using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IRegionParser
    {
        Locality ParseForPreview(HtmlNode htmlNode);
        Locality ParseForDetailed(HtmlNode htmlNode);
    }
}
