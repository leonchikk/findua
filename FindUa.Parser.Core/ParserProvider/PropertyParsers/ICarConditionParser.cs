using FindUa.Parser.Core.Entities;
using HtmlAgilityPack;

namespace FindUa.Parser.Core.ParserProvider.PropertyParsers
{
    public interface ICarConditionParser
    {
        CarCondition ParseForPreview(HtmlNode htmlNode);
        CarCondition ParseForDetailed(HtmlNode htmlNode);
    }
}
