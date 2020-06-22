using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IBodyTypeParser
    {
        int? ParseForPreview(HtmlNode htmlNode);
        int? ParseForDetailed(HtmlNode htmlNode);
    }
}
