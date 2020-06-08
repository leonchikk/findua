using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IEngineTypeParser
    {
        EngineType ParseForPreview(HtmlNode htmlNode);
        EngineType ParseForDetailed(HtmlNode htmlNode);
    }
}
