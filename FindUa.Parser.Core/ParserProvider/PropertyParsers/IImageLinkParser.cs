using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IImageLinkParser
    {
        string ParseForPreview(HtmlNode htmlNode);
        string ParseForDetailed(HtmlNode htmlNode);
    }
}
