using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IModelParser
    {
        TransportModel ParseForPreview(HtmlNode htmlNode);
        TransportModel ParseForDetailed(HtmlNode htmlNode);
    }
}
