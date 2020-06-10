using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IRegionParser
    {
        City ParseForPreview(HtmlNode htmlNode);
        City ParseForDetailed(HtmlNode htmlNode);
    }
}
