using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IMileageParser
    {
        int ParseForPreview(HtmlNode htmlNode);
        int ParseForDetailed(HtmlNode htmlNode);
    }
}
