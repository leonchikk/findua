using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IVehicleTypeParser
    {
        int ParseForPreview(HtmlNode htmlNode);
        int ParseForDetailed(HtmlNode htmlNode);
    }
}
