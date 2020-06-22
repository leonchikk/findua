using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface IBrandModelParser
    {
        (int? BrandId, int? ModelId) ParseForPreview(HtmlNode htmlNode);
        (int? BrandId, int? ModelId) ParseForDetailed(HtmlNode htmlNode);
    }
}
