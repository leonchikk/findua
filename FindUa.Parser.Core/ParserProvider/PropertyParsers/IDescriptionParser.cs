using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IDescriptionParser
    {
        string ParseForPreview(HtmlNode htmlNode);
        string ParseForDetailed(HtmlNode htmlNode);
    }
}
