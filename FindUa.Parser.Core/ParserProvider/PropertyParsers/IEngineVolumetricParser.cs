using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IEngineVolumetricParser
    {
        int ParseForPreview(HtmlNode htmlNode);
        int ParseForDetailed(HtmlNode htmlNode);
    }
}
