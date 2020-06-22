using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IDriveUnitParser
    {
        int ParseForPreview(HtmlNode htmlNode);
        int ParseForDetailed(HtmlNode htmlNode);
    }
}
