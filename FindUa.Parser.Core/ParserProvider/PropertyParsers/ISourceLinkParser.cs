using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface ISourceLinkParser
    {
        string GetLink (HtmlNode htmlNode, string baseUrl);
    }
}
