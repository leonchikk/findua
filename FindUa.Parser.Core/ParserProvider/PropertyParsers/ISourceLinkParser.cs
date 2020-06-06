using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface ISourceLinkParser
    {
        string ParseForPreview(HtmlNode htmlNode);
        string ParseForDetailed(HtmlNode htmlNode);
    }
}
