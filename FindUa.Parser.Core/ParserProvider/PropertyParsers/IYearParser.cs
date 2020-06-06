using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IYearParser
    {
        int ParseForPreview(HtmlNode htmlNode);
        int ParseForDetailed(HtmlNode htmlNode);
    }
}
